using System.Drawing;
using System.Windows.Forms;

namespace WinFwk.UITools.ToolBar
{
    public class UICommandButton : Button
    {
        public Color DisabledTextColor { get; set; } = Color.Empty;
        protected override void OnPaint(PaintEventArgs pe)
        {
            // Calling the base class OnPaint
            base.OnPaint(pe);
            if (!Enabled && DisabledTextColor != Color.Empty && DisabledTextColor.A != 0)
            {
                float y = (Height / 2) - (pe.Graphics.MeasureString(Text, Font).Height / 2);
                if (Image != null)
                {
                    y += Image.Height / 2;
                }
                // Draw the text in the button in red
                pe.Graphics.DrawString(Text, Font, new SolidBrush(DisabledTextColor), (Width - pe.Graphics.MeasureString(Text, Font).Width) / 2, y);
            }
        }
    }
}
