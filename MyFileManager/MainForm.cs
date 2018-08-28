using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using Microsoft.VisualBasic.Devices;
using System.Threading;
using System.Security.AccessControl;

namespace MyFileManager
{
    public partial class MainForm : Form
    {
        //当前路径
        private string curFilePath = "";

        //当前选中的树节点（目录节点）
        private TreeNode curSelectedNode = null;

        //是否移动文件
        private bool isMove = false;

        //待复制并粘贴的文件\文件夹的源路径
        private string[] copyFilesSourcePaths = new string[200];

        //用户的历史访问路径的第一个路径节点
        private DoublyLinkedListNode firstPathNode = new DoublyLinkedListNode();

        //当前路径节点
        private DoublyLinkedListNode curPathNode = null;

        //要搜索的文件名
        private string fileName;

        //是否第一次初始化tvwDirectory
        private bool isInitializeTvwDirectory = true;

        public MainForm()
        {
            InitializeComponent();
        }



        private void MainForm_Load(object sender, EventArgs e)
        {
            //初始化相关“查看”选项
            InitViewChecks();

            //初始化管理器界面的显示
            InitDisplay();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            //窗体大小改变时，地址栏长度也随之改变
            tscboAddress.Width = this.Width - 290;
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            //窗体大小改变时，地址栏长度也随之改变
            tscboAddress.Width = this.Width - 290;
        }


        private void tsmiNewFolder_Click(object sender, EventArgs e)
        {
            //新建文件夹
            CreateFolder();
        }

        private void tsmiNewFile_Click(object sender, EventArgs e)
        {
            //新建文件
            CreateFile();
        }

        private void tsmiPrivilege_Click(object sender, EventArgs e)
        {
            //显示权限管理窗口
            ShowPrivilegeForm();
        }

        private void tsmiProperties_Click(object sender, EventArgs e)
        {
            //显示属性窗口
            ShowAttributeForm();
        }





        private void tsmiCopy_Click(object sender, EventArgs e)
        {
            //复制文件
            CopyFiles();
        }

        private void tsmiPaste_Click(object sender, EventArgs e)
        {
            //粘贴文件
            PasteFiles();
        }

        private void tsmiCut_Click(object sender, EventArgs e)
        {
            //剪切文件
            CutFiles();
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            //删除文件
            DeleteFiles();
        }

       


        private void tsmiToolbar_Click(object sender, EventArgs e)
        {
            //设置工具栏是否可见
            tsMain.Visible = !tsMain.Visible;

            tsmiToolbar.Checked = !tsmiToolbar.Checked;
        }

        private void tsmiStatusbar_Click(object sender, EventArgs e)
        {
            //设置状态栏是否可见
            ssFooter.Visible = !ssFooter.Visible;

            tsmiStatusbar.Checked = !tsmiStatusbar.Checked;
        }

        private void tsmiBigIcon_Click(object sender, EventArgs e)
        {
            ResetViewChecks();
            tsmiBigIcon.Checked = true;
            tsmiBigIcon1.Checked = true;
            lvwFiles.View = View.LargeIcon;
        }

        private void tsmiSmallIcon_Click(object sender, EventArgs e)
        {
            ResetViewChecks();
            tsmiSmallIcon.Checked = true;
            tsmiSmallIcon1.Checked = true;
            lvwFiles.View = View.SmallIcon;
        }

        private void tsmiList_Click(object sender, EventArgs e)
        {
            ResetViewChecks();
            tsmiList.Checked = true;
            tsmiList1.Checked = true;
            lvwFiles.View = View.List;
        }

        private void tsmiDetailedInfo_Click(object sender, EventArgs e)
        {
            ResetViewChecks();
            tsmiDetailedInfo.Checked = true;
            tsmiDetailedInfo1.Checked = true;
            lvwFiles.View = View.Details;
        }

        private void tsmiRefresh_Click(object sender, EventArgs e)
        {
            ShowFilesList(curFilePath, false);
        }




        private void tsmiProcessThread_Click(object sender, EventArgs e)
        {
            ProcessForm processForm = new ProcessForm();
            processForm.Show();
        }

        private void tsmiMonitor_Click(object sender, EventArgs e)
        {
            FileAndFolderMonitorForm monitorForm = new FileAndFolderMonitorForm();
            monitorForm.Show();
        }




        private void tsmiAbout_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.Show();
        }




        //注意：在后退和前进的逻辑中，不创建新的路径节点，而是基于已有的路径节点（引用）

        //后退
        private void tsbtnBack_Click(object sender, EventArgs e)
        {
            if (curPathNode != firstPathNode)
            {
                curPathNode = curPathNode.PreNode;
                string prePath = curPathNode.Path;

                ShowFilesList(prePath, false);

                //前进按钮可用
                tsbtnAdvance.Enabled = true;
            }
            else
            {
                //后退按钮不可用
                tsbtnBack.Enabled = false;
            }
        }

        //前进
        private void tsbtnAdvance_Click(object sender, EventArgs e)
        {
            if (curPathNode.NextNode != null)
            {
                curPathNode = curPathNode.NextNode;
                string nextPath = curPathNode.Path;

                ShowFilesList(nextPath, false);

                //后退按钮可用
                tsbtnBack.Enabled = true;
            }
            else
            {
                //前进按钮不可用
                tsbtnAdvance.Enabled = false;
            }
        }

        //向上一级目录
        private void tsbtnUpArrow_Click(object sender, EventArgs e)
        {
            if (curFilePath == "")
            {
                return;
            }

            DirectoryInfo directoryInfo = new DirectoryInfo(curFilePath);

            //根目录诸如：C:\ 、D:\、E:\ 等
            //如果还没到达根目录
            if (directoryInfo.Parent != null)
            {
                ShowFilesList(directoryInfo.Parent.FullName, true);
            }
            //已经到达根目录，则停止
            else
            {
                return;
            }
        }




        private void tscboAddress_KeyDown(object sender, KeyEventArgs e)
        {
            //回车输入新地址
            if (e.KeyCode == Keys.Enter)
            {
                string newPath = tscboAddress.Text;

                if (newPath == "")
                {
                    return;
                }
                else if (!Directory.Exists(newPath))
                {
                    return;
                }

                ShowFilesList(newPath, true);
            }
        }




        private void tscboSearch_Enter(object sender, EventArgs e)
        {
            tscboSearch.Text = "";
        }

        private void tscboSearch_Leave(object sender, EventArgs e)
        {
            tscboSearch.Text = "快速搜索";
        }

        private void tscboSearch_KeyDown(object sender, KeyEventArgs e)
        {
            //回车输入文件名
            if (e.KeyCode == Keys.Enter)
            {
                string fileName = tscboSearch.Text;

                if (string.IsNullOrEmpty(fileName))
                {
                    return;
                }

                //使用多线程搜索文件/文件夹
                SearchWithMultiThread(curFilePath, fileName);
            }
        }





        //上下文菜单打开时
        private void cmsMain_Opening(object sender, CancelEventArgs e)
        {
            //将获取的鼠标当前坐标进行转换（屏幕坐标转换成工作区坐标）
            Point curPoint = lvwFiles.PointToClient(Cursor.Position);

            //获取坐标处的ListViewItem
            ListViewItem item = lvwFiles.GetItemAt(curPoint.X, curPoint.Y);

            //当前位置有ListViewItem
            if (item != null)
            {
                tsmiOpen.Visible = true;
                tsmiView1.Visible = false;
                tsmiRefresh1.Visible = false;
                tsmiCopy1.Visible = true;
                tsmiPaste1.Visible = false;
                tsmiCut1.Visible = true;
                tsmiDelete1.Visible = true;
                tsmiRename.Visible = true;
                tsmiNewFolder1.Visible = false;
                tsmiNewFile1.Visible = false;
                tssLine4.Visible = false;
            }
            //当前位置没有ListViewItem
            else
            {
                tsmiOpen.Visible = false;
                tsmiView1.Visible = true;
                tsmiRefresh1.Visible = true;
                tsmiCopy1.Visible = false;
                tsmiPaste1.Visible = true;
                tsmiCut1.Visible = false;
                tsmiDelete1.Visible = false;
                tsmiRename.Visible = false;
                tsmiNewFolder1.Visible = true;
                tsmiNewFile1.Visible = true;
                tssLine4.Visible = true;
            }
        }

        private void tsmiOpen_Click(object sender, EventArgs e)
        {
            Open();
        }

        private void tsmiRename_Click(object sender, EventArgs e)
        {
            //文件重命名
            RenameFile();
        }

        private void lvwFiles_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            string newName = e.Label;

            //选中项
            ListViewItem selectedItem = lvwFiles.SelectedItems[0];

            //如果名称为空
            if (string.IsNullOrEmpty(newName))
            {
                MessageBox.Show("文件名不能为空！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //显示时，恢复原来的标签
                e.CancelEdit = true;
            }
            //标签没有改动
            else if (newName == null)
            {
                return;
            }
            //标签改动了，但是最终还是和原来一样
            else if (newName == selectedItem.Text)
            {
                return;
            }
            //文件名不合法
            else if (!IsValidFileName(newName))
            {
                MessageBox.Show("文件名不能包含下列任何字符:\r\n" + "\t\\/:*?\"<>|", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //显示时，恢复原来的标签
                e.CancelEdit = true;
            }
            else
            {
                Computer myComputer = new Computer();

                //如果是文件
                if (File.Exists(selectedItem.Tag.ToString()))
                {
                    //如果当前路径下有同名的文件
                    if (File.Exists(Path.Combine(curFilePath, newName)))
                    {
                        MessageBox.Show("当前路径下有同名的文件！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        //显示时，恢复原来的标签
                        e.CancelEdit = true;
                    }
                    else
                    {
                        myComputer.FileSystem.RenameFile(selectedItem.Tag.ToString(), newName);

                        FileInfo fileInfo = new FileInfo(selectedItem.Tag.ToString());
                        string parentPath = Path.GetDirectoryName(fileInfo.FullName);
                        string newPath = Path.Combine(parentPath, newName);

                        //更新选中项的Tag
                        selectedItem.Tag = newPath;

                        //刷新左边的目录树
                        LoadChildNodes(curSelectedNode);
                    }
                }
                //如果是文件夹
                else if (Directory.Exists(selectedItem.Tag.ToString()))
                {
                    //如果当前路径下有同名的文件夹
                    if (Directory.Exists(Path.Combine(curFilePath, newName)))
                    {
                        MessageBox.Show("当前路径下有同名的文件夹！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        //显示时，恢复原来的标签
                        e.CancelEdit = true;
                    }
                    else
                    {
                        myComputer.FileSystem.RenameDirectory(selectedItem.Tag.ToString(), newName);

                        DirectoryInfo directoryInfo = new DirectoryInfo(selectedItem.Tag.ToString());
                        string parentPath = directoryInfo.Parent.FullName;
                        string newPath = Path.Combine(parentPath, newName);

                        //更新选中项的Tag
                        selectedItem.Tag = newPath;

                        //刷新左边的目录树
                        LoadChildNodes(curSelectedNode);
                    }
                }
            }
        }




        //激活某项事件(默认激活动作是“双击”)
        private void lvwFiles_ItemActivate(object sender, EventArgs e)
        {
            Open();
        }


        //TreeView有个默认获取焦点的过程,默认选择最顶端的节点，即索引等于0,也就是“最近访问”节点。此时会调用
        //该函数，导致右边文件列表视图为“最近访问”的文件列表视图。
        private void tvwDirectory_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //第一次初始化tvwDirectory
            if (isInitializeTvwDirectory)
            {
                curFilePath = @"最近访问";
                tscboAddress.Text = curFilePath;

                //保存用户的历史路径的第一个路径
                firstPathNode.Path = curFilePath;
                curPathNode = firstPathNode;

                curSelectedNode = e.Node;

                //在右窗体显示“最近访问”的文件列表
                ShowFilesList(curFilePath, true);

                isInitializeTvwDirectory = false;
            }
            else
            {
                curSelectedNode = e.Node;
                ShowFilesList(e.Node.Tag.ToString(), true);
            }
           
        }

        private void tvwDirectory_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            //在被选中节点展开前，加载被选中节点的子节点
            LoadChildNodes(e.Node);
        }

        private void tvwDirectory_AfterExpand(object sender, TreeViewEventArgs e)
        {
            //在被选中节点展开后，展开该节点
            e.Node.Expand();
        }











        //存储窗体左边目录区的图标在ImageList（具体是ilstDirectoryIcons）中的索引
        private class IconsIndexes
        {
            public const int FixedDrive = 0; //固定磁盘
            public const int CDRom = 1; //光驱
            public const int RemovableDisk = 2; //可移动磁盘
            public const int Folder = 3; //文件夹图标
            public const int RecentFiles = 4; //最近访问
        }


        //双向链表节点类(用来存储用户的历史访问路径)
        class DoublyLinkedListNode
        {
            //保存的路径
            public string Path { set; get; }
            public DoublyLinkedListNode PreNode { set; get; }
            public DoublyLinkedListNode NextNode { set; get; }

        }



        //初始化管理器界面的显示（初始化左窗体的驱动器树形视图和右窗体的文件列表视图）
        private void InitDisplay()
        {
            tvwDirectory.Nodes.Clear();

            TreeNode recentFilesNode = tvwDirectory.Nodes.Add("最近访问");
            recentFilesNode.Tag = "最近访问";
            recentFilesNode.ImageIndex = IconsIndexes.RecentFiles;
            recentFilesNode.SelectedImageIndex = IconsIndexes.RecentFiles;


            DriveInfo[] driveInfos = DriveInfo.GetDrives();

            foreach (DriveInfo info in driveInfos)
            {
                TreeNode driveNode = null;

                switch (info.DriveType)
                {

                    //固定磁盘
                    case DriveType.Fixed:

                        //显示的名称
                        driveNode = tvwDirectory.Nodes.Add("本地磁盘(" + info.Name.Split('\\')[0] + ")");

                        //真正的路径
                        driveNode.Tag = info.Name;

                        driveNode.ImageIndex = IconsIndexes.FixedDrive;
                        driveNode.SelectedImageIndex = IconsIndexes.FixedDrive;

                        break;

                    //光驱
                    case DriveType.CDRom:

                        //显示的名称
                        driveNode = tvwDirectory.Nodes.Add("光驱(" + info.Name.Split('\\')[0] + ")");

                        //真正的路径
                        driveNode.Tag = info.Name;

                        driveNode.ImageIndex = IconsIndexes.CDRom;
                        driveNode.SelectedImageIndex = IconsIndexes.CDRom;

                        break;

                    //可移动磁盘
                    case DriveType.Removable:

                        //显示的名称
                        driveNode = tvwDirectory.Nodes.Add("可移动磁盘(" + info.Name.Split('\\')[0] + ")");

                        //真正的路径
                        driveNode.Tag = info.Name;

                        driveNode.ImageIndex = IconsIndexes.RemovableDisk;
                        driveNode.SelectedImageIndex = IconsIndexes.RemovableDisk;

                        break;
                }
            }

            //加载每个磁盘下的子目录
            foreach (TreeNode node in tvwDirectory.Nodes)
            {
                LoadChildNodes(node);
            }


            //其中，右窗体的文件列表视图的显示其实在初始化tvwDirectory时已经默认调用了它的
            //tvwDirectory_AfterSelect函数，不必在这里写多余的代码

        }



        //加载子节点（加载当前目录下的子目录）
        private void LoadChildNodes(TreeNode node)
        {
            try
            {
                //清除空节点，然后才加载子节点
                node.Nodes.Clear();

                if (node.Tag.ToString() == "最近访问")
                {
                    return;
                }
                else
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(node.Tag.ToString());
                    DirectoryInfo[] directoryInfos = directoryInfo.GetDirectories();

                    foreach (DirectoryInfo info in directoryInfos)
                    {
                        //显示的名称
                        TreeNode childNode = node.Nodes.Add(info.Name);

                        //真正的路径
                        childNode.Tag = info.FullName;

                        childNode.ImageIndex = IconsIndexes.Folder;
                        childNode.SelectedImageIndex = IconsIndexes.Folder;

                        //加载空节点，以实现“+”号
                        childNode.Nodes.Add("");
                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        //在右窗体中显示指定路径下的所有文件/文件夹
        public void ShowFilesList(string path, bool isRecord)
        {
            //后退按钮可用
            tsbtnBack.Enabled = true;

            //需要保存记录，则需要创建新的路径节点
            if (isRecord)
            {
                //保存用户的历史访问路径
                DoublyLinkedListNode newNode = new DoublyLinkedListNode();
                newNode.Path = path;
                curPathNode.NextNode = newNode;
                newNode.PreNode = curPathNode;

                curPathNode = newNode;
            }


            //开始数据更新
            lvwFiles.BeginUpdate();

            //清空lvwFiles
            lvwFiles.Items.Clear();

            if (path == "最近访问")
            {
                //获取最近使用的文件的路径的枚举集合
                var recentFiles = RecentFilesUtil.GetRecentFiles();

                foreach (string file in recentFiles)
                {
                    if (File.Exists(file))
                    {
                        FileInfo fileInfo = new FileInfo(file);

                        ListViewItem item = lvwFiles.Items.Add(fileInfo.Name);

                        //为exe文件或无拓展名
                        if (fileInfo.Extension == ".exe" || fileInfo.Extension == "")
                        {
                            //通过当前系统获得文件相应图标
                            Icon fileIcon = GetSystemIcon.GetIconByFileName(fileInfo.FullName);

                            //因为不同的exe文件一般图标都不相同，所以不能按拓展名存取图标，应按文件名存取图标
                            ilstIcons.Images.Add(fileInfo.Name, fileIcon);

                            item.ImageKey = fileInfo.Name;
                        }
                        //其他文件
                        else
                        {
                            if (!ilstIcons.Images.ContainsKey(fileInfo.Extension))
                            {
                                Icon fileIcon = GetSystemIcon.GetIconByFileName(fileInfo.FullName);

                                //因为类型（除了exe）相同的文件，图标相同，所以可以按拓展名存取图标
                                ilstIcons.Images.Add(fileInfo.Extension, fileIcon);
                            }

                            item.ImageKey = fileInfo.Extension;
                        }

                        item.Tag = fileInfo.FullName;
                        item.SubItems.Add(fileInfo.LastWriteTime.ToString());
                        item.SubItems.Add(fileInfo.Extension + "文件");
                        item.SubItems.Add(AttributeForm.ShowFileSize(fileInfo.Length).Split('(')[0]);

                    }
                    else if (Directory.Exists(file))
                    {
                        DirectoryInfo dirInfo = new DirectoryInfo(file);

                        ListViewItem item = lvwFiles.Items.Add(dirInfo.Name, IconsIndexes.Folder);
                        item.Tag = dirInfo.FullName;
                        item.SubItems.Add(dirInfo.LastWriteTime.ToString());
                        item.SubItems.Add("文件夹");
                        item.SubItems.Add("");
                    }
                }
            }
            else
            {
                try
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(path);
                    DirectoryInfo[] directoryInfos = directoryInfo.GetDirectories();
                    FileInfo[] fileInfos = directoryInfo.GetFiles();

                    //删除ilstIcons(ImageList)中的exe文件的图标，释放ilstIcons的空间
                    foreach (ListViewItem item in lvwFiles.Items)
                    {
                        if (item.Text.EndsWith(".exe"))
                        {
                            ilstIcons.Images.RemoveByKey(item.Text);
                        }
                    }



                    //列出所有文件夹
                    foreach (DirectoryInfo dirInfo in directoryInfos)
                    {
                        ListViewItem item = lvwFiles.Items.Add(dirInfo.Name, IconsIndexes.Folder);
                        item.Tag = dirInfo.FullName;
                        item.SubItems.Add(dirInfo.LastWriteTime.ToString());
                        item.SubItems.Add("文件夹");
                        item.SubItems.Add("");
                    }

                    //列出所有文件
                    foreach (FileInfo fileInfo in fileInfos)
                    {
                        ListViewItem item = lvwFiles.Items.Add(fileInfo.Name);

                        //为exe文件或无拓展名
                        if (fileInfo.Extension == ".exe" || fileInfo.Extension == "")
                        {
                            //通过当前系统获得文件相应图标
                            Icon fileIcon = GetSystemIcon.GetIconByFileName(fileInfo.FullName);

                            //因为不同的exe文件一般图标都不相同，所以不能按拓展名存取图标，应按文件名存取图标
                            ilstIcons.Images.Add(fileInfo.Name, fileIcon);

                            item.ImageKey = fileInfo.Name;
                        }
                        //其他文件
                        else
                        {
                            if (!ilstIcons.Images.ContainsKey(fileInfo.Extension))
                            {
                                Icon fileIcon = GetSystemIcon.GetIconByFileName(fileInfo.FullName);

                                //因为类型（除了exe）相同的文件，图标相同，所以可以按拓展名存取图标
                                ilstIcons.Images.Add(fileInfo.Extension, fileIcon);
                            }

                            item.ImageKey = fileInfo.Extension;
                        }

                        item.Tag = fileInfo.FullName;
                        item.SubItems.Add(fileInfo.LastWriteTime.ToString());
                        item.SubItems.Add(fileInfo.Extension + "文件");
                        item.SubItems.Add(AttributeForm.ShowFileSize(fileInfo.Length).Split('(')[0]);
                    }

                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }


            //更新当前路径
            curFilePath = path;

            //更新地址栏
            tscboAddress.Text = curFilePath;

            //更新状态栏
            tsslblFilesNum.Text = lvwFiles.Items.Count + " 个项目";

            //结束数据更新
            lvwFiles.EndUpdate();
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



        //显示属性窗口
        private void ShowAttributeForm()
        {
            //右边窗体中没有文件/文件夹被选中
            if (lvwFiles.SelectedItems.Count == 0)
            {

                if (curFilePath == "最近访问")
                {
                    MessageBox.Show("不能查看当前路径的属性！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                AttributeForm attributeForm = new AttributeForm(curFilePath);

                //显示当前文件夹的属性
                attributeForm.Show();
            }
            //右边窗体中有文件/文件夹被选中
            else
            {
                //显示被选中的第一个文件/文件夹的属性
                AttributeForm attributeForm = new AttributeForm(lvwFiles.SelectedItems[0].Tag.ToString());

                attributeForm.Show();
            }
        }



        //显示权限管理窗口
        private void ShowPrivilegeForm()
        {
            //右边窗体中没有文件/文件夹被选中
            if (lvwFiles.SelectedItems.Count == 0)
            {
                if (curFilePath == "最近访问")
                {
                    MessageBox.Show("不能查看当前路径的权限管理！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                PrivilegeForm privilegeForm = new PrivilegeForm(curFilePath);

                //显示对于当前文件夹的权限管理界面
                privilegeForm.Show();
            }
            //右边窗体中有文件/文件夹被选中
            else
            {
                //显示被选中的第一个文件/文件夹的权限管理界面
                PrivilegeForm privilegeForm = new PrivilegeForm(lvwFiles.SelectedItems[0].Tag.ToString());

                privilegeForm.Show();
            }

        }



        //新建文件夹
        private void CreateFolder()
        {
            if (curFilePath == "最近访问")
            {
                MessageBox.Show("不能在当前路径下新建文件夹！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                int num = 1;
                string path = Path.Combine(curFilePath, "新建文件夹");
                string newFolderPath = path;

                while (Directory.Exists(newFolderPath))
                {
                    newFolderPath = path + "(" + num + ")";
                    num++;
                }

                Directory.CreateDirectory(newFolderPath);

                ListViewItem item = lvwFiles.Items.Add("新建文件夹" + (num == 1 ? "" : "(" + (num - 1) + ")"), IconsIndexes.Folder);

                //真正的路径
                item.Tag = newFolderPath;

                //刷新左边的目录树
                LoadChildNodes(curSelectedNode);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        //新建文件
        private void CreateFile()
        {
            if (curFilePath == "最近访问")
            {
                MessageBox.Show("不能在当前路径下新建文件！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            NewFileForm newFileForm = new NewFileForm(curFilePath, this);
            newFileForm.Show();
        }

       

        //打开文件/文件夹
        private void Open()
        {
            if (lvwFiles.SelectedItems.Count > 0)
            {
                string path = lvwFiles.SelectedItems[0].Tag.ToString();

                try
                {
                    //如果选中的是文件夹
                    if (Directory.Exists(path))
                    {
                        //打开文件夹
                        ShowFilesList(path, true);
                    }
                    //如果选中的是文件
                    else
                    {
                        //打开文件
                        Process.Start(path);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        //复制文件
        private void CopyFiles()
        {
            //获得待复制文件的源路径
            SetCopyFilesSourcePaths();
        }



        //粘贴文件
        private void PasteFiles()
        {
            //没有待粘贴的文件
            if (copyFilesSourcePaths[0] == null)
            {
                return;
            }

            //当前路径无效
            if (!Directory.Exists(curFilePath))
            {
                return;
            }

            if (curFilePath == "最近访问")
            {
                MessageBox.Show("不能在当前路径下进行粘贴操作！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            for (int i = 0; copyFilesSourcePaths[i] != null; i++)
            {
                //如果是文件
                if (File.Exists(copyFilesSourcePaths[i]))
                {
                    //执行文件的“移动到”或“复制到”
                    MoveToOrCopyToFileBySourcePath(copyFilesSourcePaths[i]);
                }
                //如果是文件夹
                else if (Directory.Exists(copyFilesSourcePaths[i]))
                {
                    //执行文件夹的“移动到”或“复制到”
                    MoveToOrCopyToDirectoryBySourcePath(copyFilesSourcePaths[i]);
                }

            }

            //在右边窗体显示文件列表
            ShowFilesList(curFilePath, false);

            //刷新左边的目录树
            LoadChildNodes(curSelectedNode);

            //置空
            copyFilesSourcePaths = new string[200];
        }



        //剪切文件
        private void CutFiles()
        {
            //获得待复制文件的源路径
            SetCopyFilesSourcePaths();

            //准备移动
            isMove = true;
        }



        //删除文件
        private void DeleteFiles()
        {
            if (lvwFiles.SelectedItems.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("确定要删除吗？", "确认删除", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (dialogResult == DialogResult.No)
                {
                    return;
                }
                else
                {
                    try
                    {
                        foreach (ListViewItem item in lvwFiles.SelectedItems)
                        {
                            string path = item.Tag.ToString();

                            //如果是文件
                            if (File.Exists(path))
                            {
                                File.Delete(path);
                            }
                            //如果是文件夹
                            else if (Directory.Exists(path))
                            {
                                Directory.Delete(path, true);
                            }

                            lvwFiles.Items.Remove(item);
                        }

                        //刷新左边的目录树
                        LoadChildNodes(curSelectedNode);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }



        //获得待复制文件的源路径
        private void SetCopyFilesSourcePaths()
        {
            if (lvwFiles.SelectedItems.Count > 0)
            {
                int i = 0;

                foreach (ListViewItem item in lvwFiles.SelectedItems)
                {
                    copyFilesSourcePaths[i++] = item.Tag.ToString();
                }

                isMove = false;
            }
        }






        //执行文件的“移动到”或“复制到”
        private void MoveToOrCopyToFileBySourcePath(string sourcePath)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(sourcePath);

                //获取目的路径
                string destPath = Path.Combine(curFilePath, fileInfo.Name);

                //如果目的路径和源路径相同，则不执行任何操作
                if (destPath == sourcePath)
                {
                    return;
                }

                //移动文件到目的路径（当前是在执行“剪切+粘贴”操作）
                if (isMove)
                {
                    fileInfo.MoveTo(destPath);
                }
                //粘贴文件到目的路径（当前是在执行“复制+粘贴”操作）
                else
                {
                    fileInfo.CopyTo(destPath);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        //通过递归，复制并粘贴文件夹（包含文件夹下的所有文件）
        //没有DirectoryInfo.CopyTo(string path)方法，需要自己实现
        private void CopyAndPasteDirectory(DirectoryInfo sourceDirInfo, DirectoryInfo destDirInfo)
        {
            //判断目标文件夹是否是源文件夹的子目录，是则给出错误提示，不进行任何操作
            for (DirectoryInfo dirInfo = destDirInfo.Parent; dirInfo != null; dirInfo = dirInfo.Parent)
            {
                if (dirInfo.FullName == sourceDirInfo.FullName)
                {
                    MessageBox.Show("无法复制！目标文件夹是源文件夹的子目录！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            //创建目标文件夹
            if (!Directory.Exists(destDirInfo.FullName))
            {
                Directory.CreateDirectory(destDirInfo.FullName);
            }

            //复制文件并将文件粘贴到目标文件夹下
            foreach (FileInfo fileInfo in sourceDirInfo.GetFiles())
            {
                fileInfo.CopyTo(Path.Combine(destDirInfo.FullName, fileInfo.Name));
            }

            //递归复制并将子文件夹粘贴到目标文件夹下
            foreach (DirectoryInfo sourceSubDirInfo in sourceDirInfo.GetDirectories())
            {
                DirectoryInfo destSubDirInfo = destDirInfo.CreateSubdirectory(sourceSubDirInfo.Name);
                CopyAndPasteDirectory(sourceSubDirInfo, destSubDirInfo);
            }

        }



        //执行文件夹的“移动到”或“复制到”
        private void MoveToOrCopyToDirectoryBySourcePath(string sourcePath)
        {
            try
            {
                DirectoryInfo sourceDirectoryInfo = new DirectoryInfo(sourcePath);

                //获取目的路径
                string destPath = Path.Combine(curFilePath, sourceDirectoryInfo.Name);

                //如果目的路径和源路径相同，则不执行任何操作
                if (destPath == sourcePath)
                {
                    return;
                }

                //移动文件夹到目的路径（当前是在执行“剪切+粘贴”操作）
                if (isMove)
                {
                    //若使用sourceDirectoryInfo.MoveTo(destPath)，则不支持跨磁盘移动文件夹

                    //通过递归，复制并粘贴文件夹（包含文件夹下的所有文件）
                    CopyAndPasteDirectory(sourceDirectoryInfo, new DirectoryInfo(destPath));

                    //删除源文件夹
                    Directory.Delete(sourcePath, true);

                }
                //粘贴文件夹到目的路径（当前是在执行“复制+粘贴”操作）
                else
                {
                    //通过递归，复制并粘贴文件夹（包含文件夹下的所有文件）
                    CopyAndPasteDirectory(sourceDirectoryInfo, new DirectoryInfo(destPath));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


       

        //重命名文件
        private void RenameFile()
        {
            if (lvwFiles.SelectedItems.Count > 0)
            {
                //模拟进行编辑标签，实质是为了通过代码触发LabelEdit事件
                lvwFiles.SelectedItems[0].BeginEdit();
            }
        }



        //初始化相关“查看”选项
        private void InitViewChecks()
        {
            //默认右边窗体显示的是详细信息视图
            tsmiDetailedInfo.Checked = true;
            tsmiDetailedInfo1.Checked = true;
        }



        //重置相关“查看”选项
        private void ResetViewChecks()
        {
            tsmiBigIcon.Checked = false;
            tsmiSmallIcon.Checked = false;
            tsmiList.Checked = false;
            tsmiDetailedInfo.Checked = false;

            tsmiBigIcon1.Checked = false;
            tsmiSmallIcon1.Checked = false;
            tsmiList1.Checked = false;
            tsmiDetailedInfo1.Checked = false;
        }


        

        //使用多线程搜索文件/文件夹
        private void SearchWithMultiThread(string path, string fileName)
        {
            //清空lvwFiles
            lvwFiles.Items.Clear();

            //更新状态栏
            tsslblFilesNum.Text = 0 + " 个项目";

            this.fileName = fileName;

            ThreadPool.SetMaxThreads(1000, 1000);

            //开启一个线程来执行搜索操作
            ThreadPool.QueueUserWorkItem(new WaitCallback(Search), path);

        }



        //多线程搜索文件/文件夹
        public void Search(Object obj)
        {
            string path = obj.ToString();

            DirectorySecurity directorySecurity = new DirectorySecurity(path, AccessControlSections.Access);

            //目录可以访问
            if(!directorySecurity.AreAccessRulesProtected)
            {

                //待搜索路径
                DirectoryInfo directoryInfo = new DirectoryInfo(path);

                //待搜索路径下的文件
                FileInfo[] fileInfos = directoryInfo.GetFiles();

                //搜索文件
                if (fileInfos.Length > 0)
                {
                    foreach (FileInfo fileInfo in fileInfos)
                    {
                        try
                        {
                            if (fileInfo.Name.Split('.')[0].Contains(fileName))
                            {
                                AddSearchResultItemIntoList(fileInfo.FullName, true);

                                //更新状态栏
                                tsslblFilesNum.Text = lvwFiles.Items.Count + " 个项目";
                            }
                        }
                        catch (Exception e)
                        {
                            continue;
                        }
                    }

                }


                //待搜索路径下的子文件夹
                DirectoryInfo[] directoryInfos = directoryInfo.GetDirectories();

                //搜索文件夹
                if (directoryInfos.Length > 0)
                {
                    foreach (DirectoryInfo dirInfo in directoryInfos)
                    {
                        try
                        {
                            if (dirInfo.Name.Contains(fileName))
                            {
                                AddSearchResultItemIntoList(dirInfo.FullName, false);

                                //更新状态栏
                                tsslblFilesNum.Text = lvwFiles.Items.Count + " 个项目";
                            }
                            else
                            {
                                //多线程策略一：从待搜索文件夹开始，递归过程中每遇到一个文件夹便为其开一个线程进行递归搜索，线程总数多，但是
                                //使用的是线程池，它会进行自动管理，使得线程可以被反复利用，一个线程的搜索任务执行完成之后，又可以继续被利用去
                                //执行另一个在任务队列中的搜索任务。
                                //优点：可以适应普遍情况，搜索速度一般情况下很快！
                                ThreadPool.QueueUserWorkItem(new WaitCallback(Search), dirInfo.FullName);

                                //多线程策略二：为待搜索文件夹下每个文件夹开一个线程进行递归搜索，此后不再开线程，线程总数等于待搜索文件夹的子文件夹数。
                                //缺点:当待搜索文件夹的子文件夹数越少时，效果越差，速度越慢。
                                //ThreadPool.QueueUserWorkItem(new WaitCallback(SearchWithOneThread), dirInfo.FullName);
                            }
                        }
                        catch (Exception e)
                        {

                        }

                    }
                }

            }
        }




        //使用单个线程搜索单个子文件夹
        public void SearchWithOneThread(object obj)
        {
            string path = obj.ToString();

            DirectorySecurity directorySecurity = new DirectorySecurity(path, AccessControlSections.Access);

            //目录可以访问
            if (!directorySecurity.AreAccessRulesProtected)
            {

                //子文件夹
                DirectoryInfo directoryInfo = new DirectoryInfo(path);

                //子文件夹下的文件
                FileInfo[] fileInfos = directoryInfo.GetFiles();

                //子文件夹下的文件夹
                DirectoryInfo[] directoryInfos = directoryInfo.GetDirectories();


                //搜索文件
                if (fileInfos.Length > 0)
                {
                    foreach (FileInfo fileInfo in fileInfos)
                    {
                        try
                        {
                            if (fileInfo.Name.Split('.')[0].Contains(fileName))
                            {
                                AddSearchResultItemIntoList(fileInfo.FullName, true);

                                //更新状态栏
                                tsslblFilesNum.Text = lvwFiles.Items.Count + " 个项目";
                            }
                        }
                        catch (Exception e)
                        {
                            continue;
                        }
                    }

                }


                //搜索文件夹
                if (directoryInfos.Length > 0)
                {
                    foreach (DirectoryInfo dirInfo in directoryInfos)
                    {
                        try
                        {
                            if (dirInfo.Name.Contains(fileName))
                            {
                                AddSearchResultItemIntoList(dirInfo.FullName, false);

                                //更新状态栏
                                tsslblFilesNum.Text = lvwFiles.Items.Count + " 个项目";
                            }
                            else
                            {
                                SearchWithOneThread(dirInfo.FullName);
                            }
                        }
                        catch (Exception e)
                        {
                            continue;
                        }
                    }
                }
            }
        }



        //将搜索结果显示在文件列表上
        private void AddSearchResultItemIntoList(string fullPath, bool isFile)
        {
            //是文件
            if (isFile)
            {
                FileInfo fileInfo = new FileInfo(fullPath);

                ListViewItem item = lvwFiles.Items.Add(fileInfo.Name);

                //为exe文件或无拓展名
                if (fileInfo.Extension == ".exe" || fileInfo.Extension == "")
                {
                    //通过当前系统获得文件相应图标
                    Icon fileIcon = GetSystemIcon.GetIconByFileName(fileInfo.FullName);

                    //因为不同的exe文件一般图标都不相同，所以不能按拓展名存取图标，应按文件名存取图标
                    ilstIcons.Images.Add(fileInfo.Name, fileIcon);

                    item.ImageKey = fileInfo.Name;
                }
                //其他文件
                else
                {
                    if (!ilstIcons.Images.ContainsKey(fileInfo.Extension))
                    {
                        Icon fileIcon = GetSystemIcon.GetIconByFileName(fileInfo.FullName);

                        //因为类型（除了exe）相同的文件，图标相同，所以可以按拓展名存取图标
                        ilstIcons.Images.Add(fileInfo.Extension, fileIcon);
                    }

                    item.ImageKey = fileInfo.Extension;
                }

                item.Tag = fileInfo.FullName;

                item.SubItems.Add(fileInfo.LastWriteTimeUtc.ToString());
                item.SubItems.Add(fileInfo.Extension + "文件");
                item.SubItems.Add(AttributeForm.ShowFileSize(fileInfo.Length).Split('(')[0]);
            }
            //是文件夹
            else
            {
                DirectoryInfo dirInfo = new DirectoryInfo(fullPath);

                ListViewItem item = lvwFiles.Items.Add(dirInfo.Name, IconsIndexes.Folder);
                item.Tag = dirInfo.FullName;
                item.SubItems.Add(dirInfo.LastWriteTimeUtc.ToString());
                item.SubItems.Add("文件夹");
                item.SubItems.Add("");
            }
        }
       
    }

}
