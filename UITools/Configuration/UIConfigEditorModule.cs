using System;
using System.Windows.Forms;
using WinFwk.UIModules;

namespace WinFwk.UITools.Configuration
{
    public partial class UIConfigEditorModule : UIModule
    {
        private IModuleConfig original;
        private IModuleConfig workingCopy;
        private IModuleConfigEditor editor;

        public UIConfigEditorModule()
        {
            InitializeComponent();
        }

        public void Setup(IConfigurableModule module, IModuleConfig moduleConfig)
        {
            // Todo : find something to avoid those cast / as
            UIModuleParent = module as UIModule;
            editor = module.CreateEditor();
            var editorControl = editor as UserControl;
            if (editorControl == null)
            {
                return;
            }
            Name = "Config Editor";
            Icon = Properties.Resources.small_wrench_orange;
            Summary = "test";

            original = moduleConfig;
            ResetEditor();
            editorControl.Dock = DockStyle.Fill;
            toolStripContainer1.ContentPanel.Controls.Add(editorControl);
        }

        private void ResetEditor()
        {
            workingCopy = original.Clone() as IModuleConfig;
            editor.Init(workingCopy);
        }

        private void tsbUndo_Click(object sender, System.EventArgs e)
        {
            ResetEditor();
        }

        private void tsbApply_Click(object sender, System.EventArgs e)
        {
            workingCopy.OwnerModule.Apply(workingCopy);
        }
    }
}
