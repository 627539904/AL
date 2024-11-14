using Arvin.Extensions;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL.PC.Models
{
    /// <summary>
    /// Windows信息
    /// </summary>
    public partial class WindowsInfo
    {
        /// <summary>
        /// 获取已安装软件信息
        /// </summary>
        /// <returns></returns>
        public static List<AppInfo> GetInstalledAppInfos()
        {
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
            return appInfos;
        }

    }
}
