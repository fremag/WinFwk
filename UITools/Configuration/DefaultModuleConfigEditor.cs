using System.Windows.Forms;

namespace WinFwk.UITools.Configuration
{

    public partial class DefaultModuleConfigEditor : UserControl, IModuleConfigEditor
    {
        IModuleConfig ModuleConfig { get; set; }

        public DefaultModuleConfigEditor()
        {
            InitializeComponent();
        }

        public void Apply()
        {
            if( ModuleConfig == null)
            {
                return;
            }

            ModuleConfig.OwnerModule.Apply(ModuleConfig);
        }

        public void Init(IModuleConfig moduleConfig)
        {
            propertyGrid.SelectedObject = moduleConfig;
        }
    }
}
