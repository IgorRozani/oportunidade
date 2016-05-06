using System.Collections.Generic;

namespace FeedAnalyzer.Domain.Model
{
    public class ArticleAnalyzeResult
    {
        public string Title { get; set; }
        public int QuantityWords { get; set; }
        public int QuantityUniqueWords { get; set; }
        public Dictionary<string, int> MostUsedWords { get; set; }
    }
}
