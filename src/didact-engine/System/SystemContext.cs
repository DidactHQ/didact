namespace DidactEngine.System
{
    public class SystemContext
    {
        public string MachineName { get; set; } = Environment.MachineName;

        public int ProcessId { get; set; } = Environment.ProcessId;
    }
}
