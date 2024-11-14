using AL.PC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using Arvin.Extensions;
using AL.PC.SysTools;

namespace AL.PC
{
    public class GPUHelper
    {
        public static GPUInfo GetGPUInfo()
        {
            // 获取显卡信息
            ManagementObjectSearcher searcher1 = new ManagementObjectSearcher("SELECT * FROM Win32_VideoController");
            var countData = searcher1.Get(); // 可能会有多条记录

            string vName = string.Empty;
            string vRam = string.Empty;
            string vDriverVersion = string.Empty;
            string vDriverDate = string.Empty;
            string vAdapterCompatibility = string.Empty;

            foreach (ManagementObject queryObj in countData)
            {
                vName = $"{queryObj["Name"]}";
                vRam = $"{queryObj["AdapterRAM"]}";
                vDriverVersion = $"{queryObj["DriverVersion"]}";
                vDriverDate = $"{queryObj["DriverDate"]}";
                vAdapterCompatibility = $"{queryObj["AdapterCompatibility"]}";
            }

            // 驱动日期
            string vDriverDateNew = string.Empty;
            if (!string.IsNullOrEmpty(vDriverDate) && vDriverDate.Length >= 8)
            {
                vDriverDateNew = $"{vDriverDate.Substring(0, 4)}年{vDriverDate.Substring(4, 2)}月{vDriverDate.Substring(6, 2)}日";
            }
            var nInfo = nvidia_smi.ReadInfo();
            GPUInfo gpuInfo = new GPUInfo()
            {
                Name = vName,
                Memory = nInfo.ToMemoryInfo(),
                Belong = vAdapterCompatibility,
                DriverVersion = vDriverVersion,
                DriverDate = vDriverDateNew,
            };
            return gpuInfo;
        }
    }
}
