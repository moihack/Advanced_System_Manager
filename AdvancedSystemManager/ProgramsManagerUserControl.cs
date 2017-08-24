using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace AdvancedSystemManager
{
    public partial class ProgramsManagerUserControl : UserControl
    {
        public ProgramsManagerUserControl()
        {
            InitializeComponent();
        }

        private void ServiceManagerUserControl_Load(object sender, EventArgs e)
        {
            //Console.WriteLine("test");
            //MarkForRemoval();
            backgroundWorker1.RunWorkerAsync();
        }

        public void MarkForRemoval()
        { /*
            foreach (ListViewItem item in listView1.Items)
            {
                String rem = item.SubItems[0].Text;
                //Console.WriteLine(rem);
                if (rem.Contains("qB"))
                {
                    item.Checked = true;
                }
                else
                {
                    //to re-mark default removal suggestions only!
                    item.Checked = false;
                }
            } */

            listView1.Items.Clear();
            foreach (Package pack in PackageManager.installedProgramsList)
            {
                // Console.WriteLine("test1");
                ListViewItem newListViewItem = new ListViewItem();

                newListViewItem.Text = pack.PackageName;
                newListViewItem.SubItems.Add(pack.Publisher);
                newListViewItem.SubItems.Add(pack.EstimatedSizeInKB.ToString());

                //newListViewItem.SubItems.Add(ser.StartType.ToString());
                //newListViewItem.SubItems.Add(newComboBoxItem);

                //Console.WriteLine(ser.ServiceName);

                // RegistryKey regKey1 = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\services\\" + service.ServiceName);
                //  newListViewItem.SubItems.Add(ser.
                //  newListViewItem.SubItems.Add(regKey1.GetValue("Description").ToString());
                if (pack.isSafeToRemove)
                {
                    newListViewItem.Checked = true;
                }

                listView1.Items.Add(newListViewItem);
            }

        }

        public void MarkAll()
        {
            foreach (ListViewItem item in listView1.Items)
            {
                item.Checked = true;
            }
        }

        public void MarkNone()
        {
            foreach (ListViewItem item in listView1.Items)
            {
                item.Checked = false;
            }
        }

        public void SaveList()
        {
            foreach (ListViewItem item in listView1.Items)
            {
                MyLogger.WriteProgramList(item.SubItems[0].Text);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

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
            //   RegistryParser.GetPrograms();
            //  RegistryParser.GetPrograms2();

            /*   RegistryParser.GetWin64Programs();
               RegistryParser.GetPrograms();
               RegistryParser.GetPrograms2();

               //PackageManager.DuplicatesFinder();
               //PackageManager.ShowNormal();

               PackageManager.ShowNormal();

               PackageManager.DuplicatesFinder();

               PackageManager.SortPackages(); */

            PackageManager.GetAllProgramsList();
          
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MarkForRemoval();
        }

        private void possibleEqual()
        {
            RegistryParser.GetWin64Programs();
            RegistryParser.GetPrograms();
            //   RegistryParser.GetPrograms2();

            //PackageManager.DuplicatesFinder();
            //PackageManager.ShowNormal();

            PackageManager.DuplicatesFinder();

            PackageManager.SortPackages();
            PackageManager.ShowNormal();
        }

    }
}
