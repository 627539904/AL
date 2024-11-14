using AL.PC.API;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL.PC.Models
{
    /// <summary>
    /// 操作系统信息
    /// </summary>
    public class OSInfo
    {
        /// <summary>
        /// 操作系统名称
        /// </summary>
        public string Name { get; set; }
        public string FullName { get; set; }
        /// <summary>
        /// 版本号
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// 操作系统架构
        /// </summary>
        public string Architecture { get; set; }
        public int Build { get; set; }= Environment.OSVersion.Version.Build;

        public OSInfo Init()
        {
            this.Name = GetOSName();
            this.FullName = WMIAPI.GetOSInfo().FirstOrDefault()?.Name;
            this.Version = Environment.OSVersion.Version.ToString();
            this.Architecture = Environment.Is64BitOperatingSystem ? "x64" : "x86";
            return this;
        }

        string GetOSName()
        {
            if(this.Build >= 22000)
                return "Windows 11";
            string HKLMWinNTCurrent = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion";
            string osName = Registry.GetValue(HKLMWinNTCurrent, "productName", "").ToString();
            return osName;

        }
    }
}
