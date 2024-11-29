using AL.PC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL.PC
{
    /// <summary>
    /// PC扩展类
    /// </summary>
    public static class PCExtension
    {
        /// <summary>
        /// 将字符串转换为安全的文件名
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToSafeFileName(this string str)
        {
            return PCPath.ReplaceInvalidFileNameChars(str);
        }
        /// <summary>
        /// 将安全的文件名转换为原始字符串
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string ToRawName(this string fileName)
        {
            return PCPath.RestoreInvalidFileNameChars(fileName);
        }
    }
}
