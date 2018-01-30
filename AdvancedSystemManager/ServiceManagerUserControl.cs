using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace AdvancedSystemManager
{
    internal partial class ServiceManagerUserControl : UserControl
    {
        internal ServiceManagerUserControl()
        {
            InitializeComponent();
        }

        private void ServiceManagerUserControl_Load(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        // This event handler manually raises the CellValueChanged event 
        // by calling the CommitEdit method. 
        void dataGridView1_CurrentCellDirtyStateChanged(object sender,EventArgs e)
        {
            if (this.dataGridView1.IsCurrentCellDirty)
            {
                // This fires the cell value changed handler below
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            bool scRUN = false;
            DataGridViewComboBoxCell cb = (DataGridViewComboBoxCell)dataGridView1.Rows[e.RowIndex].Cells[3];

            if (cb.Value != null)
            {
                int currentRow = dataGridView1.CurrentCellAddress.Y; // Y = current row
                String serviceName = dataGridView1.Rows[currentRow].Cells[1].Value.ToString();
                String startType = dataGridView1.Rows[currentRow].Cells[3].Value.ToString().Remove(0, 4);

                switch (startType)
                {
                    case "Automatic":
                        startType = "auto";
                        break;
                    case "Manual":
                        startType = "demand";
                        break;
                    case "Disabled":
                        startType = "disabled";
                        break;
                }

                //cmd: sc config gupdate start= disabled
                //res: [SC] ChangeServiceConfig SUCCESS
                //res inv: [SC] OpenService FAILED 1060:
                //The specified service does not exist as an installed service.

                Process myProcess = new Process();
                try
                {
                    myProcess.StartInfo.UseShellExecute = false;
                    myProcess.StartInfo.FileName = "sc.exe";
                    myProcess.StartInfo.Arguments = "config " + serviceName + " start= " + startType;
                    myProcess.StartInfo.CreateNoWindow = true;
                    myProcess.StartInfo.RedirectStandardError = true;
                    myProcess.StartInfo.RedirectStandardOutput = true;

                    myProcess.Start();

                    while (!myProcess.StandardOutput.EndOfStream)
                    {
                        string line = myProcess.StandardOutput.ReadLine();

                        if (line.Contains("SUCCESS"))
                        {
                            scRUN = true; //service config run fine
                        }
                    }
                }
                catch (Exception ex)
                {
                    MyLogger.WriteErrorLog("Exception occured while setting " + serviceName + " service start-up type");
                    MyLogger.WriteErrorLog(ex.Message);
                }

                if (scRUN)
                {
                    dataGridView1.Invalidate();
                }


            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            ServiceManager.GetServices();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            foreach (WindowsService ser in ServiceManager.servicesList)
            {
                dataGridView1.Rows.Add(ser.DisplayName, ser.ServiceName, ser.Status);

                int currentRow = dataGridView1.RowCount - 1; //dirty one-line hack!

                switch (ser.StartType)
                {
                    case 2:
                        dataGridView1.Rows[currentRow].Cells[3].Value = "2 - Automatic";
                        break;
                    case 3:
                        dataGridView1.Rows[currentRow].Cells[3].Value = "3 - Manual";
                        break;
                    case 4:
                        dataGridView1.Rows[currentRow].Cells[3].Value = "4 - Disabled";
                        break;
                }
            }

            // Add the events to listen for
            dataGridView1.CellValueChanged += new DataGridViewCellEventHandler(dataGridView1_CellValueChanged);
            dataGridView1.CurrentCellDirtyStateChanged += new EventHandler(dataGridView1_CurrentCellDirtyStateChanged);
        }
    }
}
