using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace AdvancedSystemManager
{
    internal partial class ToolsUserControl : UserControl
    {
        internal ToolsUserControl()
        {
            InitializeComponent();
        }

        private void ToolsUserControl_Load(object sender, EventArgs e)
        {

        }

        private void cmpLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("cmd.exe");
        }

        private void cmpMgmtLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("compmgmt.msc");
        }

        private void tskMgrLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("taskmgr.exe");
        }

        private void diskMgmtLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("diskmgmt.msc");
        }

        private void programsLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("appwiz.cpl");
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void openFileBtn_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Choose a file for integrity check";
            openFileDialog1.FileName = "";

            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) 
            {
                pathTB.Text = openFileDialog1.FileName;

                md5TB.Text = "Calculating MD5...";
                sha1TB.Text = "Calculating SHA-1...";

                backgroundWorker1.RunWorkerAsync(pathTB.Text);
            } 
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string filename = (string) e.Argument;

            string md5Res = IntegrityChecker.MD5Check(filename);
            string sha1Res = IntegrityChecker.SHA1Check(filename);

            List<String> checksumResults = new List<string>(2);
            checksumResults.Add(md5Res);
            checksumResults.Add(sha1Res);
            e.Result = checksumResults;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            List<String> checksumResults = (List<string>) e.Result;
            md5TB.Text = "MD5: " + checksumResults[0];
            sha1TB.Text = "SHA-1: " + checksumResults[1];

        }

        private void SysInfoLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("msinfo32");
        }

        private void msconfigLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("msconfig");
        }

        private void dxLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("dxdiag");
        }

        private void devMgmtLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("devmgmt.msc");
        }

        private void servMgmtLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("services.msc");
        }
    }
}
