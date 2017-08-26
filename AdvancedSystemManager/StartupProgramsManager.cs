using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Management;

namespace AdvancedSystemManager
{
    public partial class StartupProgramsManager : UserControl
    {
        public static bool controlLoaded = false;

        public StartupProgramsManager()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void StartupProgramsManager_Load(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
          
        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (controlLoaded)
            {
                if(e.Item.Checked)
                {
                    //Console.WriteLine("i checked this");

                    //bres to location k pane grapse ekei
                    // sbhsto apo to startupreg

                    RegistryParser.EnableKeyStartup(PackageManager.startupPrograms[e.Item.Index]);

                }
                else
                {
                    //Console.WriteLine("i un-checked this");
                    //grafto sto startupreg
                    //sbhsto apo to location tou

                    RegistryParser.DisableKeyStartup(PackageManager.startupPrograms[e.Item.Index]);

                }
            }
        }

        private void listView1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            
        }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            
        }

        private void listView1_Validated(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            RegistryParser.GetStartupPrograms();
            RegistryParser.GetDisabledStartupPrograms();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FillListView();
        }

        private void FillListView()
        {
            foreach (StartupItem si in PackageManager.startupPrograms)
            {
                ListViewItem newListViewItem = new ListViewItem();

                newListViewItem.Text = si.Name;
                newListViewItem.SubItems.Add(si.Command);
                newListViewItem.SubItems.Add(si.Location);
                if (si.IsEnabled)
                {
                    newListViewItem.Checked = true;
                }

                listView1.Items.Add(newListViewItem);
            }

            controlLoaded = true;
            Console.WriteLine("let's start");
        }

    }
}
