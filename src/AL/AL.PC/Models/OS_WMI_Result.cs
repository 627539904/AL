using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL.PC.Models
{
    /// <summary>
    /// 针对Win32_OperatingSystem的取值
    /// </summary>
    public class OS_WMI_Result
    {
        public string Name { get; set; }
        public string Version { get; set; }
    }
}
