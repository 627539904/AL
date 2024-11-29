using AL.ActionLibs;
using AL.Browser;
using AL.PC.Models;
using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PuppeteerSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL.Demo
{
    public class BrowserDemo
    {
        public static void Demo()
        {
            //ScreenShot_Demo();
            //WebDriver_Click_Demo();
            HtmlStruct();
            //ReadHtmlTest();
        }

        //网页截图Demo
        static async void ScreenShot_Demo()
        {
            string url = "https://ollama.com/search";
            string savePath=await ABrowser.ScreenShot(url);
            Console.WriteLine(savePath);
        }

        //网页元素点击
        static void WebDriver_Click_Demo()
        {
            string url = "https://ollama.com/";
            ADevTools devTools = new ADevTools(url);

            //Console.WriteLine($"点击前Url:{devTools.GetCurrentUrl()}");
            //string path_front=devTools.Screenshot();
            //Console.WriteLine(path_front);
            devTools.Element_Click(By.CssSelector("a[href='/models']"));

            //Console.WriteLine($"点击后Url:{devTools.GetCurrentUrl()}");
            //string path_finish = devTools.Screenshot();
            //Console.WriteLine(path_finish);
        }

        //网页结构
        async static void HtmlStruct()
        {
            string url = "https://ollama.com/search";
            AHtmlParser htmlParser = new AHtmlParser(url);
            htmlParser.Init();

            Console.WriteLine(htmlParser.StructData.GetUIHead().InnerText);
        }

        //网页内容提取
        async static void ReadHtmlTest()
        {
            string url = "https://ollama.com/search";
            string lastRes = await ARead.ReadHtml(url);
            //Console.WriteLine(lastRes);
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(lastRes);

            // 示例：提取所有标题（可以根据需要修改选择器）
            var titles = htmlDoc.DocumentNode.SelectNodes("//h1 | //h2 | //h3 | //h4 | //h5 | //h6")
                                .Select(node => node.InnerText.Trim())
                                .ToList();

            // 示例：提取所有链接（可以根据需要修改选择器）
            var links = htmlDoc.DocumentNode.SelectNodes("//a[@href]")
                                .Select(node => node.GetAttributeValue("href", string.Empty))
                                .ToList();

            // 打印提取的信息（这里只是示例，你可以根据需要处理这些信息）
            Console.WriteLine("Titles:");
            foreach (var title in titles)
            {
                Console.WriteLine(title);
            }
            Console.WriteLine();
            Console.WriteLine("\nLinks:");
            foreach (var link in links)
            {
                Console.WriteLine(link);
            }
        }
    }
}
