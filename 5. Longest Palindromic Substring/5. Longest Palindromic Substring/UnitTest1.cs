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
            var s = "babad";

            var actual = LongestPalindrome(s);

            var expected = "bab";

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test2()
        {
            var s = "abacdfgdcaba";

            var actual = LongestPalindrome(s);

            var expected = "aba";

            Assert.AreEqual(expected, actual);
        }

        public string LongestPalindrome(string s)
        {
            if (s.Length < 2) return s;

            (int start, int end) longest = (0, 0);
            
            for (var i = 0; i < s.Length - 1; i++)
            {
                if (s[i] == s[i + 1])
                {
                    var res = LongestPalindrome(s, i, i + 1);
                    longest = res.end - res.start > longest.end - longest.start ? res : longest;
                }

                if (i + 2 < s.Length && s[i] == s[i + 2])
                {
                    var res = LongestPalindrome(s, i, i + 2);
                    longest = res.end - res.start > longest.end - longest.start ? res : longest;
                }
            }

            return (longest.start == 0 && longest.end == 0) ? 
                s[0].ToString() : 
                s.Substring(longest.start, longest.end - longest.start + 1);
        }

        private (int start, int end) LongestPalindrome(string s, int start, int end)
        { 
            while (start >= 0 && end < s.Length && s[start] == s[end])
            {
                start--;
                end++;
            }

            return (start + 1, end - 1);
        }
    }
}