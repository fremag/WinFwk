using WinFwk.UIMessages;
using WinFwk.UIServices;

namespace WinFwk.UITools.Configuration
{
    public class ModuleConfigurationService : AbstractUIService, IMessageListener<OpenModuleConfigurationEditorRequest>
    {
        public void HandleMessage(OpenModuleConfigurationEditorRequest message)
        {
            RunConfigEditorCommand.RunConfigEditor(message.ConfigurableModule, MessageBus, message.ModuleConfig);
        }
    }
}
