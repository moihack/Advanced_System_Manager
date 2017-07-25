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

            String up1 = "KB3020369";
            String up2 = "KB3172605";

            WindowsUpdates winUp = new WindowsUpdates();
            //winUp.UpdatesFinder();

            SystemInfo sysInfo = new SystemInfo();

            osTB.Text += sysInfo.OSVERSION + " - " + sysInfo.OSBITNESS;
            mbTB.Text += sysInfo.MB;
            cpuTB.Text += sysInfo.CPU;
            ramTB.Text += Convert.ToUInt64(sysInfo.RAM) / 1024 / 1024 + " MB";
            gpuTB.Text += sysInfo.GPU + " with " + Convert.ToUInt64(sysInfo.VRAM)/1024/1024 + " MB of VRAM";
            hddTB.Text += sysInfo.HDDModel + " with " + Convert.ToUInt64(sysInfo.HDD)/1000/1000/1000 + " GB of storage";

            updatesInfo.Text = winUp.UpdateChecker(up1);
            updatesInfo.Text +=  winUp.UpdateChecker(up2);
        }
       
    }
}
