using System.Drawing;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using WinFwk.UICommands;
using WinFwk.UIMessages;
using WinFwk.UIModules;
using WinFwk.UITools.ToolBar;

namespace WinFwk.UITools.Configuration
{
    public class RunConfigEditorCommand : AbstractTypedUICommand<IConfigurableModule>
    {
        public readonly static Image LargeIcon = Properties.Resources.wrench_orange;
        public readonly static Image SmallIcon = Properties.Resources.small_wrench_orange;

        public RunConfigEditorCommand() : base("Config", "Edit module's configuration", UIToolBarSettings.Main.Name, LargeIcon, Keys.None, UIToolBarSettings.SubGroupOptions)
        {
        }

        public override void HandleAction(IConfigurableModule configurableModule)
        {
            RunConfigEditor(configurableModule, MessageBus);
        }

        public static void RunConfigEditor(IConfigurableModule configurableModule, MessageBus messageBus)
        {
            var config = configurableModule.ModuleConfig;
            RunConfigEditor(configurableModule, messageBus, config);
        }

        public static void RunConfigEditor(IConfigurableModule configurableModule, MessageBus messageBus, IModuleConfig moduleConfig)
        {
            UIModuleFactory.CreateModule<UIConfigEditorModule>(module => module.Setup(configurableModule, moduleConfig), DockState.DockRight);
        }
    }
}
