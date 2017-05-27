using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using WinFwk.UICommands;
using WinFwk.UIMessages;
using WinFwk.UIModules;

namespace WinFwk.UITools.ToolBar
{
    public partial class UIToolbar : UIModule, IMessageListener<ModuleEventMessage>
    {
        private readonly Dictionary<AbstractUICommand, Button> dicoCommands = new Dictionary<AbstractUICommand, Button>();
        public int Priority { get; }
        public UIToolbar()
        {
            InitializeComponent();
            Icon = null;
            Priority = 0;
        }

        public void HandleMessage(ModuleEventMessage eventMessage)
        {
            if( eventMessage.Module != null && eventMessage.Module.GetType() == typeof(UIToolbar))
            {
                return;
            }
            foreach (var kvp in dicoCommands)
            {
                var command = kvp.Key;
                var button = kvp.Value;
                if (eventMessage.ModuleEvent == ModuleEventType.Removed)
                {
                    command.SetSelectedModule(null);
                }
                else
                {
                    command.SetSelectedModule(eventMessage.Module);
                }
                button.Enabled = command.Enabled;
            }
        }

        public void Init(Bitmap icon, IGrouping<string, AbstractUICommand> commands)
        {
            Icon = icon;
            Name = commands.Key;
            Text = commands.Key;
            bool hasSubGroup = commands.Any(c => !string.IsNullOrEmpty(c.SubGroup));
            panel.Padding = Padding.Empty;
            panel.Margin = Padding.Empty;

            foreach (var group in commands.GroupBy(c => c.SubGroup))
            {
                Control container = panel;
                var gb = new RoundCornerGroupBox() { Text = group.Key , AutoSize=true, FlatStyle = FlatStyle.Standard};
                
                container = new FlowLayoutPanel() { FlowDirection = FlowDirection.LeftToRight, AutoScroll = false, Dock = DockStyle.Fill, WrapContents=false, AutoSize = true};
                panel.Controls.Add(gb);
                gb.Controls.Add(container);

                foreach (var command in group)
                {
                    var type = command.GetType();
                    var meth = type.GetMethod(nameof(AbstractUICommand.Run));
                    var cmd = command;
                    UICommandButton button = new UICommandButton { Text = command.Name, FlatStyle = FlatStyle.Popup, Dock = DockStyle.None};
                    string tooltip = command.ToolTip;
                    if (command.Shortcut != Keys.None)
                    { // Todo : improve this
                        tooltip += " (";
                        if (command.Shortcut.HasFlag(Keys.Control))
                        {
                            tooltip += "Ctrl+";
                        }
                        if (command.Shortcut.HasFlag(Keys.Alt))
                        {
                            tooltip += "Alt+";
                        }
                        if (command.Shortcut.HasFlag(Keys.Shift))
                        {
                            tooltip += "Shift+";
                        }

                        tooltip += command.Shortcut.ToString().Split(',')[0];
                        tooltip += ")";
                    }
                    toolTip1.SetToolTip(button, tooltip);
                    button.Click += (sender, args) =>
                    {
                        try
                        {
                            meth.Invoke(cmd, null);
                        }
                        catch (Exception e)
                        {
                            var msgIcon = MessageBoxIcon.Error;
                            var ex = e;
                            if (e.InnerException?.GetType() == typeof(InvalidOperationException))
                            {
                                msgIcon = MessageBoxIcon.Warning;
                                ex = e.InnerException;
                            }
                            var msg = $"{ex.Message}{Environment.NewLine}({ex.GetType().FullName})";
                            MessageBox.Show(msg, "MemoScope: " + command.Name, MessageBoxButtons.OK, msgIcon);
                        }
                    };
                    button.Enabled = command.Enabled;
                    if (command.Icon != null)
                    {
                        button.Image = command.Icon;
                        button.TextAlign = ContentAlignment.BottomCenter;
                        button.TextImageRelation = TextImageRelation.ImageAboveText;
                        button.AutoSize = true;
                    }
                    container.Controls.Add(button);
                    dicoCommands[command] = button;
                }
            }
        }
    }
}