using NUnit.Framework;

namespace Tests
{
    public class Tests
    { 

        [Test]
        public void Test1()
        {
            var input = new char[] {'h', 'e', 'l', 'l', 'o'};

            ReverseString(input);

            var expected = new char[] { 'o', 'l', 'l', 'e', 'h' };

            CollectionAssert.AreEqual(expected, input);
        }

        [Test]
        public void Test2()
        {
            var input = new char[] { 'H', 'a', 'n', 'n', 'a', 'h' };

            ReverseString(input);

            var expected = new char[] { 'h', 'a', 'n', 'n', 'a', 'H' };

            CollectionAssert.AreEqual(expected, input);
        }

        public void ReverseString(char[] s)
        {

            for (var i = 0; i < s.Length / 2; i++)
            {
                var tmp = s[i];
                s[i] = s[s.Length - 1 - i];
                s[s.Length - 1 - i] = tmp;
            }

        }
    }
}