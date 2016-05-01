using FeedAnalyzer.Interface.FeedReader;
using System.ServiceModel.Syndication;
using System.Xml;

namespace FeedAnalyzer.FeedReader
{
    public class FeedReader : IFeedReader
    {
        public SyndicationFeed Read(string url)
        {
            var reader = new XmlTextReader(url);

            return SyndicationFeed.Load(reader);
        }
    }
}
