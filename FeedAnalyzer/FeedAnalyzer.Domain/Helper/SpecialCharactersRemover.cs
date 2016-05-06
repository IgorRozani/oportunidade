using System.Linq;
using System.Text;

namespace FeedAnalyzer.Domain.Helper
{
    public static class SpecialCharactersRemover
    {
        const string removeChars = "?&^$#@!()+,:;<>’\'_*.";

        public static string Remove(string content)
        {
            var cleanText = new StringBuilder();

            foreach (char x in content.Where(c => !removeChars.Contains(c)))
                cleanText.Append(x);

            return cleanText.ToString();
        }
    }
}
