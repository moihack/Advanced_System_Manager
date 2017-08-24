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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.programsManagerUserControl1 = new AdvancedSystemManager.ProgramsManagerUserControl();
            this.tweaksUserControl1 = new AdvancedSystemManager.TweaksUserControl();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AccessibleName = "test";
            this.splitContainer1.Panel1.Controls.Add(this.programsManagerUserControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tweaksUserControl1);
            this.splitContainer1.Size = new System.Drawing.Size(541, 379);
            this.splitContainer1.SplitterDistance = 245;
            this.splitContainer1.TabIndex = 0;
            // 
            // programsManagerUserControl1
            // 
            this.programsManagerUserControl1.Location = new System.Drawing.Point(-1, -1);
            this.programsManagerUserControl1.Name = "programsManagerUserControl1";
            this.programsManagerUserControl1.Size = new System.Drawing.Size(540, 245);
            this.programsManagerUserControl1.TabIndex = 0;
            this.programsManagerUserControl1.Load += new System.EventHandler(this.programsManagerUserControl1_Load);
            // 
            // tweaksUserControl1
            // 
            this.tweaksUserControl1.Location = new System.Drawing.Point(0, 0);
            this.tweaksUserControl1.Name = "tweaksUserControl1";
            this.tweaksUserControl1.Size = new System.Drawing.Size(540, 129);
            this.tweaksUserControl1.TabIndex = 0;
            this.tweaksUserControl1.Load += new System.EventHandler(this.tweaksUserControl1_Load);
            // 
            // OptimizeUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "OptimizeUserControl";
            this.Size = new System.Drawing.Size(541, 379);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private ProgramsManagerUserControl programsManagerUserControl1;
        private TweaksUserControl tweaksUserControl1;
    }
}
