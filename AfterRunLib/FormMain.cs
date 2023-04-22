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

        readonly UserInput userInput_ = null;

        readonly string okText_;
        readonly string cancelText_;
        public FormMain(UserInput ui)
        {
            userInput_ = ui;

            InitializeComponent();

            HashIni ini = Profile.ReadAll(Program.IniPath);

            AmbLib.LoadFormXYWH(this, KEY_LOCATION, ini);
            AmbLib.LoadListViewColumnWidth(lvExes, SECTION_SETTINGS, KEY_COLUMNWIDTH, ini);

            // preserve btn text
            okText_ = btnOK.Text;
            cancelText_=btnCancel.Text;

            if(userInput_.DefaultCancel)
            {
                // Swap the size of the OK and Cancel button
                Size okSize = btnOK.Size;
                int distance = btnCancel.Location.X-(btnOK.Location.X+btnOK.Size.Width);
                Debug.Assert(distance > 0);
                Size cancelSize = btnCancel.Size;

                btnOK.Size = cancelSize; 
                btnCancel.Size = okSize;

                int xPosOfRightButton =btnOK.Location.X + btnOK.Size.Width +
                    btnOK.Padding.Right + btnCancel.Padding.Left +
                    btnOK.Margin.Right+btnCancel.Margin.Left; 
                btnCancel.Location=new Point(xPosOfRightButton,btnOK.Location.Y);

                btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
                btnCancel.Anchor=AnchorStyles.Bottom | AnchorStyles.Left|AnchorStyles.Right;
            }
        }

        private void LaunchAndClose(bool bDoLaunch)
        {
            if (!EnableLaunch)
                return;
            EnableLaunch = false;

            // this.WindowState = FormWindowState.Normal;

            if (bDoLaunch || !userInput_.DefaultCancel)
            {
                if (!userInput_.IsShutdown)
                {
                    foreach (var exearg in userInput_.ExeArgs)
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
                        psi.WindowStyle = userInput_.LaunchingProcessWindowStyle;
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
            }
            Close();
        }
        void LaunchAndClose()
        {
            LaunchAndClose(false);
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
            var waitsPid = new List<int>(userInput_.PidsToWait);
            foreach (Process p in Process.GetProcesses())
            {
                if (userInput_.PidsToWait.Contains(p.Id))
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
            TaskbarManager.Instance.SetProgressValue((userInput_.Interval??1) - n, userInput_.Interval??1);

            TimeSpan tsCurrent = TimeSpan.FromSeconds(n);
            string timeString = tsCurrent.ToString();

            Debug.Assert(userInput_.Interval != null);
            TimeSpan tsAll = TimeSpan.FromSeconds(userInput_.Interval ?? 0);
            string timeStringAll = tsAll.ToString();

            string btnText = userInput_.DefaultCancel ? cancelText_ : okText_;
            Button targetButton = userInput_.DefaultCancel ? btnCancel : btnOK;

            targetButton.Text = string.Format("{0} ({1})", btnText, timeString);
            this.Text = string.Format("{0}/{1} | {2} | {3}",
                timeString, timeStringAll,
                string.Join(" ", userInput_.Exes),
                 Application.ProductName);
            timerMain.Tag = n;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            if (!userInput_.IsShutdown && userInput_.ExeArgs.Count == 0)
            {
                MessageBox.Show(Properties.Resources.NoArguments);
                Close();
                return;
            }
            if (!userInput_.IsShutdown)
            {
                labelTitle.Text = Properties.Resources.Launching;
            }
            else
            {
                labelTitle.Text = Properties.Resources.Shutdowning;
            }

            if (userInput_.IsShutdown)
            {
                lvExes.Enabled = false;
            }
            else
            {
                foreach (var exes in userInput_.ExeArgs)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = exes.Exe;
                    item.SubItems.Add(exes.Arg);

                    lvExes.Items.Add(item);
                }
            }
            if (userInput_.Interval != null)
            {
                Text = "CountDown" + " " + Text;
                if (userInput_.Interval == -1)
                {
                    timerMain.Enabled = false;
                    TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress);
                }
                else
                {
                    timerMain.Tag = userInput_.Interval;
                }
            }
            else if (userInput_.PidsToWait != null)
            {
                Text = "Wait Process" + " " + Text;
                timerMain.Interval = 5000;
                timerMain.Tag = userInput_.PidsToWait;
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

            LaunchAndClose(true);
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