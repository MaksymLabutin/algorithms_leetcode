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
            var set = new HashSet<char>();

            var res = 0;

            for (var i = 0; i < s.Length; i++)
            {
                if (set.Contains(s[i]))
                {
                    res = set.Count > res ? set.Count : res;

                    set.Clear();

                    set.Add(s[i - 1]);
                    set.Add(s[i]);
                }
                else set.Add(s[i]);
            }

            return set.Count > res ? set.Count : res;
        }
    }
}