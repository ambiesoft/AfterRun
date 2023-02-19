using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CommandLine.Utility;
using System.Diagnostics;
using Microsoft.WindowsAPICodePack.Taskbar;

namespace Ambiesoft.AfterRunLib
{
    public partial class FormMain : Form
    {
        readonly string SECTION_SETTINGS = "Settings";
        readonly string KEY_LOCATION = "Location";
        readonly string KEY_COLUMNWIDTH = "ColumnWidth";

        readonly UserInput userInput = null;

        public FormMain(UserInput ui)
        {
            userInput = ui;
            InitializeComponent();

            HashIni ini = Profile.ReadAll(Program.IniPath);

            AmbLib.LoadFormXYWH(this, KEY_LOCATION, ini);
            AmbLib.LoadListViewColumnWidth(lvExes, SECTION_SETTINGS, KEY_COLUMNWIDTH, ini);
        }

        private void LaunchAndClose()
        {
            if (!EnableLaunch)
                return;
            EnableLaunch = false;

            // this.WindowState = FormWindowState.Normal;

            if (!userInput.IsShutdown)
            {
                foreach (var exearg in userInput.ExeArgs)
                {
                    ProcessStartInfo psi = new ProcessStartInfo();
                    if (!string.IsNullOrWhiteSpace(exearg.Exe))
                    {
                        psi.FileName = exearg.Exe;
                        psi.Arguments = exearg.Arg;
                    }
                    else
                    {
                        psi.FileName = exearg.Arg;
                    }
                    psi.WindowStyle = userInput.LaunchingProcessWindowStyle;
                    psi.UseShellExecute = true;
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
            var waitsPid = new List<int>(userInput.PidsToWait);
            foreach (Process p in Process.GetProcesses())
            {
                if (userInput.PidsToWait.Contains(p.Id))
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

            TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal);
            TaskbarManager.Instance.SetProgressValue((userInput.Interval??1) - n, userInput.Interval??1);

            TimeSpan tsCurrent = TimeSpan.FromSeconds(n);
            string timeString = tsCurrent.ToString();

            Debug.Assert(userInput.Interval != null);
            TimeSpan tsAll = TimeSpan.FromSeconds(userInput.Interval ?? 0);
            string timeStringAll = tsAll.ToString();

            btnOK.Text = string.Format("OK ({0})", timeString);
            this.Text = string.Format("{0}/{1} | {2} | {3}",
                timeString, timeStringAll,
                string.Join(" ", userInput.Exes),
                 Application.ProductName);
            timerMain.Tag = n;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            if (!userInput.IsShutdown && userInput.ExeArgs.Count == 0)
            {
                MessageBox.Show(Properties.Resources.NoArguments);
                Close();
                return;
            }
            if (!userInput.IsShutdown)
            {
                labelTitle.Text = Properties.Resources.Launching;
            }
            else
            {
                labelTitle.Text = Properties.Resources.Shutdowning;
            }

            if (userInput.IsShutdown)
            {
                lvExes.Enabled = false;
            }
            else
            {
                foreach (var exes in userInput.ExeArgs)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = exes.Exe;
                    item.SubItems.Add(exes.Arg);

                    lvExes.Items.Add(item);
                }
            }
            if (userInput.Interval != null)
            {
                Text = "CountDown" + " " + Text;
                if (userInput.Interval == -1)
                {
                    timerMain.Enabled = false;
                    TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress);
                }
                else
                {
                    timerMain.Tag = userInput.Interval;
                }
            }
            else if (userInput.PidsToWait != null)
            {
                Text = "Wait Process" + " " + Text;
                timerMain.Interval = 5000;
                timerMain.Tag = userInput.PidsToWait;
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
                TaskbarManager.Instance.SetProgressState(value?TaskbarProgressBarState.Normal:TaskbarProgressBarState.NoProgress);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!EnableLaunch)
            {
                MessageBox.Show("Currently launching...");
                return;
            }

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

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            HashIni ini = Profile.ReadAll(Program.IniPath);

            if (!AmbLib.SaveFormXYWH(this, KEY_LOCATION, ini) || 
                !AmbLib.SaveListViewColumnWidth(lvExes, SECTION_SETTINGS, KEY_COLUMNWIDTH, ini) ||
                !Profile.WriteAll(ini, Program.IniPath))
            {
                CppUtils.CenteredMessageBox(this,
                    Properties.Resources.FailedToSaveIni,
                    Application.ProductName,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}