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
            //Console.WriteLine(sysinfo.OSVERSION);
        }
    }
}
