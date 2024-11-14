using AL.PC;
using AL.PC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Arvin.Extensions;
using System.Management;

namespace AL.Env
{
    public class PCEnv
    {
        public static string GetCPUInfo()
        {
            try
            {
                // 创建一个 ManagementObjectSearcher 对象来查询 CPU 信息
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from Win32_Processor");

                string cpuName = "";
                // 遍历查询结果
                foreach (ManagementObject obj in searcher.Get())
                {
                    // 获取 CPU 名称
                    cpuName = obj["Name"].ToString();
                }

                return cpuName;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 获取系统安装路径,系统根目录
        /// </summary>
        /// <returns></returns>
        public static string GetSystemRoot()
        {
            return Environment.GetEnvironmentVariable("SYSTEMROOT");
        }

        /// <summary>
        /// 获取内存信息(单位:MB)
        /// </summary>
        /// <returns></returns>
        public static MemoryInfo GetMemoryInfo()
        {
            return MemoryHelper.GetMemoryInfo();
        }

        public static string GetPCName()
        {
            return Environment.MachineName;
        }

        /// <summary>
        /// 获取性能计数器类型
        /// </summary>
        /// <param name="cachePath">（可选）缓存文件路径</param>
        /// <param name="isUpateCahce">（可选）是否更新缓存</param>
        /// <returns></returns>
        public static string[] GetPerformanceTypes(string cachePath="",bool isUpateCahce=false)
        {
            if (!string.IsNullOrEmpty(cachePath)|| !isUpateCahce) {
                if(File.Exists(cachePath))
                    return File.ReadAllLines(cachePath);
            }
            var types= Performance.GetCounterTypes();
            //将结果写入缓存文件
            types.WriteAllLines(cachePath);
            return types;
        }

        public static GPUInfo GetGPUInfo()
        {
            return GPUHelper.GetGPUInfo();
        }

        
        public static MonitorInfo GetMonitorInfo()
        {
            return MonitorHelper.GetMonitorInfo();
        }
        public static int GetMonitorCount()
        {
            return MonitorHelper.Count();
        }

        public static OSInfo GetOSInfo()
        {
            return new OSInfo().Init();
        }
    }
}
