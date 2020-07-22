using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        [Test]
        public void Test1()
        {
            var words = new string[] { "apple", "app" };
            var order = "abcdefghijklmnopqrstuvwxyz";

            var actual = IsAlienSorted(words, order);

            Assert.IsFalse(actual);
        }

        [Test]
        public void Test2()
        {
            var words = new string[] { "hello", "leetcode" };
            var order = "hlabcdefgijkmnopqrstuvwxyz";

            var actual = IsAlienSorted(words, order);

            Assert.IsTrue(actual);
        }

        [Test]
        public void Test3()
        {
            var words = new string[] { "word", "world", "row" };
            var order = "worldabcefghijkmnpqstuvxyz";

            var actual = IsAlienSorted(words, order);

            Assert.IsFalse(actual);
        }

        [Test]
        public void Test4()
        {
            var words = new string[] { "word"};
            var order = "worldabcefghijkmnpqstuvxyz";

            var actual = IsAlienSorted(words, order);

            Assert.IsTrue(actual);
        }

        [Test]
        public void Test5()
        { 
            var words = new string[] { "kuvp", "q" };
            var order = "ngxlkthsjuoqcpavbfdermiywz";

            var actual = IsAlienSorted(words, order);

            Assert.IsTrue(actual);
        }
        [Test]
        public void Test6()
        { 
            var words = new string[] { "apap", "app" };
            var order = "abcdefghijklmnopqrstuvwxyz";

            var actual = IsAlienSorted(words, order);

            Assert.IsTrue(actual);
        }

        public bool IsAlienSorted(string[] words, string order)
        {
            var alphabet = new Dictionary<char, int>();

            for (var i = 0; i < order.Length; i++)
            {
                alphabet.Add(order[i], i);
            }

            for (var w = 0; w < words.Length - 1; w++)
            { 
                for (var i = 0; i < words[w].Length; i++)
                {
                    if (words[w + 1].Length <= i)
                    {
                        if (alphabet[words[w + 1][i - 1]] >= alphabet[words[w][i]]) return false;
                        break;
                    }
                    if (alphabet[words[w][i]] > alphabet[words[w + 1][i]]) return false;

                    if (alphabet[words[w][i]] < alphabet[words[w + 1][i]]) break;  
                }
            }
            return true;
        }
    }
}