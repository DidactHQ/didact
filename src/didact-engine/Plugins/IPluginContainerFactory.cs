namespace DidactEngine.Plugins
{
    public interface IPluginContainerFactory
    {
        IPluginContainer Create(IPluginContainerContext pluginContainerContext);
    }
}
