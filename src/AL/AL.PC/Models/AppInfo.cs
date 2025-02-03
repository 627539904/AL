using AL.PC.SysTools;
using Arvin.Extensions;
using Arvin.Helpers;
using Arvin.LogHelper;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL.PC.Models
{    
    /// <summary>
    /// APP信息
    /// </summary>
    public class AppInfo
    {
        static Dictionary<string, string> dicShortuct = WindowsInfo.GetShortcutAll();
        static AppInfo()
        {
            //dicShortuct=WindowsInfo.GetShortcutAll();
        }
        public AppInfo(string name, string displayIcon, string installLocation, string productCode, string uninstallString)
        {
            DisplayName = name;
            StartPath = displayIcon;
            InstallLocation = installLocation;
            ProductCode = productCode;
            UninstallString = uninstallString;
        }

        /// <summary>
        /// 显示名称
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        /// 启动路径
        /// </summary>
        public string StartPath { get; set; }
        /// <summary>
        /// 安装位置
        /// </summary>
        public string InstallLocation { get; set; }
        /// <summary>
        /// 产品代码或名称
        /// </summary>
        public string ProductCode { get; set; }
        /// <summary>
        /// 卸载字符串
        /// </summary>
        public string UninstallString { get; set; }

        public override string ToString()
        {
            return $"Name:{DisplayName}{Environment.NewLine}---StartPath:{StartPath}{Environment.NewLine}---Loc:{InstallLocation}{Environment.NewLine}---Code:{ProductCode}{Environment.NewLine}---UnStr:{UninstallString}";
        }

        /// <summary>
        /// 数据修复
        /// </summary>
        public void Repair()
        {
            //启动路径修复
            this.StartPath = this.StartPath.Trim('\"').TrimEnd(',', '0');
            this.StartPath = this.GetStartPath(this);

            //安装路径修复
            if(this.InstallLocation.IsNullOrWhiteSpace())
            {
                //获取安装目录(取StartPath的工作目录作为安装目录)
                this.InstallLocation = Path.GetDirectoryName(this.StartPath);
            }
        }

        string GetStartPath(AppInfo app)
        {
            string startPath = app.StartPath;
            if (string.IsNullOrEmpty(startPath) || !System.IO.File.Exists(startPath))
            {
                if (app.DisplayName.Contains("Postman"))
                {

                }
                //if (dicShortuct.ContainKeyAny("Epic"))
                //{

                //}
                //string[] keys = app.DisplayName.Split(' ');
                string matchKey = app.DisplayName;// keys[0];//一般为应用名或品牌名
                if (dicShortuct.ContainKeyAnyIgnoreCase(matchKey))
                {
                    var obj= dicShortuct.FirstOrDefault(p => p.Key.ToLower().Contains(matchKey.ToLower()));
                    startPath = obj.Value;
                }
            }
            return startPath;
        }

        /// <summary>
        /// 启动APP
        /// </summary>
        public void Start()
        {
            //ProcessStartInfo info = new ProcessStartInfo();
            //info.FileName = this.StartPath;
            //info.Arguments = "";
            //info.WindowStyle = ProcessWindowStyle.Minimized;
            //Process pro = Process.Start(info);
            //pro.WaitForExit();
            Cmd.RunExe(this.StartPath);
            //ProcessHelper.CallProcessNoArgs(this.StartPath);
        }

        public void Close()
        {
            Process[] allProgresse = Process.GetProcesses().Where(p=>p.MainWindowTitle.Contains(this.DisplayName)).ToArray();
            foreach (Process closeProgress in allProgresse)
            {
                //if (closeProgress.ProcessName.Equals(this.DisplayName))
                {
                    ALog.Info($"关闭进程Id:{closeProgress.Id}");
                    ALog.Info($"关闭进程Name:{closeProgress.ProcessName}");
                    ALog.Info($"关闭进程WindowTitle:{closeProgress.MainWindowTitle}");
                    closeProgress.CloseMainWindow();
                    //closeProgress.Kill();
                    //closeProgress.WaitForExit();
                    break;
                }
            }
            ALog.Info($"关闭进程【{this.DisplayName}】完成");
        }

        public bool IsNullOrEmpty()
        {
            return this.StartPath.IsNullOrWhiteSpace() && this.InstallLocation.IsNullOrWhiteSpace();
        }

        public bool IsSystemApp()
        {
            if (!this.StartPath.IsNullOrWhiteSpace() && !this.StartPath.EndsWith(".exe"))
                return true;
            return false;
        }
    }
}
