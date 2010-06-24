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

        [STAThread]
        static void Main()
        {
            String[] args = Environment.GetCommandLineArgs();

            if (args.Length < 2)
            {
                MessageBox.Show(AfterRun.Properties.Resources.NoArguments);
                return;
            }

            for (int i = 1; i < args.Length; ++i)
            {
                if (args[i].StartsWith("-t"))
                {
                    if ((i - 1) == args.Length)
                    {
                        MessageBox.Show(AfterRun.Properties.Resources.NoArgumentForInterval);
                        return;
                    }
                    ++i;

                    Int32.TryParse(args[i], out interval_);
                }
                else
                {
                    if (exe_ != null)
                    {
                        MessageBox.Show(AfterRun.Properties.Resources.MultipleInputs);
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