using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using Ambiesoft.AfterRunLib;
namespace AfterRun
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Ambiesoft.AfterRunLib.Program.Main(Environment.GetCommandLineArgs());
        }
    }
}
