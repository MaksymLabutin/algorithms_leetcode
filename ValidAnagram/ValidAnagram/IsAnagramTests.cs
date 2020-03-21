using System.Collections.Generic;
using NUnit.Framework;

namespace ValidAnagram
{
    public class IsAnagramTests
    { 

        [Test]
        public void Should_be_anagram_When_strings_are_right()
        {
            const string s = "anagram";
            const string t = "nagaram";

            var isAnagram = IsAnagram(s, t);

            Assert.IsTrue(isAnagram);
        }

        [Test]
        public void Should_not_be_anagram_When_strings_are_different()
        {
            const string s = "anagramr";
            const string t = "nagarama";

            var isAnagram = IsAnagram(s, t);

            Assert.IsFalse(isAnagram);
        }

        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length) return false;

            var dic = new Dictionary<char, int>();

            foreach (var symbol in s)
            {
                if(dic.ContainsKey(symbol)) dic[symbol] += 1;
                else dic.Add(symbol, 1);
            }

            foreach (var symbol in t)
            {
                if (dic.ContainsKey(symbol))
                {
                    if (dic[symbol] <= 0) return false;
                    dic[symbol] -= 1; 
                }
                else return false;
            }

            return true;
        }
    }
}