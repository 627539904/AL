using AL.PC;
using Arvin.Extensions;

namespace AL.ContentData
{
    public static class DataExtension
    {
        #region 针对ICache的扩展方法
        public static string ReadCache(this ICache cache)
        {
            cache.InitCachePath();
            return cache.CachePath.ReadFile();
        }
        public static void WriteCache(this ICache cache)
        {
            cache.InitCachePath();
            cache.CachePath.WriteFile(cache.Content);
        }
        #endregion

        #region 默认路径
        public static string DefaultImagePath()
        {
            return ImageData.basePath;
        }
        public static string UrlToImagePath(this string url)
        {
            string path= DefaultImagePath() + url.ToSafeFileName()+".png";
            path.InitDirectory();
            return path;
        }
        #endregion
    }
}
