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
            MarkForRemoval();
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
        {/*
            /*foreach (ListViewItem item in listView1.Items)
            {             
                if (item.Checked)
                {
                    String rem = item.SubItems[0].Text;
                    //Console.WriteLine(rem); 
                    PackageManager.installedProgramsList.Find(rem);
                }
            } 

            for (int i = 0; i < listView1.Items.Count; i++)
            {
                /////////HAZARD ALERT IF UNCOMMENTED PackageManager.CheckUninstallationMethod(PackageManager.installedProgramsList[i]);
                //Console.WriteLine(PackageManager.installedProgramsList[i].UninstallString);
                if (listView1.Items[i].Checked)
                {
                    PackageManager.CheckUninstallationMethod(PackageManager.installedProgramsList[i]);
                }

            }
            //MessageBox.Show("Done!!!!");
            //PackageManager.removeMPC();
            */
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
