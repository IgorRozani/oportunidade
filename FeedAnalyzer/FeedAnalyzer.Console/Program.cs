using FeedAnalyzer.Domain.Model;
using FeedAnalyzer.FeedReader;
using FeedAnalyzer.Interface.FeedReader;
using System.Collections.Generic;
using System.Configuration;

namespace FeedAnalyzer.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var articles = GetArticles();

            foreach (var article in articles)
            {
                var analyzeResult = article.Analyze();
                PrintAnalyze(analyzeResult);
            }

            System.Console.ReadKey();
        }

        private static void PrintAnalyze(AnalyzeResult analyzeResult)
        {
            System.Console.WriteLine($"Artigo: {analyzeResult.Title}");
            System.Console.WriteLine($"Quantidade de palavras: {analyzeResult.QuantityWords}");
            System.Console.WriteLine($"Quantidade de palavras únicas: {analyzeResult.QuantityUniqueWords}");
            System.Console.WriteLine("Palavras mais utilizadas:");

            PrintWords(analyzeResult.MostUsedWords);

            System.Console.WriteLine(string.Empty);
        }

        private static void PrintWords(Dictionary<string, int> words)
        {
            foreach (var word in words)
            {
                var plural = string.Empty;
                if (word.Value > 1)
                    plural = "s";
                System.Console.WriteLine($"{word.Key}: {word.Value} ocorrência{plural}");
            }
        }

        private static IList<Article> GetArticles()
        {
            IReader reader = new Reader();
            IFeedReader feedReader = new FeedReader.FeedReader(reader);
            var feedUrl = ConfigurationSettings.AppSettings["FeedUrl"];

            return feedReader.Read(feedUrl);
        }
    }
}
