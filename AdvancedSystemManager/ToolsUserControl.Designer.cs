namespace AdvancedSystemManager
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
            this.tskMgrLbl = new System.Windows.Forms.LinkLabel();
            this.diskMgmtLbl = new System.Windows.Forms.LinkLabel();
            this.programsLbl = new System.Windows.Forms.LinkLabel();
            this.snipLbl = new System.Windows.Forms.LinkLabel();
            this.calcLbl = new System.Windows.Forms.LinkLabel();
            this.upLbl = new System.Windows.Forms.LinkLabel();
            this.msconfigLbl = new System.Windows.Forms.LinkLabel();
            this.dxLbl = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // cmpLbl
            // 
            this.cmpLbl.AutoSize = true;
            this.cmpLbl.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmpLbl.Location = new System.Drawing.Point(15, 39);
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
            this.cmpMgmtLbl.Location = new System.Drawing.Point(15, 69);
            this.cmpMgmtLbl.Name = "cmpMgmtLbl";
            this.cmpMgmtLbl.Size = new System.Drawing.Size(117, 13);
            this.cmpMgmtLbl.TabIndex = 1;
            this.cmpMgmtLbl.TabStop = true;
            this.cmpMgmtLbl.Text = "Computer Management";
            this.cmpMgmtLbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.cmpMgmtLbl_LinkClicked);
            // 
            // tskMgrLbl
            // 
            this.tskMgrLbl.AutoSize = true;
            this.tskMgrLbl.Location = new System.Drawing.Point(15, 108);
            this.tskMgrLbl.Name = "tskMgrLbl";
            this.tskMgrLbl.Size = new System.Drawing.Size(76, 13);
            this.tskMgrLbl.TabIndex = 2;
            this.tskMgrLbl.TabStop = true;
            this.tskMgrLbl.Text = "Task Manager";
            this.tskMgrLbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.tskMgrLbl_LinkClicked);
            // 
            // diskMgmtLbl
            // 
            this.diskMgmtLbl.AutoSize = true;
            this.diskMgmtLbl.Location = new System.Drawing.Point(15, 143);
            this.diskMgmtLbl.Name = "diskMgmtLbl";
            this.diskMgmtLbl.Size = new System.Drawing.Size(93, 13);
            this.diskMgmtLbl.TabIndex = 3;
            this.diskMgmtLbl.TabStop = true;
            this.diskMgmtLbl.Text = "Disk Management";
            this.diskMgmtLbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.diskMgmtLbl_LinkClicked);
            // 
            // programsLbl
            // 
            this.programsLbl.AutoSize = true;
            this.programsLbl.Location = new System.Drawing.Point(15, 182);
            this.programsLbl.Name = "programsLbl";
            this.programsLbl.Size = new System.Drawing.Size(93, 13);
            this.programsLbl.TabIndex = 4;
            this.programsLbl.TabStop = true;
            this.programsLbl.Text = "Installed Programs";
            this.programsLbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.programsLbl_LinkClicked);
            // 
            // snipLbl
            // 
            this.snipLbl.AutoSize = true;
            this.snipLbl.Location = new System.Drawing.Point(287, 39);
            this.snipLbl.Name = "snipLbl";
            this.snipLbl.Size = new System.Drawing.Size(72, 13);
            this.snipLbl.TabIndex = 5;
            this.snipLbl.TabStop = true;
            this.snipLbl.Text = "Snipping Tool";
            // 
            // calcLbl
            // 
            this.calcLbl.AutoSize = true;
            this.calcLbl.Location = new System.Drawing.Point(287, 69);
            this.calcLbl.Name = "calcLbl";
            this.calcLbl.Size = new System.Drawing.Size(54, 13);
            this.calcLbl.TabIndex = 6;
            this.calcLbl.TabStop = true;
            this.calcLbl.Text = "Calculator";
            // 
            // upLbl
            // 
            this.upLbl.AutoSize = true;
            this.upLbl.Location = new System.Drawing.Point(287, 108);
            this.upLbl.Name = "upLbl";
            this.upLbl.Size = new System.Drawing.Size(89, 13);
            this.upLbl.TabIndex = 7;
            this.upLbl.TabStop = true;
            this.upLbl.Text = "Windows Update";
            // 
            // msconfigLbl
            // 
            this.msconfigLbl.AutoSize = true;
            this.msconfigLbl.Location = new System.Drawing.Point(287, 143);
            this.msconfigLbl.Name = "msconfigLbl";
            this.msconfigLbl.Size = new System.Drawing.Size(125, 13);
            this.msconfigLbl.TabIndex = 8;
            this.msconfigLbl.TabStop = true;
            this.msconfigLbl.Text = "Startup Config (msconfig)";
            // 
            // dxLbl
            // 
            this.dxLbl.AutoSize = true;
            this.dxLbl.Location = new System.Drawing.Point(287, 182);
            this.dxLbl.Name = "dxLbl";
            this.dxLbl.Size = new System.Drawing.Size(42, 13);
            this.dxLbl.TabIndex = 9;
            this.dxLbl.TabStop = true;
            this.dxLbl.Text = "DxDiag";
            // 
            // ToolsUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dxLbl);
            this.Controls.Add(this.msconfigLbl);
            this.Controls.Add(this.upLbl);
            this.Controls.Add(this.calcLbl);
            this.Controls.Add(this.snipLbl);
            this.Controls.Add(this.programsLbl);
            this.Controls.Add(this.diskMgmtLbl);
            this.Controls.Add(this.tskMgrLbl);
            this.Controls.Add(this.cmpMgmtLbl);
            this.Controls.Add(this.cmpLbl);
            this.Name = "ToolsUserControl";
            this.Size = new System.Drawing.Size(480, 269);
            this.Load += new System.EventHandler(this.ToolsUserControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel cmpLbl;
        private System.Windows.Forms.LinkLabel cmpMgmtLbl;
        private System.Windows.Forms.LinkLabel tskMgrLbl;
        private System.Windows.Forms.LinkLabel diskMgmtLbl;
        private System.Windows.Forms.LinkLabel programsLbl;
        private System.Windows.Forms.LinkLabel snipLbl;
        private System.Windows.Forms.LinkLabel calcLbl;
        private System.Windows.Forms.LinkLabel upLbl;
        private System.Windows.Forms.LinkLabel msconfigLbl;
        private System.Windows.Forms.LinkLabel dxLbl;
    }
}
