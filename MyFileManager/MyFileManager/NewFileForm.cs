using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace MyFileManager
{
    public partial class NewFileForm : Form
    {
        //当前路径
        private string curPath;

        //管理器的主窗体的一个引用
        private MainForm mainForm;


        public NewFileForm(string curPath, MainForm mainForm)
        {
            InitializeComponent();
            this.curPath = curPath;
            this.mainForm = mainForm;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string newFileName = txtNewFileName.Text;

            string newFilePath = Path.Combine(curPath, newFileName);

            //文件名不合法
            if (!IsValidFileName(newFileName))
            {
                MessageBox.Show("文件名不能包含下列任何字符:\r\n" + "\t\\/:*?\"<>|", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (File.Exists(newFilePath))
            {
                MessageBox.Show("在当前路径下存在同名的文件！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                File.Create(newFilePath);

                //更新文件列表
                mainForm.ShowFilesList(curPath, false);

                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }





        //检查文件名是否合法,文件名中不能包含字符\/:*?"<>|
        private bool IsValidFileName(string fileName)
        {
            bool isValid = true;

            //非法字符
            string errChar = "\\/:*?\"<>|";

            for (int i = 0; i < errChar.Length; i++)
            {
                if (fileName.Contains(errChar[i].ToString()))
                {
                    isValid = false;
                    break;
                }
            }

            return isValid;
        }

    }

}