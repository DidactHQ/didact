using DidactCore.Flows;
using DidactCore.Triggers;
using System.Threading.Tasks;

namespace DidactCore
{
    public class SomeFlow : IFlow
    {
        public SomeFlow() { }

        public Task<IFlowConfigurator> ConfigureAsync(IFlowConfigurator flowConfigurator)
        {
            flowConfigurator
                .WithName("An example flow")
                .WithDescription("A sample flow")
                .AsVersion("1.0.0")
                .WithCronScheduleTrigger(new CronScheduleTrigger("test"));

            return Task.FromResult(flowConfigurator);
        }

        public async Task ExecuteAsync(IFlowExecutionContext context)
        {
            var logger = context.Logger;
            logger.LogInformation("Starting work...");
            await Task.CompletedTask;
            logger.LogInformation("Work completed.");
        }
    }
}
