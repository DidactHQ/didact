using DidactCore.Flows;
using Microsoft.Extensions.Logging;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace DidactCore
{
    public class SomeFlow : IFlow
    {
        public Task ConfigureAsync(IFlowConfigurationContext context)
        {
            context.Configurator
                .WithName("scraper")
                .WithDescription("A sample flow")
                .AsVersion("1.0.0")
                .DeferExecutionBy(TimeSpan.FromMinutes(5))
                .WithRetryPolicy(retry => retry
                    .UseFixedInterval(TimeSpan.FromSeconds(30))
                    .WithMaxAttempts(3))

                // Simple schedule methods
                .UseCronSchedule(name: "recurring-schedule", cronExpression: "0 0 * * *")
                .UseOneTimeSchedule(name: "special-schedule", executeAt: DateTime.UtcNow.AddDays(15))

                // Advanced schedule builders
                .UseCronSchedule(cron => cron
                    .WithName("recurring-schedule")
                    .WithCronExpression("0 0 * * *"))
                .UseOneTimeSchedule(oneTime => oneTime
                    .WithName("special-schedule")
                    .ScheduleExecutionAt(DateTime.UtcNow.AddDays(15)));

            return Task.CompletedTask;
        }

        public async Task ExecuteAsync(IFlowExecutionContext context)
        {
            var logger = context.Logger;
            logger.LogInformation("Starting work...");
            await Task.Delay(100);
            logger.LogInformation("Work completed.");

            var someObject = new { httpAction = "POST", url = "someUrl" };
            var someObjectStringified = JsonSerializer.Serialize(someObject);

            var director = context.Director;
            await director.CreateSubflowRunAsync(
                flowName: "subflow",
                jsonPayload: someObjectStringified,
                executeAt: DateTime.Now);

            await context.Director.ExecuteStepAsync(
                name: "step-1",
                function: async stepExecutionContext =>
                {
                    var logger = stepExecutionContext.Logger;
                    logger.LogInformation("Executing step...");
                    await Task.Delay(100);
                    logger.LogInformation("Step execution completed.");
                });

            await context.Director.SuspendFor(name: "first-sleep", duration: TimeSpan.FromDays(5));
            await context.Director.SuspendUntil(name: "second-sleep", resumeAt: DateTime.UtcNow.AddDays(10));

            var step2result = await context.Director.ExecuteStepAsync(
                name: "step-2",
                function: async stepExecutionContext =>
                {
                    var logger = stepExecutionContext.Logger;
                    logger.LogInformation("Executing step...");
                    await Task.Delay(100);
                    logger.LogInformation("Step execution completed.");
                    return "Step 2 result";
                });

            await context.Director.ExecuteStepAsync(
                name: "step-3",
                function: stepExecutionContext =>
                {
                    return Task.CompletedTask;
                });
        }
    }
}