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
            Ambiesoft.AfterRunLib.FormMain form = new Ambiesoft.AfterRunLib.FormMain();
            form.IsShutdown = true;
            Application.Run(form);
        }
    }
}
