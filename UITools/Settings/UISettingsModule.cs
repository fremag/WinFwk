﻿using System;
using System.Reflection;
using System.Windows.Forms;
using WinFwk.UIModules;

namespace WinFwk.UITools.Settings
{
    public partial class UISettingsModule : UIModule
    {
        public UISettingsModule()
        {
            InitializeComponent();
            Name = "Settings";
            Icon = Properties.Resources.small_gear_in;
            Summary = "Application settings";
        }

        private void UIConfigModule_Load(object sender, EventArgs e)
        {
            pgUiSettings.SelectedObject = UISettings.Instance;
            pgUiSettings.CollapseAllGridItems();
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            Type type = UISettings.Instance.GetType();
            Type mgrType = typeof (UISettingsMgr<>).MakeGenericType(type);
            var meth = mgrType.GetMethod(nameof(UISettingsMgr<UISettings>.Save), new []{ type});
            meth.Invoke(null, new object[] {UISettings.Instance});
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            Type type = UISettings.Instance.GetType();
            Type mgrType = typeof(UISettingsMgr<>).MakeGenericType(type);
            var meth = mgrType.GetMethod(nameof(UISettingsMgr<UISettings>.Load), new Type[0]);
            var res = meth.Invoke(null, null);
            UISettings.InitSettings((UISettings)res);
            pgUiSettings.SelectedObject = UISettings.Instance;
        }

        public void SendUISettingsChangedMessage()
        {
            MessageBus.SendMessage(new UISettingsChangedMessage(UISettings.Instance));
        }

        private void btnApplyUISettingsChanges_Click(object sender, EventArgs e)
        {
            SendUISettingsChangedMessage();
        }
    }
}