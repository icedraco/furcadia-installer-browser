using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using LibRCH2;

namespace Furcadia_Installer_Browser
{
    public partial class CrcTestForm : Form
    {
        /*** Data Members ***/
        public Dictionary<string, bool> Results = new Dictionary<string, bool>();
        RCH2Container rch2;
        int nPassed = 0;

        /*** Properties ***/
        public int Passed { get { return nPassed; } }
        private string Status { get { return txtStatus.Text; } set { txtStatus.Text = value; } }


        /*** Constructor ***/
        public CrcTestForm(ref RCH2Container rch2)
        {
            InitializeComponent();
            this.rch2 = rch2;
            backgroundWorker1.RunWorkerAsync();
            timer.Start();
        }

        private void UpdateDisplay()
        {
            progress.Value = Results.Count * 100 / rch2.Count;
            Status = String.Format("{0} / {1}", Results.Count + 1, rch2.Count);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < rch2.Files.Count; i++)
            {
                RCH2File file = rch2.Files[i];
                if ((Results[file.Path] = file.CRCVerified) == true)
                    nPassed++;
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            // Update the currently processed file.
            UpdateDisplay();
        }
    }
}
