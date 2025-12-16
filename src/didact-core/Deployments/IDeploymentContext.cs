namespace DidactCore.Deployments
{
    public interface IDeploymentContext
    {
        public long DeploymentId { get; set; }

        public string? Name { get; set; }
    }
}
