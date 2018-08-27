using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;              //Directory 目录 
using System.Reflection;      //BindingFlags 枚举

namespace MyFileManager
{
    //关于电脑中"最近"文件夹的工具类，Win+R，输入Recent可以调出
    class RecentFilesUtil
    {
        //根据快捷方式名称（全路径）获取快捷方式的目标路径（真实路径）
        public static string GetShortcutTargetFilePath(string shortcutFilename)
        {
            //获取WScript.Shell类型
            var type = Type.GetTypeFromProgID("WScript.Shell");

            //创建该类型实例
            object instance = Activator.CreateInstance(type);

            var result = type.InvokeMember("CreateShortCut", BindingFlags.InvokeMethod, null, instance, new object[] { shortcutFilename });

            //获取到目标路径（真实路径）
            var targetFilePath = result.GetType().InvokeMember("TargetPath", BindingFlags.GetProperty, null, result, null) as string;

            return targetFilePath;
        }

        //获取最近使用的文件的路径的枚举集合
        public static IEnumerable<string> GetRecentFiles()
        {
            //获取Recent路径
            var recentFolder = Environment.GetFolderPath(Environment.SpecialFolder.Recent);

            //获取电脑"Recent"文件夹下的文件名（全路径）
            return from file in Directory.EnumerateFiles(recentFolder)

                   //只取快捷方式类型文件
                   where Path.GetExtension(file) == ".lnk"

                   //取出对应的真实路径
                   select GetShortcutTargetFilePath(file);
        }
    }
}
