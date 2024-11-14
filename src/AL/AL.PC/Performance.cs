using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL.PC
{
    /// <summary>
    /// 性能计数器
    /// </summary>
    public class Performance
    {
        /// <summary>
        /// 获取计数器类别
        /// </summary>
        /// <returns></returns>
        public static string[] GetCounterTypes()
        {
            return PerformanceCounterCategory.GetCategories().Select(x => x.CategoryName).ToArray();
        }
    }
}
