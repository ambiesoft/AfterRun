﻿namespace Ambiesoft.AfterRunLib
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
            this.txtExe = new System.Windows.Forms.TextBox();
            this.txtArg = new System.Windows.Forms.TextBox();
            this.btnSetAsDefault = new System.Windows.Forms.Button();
            this.txtInterval = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnStart.Location = new System.Drawing.Point(522, 349);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(95, 30);
            this.btnStart.TabIndex = 500;
            this.btnStart.Text = "&Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(624, 349);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 30);
            this.btnCancel.TabIndex = 600;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // txtExe
            // 
            this.txtExe.Location = new System.Drawing.Point(66, 71);
            this.txtExe.Name = "txtExe";
            this.txtExe.Size = new System.Drawing.Size(590, 19);
            this.txtExe.TabIndex = 200;
            // 
            // txtArg
            // 
            this.txtArg.Location = new System.Drawing.Point(66, 119);
            this.txtArg.Name = "txtArg";
            this.txtArg.Size = new System.Drawing.Size(590, 19);
            this.txtArg.TabIndex = 300;
            // 
            // btnSetAsDefault
            // 
            this.btnSetAsDefault.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSetAsDefault.Location = new System.Drawing.Point(12, 347);
            this.btnSetAsDefault.Name = "btnSetAsDefault";
            this.btnSetAsDefault.Size = new System.Drawing.Size(95, 30);
            this.btnSetAsDefault.TabIndex = 400;
            this.btnSetAsDefault.Text = "Set As &Default";
            this.btnSetAsDefault.UseVisualStyleBackColor = true;
            this.btnSetAsDefault.Click += new System.EventHandler(this.btnSetAsDefault_Click);
            // 
            // txtInterval
            // 
            this.txtInterval.Location = new System.Drawing.Point(66, 31);
            this.txtInterval.Name = "txtInterval";
            this.txtInterval.Size = new System.Drawing.Size(100, 19);
            this.txtInterval.TabIndex = 100;
            // 
            // UserInputDialog
            // 
            this.AcceptButton = this.btnStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(731, 389);
            this.Controls.Add(this.txtInterval);
            this.Controls.Add(this.btnSetAsDefault);
            this.Controls.Add(this.txtArg);
            this.Controls.Add(this.txtExe);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnStart);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserInputDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Input | Afterrun";
            this.Load += new System.EventHandler(this.UserInputDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtExe;
        private System.Windows.Forms.TextBox txtArg;
        private System.Windows.Forms.Button btnSetAsDefault;
        private System.Windows.Forms.TextBox txtInterval;
    }
}