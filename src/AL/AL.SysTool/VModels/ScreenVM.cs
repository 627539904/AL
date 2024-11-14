using AL.Env;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL.SysTool.VModels
{
    public class ScreenVM
    {
        //分辨率
        public string Resolution { get; set; }
        //屏幕尺寸
        public string Size { get; set; }
        //屏幕尺寸（英寸）
        public string SizeInch { get; set; }
        //屏幕数量
        public int ScreenCount { get; set; }

        public void Init()
        {
            var info = PCEnv.GetMonitorInfo();
            this.Resolution = $"{info.Resolution.Width}x{info.Resolution.Height}";
            this.Size = $"{info.ScreenSize.Width}x{info.ScreenSize.Height}";
            this.SizeInch = $"{info.ScreenSize_InInch}";
            var count= PCEnv.GetMonitorCount();
            this.ScreenCount = count;
        }
    }
}
