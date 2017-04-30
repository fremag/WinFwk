using System.Drawing;
using System.Drawing.Drawing2D;

namespace WinFwk.UITools.Settings.Skins
{
    public class DarkSkin : AbstractSkin
    {
        public override string Name => "Dark";

        public override void Apply(UISettings settings)
        {
            settings.AlternateRowColor = Color.Gray;
            settings.BackgroundColor = Color.Black;
            settings.ForegroundColor= Color.White;
            settings.DisabledTextColor = Color.Gray;

            settings.HeaderBackColor = Color.DimGray;
            settings.HeaderForeColor= Color.White;

            settings.DockStripGradient.StartColor = Color.Gray;
            settings.DockStripGradient.EndColor = Color.Black;
            settings.DockStripGradient.LinearGradientMode = LinearGradientMode.Vertical;
            settings.DockStripGradient.TextColor = Color.White;

            settings.ActiveTabGradient.StartColor = Color.Gray;
            settings.ActiveTabGradient.EndColor = Color.Black;
            settings.ActiveTabGradient.LinearGradientMode = LinearGradientMode.Vertical;
            settings.ActiveTabGradient.TextColor = Color.White;

            settings.InactiveTabGradient.StartColor = Color.Gray;
            settings.InactiveTabGradient.EndColor = Color.Black;
            settings.InactiveTabGradient.LinearGradientMode = LinearGradientMode.Vertical;
            settings.InactiveTabGradient.TextColor = Color.White;

            settings.ActiveCaptionGradient.StartColor = Color.Gray;
            settings.ActiveCaptionGradient.EndColor = Color.Black;
            settings.ActiveCaptionGradient.LinearGradientMode = LinearGradientMode.Vertical;
            settings.ActiveCaptionGradient.TextColor = Color.White;

            settings.InactiveCaptionGradient.StartColor = Color.Gray;
            settings.InactiveCaptionGradient.EndColor = Color.Black;
            settings.InactiveCaptionGradient.LinearGradientMode = LinearGradientMode.Vertical;
            settings.InactiveCaptionGradient.TextColor = Color.White;
        }
    }
}
