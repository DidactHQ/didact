using DidactDomain.FlowRuns;
using DidactDomain.Workers;

namespace DidactDomain.Mapping
{
    public static class Mapper
    {
        public static WorkerContext MapToWorkerContext(this FlowRunWorkerContextDto flowRunWorkerContextDto)
        {
            return new WorkerContext();
        }
    }
}
