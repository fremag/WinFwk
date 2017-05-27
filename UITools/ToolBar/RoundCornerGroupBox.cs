using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace WinFwk.UITools.ToolBar
{
    //
    // Thanks to:
    // https://stackoverflow.com/questions/39226946/custom-groupbox-with-round-edges
    //
    public class RoundCornerGroupBox : GroupBox
    {
        public Color TitleBackColor { get; set; } = Color.Green;
        public Color TitleForeColor { get; set; } = Color.White;
        public int Radius { get; set; }
        public int BorderWidth { get; set; } = 1;

        public RoundCornerGroupBox()
        {
            DoubleBuffered = true;
            Radius = 2 * (int)Font.Size;
            Padding = new Padding(BorderWidth);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            if (string.IsNullOrEmpty(Text))
            {
                return;
            }
            GroupBoxRenderer.DrawParentBackground(e.Graphics, ClientRectangle, this);
            var rect = ClientRectangle;
            using (var path = GetRoundRectangle(ClientRectangle, Radius))
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                rect = new Rectangle(0, 0, rect.Width, Font.Height + Padding.Bottom + Padding.Top);

                // Draw background
                if (BackColor != Color.Transparent)
                {
                    using (var brush = new SolidBrush(BackColor))
                    {
                        e.Graphics.FillPath(brush, path);
                    }
                }

                // Fill text area
                var clip = e.Graphics.ClipBounds;
                e.Graphics.SetClip(rect);
                using (var brush = new SolidBrush(TitleBackColor))
                {
                    e.Graphics.FillPath(brush, path);
                }

                // Draw Title text
                var textRect = new Rectangle(Radius / 2, BorderWidth, rect.Width - Radius, rect.Height);
                TextRenderer.DrawText(e.Graphics, Text, Font, textRect, TitleForeColor, Color.Transparent, TextFormatFlags.Left);

                // Draw Border
                e.Graphics.SetClip(clip);
                using (var pen = new Pen(TitleBackColor, BorderWidth))
                {
                    e.Graphics.DrawPath(pen, path);
                }
            }
        }

        private GraphicsPath GetRoundRectangle(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.X + rect.Width - radius - 1, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.X + rect.Width - radius - 1, rect.Y + rect.Height - radius - 1, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Y + rect.Height - radius - 1, radius, radius, 90, 90);
            path.CloseAllFigures();
            return path;
        }
    }
}
