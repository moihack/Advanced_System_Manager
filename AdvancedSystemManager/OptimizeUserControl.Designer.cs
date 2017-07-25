namespace AdvancedSystemManager
{
    partial class OptimizeUserControl
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.programsTab = new System.Windows.Forms.TabPage();
            this.noBtn = new System.Windows.Forms.Button();
            this.allBtn = new System.Windows.Forms.Button();
            this.svBtn = new System.Windows.Forms.Button();
            this.defBtn = new System.Windows.Forms.Button();
            this.programsManagerUserControl1 = new AdvancedSystemManager.ProgramsManagerUserControl();
            this.Tweaks = new System.Windows.Forms.TabPage();
            this.testBtn = new System.Windows.Forms.Button();
            this.opSum = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.opBtn = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tabControl1.SuspendLayout();
            this.programsTab.SuspendLayout();
            this.Tweaks.SuspendLayout();
            this.opSum.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.programsTab);
            this.tabControl1.Controls.Add(this.Tweaks);
            this.tabControl1.Controls.Add(this.opSum);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(541, 379);
            this.tabControl1.TabIndex = 0;
            // 
            // programsTab
            // 
            this.programsTab.Controls.Add(this.noBtn);
            this.programsTab.Controls.Add(this.allBtn);
            this.programsTab.Controls.Add(this.svBtn);
            this.programsTab.Controls.Add(this.defBtn);
            this.programsTab.Controls.Add(this.programsManagerUserControl1);
            this.programsTab.Location = new System.Drawing.Point(4, 22);
            this.programsTab.Name = "programsTab";
            this.programsTab.Padding = new System.Windows.Forms.Padding(3);
            this.programsTab.Size = new System.Drawing.Size(533, 353);
            this.programsTab.TabIndex = 0;
            this.programsTab.Text = "Programs";
            this.programsTab.UseVisualStyleBackColor = true;
            // 
            // noBtn
            // 
            this.noBtn.Location = new System.Drawing.Point(433, 228);
            this.noBtn.Name = "noBtn";
            this.noBtn.Size = new System.Drawing.Size(75, 23);
            this.noBtn.TabIndex = 4;
            this.noBtn.Text = "Select None";
            this.noBtn.UseVisualStyleBackColor = true;
            this.noBtn.Click += new System.EventHandler(this.noBtn_Click);
            // 
            // allBtn
            // 
            this.allBtn.Location = new System.Drawing.Point(433, 171);
            this.allBtn.Name = "allBtn";
            this.allBtn.Size = new System.Drawing.Size(75, 23);
            this.allBtn.TabIndex = 3;
            this.allBtn.Text = "Select All";
            this.allBtn.UseVisualStyleBackColor = true;
            this.allBtn.Click += new System.EventHandler(this.allBtn_Click);
            // 
            // svBtn
            // 
            this.svBtn.Location = new System.Drawing.Point(433, 104);
            this.svBtn.Name = "svBtn";
            this.svBtn.Size = new System.Drawing.Size(75, 23);
            this.svBtn.TabIndex = 2;
            this.svBtn.Text = "Save List";
            this.svBtn.UseVisualStyleBackColor = true;
            this.svBtn.Click += new System.EventHandler(this.svBtn_Click);
            // 
            // defBtn
            // 
            this.defBtn.Location = new System.Drawing.Point(433, 49);
            this.defBtn.Name = "defBtn";
            this.defBtn.Size = new System.Drawing.Size(75, 23);
            this.defBtn.TabIndex = 1;
            this.defBtn.Text = "Defaults";
            this.defBtn.UseVisualStyleBackColor = true;
            this.defBtn.Click += new System.EventHandler(this.defBtn_Click);
            // 
            // programsManagerUserControl1
            // 
            this.programsManagerUserControl1.Location = new System.Drawing.Point(-4, -1);
            this.programsManagerUserControl1.Name = "programsManagerUserControl1";
            this.programsManagerUserControl1.Size = new System.Drawing.Size(397, 358);
            this.programsManagerUserControl1.TabIndex = 0;
            // 
            // Tweaks
            // 
            this.Tweaks.Controls.Add(this.testBtn);
            this.Tweaks.Location = new System.Drawing.Point(4, 22);
            this.Tweaks.Name = "Tweaks";
            this.Tweaks.Padding = new System.Windows.Forms.Padding(3);
            this.Tweaks.Size = new System.Drawing.Size(533, 353);
            this.Tweaks.TabIndex = 1;
            this.Tweaks.Text = "Tweaks";
            this.Tweaks.UseVisualStyleBackColor = true;
            // 
            // testBtn
            // 
            this.testBtn.Location = new System.Drawing.Point(423, 306);
            this.testBtn.Name = "testBtn";
            this.testBtn.Size = new System.Drawing.Size(75, 23);
            this.testBtn.TabIndex = 0;
            this.testBtn.Text = "test";
            this.testBtn.UseVisualStyleBackColor = true;
            this.testBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // opSum
            // 
            this.opSum.Controls.Add(this.textBox1);
            this.opSum.Controls.Add(this.opBtn);
            this.opSum.Controls.Add(this.progressBar1);
            this.opSum.Location = new System.Drawing.Point(4, 22);
            this.opSum.Name = "opSum";
            this.opSum.Padding = new System.Windows.Forms.Padding(3);
            this.opSum.Size = new System.Drawing.Size(533, 353);
            this.opSum.TabIndex = 2;
            this.opSum.Text = "Summary";
            this.opSum.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(172, 152);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // opBtn
            // 
            this.opBtn.Location = new System.Drawing.Point(427, 286);
            this.opBtn.Name = "opBtn";
            this.opBtn.Size = new System.Drawing.Size(75, 23);
            this.opBtn.TabIndex = 1;
            this.opBtn.Text = "Optimize!";
            this.opBtn.UseVisualStyleBackColor = true;
            this.opBtn.Click += new System.EventHandler(this.opBtn_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(6, 321);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(515, 23);
            this.progressBar1.TabIndex = 0;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // OptimizeUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "OptimizeUserControl";
            this.Size = new System.Drawing.Size(541, 379);
            this.tabControl1.ResumeLayout(false);
            this.programsTab.ResumeLayout(false);
            this.Tweaks.ResumeLayout(false);
            this.opSum.ResumeLayout(false);
            this.opSum.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage programsTab;
        private System.Windows.Forms.TabPage Tweaks;
        private System.Windows.Forms.Button testBtn;
        private System.Windows.Forms.Button svBtn;
        private System.Windows.Forms.Button defBtn;
        private System.Windows.Forms.Button allBtn;
        private System.Windows.Forms.Button noBtn;
        private System.Windows.Forms.TabPage opSum;
        private System.Windows.Forms.Button opBtn;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox textBox1;
        private ProgramsManagerUserControl programsManagerUserControl1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}
