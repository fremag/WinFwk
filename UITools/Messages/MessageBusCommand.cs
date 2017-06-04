using System.Windows.Forms;
using WinFwk.UICommands;
using WinFwk.UIModules;
using WinFwk.UITools.ToolBar;

namespace WinFwk.UITools.Messages
{
    public class MessageBusCommand : AbstractVoidUICommand
    {
        public MessageBusCommand() : base("MessageBus", "View message bus subscribers", UIToolBarSettings.Help.Name, Properties.Resources.chart_organisation, Keys.None, UIToolBarSettings.SubGroupDebug)
        {
        }

        public override void Run()
        {
            UIModuleFactory.CreateModule<MessageBusModule>(module => { });
        }
    }
}
