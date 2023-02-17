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

        UserInput ui_;
        public UserInputDialog(UserInput ui)
        {
            InitializeComponent();

            this.ui_ = ui;

            HashIni ini = Ambiesoft.Profile.ReadAll(Program.IniPath);
            string s;
            if(ui.ExeArgs.Count !=0)
            {
                txtExe.Text = ui.ExeArgs[0].Exe;
                txtArg.Text = ui.ExeArgs[0].Arg;
            }
            else
            {
                Profile.GetString(SECTION_DEFAULT_VALUES, KEY_EXECUTABLE, string.Empty, out s, ini);
                txtExe.Text = s;

                Profile.GetString(SECTION_DEFAULT_VALUES, KEY_ARGUMENT, string.Empty, out s, ini);
                txtArg.Text = s;
            }

            if (ui.Interval != null && ui.Interval != 0)
            {
                txtInterval.Text = ui.Interval.ToString();
            }
            else
            {
                Profile.GetString(SECTION_DEFAULT_VALUES, KEY_INTERVAL, string.Empty, out s, ini);
                txtInterval.Text = s;
            }
        }

        private void UserInputDialog_Load(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if(txtInterval.Text=="0")
            {
                CppUtils.CenteredMessageBox(this,
                    "FFF",
                    Application.ProductName,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
                return;
            }
            try
            {
                ui_.Interval=Program.parseDuration(txtInterval.Text);
            }
            catch
            {
                CppUtils.CenteredMessageBox(this,
                                    "FFF",
                                    Application.ProductName,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
                return;
            }

            if (ui_.ExeArgs.Count == 0)
            {
                ui_.ExeArgs.Add(new ExeArg(txtExe.Text, txtArg.Text));
            }
            else
            {
                ui_.ExeArgs[0].Exe = txtExe.Text;
                ui_.ExeArgs[0].Arg = txtArg.Text;
            }
        }

        private void btnSetAsDefault_Click(object sender, EventArgs e)
        {
            HashIni ini = Profile.ReadAll(Program.IniPath);

            Profile.WriteString(SECTION_DEFAULT_VALUES, KEY_EXECUTABLE, txtExe.Text, ini);
            Profile.WriteString(SECTION_DEFAULT_VALUES, KEY_ARGUMENT, txtArg.Text, ini);
            Profile.WriteString(SECTION_DEFAULT_VALUES, KEY_INTERVAL, txtInterval.Text, ini);

            if(!Profile.WriteAll(ini,Program.IniPath))
            {
                CppUtils.CenteredMessageBox(this,
                    "FFF",
                    Application.ProductName,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            string newFile = AmbLib.GetOpenFileDialog("FFF", AmbLib.GETOPENFILEDIALOGTYPE.APP);
            if(string.IsNullOrWhiteSpace(newFile))
            {
                return;
            }

            txtExe.Text = newFile; 
        }
    }
}
