﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3655
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AfterRun.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("AfterRun.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ex: afterrun -t waittime exefile.
        /// </summary>
        internal static string HelpString {
            get {
                return ResourceManager.GetString("HelpString", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid Interval.
        /// </summary>
        internal static string InvalidInterval {
            get {
                return ResourceManager.GetString("InvalidInterval", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Launching {0}..
        /// </summary>
        internal static string Launching {
            get {
                return ResourceManager.GetString("Launching", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Multiple Inputs.
        /// </summary>
        internal static string MultipleInputs {
            get {
                return ResourceManager.GetString("MultipleInputs", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Multiple Interval Values.
        /// </summary>
        internal static string MultipleIntervals {
            get {
                return ResourceManager.GetString("MultipleIntervals", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No Arugment for interval value.
        /// </summary>
        internal static string NoArgumentForInterval {
            get {
                return ResourceManager.GetString("NoArgumentForInterval", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 引数がありません.
        /// </summary>
        internal static string NoArguments {
            get {
                return ResourceManager.GetString("NoArguments", resourceCulture);
            }
        }
    }
}
