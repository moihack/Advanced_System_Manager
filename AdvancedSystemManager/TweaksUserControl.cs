using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace AdvancedSystemManager
{
    public partial class TweaksUserControl : UserControl
    {
        static bool doDiskCleanup = false;
        static bool doFirefoxReset = false;
        static bool doChromeReset = false;
        static bool doVisualEffects = false;
        static bool doUnattended = false;
        static bool doMassiveUninstall = false;
        static bool doCPUState = false;

        static int c = 0;
        static int currentProgress = 0;
        static int maxProgress = 100;
        static float prog;

      //  static bool currentlyUninstalling = false;
     //   static bool currentlyInstalling = false;

        public TweaksUserControl()
        {
            InitializeComponent();
        }

        private void optimizeBtn_Click(object sender, EventArgs e)
        {
            //for each checkbox
            //check ti 8a treksei k ti oxi
            // 8a kanw ena pinaka gia na pernaw sto background worker gia na kserei ti 8a treksei???
            // dn xreiazetai toso pia afou exw ta static mou

            SplitContainer mySplitContair = (SplitContainer)this.Parent.Parent; //first parent is split panel
            Console.WriteLine(mySplitContair.Name);

            SplitterPanel myProgramsSplitterPanel = (SplitterPanel)mySplitContair.Panel1;
            Console.WriteLine(myProgramsSplitterPanel.AccessibleName);

            ProgramsManagerUserControl myProgramsManager = (ProgramsManagerUserControl)myProgramsSplitterPanel.Controls["programsManagerUserControl1"];
            //myProgramsManager.MarkAll();
            //myProgramsManager.backgroundWorker1.RunWorkerAsync();

            //doCPUState = true;
            CalculateProgressBarMaxValue();

            //des an exei kt tick 8eloume doMassiveUninstall = true;
            for (int i = 0; i < myProgramsManager.listView1.Items.Count; i++)
            {
                //Console.WriteLine(PackageManager.installedProgramsList[i].PackageName);

                //   Console.WriteLine(" h loupa2 einai sto i: ", i);
                if (myProgramsManager.listView1.Items[i].Checked)
                {
                    Console.WriteLine(PackageManager.installedProgramsList[i].PackageName);
                    PackageManager.installedProgramsList[i].ToRemove = true;
                    doMassiveUninstall = true;
                    c += 1;
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

            prog = (1.0f / c * maxProgress);
            Console.WriteLine("prog is: " + prog);
            Console.WriteLine("jobs are: " + c);
            //   progressBar1.Step = 1;
            //   progressBar1.Minimum = 0;
            //   progressBar1.Maximum = c;

            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            /*  Console.WriteLine(doCPUState);
              backgroundWorker1.ReportProgress(50);
              Console.WriteLine(doVisualEffects);
              backgroundWorker1.ReportProgress(80); */
            try
            {
                if (doCPUState)
                {
                    backgroundWorker1.ReportProgress(currentProgress, "Setting CPU Full State");
                   // System.Threading.Thread.Sleep(3000);
                    Console.WriteLine("mpainw edw: cpu");
                    //RegistryParser.GetVolumeCaches();
                    CPUPower.SetCPUStates();

                    //currentProgress += (1 / c * maxProgress);
                    currentProgress += Convert.ToInt32(prog);
                    // Console.WriteLine(test);
                    // Console.WriteLine("c inside the worker " + c);

                    //  backgroundWorker1.ReportProgress(1 / c * progressBar1.Maximum);
                    backgroundWorker1.ReportProgress(currentProgress);
                  //  System.Threading.Thread.Sleep(3000);
                }

                if (doVisualEffects)
                {
                    backgroundWorker1.ReportProgress(currentProgress, "Applying Visual Effects Settings");
                    //System.Threading.Thread.Sleep(3000);
                    Console.WriteLine("mpainw edw: visual ");
                    //RegistryParser.GetVolumeCaches();
                    VisualEffects.ApplySettings();
                    RegistryParser.ApplyVisualEffects();
                    //Console.WriteLine("cu " + currentProgress);
                    currentProgress += Convert.ToInt32(prog);
                    // backgroundWorker1.ReportProgress(2 / c * progressBar1.Maximum);
                    backgroundWorker1.ReportProgress(currentProgress);
                }

                if (doFirefoxReset)
                {
                    backgroundWorker1.ReportProgress(currentProgress, "Cleaning Firefox Profile");
                    Console.WriteLine("mpainw edw: ff");
                    // RegistryParser.GetVolumeCaches();
                    currentProgress += Convert.ToInt32(prog);
                    // backgroundWorker1.ReportProgress(3 / c * progressBar1.Maximum);
                    backgroundWorker1.ReportProgress(currentProgress);
                }

                if (doChromeReset)
                {
                    backgroundWorker1.ReportProgress(currentProgress, "Cleaning Google Chrome Profile");
                    Console.WriteLine("mpainw edw: chrome ");
                    //RegistryParser.GetVolumeCaches();
                    currentProgress += Convert.ToInt32(prog);
                    // backgroundWorker1.ReportProgress(3 / c * progressBar1.Maximum);
                    backgroundWorker1.ReportProgress(currentProgress);
                }

                if (doMassiveUninstall)
                {
                    Console.WriteLine("mpainw edw: massive uninstall ");
                    ManagePrograms();
                    //backgroundWorker2.RunWorkerAsync();
                    currentProgress += Convert.ToInt32(prog);
                    // backgroundWorker1.ReportProgress(3 / c * progressBar1.Maximum);
                    backgroundWorker1.ReportProgress(currentProgress);
                }

                if (doUnattended)
                {
                    Console.WriteLine("mpainw edw: unattended ");
                    //string progName="";
                    //PackageManager.UnattendedInstall(out string progName);
                    UnattendedInstall();
                    currentProgress += Convert.ToInt32(prog);
                    // backgroundWorker1.ReportProgress(3 / c * progressBar1.Maximum);
                    backgroundWorker1.ReportProgress(currentProgress);
                }

                if (doDiskCleanup)
                {
                    backgroundWorker1.ReportProgress(currentProgress, "Performing Disk Cleanup");
                    Console.WriteLine("mpainw edw: diskcc ");
                    RegistryParser.GetVolumeCaches();
                    currentProgress += Convert.ToInt32(prog);
                    //backgroundWorker1.ReportProgress(7 / c * progressBar1.Maximum);
                    backgroundWorker1.ReportProgress(currentProgress);
                }
            }
            catch (Exception ex)
            {
                MyLogger.WriteLog(ex.Message.ToString());
            }

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
           // System.Threading.Thread.Sleep(3000);
            if (progressBar1.Value <= progressBar1.Maximum)
             {
                 //   int test = progressBar1.Value;
                 //    Console.WriteLine(test);
                 //  test += e.ProgressPercentage;               
                 //  if(test <= 100)
                 //   {
                 if (e.ProgressPercentage <= 100)
                 {
                     progressBar1.Value = e.ProgressPercentage;
                    
                 }

                 //   }
             }
            else { Console.WriteLine("dn mphka"); }
            //Console.WriteLine("outside: " + currentProgress);
            //progressLbl.Text = e.ProgressPercentage.ToString();

            /*  try
              {
                  int iRes = (int)e.UserState;
                  progressLbl.Text = "Currently uninstalling: " + PackageManager.installedProgramsList[iRes].PackageName;
              }
              catch(Exception ex)
              {
                  Console.WriteLine(ex.Message.ToString());
              }*/
            //progressBar1.PerformStep();
            string Res = (string)e.UserState;
            progressLbl.Text = Res;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Value = 100;
            progressLbl.Text = "Finished! You can now close this window";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void CalculateProgressBarMaxValue()
        {
            //c = 0; //c == how many jobs the background worker will perform

            if (doDiskCleanup) { c += 1; }
            if (doFirefoxReset) { c += 1; }
            if (doChromeReset) { c += 1; }
            if (doVisualEffects) { c += 1; }
            if (doUnattended) { c += 1; }
            if (doCPUState) { c += 1; }
            if (doMassiveUninstall) { c += 1; }

            //  progressBar1.Maximum = progressBar1.Maximum * c;

            if (doUnattended)
            {
                c += 1;
                try
                {
                    //Directory.EnumerateFiles is not available in .NET 2.0
                    string[] files = Directory.GetFiles(Application.StartupPath + @"\apps_deploy");
                    //string[] files = Directory.GetFiles(@"C:\Windows", "*.dmp");

                    c += files.Length;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                }
            }

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (doVisualEffects)
            {
                doVisualEffects = false;
            }
            else
            {
                doVisualEffects = true;
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (doCPUState)
            {
                doCPUState = false;
            }
            else
            {
                doCPUState = true;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (doUnattended)
            {
                doUnattended = false;
            }
            else
            {
                doUnattended = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (doDiskCleanup)
            {
                doDiskCleanup = false;
            }
            else
            {
                doDiskCleanup = true;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (doFirefoxReset)
            {
                doFirefoxReset = false;
            }
            else
            {
                doFirefoxReset = true;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (doChromeReset)
            {
                doChromeReset = false;
            }
            else
            {
                doChromeReset = true;
            }
        }

        public void ManagePrograms()
        {
            //console write line does not help much here
            // we avoid accessing controls of the ui thread
            //Console.WriteLine(PackageManager.installedProgramsList[5].PackageName);
            for (int i = 0; i < PackageManager.installedProgramsList.Count; i++)
            {
                if (PackageManager.installedProgramsList[i].ToRemove)
                {
                    MyLogger.WriteLog("package is :" + PackageManager.installedProgramsList[i].PackageName + " " + i);
                    backgroundWorker1.ReportProgress(currentProgress, "Currently Uninstalling: " + PackageManager.installedProgramsList[i].PackageName);
                    PackageManager.CheckUninstallationMethod(PackageManager.installedProgramsList[i]);
                    currentProgress += Convert.ToInt32(prog);
                    backgroundWorker1.ReportProgress(currentProgress);
                    //Console.WriteLine(currentProgress);
                    //backgroundWorker1.ReportProgress(currentProgress, "Currently Uninstalling: " + PackageManager.installedProgramsList[i].PackageName);
                    //MyLogger.WriteLog(i);
                }
            }

            //if sth true call
            //  if (PackageManager.doUnattendedInstall)
            //   {
            //       PackageManager.UnattendedInstall();
            //  }

        }

        public void UnattendedInstall()
        {
       //     currentlyInstalling = true;
       //     currentlyUninstalling = false;
            // packageName = "";
            //(Application.StartupPath + "\\log.txt", true)
            if (Directory.Exists(Application.StartupPath + @"\apps_deploy"))
            {
                Console.WriteLine("exists!");

                try
                {
                    //Directory.EnumerateFiles is not available in .NET 2.0
                    string[] files = Directory.GetFiles(Application.StartupPath + @"\apps_deploy");
                    //string[] files = Directory.GetFiles(@"C:\Windows", "*.dmp");

                    //c += files.Length;

                    foreach (string file in files)
                    {                       
                        string[] fileName = file.Split('\\');
                       // backgroundWorker1.ReportProgress(currentProgress, "Currently Installing: " + fileName[fileName.Length - 1]);
                        currentProgress += Convert.ToInt32(prog);
                        backgroundWorker1.ReportProgress(currentProgress, "Currently Installing: " + fileName[fileName.Length - 1]);
                        //backgroundWorker1.ReportProgress(currentProgress);
                        //packageName = file;
                       Console.WriteLine(file);
                        if (file.EndsWith(".exe"))
                        {
                            PackageManager.EXE_Install(file);
                        }
                        if (file.EndsWith(".msi"))
                        {
                            PackageManager.MSI_Install(file);
                        }
                        else
                        {
                            //pass
                        }
                        //DeleteFile(file);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("The process failed: {0}", e.ToString());
                }

            }
            else
            {
                Console.WriteLine("not exists!");
            }
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            // ManagePrograms();
        }

        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void TweaksUserControl_Load(object sender, EventArgs e)
        {

        }
    }
}
