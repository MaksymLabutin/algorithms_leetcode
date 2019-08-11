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
            Assert.AreEqual(0, FirstUniqChar("leetcode"));
        }
        [Test]
        public void Test2()
        {
            Assert.AreEqual(-1, FirstUniqChar("aabbb"));
        }
        [Test]
        public void Test3()
        {
            Assert.AreEqual(2, FirstUniqChar("loveleetcode"));
        }

        public int FirstUniqChar(string s)
        {
            var dic = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; i++)
            {
                if (dic.ContainsKey(s[i])) dic[s[i]] = int.MaxValue;
                else
                {
                    dic.Add(s[i], i);
                }
            } 

            var res = int.MaxValue;
            foreach (var value in dic.Values)
            {
                res = value < res ? value : res;
            } 

            return res == int.MaxValue ? -1 : res;
        }
    }
}