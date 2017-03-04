using WinFwk.UIMessages;

namespace WinFwk.UITools.Configuration
{
    public class OpenModuleConfigurationEditorRequest : AbstractUIMessage
    {
        public IConfigurableModule ConfigurableModule { get; }
        public IModuleConfig ModuleConfig { get; }

        public OpenModuleConfigurationEditorRequest(IConfigurableModule configurableModule, IModuleConfig moduleConfig)
        {
            ConfigurableModule = configurableModule;
            ModuleConfig = moduleConfig;
        }
    }
}
