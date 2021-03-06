﻿using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using BrightIdeasSoftware;
using NLog;
using NLog.Targets;
using WinFwk.UIMessages;
using WinFwk.UIModules;
using WinFwk.UITools.Settings;

namespace WinFwk.UITools.Log
{
    public partial class LogModule : UIModule
        , IMessageListener<LogMessage>
    {
        private readonly LogModel model = new LogModel();

        public LogModule()
        {
            InitializeComponent();
            colTimeStamp.AspectGetter = model.GetTimeStamp;
            colLogLevel.AspectGetter = model.GetLogLevel;
            colText.AspectGetter = model.GetText;
            colException.AspectGetter = model.GetException;
            dlvLogMessages.CellClick += OnCellClick;

            Icon = Properties.Resources.small_file_extension_log;
            Summary = "Logs";

            var appIcon = System.Drawing.Icon.ExtractAssociatedIcon(Assembly.GetEntryAssembly().Location);
            notifyIcon.Icon = appIcon;
            notifyIcon.Text = $"{Application.ProductName} ({Application.ProductVersion})";
            notifyIcon.Visible = true;
        }

        [UIScheduler]
        public void HandleMessage(LogMessage message)
        {
            var logger = LogManager.GetLogger(message.LoggerName);
            switch (message.LogLevel)
            {
                case LogLevelType.Debug:
                    logger.Debug(message.Text);
                    break;
                case LogLevelType.Info:
                    logger.Info(message.Text);
                    break;
                case LogLevelType.Warn:
                    logger.Warn(message.Text);
                    break;
                case LogLevelType.Error:
                    logger.Error(message.Text);
                    MessageBox.Show(message.Text, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case LogLevelType.Exception:
                    MessageBox.Show($"{message.Text}{Environment.NewLine}Exception: {message.Exception.Message}", "Exception !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logger.Error(message.Exception, message.Text);
                    break;
                case LogLevelType.Notify:
                    logger.Info(message.Text);
                    notifyIcon.BalloonTipTitle = notifyIcon.Text;
                    notifyIcon.BalloonTipText = string.IsNullOrEmpty(message.Text) ? "Hello !" : message.Text;
                    notifyIcon.ShowBalloonTip(1000);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            model.Add(message);
            Summary = message.Text;
            dlvLogMessages.SetObjects(model);
        }

        private void OnCellClick(object sender, CellClickEventArgs e)
        {
            if( e.Item == null || e.Item.RowObject == null)
            {
                return;
            }

            var logMessage = model.GetObject(e.Item.RowObject);
            if (logMessage == null)
            {
                return;
            }

            switch(e.ClickCount)
            {
                case 1:
                    Summary = logMessage.Text;
                    break;
                case 2:
                    LogMessageViewerModule viewerModule = new LogMessageViewerModule {UIModuleParent = this};
                    viewerModule.Init(logMessage);
                    RequestDockModule(viewerModule);
                    break;
            }

        }

        private void fdlvLogMessages_FormatCell(object sender, FormatCellEventArgs e)
        {
            if (e.Column != colLogLevel)
                return;

            var logLevelType = (LogLevelType)e.SubItem.ModelValue;
            e.SubItem.BackColor = GetLogLevelColor(logLevelType);
            e.SubItem.ForeColor = GetLogLevelForeColor(logLevelType);
        }

        private static Color GetLogLevelColor(LogLevelType logLevel)
        {
            switch (logLevel)
            {
                case LogLevelType.Debug:
                    return UISettings.Instance.DebugColor;
                case LogLevelType.Info:
                    return UISettings.Instance.InfoColor;
                case LogLevelType.Warn:
                    return UISettings.Instance.WarnColor;
                case LogLevelType.Error:
                    return UISettings.Instance.ErrorColor;
                case LogLevelType.Exception:
                    return UISettings.Instance.ExceptionColor;
                case LogLevelType.Notify:
                    return UISettings.Instance.NotifyColor;
                default:
                    throw new ArgumentOutOfRangeException(nameof(logLevel), logLevel, null);
            }
        }

        private static Color GetLogLevelForeColor(LogLevelType logLevel)
        {
            switch (logLevel)
            {
                case LogLevelType.Debug:
                    return UISettings.Instance.DebugForeColor;
                case LogLevelType.Info:
                    return UISettings.Instance.InfoForeColor;
                case LogLevelType.Warn:
                    return UISettings.Instance.WarnForeColor;
                case LogLevelType.Error:
                    return UISettings.Instance.ErrorForeColor;
                case LogLevelType.Exception:
                    return UISettings.Instance.ExceptionForeColor;
                case LogLevelType.Notify:
                    return UISettings.Instance.NotifyForeColor;
                default:
                    throw new ArgumentOutOfRangeException(nameof(logLevel), logLevel, null);
            }
        }

        private void btnOpenLogFile_Click(object sender, EventArgs e)
        {
            foreach (var fileTarget in LogManager.Configuration.AllTargets.OfType<FileTarget>())
            {
                var logEventInfo = new LogEventInfo { TimeStamp = DateTime.Now };
                string fileName = fileTarget.FileName.Render(logEventInfo);
                Process.Start(fileName);
                return;
            }
        }
        
        public override bool Closable()
        {
            return false;
        }
    }
}
