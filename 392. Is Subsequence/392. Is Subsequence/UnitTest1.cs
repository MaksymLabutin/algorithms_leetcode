using NUnit.Framework;

namespace Tests
{
    public class Tests
    { 
        [Test]
        public void Test1()
        {
            var s = "abc";
            var t = "ahbgdc";

            var actual = IsSubsequence(s, t); 
            Assert.True(actual);
        }

        [Test]
        public void Test2()
        { 
            var s = "axc";
            var t = "ahbgdc";

            var actual = IsSubsequence(s, t); 
            Assert.False(actual);
        }

        [Test]
        public void Test3()
        { 
            var s = "";
            var t = "ahbgdc";

            var actual = IsSubsequence(s, t); 
            Assert.True(actual);
        }

        [Test]
        public void Test4()
        { 
            var s = "1";
            var t = "";

            var actual = IsSubsequence(s, t); 
            Assert.False(actual);
        }

        public bool IsSubsequence(string s, string t)
        {
            if (s.Length > t.Length) return false;
            if (s.Length == 0) return true;

            var sPointer = 0;
            foreach (var symbol in t)
            {
                if (s[sPointer] == symbol)
                {
                    sPointer++;
                    if (sPointer >= s.Length) return true;
                }
            }

            return sPointer == s.Length;
        }
    }
}