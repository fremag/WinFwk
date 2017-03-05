using System.Windows.Forms;
using WinFwk.UIModules;

namespace WinFwk.UITools.Configuration
{
    public partial class UIConfigEditorModule : UIModule
    {
        private IModuleConfig original;
        private IModuleConfig workingCopy;
        private IModuleConfigEditor editor;
        private IConfigurableModule ownerModule;

        public UIConfigEditorModule()
        {
            InitializeComponent();
        }

        public void Setup(IConfigurableModule module, IModuleConfig moduleConfig)
        {
            ownerModule = module;
            // Todo : find something to avoid those cast / as
            UIModuleParent = module as UIModule;
            editor = module.CreateEditor();
            var editorControl = editor as UserControl;
            if (editorControl == null)
            {
                return;
            }
            Name = moduleConfig?.GetType().Name;
            Icon = Properties.Resources.small_wrench_orange;
            Summary = moduleConfig?.ToString();

            original = moduleConfig;
            ResetEditor();
            editorControl.Dock = DockStyle.Fill;
            toolStripContainer1.ContentPanel.Controls.Add(editorControl);

            if(editor.EditorActions != null)
            {
                toolStrip1.Items.Add(new ToolStripSeparator());
                foreach (var action in editor.EditorActions)
                {
                    ToolStripButton tsb = new ToolStripButton();
                    tsb.ToolTipText = action.Text;
                    tsb.Image = action.Icon;
                    tsb.Click += (o, e) => action.DoWork();
                    toolStrip1.Items.Add(tsb);
                }
            }
        }

        private void ResetEditor()
        {
            if (original == null)
            {
                workingCopy = null;
            }
            else
            {
                workingCopy = original.Clone() as IModuleConfig;
            }
            editor.Init(workingCopy);
        }

        private void tsbUndo_Click(object sender, System.EventArgs e)
        {
            ResetEditor();
        }

        private void tsbApply_Click(object sender, System.EventArgs e)
        {
            ownerModule.Apply(workingCopy);
        }
    }
}
