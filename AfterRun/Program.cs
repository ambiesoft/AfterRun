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
                        Int32.TryParse(args[i], out interval_);
                    }
                }
                else
                {
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