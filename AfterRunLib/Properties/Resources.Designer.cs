﻿//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン:4.0.30319.42000
//
//     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
//     コードが再生成されるときに損失したりします。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ambiesoft.AfterRunLib.Properties {
    using System;
    
    
    /// <summary>
    ///   ローカライズされた文字列などを検索するための、厳密に型指定されたリソース クラスです。
    /// </summary>
    // このクラスは StronglyTypedResourceBuilder クラスが ResGen
    // または Visual Studio のようなツールを使用して自動生成されました。
    // メンバーを追加または削除するには、.ResX ファイルを編集して、/str オプションと共に
    // ResGen を実行し直すか、または VS プロジェクトをビルドし直します。
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   このクラスで使用されているキャッシュされた ResourceManager インスタンスを返します。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Ambiesoft.AfterRunLib.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   すべてについて、現在のスレッドの CurrentUICulture プロパティをオーバーライドします
        ///   現在のスレッドの CurrentUICulture プロパティをオーバーライドします。
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
        ///   The input dialog cannot be displayed when waiting with the process. に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string DialogNotDisplayedWhenPidWait {
            get {
                return ResourceManager.GetString("DialogNotDisplayedWhenPidWait", resourceCulture);
            }
        }
        
        /// <summary>
        ///   The input dialog cannot be displayed when there are two or more executable files specified on the command line. に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string DialogNotDisplayedWhenTwoExes {
            get {
                return ResourceManager.GetString("DialogNotDisplayedWhenTwoExes", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Duration has not been entered. に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string DurationNoEntered {
            get {
                return ResourceManager.GetString("DurationNoEntered", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Both Executable and Argument not entered. に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string ExeAndArgBothNoEntered {
            get {
                return ResourceManager.GetString("ExeAndArgBothNoEntered", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Failed to save configuration information. に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string FailedToSaveIni {
            get {
                return ResourceManager.GetString("FailedToSaveIni", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Afterrun : Run executable after specified time
        ///
        ///ex: afterrun -t SecToWait -exe EXE [-arg ARG]
        ///
        ///-c : Position window at Center
        ///-m : Set window Topmost
        ///-p : Wait pid to finish
        ///-t : Seconds to wait, or &apos;m&apos; to wait forever. Specify &apos;5m&apos; for five minutes, &apos;2h&apos; for two hours, &apos;1:30:30&apos; for one hour and 30 minutes and 30 seconds or &apos;4:30&apos; for 4 minutes and 30 seconds
        ///-aws : Set the Window State of AfterRun, &apos;normal&apos; for showing in normal window, &apos;minimized&apos; for minimized window or &apos;maximized&apos; for maximized [残りの文字列は切り詰められました]&quot;; に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string HelpString {
            get {
                return ResourceManager.GetString("HelpString", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Duplicated interval に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string IntervalAlreadySet {
            get {
                return ResourceManager.GetString("IntervalAlreadySet", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Invalid duration format に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string InvalidDurationFormat {
            get {
                return ResourceManager.GetString("InvalidDurationFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Invalid Interval に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string InvalidInterval {
            get {
                return ResourceManager.GetString("InvalidInterval", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Invalid Process Id: {0} に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string InvalidProcessId {
            get {
                return ResourceManager.GetString("InvalidProcessId", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Invalid Window Style に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string InvalidWindowStyle {
            get {
                return ResourceManager.GetString("InvalidWindowStyle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   The following program will be executed. に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string Launching {
            get {
                return ResourceManager.GetString("Launching", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Multiple Inputs に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string MultipleInputs {
            get {
                return ResourceManager.GetString("MultipleInputs", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Multiple Interval Values に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string MultipleIntervals {
            get {
                return ResourceManager.GetString("MultipleIntervals", resourceCulture);
            }
        }
        
        /// <summary>
        ///   No Arugment for interval value に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string NoArgumentForInterval {
            get {
                return ResourceManager.GetString("NoArgumentForInterval", resourceCulture);
            }
        }
        
        /// <summary>
        ///   No Argument for process id に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string NoArgumentForProcessId {
            get {
                return ResourceManager.GetString("NoArgumentForProcessId", resourceCulture);
            }
        }
        
        /// <summary>
        ///   No Argument for Window Style に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string NoArgumentForWindowStyle {
            get {
                return ResourceManager.GetString("NoArgumentForWindowStyle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   No Arguments に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string NoArguments {
            get {
                return ResourceManager.GetString("NoArguments", resourceCulture);
            }
        }
        
        /// <summary>
        ///   No arguments specifed for &apos;-arg&apos; に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string NoArgumentSpecified {
            get {
                return ResourceManager.GetString("NoArgumentSpecified", resourceCulture);
            }
        }
        
        /// <summary>
        ///   No executables specified for &apos;-exe&apos; に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string NoExecutableSpecified {
            get {
                return ResourceManager.GetString("NoExecutableSpecified", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Process of id {0} is not found に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string PIDNotFound {
            get {
                return ResourceManager.GetString("PIDNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Select an executable file に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string SelectExecutable {
            get {
                return ResourceManager.GetString("SelectExecutable", resourceCulture);
            }
        }
        
        /// <summary>
        ///   System will shutdown... に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string Shutdowning {
            get {
                return ResourceManager.GetString("Shutdowning", resourceCulture);
            }
        }
        
        /// <summary>
        ///   &apos;-t&apos; and &apos;-p&apos; can not be specified at the same time. に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string T_AND_P_CANNOTSPECIFIED_AT_THE_SAME_TIME {
            get {
                return ResourceManager.GetString("T_AND_P_CANNOTSPECIFIED_AT_THE_SAME_TIME", resourceCulture);
            }
        }
        
        /// <summary>
        ///   &apos;-t&apos; or &apos;-p&apos; must be specified. に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string T_OR_P_MUST_BE_SPECIFIED {
            get {
                return ResourceManager.GetString("T_OR_P_MUST_BE_SPECIFIED", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Unknown Option に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string UnknownOption {
            get {
                return ResourceManager.GetString("UnknownOption", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Use Url-Encoding to pass the argument に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string UseUrlEncodeToPassArg {
            get {
                return ResourceManager.GetString("UseUrlEncodeToPassArg", resourceCulture);
            }
        }
    }
}
