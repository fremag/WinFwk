using System;
using System.Drawing;

namespace WinFwk.UITools.Configuration
{
    public class DefaultEditorAction : IEditorAction
    {
        private Action Action;

        public string Text { get; }
        public Image Icon { get; }

        public DefaultEditorAction(string text, Image icon, Action action)
        {
            Text = text;
            Icon = icon;
            Action = action;
        }

        public void DoWork()
        {
            Action();
        }
    }
}
