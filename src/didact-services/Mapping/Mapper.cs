using DidactServices.FlowRuns;
using DidactServices.Workers;

namespace DidactServices.Mapping
{
    public static class Mapper
    {
        public static WorkerContext MapToWorkerContext(this FlowRunWorkerContextDto flowRunWorkerContextDto)
        {
            return new WorkerContext();
        }
    }
}
