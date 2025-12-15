using DidactCore.Flows;
using DidactCore.Triggers;
using System.Threading.Tasks;

namespace DidactCore
{
    public class SomeFlow : IFlow
    {
        public Task<IFlowConfigurationContext> ConfigureAsync(IFlowConfigurationContext context)
        {
            context.Configurator
                .WithName("An example flow")
                .WithDescription("A sample flow")
                .AsVersion("1.0.0")
                .WithCronScheduleTrigger(new CronScheduleTrigger("test"));

            return Task.FromResult(context);
        }

        public async Task ExecuteAsync(IFlowExecutionContext context)
        {
            var logger = context.Logger;
            logger.LogInformation("Starting work...");
            await Task.Delay(100);
            logger.LogInformation("Work completed.");
        }
    }
}