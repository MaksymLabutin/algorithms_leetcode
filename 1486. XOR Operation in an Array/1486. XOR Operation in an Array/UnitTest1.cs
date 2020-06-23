using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Tests
{
    public class Tests
    { 
        [Test]
        public void Test1()
        {
            var n = 5;
            var start = 0;

            var actual = XorOperation(n, start);

            var expected = 8;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test2()
        {
            var n = 4;
            var start = 3;

            var actual = XorOperation(n, start);

            var expected = 8;

            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void Test3()
        {
            var n = 1;
            var start = 7;

            var actual = XorOperation(n, start);

            var expected = 7;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test4()
        {
            var n = 10;
            var start = 5;

            var actual = XorOperation(n, start);

            var expected = 2;

            Assert.AreEqual(expected, actual);
        }

        public int XorOperation(int n, int start)
        {
            var dp = start;

            for (var i = 1; i < n; i++)
            {
                dp = (start + 2 * i) ^ dp;
            }

            return dp;
        }
    }
}