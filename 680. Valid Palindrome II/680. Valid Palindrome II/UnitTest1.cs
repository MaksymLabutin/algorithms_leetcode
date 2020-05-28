using NUnit.Framework;

namespace Tests
{
    public class Tests
    { 
        [Test]
        public void Test1()
        {
            var s = "aba";
            var actual = ValidPalindrome(s);
            
            Assert.True(actual);
        }

        [Test]
        public void Test2()
        {
            var s = "abca";
            var actual = ValidPalindrome(s);
            
            Assert.True(actual);
        }

        [Test]
        public void Test3()
        {
            var s = "abc";
            var actual = ValidPalindrome(s);
            
            Assert.False(actual);
        }

        [Test]
        public void Test4()
        {
            var s = "abcba";
            var actual = ValidPalindrome(s);
            
            Assert.True(actual);
        }

        [Test]
        public void Test5()
        {
            var s = "aabcba";
            var actual = ValidPalindrome(s);
            
            Assert.True(actual);
        }

        [Test]
        public void Test6()
        {
            var s = "abbca";
            var actual = ValidPalindrome(s);
            
            Assert.True(actual);
        }

        [Test]
        public void Test7()
        {
            var s = "abbb";
            var actual = ValidPalindrome(s);
            
            Assert.True(actual);
        }

        [Test]
        public void Test8()
        {
            var s = "abbbb";
            var actual = ValidPalindrome(s);
            
            Assert.True(actual);
        }

        [Test]
        public void Test9()
        {
            var s = "ebcbbececabbacecbbcbe";
            var actual = ValidPalindrome(s);
            
            Assert.True(actual);
        }

        public bool ValidPalindrome(string s)
        {
            if (s.Length < 2) return true;
             

            var r = s.Length - 1;
            var l = 0;
            while (l < r) 
            {
                if (s[l] == s[r])
                {
                    l++;
                    r--;
                    continue;
                }

                return Search(s, l + 1, r) || Search(s, l, r - 1);
            }

            return true;
        }

        private bool Search(string s, int l, int r)
        {
            while (l < r)
            {
                if (s[l] != s[r]) return false;
                l++;
                r--; 
            }

            return true;
        }
    }
}