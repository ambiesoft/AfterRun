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
        public List<string> exes_ = new List<string>();
        public int? Interval = null;
        public List<int> pidsToWait = null;

        // public FormStartPosition InitStartPosition = default(FormStartPosition);
        // public bool InitTopMost = false;
        public System.Diagnostics.ProcessWindowStyle LaunchingProcessWindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
        public bool IsShutdown = false;

        public FormMain()
        {
            InitializeComponent();
        }

        private void LaunchAndClose()
        {
            if (!EnableLaunch)
                return;
            EnableLaunch = false;

            if (!IsShutdown)
            {
                foreach (string exe in exes_)
                {
                    ProcessStartInfo psi = new ProcessStartInfo();
                    psi.FileName = exe;
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
            }
            else
            {
                AmbLib.ExitWin(AmbLib.EXITWINTYPE.EXITWIN_SHUTDOWN);
            }
            Close();
        }

        private void timerMain_Tick(object sender, EventArgs e)
        {
            Debug.Assert(timerMain.Tag != null);
            if (timerMain.Tag is int)
            {
                timerMain_TickCountDown();
            }
            else if (timerMain.Tag is List<int>)
            {
                timerMain_TickWaitPidsToTerminate();
            }
            else
            {
                Debug.Assert(false);
            }
        }
        void timerMain_TickWaitPidsToTerminate()
        {
            var waitsPid = new List<int>(pidsToWait);
            foreach (Process p in Process.GetProcesses())
            {
                if (pidsToWait.Contains(p.Id))
                {
                    // process still exists
                    return;
                }
            }
            LaunchAndClose();
        }

        private void timerMain_TickCountDown()
        {
            int n = Int32.Parse(timerMain.Tag.ToString());
            if (n == -1)
            {
                return;
            }

            n--;
            if (n < 0)
            {
                LaunchAndClose();
                return;
            }

            btnOK.Text = "OK" + " (" + n + ")";
            this.Text = n.ToString() + " | " + string.Join(" ", exes_) + " | " + Application.ProductName;
            timerMain.Tag = n;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            if (!IsShutdown && exes_.Count == 0)
            {
                MessageBox.Show(Properties.Resources.NoArguments);
                Close();
                return;
            }
            if (!IsShutdown)
            {
                String s = String.Format(Properties.Resources.Launching,
                    string.Join(" ", exes_));
                labelTitle.Text = s;
            }
            else
            {
                labelTitle.Text = Properties.Resources.Shutdowning;
            }

            if (Interval != null)
            {
                Text = "CountDown" + " " + Text;
                if (Interval == -1)
                {
                    timerMain.Enabled = false;
                }
                else
                {
                    timerMain.Tag = Interval;
                }
            }
            else if (pidsToWait != null)
            {
                Text = "Wait Process" + " " + Text;
                timerMain.Interval = 5000;
                timerMain.Tag = pidsToWait;
            }
            else
            {
                Debug.Assert(true);
                Close();
            }
            timerMain.Enabled = true;
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
            LaunchAndClose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            if(TopMost)
            {
                TopMost = false;
                TopMost = true;
            }
        }
    }
}