using DidactCore.Engine;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DidactCore.Threading
{
    public class DidactThreadpoolTaskScheduler : TaskScheduler
    {
        private readonly ILogger<DidactThreadpoolTaskScheduler> _logger;

        private readonly CancellationToken _cancellationToken;

        private readonly ThreadLocal<bool> _currentThreadIsExecuting = new(false);

        private readonly ThreadLocal<string> _currentThreadName = new();

        private readonly long _threadCount;

        private readonly Thread[] _threads;

        private readonly BlockingCollection<Task> _tasks;

        /// <summary>
        /// <para>
        /// Initializes a custom <see cref="TaskScheduler"/> with a dedicated thread pool for fetching and executing FlowRuns.
        /// </para>
        /// <para>
        /// Remember that we have three essential performance parameters to balance: processor count, thread count, and task count.
        /// </para>
        /// </summary>
        public DidactThreadpoolTaskScheduler(ILogger<DidactThreadpoolTaskScheduler> logger, IEngineSupervisor engineSupervisor, decimal threadFactor)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _cancellationToken = engineSupervisor.CancellationToken;
            _tasks = [];

            var threadCount = (long)Math.Ceiling(Environment.ProcessorCount * threadFactor);
            _threadCount = threadCount <= 0
                ? throw new ArgumentOutOfRangeException(nameof(threadCount))
                : threadCount;

            _threads = new Thread[_threadCount];

            // Configure each thread
            for (int i = 0; i < _threadCount; i++)
            {
                _threads[i] = new Thread(() => ThreadExecutionLoop())
                {
                    IsBackground = true,
                    // Might need to modify this later to include MachineName and/or ProcessId for distributed environments.
                    // That should only matter if saving logs in persistent storage. Otherwise, we won't worry about it for now.
                    Name = $"{nameof(DidactThreadpoolTaskScheduler)} Thread {i}"
                };
            }

            // Start each thread
            _threads.ToList().ForEach(t => t.Start());
        }

        private void ThreadExecutionLoop()
        {
            _currentThreadIsExecuting.Value = true;
            _currentThreadName.Value = Thread.CurrentThread.Name!;

            while (true)
            {
                try
                {
                    // Block the thread to avoid busy waiting.
                    // Only take one task at a time to evenly distribute work if others are freed.
                    var task = _tasks.Take(_cancellationToken);
                    TryExecuteTask(task);
                }
                catch (OperationCanceledException)
                {
                    // If the engine is shutting down, let the FlowRuns finish gracefully.
                    // So we will swallow the exception here and not worry about it.
                }
                catch (ThreadInterruptedException ex)
                {
                    _logger.LogCritical("A {exName} occurred on thread {threadName}. See inner exception: {ex}", nameof(ThreadInterruptedException), _currentThreadName, ex);
                    throw;
                }
                catch (Exception ex)
                {
                    _logger.LogCritical("An unhandled exception occurred on thread {threadName}. See inner exception: {ex}", _currentThreadName, ex);
                    throw;
                }
            }
        }

        protected sealed override void QueueTask(Task task)
        {
            _tasks.Add(task);
        }

        protected sealed override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
        {
            // IMPORTANT: This was a difficult requirement that was not intuitive to me.
            // We have to PREVENT .NET ThreadPool threads from executing inline Tasks, so check if the CurrentThread is a Didact thread.
            // If it is not, stop it from executing by returning false.
            // Also, Microsoft generally recommends allowing for inline execution when using custom threads.
            // See https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.taskscheduler
            var isDidactThread = _currentThreadIsExecuting.Value;
            return isDidactThread && TryExecuteTask(task);
        }

        protected sealed override IEnumerable<Task> GetScheduledTasks()
        {
            return _tasks.ToArray();
        }
    }
}
