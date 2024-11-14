using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL.PC.Models
{
    public class MonitorInfo
    {
        /// <summary>
        /// 分辨率
        /// </summary>
        public Size Resolution { get; set; }
        /// <summary>
        /// 物理尺寸（单位:mm）
        /// </summary>
        public Size ScreenSize { get; set; }
        /// <summary>
        /// 物理尺寸（单位:inch，即英寸）
        /// </summary>
        public double ScreenSize_InInch { get; set; }
    }
}
