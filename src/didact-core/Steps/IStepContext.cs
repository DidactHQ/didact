namespace DidactCore.Steps
{
    public interface IStepContext
    {
        long StepId { get; }

        long FlowRunId { get; }

        string StepName { get; }

        string Status { get; }
    }
}
