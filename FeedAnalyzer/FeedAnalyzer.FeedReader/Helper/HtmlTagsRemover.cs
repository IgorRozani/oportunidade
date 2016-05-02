using System.Text.RegularExpressions;

namespace FeedAnalyzer.FeedReader.Helper
{
    public static class HtmlTagsRemover
    {
        public static string Remove(string content)
        {
            return Regex.Replace(content, "<.*?>", string.Empty).Trim();
        }
    }
}
