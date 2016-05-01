using System.ServiceModel.Syndication;

namespace FeedAnalyzer.Interface.FeedReader
{
    public interface IFeedReader
    {
        SyndicationFeed Read(string url);
    }
}
