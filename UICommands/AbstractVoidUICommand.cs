using System.Drawing;
using System.Windows.Forms;
using WinFwk.UIModules;

namespace WinFwk.UICommands
{
    public abstract class AbstractVoidUICommand : AbstractUICommand
    {
        protected AbstractVoidUICommand(string name, string toolTip, string @group, Image icon, Keys shortcut=Keys.None, string subGroup=null) : base(name, toolTip, @group, icon, shortcut, subGroup)
        {
        }

        public override void SetSelectedModule(UIModule module)
        {
            selectedModule = module;
            Enabled = true;
        }
    }
}