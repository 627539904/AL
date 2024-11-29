using AL.PC.Models;
using Arvin.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL.ContentData
{
    /// <summary>
    /// Html数据
    /// </summary>
    public class HtmlData : ICache
    {
        public string Url { get; set; }
        public string Content { get; set; }
        public string CachePath { get; set; } = basePath;

        public static string basePath = PCPath.DocumentsPath + @"\Cache\Html\";
        public void InitCachePath()
        {
            this.CachePath = basePath + PCPath.ReplaceInvalidFileNameChars(this.Url) + ".txt";
            this.CachePath.InitDirectory();
        }
    }

    public interface ICache
    {
        /// <summary>
        /// 数据缓存路径
        /// </summary>
        public string CachePath { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        public string Content { get; set; }
        public void InitCachePath();
    }
}
