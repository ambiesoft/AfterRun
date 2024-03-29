﻿namespace Ambiesoft.AfterRunLib
{
    partial class FormMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region FormDesigner

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.timerMain = new System.Windows.Forms.Timer(this.components);
            this.labelTitle = new System.Windows.Forms.Label();
            this.lvExes = new System.Windows.Forms.ListView();
            this.colExecutable = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colArgument = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // timerMain
            // 
            this.timerMain.Interval = 1000;
            this.timerMain.Tag = "10";
            this.timerMain.Tick += new System.EventHandler(this.timerMain_Tick);
            // 
            // labelTitle
            // 
            resources.ApplyResources(this.labelTitle, "labelTitle");
            this.labelTitle.Name = "labelTitle";
            // 
            // lvExes
            // 
            resources.ApplyResources(this.lvExes, "lvExes");
            this.lvExes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colExecutable,
            this.colArgument});
            this.lvExes.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvExes.HideSelection = false;
            this.lvExes.MultiSelect = false;
            this.lvExes.Name = "lvExes";
            this.lvExes.ShowItemToolTips = true;
            this.lvExes.UseCompatibleStateImageBehavior = false;
            this.lvExes.View = System.Windows.Forms.View.Details;
            // 
            // colExecutable
            // 
            resources.ApplyResources(this.colExecutable, "colExecutable");
            // 
            // colArgument
            // 
            resources.ApplyResources(this.colArgument, "colArgument");
            // 
            // FormMain
            // 
            this.AcceptButton = this.btnOK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.lvExes);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Timer timerMain;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.ListView lvExes;
        private System.Windows.Forms.ColumnHeader colExecutable;
        private System.Windows.Forms.ColumnHeader colArgument;
    }
}

