using FeedAnalyzer.Domain.Model;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace FeedAnalyzer.Test.Domain.Unit
{
    [TestFixture]
    public class ArticleTest
    {
        private Article article;
        private Dictionary<string, int> expectedMostUsedWords;
        private const string EXAMPLE_TITLE = "Título de teste";
        private const string EXAMPLE_CONTENT = "Texto de teste, quantas palavras teste terá?";

        [OneTimeSetUp]
        public void Initialize()
        {
            expectedMostUsedWords = new Dictionary<string, int>();
            expectedMostUsedWords.Add("teste", 2);
            expectedMostUsedWords.Add("texto", 1);
            expectedMostUsedWords.Add("quantas", 1);
            expectedMostUsedWords.Add("palavras", 1);
            expectedMostUsedWords.Add("terá", 1);
        }

        [SetUp]
        public void InitializeTests()
        {
            article = new Article();
        }

        [Test]
        public void ArticleAnalyzeShouldReturnMostUsedWordsWitOneWordWithTwoAndFourWordsWithOne()
        {
            var result = ExecuteAnalyze(EXAMPLE_CONTENT);
            result.MostUsedWords.ShouldBeEquivalentTo(expectedMostUsedWords);
        }

        [Test]
        public void ArticleAnalyzeShouldReturn5MostUsedWords()
        {
            var result = ExecuteAnalyze(EXAMPLE_CONTENT);
            result.MostUsedWords.Should().HaveCount(5);
        }

        [Test]
        public void ArticleAnalyzeShouldReturn10MostUsedWords()
        {
            var content = "abacaxi, perâ, uva, maçã, kiwi, jaboticaba, banana, morango, laranja, jaca, carambola, tamarindo";
            var result = ExecuteAnalyze(content);
            result.MostUsedWords.Should().HaveCount(10);
        }

        [Test]
        public void ArticleAnalyzeShouldReturn5InQuantityWords()
        {
            var result = ExecuteAnalyze(EXAMPLE_CONTENT);
            result.QuantityWords.Should().Be(6);
        }

        [Test]
        public void ArticleAnalyzeShouldReturn5InQuantityUniqueWords()
        {
            var result = ExecuteAnalyze(EXAMPLE_CONTENT);
            result.QuantityUniqueWords.Should().Be(5);
        }

        [Test]
        public void ArticleAnalyzeShouldReturnArticleTitle()
        {
            article.Title = EXAMPLE_TITLE;
            var result = ExecuteAnalyze(EXAMPLE_CONTENT);
            result.Title.Should().Be(EXAMPLE_TITLE);
        }

        private ArticleAnalyzeResult ExecuteAnalyze(string content)
        {
            article.Content = content;
            return article.Analyze();
        }
    }
}
