using System.Drawing;
using WeifenLuo.WinFormsUI.Docking;

namespace WinFwk.UITools.ToolBar
{
    public class UIToolBarSettings
    {
        public static readonly UIToolBarSettings Main = new UIToolBarSettings("Main", int.MinValue, Properties.Resources.small_folder_vertical_open, DockState.DockTop, true);
        public static readonly UIToolBarSettings Help = new UIToolBarSettings("Help", int.MaxValue, Properties.Resources.small_help, DockState.DockTop);

        public static readonly string SubGroupView = "View";
        public static readonly string SubGroupEdit = "Edit";
        public static readonly string SubGroupData = "Data";
        public static readonly string SubGroupOptions = "Options";
        public static readonly string SubGroupDebug = "Debug";
        public static readonly string SubGroupHelp = "Help";

        public string Name { get; }
        public int Priority { get; }
        public Bitmap Icon  { get; }
        public DockState DockState { get; }
        public bool MainToolbar { get; }
        public UIToolBarSettings(string name, int priority, Bitmap icon, DockState dockState = DockState.DockTopAutoHide, bool mainToolbar=false)
        {
            Name = name;
            Priority = priority;
            Icon = icon;
            DockState = dockState;
            MainToolbar = mainToolbar;
        }
    }
}
