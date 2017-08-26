using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AdvancedSystemManager
{
    public partial class MainForm : Form
    {
        //public SystemInfo sysinfo = new SystemInfo();
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {            
            //sysinfo = new SystemInfo();
            Console.WriteLine("main entry");
            //Console.WriteLine(sysinfo.RAM);
            //Console.WriteLine(sysinfo.OSBITNESS);

            //PackageManager.NeoUni();
            //PackageManager.NeoUniQbit();
            //MessageBox.Show("block test");
            //ProcessManager.UninstallTest();
            //PackageManager.InstallTest();
            //PackageManager.InstallTestQ();
            //CleanUpManager man = new CleanUpManager();
            //DiskCleanUp.findFiles(@"C:\Windows", "*.dmp");
            //DiskCleanUp.findFiles(@"C:\Windows\Minidump", "*.dmp");
            //DiskCleanUp.FindFiles(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "tsirko*.*");
            //MessageBox.Show(Environment.UserName);
            //RegistryParser.GetPrograms();
            //RegistryParser.getPrograms2();
            //RegistryParser.getWin64Programs();
            //HazardTest.HazardBIOTEST();
            //MessageBox.Show("test");
            //MessageBox.Show(HazardTest.servicesList[5].DisplayName);
            //MessageBox.Show(HazardTest.servicesList[5].de);
            //VisualEffects.ApplySettings();
            //RegistryParser.ApplyVisualEffects();
            //WindowsUpdates.UpdatesFinder();
            //MessageBox.Show("tttt");
            //WindowsUpdates.UpdateChecker("KB3020369");
            //WindowsUpdates.UpdateChecker("KB3172605");
            //WindowsUpdates.UpdateChecker("afafa");
            //WindowsUpdates.UpdateChecker("33");
            //Console.WriteLine(IntegrityChecker.MD5Check(@"C:\Users\moihack\Desktop\palio.png"));
            //Console.WriteLine(IntegrityChecker.SHA1Check(@"C:\Users\moihack\Desktop\palio.png"));
            //RegistryParser.ApplyVisualEffects();
            //VisualEffects.ApplySettings();
            //PackageManager.UnattendedInstall();
            //CPUPower.SetCPUStates();
            // DiskCleanUp.FindFiles("%WINDIR%", "*.dll");
            //DiskCleanUp.FindFiles(@"C:\Windows\msdownld.tmp|?:\msdownld.tmp", "*.tmp");
            //RegistryParser.GetVolumeCaches();
            //DiskCleanUp.FirefoxCleanup();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        { /*
            DialogResult dialogResult = MessageBox.Show("Do you really want to quit Advanced System Manager?", "Advanced System Manager", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                e.Cancel = true;
            } */
        }

        private void optimizeUserControl1_Load(object sender, EventArgs e)
        {
           
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //RegistryParser.GetPrograms();
            //RegistryParser.GetPrograms2();
            //RegistryParser.GetWin64Programs();
            //PackageManager.DuplicatesFinder();
            //PackageManager.ShowNormal();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void tweaksUserControl1_Load(object sender, EventArgs e)
        {

        }

        private void startupProgramsManager1_Load(object sender, EventArgs e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }
    }
}
