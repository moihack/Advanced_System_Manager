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
    public partial class ToolsUserControl : UserControl
    {
        public ToolsUserControl()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("test with user controls");
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
    }
}
