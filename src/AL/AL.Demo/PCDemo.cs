using AL.Env;
using AL.PC;
using AL.PC.SysTools;
using Arvin.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AL.Demo
{
    /// <summary>
    /// PC相关Demo
    /// </summary>
    internal class PCDemo
    {
        public static void Demo()
        {
            Console.WriteLine("PC相关Demo");

            PCInfoShow();
            //记录：1.CPU信息不明确；2.显卡缺少显存使用率；
        }

        

        /// <summary>
        /// 显示PC信息
        /// </summary>
        public static void PCInfoShow()
        {
            Console.WriteLine("PC信息：");
            Console.WriteLine($"PC名称：{PCEnv.GetPCName()}");
            Console.WriteLine("CPU信息：{0}", PCEnv.GetCPUInfo());

            if (false)
            {
                //用于性能优化，暂时不使用
                string workDir = @"F:\AI.Lumi\WorkDir";
                string fileFullName = $"{workDir}\\pfcTypes.txt";
                string pfcPath = fileFullName;
                var pfcTypes = PCEnv.GetPerformanceTypes(pfcPath);
                StringBuilder sb = new StringBuilder();
                foreach (var item in pfcTypes)
                {
                    sb.AppendLine(item);
                    Console.WriteLine($"性能计数器类别：{item}");
                }
            }
            var mInfo= PCEnv.GetMemoryInfo();
            Console.WriteLine($"内存信息：");
            Console.WriteLine("总内存=" + mInfo.TotalMemory.ToString() + "G");
            Console.WriteLine("可使用=" + mInfo.FreeMemory.ToString() + "G");
            Console.WriteLine("已使用=" + mInfo.UsedMemory + "G," + mInfo.UsedRate + "%");

            Console.WriteLine($"显卡信息：{PCEnv.GetGPUInfo().ToJsonForPrint()}");
            Console.WriteLine("显示器信息:");
            MonitorInfoDemo();
            //Console.WriteLine("网卡信息：{0}", PCInfo.GetNetworkCardInfo());
            //Console.WriteLine("声卡信息：{0}", PCInfo.GetSoundCardInfo());
            Console.WriteLine("操作系统信息：");
            OSInfoDemo();
            GPURAM();
        }

        static void OSInfoDemo()
        {
            var info= PCEnv.GetOSInfo();
            Console.WriteLine($"操作系统名称：{info.Name}");
            Console.WriteLine($"操作系统名称(全)：{info.FullName}");
            Console.WriteLine($"操作系统版本：{info.Version}");
            Console.WriteLine($"操作系统架构：{info.Architecture}");
            Console.WriteLine($"操作系统：{info.Build}");
        }

        //显示器信息
        static void MonitorInfoDemo()
        {
            Console.WriteLine($"显示器数量：{PCEnv.GetMonitorCount()}");
            var info = PCEnv.GetMonitorInfo();
            var size= info.Resolution;
            Console.WriteLine($"分辨率(宽)：{size.Width}");
            Console.WriteLine($"分辨率（高）：{size.Height}");
            var sreenSize = info.ScreenSize;
            Console.WriteLine($"屏幕尺寸(宽)：{sreenSize.Width}mm");
            Console.WriteLine($"屏幕尺寸（高）：{sreenSize.Height}mm");
            var sreenSize_inch = info.ScreenSize_InInch;
            Console.WriteLine($"屏幕尺寸：{sreenSize_inch}英寸");
        }

        #region GPU显存
        static void GPURAM()
        {
            var gpuRamInfo = nvidia_smi.ReadInfo();
            Console.WriteLine($"GPU Total Memory: {gpuRamInfo.MemoryTotal} MB");
            Console.WriteLine($"GPU Free Memory: {gpuRamInfo.MemoryFree} MB");
            Console.WriteLine($"GPU Used Memory: {gpuRamInfo.MemoryUsed} MB");
        }
        #endregion
    }
}
