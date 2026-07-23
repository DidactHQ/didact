using DidactPrimitives.Constants;

namespace DidactEngine.Modules
{
    public class ModuleStatus
    {
        public IModule Module { get; init; }

        public string State { get; set; } = ModuleStates.Ready;

        public DateTime? StateChangedAt { get; set; }

        public ModuleStatus(IModule module) => Module = module;
    }
}
