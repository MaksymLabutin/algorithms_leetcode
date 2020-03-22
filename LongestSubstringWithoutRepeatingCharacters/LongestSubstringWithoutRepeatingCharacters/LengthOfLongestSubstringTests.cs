using System.Collections.Generic;
using NUnit.Framework;

namespace LongestSubstringWithoutRepeatingCharacters
{
    public class LengthOfLongestSubstringTests
    {
       
        [Test]
        public void Test1()
        {
            var str = "abcabcbb";

            var res = LengthOfLongestSubstring(str);

            var expectedRes = 3;

            Assert.AreEqual(expectedRes, res);
        }

        [Test]
        public void Test2()
        {
            var str = "bbbbb";

            var res = LengthOfLongestSubstring(str);

            var expectedRes = 1;

            Assert.AreEqual(expectedRes, res);
        }

        [Test]
        public void Test3()
        {
            var str = "pwwkew";

            var res = LengthOfLongestSubstring(str);

            var expectedRes = 3;

            Assert.AreEqual(expectedRes, res);
        }

        [Test]
        public void Test4()
        {
            var str = "";

            var res = LengthOfLongestSubstring(str);

            var expectedRes = 0;

            Assert.AreEqual(expectedRes, res);
        }

        [Test]
        public void Test5()
        {
            var str = "qwe";

            var res = LengthOfLongestSubstring(str);

            var expectedRes = 3;

            Assert.AreEqual(expectedRes, res);
        }

        [Test]
        public void Test6()
        {
            var str = "dvdf";

            var res = LengthOfLongestSubstring(str);

            var expectedRes = 3;

            Assert.AreEqual(expectedRes, res);
        }

        [Test]
        public void Test7()
        {
            var str = "anviaj";

            var res = LengthOfLongestSubstring(str);

            var expectedRes = 5;

            Assert.AreEqual(expectedRes, res);
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