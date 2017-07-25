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
            this.Optimize = new System.Windows.Forms.TabPage();
            this.optimizeUserControl1 = new AdvancedSystemManager.OptimizeUserControl();
            this.Services = new System.Windows.Forms.TabPage();
            this.serviceManagerUserControl1 = new AdvancedSystemManager.ServiceManagerUserControl();
            this.Tools = new System.Windows.Forms.TabPage();
            this.toolsUserControl1 = new AdvancedSystemManager.ToolsUserControl();
            this.Info = new System.Windows.Forms.TabPage();
            this.systemInfoUserControl1 = new AdvancedSystemManager.SystemInfoUserControl();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.Optimize.SuspendLayout();
            this.Services.SuspendLayout();
            this.Tools.SuspendLayout();
            this.Info.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Optimize
            // 
            this.Optimize.Controls.Add(this.optimizeUserControl1);
            this.Optimize.Location = new System.Drawing.Point(4, 22);
            this.Optimize.Name = "Optimize";
            this.Optimize.Size = new System.Drawing.Size(541, 379);
            this.Optimize.TabIndex = 3;
            this.Optimize.Text = "Optimize";
            this.Optimize.UseVisualStyleBackColor = true;
            // 
            // optimizeUserControl1
            // 
            this.optimizeUserControl1.Location = new System.Drawing.Point(-3, 0);
            this.optimizeUserControl1.Name = "optimizeUserControl1";
            this.optimizeUserControl1.Size = new System.Drawing.Size(541, 379);
            this.optimizeUserControl1.TabIndex = 0;
            this.optimizeUserControl1.Load += new System.EventHandler(this.optimizeUserControl1_Load);
            // 
            // Services
            // 
            this.Services.Controls.Add(this.serviceManagerUserControl1);
            this.Services.Location = new System.Drawing.Point(4, 22);
            this.Services.Name = "Services";
            this.Services.Size = new System.Drawing.Size(541, 379);
            this.Services.TabIndex = 2;
            this.Services.Text = "Startup Services";
            this.Services.UseVisualStyleBackColor = true;
            // 
            // serviceManagerUserControl1
            // 
            this.serviceManagerUserControl1.Location = new System.Drawing.Point(-4, 0);
            this.serviceManagerUserControl1.Name = "serviceManagerUserControl1";
            this.serviceManagerUserControl1.Size = new System.Drawing.Size(545, 383);
            this.serviceManagerUserControl1.TabIndex = 0;
            // 
            // Tools
            // 
            this.Tools.Controls.Add(this.toolsUserControl1);
            this.Tools.Location = new System.Drawing.Point(4, 22);
            this.Tools.Name = "Tools";
            this.Tools.Size = new System.Drawing.Size(541, 379);
            this.Tools.TabIndex = 1;
            this.Tools.Text = "Tools";
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
            this.tabControl1.Controls.Add(this.Services);
            this.tabControl1.Controls.Add(this.Optimize);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
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
            this.Services.ResumeLayout(false);
            this.Tools.ResumeLayout(false);
            this.Info.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage Optimize;
        private System.Windows.Forms.TabPage Services;
        private ServiceManagerUserControl serviceManagerUserControl1;
        private System.Windows.Forms.TabPage Tools;
        private ToolsUserControl toolsUserControl1;
        private System.Windows.Forms.TabPage Info;
        private SystemInfoUserControl systemInfoUserControl1;
        private System.Windows.Forms.TabControl tabControl1;
        private OptimizeUserControl optimizeUserControl1;
        public System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

