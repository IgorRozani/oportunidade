using FeedAnalyzer.Interface.FeedReader;
using System.ServiceModel.Syndication;
using System.Xml;

namespace FeedAnalyzer.FeedReader
{
    public class Reader : IReader
    {
        public SyndicationFeed ReadFeed(string url)
        {
            var reader = new XmlTextReader(url);

            return SyndicationFeed.Load(reader);
        }
    }
}
