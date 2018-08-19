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
    public partial class AttributeForm : Form
    {
        public AttributeForm(string filePath)
        {
            InitializeComponent();

            //如果filePath是文件的路径
            if(File.Exists(filePath))
            {
                FileInfo fileInfo = new FileInfo(filePath);

                txtFileName.Text = fileInfo.Name;
                txtFileType.Text = fileInfo.Extension;
                txtFileLocation.Text = (fileInfo.DirectoryName != null) ? fileInfo.DirectoryName : null;
                txtFileSize.Text = ShowFileSize(fileInfo.Length);
                txtFileCreateTime.Text = fileInfo.CreationTimeUtc.ToString();
                txtFileModifyTime.Text = fileInfo.LastWriteTimeUtc.ToString();
                txtFileAccessTime.Text = fileInfo.LastAccessTimeUtc.ToString();
            }
            //如果filePath是文件夹的路径
            else if (Directory.Exists(filePath))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(filePath);

                txtFileName.Text = directoryInfo.Name;
                txtFileType.Text = "文件夹";
                txtFileLocation.Text = (directoryInfo.Parent != null) ? directoryInfo.Parent.FullName : null;
                txtFileSize.Text = ShowFileSize(GetDirectoryLength(filePath));
                txtFileCreateTime.Text = directoryInfo.CreationTimeUtc.ToString();
                txtFileModifyTime.Text = directoryInfo.LastWriteTimeUtc.ToString();
                txtFileAccessTime.Text = directoryInfo.LastAccessTimeUtc.ToString();
            }
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AboutForm_Load(object sender, EventArgs e)
        {

        }

        private void lblModifyTime_Click(object sender, EventArgs e)
        {

        }



        //获取目录的大小
        private long GetDirectoryLength(string dirPath)
        {
            long length = 0;

            DirectoryInfo directoryInfo = new DirectoryInfo(dirPath);

        
            //获取目录下所有文件的大小
            FileInfo[] fileInfos = directoryInfo.GetFiles();
            if (fileInfos.Length > 0)
            {
                foreach (FileInfo fileInfo in fileInfos)
                {
                    length += fileInfo.Length;
                }
            }
           

            //递归获取目录下所有文件夹的大小
            DirectoryInfo[] directoryInfos = directoryInfo.GetDirectories();
            if(directoryInfos.Length > 0)
            {
                foreach(DirectoryInfo dirInfo in directoryInfos)
                {
                    length += GetDirectoryLength(dirInfo.FullName);
                }
            }

            return length;
        }


        //以一定格式显示文件的大小
        public static string ShowFileSize(long fileSize)
        {
            string fileSizeStr = "";

            if (fileSize < 1024)
            {
                fileSizeStr = fileSize + " 字节";
            }
            else if (fileSize >= 1024 && fileSize < 1024 * 1024)
            {
                fileSizeStr = fileSize / 1024 + " KB(" + fileSize + "字节)";
            }
            else if (fileSize >= 1024 * 1024 && fileSize < 1024 * 1024 * 1024)
            {
                fileSizeStr = fileSize / (1024 * 1024) + " MB(" + fileSize + "字节)";
            }
            else if (fileSize >= 1024 * 1024 * 1024)
            {
                fileSizeStr = fileSize / (1024 * 1024 * 1024) + " GB(" + fileSize + "字节)";
            }

            return fileSizeStr;
        }


        //关闭对话框
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
