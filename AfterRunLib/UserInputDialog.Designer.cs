namespace Ambiesoft.AfterRunLib
{
    partial class UserInputDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserInputDialog));
            this.btnStart = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSetAsDefault = new System.Windows.Forms.Button();
            this.btnBrowseExe = new System.Windows.Forms.Button();
            this.cmbExe = new System.Windows.Forms.ComboBox();
            this.cmbArg = new System.Windows.Forms.ComboBox();
            this.cmbInterval = new System.Windows.Forms.ComboBox();
            this.lblDuration = new System.Windows.Forms.Label();
            this.lblExecutable = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDurationInformation = new System.Windows.Forms.Label();
            this.chkStartWithMinimized = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            resources.ApplyResources(this.btnStart, "btnStart");
            this.btnStart.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnStart.Name = "btnStart";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSetAsDefault
            // 
            resources.ApplyResources(this.btnSetAsDefault, "btnSetAsDefault");
            this.btnSetAsDefault.Name = "btnSetAsDefault";
            this.btnSetAsDefault.UseVisualStyleBackColor = true;
            this.btnSetAsDefault.Click += new System.EventHandler(this.btnSetAsDefault_Click);
            // 
            // btnBrowseExe
            // 
            resources.ApplyResources(this.btnBrowseExe, "btnBrowseExe");
            this.btnBrowseExe.Name = "btnBrowseExe";
            this.btnBrowseExe.UseVisualStyleBackColor = true;
            this.btnBrowseExe.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // cmbExe
            // 
            resources.ApplyResources(this.cmbExe, "cmbExe");
            this.cmbExe.FormattingEnabled = true;
            this.cmbExe.Name = "cmbExe";
            // 
            // cmbArg
            // 
            resources.ApplyResources(this.cmbArg, "cmbArg");
            this.cmbArg.FormattingEnabled = true;
            this.cmbArg.Name = "cmbArg";
            // 
            // cmbInterval
            // 
            this.cmbInterval.FormattingEnabled = true;
            resources.ApplyResources(this.cmbInterval, "cmbInterval");
            this.cmbInterval.Name = "cmbInterval";
            this.cmbInterval.TextChanged += new System.EventHandler(this.cmbInterval_TextChanged);
            // 
            // lblDuration
            // 
            resources.ApplyResources(this.lblDuration, "lblDuration");
            this.lblDuration.Name = "lblDuration";
            // 
            // lblExecutable
            // 
            resources.ApplyResources(this.lblExecutable, "lblExecutable");
            this.lblExecutable.Name = "lblExecutable";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // lblDurationInformation
            // 
            resources.ApplyResources(this.lblDurationInformation, "lblDurationInformation");
            this.lblDurationInformation.Name = "lblDurationInformation";
            // 
            // chkStartWithMinimized
            // 
            resources.ApplyResources(this.chkStartWithMinimized, "chkStartWithMinimized");
            this.chkStartWithMinimized.Name = "chkStartWithMinimized";
            this.chkStartWithMinimized.UseVisualStyleBackColor = true;
            // 
            // UserInputDialog
            // 
            this.AcceptButton = this.btnStart;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.chkStartWithMinimized);
            this.Controls.Add(this.lblDurationInformation);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblExecutable);
            this.Controls.Add(this.lblDuration);
            this.Controls.Add(this.cmbInterval);
            this.Controls.Add(this.cmbArg);
            this.Controls.Add(this.cmbExe);
            this.Controls.Add(this.btnBrowseExe);
            this.Controls.Add(this.btnSetAsDefault);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnStart);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserInputDialog";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.UserInputDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSetAsDefault;
        private System.Windows.Forms.Button btnBrowseExe;
        private System.Windows.Forms.ComboBox cmbExe;
        private System.Windows.Forms.ComboBox cmbArg;
        private System.Windows.Forms.ComboBox cmbInterval;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.Label lblExecutable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDurationInformation;
        private System.Windows.Forms.CheckBox chkStartWithMinimized;
    }
}