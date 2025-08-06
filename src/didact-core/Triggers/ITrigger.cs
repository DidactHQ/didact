namespace DidactCore.Triggers
{
    public interface ITrigger
    {
        public string TriggerType { get; }

        public string TriggerScope { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }
    }
}