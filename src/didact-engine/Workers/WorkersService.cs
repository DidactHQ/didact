namespace DidactEngine.Workers
{
    public class WorkersService
    {
        public WorkersService()
        {
        }

        public async Task PollDatabaseForCompatibleFlowRunAsync(CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }

        public async Task InstantiateFlowAsync(WorkerContext workerContext, CancellationToken cancellationToken)
        {

        }

        public async Task PollFlowRunCancellationAsync(WorkerContext workerContext, CancellationToken compositeCancellationToken)
        {

        }

        public async Task ExecuteFlowRunTimeoutCountdownAsync(WorkerContext workerContext, CancellationToken compositeCancellationToken)
        {

        }

        public async Task ExecuteFlowRunAsync(WorkerContext workerContext, CancellationToken compositeCancellationToken)
        {

        }

        public async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }
    }
}
