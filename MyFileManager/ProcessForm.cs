using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Windows.Forms;

namespace MyFileManager
{
    
    public partial class ProcessForm : Form
    {
        public ProcessForm()
        {
            InitializeComponent();
        }

        private void ProcessForm_Load(object sender, EventArgs e)
        {
            //显示进程列表
            ShowProcesses();
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //刷新界面
            RefreshDisplay();
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            //结束指定进程
            StopProcess();
        }


        private void tsmiThread_Click(object sender, EventArgs e)
        {
            if (lvwProcess.SelectedItems.Count > 0)
            {
                string processName = lvwProcess.SelectedItems[0].Text;

                //显示对应的线程管理窗口
                ThreadForm threadForm = new ThreadForm(processName);
                threadForm.Show();
            }
        }





        //显示进程列表
        private void ShowProcesses()
        {
            lvwProcess.Items.Clear();

            //获取本机的当前所有正在运行的进程
            Process[] processesList = Process.GetProcesses();

            //当前进程数
            txtCurProcessNum.Text = processesList.Length.ToString();

            //有些进程无法获取启动时间和文件名信息，所以要用try/catch
            try
            {
                foreach (Process process in processesList)
                {
                    //进程名称
                    ListViewItem item = lvwProcess.Items.Add(process.ProcessName, IconsIndexes.Process);

                    //进程Id
                    item.SubItems.Add(process.Id.ToString());

                    //专用内存大小
                    item.SubItems.Add(AttributeForm.ShowFileSize(process.PrivateMemorySize64).Split('(')[0]);

                    //虚拟内存大小
                    item.SubItems.Add(AttributeForm.ShowFileSize(process.VirtualMemorySize64).Split('(')[0]);

                    //启动时间
                    item.SubItems.Add(process.StartTime.ToLongDateString() + process.StartTime.ToLongTimeString());

                    //基本优先级
                    item.SubItems.Add(process.BasePriority.ToString());

                    //路径 
                    item.SubItems.Add(process.MainModule.FileName);

                }

            }
            catch(Exception e)
            {

            }

        }


        //结束指定进程
        private void StopProcess()
        {
            if(lvwProcess.SelectedItems.Count > 0)
            {
                try
                {
                    string processName = lvwProcess.SelectedItems[0].Text;
                    Process process = Process.GetProcessesByName(processName)[0];

                    process.Kill();

                    RefreshDisplay();
                }
                catch(Exception e)
                {
                    MessageBox.Show("无法关闭此进程！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("请选中一个进程！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //刷新界面
        private void RefreshDisplay()
        {
            //显示进程列表
            ShowProcesses();
        }



        //图标索引
        class IconsIndexes
        {
            public const int Process = 0; //进程图标
        }
    }


}
