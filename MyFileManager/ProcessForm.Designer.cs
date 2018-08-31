namespace MyFileManager
{
    partial class ProcessForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProcessForm));
            this.lvwProcess = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmsProcess = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiThread = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFinish = new System.Windows.Forms.ToolStripMenuItem();
            this.ilstIcons = new System.Windows.Forms.ImageList(this.components);
            this.btnFinish = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblCurProcessNum = new System.Windows.Forms.Label();
            this.txtCurProcessNum = new System.Windows.Forms.TextBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.cmsProcess.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwProcess
            // 
            this.lvwProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwProcess.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.lvwProcess.ContextMenuStrip = this.cmsProcess;
            this.lvwProcess.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwProcess.FullRowSelect = true;
            this.lvwProcess.LargeImageList = this.ilstIcons;
            this.lvwProcess.Location = new System.Drawing.Point(3, 0);
            this.lvwProcess.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lvwProcess.Name = "lvwProcess";
            this.lvwProcess.Size = new System.Drawing.Size(924, 579);
            this.lvwProcess.SmallImageList = this.ilstIcons;
            this.lvwProcess.TabIndex = 0;
            this.lvwProcess.UseCompatibleStateImageBehavior = false;
            this.lvwProcess.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "进程名称";
            this.columnHeader1.Width = 130;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "进程ID";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "专用内存大小";
            this.columnHeader3.Width = 110;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "虚拟内存大小";
            this.columnHeader4.Width = 110;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "启动时间";
            this.columnHeader5.Width = 200;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "基本优先级";
            this.columnHeader6.Width = 120;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "路径";
            this.columnHeader7.Width = 250;
            // 
            // cmsProcess
            // 
            this.cmsProcess.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiThread,
            this.tsmiFinish});
            this.cmsProcess.Name = "cmsProcess";
            this.cmsProcess.Size = new System.Drawing.Size(197, 48);
            // 
            // tsmiThread
            // 
            this.tsmiThread.Name = "tsmiThread";
            this.tsmiThread.Size = new System.Drawing.Size(196, 22);
            this.tsmiThread.Text = "管理此进程包含的线程";
            this.tsmiThread.Click += new System.EventHandler(this.tsmiThread_Click);
            // 
            // tsmiFinish
            // 
            this.tsmiFinish.Name = "tsmiFinish";
            this.tsmiFinish.Size = new System.Drawing.Size(196, 22);
            this.tsmiFinish.Text = "结束此进程";
            this.tsmiFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // ilstIcons
            // 
            this.ilstIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilstIcons.ImageStream")));
            this.ilstIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.ilstIcons.Images.SetKeyName(0, "process.png");
            // 
            // btnFinish
            // 
            this.btnFinish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinish.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFinish.Location = new System.Drawing.Point(832, 589);
            this.btnFinish.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(87, 33);
            this.btnFinish.TabIndex = 1;
            this.btnFinish.Text = "结束进程";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRefresh.Location = new System.Drawing.Point(715, 589);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(87, 33);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblCurProcessNum
            // 
            this.lblCurProcessNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCurProcessNum.AutoSize = true;
            this.lblCurProcessNum.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurProcessNum.Location = new System.Drawing.Point(15, 605);
            this.lblCurProcessNum.Name = "lblCurProcessNum";
            this.lblCurProcessNum.Size = new System.Drawing.Size(172, 17);
            this.lblCurProcessNum.TabIndex = 3;
            this.lblCurProcessNum.Text = "当前进程数(包含隐藏的进程)：";
            // 
            // txtCurProcessNum
            // 
            this.txtCurProcessNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCurProcessNum.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurProcessNum.Location = new System.Drawing.Point(181, 604);
            this.txtCurProcessNum.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCurProcessNum.Name = "txtCurProcessNum";
            this.txtCurProcessNum.Size = new System.Drawing.Size(53, 22);
            this.txtCurProcessNum.TabIndex = 4;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 6000;
            this.timer.Tick += new System.EventHandler(this.btnRefresh_Click);
            // 
            // ProcessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 637);
            this.Controls.Add(this.txtCurProcessNum);
            this.Controls.Add(this.lblCurProcessNum);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.lvwProcess);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ProcessForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "进程管理";
            this.Load += new System.EventHandler(this.ProcessForm_Load);
            this.cmsProcess.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwProcess;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblCurProcessNum;
        private System.Windows.Forms.TextBox txtCurProcessNum;
        private System.Windows.Forms.ImageList ilstIcons;
        private System.Windows.Forms.ContextMenuStrip cmsProcess;
        private System.Windows.Forms.ToolStripMenuItem tsmiThread;
        private System.Windows.Forms.ToolStripMenuItem tsmiFinish;
        private System.Windows.Forms.Timer timer;
    }
}