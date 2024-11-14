using AL.Env;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL.SysTool.VModels
{
    public interface IRefresh
    {
        public void Refresh();
    }
    public class RAM : BaseRamVM, IRefresh
    {
        public override void Init()
        {
            var info = PCEnv.GetMemoryInfo();
            Total = info.TotalMemory.ToString("0.00");
            Free = info.FreeMemory.ToString();
            Used = $"{info.UsedMemory}({info.UsedRate:F2}%)" ;
        }

        bool isRefresh = true;
        public void Refresh()
        {
            if (isRefresh)
            {
                var info = PCEnv.GetMemoryInfo();
                Free = info.FreeMemory.ToString();
                Used = $"{info.UsedMemory}({info.UsedRate:F2}%)";
            }
        }

        public void SwitchRefresh()
        {
            isRefresh = !isRefresh;
        }
    }
}
