using AL.ActionLibs;
using AL.ContentData;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL.Browser
{
    /// <summary>
    /// html解析器
    /// </summary>
    public class AHtmlParser
    {
        public HtmlData RawData { get; set; }
        public HtmlStruct StructData { get; set; }
        public AHtmlParser(string url)
        {
            this.RawData = new HtmlData() { Url = url };
        }

        HtmlDocument htmlDoc = new HtmlDocument();
        public async void Init()
        {
            var content=await this.RawData.Request();
            htmlDoc.LoadHtml(content);
            this.StructData = new HtmlStruct();
            this.StructData.Head = htmlDoc.DocumentNode.SelectSingleNode("//head");
            this.StructData.Body = htmlDoc.DocumentNode.SelectSingleNode("//body");
            this.StructData.Header = htmlDoc.DocumentNode.SelectSingleNode("//header");
            this.StructData.Nav = htmlDoc.DocumentNode.SelectSingleNode("//nav");
            this.StructData.Main = htmlDoc.DocumentNode.SelectSingleNode("//main");
            this.StructData.Article = htmlDoc.DocumentNode.SelectSingleNode("//article");
            this.StructData.Section = htmlDoc.DocumentNode.SelectSingleNode("//section");
            this.StructData.Aside = htmlDoc.DocumentNode.SelectSingleNode("//aside");
            this.StructData.Footer = htmlDoc.DocumentNode.SelectSingleNode("//footer");
        }
    }

    public class HtmlStruct
    {
        /// <summary>
        /// 包含页面的元数据和链接文件的声明，如页面标题、字符集编码、meta信息、外部样式表链接等。
        /// </summary>
        public HtmlNode Head { get; set; }
        /// <summary>
        /// 包含页面的可见内容，是用户在浏览器中看到的内容
        /// </summary>
        public HtmlNode Body { get; set; }
        /// <summary>
        /// 定义页眉或章节的头部内容，通常包含导航栏、Logo等
        /// </summary>
        public HtmlNode Header { get; set; }
        /// <summary>
        /// 导航区域，用于提供清晰的导航路径，帮助用户找到所需的信息和功能。
        /// </summary>
        public HtmlNode Nav { get; set; }
        /// <summary>
        /// 页面的主要内容部分。
        /// </summary>
        public HtmlNode Main { get; set; }
        /// <summary>
        /// 独立、完整的内容区域。
        /// </summary>
        public HtmlNode Article { get; set; }
        /// <summary>
        /// 定义页面中独立的内容区域。
        /// </summary>
        public HtmlNode Section { get; set; }
        /// <summary>
        /// 侧边栏，用于展示与主要内容相关的附加信息。
        /// </summary>
        public HtmlNode Aside { get; set; }
        /// <summary>
        /// 定义页脚，通常包含版权信息、社交链接等。
        /// </summary>
        public HtmlNode Footer { get; set; }

        public HtmlNode GetUIHead()
        {
            var headUI = this.Header;
            if( headUI == null)
                headUI = this.Head;
            return headUI;
        }

        public HtmlNode GetUIMain()
        {
            var mainBody = this.Main;
            if (mainBody == null)
            {
                mainBody = this.Body;
                //提取body中的class="container"的div
                //var containerDiv = mainBody.Descendants("div").FirstOrDefault(div => div.GetAttributeValue("class", "").Contains("container"));
                if (mainBody != null)
                {
                    var containerDivs = mainBody.SelectNodes("//div[@class='container']");
                    if (containerDivs != null && containerDivs.Count >= 2)
                    {
                        mainBody = containerDivs[1];
                    }
                }

            }
            return mainBody;
        }
    }
}
