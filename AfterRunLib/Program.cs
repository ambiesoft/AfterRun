using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using System.Linq;

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

        [STAThread]
        public static void Main(String[] args)
        {
            Ambiesoft.CppUtils.AmbSetProcessDPIAware();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Length < 2)
            {
                messageWithHelp(Properties.Resources.NoArguments);
                return;
            }

            int? interval = null;
            List<int> pidsToWait = new List<int>();

            FormMain form = new FormMain();

            for (int i = 1; i < args.Length; ++i)
            {
                if(false)
                { }
                else if (args[i].StartsWith("-c"))
                {
                    form.StartPosition = FormStartPosition.CenterScreen;
                }
                else if (args[i].StartsWith("-m"))
                {
                    form.TopMost = true;
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

                    if (!IsNumeric( args[i]))
                    {
                        messageWithHelp(
                            string.Format(Properties.Resources.InvalidProcessId, args[i]));
                        return;
                    }

                    int pid = int.Parse(args[i]);
                    if(!ProcessExists(pid))
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
                        int intval;
                        if (!Int32.TryParse(args[i], out intval))
                        {
                            string message = Ambiesoft.AfterRunLib.Properties.Resources.InvalidInterval;
                            message += " : ";
                            message += args[i];
                            messageWithHelp(message);
                            return;
                        }
                        interval= intval;
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
                        form.LaunchingProcessWindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                    }
                    else if (args[i] == "minimized")
                    {
                        form.LaunchingProcessWindowStyle = System.Diagnostics.ProcessWindowStyle.Minimized;
                    }
                    else if (args[i] == "maximized")
                    {
                        form.LaunchingProcessWindowStyle = System.Diagnostics.ProcessWindowStyle.Maximized;
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
                else if (args[i].StartsWith("-") || args[i].StartsWith("/"))
                {
                    string message = Properties.Resources.UnknownOption;
                    message += " : ";
                    message += args[i];
                    messageWithHelp(message);
                    return;
                }
                else
                {
                    form.exes_.Add(args[i]);
                }
            }

            if(interval != null && pidsToWait.Count!=0)
            {
                messageWithHelp("-c and -p catnot");
                return;
            }
            form.Interval = interval;
            form.pidsToWait = pidsToWait;
            Application.Run(form);
        }
    }
}