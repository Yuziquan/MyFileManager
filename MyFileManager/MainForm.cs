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

namespace MyFileManager
{
    public partial class MainForm : Form
    {
        //当前路径
        private string curFilePath = "";

        //是否移动
        private bool isMove = false;

        //待复制并粘贴的文件\文件夹的源路径
        private string[] copyFilesSourcePaths = new string[200];

        //用户的历史访问路径的第一个路径节点
        private DoublyLinkedListNode firstPathNode = new DoublyLinkedListNode();

        //当前路径节点
        private DoublyLinkedListNode curPathNode = null;
       

        public MainForm()
        {
            InitializeComponent();
        }


        //以下为控件的事件处理方法

        private void tsMain_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void tsmiAbout_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.Show();
        }

        private void tstxtFilePath_Click(object sender, EventArgs e)
        {

        }

        private void tsmiFile_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
          
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



        private void tsmiCopy_Click(object sender, EventArgs e)
        {
            //获得待复制文件的源路径
            SetCopyFilesSourcePaths();
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
        }

        private void tsmiStatusbar_Click(object sender, EventArgs e)
        {
            //设置状态栏是否可见
            ssFooter.Visible = !ssFooter.Visible;
        }

        private void tsmiBigIcon_Click(object sender, EventArgs e)
        {
            ResetCheck();
            tsmiBigIcon.Checked = true;
            tsmiBigIcon1.Checked = true;
            lvwFiles.View = View.LargeIcon;
        }

        private void tsmiSmallIcon_Click(object sender, EventArgs e)
        {
            ResetCheck();
            tsmiSmallIcon.Checked = true;
            tsmiSmallIcon1.Checked = true;
            lvwFiles.View = View.SmallIcon;
        }

        private void tsmiList_Click(object sender, EventArgs e)
        {
            ResetCheck();
            tsmiList.Checked = true;
            tsmiList1.Checked = true;
            lvwFiles.View = View.List;
        }

        private void tsmiDetailedInfo_Click(object sender, EventArgs e)
        {
            ResetCheck();
            tsmiDetailedInfo.Checked = true;
            tsmiDetailedInfo1.Checked = true;
            lvwFiles.View = View.Details;
        }

        private void tsmiRefresh_Click(object sender, EventArgs e)
        {
            ShowFilesList(curFilePath, false);
        }

        private void tsmiSearch_Click(object sender, EventArgs e)
        {

        }

        private void tsmiOpen_Click(object sender, EventArgs e)
        {
            Open();
        }

        private void tsmiNewFolder_Click(object sender, EventArgs e)
        {
            CreateFolder();
        }

        private void tvwDirectory_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ShowFilesList(e.Node.Tag.ToString(), true);
        }

        private void tvwDirectory_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            //在被选中节点展开前，加载被选中节点的子节点
            LoadChildNodes(e.Node);

            //加载当前选中节点的子节点的子节点
            /*  foreach (TreeNode node in e.Node.Nodes)
              {
                  LoadChildNodes(node);
              }*/
        }

        private void tvwDirectory_AfterExpand(object sender, TreeViewEventArgs e)
        {
            //在被选中节点展开后，展开该节点
            e.Node.Expand();
        }

        //激活某项事件(默认激活动作是“双击”)
        private void lvwFiles_ItemActivate(object sender, EventArgs e)
        {
            Open();
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

                ShowFilesList(newPath, true);
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
                tsmiView.Visible = false;
                tsmiRefresh.Visible = false;
                tsmiCopy1.Visible = true;
                tsmiPaste1.Visible = false;
                tsmiCut1.Visible = true;
                tsmiDelete1.Visible = true;
                tsmiRename.Visible = true;
                tsmiNewFolder.Visible = false;
                tssLine4.Visible = false;
            }
            //当前位置没有ListViewItem
            else
            {
                tsmiOpen.Visible = false;
                tsmiView.Visible = true;
                tsmiRefresh.Visible = true;
                tsmiCopy1.Visible = false;
                tsmiPaste1.Visible = true;
                tsmiCut1.Visible = false;
                tsmiDelete1.Visible = false;
                tsmiRename.Visible = false;
                tsmiNewFolder.Visible = true;
                tssLine4.Visible = true;
            }
        }

        private void tsmiEdit_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }



        private void lvwFiles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tsmiProperties_Click(object sender, EventArgs e)
        {
            //显示属性窗口
            ShowAttributeForm();
        }

        private void tsmiRename_Click(object sender, EventArgs e)
        {
            RenameFile();
        }



        private void lvwFiles_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            string newName = e.Label;

            //选中项
            ListViewItem SelectedItem = lvwFiles.SelectedItems[0];

            //标签没有改动
            if (newName == null)
            {
                return;
            }
            //标签改动了，但是最终还是和原来一样
            else if (newName == SelectedItem.Text)
            {
                return;
            }
            else
            {
                Computer myComputer = new Computer();

                //如果是文件
                if (File.Exists(SelectedItem.Tag.ToString()))
                {
                    myComputer.FileSystem.RenameFile(SelectedItem.Tag.ToString(), newName);

                    FileInfo fileInfo = new FileInfo(SelectedItem.Tag.ToString());
                    string parentPath = Path.GetDirectoryName(fileInfo.FullName);
                    string newPath = Path.Combine(parentPath, newName);

                    //更新选中项的Tag
                    SelectedItem.Tag = newPath;

                }
                //如果是文件夹
                else if (Directory.Exists(SelectedItem.Tag.ToString()))
                {
                    myComputer.FileSystem.RenameDirectory(SelectedItem.Tag.ToString(), newName);

                    DirectoryInfo directoryInfo = new DirectoryInfo(SelectedItem.Tag.ToString());
                    string parentPath = directoryInfo.Parent.FullName;
                    string newPath = Path.Combine(parentPath, newName);

                    //更新选中项的Tag
                    SelectedItem.Tag = newPath;
                }

            }
        }





        //以下为自定义的一些工具方法


        //存储窗体左边目录区的图标在ImageList（具体是ilstDirectoryIcons）中的索引
        private class IconsIndexes
        {
            public const int FixedDrive = 0; //固定磁盘
            public const int CDRom = 1; //光驱
            public const int RemovableDisk = 2; //可移动磁盘
            public const int Folder = 3; //文件夹图标
        }




        //初始化管理器界面的显示（初始化左窗体的目录和右窗体的文件列表）
        private void InitDisplay()
        {
            tvwDirectory.Nodes.Clear();

            DriveInfo[] driveInfos = DriveInfo.GetDrives();

            foreach (DriveInfo info in driveInfos)
            {
                //显示的名称
                TreeNode driveNode = tvwDirectory.Nodes.Add(info.Name.Split(':')[0] + "盘");

                //真正的路径
                driveNode.Tag = info.Name;

                switch (info.DriveType)
                {
                    //固定磁盘
                    case DriveType.Fixed:
                        driveNode.ImageIndex = IconsIndexes.FixedDrive;
                        driveNode.SelectedImageIndex = IconsIndexes.FixedDrive;

                        break;

                    //光驱
                    case DriveType.CDRom:
                        driveNode.ImageIndex = IconsIndexes.CDRom;
                        driveNode.SelectedImageIndex = IconsIndexes.CDRom;

                        break;

                    //可移动磁盘
                    case DriveType.Removable:
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

            curFilePath = @"C:\";
            tscboAddress.Text = curFilePath;

            //保存用户的历史路径的第一个路径
            firstPathNode.Path = curFilePath;
            curPathNode = firstPathNode;

            //在右窗体显示C盘下的文件列表
            ShowFilesList(curFilePath, true);

        }

        //加载子节点（加载当前目录下的子目录）
        private void LoadChildNodes(TreeNode node)
        {
            try
            {
                //清除空节点，然后才加载子节点
                node.Nodes.Clear();

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
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //显示属性窗口
        private void ShowAttributeForm()
        {
            //右边窗体中没有文件/文件夹被选中
            if (lvwFiles.SelectedItems.Count == 0)
            {
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


        //新建文件夹
        private void CreateFolder()
        {
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
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //在右窗体中显示指定路径下的所有文件/文件夹
        private void ShowFilesList(string path, bool isRecord)
        {
            //需要保存记录，则需要创建新的路径节点
            if(isRecord)
            {
                //保存用户的历史访问路径
                DoublyLinkedListNode newNode = new DoublyLinkedListNode();
                newNode.Path = path;
                curPathNode.NextNode = newNode;
                newNode.PreNode = curPathNode;

                curPathNode = newNode;
            }



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

                //清空lvwFiles
                lvwFiles.Items.Clear();

                //列出所有文件夹
                foreach (DirectoryInfo dirInfo in directoryInfos)
                {
                    ListViewItem item = lvwFiles.Items.Add(dirInfo.Name, IconsIndexes.Folder);
                    item.Tag = dirInfo.FullName;
                    item.SubItems.Add(dirInfo.LastWriteTimeUtc.ToString());
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
                    item.SubItems.Add(fileInfo.LastWriteTimeUtc.ToString());
                    item.SubItems.Add(fileInfo.Extension + "文件");
                    item.SubItems.Add(AttributeForm.ShowFileSize(fileInfo.Length).Split('(')[0]);
                }

                //更新当前路径
                curFilePath = path;

                //更新地址栏
                tscboAddress.Text = curFilePath;

                //更新状态栏
                tsslblFilesNum.Text = lvwFiles.Items.Count + "个项目";

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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

        //复制(并粘贴)或移动文件
        private void CopyOrMoveFileBySourcePath(string sourcePath)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(sourcePath);

                //获取目的路径
                string destPath = Path.Combine(curFilePath, fileInfo.Name);

                if (destPath == sourcePath)
                {
                    return;
                }

                //移动文件到目的路径
                if (isMove)
                {
                    fileInfo.MoveTo(destPath);
                }
                //粘贴文件到目的路径
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

        //复制(并粘贴)或移动文件夹
        private void CopyOrMoveDirectoryBySourcePath(string sourcePath)
        {
            try
            {
                DirectoryInfo sourceDirectoryInfo = new DirectoryInfo(sourcePath);

                //获取目的路径
                string destPath = Path.Combine(curFilePath, sourceDirectoryInfo.Name);

                if (destPath == sourcePath)
                {
                    return;
                }

                //移动文件夹到目的路径
                if (isMove)
                {
                    sourceDirectoryInfo.MoveTo(destPath);
                }
                //粘贴文件夹到目的路径
                else
                {
                    //没有DirectoryInfo.CopyTo(string path)方法，需要自己实现
                    CopyAndPasteDirectory(sourceDirectoryInfo, new DirectoryInfo(destPath));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

            for (int i = 0; copyFilesSourcePaths[i] != null; i++)
            {
                //如果是文件
                if (File.Exists(copyFilesSourcePaths[i]))
                {
                    CopyOrMoveFileBySourcePath(copyFilesSourcePaths[i]);
                }
                //如果是文件夹
                else if (Directory.Exists(copyFilesSourcePaths[i]))
                {
                    CopyOrMoveDirectoryBySourcePath(copyFilesSourcePaths[i]);
                }

            }

            //在右边窗体显示文件列表
            ShowFilesList(curFilePath, false);

            //置空
            copyFilesSourcePaths = new string[200];
        }

        //剪切文件
        private void CutFiles()
        {
            SetCopyFilesSourcePaths();
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
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
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


        //重置相关“查看”选项
        private void ResetCheck()
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


        //注意：在后退和前进的逻辑中，不创建新的路径节点，而是基于已有的路径节点（引用）

        private void tsbtnBack_Click(object sender, EventArgs e)
        {
            if(curPathNode != firstPathNode)
            {
                curPathNode = curPathNode.PreNode;
                string prePath = curPathNode.Path;

                ShowFilesList(prePath, false);
            }
        }

        private void tsbtnAdvance_Click(object sender, EventArgs e)
        {
            if(curPathNode.NextNode != null)
            {
                curPathNode = curPathNode.NextNode;
                string nextPath = curPathNode.Path;

                ShowFilesList(nextPath, false);
            }
        }
    }
}
