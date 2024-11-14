using AL.PC.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AL.PC
{
    /// <summary>
    /// 显示器帮助类
    /// </summary>
    public class MonitorHelper
    {
        public static MonitorInfo GetMonitorInfo()
        {
            MonitorInfo monitorInfo = new MonitorInfo();
            monitorInfo.Resolution = GetResolution();
            monitorInfo.ScreenSize = GetScreenSize();
            monitorInfo.ScreenSize_InInch = GetScreenInch();
            return monitorInfo;
        }

        /// <summary>
        /// 获取DC句柄
        /// </summary>
        [DllImport("user32.dll")]
        static extern IntPtr GetDC(IntPtr hdc);
        /// <summary>
        /// 释放DC句柄
        /// </summary>
        [DllImport("user32.dll", EntryPoint = "ReleaseDC")]
        static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hdc);
        /// <summary>
        /// 获取句柄指定的数据
        /// </summary>
        [DllImport("gdi32.dll")]
        static extern int GetDeviceCaps(IntPtr hdc, int nIndex);

        /// <summary>
        /// 获取分辨率
        /// </summary>
        /// <returns></returns>
        public static Size GetResolution()
        {
            Size size = new Size();
            IntPtr hdc = GetDC(IntPtr.Zero);
            size.Width = GetDeviceCaps(hdc, DeviceCapsType.DESKTOPHORZRES);
            size.Height = GetDeviceCaps(hdc, DeviceCapsType.DESKTOPVERTRES);
            ReleaseDC(IntPtr.Zero, hdc);
            return size;
        }
        /// <summary>
        /// 获取屏幕物理尺寸(mm,mm)
        /// </summary>
        /// <returns></returns>
        public static Size GetScreenSize()
        {
            Size size = new Size();
            IntPtr hdc = GetDC(IntPtr.Zero);
            size.Width = GetDeviceCaps(hdc, DeviceCapsType.HORZSIZE);
            size.Height = GetDeviceCaps(hdc, DeviceCapsType.VERTSIZE);
            ReleaseDC(IntPtr.Zero, hdc);
            return size;
        }

        /// <summary>
        /// 获取屏幕的尺寸---inch(英寸)
        /// </summary>
        /// <returns></returns>
        public static float GetScreenInch()
        {
            Size size = GetScreenSize();
            double inch = Math.Round(Math.Sqrt(Math.Pow(size.Width, 2) + Math.Pow(size.Height, 2)) / 25.4, 1);
            return (float)inch;
        }

        /// <summary>
        /// 获取显示器数量（不支持复制模式）
        /// </summary>
        /// <returns></returns>
        public static int Count()
        {
            int number = 0;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_DesktopMonitor");
            foreach (ManagementObject queryObj in searcher.Get())
            {
                number++;
            }
            return number;
        }
    }
}
