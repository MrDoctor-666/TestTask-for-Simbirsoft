using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;

namespace SimbirSoftTest
{
    //keeping the unique word in site
    public class UniqWord
    {
        public string word { get; private set; }
        public int count { get; private set; }
        public UniqWord(string word, int count)
        {
            this.word = word;
            this.count = count;
        }

        public string StringToPrint
        {
            get
            {
                return (word + " - " + count.ToString());
            }
        }
    }

    public class WordCounter
    {
        string text;
        public List<UniqWord> words { get; private set; } //keep in memory
        char[] toSplit = { ' ', ',', '.', '!', '?', '"', ';', ':', '[', ']', '(', ')', '\n', '\r', '\t' };

        public void Count(string text)
        {
            this.text = text;

            string[] allWords = text.Split(toSplit, StringSplitOptions.RemoveEmptyEntries);
            var uniqueWords = allWords
                .GroupBy(x => x, StringComparer.InvariantCultureIgnoreCase)
                .OrderByDescending(group => group.Count());

            //could've just printed a result here but
            //foreach (var w in uniqueWords) Console.WriteLine(w.Key + " " + w.Count());
            words = new List<UniqWord>();
            foreach (var w in uniqueWords)
            {
                words.Add(new UniqWord(w.Key, w.Count()));
            }
        }
    }
}
