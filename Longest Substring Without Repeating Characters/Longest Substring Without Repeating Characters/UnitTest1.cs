using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            var res = LengthOfLongestSubstring("abcabcbb");

            Assert.AreEqual(res, 3);
        }

        [Test]
        public void Test2()
        {
            var res = LengthOfLongestSubstring("bbbbb");

            Assert.AreEqual(res, 1);
        }

        [Test]
        public void Test3()
        {
            var res = LengthOfLongestSubstring("pwwkew");

            Assert.AreEqual(res, 3);
        }

        [Test]
        public void Test4()
        {
            var res = LengthOfLongestSubstring("aab");

            Assert.AreEqual(res, 2);
        }

        [Test]
        public void Test5()
        {
            var res = LengthOfLongestSubstring("dvdf");

            Assert.AreEqual(res, 3);
        }
        [Test]
        public void Test6()
        {
            var res = LengthOfLongestSubstring("ab");

            Assert.AreEqual(res, 2);
        }


        [Test]
        public void Test7()
        {
            var res = LengthOfLongestSubstring("abba");

            Assert.AreEqual(res, 2);
        }
        public int LengthOfLongestSubstring(string s)
        {
            var dic = new Dictionary<char, int>();

            var longestStrn = 0;
            var pointer = -1;

            for (var i = 0; i < s.Length; i++)
            {
                if (dic.ContainsKey(s[i]))
                {
                    pointer = pointer > dic[s[i]] ? pointer : dic[s[i]];
                    dic[s[i]] = i;
                }
                else
                {
                    dic.Add(s[i], i);
                }
                longestStrn = longestStrn > i - pointer ? longestStrn : i - pointer;

            }

            if (pointer == -1) return s.Length;

            return longestStrn;
        }
    }
}