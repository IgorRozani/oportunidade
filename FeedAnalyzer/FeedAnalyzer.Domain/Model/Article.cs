using FeedAnalyzer.Domain.Helper;
using System.Collections.Generic;
using System.Linq;
using System;

namespace FeedAnalyzer.Domain.Model
{
    public class Article
    {
        private const int MAX_MOST_USED_WORDS = 10;

        public string Title { get; set; }
        public string Content { get; set; }

        public AnalyzeResult Analyze()
        {
            var wordList = CleanAndSplitContent();

            var quantityWords = wordList.Count;

            var groupedWords = wordList
                .GroupBy(w => w)
                .Select(w => new { Word = w.Key, Count = w.Count() });

            var quantityUniqueWords = groupedWords.Count();

            var sortedWords = groupedWords.OrderByDescending(w => w.Count).ToList();

            if (sortedWords.Count > MAX_MOST_USED_WORDS)
                sortedWords = sortedWords.Take(MAX_MOST_USED_WORDS).ToList();

            var mostUsedWords = sortedWords.ToDictionary(w => w.Word, w => w.Count);

            return new AnalyzeResult
            {
                Title = Title,
                QuantityWords = quantityWords,
                QuantityUniqueWords = quantityUniqueWords,
                MostUsedWords = mostUsedWords
            };
        }

        private List<string> CleanAndSplitContent()
        {
            var content = SpecialCharactersRemover.Remove(Content.ToLower());
            var wordList = content.Split(' ').ToList();

            return ArticleAndPrepositionRemover.Remove(wordList);
        }
    }
}
