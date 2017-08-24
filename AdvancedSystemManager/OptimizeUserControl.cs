using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace AdvancedSystemManager
{
    public partial class OptimizeUserControl : UserControl
    {
        public OptimizeUserControl()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void allBtn_Click(object sender, EventArgs e)
        {
            programsManagerUserControl1.MarkAll();
        }

        private void noBtn_Click(object sender, EventArgs e)
        {
            programsManagerUserControl1.MarkNone();
        }

        private void defBtn_Click(object sender, EventArgs e)
        {
            programsManagerUserControl1.MarkForRemoval();
        }

        private void svBtn_Click(object sender, EventArgs e)
        {
            programsManagerUserControl1.SaveList();
        }

        private void opBtn_Click(object sender, EventArgs e)
        {
            //cast is required - parent1=tab page,parent2=tab control,parent3=Form1
            //Form myParent = (Form)this.Parent.Parent.Parent;
            TabControl myParent = (TabControl)this.Parent.Parent; // disable the tab controls so we can mimimize and close!
            Console.WriteLine(myParent.Name);
            //myParent.Enabled = false; //disable the UI
            //textBox1.Text = "test after";


            for (int i = 0; i < programsManagerUserControl1.listView1.Items.Count; i++)
            {
                //Console.WriteLine(PackageManager.installedProgramsList[i].PackageName);
                
             //   Console.WriteLine(" h loupa2 einai sto i: ", i);
                if (programsManagerUserControl1.listView1.Items[i].Checked)
                {
                   Console.WriteLine(PackageManager.installedProgramsList[i].PackageName);
                    PackageManager.installedProgramsList[i].ToRemove = true;
                   /* if(!backgroundWorker1.IsBusy)
                    {
                        backgroundWorker1.RunWorkerAsync(i);
                    }
                    else
                    {
                       // i = i - 1;
                    } */
                                        
                //    Console.WriteLine(PackageManager.installedProgramsList[i].PackageName);
                  //  Console.WriteLine(" h loupa einai sto i: ", i);
                }
                else
                {
                    //workaround for markfromtext
                    PackageManager.installedProgramsList[i].ToRemove = false;
                }
            }

            backgroundWorker1.RunWorkerAsync();
            

            //Form myParent2 = (Form)this.Parent.Parent.Parent;
            //Console.WriteLine(myParent2.Name);
            // myParent2.
            //
            // BackgroundWorker1.
            
        }

        public static void ManagePrograms()
        {
            //console write line does not help much here
            // we avoid accessing controls of the ui thread
            //Console.WriteLine(PackageManager.installedProgramsList[5].PackageName);
            for (int i = 0; i < PackageManager.installedProgramsList.Count; i++)
            {
                if(PackageManager.installedProgramsList[i].ToRemove)
                {
                    MyLogger.WriteLog("package is :" + PackageManager.installedProgramsList[i].PackageName + " " + i);
                    PackageManager.CheckUninstallationMethod(PackageManager.installedProgramsList[i]);                   
                    //MyLogger.WriteLog(i);
                }                
            }

            //if sth true call
            if(PackageManager.doUnattendedInstall)
            {
             //   PackageManager.UnattendedInstall();
            }                           

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
          //  int val = (int) e.Argument;
          //  Console.WriteLine("background : " , val);
            ManagePrograms();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        { /*
            RegistryParser.GetPrograms();
            RegistryParser.GetPrograms2();
            RegistryParser.GetWin64Programs();
            PackageManager.DuplicatesFinder();
            PackageManager.ShowNormal(); */
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void programsManagerUserControl1_Load(object sender, EventArgs e)
        {
            //backgroundWorker2.RunWorkerAsync();
        }

        private void backgroundWorker2_DoWork_1(object sender, DoWorkEventArgs e)
        {

        }

        private void tweaksUserControl1_Load(object sender, EventArgs e)
        {

        }
    }
}
