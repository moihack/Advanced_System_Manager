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
    internal partial class StartupProgramsManager : UserControl
    {
        internal static bool controlLoaded = false;

        internal StartupProgramsManager()
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
            //check if it's the first time the control loads for the current session of the program
            //there is an issue with .NET that checks and unchecks all items accordingly to their default values
            //this fires up the associated events without input from the user

            if (controlLoaded) //hack
            {
                if(e.Item.Checked)
                {
                    RegistryParser.EnableKeyStartup(PackageManager.startupProgramsList[e.Item.Index]);
                }
                else
                {
                    RegistryParser.DisableKeyStartup(PackageManager.startupProgramsList[e.Item.Index]);
                }
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            RegistryParser.CreateStartupReg();
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
            foreach (StartupItem si in PackageManager.startupProgramsList)
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
        }
    }
}
