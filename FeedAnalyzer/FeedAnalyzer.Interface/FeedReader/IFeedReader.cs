using FeedAnalyzer.Domain.Model;
using System.Collections.Generic;

namespace FeedAnalyzer.Interface.FeedReader
{
    public interface IFeedReader
    {
        IList<Article> Read(string url);
    }
}
