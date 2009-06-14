using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CommandLine.Utility;

namespace AfterRun
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void Launch()
        {
            String[] args = Environment.GetCommandLineArgs();
            for (int i = 1; i < args.Length; ++i)
            {
                System.Diagnostics.Process.Start(args[i]);
            }
            Close();
        }

        private void timerMain_Tick(object sender, EventArgs e)
        {
            int n = Int32.Parse(timerMain.Tag.ToString());
            n--;
            if (n < 0)
            {
                Launch();
            }

            btnOK.Text = "OK" + " (" + n + ")";
            timerMain.Tag = n;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            String[] args = Environment.GetCommandLineArgs();

            if (args.Length < 2)
            {
                MessageBox.Show(AfterRun.Properties.Resources.NoArguments);
                Close();
            }
            String s = String.Format(AfterRun.Properties.Resources.Launching, args[1]);
            labelTitle.Text = s;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Launch();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}