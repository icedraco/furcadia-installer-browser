using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using LibRCH2;

namespace Furcadia_Installer_Browser
{
    public partial class Form1 : Form
    {
        /*** Constants ***/
        private static Color COLOR_PASS = Color.Lime;
        private static Color COLOR_FAIL = Color.Red;

        /*** Data Members ***/
        private RCH2Container rch2 = null;
        private DataGridViewRow CurrentRow = null;

        /*** Properties ***/
        private string Status { get { return txtStatus.Text; } set { txtStatus.Text = value; } }

        /*** Constructor ***/
        public Form1()
        {
            FIB.Init();
            InitializeComponent();
        }

        /*** Methods ***/
        private string GenerateReport()
        {
            StringBuilder buffer = new StringBuilder();
            buffer.AppendLine(String.Format("--- Install package contents of: {0}", txtInstallerName.Text));

            foreach (DataGridViewRow row in dgvInstallerList.Rows)
            {
                string crcmsg = (row.Cells[3].Style.BackColor == COLOR_FAIL) ? "(CRC FAIL) " : "";
                buffer.AppendLine(
                    String.Format("{0,8} [{1,8}] {2}{3}",
                        row.Cells[2].Value,
                        row.Cells[1].Value,
                        row.Cells[0].Value,
                        crcmsg)
                    );
            }

            buffer.AppendLine("--- END OF REPORT");
            return buffer.ToString();
        }
        private RCH2File FindFileByPath(string filePath)
        {
            return FIB.FindFileByPath(rch2, filePath);
        }
        private void LoadFile(string fileName)
        {
            RCH2Container c;
            Status = String.Format("Loading {0}...", fileName);
            try
            {
                c = FurcadiaInstaller.GetFileContainer(fileName);
                if (c == null)
                {
                    MessageBox.Show("Unable to load data - make sure it is a Furcadia installer!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            rch2 = c;
            txtDragDrop.Visible = false;
            txtInstallerName.Text = System.IO.Path.GetFileName(fileName);
            UpdateList();
            UpdateToolStrip(rch2 != null);
            Status = String.Format("Imported {0} files.", rch2.Count);
        }
        private void PromptExtractToFolder()
        {
            if (fbdTargetFolder.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                ExtractTo(fbdTargetFolder.SelectedPath);
        }
        private void ExtractAndOpen(string filePath)
        {
            // Find the file.
            RCH2File file = FindFileByPath(filePath);
            if (file == null)
            {
                MessageBox.Show("Cannot find specified path in the internal lists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            // Extract to temporary folder.
            string targetPath = FIB.GetTemporaryPath(System.IO.Path.GetFileName(FIB.ProcessPath(file.Filename)));

            try
            {
                file.Extract(targetPath);
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo.FileName = targetPath;
                proc.Start();
                FIB.DelSchedule(targetPath);
            }
            catch (Exception e)
            {
                MessageBox.Show("Cannot extract file: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CheckSelection()
        {
            // If the current cell wasn't selected, select only it since
            // that's where the menu was opened from.
            if (CurrentRow != null && !CurrentRow.Selected)
            {
                dgvInstallerList.ClearSelection();
                CurrentRow.Selected = true;
            }
        }
        private void ExtractTo(string path)
        {
            /*** Prepare parameters ***/
            List<string> selectedPaths = new List<string>();
            foreach (DataGridViewRow row in dgvInstallerList.SelectedRows)
                selectedPaths.Add((string)row.Cells[0].Value);

            List<RCH2File> selectedFiles = new List<RCH2File>(selectedPaths.Count);
            foreach (RCH2File file in rch2.Files)
                if (selectedPaths.Contains(file.Path))
                    selectedFiles.Add(file);

            /*** Pass to the extraction dialog ***/
            ExtractForm ef = new ExtractForm(ref selectedFiles, path);
            ef.ShowDialog();
        }

        /*** Methods - UI Updates ***/
        private void UpdateList()
        {
            if (rch2 == null) return;

            dgvInstallerList.SuspendLayout();
            dgvInstallerList.Rows.Clear();
            dgvInstallerList.Rows.Add(rch2.Count);
            for (int i = 0; i < rch2.Files.Count; i++)
            {
                RCH2File file = rch2.Files[i];
                dgvInstallerList.Rows[i].Cells[0].Value = file.Path;
                dgvInstallerList.Rows[i].Cells[1].Value = file.Size;
                dgvInstallerList.Rows[i].Cells[2].Value = String.Format("{0:x8}", file.CRCSum);
                dgvInstallerList.Rows[i].Cells[3].Value = "";
            }
            dgvInstallerList.ResumeLayout();
        }
        private void UpdateToolStrip(bool enabled)
        {
            btnCompareTo.Enabled = enabled;
            btnExtractAll.Enabled = enabled;
            btnReport.Enabled = enabled;
            btnCrcTest.Enabled = enabled;
        }
        private void UpdateCrcTest(Dictionary<string, bool> results)
        {
            foreach (DataGridViewRow row in dgvInstallerList.Rows)
            {
                bool passed;
                if (results.TryGetValue((string)row.Cells[0].Value, out passed))
                    SetCellCRC(row.Cells[3], passed);
            }
        }
        private void SetCellCRC(DataGridViewCell cell, bool passed)
        {
            cell.Style.BackColor = passed ? Color.Lime : Color.Red;
            cell.Value = passed ? "PASS" : "FAIL";
        }

        #region Event Handlers
        //--- "Open Installer" button clicked
        private void btnOpenInstaller_Click(object sender, EventArgs e)
        {
            // Open the file dialog.
            if (fdOpenInstaller.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                LoadFile(fdOpenInstaller.FileName);
        }

        // "Compare To..." button clicked.
        private void btnCompare_Click(object sender, EventArgs e)
        {
            RCH2Container rch2compare;
            // Get another installer from them.
            if (fdOpenInstaller.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;

            // Load the file.
            rch2compare = FurcadiaInstaller.GetFileContainer(fdOpenInstaller.FileName);
            if (rch2compare == null)
            {
                MessageBox.Show("Cannot load comparison file - make sure this is a Furcadia installer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Display comparison dialog.
            RCH2Compare cmp = new RCH2Compare(ref rch2, ref rch2compare);
            if (cmp.Identical)
            {
                MessageBox.Show("The two files have identical install packages.", "Identical Packages", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            CompareForm cf = new CompareForm(ref cmp);
            cf.FileName1 = txtInstallerName.Text;
            cf.FileName2 = fdOpenInstaller.SafeFileName;
            cf.ShowDialog();
        }

        //--- "CRC Test" button clicked
        private void btnCrcTest_Click(object sender, EventArgs e)
        {
            CrcTestForm ctf = new CrcTestForm(ref rch2);
            if (ctf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                UpdateCrcTest(ctf.Results);
                MessageBox.Show(String.Format("{0} out of {1} files passed validation!", ctf.Passed, ctf.Results.Count), "Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //--- "Extract All" button clicked
        private void btnExtractAll_Click(object sender, EventArgs e)
        {
            dgvInstallerList.SuspendLayout();
            dgvInstallerList.SelectAll();
            PromptExtractToFolder();
            dgvInstallerList.ClearSelection();
            dgvInstallerList.ResumeLayout();
        }

        //--- "Report..." button clicked.
        private void btnReport_Click(object sender, EventArgs e)
        {
            // Generate a report and send it to the report dialog
            string report = GenerateReport();
            ReportForm rf = new ReportForm(report);
            rf.ShowDialog();
        }

        //--- "Exit" button clicked.
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //--- Someone drags a file on top of the window.
        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            // We only support file drops.
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Copy : DragDropEffects.None;
        }

        //--- Someone dropped a file on our window.
        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] file_list = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            if (file_list.Length > 1)
            {
                MessageBox.Show("Please drag only one file into the window.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LoadFile(file_list[0]);
        }

        //--- A file within the installer file-list was double-clicked.
        private void dgvInstallerList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ExtractAndOpen((string)dgvInstallerList.Rows[e.RowIndex].Cells[0].Value);
        }

        //--- Main form successfully loaded.
        private void Form1_Load(object sender, EventArgs e)
        {
            Status = "Ready.";
        }

        //--- Program is about to close.
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Delete whatever we have left in the queue.
            FIB.EmptyDeleteQueue();
        }

        //--- List Context Menu: Before popping up
        private void cmFileListMenu_Opening(object sender, CancelEventArgs e)
        {
            CheckSelection();
        }

        //--- List Context Menu: "Open" option selected.
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExtractAndOpen((string)CurrentRow.Cells[0].Value);
        }

        //--- List Context Menu: "Extract" option selected.
        private void extractToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PromptExtractToFolder();
        }

        //--- List Context Menu: "Validate CRC32" option selected.
        private void validateCRC32ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckSelection();
            foreach (DataGridViewRow row in dgvInstallerList.SelectedRows)
            {
                RCH2File file = FindFileByPath((string)row.Cells[0].Value);
                if (file == null)
                {
                    MessageBox.Show("Unknown file: " + file.Path, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                SetCellCRC(row.Cells[3], file.CRCVerified);
            }
        }

        //--- When a mouse enters a new cell.
        private void dgvInstallerList_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            CurrentRow = (e.RowIndex >= 0) ? dgvInstallerList.Rows[e.RowIndex] : null;
        }
        #endregion
    }
}
