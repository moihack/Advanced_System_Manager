namespace AdvancedSystemManager
{
    partial class SystemInfoUserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cpuLbl = new System.Windows.Forms.Label();
            this.ramLbl = new System.Windows.Forms.Label();
            this.gpuLbl = new System.Windows.Forms.Label();
            this.hddLbl = new System.Windows.Forms.Label();
            this.mbLbl = new System.Windows.Forms.Label();
            this.osLbl = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.osTB = new System.Windows.Forms.TextBox();
            this.mbTB = new System.Windows.Forms.TextBox();
            this.cpuTB = new System.Windows.Forms.TextBox();
            this.ramTB = new System.Windows.Forms.TextBox();
            this.gpuTB = new System.Windows.Forms.TextBox();
            this.hddTB = new System.Windows.Forms.TextBox();
            this.updatesInfo = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cpuLbl
            // 
            this.cpuLbl.AutoSize = true;
            this.cpuLbl.Location = new System.Drawing.Point(12, 93);
            this.cpuLbl.Name = "cpuLbl";
            this.cpuLbl.Size = new System.Drawing.Size(35, 13);
            this.cpuLbl.TabIndex = 0;
            this.cpuLbl.Text = "CPU: ";
            // 
            // ramLbl
            // 
            this.ramLbl.AutoSize = true;
            this.ramLbl.Location = new System.Drawing.Point(13, 139);
            this.ramLbl.Name = "ramLbl";
            this.ramLbl.Size = new System.Drawing.Size(37, 13);
            this.ramLbl.TabIndex = 1;
            this.ramLbl.Text = "RAM: ";
            // 
            // gpuLbl
            // 
            this.gpuLbl.AutoSize = true;
            this.gpuLbl.Location = new System.Drawing.Point(13, 181);
            this.gpuLbl.Name = "gpuLbl";
            this.gpuLbl.Size = new System.Drawing.Size(36, 13);
            this.gpuLbl.TabIndex = 2;
            this.gpuLbl.Text = "GPU: ";
            // 
            // hddLbl
            // 
            this.hddLbl.AutoSize = true;
            this.hddLbl.Location = new System.Drawing.Point(12, 226);
            this.hddLbl.Name = "hddLbl";
            this.hddLbl.Size = new System.Drawing.Size(37, 13);
            this.hddLbl.TabIndex = 3;
            this.hddLbl.Text = "HDD: ";
            // 
            // mbLbl
            // 
            this.mbLbl.AutoSize = true;
            this.mbLbl.Location = new System.Drawing.Point(3, 57);
            this.mbLbl.Name = "mbLbl";
            this.mbLbl.Size = new System.Drawing.Size(73, 13);
            this.mbLbl.TabIndex = 4;
            this.mbLbl.Text = "Motherboard: ";
            // 
            // osLbl
            // 
            this.osLbl.AutoSize = true;
            this.osLbl.Location = new System.Drawing.Point(16, 21);
            this.osLbl.Name = "osLbl";
            this.osLbl.Size = new System.Drawing.Size(28, 13);
            this.osLbl.TabIndex = 5;
            this.osLbl.Text = "OS: ";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.updatesInfo);
            this.panel1.Controls.Add(this.hddTB);
            this.panel1.Controls.Add(this.gpuTB);
            this.panel1.Controls.Add(this.ramTB);
            this.panel1.Controls.Add(this.cpuTB);
            this.panel1.Controls.Add(this.mbTB);
            this.panel1.Controls.Add(this.osTB);
            this.panel1.Controls.Add(this.osLbl);
            this.panel1.Controls.Add(this.hddLbl);
            this.panel1.Controls.Add(this.mbLbl);
            this.panel1.Controls.Add(this.gpuLbl);
            this.panel1.Controls.Add(this.ramLbl);
            this.panel1.Controls.Add(this.cpuLbl);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(488, 382);
            this.panel1.TabIndex = 6;
            // 
            // osTB
            // 
            this.osTB.Location = new System.Drawing.Point(81, 18);
            this.osTB.Name = "osTB";
            this.osTB.ReadOnly = true;
            this.osTB.Size = new System.Drawing.Size(372, 20);
            this.osTB.TabIndex = 6;
            // 
            // mbTB
            // 
            this.mbTB.Location = new System.Drawing.Point(81, 57);
            this.mbTB.Name = "mbTB";
            this.mbTB.ReadOnly = true;
            this.mbTB.Size = new System.Drawing.Size(372, 20);
            this.mbTB.TabIndex = 7;
            // 
            // cpuTB
            // 
            this.cpuTB.Location = new System.Drawing.Point(81, 90);
            this.cpuTB.Name = "cpuTB";
            this.cpuTB.ReadOnly = true;
            this.cpuTB.Size = new System.Drawing.Size(372, 20);
            this.cpuTB.TabIndex = 8;
            // 
            // ramTB
            // 
            this.ramTB.Location = new System.Drawing.Point(81, 132);
            this.ramTB.Name = "ramTB";
            this.ramTB.ReadOnly = true;
            this.ramTB.Size = new System.Drawing.Size(372, 20);
            this.ramTB.TabIndex = 9;
            // 
            // gpuTB
            // 
            this.gpuTB.Location = new System.Drawing.Point(81, 174);
            this.gpuTB.Name = "gpuTB";
            this.gpuTB.ReadOnly = true;
            this.gpuTB.Size = new System.Drawing.Size(372, 20);
            this.gpuTB.TabIndex = 10;
            // 
            // hddTB
            // 
            this.hddTB.Location = new System.Drawing.Point(81, 219);
            this.hddTB.Name = "hddTB";
            this.hddTB.ReadOnly = true;
            this.hddTB.Size = new System.Drawing.Size(372, 20);
            this.hddTB.TabIndex = 11;
            // 
            // updatesInfo
            // 
            this.updatesInfo.Location = new System.Drawing.Point(15, 263);
            this.updatesInfo.Multiline = true;
            this.updatesInfo.Name = "updatesInfo";
            this.updatesInfo.ReadOnly = true;
            this.updatesInfo.Size = new System.Drawing.Size(438, 97);
            this.updatesInfo.TabIndex = 12;
            // 
            // SystemInfoUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "SystemInfoUserControl";
            this.Size = new System.Drawing.Size(493, 385);
            this.Load += new System.EventHandler(this.SystemInfoUserControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label cpuLbl;
        private System.Windows.Forms.Label ramLbl;
        private System.Windows.Forms.Label gpuLbl;
        private System.Windows.Forms.Label hddLbl;
        private System.Windows.Forms.Label mbLbl;
        private System.Windows.Forms.Label osLbl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox osTB;
        private System.Windows.Forms.TextBox hddTB;
        private System.Windows.Forms.TextBox gpuTB;
        private System.Windows.Forms.TextBox ramTB;
        private System.Windows.Forms.TextBox cpuTB;
        private System.Windows.Forms.TextBox mbTB;
        private System.Windows.Forms.TextBox updatesInfo;
    }
}
