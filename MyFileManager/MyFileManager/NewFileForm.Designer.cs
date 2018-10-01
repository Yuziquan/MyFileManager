namespace MyFileManager
{
    partial class NewFileForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewFileForm));
            this.lblNewFile = new System.Windows.Forms.Label();
            this.txtNewFileName = new System.Windows.Forms.TextBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblNewFile
            // 
            this.lblNewFile.AutoSize = true;
            this.lblNewFile.Location = new System.Drawing.Point(70, 55);
            this.lblNewFile.Name = "lblNewFile";
            this.lblNewFile.Size = new System.Drawing.Size(56, 17);
            this.lblNewFile.TabIndex = 0;
            this.lblNewFile.Text = "文件名：";
            // 
            // txtNewFileName
            // 
            this.txtNewFileName.Location = new System.Drawing.Point(123, 52);
            this.txtNewFileName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNewFileName.Name = "txtNewFileName";
            this.txtNewFileName.Size = new System.Drawing.Size(324, 23);
            this.txtNewFileName.TabIndex = 1;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(413, 133);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(69, 22);
            this.btnConfirm.TabIndex = 2;
            this.btnConfirm.Text = "确定";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(312, 133);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(73, 22);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // NewFileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 170);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.txtNewFileName);
            this.Controls.Add(this.lblNewFile);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "NewFileForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新建文件";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNewFile;
        private System.Windows.Forms.TextBox txtNewFileName;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
    }
}