using FeedAnalyzer.Domain.Helper;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace FeedAnalyzer.Test.Domain.Unit
{
    [TestFixture]
    public class ArticleAndPrepositionRemoverTest
    {
        [Test]
        public void RemoveArticlesAndPrepostionsFromEmptyString()
        {
            var cleanContent = ArticleAndPrepositionRemover.Remove(null);
            cleanContent.ShouldBeEquivalentTo(null);
        }

        [Test]
        public void RemoveArticlesAndPrepostionsFromString()
        {
            var words = new List<string> { "isso", "é", "um", "texto", "de", "teste" };
            var expectedWords = new List<string> { "é", "texto", "teste" };
            var cleanContent = ArticleAndPrepositionRemover.Remove(words);
            cleanContent.ShouldAllBeEquivalentTo(expectedWords);
        }
    }
}
