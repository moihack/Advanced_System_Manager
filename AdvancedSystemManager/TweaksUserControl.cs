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
    internal partial class TweaksUserControl : UserControl
    {
        //use these to count the total tasks for backgroundworker
        //calculate total progress depending on the number of tasks
        static bool doDiskCleanup = false;
        static bool doFirefoxReset = false;
        static bool doChromeReset = false;
        static bool doVisualEffects = false;
        static bool doUnattended = false;
        static bool doMassiveUninstall = false;
        static bool doCPUState = false;

        static int c = 0; //number of tasks for the backgroundworker to perform
        static int currentProgress = 0;
        static int maxProgress = 100;
        static float prog;

        internal TweaksUserControl()
        {
            InitializeComponent();
        }

        private void optimizeBtn_Click(object sender, EventArgs e)
        {
            doMassiveUninstall = false;

            //Form myForm = (Form)this.Parent.Parent.Parent.Parent.Parent;
            TabControl myTabControl = (TabControl)this.Parent.Parent.Parent.Parent;
            //Console.WriteLine(myTabControl.Name);

            SplitContainer mySplitContair = (SplitContainer)this.Parent.Parent; //first parent is split container control
            //Console.WriteLine(mySplitContair.Name);

            SplitterPanel myProgramsSplitterPanel = (SplitterPanel)mySplitContair.Panel1;
            //Console.WriteLine(myProgramsSplitterPanel.AccessibleName);

            ProgramsManagerUserControl myProgramsManager = (ProgramsManagerUserControl)myProgramsSplitterPanel.Controls["programsManagerUserControl1"];

            CalculateProgressBarMaxValue();

            //check if a program is selected in the programs list
            // if yes, set : doMassiveUninstall = true;

            for (int i = 0; i < myProgramsManager.listView1.Items.Count; i++)
            {
                if (myProgramsManager.listView1.Items[i].Checked)
                {
                    PackageManager.installedProgramsList[i].ToRemove = true;
                    doMassiveUninstall = true;
                    c += 1;
                }
                else
                {
                    //workaround for markfromtext() method - if sth got marked from the list but we unchecked it
                    PackageManager.installedProgramsList[i].ToRemove = false;
                }
            }

            //if everything is false! - meaning if the user has not selected any option
            if (!doDiskCleanup && !doFirefoxReset && !doChromeReset && !doVisualEffects && !doUnattended && !doMassiveUninstall && !doCPUState)
            {
                MessageBox.Show("Please select at least one option or mark a program for uninstallation");
            }
            else
            {
                prog = (1.0f / c * maxProgress);
                //Console.WriteLine("prog is: " + prog);
                //Console.WriteLine("jobs are: " + c);

                //disable input from the user to the program while working
                myTabControl.Enabled = false;
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (doCPUState)
                {
                    backgroundWorker1.ReportProgress(currentProgress, "Setting CPU Full State");
                    CPUPower.SetCPUStates();

                    currentProgress += Convert.ToInt32(prog);

                    backgroundWorker1.ReportProgress(currentProgress);
                    //System.Threading.Thread.Sleep(3000);
                }

                if (doVisualEffects)
                {
                    backgroundWorker1.ReportProgress(currentProgress, "Applying Visual Effects Settings");

                    VisualEffects.ApplySettings();
                    RegistryParser.ApplyVisualEffects();

                    currentProgress += Convert.ToInt32(prog);

                    backgroundWorker1.ReportProgress(currentProgress);
                }

                if (doFirefoxReset)
                {
                    backgroundWorker1.ReportProgress(currentProgress, "Cleaning Firefox Profile");

                    DiskCleanUp.FirefoxCleanup();
                    currentProgress += Convert.ToInt32(prog);

                    backgroundWorker1.ReportProgress(currentProgress);
                }

                if (doChromeReset)
                {
                    backgroundWorker1.ReportProgress(currentProgress, "Cleaning Google Chrome Profile");

                    DiskCleanUp.ChromeCleanup();
                    currentProgress += Convert.ToInt32(prog);

                    backgroundWorker1.ReportProgress(currentProgress);
                }

                if (doMassiveUninstall)
                {
                    UninstallPrograms();

                    currentProgress += Convert.ToInt32(prog);

                    backgroundWorker1.ReportProgress(currentProgress);
                }

                if (doUnattended)
                {
                    UnattendedInstall();

                    currentProgress += Convert.ToInt32(prog);

                    backgroundWorker1.ReportProgress(currentProgress);
                }

                if (doDiskCleanup)
                {
                    backgroundWorker1.ReportProgress(currentProgress, "Performing Disk Cleanup");

                    RegistryParser.GetVolumeCaches();
                    currentProgress += Convert.ToInt32(prog);

                    backgroundWorker1.ReportProgress(currentProgress);
                }
            }
            catch (Exception ex)
            {
                MyLogger.WriteErrorLog("Exception occured during optimization");
                MyLogger.WriteErrorLog(ex.Message);
            }

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (progressBar1.Value <= progressBar1.Maximum)
            {
                if (e.ProgressPercentage <= 100)
                {
                    progressBar1.Value = e.ProgressPercentage;
                }
            }
            else { }

            string Res = (string)e.UserState;
            progressLbl.Text = Res;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Value = 100;
            progressLbl.Text = "Finished! You can now close this window";
            MessageBox.Show("Optimization Finished! You can now close Advanced System Manager.");
        }

        private void CalculateProgressBarMaxValue()
        {
            if (doDiskCleanup) { c += 1; }
            if (doFirefoxReset) { c += 1; }
            if (doChromeReset) { c += 1; }
            if (doVisualEffects) { c += 1; }
            if (doUnattended) { c += 1; }
            if (doCPUState) { c += 1; }
            if (doMassiveUninstall) { c += 1; }

            if (doUnattended)
            {
                c += 1;
                try
                {
                    //Directory.EnumerateFiles is not available in .NET 2.0
                    string[] files = Directory.GetFiles(Application.StartupPath + @"\apps_deploy");

                    //each program to install is a new task
                    c += files.Length;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
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

        internal void UninstallPrograms()
        {
            //console write line does not work here
            //we also have to avoid accessing controls of the ui thread

            for (int i = 0; i < PackageManager.installedProgramsList.Count; i++)
            {
                if (PackageManager.installedProgramsList[i].ToRemove)
                {
                    //MyLogger.WriteLog("package is :" + PackageManager.installedProgramsList[i].PackageName + " " + i);
                    backgroundWorker1.ReportProgress(currentProgress, "Currently Uninstalling: " + PackageManager.installedProgramsList[i].PackageName);
                    PackageManager.CheckUninstallationMethod(PackageManager.installedProgramsList[i]);
                    currentProgress += Convert.ToInt32(prog);
                    backgroundWorker1.ReportProgress(currentProgress);
                }
            }
        }

        internal void UnattendedInstall()
        {
            if (Directory.Exists(Application.StartupPath + @"\apps_deploy"))
            {
                try
                {
                    //Directory.EnumerateFiles is not available in .NET 2.0
                    string[] files = Directory.GetFiles(Application.StartupPath + @"\apps_deploy");

                    foreach (string file in files)
                    {
                        string[] fileName = file.Split('\\');

                        currentProgress += Convert.ToInt32(prog);
                        backgroundWorker1.ReportProgress(currentProgress, "Currently Installing: " + fileName[fileName.Length - 1]);

                        //Console.WriteLine(file);
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
                    }
                }
                catch (Exception ex)
                {
                    MyLogger.WriteErrorLog("Exception Occured while installing software");
                    MyLogger.WriteErrorLog(ex.Message);
                }

            }
            else
            {
                MyLogger.WriteLog("Directory apps_deploy does not exist!");
            }
        }

        private void TweaksUserControl_Load(object sender, EventArgs e)
        {

        }
    }
}
