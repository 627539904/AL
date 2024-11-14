using AL.Env;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL.SysTool.VModels
{
    public class SysInfoVM:BaseVM
    {
        public string PCName { get; set; }
        public string CPU { get; set; }
        public string OSName { get; set; }
        /// <summary>
        /// OS架构
        /// </summary>
        public string OSArch { get; set; }

        public override void Init()
        {
            this.PCName = PCEnv.GetPCName();
            this.CPU = PCEnv.GetCPUInfo();
            var osInfo= PCEnv.GetOSInfo();
            this.OSName= osInfo.FullName;
            this.OSArch = osInfo.Architecture;
        }
    }
}
