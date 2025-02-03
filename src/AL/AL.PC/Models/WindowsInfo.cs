using Arvin.Extensions;
using Arvin.Helpers;
using Arvin.LogHelper;
using IWshRuntimeLibrary;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AL.PC.Models
{
    /// <summary>
    /// Windows信息
    /// </summary>
    public partial class WindowsInfo
    {
        public static List<AppInfo> AppInfos = null;
        /// <summary>
        /// 获取已安装软件信息
        /// </summary>
        /// <returns></returns>
        public static List<AppInfo> GetInstalledAppInfos()
        {
            if(!AppInfos.IsNullOrEmpty())
                return AppInfos;
            List<AppInfo> appInfos = new List<AppInfo>();
            string SameApp = "";

            void AddApp(RegistryKey subkey, string keyName)
            {
                string displayIcon = subkey.GetValue("DisplayIcon") as string;
                if (string.IsNullOrWhiteSpace(displayIcon)) displayIcon = string.Empty;

                string installLocation = subkey.GetValue("InstallLocation") as string;
                if (string.IsNullOrWhiteSpace(installLocation)) installLocation = string.Empty;

                string displayName = subkey.GetValue("DisplayName") as string;
                if (string.IsNullOrWhiteSpace(displayName)) displayName = string.Empty;

                string uninstallString = subkey.GetValue("UninstallString") as string;
                if (string.IsNullOrWhiteSpace(uninstallString)) uninstallString = string.Empty;

                var app = new AppInfo(displayName, displayIcon, installLocation, keyName, uninstallString);
                app.Repair();
                if (appInfos.Exists(a => a.ToString() == app.ToString()))
                {
                    SameApp += app.ToString() + "\r\n";
                }
                else
                {
                    appInfos.Add(app);
                }
            }

            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall", false))
            {
                foreach (String keyName in key.GetSubKeyNames())
                {
                    RegistryKey subkey = key.OpenSubKey(keyName);
                    AddApp(subkey, keyName);
                }
            }

            using (var key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall", false))
            {
                foreach (String keyName in key.GetSubKeyNames())
                {
                    RegistryKey subkey = key.OpenSubKey(keyName);
                    AddApp(subkey, keyName);
                }
            }

            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall", false))
            {
                foreach (String keyName in key.GetSubKeyNames())
                {
                    RegistryKey subkey = key.OpenSubKey(keyName);

                    AddApp(subkey, keyName);
                }
            }
            appInfos = appInfos.DistinctBy(p => p.DisplayName).ToList();
            //foreach (var app in appInfos)
            //{
            //    app?.Repair();
            //}
            AppInfos = appInfos;
            return appInfos;
        }
        public static AppInfo GetAppInfo(string displayName)
        {
            if(AppInfos.IsNullOrEmpty())
                GetInstalledAppInfos();
            return AppInfos.FirstOrDefault(a => a.DisplayName.IsContainsAny(displayName));
        }
        public static string[] GetLocalDrives()
        {
            return Directory.GetLogicalDrives();
        }

        [DllImport("shell32.dll", CharSet = CharSet.Unicode, ExactSpelling = true, PreserveSig = false)]
        static extern string SHGetKnownFolderPath([MarshalAs(UnmanagedType.LPStruct)] Guid id, int flags, IntPtr token);

        /// <summary>
        /// 获取指定特殊目录
        /// </summary>
        /// <param name="floderType"></param>
        /// <returns></returns>
        public static string GetSpeicialFolderPath(SpecialFolder floderType)
        {
            switch (floderType)
            {
                case SpecialFolder.Desktop:
                    return Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                case SpecialFolder.Documents:
                    return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                case SpecialFolder.Downloads:
                    {
                        var downloadFolderGuid = new Guid("374DE290-123F-4565-9164-39C4925E467B");
                        var downloadFolderPath = SHGetKnownFolderPath(downloadFolderGuid, 0, IntPtr.Zero);
                        return downloadFolderPath;
                    }
                case SpecialFolder.Music:
                    return Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
                case SpecialFolder.Pictures:
                    return Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                case SpecialFolder.Videos:
                    return Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);
                default:
                    return "";
            }
        }

        /// <summary>
        /// 获取所有特殊文件夹路径
        /// </summary>
        /// <returns></returns>
        public static Dictionary<SpecialFolder, string> GetSpecialFolderAll()
        {
            var dic = new Dictionary<SpecialFolder, string>();
            foreach (SpecialFolder folder in Enum.GetValues(typeof(SpecialFolder)))
            {
                dic.Add(folder, GetSpeicialFolderPath(folder));
            }
            return dic;
        }

        

        /// <summary>
        /// 获取指定文件夹下所有快捷方式
        /// </summary>
        /// <param name="folderPath"></param>
        public static Dictionary<string, string> GetShortcuts(string folderPath)
        {
            var dic = new Dictionary<string, string>();
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

                    dic.Add(shortcutName, shortcut.TargetPath);
                    // 输出快捷方式的目标路径
                    ALog.Deubg($"Shortcut: {shortcutName}, Target: {shortcut.TargetPath}");
                }
                catch (Exception ex)
                {
                    // 处理无法读取的快捷方式文件（例如，权限问题）
                    ALog.WriteLine($"Error reading shortcut {shortcutName}: {ex.Message}");
                }
            }
            return dic;
        }

        static Dictionary<string, string> _dicShortcuts = null;
        /// <summary>
        /// 获取所有快捷方式
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> GetShortcutAll()
        {
            if (_dicShortcuts != null&& _dicShortcuts.Count > 0)
            {
                return _dicShortcuts;
            }
            List<string> targetDirs = new List<string>()
            {
                Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory),
                Environment.GetFolderPath(Environment.SpecialFolder.Programs),//开始菜单（用户）
                @"C:\ProgramData\Microsoft\Windows\Start Menu\Programs"//开始菜单（所有用户）
            };
            var dic = new Dictionary<string, string>();
            foreach (var dir in targetDirs)
            {
                var temp = GetShortcuts(dir);
                var test11 = temp.FirstOrDefault(p => p.Key.Contains("Epic")).Value;
                if (!test11.IsNullOrWhiteSpace())
                {

                }
                dic.MeregDic(temp);
                //dic = dic.Concat(GetShortcuts(dir)).ToDictionary(x => x.Key, x => x.Value);
            }
            _dicShortcuts = dic;
            var test = dic.FirstOrDefault(p => p.Key.Contains("Epic")).Value;
            if (!test.IsNullOrWhiteSpace())
            {

            }
            return dic;
        }
    }

    public enum SpecialFolder
    {
        Desktop,
        Documents,
        Downloads,
        Music,
        Pictures,
        Videos
    }
}
