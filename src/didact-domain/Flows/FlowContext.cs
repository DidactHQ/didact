namespace DidactDomain.Flows
{
    public class FlowContext
    {
        public long FlowId { get; set; }

        public string? Name { get; set; }

        public string TypeName { get; set; } = null!;
    }
}
