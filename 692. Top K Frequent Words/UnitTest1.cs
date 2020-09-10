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
            var words = new string[] {"i", "love", "leetcode", "i", "love", "coding"};
            var k = 2;

            var actual = TopKFrequent(words, k);

            var expected = new List<string>() {"i", "love"};
            CollectionAssert.AreEqual(expected, actual); 
        }

 [Test]
        public void Test2()
        {
            var words = new string[] { "the", "day", "is", "sunny", "the", "the", "the", "sunny", "is", "is" };
            var k = 4;

            var actual = TopKFrequent(words, k);

            var expected = new List<string>() { "the", "is", "sunny", "day" };
            CollectionAssert.AreEqual(expected, actual); 
        }

        public IList<string> TopKFrequent(string[] words, int k)
        {
            var memo = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (memo.ContainsKey(word)) memo[word] += 1;
                else memo.Add(word, 1);
            }

            return memo.OrderByDescending(_ => _.Value).ThenBy(_ => _.Key).Select(_ => _.Key).Take(k).ToList();
        }
    }
}