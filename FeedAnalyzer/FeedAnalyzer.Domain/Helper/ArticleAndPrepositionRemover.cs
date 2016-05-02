using System.Collections.Generic;
using System.Linq;

namespace FeedAnalyzer.Domain.Helper
{
    public class ArticleAndPrepositionRemover
    {
        private static List<string> wordsToRemove = new List<string>
        {
            "a", "as", "o", "os", "um", "uns",  "uma", "umas",
            "ao", "aos", "à", "às", "de","do", "dos", "da", "das", "dum", "duns", "duma", "dumas",
            "em",  "no", "nos", "na", "nas", "num", "nuns", "numa", "numas",
            "por",  "per", "pelo", "pelos", "pela", "pelas", "com", "e", "isso", "que","quem","como", "para", "qual",
            "ante", "após", "até", "contra", "desde","entre", "perante", "sem", "sob", "sobre", "trás",
            "conforme", "segundo", "durante", "salvo", "fora", "mediante","tirante", "exceto", "senão", "visto"
        };

        public static List<string> Remove(List<string> words)
        {
            if (words == null || !words.Any())
                return null;

            return words.Where(w => !wordsToRemove.Contains(w) && w.Length > 2).ToList();
        }
    }
}
