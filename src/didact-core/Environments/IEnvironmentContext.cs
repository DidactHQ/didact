namespace DidactCore.Environments
{
    public interface IEnvironmentContext
    {
        public long EnvironmentId { get; set; }

        public string Name { get; set; }
    }
}
