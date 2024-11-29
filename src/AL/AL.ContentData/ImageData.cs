using AL.PC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL.ContentData
{
    public class ImageData : ICache
    {
        public string CachePath { get; set; }= basePath;
        public string Content { get; set; }

        public static string basePath = PCPath.DocumentsPath + @"\Cache\Image\";

        public void InitCachePath()
        {
            throw new NotImplementedException();
        }
    }
}
