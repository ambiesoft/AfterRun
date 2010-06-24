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
            System.Diagnostics.Process.Start(Program.exe_);
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
            if( string.IsNullOrEmpty(Program.exe_) )
            {
                MessageBox.Show(AfterRun.Properties.Resources.NoArguments);
                Close();
                return;
            }
            String s = String.Format(AfterRun.Properties.Resources.Launching, Program.exe_);
            labelTitle.Text = s;
            timerMain.Tag = Program.interval_;
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