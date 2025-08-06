using System.Collections.Concurrent;

namespace DidactEngine.TaskSchedulers
{
    public class DidactThreadPoolScheduler : TaskScheduler
    {
        private readonly ILogger<DidactThreadPoolScheduler> _logger;

        private readonly ThreadLocal<bool> _currentThreadIsExecuting = new(false);

        private readonly ThreadLocal<string> _currentThreadName = new();

        private readonly int _maxDegreeOfParallelism;

        private readonly Thread[] _threads;

        private readonly ConcurrentQueue<Task> _tasks;

        public DidactThreadPoolScheduler(ILogger<DidactThreadPoolScheduler> logger, int maxDegreeOfParallelism)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            _maxDegreeOfParallelism = maxDegreeOfParallelism <= 0
                ? throw new ArgumentOutOfRangeException(nameof(maxDegreeOfParallelism))
                : maxDegreeOfParallelism;

            _tasks = new ConcurrentQueue<Task>();
            _threads = new Thread[maxDegreeOfParallelism];

            // Configure each thread
            for (int i = 0; i < _maxDegreeOfParallelism; i++)
            {
                _threads[i] = new Thread(() => ThreadExecutionLoop())
                {
                    IsBackground = true,
                    // Might need to modify this later to include MachineName and/or ProcessId for distributed environments.
                    // That should only matter if saving logs in persistent storage. Otherwise, we won't worry about it for now.
                    Name = $"{nameof(DidactThreadPoolScheduler)} Thread {i}"
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
                    var taskDequeued = _tasks.TryDequeue(out var task);
                    if (taskDequeued)
                    {
                        TryExecuteTask(task!);
                    }
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
            _tasks.Enqueue(task);
        }

        protected sealed override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
        {
            // IMPORTANT: This was a difficult requirement that was not intuitive to me.
            // We have to PREVENT .NET ThreadPool threads from executing inline Tasks, so check if the CurrentThread is a Didact thread.
            // If it is not, stop it from executing by returning false.
            if (_threads.SingleOrDefault(t => t == Thread.CurrentThread) is null) return false;

            // If the task was previously enqueued, we can't arbitrarily remove it from the FIFO queue.
            // So we just have to wait for it to be executed.
            if (taskWasPreviouslyQueued)
            {
                return false;
            }
            // If the task was not previously enqueued, go ahead and inline execute it and skip the FIFO queue.
            else
            {
                return TryExecuteTask(task);
            }
        }

        protected sealed override IEnumerable<Task> GetScheduledTasks()
        {
            return _tasks.ToArray();
        }
    }
}
