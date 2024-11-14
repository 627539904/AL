using AL.PC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace AL.PC
{
    /// <summary>
    /// 内存帮助类
    /// </summary>
    public class MemoryHelper
    {
        public static MemoryInfo GetMemoryInfo()
        {
            var total= GetTotalMemory();
            var available = GetAvailableMemory();
            var used = total - available;
            var usedRate = Math.Round(used / total * 100, 0);
            return new MemoryInfo()
            {
                TotalMemory = total,
                FreeMemory = available,
                UsedMemory = used,
                UsedRate= usedRate
            };
        }

        /// <summary>
        /// 获取总物理内存大小（单位GB）
        /// </summary>
        /// <returns></returns>
        public static double GetTotalMemory()
        {
            //获取总物理内存大小
            ManagementClass cimobject1 = new ManagementClass("Win32_PhysicalMemory");
            ManagementObjectCollection moc1 = cimobject1.GetInstances();
            double capacity = 0;
            foreach (ManagementObject mo1 in moc1)
            {
                capacity += ((Math.Round(Int64.Parse(mo1.Properties["Capacity"].Value.ToString()) / 1024 / 1024 / 1024.0, 1)));
            }
            moc1.Dispose();
            cimobject1.Dispose();
            return capacity;
        }

        /// <summary>
        /// 获取可用物理内存大小（单位GB）
        /// </summary>
        /// <returns></returns>
        public static double GetAvailableMemory()
        {
            //获取内存可用大小
            ManagementClass cimobject2 = new ManagementClass("Win32_PerfFormattedData_PerfOS_Memory");
            ManagementObjectCollection moc2 = cimobject2.GetInstances();
            double available = 0;
            foreach (ManagementObject mo2 in moc2)
            {
                available += ((Math.Round(Int64.Parse(mo2.Properties["AvailableMBytes"].Value.ToString()) / 1024.0, 1)));

            }
            moc2.Dispose();
            cimobject2.Dispose();
            return available;
        }
    }
}
