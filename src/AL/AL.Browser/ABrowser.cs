using AL.PC;
using AL.PC.Models;
using Arvin.Extensions;
using PuppeteerSharp;

namespace AL.Browser
{
    public class ABrowser
    {
        public static string BrowserBasePath = PCPath.DocumentsPath + "AL\\Browser\\";

        /// <summary>
        /// url截图
        /// </summary>
        /// <param name="url"></param>
        /// <param name="savePath"></param>
        /// <returns>返回路径</returns>
        public async static Task<string> ScreenShot(string url,string savePath="")
        {
            var app = WindowsInfo.GetAppInfo("chrome");
            // 设置Chrome浏览器的可执行文件路径
            string chromeExecutablePath = app.StartPath;
            // 下载Chromium浏览器（如果需要）并启动浏览器
            //await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);
            var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true,
                ExecutablePath = chromeExecutablePath  // 指定Chrome的可执行文件路径
            });

            if (string.IsNullOrEmpty(savePath))
                savePath= BrowserBasePath + $"{url.ToSafeFileName()}.png";
            try
            {
                // 打开一个新页面
                var page = await browser.NewPageAsync();

                // 打开指定的URL
                await page.GoToAsync(url);

                // 截取整个页面的截图并保存
                savePath.InitDirectory();
                await page.ScreenshotAsync(savePath, new ScreenshotOptions { FullPage = true });
            }
            finally
            {
                // 关闭浏览器
                await browser.CloseAsync();
            }
            return savePath;
        }
    }
}
