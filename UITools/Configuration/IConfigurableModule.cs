using WinFwk.UIMessages;

namespace WinFwk.UITools.Configuration
{
    public interface IConfigurableModule
    {
        IModuleConfigEditor CreateEditor();
        IModuleConfig ModuleConfig { get; }
        void Apply(IModuleConfig config);
    }
}
