using FluentAssertions;
using NUnit.Framework;

namespace FeedAnalyzer.Test.FeedReader.Integration
{
    [TestFixture]
    public class FeedReaderTest
    {
        private FeedAnalyzer.FeedReader.FeedReader reader;

        [OneTimeSetUp]
        public void Initialize()
        {
            reader = new FeedAnalyzer.FeedReader.FeedReader();
        }

        [Test]
        public void ReadFeedFromUrl()
        {
            var feed = reader.Read("https://www.minutoseguros.com.br/blog/feed");

            feed.Should().NotBeNull();
        }
    }
}
