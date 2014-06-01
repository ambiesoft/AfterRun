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
            if (Program.iscenter_)
            {
                this.StartPosition = FormStartPosition.CenterScreen;
            }

            if (Program.istopmost_)
            {
                this.TopMost = true;
            }
        }

        private void Launch()
        {


            System.Diagnostics.Process.Start(Program.exe_);
            Close();
        }

        private void timerMain_Tick(object sender, EventArgs e)
        {
            int n = Int32.Parse(timerMain.Tag.ToString());
            if (n == -1)
            {
                return;
            }

            n--;
            if (n < 0)
            {
                if (!EnableLaunch)
                    return;

                EnableLaunch = false;
                
                Launch();

                return;
            }

            btnOK.Text = "OK" + " (" + n + ")";
            this.Text = n.ToString() + " | " + Program.exe_ + " | " + Application.ProductName;
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
            if (Program.interval_ == -1)
            {
                timerMain.Enabled = false;
            }
            else
            {
                timerMain.Tag = Program.interval_;
            }
        }

        private bool EnableLaunch
        {
            get
            {
                return btnOK.Enabled;
            }
            set
            {
                btnOK.Enabled = value;
                timerMain.Enabled = value;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!EnableLaunch)
                return;

            EnableLaunch = false;
            Launch();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}