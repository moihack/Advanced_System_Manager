using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace AdvancedSystemManager
{
    public partial class SystemInfoUserControl : UserControl
    {
        SystemInfo sysInfo;

        public SystemInfoUserControl()
        {
            InitializeComponent();
        }

        private void SystemInfoUserControl_Load(object sender, EventArgs e)
        {
            //cast is required - parent1=tab page,parent2=tab control,parent3=Form1
            //Form1 myParent = (Form1)this.Parent.Parent.Parent;

            //Console.WriteLine(this.Parent.Parent.Parent.Name);
            //osLbl.Text = osLbl.Text + myParent.sysinfo.OSVERSION;

            sysInfo = new SystemInfo();
            try
            {
                osTB.Text += sysInfo.OSVERSION + " - " + sysInfo.OSBITNESS;
                mbTB.Text += sysInfo.MB;
                cpuTB.Text += sysInfo.CPU;
                ramTB.Text += Convert.ToUInt64(sysInfo.RAM) / 1024 / 1024 + " MB";
                gpuTB.Text += sysInfo.GPU + " with " + Convert.ToUInt64(sysInfo.VRAM) / 1024 / 1024 + " MB of VRAM";
                hddTB.Text += sysInfo.HDDModel + " with " + Convert.ToUInt64(sysInfo.HDD) / 1000 / 1000 / 1000 + " GB of storage";
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void updatesInfo_TextChanged(object sender, EventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            MyLogger.WriteSystemInfo(sysInfo.ToString());
            MessageBox.Show("Saved System Info to info.txt");
            Console.WriteLine(sysInfo.ToString());
        }
    }
}
