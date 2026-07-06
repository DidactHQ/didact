using DidactCore.Deployments;
using DidactCore.Director;
using DidactCore.Environments;
using DidactCore.Flows;
using DidactCore.Steps;
using DidactDomain.FlowRuns;
using DidactDomain.Steps;
using System;
using System.Threading.Tasks;

namespace DidactDomain.Director
{
    public class Director : IDirector
    {
        private readonly IStepRepository _stepRepository;
        private readonly IFlowRunRepository _flowRunRepository;
        private readonly IEnvironmentContext _environmentContext;
        private readonly IDeploymentContext _deploymentContext;
        private readonly IFlowContext _flowContext;
        private readonly IFlowRunContext _flowRunContext;

        public Director(IStepRepository stepRepository, IFlowRunRepository flowRunRepository, IEnvironmentContext environmentContext,
            IDeploymentContext deploymentContext, IFlowContext flowContext, IFlowRunContext flowRunContext)
        {
            _stepRepository = stepRepository;
            _flowRunRepository = flowRunRepository;
            _environmentContext = environmentContext;
            _deploymentContext = deploymentContext;
            _flowContext = flowContext;
            _flowRunContext = flowRunContext;
        }

        public async Task<IFlowRunContext> CreateSubflowRunAsync(string flowName, string? jsonPayload, DateTime? executeAt)
        {
            return await _flowRunRepository.CreateSubflowRunAsync(flowName, jsonPayload, executeAt);
        }

        public async Task ExecuteStepAsync(string name, Func<IStepExecutionContext, Task> function)
        {
            // Check for existence of step, using either cache or database.
            var stepContext = await _stepRepository.GetOrCreateStepAsync(_flowRunContext.FlowRunId, name);
        }

        public async Task<TOutput> ExecuteStepAsync<TOutput>(string name, Func<IStepExecutionContext, Task<TOutput>> function)
        {
            // Check for existence of step, using either cache or database.
            var stepContext = await _stepRepository.GetOrCreateStepAsync(_flowRunContext.FlowRunId, name);

            // Get context.
            var stepExecutionContext = new IStepExecutionContext();

            // Pass context into function.
            var result = await function(stepExecutionContext);
            return result;
        }
    }
}
