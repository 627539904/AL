using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL.PC.Models
{
    public class PCPath
    {
        #region 文件命名-非法字符
        //命名时的非法字符
        public static string[] InvalidFileNameChars = new string[] {
    "?", "\"", "\\", "/", ":", "*", "<", ">", "|"
};
        public static Dictionary<char, string> InvalidCharReplace = new Dictionary<char, string>()
    {
        { '?', "_ASC63_" },  // ASCII码63对应问号(?)
        { '"', "_ASC34_" },  // ASCII码34对应双引号(")
        { '\\', "_ASC92_" }, // ASCII码92对应反斜杠(\\) 注意：在字符串中，反斜杠需要转义
        { '/', "_ASC47_" },  // ASCII码47对应正斜杠(/)
        { ':', "_ASC58_" },  // ASCII码58对应冒号(:)
        { '*', "_ASC42_" },  // ASCII码42对应星号(*)
        { '<', "_ASC60_" },  // ASCII码60对应小于号(<)
        { '>', "_ASC62_" },  // ASCII码62对应大于号(>)
        { '|', "_ASC124_" }  // ASCII码124对应竖线(|)
    };

        // 示例方法：替换文件名中的无效字符
        public static string ReplaceInvalidFileNameChars(string fileName)
        {
            foreach (var kvp in InvalidCharReplace)
            {
                fileName = fileName.Replace(kvp.Key.ToString(), kvp.Value);
            }
            return fileName;
        }

        // 示例方法：还原文件名中的替换字符
        public static string RestoreInvalidFileNameChars(string fileName)
        {
            foreach (var kvp in InvalidCharReplace)
            {
                fileName = fileName.Replace(kvp.Value, kvp.Key.ToString());
            }
            return fileName;
        }
        #endregion

        #region 特殊文件夹
        public static string DesktopPath => WindowsInfo.GetSpeicialFolderPath(SpecialFolder.Desktop);
        public static string DocumentsPath => WindowsInfo.GetSpeicialFolderPath(SpecialFolder.Documents);
        public static string DownloadsPath => WindowsInfo.GetSpeicialFolderPath(SpecialFolder.Downloads);
        public static string MusicPath => WindowsInfo.GetSpeicialFolderPath(SpecialFolder.Music);
        public static string PicturesPath => WindowsInfo.GetSpeicialFolderPath(SpecialFolder.Pictures);
        public static string VideosPath => WindowsInfo.GetSpeicialFolderPath(SpecialFolder.Videos);
        #endregion
    }
}
