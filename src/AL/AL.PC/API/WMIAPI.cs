using AL.PC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace AL.PC.API
{
    public class WMIAPI
    {
        public static List<OS_WMI_Result> GetOSInfo()
        {
            var os = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
            List<OS_WMI_Result> osInfos = new List<OS_WMI_Result>();
            foreach (var item in os.Get())
            {
                OS_WMI_Result osResult = new OS_WMI_Result();
                osResult.Name = item["Caption"].ToString();
                osResult.Version = item["Version"].ToString();
                osInfos.Add(osResult);
            }
            return osInfos;
        }
    }
}
