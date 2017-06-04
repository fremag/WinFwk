using System.Windows.Forms;
using WinFwk.UICommands;
using WinFwk.UIModules;
using WinFwk.UITools.ToolBar;

namespace WinFwk.UITools.Messages
{
    public class MessageBusLogCommand : AbstractVoidUICommand
    {
        public MessageBusLogCommand() : base("MessageBus Log", "View messages sent over the bus", UIToolBarSettings.Help.Name, Properties.Resources.raw_access_logs, Keys.None, UIToolBarSettings.SubGroupDebug)
        {
        }

        public override void Run()
        {
            UIModuleFactory.CreateModule<MessageBusLogModule>(module => { });
        }
    }
}
