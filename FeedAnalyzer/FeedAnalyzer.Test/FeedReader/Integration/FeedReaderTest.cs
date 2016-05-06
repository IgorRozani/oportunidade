using FeedAnalyzer.FeedReader;
using FluentAssertions;
using NUnit.Framework;

namespace FeedAnalyzer.Test.FeedReader.Integration
{
    [TestFixture]
    public class FeedReaderTest
    {
        private const string FEED_URL = "https://www.minutoseguros.com.br/blog/feed";
        private FeedAnalyzer.FeedReader.FeedReader feedReader;

        [OneTimeSetUp]
        public void Initiliaze()
        {
            var reader = new Reader();
            feedReader = new FeedAnalyzer.FeedReader.FeedReader(reader);
        }

        [Test]
        public void Read10ArticlesFromUrl()
        {
            var articles = feedReader.Read(FEED_URL);
            articles.Should().NotBeNull().And.HaveCount(10);
        }

        [Test]
        public void ContentArticleDoesntHaveHtmlTag()
        {
            var articles = feedReader.Read(FEED_URL);
            
        }
    }
}
