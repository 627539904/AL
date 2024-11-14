using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL.PC.Models
{
    /// <summary>
    /// 内存信息
    /// </summary>
    public class MemoryInfo
    {
        /// <summary>
        /// 总内存(GB)
        /// </summary>
        public double TotalMemory { get; set; }
        /// <summary>
        /// 可用内存(GB)
        /// </summary>
        public double FreeMemory { get; set; }
        /// <summary>
        /// 已使用内存(GB)
        /// </summary>
        public double UsedMemory { get; set; }
        /// <summary>
        /// 已使用内存占比(0-1)
        /// </summary>
        public double UsedRate { get; set; }
    }
}
