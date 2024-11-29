using AL.ContentData;
using Arvin.Helpers;

namespace AL.ActionLibs
{
    public static class ARead
    {
        public async static Task<HtmlData> ReadHtml(this HtmlData data)
        {
            string url = data.Url;
            var cache = data.ReadCache();
            if (!string.IsNullOrWhiteSpace(cache))
            {
                data.Content = cache;
                return data;
            }
            string content = await HttpHelper.GetAsync(url, true);
            data.Content = content;
            data.WriteCache();
            return data;
        }
        public async static Task<string> ReadHtml(this string url)
        {
            var res = await ReadHtml(new HtmlData() { Url = url });
            return res.Content;
        }
        public async static Task<string> Request(this HtmlData data)
        {
            var res = await ReadHtml(data);
            return res.Content;
        }
    }
}
