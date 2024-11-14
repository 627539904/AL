using AL.PC.Models;
using Arvin.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL.PC.SysTools
{
    public class nvidia_smi
    {
        public static string Read()
        {
            return Cmd.Read("nvidia-smi --query-gpu=index,uuid,utilization.gpu,memory.total,memory.used,memory.free --format=csv,noheader,nounits");
        }

        public static nvidiaInfo ReadInfo()
        {
            string infoStr= Read();
            string[] info = infoStr.Split(',');
            return new nvidiaInfo()
            {
                Index = info[0].Trim(),
                UUID = info[1].Trim(),
                Utilization = info[2].Trim(),
                MemoryTotal = info[3].Trim(),
                MemoryUsed = info[4].Trim(),
                MemoryFree = info[5].Trim()
            };
        }
    }

    public class nvidiaInfo
    {
        public string Index { get; set; }
        public string UUID { get; set; }
        public string Utilization { get; set; }
        public string MemoryTotal { get; set; }
        public string MemoryUsed { get; set; }
        public string MemoryFree { get; set; }

        public GPUMemory ToMemoryInfo()
        {
            return new GPUMemory()
            {
                TotalMemory = MemoryTotal.ToDouble()/1024,
                UsedMemory = MemoryUsed.ToDouble()/1024,
                FreeMemory = MemoryFree.ToDouble()/1024,
                UsedRate = Utilization.ToDouble(),
            };
        }
    }
}
