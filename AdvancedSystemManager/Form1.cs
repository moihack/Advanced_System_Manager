using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AdvancedSystemManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {            
            SystemInfo sysinfo = new SystemInfo();
            Console.WriteLine("main entry");
            //Console.WriteLine(sysinfo.RAM);
            Console.WriteLine(sysinfo.OSBITNESS);
            //RegistryParser.getPrograms();
            ProcessManager.NeoUni();
            ProcessManager.NeoUniQbit();
            MessageBox.Show("block test");
            //ProcessManager.UninstallTest();
            ProcessManager.InstallTest();
            ProcessManager.InstallTestQ();
            //CleanUpManager man = new CleanUpManager();
            //DiskCleanUp.findFiles(@"C:\Windows", "*.dmp");
            //DiskCleanUp.findFiles(@"C:\Windows\Minidump", "*.dmp");
            //DiskCleanUp.FindFiles(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "tsirko*.*");
            //MessageBox.Show(Environment.UserName);
            //RegistryParser.getPrograms();
            //RegistryParser.getPrograms2();
            //RegistryParser.getWin64Programs();
        }       
    }
}
