using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Xml.Serialization;
using WinFwk.UITools.Settings.Skins;

namespace WinFwk.UITools.Settings
{
    public enum Themes {
        VS2003,
        VS2005,
        VS2012Blue,
        VS2012Dark,
//        VS2012Light,
//        VS2013Blue,
        VS2013Dark,
        VS2013Light,
        VS2015Blue,
        VS2015Dark,
        VS2015Light
    }
    public class UISettings
    {
        public static UISettings Instance { get; private set; }

        internal static void InitSettings(UISettings uiSettings)
        {
            Instance = uiSettings;
        }

        public UISettings()
        {
            DockStripGradient = new GradientConfig();
            ActiveTabGradient = new GradientConfig();
            InactiveTabGradient = new GradientConfig();

            ActiveCaptionGradient = new GradientConfig() { TextColor = SystemColors.ActiveCaptionText };
            InactiveCaptionGradient = new GradientConfig() { TextColor = SystemColors.InactiveCaptionText };
        }

        [Category("__Global")]
        [DisplayName("Theme - Need to save and restart")]
        public Themes Theme { get; set; } 

        [Category("__Global")]
        [Editor(typeof(SkinTypeEditor), typeof(UITypeEditor))]
        [DisplayName("Select and apply pre set skin")]
        [XmlIgnore]
        public AbstractSkin Skin
        {
            get
            {
                return null;
            }
            set
            {
                if (value == null)
                {
                    return;
                }
                value.Apply(this);
            }
        }

        [XmlIgnore]
        [Category("GUI - Main")]
        public Color BackgroundColor { get; set; }
        [Browsable(false)]
        public string BackgroundColorStr
        {
            get
            {
                return WinFwkHelper.ToString(BackgroundColor);
            }
            set
            {
                BackgroundColor = WinFwkHelper.FromString(value);
            }
        }

        [XmlIgnore]
        [Category("GUI - Main")]
        public Color ForegroundColor { get; set; }
        [Browsable(false)]
        public string ForegroundColorStr
        {
            get
            {
                return WinFwkHelper.ToString(ForegroundColor);
            }
            set
            {
                ForegroundColor = WinFwkHelper.FromString(value);
            }
        }

        [XmlIgnore]
        [Category("GUI - Main")]
        public Color DisabledTextColor { get; set; }
        [Browsable(false)]
        public string DisabledTextStr
        {
            get
            {
                return WinFwkHelper.ToString(DisabledTextColor);
            }
            set
            {
                DisabledTextColor = WinFwkHelper.FromString(value);
            }
        }

        [Category("GUI - Tables")]
        public bool UseAlternateRowColor { get; set; }
        [XmlIgnore]
        [Category("GUI - Tables")]
        public Color AlternateRowColor { get; set; }
        [Browsable(false)]
        public string AlternateRowColorStr
        {
            get
            {
                return WinFwkHelper.ToString(AlternateRowColor);
            }
            set
            {
                AlternateRowColor = WinFwkHelper.FromString(value);
            }
        }
        [XmlIgnore]
        [Category("GUI - Tables")]
        public Color HeaderBackColor { get; set; }
        [Browsable(false)]
        public string HeaderBackColorStr
        {
            get
            {
                return WinFwkHelper.ToString(HeaderBackColor);
            }
            set
            {
                HeaderBackColor = WinFwkHelper.FromString(value);
            }
        }
        [XmlIgnore]
        [Category("GUI - Tables")]
        public Color HeaderForeColor { get; set; }
        [Browsable(false)]
        public string HeaderForeColorStr
        {
            get
            {
                return WinFwkHelper.ToString(HeaderForeColor);
            }
            set
            {
                HeaderForeColor = WinFwkHelper.FromString(value);
            }
        }
        [XmlIgnore]
        [Category("GUI - Tables")]
        public Color SelectedRowBackgroundColor { get; set; }
        [Browsable(false)]
        public string SelectedRowBackgroundColorStr
        {
            get
            {
                return WinFwkHelper.ToString(SelectedRowBackgroundColor);
            }
            set
            {
                SelectedRowBackgroundColor = WinFwkHelper.FromString(value);
            }
        }
        [XmlIgnore]
        [Category("GUI - Tables")]
        public Color SelectedRowForegroundColor { get; set; }
        [Browsable(false)]
        public string SelectedRowForeColorStr
        {
            get
            {
                return WinFwkHelper.ToString(SelectedRowForegroundColor);
            }
            set
            {
                SelectedRowForegroundColor = WinFwkHelper.FromString(value);
            }
        }

        [Category("DockPanel - Tab")]
        public GradientConfig DockStripGradient { get; set; }

        [Category("DockPanel - Tab")]
        public GradientConfig ActiveTabGradient { get; set; }
        [Category("DockPanel - Tab")]
        public GradientConfig InactiveTabGradient { get; set; }

        [Category("DockPanel - Caption")]
        public GradientConfig ActiveCaptionGradient { get; set; }
        [Category("DockPanel - Caption")]
        public GradientConfig InactiveCaptionGradient { get; set; }


        [XmlIgnore]
        [Category("GUI - Misc Colors")]
        public Color DebugColor { get; set; } = Color.LightSkyBlue;
        [Browsable(false)]
        public string DebugColorStr
        {
            get
            {
                return WinFwkHelper.ToString(DebugColor);
            }
            set
            {
                DebugColor = WinFwkHelper.FromString(value);
            }
        }


        [XmlIgnore]
        [Category("GUI - Misc Colors")]
        public Color InfoColor { get; set; } = Color.PaleGreen;
        [Browsable(false)]
        public string InfoColorStr
        {
            get
            {
                return WinFwkHelper.ToString(InfoColor);
            }
            set
            {
                InfoColor = WinFwkHelper.FromString(value);
            }
        }

        [XmlIgnore]
        [Category("GUI - Misc Colors")]
        public Color ErrorColor { get; set; } = Color.Red;
        [Browsable(false)]
        public string ErrorColorStr
        {
            get
            {
                return WinFwkHelper.ToString(ErrorColor);
            }
            set
            {
                ErrorColor = WinFwkHelper.FromString(value);
            }
        }

        [XmlIgnore]
        [Category("GUI - Misc Colors")]
        public Color OkColor { get; set; } = Color.PaleGreen;
        [Browsable(false)]
        public string OkColorStr
        {
            get
            {
                return WinFwkHelper.ToString(OkColor);
            }
            set
            {
                OkColor = WinFwkHelper.FromString(value);
            }
        }

        [XmlIgnore]
        [Category("GUI - Misc Colors")]
        public Color WarnColor { get; set; } = Color.Yellow;
        [Browsable(false)]
        public string WarnColorStr
        {
            get
            {
                return WinFwkHelper.ToString(WarnColor);
            }
            set
            {
                WarnColor = WinFwkHelper.FromString(value);
            }
        }


        [XmlIgnore]
        [Category("GUI - Misc Colors")]
        public Color ExceptionColor { get; set; } = Color.MediumPurple;
        [Browsable(false)]
        public string ExceptionColorStr
        {
            get
            {
                return WinFwkHelper.ToString(ExceptionColor);
            }
            set
            {
                ExceptionColor = WinFwkHelper.FromString(value);
            }
        }


        [XmlIgnore]
        [Category("GUI - Misc Colors")]
        public Color NotifyColor { get; set; } = Color.Chartreuse;
        [Browsable(false)]
        public string NotifyColorStr
        {
            get
            {
                return WinFwkHelper.ToString(NotifyColor);
            }
            set
            {
                NotifyColor = WinFwkHelper.FromString(value);
            }
        }
        ///////////////////////////////////////////////////////////////////////////////////////////

        [XmlIgnore]
        [Category("GUI - Misc Colors")]
        public Color DebugForeColor { get; set; } = Color.Black;
        [Browsable(false)]
        public string DebugForeColorStr
        {
            get
            {
                return WinFwkHelper.ToString(DebugForeColor);
            }
            set
            {
                DebugForeColor = WinFwkHelper.FromString(value);
            }
        }


        [XmlIgnore]
        [Category("GUI - Misc Colors")]
        public Color InfoForeColor { get; set; } = Color.Black;
        [Browsable(false)]
        public string InfoForeColorStr
        {
            get
            {
                return WinFwkHelper.ToString(InfoForeColor);
            }
            set
            {
                InfoForeColor = WinFwkHelper.FromString(value);
            }
        }
        [XmlIgnore]
        [Category("GUI - Misc Colors")]
        public Color ErrorForeColor { get; set; } = Color.Black;
        [Browsable(false)]
        public string ErrorForeColorStr
        {
            get
            {
                return WinFwkHelper.ToString(ErrorForeColor);
            }
            set
            {
                ErrorForeColor = WinFwkHelper.FromString(value);
            }
        }

        [XmlIgnore]
        [Category("GUI - Misc Colors")]
        public Color OkForeColor { get; set; } = Color.Black;
        [Browsable(false)]
        public string OkForeColorStr
        {
            get
            {
                return WinFwkHelper.ToString(OkForeColor);
            }
            set
            {
                OkForeColor = WinFwkHelper.FromString(value);
            }
        }

        [XmlIgnore]
        [Category("GUI - Misc Colors")]
        public Color WarnForeColor { get; set; } = Color.Black;
        [Browsable(false)]
        public string WarnForeColorStr
        {
            get
            {
                return WinFwkHelper.ToString(WarnForeColor);
            }
            set
            {
                WarnForeColor = WinFwkHelper.FromString(value);
            }
        }


        [XmlIgnore]
        [Category("GUI - Misc Colors")]
        public Color ExceptionForeColor { get; set; } = Color.Black;
        [Browsable(false)]
        public string ExceptionForeColorStr
        {
            get
            {
                return WinFwkHelper.ToString(ExceptionForeColor);
            }
            set
            {
                ExceptionForeColor = WinFwkHelper.FromString(value);
            }
        }


        [XmlIgnore]
        [Category("GUI - Misc Colors")]
        public Color NotifyForeColor { get; set; } = Color.Black;
        [Browsable(false)]
        public string NotifyForeColorStr
        {
            get
            {
                return WinFwkHelper.ToString(NotifyForeColor);
            }
            set
            {
                NotifyForeColor = WinFwkHelper.FromString(value);
            }
        }
        ///////////////////////////////////////////////////////////////////////////////////////////


        [XmlIgnore]
        [Category("GUI - Toolbars Colors")]
        public Color TitleForeColor { get; set; } = SystemColors.MenuText;
        [Browsable(false)]
        public string TitleForeColorStr
        {
            get
            {
                return WinFwkHelper.ToString(TitleForeColor);
            }
            set
            {
                TitleForeColor = WinFwkHelper.FromString(value);
            }
        }


        [XmlIgnore]
        [Category("GUI - Toolbars Colors")]
        public Color TitleBackColor { get; set; } = SystemColors.Control;
        [Browsable(false)]
        public string TitleBackColorStr
        {
            get
            {
                return WinFwkHelper.ToString(TitleBackColor);
            }
            set
            {
                TitleBackColor = WinFwkHelper.FromString(value);
            }
        }
        ///////////////////////////////////////////////////////////////////////////////////////////
        [XmlIgnore]
        [Category("GUI - PropertyGrids Colors")]
        public Color LineColor { get; set; } = SystemColors.Control;
        [Browsable(false)]
        public string LineColorStr
        {
            get
            {
                return WinFwkHelper.ToString(LineColor);
            }
            set
            {
                LineColor = WinFwkHelper.FromString(value);
            }
        }

        [XmlIgnore]
        [Category("GUI - PropertyGrids Colors")]
        public Color SelectedItemColor { get; set; } = SystemColors.Control;
        [Browsable(false)]
        public string ColorStr
        {
            get
            {
                return WinFwkHelper.ToString(SelectedItemColor);
            }
            set
            {
                SelectedItemColor = WinFwkHelper.FromString(value);
            }
        }
        [XmlIgnore]
        [Category("GUI - PropertyGrids Colors")]
        public Color SelectedItemTextColor { get; set; } = SystemColors.MenuText;
        [Browsable(false)]
        public string SelectedItemTextColorStr
        {
            get
            {
                return WinFwkHelper.ToString(SelectedItemTextColor);
            }
            set
            {
                SelectedItemTextColor = WinFwkHelper.FromString(value);
            }
        }
    }
}

