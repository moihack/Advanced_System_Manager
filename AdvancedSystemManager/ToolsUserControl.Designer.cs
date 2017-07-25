﻿namespace AdvancedSystemManager
{
    partial class ToolsUserControl
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
            this.cmpLbl = new System.Windows.Forms.LinkLabel();
            this.cmpMgmtLbl = new System.Windows.Forms.LinkLabel();
            this.diskMgmtLbl = new System.Windows.Forms.LinkLabel();
            this.msconfigLbl = new System.Windows.Forms.LinkLabel();
            this.dxLbl = new System.Windows.Forms.LinkLabel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SysInfoLbl = new System.Windows.Forms.LinkLabel();
            this.openFileBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.md5Lbl = new System.Windows.Forms.Label();
            this.sha1Lbl = new System.Windows.Forms.Label();
            this.pathTB = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.devMgmtLbl = new System.Windows.Forms.LinkLabel();
            this.servMgmtLbl = new System.Windows.Forms.LinkLabel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmpLbl
            // 
            this.cmpLbl.AutoSize = true;
            this.cmpLbl.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmpLbl.Location = new System.Drawing.Point(37, 9);
            this.cmpLbl.Name = "cmpLbl";
            this.cmpLbl.Size = new System.Drawing.Size(156, 13);
            this.cmpLbl.TabIndex = 0;
            this.cmpLbl.TabStop = true;
            this.cmpLbl.Text = "Command Prompt(Administrator)";
            this.cmpLbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.cmpLbl_LinkClicked);
            // 
            // cmpMgmtLbl
            // 
            this.cmpMgmtLbl.AutoSize = true;
            this.cmpMgmtLbl.Location = new System.Drawing.Point(37, 39);
            this.cmpMgmtLbl.Name = "cmpMgmtLbl";
            this.cmpMgmtLbl.Size = new System.Drawing.Size(117, 13);
            this.cmpMgmtLbl.TabIndex = 1;
            this.cmpMgmtLbl.TabStop = true;
            this.cmpMgmtLbl.Text = "Computer Management";
            this.cmpMgmtLbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.cmpMgmtLbl_LinkClicked);
            // 
            // diskMgmtLbl
            // 
            this.diskMgmtLbl.AutoSize = true;
            this.diskMgmtLbl.Location = new System.Drawing.Point(37, 102);
            this.diskMgmtLbl.Name = "diskMgmtLbl";
            this.diskMgmtLbl.Size = new System.Drawing.Size(93, 13);
            this.diskMgmtLbl.TabIndex = 3;
            this.diskMgmtLbl.TabStop = true;
            this.diskMgmtLbl.Text = "Disk Management";
            this.diskMgmtLbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.diskMgmtLbl_LinkClicked);
            // 
            // msconfigLbl
            // 
            this.msconfigLbl.AutoSize = true;
            this.msconfigLbl.Location = new System.Drawing.Point(302, 71);
            this.msconfigLbl.Name = "msconfigLbl";
            this.msconfigLbl.Size = new System.Drawing.Size(125, 13);
            this.msconfigLbl.TabIndex = 8;
            this.msconfigLbl.TabStop = true;
            this.msconfigLbl.Text = "Startup Config (msconfig)";
            this.msconfigLbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.msconfigLbl_LinkClicked);
            // 
            // dxLbl
            // 
            this.dxLbl.AutoSize = true;
            this.dxLbl.Location = new System.Drawing.Point(302, 9);
            this.dxLbl.Name = "dxLbl";
            this.dxLbl.Size = new System.Drawing.Size(42, 13);
            this.dxLbl.TabIndex = 9;
            this.dxLbl.TabStop = true;
            this.dxLbl.Text = "DxDiag";
            this.dxLbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.dxLbl_LinkClicked);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // SysInfoLbl
            // 
            this.SysInfoLbl.AutoSize = true;
            this.SysInfoLbl.Location = new System.Drawing.Point(302, 102);
            this.SysInfoLbl.Name = "SysInfoLbl";
            this.SysInfoLbl.Size = new System.Drawing.Size(62, 13);
            this.SysInfoLbl.TabIndex = 6;
            this.SysInfoLbl.TabStop = true;
            this.SysInfoLbl.Text = "System Info";
            this.SysInfoLbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.SysInfoLbl_LinkClicked);
            // 
            // openFileBtn
            // 
            this.openFileBtn.Location = new System.Drawing.Point(6, 13);
            this.openFileBtn.Name = "openFileBtn";
            this.openFileBtn.Size = new System.Drawing.Size(90, 23);
            this.openFileBtn.TabIndex = 10;
            this.openFileBtn.Text = "File Checksum";
            this.openFileBtn.UseVisualStyleBackColor = true;
            this.openFileBtn.Click += new System.EventHandler(this.openFileBtn_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.servMgmtLbl);
            this.panel1.Controls.Add(this.devMgmtLbl);
            this.panel1.Controls.Add(this.cmpLbl);
            this.panel1.Controls.Add(this.cmpMgmtLbl);
            this.panel1.Controls.Add(this.dxLbl);
            this.panel1.Controls.Add(this.msconfigLbl);
            this.panel1.Controls.Add(this.diskMgmtLbl);
            this.panel1.Controls.Add(this.SysInfoLbl);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(438, 128);
            this.panel1.TabIndex = 11;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // md5Lbl
            // 
            this.md5Lbl.AutoSize = true;
            this.md5Lbl.Location = new System.Drawing.Point(98, 48);
            this.md5Lbl.Name = "md5Lbl";
            this.md5Lbl.Size = new System.Drawing.Size(0, 13);
            this.md5Lbl.TabIndex = 12;
            // 
            // sha1Lbl
            // 
            this.sha1Lbl.AutoSize = true;
            this.sha1Lbl.Location = new System.Drawing.Point(98, 72);
            this.sha1Lbl.Name = "sha1Lbl";
            this.sha1Lbl.Size = new System.Drawing.Size(0, 13);
            this.sha1Lbl.TabIndex = 13;
            // 
            // pathTB
            // 
            this.pathTB.Location = new System.Drawing.Point(102, 15);
            this.pathTB.Name = "pathTB";
            this.pathTB.ReadOnly = true;
            this.pathTB.Size = new System.Drawing.Size(354, 20);
            this.pathTB.TabIndex = 15;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.openFileBtn);
            this.panel2.Controls.Add(this.pathTB);
            this.panel2.Controls.Add(this.md5Lbl);
            this.panel2.Controls.Add(this.sha1Lbl);
            this.panel2.Location = new System.Drawing.Point(3, 149);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(474, 102);
            this.panel2.TabIndex = 16;
            // 
            // devMgmtLbl
            // 
            this.devMgmtLbl.AutoSize = true;
            this.devMgmtLbl.Location = new System.Drawing.Point(37, 71);
            this.devMgmtLbl.Name = "devMgmtLbl";
            this.devMgmtLbl.Size = new System.Drawing.Size(86, 13);
            this.devMgmtLbl.TabIndex = 10;
            this.devMgmtLbl.TabStop = true;
            this.devMgmtLbl.Text = "Device Manager";
            this.devMgmtLbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.devMgmtLbl_LinkClicked);
            // 
            // servMgmtLbl
            // 
            this.servMgmtLbl.AutoSize = true;
            this.servMgmtLbl.Location = new System.Drawing.Point(302, 39);
            this.servMgmtLbl.Name = "servMgmtLbl";
            this.servMgmtLbl.Size = new System.Drawing.Size(88, 13);
            this.servMgmtLbl.TabIndex = 11;
            this.servMgmtLbl.TabStop = true;
            this.servMgmtLbl.Text = "Service Manager";
            this.servMgmtLbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.servMgmtLbl_LinkClicked);
            // 
            // ToolsUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ToolsUserControl";
            this.Size = new System.Drawing.Size(480, 269);
            this.Load += new System.EventHandler(this.ToolsUserControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.LinkLabel cmpLbl;
        private System.Windows.Forms.LinkLabel cmpMgmtLbl;
        private System.Windows.Forms.LinkLabel diskMgmtLbl;
        private System.Windows.Forms.LinkLabel msconfigLbl;
        private System.Windows.Forms.LinkLabel dxLbl;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.LinkLabel SysInfoLbl;
        private System.Windows.Forms.Button openFileBtn;
        private System.Windows.Forms.Panel panel1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label md5Lbl;
        private System.Windows.Forms.Label sha1Lbl;
        private System.Windows.Forms.TextBox pathTB;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.LinkLabel devMgmtLbl;
        private System.Windows.Forms.LinkLabel servMgmtLbl;
    }
}
