using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using LibRCH2;

namespace Furcadia_Installer_Browser
{
    public partial class CompareForm : Form
    {
        /*** Data Members ***/
        public RCH2Compare CompareInstance = null;
        public string FileName1 = "File 1";
        public string FileName2 = "File 2";

        private DataGridView dgvFile1 = null;
        private DataGridView dgvFile2 = null;

        private int extractCurrentFile;
        private int extractTotalFiles;
        private bool stopExtraction = false;


        /*** Static Functions ***/
        public DataGridView CreateDataGridView(string name)
        {
            // Generate the "Filename" column
            DataGridViewTextBoxColumn filename = new DataGridViewTextBoxColumn();
            filename.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            filename.HeaderText = "Filename";
            filename.MaxInputLength = 256;
            filename.MinimumWidth = 180;
            filename.Name = "Filename";
            filename.ReadOnly = true;

            // Generate the "Size" column
            DataGridViewTextBoxColumn size = new DataGridViewTextBoxColumn();
            size.HeaderText = "Size";
            size.Name = "Size";
            size.ReadOnly = true;
            size.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // Generate the DGV itself
            DataGridView dgv = new DataGridView();

            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            filename,
            size});
            dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            dgv.Name = name;
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgv.Size = new System.Drawing.Size(330, 386);

            // Don't forget: this.grpFile1.Controls.Add(this.dataGridView1);
            return dgv;
        }

        /*** Constructor ***/
        public CompareForm(ref RCH2Compare compareInstance)
        {
            CompareInstance = compareInstance;

            InitializeComponent();

            // Generate two DGVs for the areas.
            dgvFile1 = CreateDataGridView("dgvFile1");
            dgvFile2 = CreateDataGridView("dgvFile2");
            splitContainer.Panel1.Controls.Add(dgvFile1);
            splitContainer.Panel2.Controls.Add(dgvFile2);

            // Populate DGVs.
            PopulateLists();
        }

        private void PopulateLists()
        {
            // Get the amount of rows we should add in each panel.
            int f1_rows = (cbShowIdentical.Checked ? CompareInstance.IdenticalFiles.Count : 0) +
                (cbDifferent.Checked ? CompareInstance.File1.DifferentFiles.Count : 0) +
                (cbUnique.Checked ? CompareInstance.File1.UniqueFiles.Count : 0);

            int f2_rows = (cbShowIdentical.Checked ? CompareInstance.IdenticalFiles.Count : 0) +
                (cbDifferent.Checked ? CompareInstance.File2.DifferentFiles.Count : 0) +
                (cbUnique.Checked ? CompareInstance.File2.UniqueFiles.Count : 0);

            // Suspend layout for the lists and initialize the lists.
            dgvFile1.SuspendLayout();
            dgvFile1.Rows.Clear();
            if (f1_rows > 0)
                dgvFile1.Rows.Add(f1_rows);

            dgvFile2.SuspendLayout();
            dgvFile2.Rows.Clear();
            if (f2_rows > 0)
                dgvFile2.Rows.Add(f2_rows);

            // Push identical files onto the list if needed.
            int i = 0;
            if (cbShowIdentical.Checked)
            {
                foreach (RCH2File file in CompareInstance.IdenticalFiles)
                {
                    dgvFile1.Rows[i].Cells[0].Value = file.Path;
                    dgvFile1.Rows[i].Cells[1].Value = file.Size;

                    dgvFile2.Rows[i].Cells[0].Value = file.Path;
                    dgvFile2.Rows[i].Cells[1].Value = file.Size;

                    i++;
                }
            }

            // Push different files onto File1 and File2 lists
            int j = i;
            if (cbDifferent.Checked)
            {
                foreach (RCH2File file in CompareInstance.File1.DifferentFiles)
                {
                    dgvFile1.Rows[i].Cells[0].Value = file.Path;
                    dgvFile1.Rows[i].Cells[0].Style.BackColor = cbDifferent.BackColor;

                    dgvFile1.Rows[i].Cells[1].Value = file.Size;
                    dgvFile1.Rows[i].Cells[1].Style.BackColor = cbDifferent.BackColor;

                    i++;
                }

                foreach (RCH2File file in CompareInstance.File2.DifferentFiles)
                {
                    dgvFile2.Rows[j].Cells[0].Value = file.Path;
                    dgvFile2.Rows[j].Cells[0].Style.BackColor = cbDifferent.BackColor;

                    dgvFile2.Rows[j].Cells[1].Value = file.Size;
                    dgvFile2.Rows[j].Cells[1].Style.BackColor = cbDifferent.BackColor;

                    j++;
                }
            }

            // Push unique files onto File1 and File2 lists
            if (cbUnique.Checked)
            {
                foreach (RCH2File file in CompareInstance.File1.UniqueFiles)
                {
                    dgvFile1.Rows[i].Cells[0].Value = file.Path;
                    dgvFile1.Rows[i].Cells[0].Style.BackColor = cbUnique.BackColor;

                    dgvFile1.Rows[i].Cells[1].Value = file.Size;
                    dgvFile1.Rows[i].Cells[1].Style.BackColor = cbUnique.BackColor;

                    i++;
                }

                foreach (RCH2File file in CompareInstance.File2.UniqueFiles)
                {
                    dgvFile2.Rows[j].Cells[0].Value = file.Path;
                    dgvFile2.Rows[j].Cells[0].Style.BackColor = cbUnique.BackColor;

                    dgvFile2.Rows[j].Cells[1].Value = file.Size;
                    dgvFile2.Rows[j].Cells[1].Style.BackColor = cbUnique.BackColor;

                    j++;
                }
            }

            // Resume layout for the lists.
            dgvFile1.ResumeLayout();
            dgvFile2.ResumeLayout();
        }
        private string GenerateReport()
        {
            StringBuilder buffer = new StringBuilder();
            buffer.AppendLine(String.Format("--- Installer Comparison: {0} --> {1}", FileName1, FileName2));

            // Store identical filenames if necessary.
            if (cbShowIdentical.Checked)
            {
                buffer.AppendLine("= Identical files");
                foreach (RCH2File file in CompareInstance.IdenticalFiles)
                    buffer.AppendLine(String.Format("{0,8:x} [{1,8}] {2}", file.CRCSum, file.Size, file.Path));
                buffer.AppendLine();
            }

            // Store different filenames if necessary.
            if (cbDifferent.Checked)
            {
                buffer.AppendLine("= Different files");
                foreach (RCH2File file in CompareInstance.File1.DifferentFiles)
                {
                    RCH2File file2 = FIB.FindFileByPath(CompareInstance.File2.Container, file.Path);
                    buffer.AppendLine(file.Path);
                    buffer.AppendLine(String.Format("   - CRC32: {0,8:x} --> {1,8:x}", file.CRCSum, file2.CRCSum));
                    buffer.AppendLine(String.Format("   - Size:  {0,8} --> {1,8}", file.Size, file2.Size));
                }
                buffer.AppendLine();
            }

            // Store unique filenames if necessary.
            if (cbUnique.Checked)
            {
                buffer.AppendLine("= Unique files");
                foreach (RCH2File file in CompareInstance.File1.UniqueFiles)
                    buffer.AppendLine("- " + file.Path);
                foreach (RCH2File file in CompareInstance.File2.UniqueFiles)
                    buffer.AppendLine("+ " + file.Path);
            }

            return buffer.ToString();
        }

        //--- One of the display checkboxes clicked.
        private void ShowCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            // If at least one checkbox ends up being checked, refresh the lists.
            if (cbUnique.Checked || cbDifferent.Checked || cbShowIdentical.Checked)
                PopulateLists();
        }

        //--- "Report" button clicked.
        private void btnReport_Click(object sender, EventArgs e)
        {
            ReportForm rf = new ReportForm(GenerateReport());
            rf.ShowDialog();
        }

        private void btnExtract_Click(object sender, EventArgs e)
        {
            // Get the target folder path.
            if (folderBrowser.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;

            progress.Visible = true;
            stopExtraction = false;
            updateTimer.Start();
            bgw.RunWorkerAsync(folderBrowser.SelectedPath);
        }

        private void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            updateTimer.Stop();
            progress.Visible = false;

            if (e.Cancelled)
                this.Close();
        }

        private void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = sender as BackgroundWorker;
            bool showIdentical = cbShowIdentical.Checked;
            bool showDifferent = cbDifferent.Checked;
            bool showUnique = cbUnique.Checked;
            string targetPath = (string)e.Argument;

            extractCurrentFile = 0;
            extractTotalFiles =
                (showIdentical ? CompareInstance.IdenticalFiles.Count : 0) +
                (showDifferent ? CompareInstance.File1.DifferentFiles.Count + CompareInstance.File2.DifferentFiles.Count : 0) +
                (showUnique ? CompareInstance.File1.UniqueFiles.Count + CompareInstance.File2.UniqueFiles.Count : 0);

            // Create File1 and File2 folders.
            string file1path = targetPath + Path.DirectorySeparatorChar + FileName1;
            string file2path = targetPath + Path.DirectorySeparatorChar + FileName2;

            Directory.CreateDirectory(file1path);
            Directory.CreateDirectory(file2path);

            // Extract the files mentioned.
            if (showIdentical)
            {
                foreach (RCH2File file in CompareInstance.IdenticalFiles)
                {
                    string processedPath = FIB.ProcessPath(file.Path);
                    string file1full = file1path + Path.DirectorySeparatorChar + processedPath;
                    string file2full = file2path + Path.DirectorySeparatorChar + processedPath;
                    Directory.CreateDirectory(Path.GetDirectoryName(file1full));
                    Directory.CreateDirectory(Path.GetDirectoryName(file2full));

                    file.Extract(file1full);
                    File.Copy(file1full, file2full, true);
                    extractCurrentFile++;

                    if (bw.CancellationPending) goto bgwCancel;
                }
            }

            if (showDifferent)
            {
                foreach (RCH2File file in CompareInstance.File1.DifferentFiles)
                {
                    RCH2File file2 = FIB.FindFileByPath(CompareInstance.File2.Container, file.Path);
                    string processedPath = FIB.ProcessPath(file.Path);
                    string file1full = file1path + Path.DirectorySeparatorChar + processedPath;
                    string file2full = file2path + Path.DirectorySeparatorChar + processedPath;
                    Directory.CreateDirectory(Path.GetDirectoryName(file1full));
                    Directory.CreateDirectory(Path.GetDirectoryName(file2full));

                    file.Extract(file1full);
                    file2.Extract(file2full);
                    extractCurrentFile += 2;

                    if (bw.CancellationPending) goto bgwCancel;
                }
            }

            if (showUnique)
            {
                bool flag = true;
                foreach (List<RCH2File> list in new List<RCH2File>[] { CompareInstance.File1.UniqueFiles, CompareInstance.File2.UniqueFiles })
                {
                    foreach (RCH2File file in list)
                    {
                        string full = (flag ? file1path : file2path) + Path.DirectorySeparatorChar + FIB.ProcessPath(file.Path);
                        Directory.CreateDirectory(Path.GetDirectoryName(full));
                        file.Extract(full);
                        extractCurrentFile++;

                        if (bw.CancellationPending) goto bgwCancel;
                    }
                    flag = false;
                }
            }

            return;

        bgwCancel:
            e.Cancel = true;
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            progress.Value = extractCurrentFile * 100 / extractTotalFiles;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (!bgw.IsBusy)
                this.Close();
            else if (MessageBox.Show("File extraction still running. Do you want to abort?", "Abort?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                bgw.CancelAsync();
        }
    }
}
