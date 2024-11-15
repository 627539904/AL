using Arvin.Extensions;
using Arvin.Helpers;
using Arvin.PC;
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
            if(this.InstallLocation.IsNullOrWhiteSpace())
            {
                //获取安装目录(取StartPath的工作目录作为安装目录)
                this.InstallLocation = Path.GetDirectoryName(this.StartPath);
            }
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
            ProcessHelper.CallProcessNoArgs(this.StartPath);
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
    }
}
