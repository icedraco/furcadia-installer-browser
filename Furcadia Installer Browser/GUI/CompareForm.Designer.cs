namespace Furcadia_Installer_Browser
{
    partial class CompareForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components;

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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnExtract = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.cbShowIdentical = new System.Windows.Forms.CheckBox();
            this.cbUnique = new System.Windows.Forms.CheckBox();
            this.cbDifferent = new System.Windows.Forms.CheckBox();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.progress = new System.Windows.Forms.ProgressBar();
            this.bgw = new System.ComponentModel.BackgroundWorker();
            this.updateTimer = new System.Windows.Forms.Timer();
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(615, 417);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnExtract
            // 
            this.btnExtract.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExtract.Location = new System.Drawing.Point(534, 417);
            this.btnExtract.Name = "btnExtract";
            this.btnExtract.Size = new System.Drawing.Size(75, 23);
            this.btnExtract.TabIndex = 1;
            this.btnExtract.Text = "E&xtract...";
            this.btnExtract.UseVisualStyleBackColor = true;
            this.btnExtract.Click += new System.EventHandler(this.btnExtract_Click);
            // 
            // btnReport
            // 
            this.btnReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReport.Location = new System.Drawing.Point(453, 417);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(75, 23);
            this.btnReport.TabIndex = 2;
            this.btnReport.Text = "&Report...";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // cbShowIdentical
            // 
            this.cbShowIdentical.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbShowIdentical.AutoSize = true;
            this.cbShowIdentical.Location = new System.Drawing.Point(13, 423);
            this.cbShowIdentical.Name = "cbShowIdentical";
            this.cbShowIdentical.Size = new System.Drawing.Size(66, 17);
            this.cbShowIdentical.TabIndex = 3;
            this.cbShowIdentical.Text = "&Identical";
            this.cbShowIdentical.UseVisualStyleBackColor = true;
            this.cbShowIdentical.CheckedChanged += new System.EventHandler(this.ShowCheckbox_CheckedChanged);
            // 
            // cbUnique
            // 
            this.cbUnique.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbUnique.AutoSize = true;
            this.cbUnique.BackColor = System.Drawing.Color.Yellow;
            this.cbUnique.Checked = true;
            this.cbUnique.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbUnique.Location = new System.Drawing.Point(157, 423);
            this.cbUnique.Name = "cbUnique";
            this.cbUnique.Size = new System.Drawing.Size(60, 17);
            this.cbUnique.TabIndex = 5;
            this.cbUnique.Text = "Unique";
            this.cbUnique.UseVisualStyleBackColor = false;
            this.cbUnique.CheckedChanged += new System.EventHandler(this.ShowCheckbox_CheckedChanged);
            // 
            // cbDifferent
            // 
            this.cbDifferent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbDifferent.AutoSize = true;
            this.cbDifferent.BackColor = System.Drawing.Color.Lime;
            this.cbDifferent.Checked = true;
            this.cbDifferent.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDifferent.Location = new System.Drawing.Point(85, 423);
            this.cbDifferent.Name = "cbDifferent";
            this.cbDifferent.Size = new System.Drawing.Size(66, 17);
            this.cbDifferent.TabIndex = 4;
            this.cbDifferent.Text = "&Different";
            this.cbDifferent.UseVisualStyleBackColor = false;
            this.cbDifferent.CheckedChanged += new System.EventHandler(this.ShowCheckbox_CheckedChanged);
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.Location = new System.Drawing.Point(12, 12);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Size = new System.Drawing.Size(678, 399);
            this.splitContainer.SplitterDistance = 339;
            this.splitContainer.TabIndex = 6;
            // 
            // progress
            // 
            this.progress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progress.Location = new System.Drawing.Point(224, 417);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(223, 22);
            this.progress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progress.TabIndex = 7;
            this.progress.Visible = false;
            // 
            // bgw
            // 
            this.bgw.WorkerSupportsCancellation = true;
            this.bgw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_DoWork);
            this.bgw.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw_RunWorkerCompleted);
            // 
            // updateTimer
            // 
            this.updateTimer.Tick += new System.EventHandler(this.updateTimer_Tick);
            // 
            // folderBrowser
            // 
            this.folderBrowser.Description = "Target folder";
            // 
            // CompareForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 452);
            this.Controls.Add(this.progress);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.cbDifferent);
            this.Controls.Add(this.cbUnique);
            this.Controls.Add(this.cbShowIdentical);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnExtract);
            this.Controls.Add(this.btnClose);
            this.Name = "CompareForm";
            this.Text = "Compare Installers";
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnExtract;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.CheckBox cbShowIdentical;
        private System.Windows.Forms.CheckBox cbUnique;
        private System.Windows.Forms.CheckBox cbDifferent;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.ProgressBar progress;
        private System.ComponentModel.BackgroundWorker bgw;
        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;

    }
}