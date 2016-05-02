using FeedAnalyzer.FeedReader;
using FluentAssertions;
using NUnit.Framework;

namespace FeedAnalyzer.Test.FeedReader.Integration
{
    [TestFixture]
    public class ReaderTest
    {
        private const string FEED_URL = "https://www.minutoseguros.com.br/blog/feed";
        private Reader reader;

        [OneTimeSetUp]
        public void Initiliaze()
        {
            reader = new Reader();
        }

        [Test]
        public void ReadFeedFromUrl()
        {
            var feed = reader.ReadFeed(FEED_URL);

            feed.Should().NotBeNull();
        }
    }
}
