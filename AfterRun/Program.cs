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

        static void messageWithHelp(string message)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendLine(message);
            sb.AppendLine();
            sb.AppendLine(AfterRun.Properties.Resources.HelpString);

            MessageBox.Show(sb.ToString(),
                Application.ProductName,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

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

                    if (args[i] == "m")
                    {
                        interval_ = -1;
                    }
                    else
                    {
                        if (intervalset)
                        {
                            messageWithHelp(AfterRun.Properties.Resources.NoArgumentForInterval);
                            return;
                        }
                        Int32.TryParse(args[i], out interval_);
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