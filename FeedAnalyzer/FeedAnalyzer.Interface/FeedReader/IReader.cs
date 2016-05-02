using System.ServiceModel.Syndication;

namespace FeedAnalyzer.Interface.FeedReader
{
    public interface IReader
    {
        SyndicationFeed ReadFeed(string url);
    }
}
