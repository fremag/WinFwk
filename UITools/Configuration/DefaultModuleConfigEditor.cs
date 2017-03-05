using System.Collections.Generic;
using System.Windows.Forms;

namespace WinFwk.UITools.Configuration
{

    public partial class DefaultModuleConfigEditor : UserControl, IModuleConfigEditor
    {
        public IModuleConfig ModuleConfig => propertyGrid.SelectedObject as IModuleConfig;
        public IEnumerable<IEditorAction> EditorActions => null;

        public DefaultModuleConfigEditor()
        {
            InitializeComponent();
        }

        public void Init(IModuleConfig moduleConfig)
        {
            propertyGrid.SelectedObject = moduleConfig;
        }
    }
}
