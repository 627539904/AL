using AL.PC.Models;
using Arvin.API.APIModel;
using Arvin.Extensions;
using IWshRuntimeLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AL.Demo
{
    public class AppDemo
    {
        public static void Demo()
        {
            TextToImage();
            //ReadDrives();
            //ReadFile();
        }

        static void TextToImage(string text = "未知",string fileName = "text.png")
        {
            text.TextToImage(fileName);
            Console.WriteLine("图片已保存");
        }

        static void PrintList<T>(IEnumerable<T> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

        static string ReadFile()
        {
            string appName = "Epic Games Launcher";
            string dir = @"D:\Programs\Epic Games";
            Console.WriteLine($"{appName}目录：{dir}");
            // 获取所有.exe文件的路径，包括子文件夹中的
            string[] exeFiles = Directory.GetFiles(dir, "*.exe", SearchOption.AllDirectories);

            var nameKeys = new List<string>() { "Epic", "Launcher" };
            var dirKeys= new List<string>() { "Portal" };
            // 输出每个.exe文件的路径
            var targetFiles= exeFiles.Where(p => nameKeys.Any(n => p.Contains(n))).ToList();
            Console.WriteLine($"{appName}文件数量：{targetFiles.Count()}");
            if (targetFiles.Count() <= 1)
                return targetFiles.FirstOrDefault();
            //以Launcher.exe结尾的文件
            targetFiles = targetFiles.Where(p => p.EndsWith("Launcher.exe")).ToList();
            Console.WriteLine($"{appName}文件数量(以Launcher.exe结尾)：{targetFiles.Count()}");
            if (targetFiles.Count() <= 1)
                return targetFiles.FirstOrDefault();
            //文件夹路径中包含Portal的文件
            targetFiles = targetFiles.Where(p => dirKeys.Any(n => p.Contains(n))).ToList();
            Console.WriteLine($"{appName}文件数量(文件夹路径中包含Portal)：{targetFiles.Count()}");
            foreach (string exeFile in targetFiles)
            {
                Console.WriteLine(exeFile);
            }
            return targetFiles.FirstOrDefault();
        }

        static void ReadDrives()
        {
            WindowsInfo.GetShortcutAll();
            return;
            
            // 获取当前用户的桌面路径和开始菜单程序文件夹路径
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            Console.WriteLine("桌面路径：{0}", desktopPath);
            // 遍历桌面文件夹
            TraverseShortcuts(desktopPath);

            string programsPath = Environment.GetFolderPath(Environment.SpecialFolder.Programs);
            Console.WriteLine("开始菜单程序文件夹路径：{0}", programsPath);
            // 遍历开始菜单的程序文件夹
            TraverseShortcuts(programsPath);

            string path = @"C:\ProgramData\Microsoft\Windows\Start Menu\Programs";
            Console.WriteLine("开始菜单程序文件夹路径：{0}", path);
            // 遍历开始菜单的程序文件夹
            TraverseShortcuts(path);

            //string[] drives = Directory.GetLogicalDrives();// Environment.GetLogicalDrives();
            //foreach (var drive in drives)
            //{
            //    TraverseShortcuts(drive);
            //    //Console.WriteLine(drive); // 输出盘符，例如 C:\\
            //}
        }
        static void TraverseShortcuts(string folderPath)
        {
            WindowsInfo.GetShortcuts(folderPath);
            return;
            // 获取文件夹中的所有.lnk文件
            string[] shortcutFiles = Directory.GetFiles(folderPath, "*.lnk", SearchOption.AllDirectories);

            foreach (string shortcutFile in shortcutFiles)
            {
                var shortcutName = Path.GetFileName(shortcutFile);
                try
                {
                    // 创建WshShell对象【Coms:Windows Script Host Object Model】
                    WshShell shell = new WshShell();
                    // 创建快捷方式对象
                    IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutFile);

                    if (shortcutName.Contains("Epic"))
                    {

                    }
                    // 输出快捷方式的目标路径
                    Console.WriteLine("Shortcut: {0}, Target: {1}", shortcutName, shortcut.TargetPath);
                }
                catch (Exception ex)
                {
                    // 处理无法读取的快捷方式文件（例如，权限问题）
                    Console.WriteLine("Error reading shortcut {0}: {1}", shortcutName, ex.Message);
                }
            }
        }

    }
}
