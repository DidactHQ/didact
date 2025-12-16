namespace DidactCore.Flows
{
    public interface IFlowContext
    {
        public long FlowId { get; set; }

        public string? Name { get; set; }

        public string TypeName { get; set; }
    }
}
