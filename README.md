## MyFileManager

### 一、功能预览

#### 1. 主窗体

![1](https://github.com/Yuziquan/MyFileManager/blob/master/Screenshots/1.gif)

<br/>

#### 2. 新建文件窗口



![2](https://github.com/Yuziquan/MyFileManager/blob/master/Screenshots/2.gif)

<br/>

#### 3. “最近访问”功能区

![3](https://github.com/Yuziquan/MyFileManager/blob/master/Screenshots/3.gif)

<br/>

#### 4. 进程/线程管理窗口

![4-1](https://github.com/Yuziquan/MyFileManager/blob/master/Screenshots/4-1.gif)

<br/>

<br/>

![4-2](https://github.com/Yuziquan/MyFileManager/blob/master/Screenshots/4-2.gif)

<br/>

#### 5. 文件/文件夹监控窗口

![5](https://github.com/Yuziquan/MyFileManager/blob/master/Screenshots/5.gif)

<br/>

#### 6. 文件属性窗口

![6](https://github.com/Yuziquan/MyFileManager/blob/master/Screenshots/6.gif)

<br/>

#### 7. 权限管理窗口

![7](https://github.com/Yuziquan/MyFileManager/blob/master/Screenshots/7.gif)

<br/>

#### 8. 快速搜索窗口


![8](https://github.com/Yuziquan/MyFileManager/blob/master/Screenshots/8.gif)

<br/>



***

### 二、版本更新

#### 1、V1.0.0 

1. 实现了对文件、文件夹的复制、粘贴、剪切、删除功能；
2. 实现了对文件夹的双击打开、对多种类型的文件的双击打开查看功能；
3. 实现了主窗体左边驱动器树形视图(显示各驱动器及内部各文件夹列表)、右边文件列表视图（显示当前文件夹下所包含的文件和下一级文件夹）的显示，以及两者的联动显示。左右窗体间设有分隔条，拖动可改变左右窗体大小。文件列表视图中包含了名称、修改日期、类型、大小四个字段；
4. 实现了主窗体上方地址栏显示的文件路径在用户操作过程中的实时更新；
5. 实现了主窗体下方状态栏实时显示当前文件列表的项目总数；
6. 实现了在主窗体右边文件列表视图进行右键时弹出的上下文菜单，该菜单会根据当前是否选中某一文件项而将菜单项加以调整。例如，右键时，若当前没有选中文件项，则可以显示出“查看”、“新建文件”、“新建文件夹”等菜单项；但是若当前选中了某一文件项，则可以显示出“复制”、“剪切”、“重命名”等菜单项；
7. 实现了主窗体地址栏、状态栏的显示和隐藏可以由用户控制；
8. 实现了主窗体右边文件列表的四种视图：大图标、小图标、列表、详细信息；
9. 实现了主窗体右边文件列表的刷新操作；
10. 为每个窗体配置相应的icon图标。


<br/>

***

#### 2、V1.1.2

1. 实现了文件、文件夹的重命名功能。具体操作是在主窗体右边文件列表中右键某一文件项，在弹出的上下文菜单中选中“重命名”菜单项，此时弹出一个重命名窗口，在该窗口中完成文件、文件夹重命名操作。
2. 实现了新建文件夹功能；
3. 实现了文件、文件夹属性的查看；
4. 实现了对当前计算机的进程、线程管理功能；
5. 实现了在当前路径下“返回上一级目录”的功能；
6. 实现了在主窗体上方地址栏直接输入文件路径，然后直接回车查看该路径下的文件列表的功能；
7. 修复了在主窗体右边文件列表中进行新建文件/文件夹、删除、重命名、粘贴操作时，左边驱动器树形视图的节点不能实时更新并显示的bug；
8. 修复了主窗体上方地址栏显示的文件路径在用户操作过程中有时更新不正确的bug。

<br/>

***

#### 3、V1.3.0

1. 实现了对当前计算机文件、文件夹的监控功能。可定制化程度较高，既可以实现对特定路径的监控，也可以实现对具体磁盘驱动器的监控，甚至是全盘监控。监控过程中的日志均高亮显示在监控窗口中，也支持将日志保存到特定路径；
2. 实现了用户在主窗体右边文件列表中的历史访问路径的前进、后退功能；
3. 实现了新建文件功能，用户可以根据自己的需要在弹出的窗口中输入文件的全名（包括“文件名+拓展名”），从而新建各种类型的文件；
4. 实现了”最近访问“的功能，用户可以在该功能区找到最近使用的文件，并双击打开查看；
5. 实现了对文件/文件夹的快速搜索功能（基于多线程）。使用时先在地址栏输入特定文件路径（或者直接进入特定文件路径），然后直接在主窗体上方搜索框中输入你所要搜索的文件名或关键字，最后回车即可在当前文件列表区中显示出搜索到的结果，搜索到的文件/文件夹支持直接双击查看或编辑。实测时，比windows自带的文件/文件夹搜索功能快一点。但目前不支持对于整个磁盘驱动器进行搜索，只支持在文件夹下进行搜索；
6. 将重命名功能加以改进，实现了类似windows的”选定->再单击->出现重命名状态->进行重命名“功能；
7. 实现了对当前计算机的文件/文件夹的权限管理功能。权限管理包括：完全控制、修改、读取和执行、列出文件夹内容、读取、写入共6个模块。

<br/>

***

#### 4、V1.4.1

1. 对文件/文件夹的快速搜索功能进一步改进，使用另一种多线程搜索策略，实测比windows自带的文件/文件夹搜索功能快几倍。
2. 增加了在文件/文件夹的快速搜索过程中，对于搜索结果总数在主窗体下方状态栏的实时显示；
3. 修复了此前多线程搜索时”只支持在文件夹下进行搜索“的bug，目前支持对除系统盘以外的其他磁盘驱动器进行搜索，系统盘因为权限保护原因而无法访问。

<br/>

***
### 三、遵循的WinForm 控件命名规范

> https://www.cnblogs.com/codefly/p/3216484.html


<br/>

***
### 四、约定事项
> 1. TreeNode的Tag字段放置真实路径，Text字段放置显示的文件夹名或驱动器名；
> 2. ListViewItem的Tag字段放置真实路径，Text字段放置显示的文件夹名或文件名。

<br/>

***
### 五、未修复的bug以及未完成的功能
1. 在主窗体右边文件列表的大图标视图中，大图标不能正常显示；
2. 不能实现.png、.jpg图片的预览；
3. 启动速度稍慢，不过这个应该是C#程序的通病了；
4. 在权限管理部分有些未修复的bug，主要是微软官方的资料缺乏或未公开；
5. 在粘贴较多文件时界面停止响应；（因为未使用多线程，可以在显示界面的同时，另外开启一个线程来进行粘贴操作）；
6. 快速搜索中，因为对于系统盘没有权限访问，导致无法对系统盘进行搜索；
7. 新建一个文件之后，如果马上双击打开查看，则会提示”另一个程序正在使用此文件，进程无法访问“。如果再刷新几次，又能正常打开查看；
8. 不能实现图片预览;
9. 还未实现主窗体右边文件列表的”排序方式“功能；
10. 还未引入快捷键功能；
11. 选中多个文件/文件夹时只支持间隔选择，也就是按住Ctrl键不放逐一单击。还未支持选定全部，也就是Ctrl+A;
12. 快速搜索的结果没有像windows那样过滤掉一些系统文件和隐藏文件；
13. 快速搜索过程中不支持实时停止。



<br/>

***

### 六、参考资料
1. https://docs.microsoft.com/zh-cn/dotnet/csharp/ (C# 指南)
2. https://docs.microsoft.com/zh-cn/dotnet/framework/winforms/index (Windows 窗体)
3. https://docs.microsoft.com/zh-cn/dotnet/framework/winforms/controls/treeview-control-windows-forms (TreeView 控件（Windows 窗体）)
4. https://blog.csdn.net/Lyncai/article/details/26681645 (Path.Combine （合并两个路径字符串）方法的一些使用细节)
5. https://blog.csdn.net/luchuanbo/article/details/1630095 (C＃中TreeView组件使用方法初步)
6. https://blog.csdn.net/eastmount/article/details/18474655 (C# 系统应用之获取Windows最近使用记录)
7. https://www.cnblogs.com/shenbing/p/5629716.html (C#编程，TreeView控件的学习)
8. https://blog.csdn.net/qth515/article/details/77890558 (C# SplitContainer 控件详细用法)
9. https://blog.csdn.net/u010450592/article/details/46817233 (winfrom窗体的Anchor属性、Dock属性)
10. https://www.cnblogs.com/menghuijinxi/p/5734274.html (关于.Net中Process的使用方法和各种用途汇总（一）：Process用法简介)
11. https://blog.csdn.net/qq_29176825/article/details/77183599 (c# 设置窗体位置)
12. https://bbs.csdn.net/topics/390753352 (C# ListView如何通代码触发BeforeLabelEdit事件)
13. https://blog.csdn.net/jiliqiang1986/article/details/52034964 (C#中怎样使控件随着窗体一起变化大小(常见困难以及修正))
14. https://blog.csdn.net/qq_36526650/article/details/78442382 (c# 窗体放大窗体中的控件也随着窗体放大)
15. https://www.cnblogs.com/hao-1234-1234/p/8668258.html (C#中的Round()不是我们中国人理解的四舍五入，是老外的四舍五入)
16. https://www.cnblogs.com/TianFang/p/3427776.html (在C#中快速查询文件)
17. https://www.cnblogs.com/yinqixin/p/5056307.html (分分钟用上C#中的委托和事件)
18. https://www.cnblogs.com/ruanraun/p/6037075.html (委托学习总结（一）浅谈对C#委托理解)
19. https://www.cnblogs.com/liuhaorain/p/3911845.html (C#委托使用详解（Delegates）)
20. https://blog.csdn.net/honantic/article/details/46884537 ([深入学习C#]C#实现多线程的方法：线程(Thread类)和线程池(ThreadPool))
21. http://www.cnblogs.com/kissdodog/archive/2013/03/28/2986026.html (线程池之ThreadPool类与辅助线程 - <第二篇>)
22. https://www.cnblogs.com/changrulin/p/4775053.html (C#学习笔记----.net操作进程)
23. https://www.cnblogs.com/tommyli/p/4054296.html (C# 获取进程或线程的相关信息)
24. https://blog.csdn.net/u011108093/article/details/79448060 (ListView的BeginUpdate()和EndUpdate()作用)
25. https://www.cnblogs.com/songxingzhu/p/3677307.html (InvokeRequired和Invoke)
26. https://blog.csdn.net/chen_zw/article/details/7916262 (C# FileSystemWatcher用法详解)
27. http://www.cnblogs.com/babycool/p/3569183.html (C#如何以管理员身份运行程序)
28. https://www.cnblogs.com/cteng-common/p/fileaccess.html (C#文件夹权限操作整理)
29. https://dotblogs.com.tw/larrynung/archive/2012/09/27/75118.aspx ([C#]如何取出最近在Windows上所使用的文件檔案)
30. https://www.cnblogs.com/wolf-sun/p/4591734.html (C#修改文件或文件夹的权限，为指定用户、用户组添加完全控制权限)
31. https://blog.csdn.net/u011623102/article/details/45335889 (文件操作中出现system.notsupportedexception异常)
32. https://blog.csdn.net/linux7985/article/details/8646550 (C# Winform对文件夹的权限判断及处理)
33. https://blog.csdn.net/mon_ice/article/details/64121050?locationNum=8&fps=1 (c#获取文件权限)
34. https://support.microsoft.com/zh-cn/help/243330/well-known-security-identifiers-in-windows-operating-systems (在 Windows 操作系统中的公认的安全标识符)
35. https://blog.csdn.net/codeeer/article/details/6732040 (ListView的ItemCheck和ItemChecked事件)
36. https://baike.baidu.com/item/windows%E6%9D%83%E9%99%90/10292739?fr=aladdin (windows权限)
37. https://docs.microsoft.com/zh-cn/dotnet/framework/winforms/controls/creating-an-explorer-style-interface-with-the-listview-and-treeview (演练：使用设计器创建带有 ListView 和 TreeView 控件的资源管理器样式的界面)
38. https://blog.csdn.net/u014654707/article/details/80083091 （Visual Studio 2017 - Windows应用程序打包成exe文件（2）- Advanced Installer）
39. https://blog.csdn.net/baidu_27438681/article/details/72823844 (
   Visual Stdio 2015打包安装项目的方法（使用Visual Studio Installer）)
40. https://baike.baidu.com/item/%E8%B5%84%E6%BA%90%E7%AE%A1%E7%90%86%E5%99%A8/1951545 (资源管理器的定义)

