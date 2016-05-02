using FeedAnalyzer.Domain.Model;
using FeedAnalyzer.FeedReader.Helper;
using FeedAnalyzer.Interface.FeedReader;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Xml.Linq;

namespace FeedAnalyzer.FeedReader
{
    public class FeedReader : IFeedReader
    {
        private IReader reader;

        public FeedReader(IReader reader)
        {
           this.reader = reader;
        }

        public IList<Article> Read(string url)
        {
            var feed = reader.ReadFeed(url);
            return ConvertFeedItemsToArticle(feed);
        }

        private IList<Article> ConvertFeedItemsToArticle(SyndicationFeed feed)
        {
            var articles = new List<Article>();
            foreach (var item in feed.Items)
                articles.Add(ConvertItemToArticle(item));

            return articles;
        }

        private Article ConvertItemToArticle(SyndicationItem item)
        {
            var article = new Article
            {
                Title = item.Title.Text,
                Content = GetItemContent(item.ElementExtensions)
            };
            return article;
        }

        private string GetItemContent(SyndicationElementExtensionCollection extensions)
        {
            var content = string.Empty;
            foreach (SyndicationElementExtension extension in extensions)
            {
                if (extension.GetObject<XElement>().Name.LocalName == "encoded")
                    content = extension.GetObject<XElement>().Value;
            }
            return HtmlTagsRemover.Remove(content);
        }
    }
}
