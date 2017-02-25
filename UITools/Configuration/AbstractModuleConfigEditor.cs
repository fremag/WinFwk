using System.Windows.Forms;

namespace WinFwk.UITools.Configuration
{
    public abstract class AbstractModuleConfigEditor : UserControl, IModuleConfigEditor
    {
        public abstract void Apply();
        public abstract void Init(IModuleConfig moduleConfig);
    }
}
