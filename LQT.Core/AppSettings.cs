
/*
 * This program is part of the ForLAB software.
 * Copyright © 2010 Clinton Health Access Initiative(CHAI) 
 *
 *  The ForLAB software was made possible in part through the support of the President's Emergency Plan for AIDS Relief (PEPFAR) through the U.S. Agency for International Development (USAID) under the Supply Chain Management System (SCMS) Project CONTRACT # GPO-1-00-05-00032-00; CFDA/AWARD# 98.001.
 *
 *  The U.S. Government is not liable for any disclosure, use, or reproduction of the ForLAB software.
 *
 
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Security;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

namespace LQT.Core
{
    [Serializable]
    public class AppSettings
    {
		public const string ASSEMBLY_VERSION = "1.6.1";
        public const string PRODUCT = "ForLAB Forecasting Tools Suite";
        public const string COPYRIGHT = "CHIA Ethiopia 2011";
        
        private static readonly string REGISTRY_PATH = "Software\\ForLAB " + AppSettingsStore.Default.VERSION;
        
        private static bool _useRegistry = false;
        
        public static bool CheckSettings()
        {
            if (Microsoft.Win32.Registry.LocalMachine.OpenSubKey(REGISTRY_PATH) != null)
            {
                _useRegistry = true;
                _GetSettingsFromRegistry();
            }

            return _CheckSettings();
        }

        private static bool _CheckSettings()
        {
            foreach (string key in new List<string> { "DATABASE_NAME", "DATABASE_PASSWORD", "DATABASE_SERVER_NAME",
                "DATABASE_LOGIN_NAME", "DATABASE_TIMEOUT","INTEGRATED_SECURITY", "VERSION", "COPYRIGHT", "PRODUCT" })
            {
                if (string.IsNullOrEmpty(AppSettingsStore.Default[key].ToString())) return false;
            }

            return true;
        }

        public static string Copyright
        {
            get { return AppSettingsStore.Default.COPYRIGHT; }
        }

        public static string Product
        {
            get { return AppSettingsStore.Default.PRODUCT; }
        }
               
        public static string DatabaseServerName
        {
            get { return AppSettingsStore.Default.DATABASE_SERVER_NAME; }
            set { _SetSetting("DATABASE_SERVER_NAME", value); }
        }

        public static string DatabaseName
        {
            get { return AppSettingsStore.Default.DATABASE_NAME; }
            set { _SetSetting("DATABASE_NAME", value); }
        }

        public static string DatabasePassword
        {
            get { return AppSettingsStore.Default.DATABASE_PASSWORD; }
            set { _SetSetting("DATABASE_PASSWORD", value); }
        }

        public static string DatabaseLoginName
        {
            get { return AppSettingsStore.Default.DATABASE_LOGIN_NAME; }
            set { _SetSetting("DATABASE_LOGIN_NAME", value); }
        }

        public static int DatabaseTimeout
        {
            get { return Convert.ToInt32(AppSettingsStore.Default.DATABASE_TIMEOUT); }
            set { _SetSetting("DATABASE_TIMEOUT", value.ToString()); }
        }

        public static bool IntegratedSecurity
        {
            get { return AppSettingsStore.Default.INTEGRATED_SECURITY; }
            set { _SetSetting("INTEGRATED_SECURITY", value); }
        }
        
        public static string SoftwareVersion
        {
            get { return string.Format("v{0}", AppSettingsStore.Default.VERSION); }
        }
        public static string GetReportPath
        {
            get { return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Reports"); }
        }

        public static string GetUpdatePath
        {
            get { return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Update"); }
        }

        public static string BackupPath
        {
            get
            {
                if (string.IsNullOrEmpty(AppSettingsStore.Default.BACKUP_PATH))
                {
                    if (Directory.Exists(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Backup")))
                    {
                        _SetSetting("BACKUP_PATH",
                                    Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                                                 "Backup"));
                    }
                    else
                    {
                        _SetSetting("BACKUP_PATH", Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

                    }
                }
                return AppSettingsStore.Default.BACKUP_PATH;
            }
            set { _SetSetting("BACKUP_PATH", value); }
        }

        public static string ExportPath
        {
            get
            {
                if (string.IsNullOrEmpty(AppSettingsStore.Default.EXPORT_PATH))
                {
                    _SetSetting("EXPORT_PATH", Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Export"));
                }
                return AppSettingsStore.Default.EXPORT_PATH;
            }
            set { _SetSetting("EXPORT_PATH", value); }
        }

        public static bool IsThisVersionNewer(string pVersion)
        {
            try
            {
                Version v = new Version(pVersion.ToLower().Replace("v", ""));
                Version c = new Version(AppSettingsStore.Default.VERSION.ToLower());
                return (v > c);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                return false;
            }
        }
                
        private static void _GetSettingsFromRegistry()
        {
            Microsoft.Win32.RegistryKey regkey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(REGISTRY_PATH);
            if (null == regkey) return;
            foreach (string key in new List<string> { "DATABASE_NAME", "DATABASE_LOGIN_NAME", "DATABASE_PASSWORD", 
                "DATABASE_SERVER_NAME", "DATABASE_TIMEOUT","INTEGRATED_SECURITY" })
            {
                object o = regkey.GetValue(key);
                if (key == "INTEGRATED_SECURITY")
                {
                    AppSettingsStore.Default[key] = o == null ? true : Convert.ToBoolean(o);
                }
                else
                    AppSettingsStore.Default[key] = o == null ? string.Empty : o.ToString();
            }
            regkey.Close();
        }

        private static void _SetSetting(string pPropertyName, string pValue)
        {
            AppSettingsStore.Default[pPropertyName] = pValue;
            AppSettingsStore.Default.Save();

            if (!_useRegistry) return;

            _SetSettingsInRegistry(REGISTRY_PATH, pPropertyName, pValue);
        }

        private static void _SetSetting(string pPropertyName, bool pValue)
        {
            AppSettingsStore.Default[pPropertyName] = pValue;
            AppSettingsStore.Default.Save();
        }

        private static void _SetSetting(string pPropertyName, int pValue)
        {
            AppSettingsStore.Default[pPropertyName] = pValue;
            AppSettingsStore.Default.Save();
        }

        private static void _SetSettingsInRegistry(string pRegistryPath, string pPropertyName, string pValue)
        {
            Microsoft.Win32.RegistryKey reg = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(pRegistryPath, true);
            if (reg == null) return;

            reg.SetValue(pPropertyName, pValue);
            reg.Close();
        }

		public static string ApplicationPath
		{
			get { return Path.GetDirectoryName(Assembly.GetEntryAssembly().Location); }
		}
   
    }
}
