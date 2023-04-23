using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestShutdown
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Ambiesoft.AfterRunLib.FormMain form = new Ambiesoft.AfterRunLib.FormMain(
                new Ambiesoft.AfterRunLib.UserInput(
                    false,
                    null,
                    null,
                    null,
                    System.Diagnostics.ProcessWindowStyle.Normal,
                    false));
            Application.Run(form);
        }
    }
}
