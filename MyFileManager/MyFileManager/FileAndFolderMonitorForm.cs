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
    public partial class FileAndFolderMonitorForm : Form
    {
        //一系列监控器
        private FileSystemWatcher[] fileSystemWatchers;

        //定义传递FileSystemEventArgs对象的委托，用于文件发生Created、Deleted、Changed事件时更新UI界面（lvwChanges）
        private delegate void SetNormalLogTextEventHandler(FileSystemEventArgs e);

        //定义传递RenamedEventArgs对象的委托，用于文件发生Renamed事件时更新UI界面（lvwChanges）
        private delegate void SetRenameLogTextEventHandler(RenamedEventArgs e);

       
        
        public FileAndFolderMonitorForm()
        {
            InitializeComponent();
        }

        private void FileAndFolderMonitorForm_Load(object sender, EventArgs e)
        {
            //初始化界面
            InitDisplay();
        }

        private void tsbtnStart_Click(object sender, EventArgs e)
        {
            //开始监控
            StartMonitor();
        }

        private void tsbtnStop_Click(object sender, EventArgs e)
        {
            //停止监控
            StopMonitor();
        }

        private void tsbtnClear_Click(object sender, EventArgs e)
        {
            //清空监控信息
            Clear();
        }

        private void tsbtnSave_Click(object sender, EventArgs e)
        {
            //保存监控信息
            Save();
        }


        private void btnSelectPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.ShowNewFolderButton = false;
            folderBrowserDialog.RootFolder = Environment.SpecialFolder.Desktop;
            folderBrowserDialog.Description = "请选择需要监控的目录:";

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void chkAllDisks_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllDisks.Checked)
            {
                foreach (ListViewItem item in lvwDisks.Items)
                {
                    item.Checked = true;
                }
            }
            else
            {
                foreach (ListViewItem item in lvwDisks.Items)
                {
                    item.Checked = false;
                }
            }
        }








        //初始化界面
        private void InitDisplay()
        {
            DriveInfo[] driveInfos = DriveInfo.GetDrives();

            foreach (DriveInfo info in driveInfos)
            {
                ListViewItem item = null;

                switch (info.DriveType)
                {

                    //固定磁盘
                    case DriveType.Fixed:

                        item = lvwDisks.Items.Add("本地磁盘(" + info.Name.Split('\\')[0] + ")");
                        item.ImageIndex = IconsIndexes.FixedDrive;
                        break;

                    //光驱
                    case DriveType.CDRom:
                    
                        item = lvwDisks.Items.Add("光驱(" + info.Name.Split('\\')[0] + ")");
                        item.ImageIndex = IconsIndexes.CDRom;
                        break;

                    //可移动磁盘
                    case DriveType.Removable:

                        item = lvwDisks.Items.Add("可移动磁盘(" + info.Name.Split('\\')[0] + ")");
                        item.ImageIndex = IconsIndexes.RemovableDisk;
                        break;
                }
            }
        }



        //开始监控
        private void StartMonitor()
        {
            if (rbtnPath.Checked)
            {
                if (!string.IsNullOrEmpty(txtPath.Text))
                {
                    fileSystemWatchers = new FileSystemWatcher[1];
                    fileSystemWatchers[0] = new FileSystemWatcher();

                    //设置要监视的目录的路径
                    fileSystemWatchers[0].Path = txtPath.Text;

                    //是否监控指定路径下的子目录
                    fileSystemWatchers[0].IncludeSubdirectories = chkSubDirectories.Checked;

                    fileSystemWatchers[0].NotifyFilter = NotifyFilters.FileName | NotifyFilters.DirectoryName
                        | NotifyFilters.Size;

                    //启用监控
                    fileSystemWatchers[0].EnableRaisingEvents = true;

                    //绑定相应事件触发后处理数据的方法
                    fileSystemWatchers[0].Created += new FileSystemEventHandler(SetNormalLogTextEvent);
                    fileSystemWatchers[0].Deleted += new FileSystemEventHandler(SetNormalLogTextEvent);
                    fileSystemWatchers[0].Changed += new FileSystemEventHandler(SetNormalLogTextEvent);
                    fileSystemWatchers[0].Renamed += new RenamedEventHandler(SetRenameLogTextEvent);
                }
                else
                {
                    MessageBox.Show("请选择需要监控的路径！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else if(rbtnDisk.Checked)
            {
                int checkedCount = lvwDisks.CheckedItems.Count;

                if (checkedCount > 0)
                {
                    fileSystemWatchers = new FileSystemWatcher[checkedCount];

                    for(int i = 0; i < checkedCount; i++)
                    {
                        fileSystemWatchers[i] = new FileSystemWatcher();

                        //设置要监视的目录的路径
                        fileSystemWatchers[i].Path = lvwDisks.CheckedItems[i].Text.Split('(')[1].Split(')')[0] + "\\";

                        //是否监控指定路径下的子目录
                        fileSystemWatchers[i].IncludeSubdirectories = chkSubDirectories.Checked;

                        fileSystemWatchers[i].NotifyFilter = NotifyFilters.FileName | NotifyFilters.DirectoryName
                            | NotifyFilters.Size;

                        //启用监控
                        fileSystemWatchers[i].EnableRaisingEvents = true;

                        //绑定相应事件触发后处理数据的方法
                        fileSystemWatchers[i].Created += new FileSystemEventHandler(SetNormalLogTextEvent);
                        fileSystemWatchers[i].Deleted += new FileSystemEventHandler(SetNormalLogTextEvent);
                        fileSystemWatchers[i].Changed += new FileSystemEventHandler(SetNormalLogTextEvent);
                        fileSystemWatchers[i].Renamed += new RenamedEventHandler(SetRenameLogTextEvent);
                    }
                }
                else
                {
                    MessageBox.Show("请选择需要监控的磁盘！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                MessageBox.Show("请选择需要监控的路径/磁盘！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            tsbtnStart.Enabled = false;
            tsbtnStop.Enabled = true;
        }



        //停止监控
        private void StopMonitor()
        {
            foreach(FileSystemWatcher fsw in fileSystemWatchers)
            {
                //不启用监控
                fsw.EnableRaisingEvents = false;
            }

            tsbtnStart.Enabled = true;
            tsbtnStop.Enabled = false;
        }


        //清空监控信息
        private void Clear()
        {
            lvwChanges.Items.Clear();
        }


        //保存监控信息
        private void Save()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "将监控日志保存为";
            saveFileDialog.InitialDirectory = Application.StartupPath + "\\Logs";
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.FileName = DateTime.Now.ToString("yyyyMMdd hh-mm-ss") + ".log";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName);

                for (int i = 0; i < lvwChanges.Items.Count; i++)
                {
                    string log = "[时间：" + lvwChanges.Items[i].Text + " ] " +
                        " [硬盘：" + lvwChanges.Items[i].SubItems[1].Text + " ] " +
                        " [事件：" + lvwChanges.Items[i].SubItems[2].Text + " ] " +
                        " [文件名：" + lvwChanges.Items[i].SubItems[3].Text + " ] " +
                        " [路径：" + lvwChanges.Items[i].SubItems[4].Text + " ] " +
                        " [详细说明：" + lvwChanges.Items[i].SubItems[5].Text + " ] ";

                    streamWriter.WriteLine(log);
                    streamWriter.WriteLine();
                }

                streamWriter.Close();
            }
        }



        //用于文件发生Created、Deleted、Changed事件时更新UI界面（lvwChanges）
        private void SetNormalLogText(FileSystemEventArgs e)
        {
            string[] pathStrArray = e.FullPath.Split('\\');

            //不监控回收站下的文件
            if(pathStrArray[1] != "$Recycle.Bin")
            {
                //开始数据更新
                lvwChanges.BeginUpdate();

                //时间
                ListViewItem item = new ListViewItem(DateTime.Now.ToString());

                //硬盘
                item.SubItems.Add(pathStrArray[0]);

                //事件
                item.SubItems.Add(e.ChangeType.ToString());

                //文件名
                item.SubItems.Add(pathStrArray[pathStrArray.Length - 1]);

                //路径
                item.SubItems.Add(e.FullPath);

                //详细说明
                switch (e.ChangeType)
                {
                    case WatcherChangeTypes.Created:

                        item.ForeColor = Color.Blue;
                        item.SubItems.Add("在" + pathStrArray[0].Split(':')[0] + "盘中创建了 "
                            + pathStrArray[pathStrArray.Length - 1] + " 文件");
                        break;

                    case WatcherChangeTypes.Deleted:

                        item.ForeColor = Color.Red;
                        item.SubItems.Add("在" + pathStrArray[0].Split(':')[0] + "盘中删除了 "
                            + pathStrArray[pathStrArray.Length - 1] + " 文件");
                        break;

                    case WatcherChangeTypes.Changed:

                        item.ForeColor = Color.Green;
                        item.SubItems.Add("在" + pathStrArray[0].Split(':')[0] + "盘中修改了 "
                           + pathStrArray[pathStrArray.Length - 1] + " 文件");
                        break;
                }

                lvwChanges.Items.Add(item);

                //结束数据更新
                lvwChanges.EndUpdate();
            }
        }



        //用于文件发生Renamed事件时更新UI界面（lvwChanges）
        private void SetRenameLogText(RenamedEventArgs e)
        {
            string[] oldPathStrArray = e.OldFullPath.Split('\\');
            string[] newPathStrArray = e.Name.Split('\\');

            //开始数据更新
            lvwChanges.BeginUpdate();

            //时间
            ListViewItem item = new ListViewItem(DateTime.Now.ToString());

            //硬盘
            item.SubItems.Add(oldPathStrArray[0]);

            //事件
            item.SubItems.Add(e.ChangeType.ToString());

            //文件名的改变
            item.SubItems.Add(oldPathStrArray[oldPathStrArray.Length - 1] + " -> "
                 + newPathStrArray[newPathStrArray.Length - 1]);

            //路径
            item.SubItems.Add(e.FullPath);

            //详细说明
            item.SubItems.Add("在" + oldPathStrArray[0].Split(':')[0] + "盘中将 "
                           + oldPathStrArray[oldPathStrArray.Length - 1] + " 文件重命名为 " +
                           newPathStrArray[newPathStrArray.Length - 1] + " 文件");

            item.ForeColor = Color.Yellow;

            lvwChanges.Items.Add(item);

            //结束数据更新
            lvwChanges.EndUpdate();
        }


        //文件增删改时被调用的处理方法
        private void SetNormalLogTextEvent(object sender, FileSystemEventArgs e)
        {
            //当前线程不是创建lvwChanges的线程时InvokeRequired为true
            if (lvwChanges.InvokeRequired)
            {
                //使用委托将更新界面的方法发送到UI主线程（创建lvwChanges的线程）中执行
                lvwChanges.Invoke(new SetNormalLogTextEventHandler(SetNormalLogText), new object[] { e });
            }
        }

        //文件重命名时被调用的处理方法
        private void SetRenameLogTextEvent(object sender, RenamedEventArgs e)
        {
            //当前线程不是创建lvwChanges的线程时InvokeRequired为true
            if (lvwChanges.InvokeRequired)
            {
                //使用委托将更新界面的方法发送到UI主线程（创建lvwChanges的线程）中执行
                lvwChanges.Invoke(new SetRenameLogTextEventHandler(SetRenameLogText), new object[] { e });
            }
        }



        //图标索引
        class IconsIndexes
        {
            public const int FixedDrive = 0; //固定磁盘
            public const int CDRom = 1; //光驱
            public const int RemovableDisk = 2; //可移动磁盘
        }

    }
}
