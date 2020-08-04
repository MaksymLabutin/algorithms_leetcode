using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        [Test]
        public void Test1()
        {
            var s = "A man, a plan, a canal: Panama";

            var actual = IsPalindrome(s);

            Assert.IsTrue(actual);
        }

        [Test]
        public void Test2()
        {
            var s = "race a car";

            var actual = IsPalindrome(s);

            Assert.IsFalse(actual);
        }

        [Test]
        public void Test3()
        {
            var s = "";

            var actual = IsPalindrome(s);

            Assert.IsTrue(actual);
        }


        [Test]
        public void Test4()
        {
            var s = "0P";

            var actual = IsPalindrome(s);

            Assert.IsFalse(actual);
        }

        public bool IsPalindrome(string s)
        {
            var l = 0;
            var r = s.Length - 1;

            var hs = new HashSet<int>();
            for (int i = 48; i < 58 ; i++)
            {
                hs.Add(i); 
            }

            for (int i = 97; i < 122 ; i++)
            {
                hs.Add(i); 
            }
             
            s = s.ToLower();
            while (l < r)
            {
                if (!hs.Contains(s[l]) || !hs.Contains(s[r]))
                {
                    if(!hs.Contains(s[l])) l++;
                    if (!hs.Contains(s[r])) r--;
                    continue;
                } 
                if (s[l] != s[r]) return false;
                l++;
                r--;
            }

            return true;
        }
    }
}