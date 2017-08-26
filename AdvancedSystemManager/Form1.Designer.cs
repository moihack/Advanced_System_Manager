namespace AdvancedSystemManager
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Optimize = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.programsManagerUserControl1 = new AdvancedSystemManager.ProgramsManagerUserControl();
            this.tweaksUserControl1 = new AdvancedSystemManager.TweaksUserControl();
            this.Startup = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.serviceManagerUserControl1 = new AdvancedSystemManager.ServiceManagerUserControl();
            this.startupProgramsManager1 = new AdvancedSystemManager.StartupProgramsManager();
            this.Tools = new System.Windows.Forms.TabPage();
            this.toolsUserControl1 = new AdvancedSystemManager.ToolsUserControl();
            this.Info = new System.Windows.Forms.TabPage();
            this.systemInfoUserControl1 = new AdvancedSystemManager.SystemInfoUserControl();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.Optimize.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.Startup.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.Tools.SuspendLayout();
            this.Info.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Optimize
            // 
            this.Optimize.Controls.Add(this.splitContainer1);
            this.Optimize.Location = new System.Drawing.Point(4, 22);
            this.Optimize.Name = "Optimize";
            this.Optimize.Size = new System.Drawing.Size(541, 379);
            this.Optimize.TabIndex = 3;
            this.Optimize.Text = "Optimize";
            this.Optimize.ToolTipText = "Uninstall programs and apply tweaks to boost your computer\'s performance";
            this.Optimize.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.programsManagerUserControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tweaksUserControl1);
            this.splitContainer1.Size = new System.Drawing.Size(541, 379);
            this.splitContainer1.SplitterDistance = 256;
            this.splitContainer1.TabIndex = 0;
            // 
            // programsManagerUserControl1
            // 
            this.programsManagerUserControl1.Location = new System.Drawing.Point(-2, 3);
            this.programsManagerUserControl1.Name = "programsManagerUserControl1";
            this.programsManagerUserControl1.Size = new System.Drawing.Size(540, 245);
            this.programsManagerUserControl1.TabIndex = 0;
            // 
            // tweaksUserControl1
            // 
            this.tweaksUserControl1.Location = new System.Drawing.Point(1, -6);
            this.tweaksUserControl1.Name = "tweaksUserControl1";
            this.tweaksUserControl1.Size = new System.Drawing.Size(540, 129);
            this.tweaksUserControl1.TabIndex = 0;
            this.tweaksUserControl1.Load += new System.EventHandler(this.tweaksUserControl1_Load);
            // 
            // Startup
            // 
            this.Startup.Controls.Add(this.splitContainer2);
            this.Startup.Location = new System.Drawing.Point(4, 22);
            this.Startup.Name = "Startup";
            this.Startup.Size = new System.Drawing.Size(541, 379);
            this.Startup.TabIndex = 2;
            this.Startup.Text = "Startup Manager";
            this.Startup.ToolTipText = "Manage startup programs and services";
            this.Startup.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.serviceManagerUserControl1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.startupProgramsManager1);
            this.splitContainer2.Size = new System.Drawing.Size(541, 379);
            this.splitContainer2.SplitterDistance = 211;
            this.splitContainer2.TabIndex = 2;
            // 
            // serviceManagerUserControl1
            // 
            this.serviceManagerUserControl1.Location = new System.Drawing.Point(0, 0);
            this.serviceManagerUserControl1.Name = "serviceManagerUserControl1";
            this.serviceManagerUserControl1.Size = new System.Drawing.Size(540, 200);
            this.serviceManagerUserControl1.TabIndex = 0;
            // 
            // startupProgramsManager1
            // 
            this.startupProgramsManager1.Location = new System.Drawing.Point(0, 3);
            this.startupProgramsManager1.Name = "startupProgramsManager1";
            this.startupProgramsManager1.Size = new System.Drawing.Size(540, 150);
            this.startupProgramsManager1.TabIndex = 0;
            // 
            // Tools
            // 
            this.Tools.Controls.Add(this.toolsUserControl1);
            this.Tools.Location = new System.Drawing.Point(4, 22);
            this.Tools.Name = "Tools";
            this.Tools.Size = new System.Drawing.Size(541, 379);
            this.Tools.TabIndex = 1;
            this.Tools.Text = "Tools";
            this.Tools.ToolTipText = "Access common Windows management tools and calculate MD5|SHA-1 checksums of your " +
    "files";
            this.Tools.UseVisualStyleBackColor = true;
            // 
            // toolsUserControl1
            // 
            this.toolsUserControl1.Location = new System.Drawing.Point(29, 42);
            this.toolsUserControl1.Name = "toolsUserControl1";
            this.toolsUserControl1.Size = new System.Drawing.Size(480, 269);
            this.toolsUserControl1.TabIndex = 0;
            // 
            // Info
            // 
            this.Info.Controls.Add(this.systemInfoUserControl1);
            this.Info.Location = new System.Drawing.Point(4, 22);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(541, 379);
            this.Info.TabIndex = 0;
            this.Info.Text = "System Info";
            this.Info.ToolTipText = "View hardware and software info of your computer";
            this.Info.UseVisualStyleBackColor = true;
            // 
            // systemInfoUserControl1
            // 
            this.systemInfoUserControl1.Location = new System.Drawing.Point(24, 3);
            this.systemInfoUserControl1.Name = "systemInfoUserControl1";
            this.systemInfoUserControl1.Size = new System.Drawing.Size(493, 385);
            this.systemInfoUserControl1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Info);
            this.tabControl1.Controls.Add(this.Tools);
            this.tabControl1.Controls.Add(this.Startup);
            this.tabControl1.Controls.Add(this.Optimize);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.ShowToolTips = true;
            this.tabControl1.Size = new System.Drawing.Size(549, 405);
            this.tabControl1.TabIndex = 0;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // toolTip1
            // 
            this.toolTip1.StripAmpersands = true;
            this.toolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 403);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Advanced System Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Optimize.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.Startup.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.Tools.ResumeLayout(false);
            this.Info.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage Optimize;
        private System.Windows.Forms.TabPage Startup;
        private System.Windows.Forms.TabPage Tools;
        private ToolsUserControl toolsUserControl1;
        private System.Windows.Forms.TabPage Info;
        private SystemInfoUserControl systemInfoUserControl1;
        private System.Windows.Forms.TabControl tabControl1;
        public System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private ProgramsManagerUserControl programsManagerUserControl1;
        private TweaksUserControl tweaksUserControl1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private ServiceManagerUserControl serviceManagerUserControl1;
        private StartupProgramsManager startupProgramsManager1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

