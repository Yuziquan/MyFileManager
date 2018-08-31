namespace MyFileManager
{
    partial class ThreadForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThreadForm));
            this.lvwThread = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ilstIcons = new System.Windows.Forms.ImageList(this.components);
            this.btnFinish = new System.Windows.Forms.Button();
            this.lblCurThreadNum = new System.Windows.Forms.Label();
            this.txtCurThreadNum = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblThreadsDescribe = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lvwThread
            // 
            this.lvwThread.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwThread.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lvwThread.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwThread.FullRowSelect = true;
            this.lvwThread.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lvwThread.LargeImageList = this.ilstIcons;
            this.lvwThread.Location = new System.Drawing.Point(2, 34);
            this.lvwThread.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lvwThread.Name = "lvwThread";
            this.lvwThread.Size = new System.Drawing.Size(926, 544);
            this.lvwThread.SmallImageList = this.ilstIcons;
            this.lvwThread.TabIndex = 0;
            this.lvwThread.UseCompatibleStateImageBehavior = false;
            this.lvwThread.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "线程ID";
            this.columnHeader1.Width = 90;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "基本优先级";
            this.columnHeader2.Width = 90;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "当前优先级";
            this.columnHeader3.Width = 90;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "当前状态";
            this.columnHeader4.Width = 270;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "启动时间";
            this.columnHeader5.Width = 130;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "内存地址";
            this.columnHeader6.Width = 130;
            // 
            // ilstIcons
            // 
            this.ilstIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilstIcons.ImageStream")));
            this.ilstIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.ilstIcons.Images.SetKeyName(0, "thread.png");
            // 
            // btnFinish
            // 
            this.btnFinish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinish.Location = new System.Drawing.Point(832, 588);
            this.btnFinish.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(87, 33);
            this.btnFinish.TabIndex = 1;
            this.btnFinish.Text = "结束线程";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // lblCurThreadNum
            // 
            this.lblCurThreadNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCurThreadNum.AutoSize = true;
            this.lblCurThreadNum.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurThreadNum.Location = new System.Drawing.Point(20, 595);
            this.lblCurThreadNum.Name = "lblCurThreadNum";
            this.lblCurThreadNum.Size = new System.Drawing.Size(56, 17);
            this.lblCurThreadNum.TabIndex = 2;
            this.lblCurThreadNum.Text = "线程数：";
            // 
            // txtCurThreadNum
            // 
            this.txtCurThreadNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCurThreadNum.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurThreadNum.Location = new System.Drawing.Point(67, 592);
            this.txtCurThreadNum.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCurThreadNum.Name = "txtCurThreadNum";
            this.txtCurThreadNum.Size = new System.Drawing.Size(34, 23);
            this.txtCurThreadNum.TabIndex = 3;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Location = new System.Drawing.Point(720, 589);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(87, 33);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblThreadsDescribe
            // 
            this.lblThreadsDescribe.AutoSize = true;
            this.lblThreadsDescribe.Location = new System.Drawing.Point(21, 13);
            this.lblThreadsDescribe.Name = "lblThreadsDescribe";
            this.lblThreadsDescribe.Size = new System.Drawing.Size(0, 17);
            this.lblThreadsDescribe.TabIndex = 5;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 6000;
            this.timer.Tick += new System.EventHandler(this.btnRefresh_Click);
            // 
            // ThreadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 637);
            this.Controls.Add(this.lblThreadsDescribe);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.txtCurThreadNum);
            this.Controls.Add(this.lblCurThreadNum);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.lvwThread);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ThreadForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "线程管理";
            this.Load += new System.EventHandler(this.ThreadForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwThread;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Label lblCurThreadNum;
        private System.Windows.Forms.TextBox txtCurThreadNum;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ImageList ilstIcons;
        private System.Windows.Forms.Label lblThreadsDescribe;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
     
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ColumnHeader columnHeader6;
    }
}