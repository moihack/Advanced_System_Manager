namespace AdvancedSystemManager
{
    partial class ProgramsManagerUserControl
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
            this.components = new System.ComponentModel.Container();
            this.listView1 = new System.Windows.Forms.ListView();
            this.ProgramName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Publisher = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EstSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.noBtn = new System.Windows.Forms.Button();
            this.allBtn = new System.Windows.Forms.Button();
            this.svBtn = new System.Windows.Forms.Button();
            this.defBtn = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.Version = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.listView1.CheckBoxes = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ProgramName,
            this.Publisher,
            this.EstSize,
            this.Version});
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(447, 245);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // ProgramName
            // 
            this.ProgramName.Text = "Program Name";
            this.ProgramName.Width = 150;
            // 
            // Publisher
            // 
            this.Publisher.Text = "Publisher";
            this.Publisher.Width = 120;
            // 
            // EstSize
            // 
            this.EstSize.Text = "Size";
            this.EstSize.Width = 65;
            // 
            // noBtn
            // 
            this.noBtn.Location = new System.Drawing.Point(453, 90);
            this.noBtn.Name = "noBtn";
            this.noBtn.Size = new System.Drawing.Size(75, 23);
            this.noBtn.TabIndex = 8;
            this.noBtn.Text = "Select None";
            this.noBtn.UseVisualStyleBackColor = true;
            this.noBtn.Click += new System.EventHandler(this.noBtn_Click);
            // 
            // allBtn
            // 
            this.allBtn.Location = new System.Drawing.Point(453, 61);
            this.allBtn.Name = "allBtn";
            this.allBtn.Size = new System.Drawing.Size(75, 23);
            this.allBtn.TabIndex = 7;
            this.allBtn.Text = "Select All";
            this.allBtn.UseVisualStyleBackColor = true;
            this.allBtn.Click += new System.EventHandler(this.allBtn_Click);
            // 
            // svBtn
            // 
            this.svBtn.Location = new System.Drawing.Point(453, 3);
            this.svBtn.Name = "svBtn";
            this.svBtn.Size = new System.Drawing.Size(75, 23);
            this.svBtn.TabIndex = 6;
            this.svBtn.Text = "Save List";
            this.toolTip1.SetToolTip(this.svBtn, "Save programs list to programs.txt");
            this.svBtn.UseVisualStyleBackColor = true;
            this.svBtn.Click += new System.EventHandler(this.svBtn_Click);
            // 
            // defBtn
            // 
            this.defBtn.Location = new System.Drawing.Point(453, 32);
            this.defBtn.Name = "defBtn";
            this.defBtn.Size = new System.Drawing.Size(75, 23);
            this.defBtn.TabIndex = 5;
            this.defBtn.Text = "Defaults";
            this.defBtn.UseVisualStyleBackColor = true;
            this.defBtn.Click += new System.EventHandler(this.defBtn_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // Version
            // 
            this.Version.Text = "Version";
            this.Version.Width = 85;
            // 
            // ProgramsManagerUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.noBtn);
            this.Controls.Add(this.allBtn);
            this.Controls.Add(this.svBtn);
            this.Controls.Add(this.defBtn);
            this.Controls.Add(this.listView1);
            this.Name = "ProgramsManagerUserControl";
            this.Size = new System.Drawing.Size(540, 245);
            this.Load += new System.EventHandler(this.ServiceManagerUserControl_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader ProgramName;
        private System.Windows.Forms.ColumnHeader Publisher;
        private System.Windows.Forms.ColumnHeader EstSize;
        private System.Windows.Forms.Button noBtn;
        private System.Windows.Forms.Button allBtn;
        private System.Windows.Forms.Button svBtn;
        private System.Windows.Forms.Button defBtn;
        public System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ColumnHeader Version;
    }
}
