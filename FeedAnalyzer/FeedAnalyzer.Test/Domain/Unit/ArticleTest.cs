using FeedAnalyzer.Domain.Model;
using NUnit.Framework;

namespace FeedAnalyzer.Test.Domain.Unit
{
    [TestFixture]
    public class ArticleTest
    {
        private Article article;

        [SetUp]
        public void InitializeTests()
        {
            article = new Article();
        }

        [Test]
        public void TestMethod()
        {
            article.Content = "Texto de teste, quantas palavras teste terá?";
            var test = article.Analyze();
        }
    }
}
