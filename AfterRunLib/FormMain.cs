using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CommandLine.Utility;
using System.Diagnostics;

namespace Ambiesoft.AfterRunLib
{
    public partial class FormMain : Form
    {
        public string exe_ = null;
        public int Interval = 10;
        // public FormStartPosition InitStartPosition = default(FormStartPosition);
        // public bool InitTopMost = false;
        public System.Diagnostics.ProcessWindowStyle LaunchingProcessWindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
        public bool IsShutdown = false;

        public FormMain()
        {
            InitializeComponent();

            //if (InitStartPosition != default(FormStartPosition))
            //    StartPosition = InitStartPosition;

            //this.TopMost = InitTopMost;
        }

        private void Launch()
        {
            if (!IsShutdown)
            {
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = exe_;
                psi.WindowStyle = LaunchingProcessWindowStyle;

                try
                {
                    System.Diagnostics.Process.Start(psi);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,
                        Application.ProductName,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            else
            {
                AmbLib.ExitWin(AmbLib.EXITWINTYPE.EXITWIN_SHUTDOWN);
            }
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
            this.Text = n.ToString() + " | " + exe_ + " | " + Application.ProductName;
            timerMain.Tag = n;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            if( !IsShutdown && string.IsNullOrEmpty(exe_) )
            {
                MessageBox.Show(Properties.Resources.NoArguments);
                Close();
                return;
            }
            if (!IsShutdown)
            {
                String s = String.Format(Properties.Resources.Launching, exe_);
                labelTitle.Text = s;
            }
            else
            {
                labelTitle.Text = Properties.Resources.Shutdowning;
            }

            if (Interval == -1)
            {
                timerMain.Enabled = false;
            }
            else
            {
                timerMain.Tag = Interval;
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