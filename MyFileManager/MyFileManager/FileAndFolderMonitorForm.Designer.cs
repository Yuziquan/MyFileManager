namespace MyFileManager
{
    partial class FileAndFolderMonitorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileAndFolderMonitorForm));
            this.lvwChanges = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnStart = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnStop = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnClear = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnSave = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSelectPath = new System.Windows.Forms.Button();
            this.lvwDisks = new System.Windows.Forms.ListView();
            this.ilstIcons = new System.Windows.Forms.ImageList(this.components);
            this.txtPath = new System.Windows.Forms.TextBox();
            this.chkSubDirectories = new System.Windows.Forms.CheckBox();
            this.chkAllDisks = new System.Windows.Forms.CheckBox();
            this.rbtnDisk = new System.Windows.Forms.RadioButton();
            this.rbtnPath = new System.Windows.Forms.RadioButton();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwChanges
            // 
            this.lvwChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwChanges.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lvwChanges.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwChanges.FullRowSelect = true;
            this.lvwChanges.Location = new System.Drawing.Point(12, 191);
            this.lvwChanges.Name = "lvwChanges";
            this.lvwChanges.Size = new System.Drawing.Size(960, 367);
            this.lvwChanges.TabIndex = 0;
            this.lvwChanges.UseCompatibleStateImageBehavior = false;
            this.lvwChanges.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "时间";
            this.columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "硬盘";
            this.columnHeader2.Width = 50;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "事件";
            this.columnHeader3.Width = 80;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "文件名";
            this.columnHeader4.Width = 200;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "路径";
            this.columnHeader5.Width = 230;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "详细说明";
            this.columnHeader6.Width = 310;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnStart,
            this.toolStripSeparator1,
            this.tsbtnStop,
            this.toolStripSeparator2,
            this.tsbtnClear,
            this.toolStripSeparator3,
            this.tsbtnSave});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(984, 44);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnStart
            // 
            this.tsbtnStart.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnStart.Image")));
            this.tsbtnStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnStart.Name = "tsbtnStart";
            this.tsbtnStart.Size = new System.Drawing.Size(60, 41);
            this.tsbtnStart.Text = "开始监控";
            this.tsbtnStart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnStart.Click += new System.EventHandler(this.tsbtnStart_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 44);
            // 
            // tsbtnStop
            // 
            this.tsbtnStop.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnStop.Image")));
            this.tsbtnStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnStop.Name = "tsbtnStop";
            this.tsbtnStop.Size = new System.Drawing.Size(60, 41);
            this.tsbtnStop.Text = "停止监控";
            this.tsbtnStop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnStop.Click += new System.EventHandler(this.tsbtnStop_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 44);
            // 
            // tsbtnClear
            // 
            this.tsbtnClear.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnClear.Image")));
            this.tsbtnClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnClear.Name = "tsbtnClear";
            this.tsbtnClear.Size = new System.Drawing.Size(84, 41);
            this.tsbtnClear.Text = "清空监控信息";
            this.tsbtnClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnClear.Click += new System.EventHandler(this.tsbtnClear_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 44);
            // 
            // tsbtnSave
            // 
            this.tsbtnSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnSave.Image")));
            this.tsbtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSave.Name = "tsbtnSave";
            this.tsbtnSave.Size = new System.Drawing.Size(84, 41);
            this.tsbtnSave.Text = "保存监控信息";
            this.tsbtnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnSave.Click += new System.EventHandler(this.tsbtnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnSelectPath);
            this.groupBox1.Controls.Add(this.lvwDisks);
            this.groupBox1.Controls.Add(this.txtPath);
            this.groupBox1.Controls.Add(this.chkSubDirectories);
            this.groupBox1.Controls.Add(this.chkAllDisks);
            this.groupBox1.Controls.Add(this.rbtnDisk);
            this.groupBox1.Controls.Add(this.rbtnPath);
            this.groupBox1.Location = new System.Drawing.Point(12, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(960, 140);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "监控设置";
            // 
            // btnSelectPath
            // 
            this.btnSelectPath.Location = new System.Drawing.Point(792, 26);
            this.btnSelectPath.Name = "btnSelectPath";
            this.btnSelectPath.Size = new System.Drawing.Size(75, 23);
            this.btnSelectPath.TabIndex = 6;
            this.btnSelectPath.Text = "选择";
            this.btnSelectPath.UseVisualStyleBackColor = true;
            this.btnSelectPath.Click += new System.EventHandler(this.btnSelectPath_Click);
            // 
            // lvwDisks
            // 
            this.lvwDisks.CheckBoxes = true;
            this.lvwDisks.FullRowSelect = true;
            this.lvwDisks.LargeImageList = this.ilstIcons;
            this.lvwDisks.Location = new System.Drawing.Point(233, 58);
            this.lvwDisks.Name = "lvwDisks";
            this.lvwDisks.Size = new System.Drawing.Size(634, 42);
            this.lvwDisks.SmallImageList = this.ilstIcons;
            this.lvwDisks.TabIndex = 5;
            this.lvwDisks.UseCompatibleStateImageBehavior = false;
            this.lvwDisks.View = System.Windows.Forms.View.List;
            // 
            // ilstIcons
            // 
            this.ilstIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilstIcons.ImageStream")));
            this.ilstIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.ilstIcons.Images.SetKeyName(0, "disk.png");
            this.ilstIcons.Images.SetKeyName(1, "CD_ROM.png");
            this.ilstIcons.Images.SetKeyName(2, "u_pan.png");
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(169, 26);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(575, 23);
            this.txtPath.TabIndex = 4;
            // 
            // chkSubDirectories
            // 
            this.chkSubDirectories.AutoSize = true;
            this.chkSubDirectories.Location = new System.Drawing.Point(37, 111);
            this.chkSubDirectories.Name = "chkSubDirectories";
            this.chkSubDirectories.Size = new System.Drawing.Size(183, 21);
            this.chkSubDirectories.TabIndex = 3;
            this.chkSubDirectories.Text = "级联监控指定路径中的子目录";
            this.chkSubDirectories.UseVisualStyleBackColor = true;
            // 
            // chkAllDisks
            // 
            this.chkAllDisks.AutoSize = true;
            this.chkAllDisks.Location = new System.Drawing.Point(152, 69);
            this.chkAllDisks.Name = "chkAllDisks";
            this.chkAllDisks.Size = new System.Drawing.Size(75, 21);
            this.chkAllDisks.TabIndex = 2;
            this.chkAllDisks.Text = "全盘监控";
            this.chkAllDisks.UseVisualStyleBackColor = true;
            this.chkAllDisks.CheckedChanged += new System.EventHandler(this.chkAllDisks_CheckedChanged);
            // 
            // rbtnDisk
            // 
            this.rbtnDisk.AutoSize = true;
            this.rbtnDisk.Location = new System.Drawing.Point(36, 67);
            this.rbtnDisk.Name = "rbtnDisk";
            this.rbtnDisk.Size = new System.Drawing.Size(98, 21);
            this.rbtnDisk.TabIndex = 1;
            this.rbtnDisk.TabStop = true;
            this.rbtnDisk.Text = "监控指定磁盘";
            this.rbtnDisk.UseVisualStyleBackColor = true;
            // 
            // rbtnPath
            // 
            this.rbtnPath.AutoSize = true;
            this.rbtnPath.Location = new System.Drawing.Point(37, 25);
            this.rbtnPath.Name = "rbtnPath";
            this.rbtnPath.Size = new System.Drawing.Size(98, 21);
            this.rbtnPath.TabIndex = 0;
            this.rbtnPath.TabStop = true;
            this.rbtnPath.Text = "监控指定路径";
            this.rbtnPath.UseVisualStyleBackColor = true;
            // 
            // FileAndFolderMonitorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.lvwChanges);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FileAndFolderMonitorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "文件/文件夹监控";
            this.Load += new System.EventHandler(this.FileAndFolderMonitorForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwChanges;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.CheckBox chkSubDirectories;
        private System.Windows.Forms.CheckBox chkAllDisks;
        private System.Windows.Forms.RadioButton rbtnDisk;
        private System.Windows.Forms.RadioButton rbtnPath;
        private System.Windows.Forms.ToolStripButton tsbtnStart;
        private System.Windows.Forms.ToolStripButton tsbtnStop;
        private System.Windows.Forms.ToolStripButton tsbtnClear;
        private System.Windows.Forms.ToolStripButton tsbtnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ListView lvwDisks;
        private System.Windows.Forms.ImageList ilstIcons;
        private System.Windows.Forms.Button btnSelectPath;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
    }
}