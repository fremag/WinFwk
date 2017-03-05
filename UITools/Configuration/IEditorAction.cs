using System.Drawing;

namespace WinFwk.UITools.Configuration
{
    public interface IEditorAction
    {
        string Text { get; }
        Image Icon { get; }
        void DoWork();
    }
}
