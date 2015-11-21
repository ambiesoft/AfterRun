using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AfterRun
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        
        public static string exe_ = null;
        public static int interval_ = 10;
        public static bool iscenter_ = false;
        public static bool istopmost_ = false;
        public static System.Diagnostics.ProcessWindowStyle pws_ = System.Diagnostics.ProcessWindowStyle.Normal;

        static void messageWithHelp(string message)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendLine(message);
            sb.AppendLine();
            sb.AppendLine(AfterRun.Properties.Resources.HelpString);

            MessageBox.Show(sb.ToString(),
                Application.ProductName,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

        }

        [STAThread]
        static void Main()
        {
            String[] args = Environment.GetCommandLineArgs();

            if (args.Length < 2)
            {
                messageWithHelp(AfterRun.Properties.Resources.NoArguments);
                return;
            }

            bool intervalset = false;
            for (int i = 1; i < args.Length; ++i)
            {
                if (args[i].StartsWith("-t"))
                {
                    if ((i - 1) == args.Length)
                    {
                        messageWithHelp(AfterRun.Properties.Resources.NoArgumentForInterval);
                        return;
                    }
                    ++i;

                    if (intervalset)
                    {
                        messageWithHelp(AfterRun.Properties.Resources.NoArgumentForInterval);
                        return;
                    }

                    if (args[i] == "m")
                    {
                        interval_ = -1;
                        intervalset = true;
                    }
                    else
                    {
                        if (!Int32.TryParse(args[i], out interval_))
                        {
                            string message = AfterRun.Properties.Resources.InvalidInterval;
                            message += " : ";
                            message += args[i];
                            messageWithHelp(message);
                            return;
                        }
                        intervalset = true;
                    }
                }
                else if (args[i].StartsWith("-c"))
                {
                    iscenter_ = true;
                }
                else if (args[i].StartsWith("-m"))
                {
                    istopmost_ = true;
                }
                else if (args[i].StartsWith("-ws"))
                {
                    if ((i - 1) == args.Length)
                    {
                        messageWithHelp(AfterRun.Properties.Resources.NoArgumentForWindowStyle);
                        return;
                    }
                    ++i;
                    if (args[i] == "normal")
                    {
                        pws_ = System.Diagnostics.ProcessWindowStyle.Normal;
                    }
                    else if (args[i] == "minimized")
                    {
                        pws_ = System.Diagnostics.ProcessWindowStyle.Minimized;
                    }
                    else if (args[i] == "maximized")
                    {
                        pws_ = System.Diagnostics.ProcessWindowStyle.Maximized;
                    }
                    else
                    {
                        string message = AfterRun.Properties.Resources.InvalidWindowStyle;
                        message += " : ";
                        message += args[i];
                        messageWithHelp(message);
                        return;
                    }
                }
                else if (args[i].StartsWith("-"))
                {
                    string message = AfterRun.Properties.Resources.UnknownOption;
                    message += " : ";
                    message += args[i];
                    messageWithHelp(message);
                    return;
                }
                else
                {  // main arg
                    if (exe_ != null)
                    {
                        messageWithHelp(AfterRun.Properties.Resources.MultipleInputs);
                        return;
                    }

                    exe_ = args[i];
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}