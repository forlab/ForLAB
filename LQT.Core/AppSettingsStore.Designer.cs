
/*
 * This program is part of the ForLAB software.
 * Copyright � 2010 Clinton Health Access Initiative(CHAI) 
 *
 *  The ForLAB software was made possible in part through the support of the President's Emergency Plan for AIDS Relief (PEPFAR) through the U.S. Agency for International Development (USAID) under the Supply Chain Management System (SCMS) Project CONTRACT # GPO-1-00-05-00032-00; CFDA/AWARD# 98.001.
 *
 *  The U.S. Government is not liable for any disclosure, use, or reproduction of the ForLAB software.
 *
 
 */

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LQT.Core {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
    internal sealed partial class AppSettingsStore : global::System.Configuration.ApplicationSettingsBase {
        
        private static AppSettingsStore defaultInstance = ((AppSettingsStore)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new AppSettingsStore())));
        
        public static AppSettingsStore Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string BACKUP_PATH {
            get {
                return ((string)(this["BACKUP_PATH"]));
            }
            set {
                this["BACKUP_PATH"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string EXPORT_PATH {
            get {
                return ((string)(this["EXPORT_PATH"]));
            }
            set {
                this["EXPORT_PATH"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1.6.1")]
        public string VERSION {
            get {
                return ((string)(this["VERSION"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("CHIA Ethiopia 2011")]
        public string COPYRIGHT {
            get {
                return ((string)(this["COPYRIGHT"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("ForLAB Forecasting Tools Suite")]
        public string PRODUCT {
            get {
                return ((string)(this["PRODUCT"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("localhost")]
        public string DATABASE_SERVER_NAME {
            get {
                return ((string)(this["DATABASE_SERVER_NAME"]));
            }
            set {
                this["DATABASE_SERVER_NAME"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("wauser")]
        public string DATABASE_LOGIN_NAME {
            get {
                return ((string)(this["DATABASE_LOGIN_NAME"]));
            }
            set {
                this["DATABASE_LOGIN_NAME"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("password")]
        public string DATABASE_PASSWORD {
            get {
                return ((string)(this["DATABASE_PASSWORD"]));
            }
            set {
                this["DATABASE_PASSWORD"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool INTEGRATED_SECURITY {
            get {
                return ((bool)(this["INTEGRATED_SECURITY"]));
            }
            set {
                this["INTEGRATED_SECURITY"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("60")]
        public string DATABASE_TIMEOUT {
            get {
                return ((string)(this["DATABASE_TIMEOUT"]));
            }
            set {
                this["DATABASE_TIMEOUT"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("ForLAB")]
        public string DATABASE_NAME {
            get {
                return ((string)(this["DATABASE_NAME"]));
            }
            set {
                this["DATABASE_NAME"] = value;
            }
        }
    }
}
