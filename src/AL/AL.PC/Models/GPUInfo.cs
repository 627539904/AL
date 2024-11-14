using Arvin.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL.PC.Models
{
    public class GPUInfo
    {
        /// <summary>
        /// 显卡名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 显存大小(GB)
        /// </summary>
        public GPUMemory Memory { get; set; }
        /// <summary>
        /// 显卡厂商,如NVIDIA或其他标志
        /// </summary>
        public string Belong { get; set; }
        /// <summary>
        /// 驱动版本
        /// </summary>
        public string DriverVersion { get; set; }
        /// <summary>
        /// 驱动日期
        /// </summary>
        public string DriverDate { get; set; }

        public override string ToString()
        {
            return this.ToJsonIgnoreNull();
        }
    }

    public class GPUMemory:MemoryInfo
    {

    }
}
