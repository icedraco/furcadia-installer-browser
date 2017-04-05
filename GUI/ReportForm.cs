using System;
using System.Windows.Forms;
using System.IO;

namespace Furcadia_Installer_Browser
{
    public partial class ReportForm : Form
    {
        public ReportForm(string reportText)
        {
            InitializeComponent();
            tbReport.MaxLength = reportText.Length + 8192;
            tbReport.Text = reportText;
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write)))
                {
                    try
                    {
                        sw.Write(tbReport.Text);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Could not write: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
