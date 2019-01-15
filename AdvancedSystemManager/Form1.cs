using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AdvancedSystemManager
{
    internal partial class MainForm : Form
    {
        internal MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {            
           
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (tweaksUserControl1.backgroundWorker1.IsBusy)
            {
                DialogResult dialogResult = MessageBox.Show("Do you really want to quit Advanced System Manager? Doing this now may leave your system in an unusable state", "Advanced System Manager", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
