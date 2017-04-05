using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using LibRCH2;

namespace Furcadia_Installer_Browser
{
    public partial class ExtractForm : Form
    {
        /*** Members ***/
        private string targetPath;
        private List<RCH2File> files;
        private RCH2File currentFile = null;
        private string currentPath = "";
        private int filesCompleted = 0;

        /*** Constructor ***/
        public ExtractForm(ref List<RCH2File> files, string path)
        {
            InitializeComponent();

            this.files = files;
            targetPath = path;

            BeginExtract();
        }

        private void BeginExtract()
        {
            updateTimer.Start();
            bgw.RunWorkerAsync();
        }

        private void UpdateContents()
        {
            if (currentFile != null)
            {
                txtFile.Text = currentFile.Filename;
                txtTargetPath.Text = currentPath;
                progress.Value = filesCompleted * 100 / files.Count;
            }
        }

        #region Event Handlers
        private void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < files.Count; i++)
            {
                currentFile = files[i];
                currentPath = targetPath + System.IO.Path.DirectorySeparatorChar + FIB.ProcessPath(currentFile.Path);
                string target_dir = System.IO.Path.GetDirectoryName(currentPath);

                try
                {
                    if (!System.IO.Directory.Exists(target_dir))
                        System.IO.Directory.CreateDirectory(target_dir);
                    currentFile.Extract(currentPath);
                    filesCompleted++;
                }
                catch (Exception ex)
                {
                    DialogResult result = MessageBox.Show(String.Format("Cannot extract file '{0}': {1}", currentFile.Filename, ex.Message), "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    if (result == System.Windows.Forms.DialogResult.Cancel)
                    {
                        this.DialogResult = DialogResult.Cancel;
                        return;
                    }
                    else
                        i--;
                }
            }

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            UpdateContents();
        }

        private void ExtractForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            updateTimer.Stop();
        }
        #endregion
    }
}
