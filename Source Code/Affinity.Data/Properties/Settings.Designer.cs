﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Affinity.Data.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
    public sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("affinitydev")]
        public string AccName {
            get {
                return ((string)(this["AccName"]));
            }
            set {
                this["AccName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("bbIKFgiLTtZ3wYvCq68KIwBDHURYUnjtEq1xEK75EwLRctlYOP3yc/0aHvUJEMpBFW5Jf1HYEhV/hWWXi" +
            "4xQog==")]
        public string AccKey {
            get {
                return ((string)(this["AccKey"]));
            }
            set {
                this["AccKey"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool UseHttp {
            get {
                return ((bool)(this["UseHttp"]));
            }
            set {
                this["UseHttp"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("azure_77a0caf11740c8303d1cee695d9f0c2b@azure.com")]
        public string mUser {
            get {
                return ((string)(this["mUser"]));
            }
            set {
                this["mUser"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("smtp.sendgrid.net")]
        public string mHost {
            get {
                return ((string)(this["mHost"]));
            }
            set {
                this["mHost"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("587")]
        public int mPort {
            get {
                return ((int)(this["mPort"]));
            }
            set {
                this["mPort"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool mUseSSL {
            get {
                return ((bool)(this["mUseSSL"]));
            }
            set {
                this["mUseSSL"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("pass")]
        public string mPass {
            get {
                return ((string)(this["mPass"]));
            }
            set {
                this["mPass"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("users")]
        public string mForm {
            get {
                return ((string)(this["mForm"]));
            }
            set {
                this["mForm"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("notify")]
        public string notifyUsers {
            get {
                return ((string)(this["notifyUsers"]));
            }
            set {
                this["notifyUsers"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("23.96.199.209")]
        public string ExternalIP {
            get {
                return ((string)(this["ExternalIP"]));
            }
            set {
                this["ExternalIP"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool UsePassive {
            get {
                return ((bool)(this["UsePassive"]));
            }
            set {
                this["UsePassive"] = value;
            }
        }
    }
}
