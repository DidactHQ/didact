using DidactCore.Flows;
using DidactCore.Triggers;
using System.Threading.Tasks;

namespace DidactCore
{
    public class SomeFlow : IFlow
    {
        private readonly IFlowLogger _flowLogger;

        public SomeFlow(IFlowLogger flowLogger)
        {
            _flowLogger = flowLogger;
        }

        public Task<IFlowConfigurator> ConfigureAsync(IFlowConfigurator flowConfigurator)
        {
            flowConfigurator
                .WithTypeName(GetType().Name)
                .WithDescription("A sample flow")
                .WithCronScheduleTrigger(new CronScheduleTrigger("test"));

            return Task.FromResult(flowConfigurator);
        }

        public async Task ExecuteAsync(IFlowExecutionContext context)
        {
            _flowLogger.LogInformation("Starting work...");
            await Task.Delay(1000);
            _flowLogger.LogInformation("Work completed.");
        }
    }
}
