using FeedAnalyzer.FeedReader.Helper;
using FluentAssertions;
using NUnit.Framework;

namespace FeedAnalyzer.Test.FeedReader.Unit
{
    [TestFixture]
    public class HtmlTagsRemoverTest
    {
        [Test]
        public void RemoveHtmlFromString()
        {
            var content = "<html><body><p>Teste</p><br/></body></html>";

            var cleanContent = HtmlTagsRemover.Remove(content);

            cleanContent.Should().Be("Teste");
        }

        [Test]
        public void RemoveHtmlWithAttributesFromString()
        {
            var content = "<p> Veja a <a href = \"https://www.minutoseguros.com.br/blog/imprensa/dicas-empreendedorismo-marcelo-blay-1\" target = \"_blank\" > parte 1 </ a >";
            var cleanContent = HtmlTagsRemover.Remove(content);
            cleanContent.Should().Be("Veja a  parte 1");
        }

        [Test]
        public void RemoveHtmlFromEmptyString()
        {
            var content = string.Empty;
            var cleanContent = HtmlTagsRemover.Remove(content);
            cleanContent.Should().Be(string.Empty);
        }
    }
}
