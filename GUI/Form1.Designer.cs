namespace Furcadia_Installer_Browser
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnOpenInstaller = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExtractAll = new System.Windows.Forms.ToolStripButton();
            this.btnCompareTo = new System.Windows.Forms.ToolStripButton();
            this.btnCrcTest = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnReport = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.txtInstallerName = new System.Windows.Forms.ToolStripLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.txtStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.dgvInstallerList = new System.Windows.Forms.DataGridView();
            this.Filename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmFileListMenu = new System.Windows.Forms.ContextMenuStrip();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extractToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.validateCRC32ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CRC32 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CRCTest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fdOpenInstaller = new System.Windows.Forms.OpenFileDialog();
            this.fdExport = new System.Windows.Forms.SaveFileDialog();
            this.txtDragDrop = new System.Windows.Forms.Label();
            this.fbdTargetFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.cmFileListMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOpenInstaller,
            this.toolStripSeparator1,
            this.btnExtractAll,
            this.btnCompareTo,
            this.btnCrcTest,
            this.toolStripSeparator2,
            this.btnReport,
            this.toolStripSeparator3,
            this.btnExit,
            this.txtInstallerName});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(745, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnOpenInstaller
            // 
            this.btnOpenInstaller.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnOpenInstaller.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenInstaller.Image")));
            this.btnOpenInstaller.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpenInstaller.Name = "btnOpenInstaller";
            this.btnOpenInstaller.Size = new System.Drawing.Size(84, 22);
            this.btnOpenInstaller.Text = "&Open Installer";
            this.btnOpenInstaller.ToolTipText = "Open a Furcadia installer";
            this.btnOpenInstaller.Click += new System.EventHandler(this.btnOpenInstaller_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnExtractAll
            // 
            this.btnExtractAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnExtractAll.Enabled = false;
            this.btnExtractAll.Image = ((System.Drawing.Image)(resources.GetObject("btnExtractAll.Image")));
            this.btnExtractAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExtractAll.Name = "btnExtractAll";
            this.btnExtractAll.Size = new System.Drawing.Size(72, 22);
            this.btnExtractAll.Text = "Extract &All...";
            this.btnExtractAll.ToolTipText = "Extract all the files into a specific folder";
            this.btnExtractAll.Click += new System.EventHandler(this.btnExtractAll_Click);
            // 
            // btnCompareTo
            // 
            this.btnCompareTo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnCompareTo.Enabled = false;
            this.btnCompareTo.Image = ((System.Drawing.Image)(resources.GetObject("btnCompareTo.Image")));
            this.btnCompareTo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCompareTo.Name = "btnCompareTo";
            this.btnCompareTo.Size = new System.Drawing.Size(86, 22);
            this.btnCompareTo.Text = "&Compare To...";
            this.btnCompareTo.ToolTipText = "Compare two installers";
            this.btnCompareTo.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // btnCrcTest
            // 
            this.btnCrcTest.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnCrcTest.Enabled = false;
            this.btnCrcTest.Image = ((System.Drawing.Image)(resources.GetObject("btnCrcTest.Image")));
            this.btnCrcTest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCrcTest.Name = "btnCrcTest";
            this.btnCrcTest.Size = new System.Drawing.Size(59, 22);
            this.btnCrcTest.Text = "CRC &Test";
            this.btnCrcTest.ToolTipText = "Validate integrity of all files";
            this.btnCrcTest.Click += new System.EventHandler(this.btnCrcTest_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnReport
            // 
            this.btnReport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnReport.Enabled = false;
            this.btnReport.Image = ((System.Drawing.Image)(resources.GetObject("btnReport.Image")));
            this.btnReport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(55, 22);
            this.btnReport.Text = "&Report...";
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnExit
            // 
            this.btnExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(29, 22);
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtInstallerName
            // 
            this.txtInstallerName.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.txtInstallerName.Name = "txtInstallerName";
            this.txtInstallerName.Size = new System.Drawing.Size(44, 22);
            this.txtInstallerName.Text = "No File";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 333);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(745, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // txtStatus
            // 
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(70, 17);
            this.txtStatus.Text = "Initializing...";
            // 
            // dgvInstallerList
            // 
            this.dgvInstallerList.AllowUserToAddRows = false;
            this.dgvInstallerList.AllowUserToDeleteRows = false;
            this.dgvInstallerList.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.NullValue = null;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInstallerList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInstallerList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInstallerList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Filename,
            this.Size,
            this.CRC32,
            this.CRCTest});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInstallerList.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvInstallerList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInstallerList.Location = new System.Drawing.Point(0, 25);
            this.dgvInstallerList.Name = "dgvInstallerList";
            this.dgvInstallerList.ReadOnly = true;
            this.dgvInstallerList.RowHeadersVisible = false;
            this.dgvInstallerList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInstallerList.Size = new System.Drawing.Size(745, 308);
            this.dgvInstallerList.TabIndex = 1;
            this.dgvInstallerList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInstallerList_CellDoubleClick);
            this.dgvInstallerList.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInstallerList_CellMouseEnter);
            // 
            // Filename
            // 
            this.Filename.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Filename.ContextMenuStrip = this.cmFileListMenu;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Filename.DefaultCellStyle = dataGridViewCellStyle2;
            this.Filename.HeaderText = "Filename";
            this.Filename.MaxInputLength = 256;
            this.Filename.MinimumWidth = 200;
            this.Filename.Name = "Filename";
            this.Filename.ReadOnly = true;
            // 
            // cmFileListMenu
            // 
            this.cmFileListMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.extractToolStripMenuItem,
            this.validateCRC32ToolStripMenuItem});
            this.cmFileListMenu.Name = "cmFileListMenu";
            this.cmFileListMenu.Size = new System.Drawing.Size(155, 92);
            this.cmFileListMenu.Opening += new System.ComponentModel.CancelEventHandler(this.cmFileListMenu_Opening);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // extractToolStripMenuItem
            // 
            this.extractToolStripMenuItem.Name = "extractToolStripMenuItem";
            this.extractToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.extractToolStripMenuItem.Text = "Extract...";
            this.extractToolStripMenuItem.Click += new System.EventHandler(this.extractToolStripMenuItem_Click);
            // 
            // validateCRC32ToolStripMenuItem
            // 
            this.validateCRC32ToolStripMenuItem.Name = "validateCRC32ToolStripMenuItem";
            this.validateCRC32ToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.validateCRC32ToolStripMenuItem.Text = "Validate CRC32";
            this.validateCRC32ToolStripMenuItem.Click += new System.EventHandler(this.validateCRC32ToolStripMenuItem_Click);
            // 
            // Size
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Size.DefaultCellStyle = dataGridViewCellStyle3;
            this.Size.HeaderText = "Size (Compressed)";
            this.Size.MaxInputLength = 10;
            this.Size.MinimumWidth = 120;
            this.Size.Name = "Size";
            this.Size.ReadOnly = true;
            this.Size.Width = 120;
            // 
            // CRC32
            // 
            this.CRC32.HeaderText = "CRC32";
            this.CRC32.MaxInputLength = 10;
            this.CRC32.MinimumWidth = 80;
            this.CRC32.Name = "CRC32";
            this.CRC32.ReadOnly = true;
            this.CRC32.Width = 80;
            // 
            // CRCTest
            // 
            this.CRCTest.HeaderText = "CRC Test";
            this.CRCTest.MaxInputLength = 8;
            this.CRCTest.MinimumWidth = 80;
            this.CRCTest.Name = "CRCTest";
            this.CRCTest.ReadOnly = true;
            this.CRCTest.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // fdOpenInstaller
            // 
            this.fdOpenInstaller.DefaultExt = "exe";
            this.fdOpenInstaller.FileName = "furcsetup.exe";
            this.fdOpenInstaller.Filter = "Executables|*.exe|All files|*.*";
            this.fdOpenInstaller.Title = "Open Installer...";
            // 
            // fdExport
            // 
            this.fdExport.DefaultExt = "txt";
            this.fdExport.FileName = "furcsetup.txt";
            this.fdExport.Filter = "Text files|*.txt|All files|*.*";
            this.fdExport.Title = "Export Info...";
            // 
            // txtDragDrop
            // 
            this.txtDragDrop.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDragDrop.BackColor = System.Drawing.SystemColors.Window;
            this.txtDragDrop.Location = new System.Drawing.Point(219, 178);
            this.txtDragDrop.MinimumSize = new System.Drawing.Size(308, 25);
            this.txtDragDrop.Name = "txtDragDrop";
            this.txtDragDrop.Padding = new System.Windows.Forms.Padding(6);
            this.txtDragDrop.Size = new System.Drawing.Size(308, 25);
            this.txtDragDrop.TabIndex = 3;
            this.txtDragDrop.Text = "Drag && Drop a Furcadia installer file in here.";
            this.txtDragDrop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fbdTargetFolder
            // 
            this.fbdTargetFolder.Description = "Target folder to extract all the files to";
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 355);
            this.Controls.Add(this.txtDragDrop);
            this.Controls.Add(this.dgvInstallerList);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Text = "Furcadia Installer Browser 1.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.cmFileListMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnOpenInstaller;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnExit;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel txtStatus;
        private System.Windows.Forms.DataGridView dgvInstallerList;
        private System.Windows.Forms.ToolStripButton btnCompareTo;
        private System.Windows.Forms.ToolStripButton btnCrcTest;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel txtInstallerName;
        private System.Windows.Forms.ToolStripButton btnExtractAll;
        private System.Windows.Forms.OpenFileDialog fdOpenInstaller;
        private System.Windows.Forms.SaveFileDialog fdExport;
        private System.Windows.Forms.Label txtDragDrop;
        private System.Windows.Forms.ContextMenuStrip cmFileListMenu;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extractToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem validateCRC32ToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Filename;
        private System.Windows.Forms.DataGridViewTextBoxColumn Size;
        private System.Windows.Forms.DataGridViewTextBoxColumn CRC32;
        private System.Windows.Forms.DataGridViewTextBoxColumn CRCTest;
        private System.Windows.Forms.FolderBrowserDialog fbdTargetFolder;
        private System.Windows.Forms.ToolStripButton btnReport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}

