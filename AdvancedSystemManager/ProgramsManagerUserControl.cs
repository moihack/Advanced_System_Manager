﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace AdvancedSystemManager
{
    internal partial class ProgramsManagerUserControl : UserControl
    {
        internal ProgramsManagerUserControl()
        {
            InitializeComponent();
        }

        private void ServiceManagerUserControl_Load(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        internal void MarkForRemoval()
        { 
            listView1.Items.Clear();

            foreach (Package pack in PackageManager.installedProgramsList)
            {
                ListViewItem newListViewItem = new ListViewItem();

                newListViewItem.Text = pack.PackageName;
                newListViewItem.SubItems.Add(pack.Publisher);
                newListViewItem.SubItems.Add(pack.EstimatedSizeInKB.ToString());
                newListViewItem.SubItems.Add(pack.DisplayVersion);

                if (pack.IsSafeToRemove)
                {
                    newListViewItem.Checked = true;
                }

                listView1.Items.Add(newListViewItem);
            }
        }

        internal void MarkAll()
        {
            foreach (ListViewItem item in listView1.Items)
            {
                item.Checked = true;
            }
        }

        internal void MarkNone()
        {
            foreach (ListViewItem item in listView1.Items)
            {
                item.Checked = false;
            }
        }

        internal void SaveList()
        {
            foreach (ListViewItem item in listView1.Items)
            {
                MyLogger.WriteProgramList(item.SubItems[0].Text);
            }
        }

        private void svBtn_Click(object sender, EventArgs e)
        {
            SaveList();
            MessageBox.Show("Programs list saved to programs.txt");
        }

        private void defBtn_Click(object sender, EventArgs e)
        {
            MarkForRemoval();
        }

        private void allBtn_Click(object sender, EventArgs e)
        {
            MarkAll();
        }

        private void noBtn_Click(object sender, EventArgs e)
        {
            MarkNone();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            PackageManager.GetAllProgramsList();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MarkForRemoval();
        }
    }
}
