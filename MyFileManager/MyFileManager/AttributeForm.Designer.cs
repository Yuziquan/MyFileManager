namespace MyFileManager
{
    partial class AttributeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AttributeForm));
            this.btnConfirm = new System.Windows.Forms.Button();
            this.lblFileName = new System.Windows.Forms.Label();
            this.lblFileType = new System.Windows.Forms.Label();
            this.lblFileLocation = new System.Windows.Forms.Label();
            this.lblFileSize = new System.Windows.Forms.Label();
            this.lblFileCreateTime = new System.Windows.Forms.Label();
            this.lblFileModifyTime = new System.Windows.Forms.Label();
            this.lblFileAccessTime = new System.Windows.Forms.Label();
            this.pnlLine1 = new System.Windows.Forms.Panel();
            this.pnlLine2 = new System.Windows.Forms.Panel();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.txtFileCreateTime = new System.Windows.Forms.TextBox();
            this.txtFileModifyTime = new System.Windows.Forms.TextBox();
            this.txtFileAccessTime = new System.Windows.Forms.TextBox();
            this.txtFileSize = new System.Windows.Forms.TextBox();
            this.txtFileLocation = new System.Windows.Forms.TextBox();
            this.txtFileType = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnConfirm
            // 
            resources.ApplyResources(this.btnConfirm, "btnConfirm");
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // lblFileName
            // 
            resources.ApplyResources(this.lblFileName, "lblFileName");
            this.lblFileName.Name = "lblFileName";
            // 
            // lblFileType
            // 
            resources.ApplyResources(this.lblFileType, "lblFileType");
            this.lblFileType.Name = "lblFileType";
            // 
            // lblFileLocation
            // 
            resources.ApplyResources(this.lblFileLocation, "lblFileLocation");
            this.lblFileLocation.Name = "lblFileLocation";
            // 
            // lblFileSize
            // 
            resources.ApplyResources(this.lblFileSize, "lblFileSize");
            this.lblFileSize.Name = "lblFileSize";
            // 
            // lblFileCreateTime
            // 
            resources.ApplyResources(this.lblFileCreateTime, "lblFileCreateTime");
            this.lblFileCreateTime.Name = "lblFileCreateTime";
            // 
            // lblFileModifyTime
            // 
            resources.ApplyResources(this.lblFileModifyTime, "lblFileModifyTime");
            this.lblFileModifyTime.Name = "lblFileModifyTime";
            // 
            // lblFileAccessTime
            // 
            resources.ApplyResources(this.lblFileAccessTime, "lblFileAccessTime");
            this.lblFileAccessTime.Name = "lblFileAccessTime";
            // 
            // pnlLine1
            // 
            this.pnlLine1.BackColor = System.Drawing.SystemColors.MenuText;
            resources.ApplyResources(this.pnlLine1, "pnlLine1");
            this.pnlLine1.Name = "pnlLine1";
            // 
            // pnlLine2
            // 
            this.pnlLine2.BackColor = System.Drawing.SystemColors.MenuText;
            resources.ApplyResources(this.pnlLine2, "pnlLine2");
            this.pnlLine2.Name = "pnlLine2";
            // 
            // txtFileName
            // 
            resources.ApplyResources(this.txtFileName, "txtFileName");
            this.txtFileName.Name = "txtFileName";
            // 
            // txtFileCreateTime
            // 
            resources.ApplyResources(this.txtFileCreateTime, "txtFileCreateTime");
            this.txtFileCreateTime.Name = "txtFileCreateTime";
            // 
            // txtFileModifyTime
            // 
            resources.ApplyResources(this.txtFileModifyTime, "txtFileModifyTime");
            this.txtFileModifyTime.Name = "txtFileModifyTime";
            // 
            // txtFileAccessTime
            // 
            resources.ApplyResources(this.txtFileAccessTime, "txtFileAccessTime");
            this.txtFileAccessTime.Name = "txtFileAccessTime";
            // 
            // txtFileSize
            // 
            resources.ApplyResources(this.txtFileSize, "txtFileSize");
            this.txtFileSize.Name = "txtFileSize";
            // 
            // txtFileLocation
            // 
            resources.ApplyResources(this.txtFileLocation, "txtFileLocation");
            this.txtFileLocation.Name = "txtFileLocation";
            // 
            // txtFileType
            // 
            resources.ApplyResources(this.txtFileType, "txtFileType");
            this.txtFileType.Name = "txtFileType";
            // 
            // AttributeForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtFileType);
            this.Controls.Add(this.txtFileLocation);
            this.Controls.Add(this.txtFileSize);
            this.Controls.Add(this.txtFileAccessTime);
            this.Controls.Add(this.txtFileModifyTime);
            this.Controls.Add(this.txtFileCreateTime);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.pnlLine2);
            this.Controls.Add(this.pnlLine1);
            this.Controls.Add(this.lblFileAccessTime);
            this.Controls.Add(this.lblFileModifyTime);
            this.Controls.Add(this.lblFileCreateTime);
            this.Controls.Add(this.lblFileSize);
            this.Controls.Add(this.lblFileLocation);
            this.Controls.Add(this.lblFileType);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.btnConfirm);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AttributeForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Label lblFileType;
        private System.Windows.Forms.Label lblFileLocation;
        private System.Windows.Forms.Label lblFileSize;
        private System.Windows.Forms.Label lblFileCreateTime;
        private System.Windows.Forms.Label lblFileModifyTime;
        private System.Windows.Forms.Label lblFileAccessTime;
        private System.Windows.Forms.Panel pnlLine1;
        private System.Windows.Forms.Panel pnlLine2;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.TextBox txtFileCreateTime;
        private System.Windows.Forms.TextBox txtFileModifyTime;
        private System.Windows.Forms.TextBox txtFileAccessTime;
        private System.Windows.Forms.TextBox txtFileSize;
        private System.Windows.Forms.TextBox txtFileLocation;
        private System.Windows.Forms.TextBox txtFileType;
    }
}