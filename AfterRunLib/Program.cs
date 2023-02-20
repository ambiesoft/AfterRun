using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using System.Linq;
using System.Net;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace Ambiesoft.AfterRunLib
{
    public static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>

        static void messageWithHelp(string message, MessageBoxIcon icon)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            if (!string.IsNullOrEmpty(message))
            {
                sb.AppendLine(message);
                for(int i = 0; i < 60; i++)
                    sb.Append("-");
                sb.AppendLine();
            }
            sb.AppendLine(Properties.Resources.HelpString);

            MessageBox.Show(sb.ToString(),
                string.Format("{0} v{1}",
                    Application.ProductName,
                    AmbLib.getAssemblyVersion(Assembly.GetExecutingAssembly(),3)),
                MessageBoxButtons.OK,
                icon);
        }
        static void messageWithHelp(string message)
        { 
            messageWithHelp(message,MessageBoxIcon.Error);
        }

        static public bool IsNumeric(string value)
        {
            return value.All(char.IsNumber);
        }

        static bool ProcessExists(int pid)
        {
            foreach(var p in Process.GetProcesses())
            {
                if(p.Id==pid) 
                    return true;
            }
            return false;
        }

        internal static string IniPath
        {
            get
            {
                return Path.Combine(
                    Path.GetDirectoryName(Application.ExecutablePath),
                    Path.GetFileNameWithoutExtension(Application.ExecutablePath) + ".ini");
            }
        }

        internal static int parseDuration(string arg)
        {
            arg = Regex.Replace(arg, "[^A-Za-z0-9]", ":");
            arg = arg.Trim(':');
            TimeSpan timeSpan = new TimeSpan(0, 0, 0);
            
            {
                if (arg.IndexOf(':') >= 0)
                {
                    // In the format of 11:22:33 or 11:22
                    string[] parts = arg.Split(':');
                    if (parts.Length == 2)
                    {
                        // In the format of 11:22
                        timeSpan = new TimeSpan(0, int.Parse(parts[0]), int.Parse(parts[1]));
                    }
                    else if (parts.Length == 3)
                    {
                        // In the format of 11:22:33
                        timeSpan = new TimeSpan(int.Parse(parts[0]), int.Parse(parts[1]), int.Parse(parts[2]));
                    }

                }
                else if (arg[arg.Length - 1] == 'h')
                {
                    int hour = int.Parse(arg.Substring(0, arg.Length - 1));
                    timeSpan = new TimeSpan(hour, 0, 0);
                }
                else if (arg[arg.Length - 1] == 'm')
                {
                    int minutes = int.Parse(arg.Substring(0, arg.Length - 1));
                    timeSpan = new TimeSpan(0, minutes, 0);
                }
                else
                {
                    timeSpan = new TimeSpan(0, 0, int.Parse(arg));
                }
                if (timeSpan.TotalSeconds == 0)
                {
                    throw new Exception();
                }
            }
            return (int)timeSpan.TotalSeconds;
        }
        [STAThread]
        public static void Main(String[] args)
        {
            Ambiesoft.CppUtils.AmbSetProcessDPIAware();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            bool? needsDialog = null;
            string errorMessage = string.Empty;

            int? interval = null;
            List<int> pidsToWait = new List<int>();

            List<ExeArg> exeArgs = new List<ExeArg>();
            FormStartPosition fsp = default(FormStartPosition);
            bool topMost = false;
            FormWindowState aws = default(FormWindowState);
            System.Diagnostics.ProcessWindowStyle pws = default(System.Diagnostics.ProcessWindowStyle);

            do
            {
                if (args.Length < 2)
                {
                    needsDialog = true;
                    errorMessage = Properties.Resources.NoArguments;
                    break;
                }

                for (int i = 1; i < args.Length; ++i)
                {
                    if (false)
                    { }
                    else if (args[i].StartsWith("-c"))
                    {
                        fsp = FormStartPosition.CenterScreen;
                    }
                    else if (args[i].StartsWith("-m"))
                    {
                        topMost = true;
                    }
                    else if (args[i].ToLower().StartsWith("-h") ||
                        args[i].ToLower().StartsWith("-help") ||
                        args[i].ToLower().StartsWith("--help") ||
                        args[i].ToLower().StartsWith("/h") ||
                        args[i].ToLower().StartsWith("/?"))
                    {
                        messageWithHelp("", MessageBoxIcon.Information);
                        return;
                    }
                    else if (args[i].StartsWith("-p"))
                    {
                        if ((i - 1) == args.Length)
                        {
                            messageWithHelp(Properties.Resources.NoArgumentForProcessId);
                            return;
                        }
                        ++i;

                        if (!IsNumeric(args[i]))
                        {
                            messageWithHelp(
                                string.Format(Properties.Resources.InvalidProcessId, args[i]));
                            return;
                        }

                        int pid = int.Parse(args[i]);
                        if (!ProcessExists(pid))
                        {
                            messageWithHelp(
                                string.Format(Properties.Resources.PIDNotFound, pid));
                            return;
                        }
                        pidsToWait.Add(pid);
                    }
                    else if (args[i].StartsWith("-t"))
                    {
                        if ((i - 1) == args.Length)
                        {
                            messageWithHelp(Properties.Resources.NoArgumentForInterval);
                            return;
                        }
                        ++i;

                        if (interval != null)
                        {
                            messageWithHelp(Properties.Resources.IntervalAlreadySet);
                            return;
                        }

                        if (args[i] == "m")
                        {
                            interval = -1;
                        }
                        else
                        {
                            try
                            {
                                interval = parseDuration(args[i]);
                            }
                            catch (Exception)
                            {
                                string message = Ambiesoft.AfterRunLib.Properties.Resources.InvalidInterval;
                                message += " : ";
                                message += args[i];
                                messageWithHelp(message);
                                return;
                            }
                        }
                    }
                    else if (args[i].StartsWith("-aws"))
                    {
                        if ((i - 1) == args.Length)
                        {
                            messageWithHelp(Properties.Resources.NoArgumentForWindowStyle);
                            return;
                        }
                        ++i;
                        
                        if (args[i] == "normal")
                        {
                            aws = FormWindowState.Normal;
                        }
                        else if (args[i] == "minimized")
                        {
                            aws = FormWindowState.Minimized;
                        }
                        else if (args[i] == "maximized")
                        {
                            aws = FormWindowState.Maximized;
                        }
                        else
                        {
                            string message = Properties.Resources.InvalidWindowStyle;
                            message += " : ";
                            message += args[i];
                            messageWithHelp(message);
                            return;
                        }
                    }
                    else if (args[i].StartsWith("-ws"))
                    {
                        if ((i - 1) == args.Length)
                        {
                            messageWithHelp(Properties.Resources.NoArgumentForWindowStyle);
                            return;
                        }
                        ++i;

                        if (args[i] == "normal")
                        {
                            pws = System.Diagnostics.ProcessWindowStyle.Normal;
                        }
                        else if (args[i] == "minimized")
                        {
                            pws = System.Diagnostics.ProcessWindowStyle.Minimized;
                        }
                        else if (args[i] == "maximized")
                        {
                            pws = System.Diagnostics.ProcessWindowStyle.Maximized;
                        }
                        else
                        {
                            string message = Properties.Resources.InvalidWindowStyle;
                            message += " : ";
                            message += args[i];
                            messageWithHelp(message);
                            return;
                        }
                    }
                    else if ((args[i].StartsWith("-") || args[i].StartsWith("/")) &&
                        !(args[i].StartsWith("-exe") || args[i].StartsWith("/exe")) &&
                        !(args[i].StartsWith("-arg") || args[i].StartsWith("/arg")))
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append(Properties.Resources.UnknownOption);
                        sb.Append(" : ");
                        sb.Append(args[i]);
                        sb.AppendLine();
                        sb.AppendLine();
                        sb.Append(Properties.Resources.UseUrlEncodeToPassArg);
                        messageWithHelp(sb.ToString());
                        return;
                    }
                }  // for (int i = 1; i < args.Length; ++i)

                // get all -exe and -arg
                for (int i = 1; i < args.Length; ++i)
                {
                    if (args[i].StartsWith("-exe") || args[i].StartsWith("/exe"))
                    {
                        ++i;
                        if (args.Length <= i)
                        {
                            string message = Properties.Resources.NoExecutableSpecified;
                            message += " : ";
                            message += args[i];
                            messageWithHelp(message);
                            return;
                        }

                        string exevalue = args[i];
                        string argvalue = string.Empty;
                        ++i;
                        if (!(args.Length <= i))
                        {
                            if (!(args[i].StartsWith("-arg") || args[i].StartsWith("/arg")))
                            {
                                exeArgs.Add(new ExeArg(exevalue, argvalue));
                                --i;
                                continue;
                            }

                            // now -arg is confirmed
                            ++i;
                            if (args.Length <= i)
                            {
                                string message = Properties.Resources.NoArgumentSpecified;
                                message += " : ";
                                message += args[i];
                                messageWithHelp(message);
                                return;
                            }

                            argvalue = WebUtility.UrlDecode(args[i]);
                        }
                        exeArgs.Add(new ExeArg(exevalue, argvalue));
                    }
                }

                if (interval != null && pidsToWait.Count != 0)
                {
                    messageWithHelp(Properties.Resources.T_AND_P_CANNOTSPECIFIED_AT_THE_SAME_TIME);
                    return;
                }
                if (interval == null && pidsToWait.Count == 0)
                {
                    needsDialog = true;
                    errorMessage = Properties.Resources.T_OR_P_MUST_BE_SPECIFIED;
                    break;
                }
                needsDialog = false;
            } while (false);

            var userInput = new UserInput(
                    false,
                    exeArgs,
                    interval,
                    pidsToWait,
                    pws);

            if (needsDialog == true || (!userInput.IsShutdown && userInput.ExeArgs.Count == 0))
            {
                if(userInput.ExeArgs.Count > 1)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(Properties.Resources.DialogNotDisplayedWhenTwoExes);
                    sb.AppendLine();
                    sb.AppendLine();
                    sb.Append(errorMessage);
                    messageWithHelp(sb.ToString());
                    return;
                }
                if(userInput.PidsToWait.Count> 0)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(Properties.Resources.DialogNotDisplayedWhenPidWait);
                    sb.AppendLine();
                    sb.AppendLine();
                    sb.Append(errorMessage);
                    messageWithHelp(sb.ToString());
                    return;
                }
                using (UserInputDialog uid = new UserInputDialog(userInput))
                {
                    if (DialogResult.OK != uid.ShowDialog())
                        return;
                }
            }
            Debug.Assert(needsDialog != null);
            FormMain form = new FormMain(userInput);
            form.StartPosition = fsp;
            form.TopMost = topMost;
            form.WindowState = aws;

            Application.Run(form);
        }
    }
}