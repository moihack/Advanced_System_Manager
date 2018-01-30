using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace AdvancedSystemManager
{
    internal partial class SystemInfoUserControl : UserControl
    {
        SystemInfo sysInfo;

        internal SystemInfoUserControl()
        {
            InitializeComponent();
        }

        private void SystemInfoUserControl_Load(object sender, EventArgs e)
        {
            sysInfo = new SystemInfo();
            try
            {
                osTB.Text += sysInfo.OSVERSION + " - " + sysInfo.OSBITNESS;
                mbTB.Text += sysInfo.MB;
                cpuTB.Text += sysInfo.CPU;
                ramTB.Text += sysInfo.RAM;
                gpuTB.Text += sysInfo.GPU + " with " + sysInfo.VRAM;
                hddTB.Text += sysInfo.HDDModel + " with " + sysInfo.HDD;
            }
            catch(Exception ex)
            {
                MyLogger.WriteErrorLog(ex.Message);
            }

            updatesInfo.Text = "Please wait...Searching for installed updates";
            backgroundWorker1.RunWorkerAsync();

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            WindowsUpdates winUp = new WindowsUpdates();
            winUp.UpdatesFinder();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            if ((sysInfo.OSVERSION.Contains("7")) || (sysInfo.OSVERSION.Contains("8")))
            {
                String up1 = "KB3020369";
                String up2 = "KB3172605";

                updatesInfo.Text = WindowsUpdates.UpdateChecker(up1) + "\r\n";
                updatesInfo.Text += WindowsUpdates.UpdateChecker(up2) + "\r\n";

                if( !updatesInfo.Text.Contains("NOT"))
                {
                    updatesInfo.Text += "Windows Update seems to be working correctly";
                }
            }
            else
            {
                if(updatesInfo.Text.Equals("Please wait...Searching for installed updates"))
                {
                    updatesInfo.Text = "Windows Update seems to be working correctly";
                }
            }           
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            MyLogger.WriteSystemInfo(sysInfo.ToString());
            MessageBox.Show("Saved System Info to info.txt");
            Console.WriteLine(sysInfo.ToString());
        }
    }
}
