using FeedAnalyzer.FeedReader;
using FeedAnalyzer.Interface.FeedReader;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
