﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace svTaskJG {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.9.0.0")]
    internal sealed partial class TaskConfig : global::System.Configuration.ApplicationSettingsBase {
        
        private static TaskConfig defaultInstance = ((TaskConfig)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new TaskConfig())));
        
        public static TaskConfig Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("2268")]
        public long id {
            get {
                return ((long)(this["id"]));
            }
            set {
                this["id"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool actualizar {
            get {
                return ((bool)(this["actualizar"]));
            }
            set {
                this["actualizar"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("17:00:00")]
        public global::System.TimeSpan hora {
            get {
                return ((global::System.TimeSpan)(this["hora"]));
            }
            set {
                this["hora"] = value;
            }
        }
    }
}
