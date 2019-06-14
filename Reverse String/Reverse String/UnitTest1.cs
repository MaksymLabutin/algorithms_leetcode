using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var res = ReverseString(new []{'h', 'e', 'l', 'l', 'o'});

            CollectionAssert.AreEqual(res, new []{ 'o', 'l', 'l', 'e', 'h' });
        }

        [Test]
        public void Test2()
        {
            var res = ReverseString(new []{ 'H', 'a', 'n', 'n', 'a', 'h' });

            CollectionAssert.AreEqual(res, new []{ 'h', 'a', 'n', 'n', 'a', 'H' });
        }
        [Test]
        public void Test3()
        {
            var res = ReverseString(new []{ 'a'});

            CollectionAssert.AreEqual(res, new []{ 'a'});
        }

        public char[] ReverseString(char[] s)
        {
            if(s.Length < 2) return s;

            var firstIndex = 0;
            var lastIndex = s.Length - 1;

            while (firstIndex < lastIndex)
            { 
                var tmp = s[firstIndex];
                s[firstIndex] = s[lastIndex];
                s[lastIndex] = tmp;
                 
                firstIndex++;
                lastIndex--;
            }


            return s;
        }
 
    }
}