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
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnStart.Location = new System.Drawing.Point(308, 220);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(95, 32);
            this.btnStart.TabIndex = 500;
            this.btnStart.Text = "&Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(409, 219);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 32);
            this.btnCancel.TabIndex = 600;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSetAsDefault
            // 
            this.btnSetAsDefault.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSetAsDefault.Location = new System.Drawing.Point(12, 220);
            this.btnSetAsDefault.Name = "btnSetAsDefault";
            this.btnSetAsDefault.Size = new System.Drawing.Size(154, 32);
            this.btnSetAsDefault.TabIndex = 400;
            this.btnSetAsDefault.Text = "Set As &Default";
            this.btnSetAsDefault.UseVisualStyleBackColor = true;
            this.btnSetAsDefault.Click += new System.EventHandler(this.btnSetAsDefault_Click);
            // 
            // btnBrowseExe
            // 
            this.btnBrowseExe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseExe.Location = new System.Drawing.Point(447, 83);
            this.btnBrowseExe.Name = "btnBrowseExe";
            this.btnBrowseExe.Size = new System.Drawing.Size(57, 20);
            this.btnBrowseExe.TabIndex = 250;
            this.btnBrowseExe.Text = "&...";
            this.btnBrowseExe.UseVisualStyleBackColor = true;
            this.btnBrowseExe.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // cmbExe
            // 
            this.cmbExe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbExe.FormattingEnabled = true;
            this.cmbExe.Location = new System.Drawing.Point(12, 83);
            this.cmbExe.Name = "cmbExe";
            this.cmbExe.Size = new System.Drawing.Size(429, 23);
            this.cmbExe.TabIndex = 200;
            // 
            // cmbArg
            // 
            this.cmbArg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbArg.FormattingEnabled = true;
            this.cmbArg.Location = new System.Drawing.Point(15, 142);
            this.cmbArg.Name = "cmbArg";
            this.cmbArg.Size = new System.Drawing.Size(426, 23);
            this.cmbArg.TabIndex = 300;
            // 
            // cmbInterval
            // 
            this.cmbInterval.FormattingEnabled = true;
            this.cmbInterval.Location = new System.Drawing.Point(12, 29);
            this.cmbInterval.Name = "cmbInterval";
            this.cmbInterval.Size = new System.Drawing.Size(121, 23);
            this.cmbInterval.TabIndex = 100;
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(12, 11);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(62, 15);
            this.lblDuration.TabIndex = 50;
            this.lblDuration.Text = "&Duration:";
            // 
            // lblExecutable
            // 
            this.lblExecutable.AutoSize = true;
            this.lblExecutable.Location = new System.Drawing.Point(12, 65);
            this.lblExecutable.Name = "lblExecutable";
            this.lblExecutable.Size = new System.Drawing.Size(75, 15);
            this.lblExecutable.TabIndex = 150;
            this.lblExecutable.Text = "&Executable:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 15);
            this.label1.TabIndex = 275;
            this.label1.Text = "&Argument:";
            // 
            // UserInputDialog
            // 
            this.AcceptButton = this.btnStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(516, 264);
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
            this.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserInputDialog";
            this.ShowIcon = false;
            this.Text = "Input | Afterrun";
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
    }
}