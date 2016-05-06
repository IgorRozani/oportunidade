using FeedAnalyzer.Domain.Helper;
using FluentAssertions;
using NUnit.Framework;

namespace FeedAnalyzer.Test.Domain.Unit
{
    [TestFixture]
    public class SpecialCharactersRemoverTest
    {
        [Test]
        public void RemoveSpecialCharacters()
        {
            var content = "Teste de texto, funcionou.?&^$#@!()+-,:;<>’\'_*.";
            var expectedContent = "Teste de texto funcionou-";
            var cleanContent = SpecialCharactersRemover.Remove(content);
            cleanContent.Should().Be(expectedContent);
        }
    }
}
