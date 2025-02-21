using AL.ContentData;
using Arvin.Helpers;
using Arvin.LogHelper;
using Microsoft.Extensions.Options;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QRCoder.PayloadGenerator;

namespace AL.Browser
{
    public class ADevTools
    {
        public string Url { get; set; }
        public ADevTools(string url)
        {
            this.Url = url;
            Init();
            Start();
        }
        ~ADevTools()
        {
            // 关闭浏览器
            driver.Quit();
        }
        static IWebDriver driver=null;
        static void Init()
        {
            if (driver != null)
                return;
            // 设置Chrome选项，开启无头模式
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--headless");

            // 初始化ChromeDriver
            driver = new ChromeDriver(options);
        }

        void Start()
        {
            // 打开指定的URL
            driver.Navigate().GoToUrl(this.Url);
        }

        public string GetCurrentUrl()
        {
            return driver.Url;
        }
        /// <summary>
        /// 获取原始URL
        /// </summary>
        /// <returns></returns>
        public string GetRawUrl()
        {
            return this.Url;
        }

        /// <summary>
        /// 当前Url屏幕截图
        /// </summary>
        /// <returns></returns>
        public string Screenshot()
        {
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            string path = this.GetCurrentUrl().UrlToImagePath();
            screenshot.SaveAsFile(path);
            return path;
        }

        public void Element_Click(By by)
        {
            try
            {
                // 查找元素并进行操作（例如：点击一个按钮）
                //IWebElement button = driver.FindElement(By.Id("myButton"));
                //IWebElement link = driver.FindElement(By.CssSelector("a[href='/models']"));
                IWebElement element = driver.FindElement(by);
                element.Click();
                // 等待一段时间，以便观察效果（在无头模式下，这通常是为了确保操作完成）
                Thread.Sleep(3000);
            }
            catch (Exception ex)
            {
                ALog.Debug(ex.Message);
            }
        }
    }
}
