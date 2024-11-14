using AL.Env;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL.SysTool.VModels
{
    public class GPUVM:BaseRamVM,IRefresh
    {
        public string Name { get; set; }
        public string DriverVersion { get; set; }
        public override void Init()
        {
            var info=PCEnv.GetGPUInfo();
            this.Total = info.Memory.TotalMemory.ToString("0.00");
            this.Used = info.Memory.UsedMemory.ToString("0.00");
            this.Free =$"{info.Memory.FreeMemory.ToString("0.00")}({info.Memory.UsedRate:F2}%)" ;
            this.Name = info.Name;
            this.DriverVersion = info.DriverVersion;
        }

        public void Refresh()
        {
            var info = PCEnv.GetGPUInfo();
            Free = info.Memory.FreeMemory.ToString("0.00");
            Used = $"{info.Memory.UsedMemory:F2}({info.Memory.UsedRate:F2}%)";
        }
    }
}
