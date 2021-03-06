﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using NLog;

namespace WinFwk.UITools.Settings
{
    public static class UISettingsMgr<T> where T : UISettings, new()
    {
        private static XmlSerializer xml;

        public static void Init(string applicationName)
        {
            List<Type> types = WinFwkHelper.GetDerivedTypes(typeof (UISettings));
            xml = new XmlSerializer(typeof (T), types.ToArray());
            UISettings.InitSettings(Load(applicationName));
            InitLogs(applicationName);
        }

        public static T Load(string applicationName)
        {
            string configPath = GetConfigPath(applicationName);
            if (!File.Exists(configPath))
            {
                return new T();
            }
            FileInfo fi = new FileInfo(configPath);
            if (fi.Length == 0)
            {
                return new T();
            }
            using (var reader = new StreamReader(configPath))
            {
                var configObj = xml.Deserialize(reader);
                var config = configObj as T;
                return config;
            }
        }

        public static void Save(string applicationName, T uiSettings)
        {
            string configPath = GetConfigPath(applicationName);
            var dir = Path.GetDirectoryName(configPath);
            if (dir != null && ! Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            using (var reader = new StreamWriter(configPath))
            {
                xml.Serialize(reader, uiSettings);
            }
        }

        public static void Init()
        {
            Init(Application.ProductName);
        }

        public static T Load()
        {
            return Load(Application.ProductName);
        }

        public static void Save(T uiSettings)
        {
            Save(Application.ProductName, uiSettings);
        }

        private static string GetConfigPath(string applicationName)
        {
            var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var configPath = Path.Combine(appDataPath, applicationName);
            configPath = Path.Combine(configPath, applicationName);
            configPath = Path.ChangeExtension(configPath, "config");
            return configPath;
        }

        private static void InitLogs(string applicationName)
        {
            var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var appPath = Path.Combine(appDataPath, applicationName);
            var logPath = Path.Combine(appPath, "log");
            if (!Directory.Exists(logPath))
            {
                Directory.CreateDirectory(logPath);
            }
            LogManager.EnableLogging();
            LogManager.GetLogger(typeof (UISettingsMgr<>).Name).Info("Init Logs");
        }
    }
}