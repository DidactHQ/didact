namespace DidactEngine.Modules
{
    public abstract class PollingModule : IPollingModule
    {
        private readonly ILogger _logger;

        protected PollingModule(ILogger logger)
        {
            _logger = logger;
        }

        public abstract string Name { get; }

        public bool Enabled => true;

        public virtual IReadOnlyCollection<Type> Dependencies => Array.Empty<Type>();

        public abstract TimeSpan PollingInterval { get; }

        public async Task RunAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Polling module {ModuleName} started.", Name);

            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    try
                    {
                        await PollAsync(cancellationToken);
                    }
                    catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
                    {
                        break;
                    }
                    catch (Exception exception)
                    {
                        await HandleTransientFailureAsync(exception, cancellationToken);
                    }

                    await Task.Delay(PollingInterval, cancellationToken);
                }
            }
            catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
            {
                // Expected during engine shutdown.
            }
            finally
            {
                _logger.LogInformation("Polling module {ModuleName} stopped.", Name);
            }
        }

        protected abstract Task PollAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Handles a recoverable polling failure. The default treats the failure as fatal.
        /// Override only for exceptions the concrete module can safely recover from.
        /// </summary>
        protected virtual Task HandleTransientFailureAsync(Exception exception, CancellationToken cancellationToken)
        {
            return Task.FromException(exception);
        }
    }
}
