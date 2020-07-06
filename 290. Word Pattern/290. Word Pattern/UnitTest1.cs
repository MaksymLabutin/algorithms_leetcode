using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        

        [Test]
        public void Test1()
        {
            var pattern = "abba";
            var str = "dog cat cat dog";

            var actual = WordPattern(pattern, str);

            Assert.IsTrue(actual);
        }

        [Test]
        public void Test2()
        {
            var pattern = "abba";
            var str = "dog cat cat fish";

            var actual = WordPattern(pattern, str);

            Assert.IsFalse(actual);
        }

        [Test]
        public void Test3()
        {
            var pattern = "abba";
            var str = "dog dog dog fish";

            var actual = WordPattern(pattern, str);

            Assert.IsFalse(actual);
        }

        [Test]
        public void Test4()
        {
            var pattern = "abba";
            var str = "dog dog dog dog";

            var actual = WordPattern(pattern, str);

            Assert.IsFalse(actual);
        }

        [Test]
        public void Test5()
        {
            var pattern = "aaa";
            var str = "aa aa aa aa";

            var actual = WordPattern(pattern, str);

            Assert.IsFalse(actual);
        }

        public bool WordPattern(string pattern, string str)
        {
            var dictionary = new Dictionary<string, char>();

            var words = str.Split(" ");

            for (var i = 0; i < words.Length; i++)
            {
                if (pattern.Length <= i) return false;
                if (dictionary.ContainsKey(words[i]) && dictionary[words[i]] != pattern[i]) return false;
                else if(!dictionary.ContainsKey(words[i])) dictionary.Add(words[i], pattern[i]);
            }

            var uniqSympols = pattern.GroupBy(_ => _).Count();

            return uniqSympols == dictionary.Count; 

        }
    }
}