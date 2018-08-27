namespace MyFileManager
{
    partial class PrivilegeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrivilegeForm));
            this.lvwGroupOrUserName = new System.Windows.Forms.ListView();
            this.ilstIcons = new System.Windows.Forms.ImageList(this.components);
            this.lvwPrivilege = new System.Windows.Forms.ListView();
            this.lblGroupOrUserName = new System.Windows.Forms.Label();
            this.lblPrivilege = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblObjectName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lvwGroupOrUserName
            // 
            this.lvwGroupOrUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwGroupOrUserName.FullRowSelect = true;
            this.lvwGroupOrUserName.LargeImageList = this.ilstIcons;
            this.lvwGroupOrUserName.Location = new System.Drawing.Point(13, 66);
            this.lvwGroupOrUserName.Name = "lvwGroupOrUserName";
            this.lvwGroupOrUserName.Size = new System.Drawing.Size(286, 240);
            this.lvwGroupOrUserName.SmallImageList = this.ilstIcons;
            this.lvwGroupOrUserName.TabIndex = 0;
            this.lvwGroupOrUserName.UseCompatibleStateImageBehavior = false;
            this.lvwGroupOrUserName.View = System.Windows.Forms.View.List;
            this.lvwGroupOrUserName.SelectedIndexChanged += new System.EventHandler(this.lvwGroupOrUserName_SelectedIndexChanged);
            // 
            // ilstIcons
            // 
            this.ilstIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilstIcons.ImageStream")));
            this.ilstIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.ilstIcons.Images.SetKeyName(0, "group_or_user.png");
            this.ilstIcons.Images.SetKeyName(1, "privilege.png");
            // 
            // lvwPrivilege
            // 
            this.lvwPrivilege.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwPrivilege.CheckBoxes = true;
            this.lvwPrivilege.FullRowSelect = true;
            this.lvwPrivilege.LargeImageList = this.ilstIcons;
            this.lvwPrivilege.Location = new System.Drawing.Point(308, 105);
            this.lvwPrivilege.Name = "lvwPrivilege";
            this.lvwPrivilege.Size = new System.Drawing.Size(288, 158);
            this.lvwPrivilege.SmallImageList = this.ilstIcons;
            this.lvwPrivilege.TabIndex = 1;
            this.lvwPrivilege.UseCompatibleStateImageBehavior = false;
            this.lvwPrivilege.View = System.Windows.Forms.View.List;
            this.lvwPrivilege.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvwPrivilege_ItemChecked);
            // 
            // lblGroupOrUserName
            // 
            this.lblGroupOrUserName.AutoSize = true;
            this.lblGroupOrUserName.Location = new System.Drawing.Point(9, 45);
            this.lblGroupOrUserName.Name = "lblGroupOrUserName";
            this.lblGroupOrUserName.Size = new System.Drawing.Size(80, 17);
            this.lblGroupOrUserName.TabIndex = 2;
            this.lblGroupOrUserName.Text = "组或用户名：";
            // 
            // lblPrivilege
            // 
            this.lblPrivilege.AutoSize = true;
            this.lblPrivilege.Location = new System.Drawing.Point(305, 85);
            this.lblPrivilege.Name = "lblPrivilege";
            this.lblPrivilege.Size = new System.Drawing.Size(43, 17);
            this.lblPrivilege.TabIndex = 3;
            this.lblPrivilege.Text = "label2";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.Location = new System.Drawing.Point(513, 319);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 4;
            this.btnConfirm.Text = "确定";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "对象名称：";
            // 
            // lblObjectName
            // 
            this.lblObjectName.AutoSize = true;
            this.lblObjectName.Location = new System.Drawing.Point(75, 9);
            this.lblObjectName.Name = "lblObjectName";
            this.lblObjectName.Size = new System.Drawing.Size(43, 17);
            this.lblObjectName.TabIndex = 7;
            this.lblObjectName.Text = "label1";
            // 
            // PrivilegeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 354);
            this.Controls.Add(this.lblObjectName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.lblPrivilege);
            this.Controls.Add(this.lblGroupOrUserName);
            this.Controls.Add(this.lvwPrivilege);
            this.Controls.Add(this.lvwGroupOrUserName);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "PrivilegeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "权限管理";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwGroupOrUserName;
        private System.Windows.Forms.Label lblGroupOrUserName;
        private System.Windows.Forms.Label lblPrivilege;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.ImageList ilstIcons;
        private System.Windows.Forms.ListView lvwPrivilege;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblObjectName;
    }
}