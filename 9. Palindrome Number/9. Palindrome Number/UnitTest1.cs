using NUnit.Framework;

namespace Tests
{
    public class Tests
    { 
        [Test]
        public void Test1()
        {
            var x = 121;
            var actual = IsPalindrome(x);

            Assert.IsTrue(actual);
        }

        [Test]
        public void Test2()
        {
            var x = -121;
            var actual = IsPalindrome(x);

            Assert.IsFalse(actual);
        }

        [Test]
        public void Test3()
        {
            var x = 10;
            var actual = IsPalindrome(x);

            Assert.IsFalse(actual);
        }

        public bool IsPalindrome(int x)
        {
            if (x < 0) return false;
            var s = x.ToString();
            var rPointer = s.Length - 1;
            for (int i = 0; i < s.Length / 2; i++)
            {
                if (s[i] != s[rPointer--]) return false;
            }

            return true;
        }
    }
}