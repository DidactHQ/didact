using DidactCore.Constants;
using DidactCore.Exceptions;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace DidactCore.Blocks
{
    /// <summary>
    /// A synchronous execution wrapper that takes an input of type T and returns no output.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ActionBlock<T>
    {
        private readonly ILogger _logger;
        private readonly IBlockRepository _blockRepository;

        /// <summary>
        /// The executor of the block which is, specifically, an Action delegate with one input parameter T.
        /// </summary>
        public Action<T> Action { get; private set; }

        /// <summary>
        /// The input parameter for the executor.
        /// </summary>
        public T Parameter { get; private set; }

        /// <summary>
        /// <para>The name of the block.</para>
        /// <para>This parameter is optional, but its use is highly recommended for convenience in logging and observability.</para>
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// <para>An internal property that represents the block's execution state, or BlockState.</para>
        /// <para>This BlockState changes values appropriately as an execution attempt is made against the block.</para>
        /// <para>Default value is Idle.</para>
        /// </summary>
        public string State { get; private set; } = BlockStates.Idle;

        /// <summary>
        /// <para>The maximum number of retry attempts allowed in case an execution attempt against the block throws an exception.</para>
        /// <para>Default value is 0.</para>
        /// </summary>
        public int MaxRetries { get; private set; } = 0;

        /// <summary>
        /// <para>A delay (in milliseconds) between retry attempts.</para>
        /// <para>This is a constant value that is used between each retry attempt until the MaxRetries is met.</para>
        /// <para>Default is 0.</para>
        /// </summary>
        public int RetryDelayMilliseconds { get; private set; } = 0;

        /// <summary>
        /// <para>
        ///     A soft timeout (in milliseconds) to limit the elapsed execution time of the block.
        /// </para>
        /// <para>
        ///     Notice the terminology here: this property is a soft timeout, meaning it will not force abort an execution.
        ///     Rather, the block periodically checks for a SoftTimeout violation at various lifecycle events of the execution attempt.
        /// </para>
        /// <para>
        ///     If a SoftTimeout violation occurs, the block is marked for cancellation and the BlockState is updated appropriately.
        /// </para>
        /// <para>
        ///     Default is 3,600,000 milliseconds (1 hour).
        /// </para>
        /// </summary>
        public int SoftTimeoutMilliseconds { get; private set; } = 3600000;

        /// <summary>
        /// <para>
        ///     An internal property that tracks the number of retries attempted.
        /// </para>
        /// <para>
        ///     Default is 0.
        /// </para>
        /// </summary>
        public int RetriesAttempted { get; private set; } = 0;

        /// <summary>
        /// A boolean flag indicating whether the SoftTimeoutMilliseconds has been violated or not.
        /// </summary>
        public bool SoftTimeoutExceeded { get; private set; }


        public ActionBlock(ILogger logger, IBlockRepository blockRepository)
        {
            _logger = logger;
            _blockRepository = blockRepository;
        }

        /// <summary>
        /// Sets the delegate to execute. Since this is a delegate, it can be many things, like an expression tree that you define in this constructor or a method from somewhere else.
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public ActionBlock<T> WithExecutor(Action<T> action)
        {
            Action = action;
            return this;
        }

        /// <summary>
        /// Sets the arguments for the executor (delegate).
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ActionBlock<T> WithArgs(T param)
        {
            Parameter = param;
            return this;
        }

        /// <summary>
        /// Sets the name of the ActionBlock.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ActionBlock<T> WithName(string name)
        {
            Name = name;
            return this;
        }

        /// <summary>
        /// Sets the soft timeout threshold for the block.
        /// The soft timeout will NOT abort the delegate's execution, but it will check for a violation before and after the delegate's execution and retries.
        /// </summary>
        /// <param name="softTimeoutThreshold"></param>
        /// <returns></returns>
        public ActionBlock<T> WithSoftTimeout(int softTimeoutMilliseconds)
        {
            SoftTimeoutMilliseconds = softTimeoutMilliseconds;
            return this;
        }

        /// <summary>
        /// Sets the maximum number of retry attempts and the constant delay that should be used between each of them.
        /// </summary>
        /// <param name="maxRetries"></param>
        /// <param name="retryDelayMilliseconds"></param>
        /// <returns></returns>
        public ActionBlock<T> WithRetries(int maxRetries, int retryDelayMilliseconds)
        {
            MaxRetries = maxRetries;
            RetryDelayMilliseconds = retryDelayMilliseconds;
            return this;
        }

        private async Task ExecuteDelegateAsync()
        {
            if (Action == null || Parameter == null)
            {
                throw new NullBlockExecutorException("The executor or its arguments were not properly satisfied.");
            }

            while (RetriesAttempted <= MaxRetries)
            {
                if (SoftTimeoutExceeded)
                {
                    State = BlockStates.Cancelled;
                    _logger.LogInformation("The soft timeout threshold has been exceeded. Cancelling execution...");
                    break;
                }

                try
                {
                    State = BlockStates.Running;
                    _logger.LogInformation("Action Block {name} executing delegate...", Name);
                    Action(Parameter);
                    State = BlockStates.Succeeded;
                    break;
                }
                catch (Exception ex)
                {
                    RetriesAttempted++;

                    if (RetriesAttempted <= MaxRetries)
                    {
                        if (SoftTimeoutExceeded)
                        {
                            State = BlockStates.Cancelled;
                            _logger.LogInformation("The soft timeout threshold has been exceeded. Cancelling execution...");
                            break;
                        }

                        State = BlockStates.Failing;
                        _logger.LogError("Action Block {name} encountered an unhandled exception. See details: {ex}", Name, ex.Message);
                        _logger.LogInformation("Action Block {name} awaiting retry delay...", Name);
                        await Task.Delay(RetryDelayMilliseconds);
                        State = BlockStates.Retrying;
                        _logger.LogInformation("Action Block {name} attempting retry...", Name);

                        if (SoftTimeoutExceeded)
                        {
                            State = BlockStates.Cancelled;
                            _logger.LogInformation("The soft timeout threshold has been exceeded. Cancelling execution...");
                            break;
                        }

                        continue;
                    }
                    else
                    {
                        State = BlockStates.Failed;
                        _logger.LogCritical("Action Block {name} has encountered an unhandled exception and has now failed. See details: {ex}", Name, ex.Message);
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Asynchronously executes the delegate on a Task.
        /// </summary>
        /// <returns></returns>
        public async Task ExecuteAsync()
        {
            var timeoutTask = Task.Delay(SoftTimeoutMilliseconds);
            var delegateTask = ExecuteDelegateAsync();

            if (timeoutTask == await Task.WhenAny(delegateTask, timeoutTask))
            {
                State = BlockStates.Cancelling;
                _logger.LogCritical("Action Block {name} exceeded its soft timeout threshold. Marking for cancellation...", Name);
                SoftTimeoutExceeded = true;
            }

            await delegateTask;
        }
    }
}
