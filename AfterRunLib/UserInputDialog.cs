using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ambiesoft;

namespace Ambiesoft.AfterRunLib
{
    public partial class UserInputDialog : Form
    {
        readonly string SECTION_DEFAULT_VALUES = "DefaultValues";
        readonly string KEY_EXECUTABLE = "Executable";
        readonly string KEY_ARGUMENT = "Argument";
        readonly string KEY_INTERVAL = "Interval";
        readonly string SECTION_COMBO_INTERVAL = "ComboInterval";
        readonly string SECTION_COMBO_EXE = "ComboExe";
        readonly string SECTION_COMBO_ARG = "ComboArg";
        readonly int MAX_COMBO_SAVECOUNT = 16;

        UserInput ui_;

        public UserInputDialog(UserInput ui)
        {
            InitializeComponent();

            this.ui_ = ui;
        }

        private void UserInputDialog_Load(object sender, EventArgs e)
        {
            // Setup comboboxes, these lines must not place at Ctor because
            HashIni ini = Profile.ReadAll(Program.IniPath);
            string s;

            // cmbExe.Text is not set properly
            {
                // First, read recent items
                AmbLib.LoadComboBox(cmbExe, SECTION_COMBO_EXE, MAX_COMBO_SAVECOUNT, ini);
                AmbLib.LoadComboBox(cmbArg, SECTION_COMBO_ARG, MAX_COMBO_SAVECOUNT, ini);

                // then read default items
                if (ui_.ExeArgs.Count != 0)
                {
                    cmbExe.Text = ui_.ExeArgs[0].Exe;
                    cmbArg.Text = ui_.ExeArgs[0].Arg;
                }
                else
                {
                    Profile.GetString(SECTION_DEFAULT_VALUES, KEY_EXECUTABLE, string.Empty, out s, ini);
                    cmbExe.Text = s;

                    Profile.GetString(SECTION_DEFAULT_VALUES, KEY_ARGUMENT, string.Empty, out s, ini);
                    cmbArg.Text = s;
                }
            }

            {
                // First, read recent items
                AmbLib.LoadComboBox(cmbInterval, SECTION_COMBO_INTERVAL, MAX_COMBO_SAVECOUNT, ini);

                // then read default items
                if (ui_.Interval != null && ui_.Interval != 0)
                {
                    cmbInterval.Text = ui_.Interval.ToString();
                }
                else
                {
                    Profile.GetString(SECTION_DEFAULT_VALUES, KEY_INTERVAL, string.Empty, out s, ini);
                    cmbInterval.Text = s;
                }
            }
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbInterval.Text) || cmbInterval.Text == "0")
            {
                CppUtils.CenteredMessageBox(this,
                    Properties.Resources.DurationNoEntered,
                    Application.ProductName,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
                return;
            }

            if (string.IsNullOrWhiteSpace(cmbExe.Text) && string.IsNullOrWhiteSpace(cmbArg.Text))
            {
                CppUtils.CenteredMessageBox(this,
                                    Properties.Resources.ExeAndArgBothNoEntered,
                                    Application.ProductName,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
                return;
            }

            try
            {
                ui_.Interval = Program.parseDuration(cmbInterval.Text);
            }
            catch (Exception ex)
            {
                CppUtils.CenteredMessageBox(this,
                                    ex.Message,
                                    Application.ProductName,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
                return;
            }

            if (ui_.ExeArgs.Count == 0)
            {
                ui_.ExeArgs.Add(new ExeArg(cmbExe.Text, cmbArg.Text));
            }
            else
            {
                ui_.ExeArgs[0].Exe = cmbExe.Text;
                ui_.ExeArgs[0].Arg = cmbArg.Text;
            }

            HashIni ini = Profile.ReadAll(Program.IniPath);
            AmbLib.SaveComboBox(cmbInterval, SECTION_COMBO_INTERVAL, MAX_COMBO_SAVECOUNT, ini);
            AmbLib.SaveComboBox(cmbExe, SECTION_COMBO_EXE, MAX_COMBO_SAVECOUNT, ini);
            AmbLib.SaveComboBox(cmbArg, SECTION_COMBO_ARG, MAX_COMBO_SAVECOUNT, ini);
            if (!Profile.WriteAll(ini, Program.IniPath))
            {
                CppUtils.CenteredMessageBox(this,
                    Properties.Resources.FailedToSaveIni,
                    Application.ProductName,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnSetAsDefault_Click(object sender, EventArgs e)
        {
            HashIni ini = Profile.ReadAll(Program.IniPath);

            Profile.WriteString(SECTION_DEFAULT_VALUES, KEY_EXECUTABLE, cmbExe.Text, ini);
            Profile.WriteString(SECTION_DEFAULT_VALUES, KEY_ARGUMENT, cmbArg.Text, ini);
            Profile.WriteString(SECTION_DEFAULT_VALUES, KEY_INTERVAL, cmbInterval.Text, ini);

            if (!Profile.WriteAll(ini, Program.IniPath))
            {
                CppUtils.CenteredMessageBox(this,
                    Properties.Resources.FailedToSaveIni,
                    Application.ProductName,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            string newFile = AmbLib.GetOpenFileDialog(Properties.Resources.SelectExecutable,
                AmbLib.GETOPENFILEDIALOGTYPE.APP);
            if (string.IsNullOrWhiteSpace(newFile))
            {
                return;
            }

            cmbExe.Text = newFile;
        }

        private void cmbInterval_TextChanged(object sender, EventArgs e)
        {
            lblDurationInformation.Text = string.Empty;

            if (string.IsNullOrWhiteSpace(cmbInterval.Text) || cmbInterval.Text == "0")
            {
                lblDurationInformation.Text = Properties.Resources.DurationNoEntered;
            }

            try
            {
                TimeSpan ts = TimeSpan.FromSeconds(Program.parseDuration(cmbInterval.Text));
                lblDurationInformation.Text = ts.ToString();
            }
            catch (Exception)
            {
                lblDurationInformation.Text = Properties.Resources.InvalidDurationFormat;
                return;
            }
        }
    }
}
