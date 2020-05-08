using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        [Test]
        public void Test1()
        {
            //["Hello","Alaska","Dad","Peace"]

            var words = new string[]{ "Hello", "Alaska", "Dad", "Peace" };
            var actual = FindWords(words);


        CollectionAssert.AreEqual(new string[]{ "Alaska", "Dad" }, actual);
        }

        [Test]
        public void Test2()
        {
            //["Hello","Alaska","Dad","Peace"]

            var words = new string[]{ "Aasdfghjkl", "Qwertyuiop", "zZxcvbnm" };
            var actual = FindWords(words);


        CollectionAssert.AreEqual(new string[]{ "Aasdfghjkl", "Qwertyuiop", "zZxcvbnm" }, actual);
        }

        private HashSet<char> _line1;
        private HashSet<char> _line2;
        private HashSet<char> _line3;

        public string[] FindWords(string[] words)
        {
            _line1 = new HashSet<char>() {'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p'};
            _line2 = new HashSet<char>() {'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l'};
            _line3 = new HashSet<char>() {'z', 'x', 'c', 'v', 'b', 'n', 'm'};

            var res = new List<string>();
            foreach (var word in words)
            {
                if (!CanBeTypedInOneLine(word)) continue;
                res.Add(word);
            }

            return res.ToArray();
        }

        private bool CanBeTypedInOneLine(string word)
        {
            var i = 0;

            HashSet<char> lineToCheck;

            var letter = char.ToLower(word[i]);

            if (_line1.Contains(letter)) lineToCheck = _line1;
            else if (_line2.Contains(letter)) lineToCheck = _line2;
            else lineToCheck = _line3;

            while (i < word.Length)
            { 
                if (!lineToCheck.Contains(char.ToLower(word[i]))) return false;
                i++;
            }

            return true;
        }
         
    }
}