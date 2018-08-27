using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyFileManager
{
    public partial class ThreadForm : Form
    {
        //当前选中的进程
        private Process process;

        //当前进程中的所有线程
        private Dictionary<int, ProcessThread> curThreads = new Dictionary<int, ProcessThread>();

        public ThreadForm(string processName)
        {
            process = Process.GetProcessesByName(processName)[0];
            InitializeComponent();
        }


        private void ThreadForm_Load(object sender, EventArgs e)
        {
            lblThreadsDescribe.Text = "进程" + process.ProcessName + "中的线程的详细信息如下：";

            //显示所有线程
            ShowThreads();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //刷新界面
            RefreshDisplay();
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            //结束指定线程
            StopThread();
        }







        //显示所有线程
        private void ShowThreads()
        {
            lvwThread.Items.Clear();
            curThreads = new Dictionary<int, ProcessThread>();

            //当前选中进程的所有线程
            ProcessThreadCollection threads = process.Threads;

            //当前线程数
            txtCurThreadNum.Text = threads.Count.ToString();

            //开始数据更新
            lvwThread.BeginUpdate();

            foreach (ProcessThread thread in threads)
            {
                curThreads.Add(thread.Id, thread);

                //线程Id
                ListViewItem item = lvwThread.Items.Add(thread.Id.ToString(), IconsIndexes.Thread);

                //基本优先级
                item.SubItems.Add(thread.BasePriority.ToString());

                //当前优先级
                item.SubItems.Add(thread.CurrentPriority.ToString());

                //当前状态
                item.SubItems.Add(GetThreadState(thread));

                //启动时间
                item.SubItems.Add(thread.StartTime.ToLongTimeString());

                //内存地址
                item.SubItems.Add(thread.StartAddress.ToString());

            }

            //结束数据更新
            lvwThread.EndUpdate();
        }


        //结束指定线程
        private void StopThread()
        {
            if (lvwThread.SelectedItems.Count > 0)
            {
                try
                {
                    int id = Convert.ToInt32(lvwThread.SelectedItems[0].Text);
                    ProcessThread thread = curThreads[id];
                    thread.Dispose();

                    RefreshDisplay();
                }
                catch (Exception e)
                {
                    MessageBox.Show("无法关闭此线程！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("请选中一个线程！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        //刷新界面
        private void RefreshDisplay()
        {
            ShowThreads();
        }


        //获取指定线程的状态
        private string GetThreadState(ProcessThread thread)
        {
            string state = "";

            switch (thread.ThreadState)
            {
                case ThreadState.Initialized:
                    state = "线程已经初始化但尚未启动";
                    break;

                case ThreadState.Ready:
                    state = "线程准备在下一个可用的处理器上运行";
                    break;

                case ThreadState.Running:
                    state = "当前正在使用处理器";
                    break;

                case ThreadState.Standby:
                    state = "线程将要使用处理器";
                    break;

                case ThreadState.Terminated:
                    state = "线程已完成执行并退出";
                    break;

                case ThreadState.Transition:
                    state = "线程在可以执行前等待处理器之外的资源";
                    break;

                case ThreadState.Unknown:
                    state = "状态未知";
                    break;

                case ThreadState.Wait:
                    state = "正在等待外围操作完成或者资源释放";
                    break;

                default:
                    break;
            }

            return state;
        }


        //图标索引
        class IconsIndexes
        {
            public const int Thread = 0; //线程图标
        }


    }
}
