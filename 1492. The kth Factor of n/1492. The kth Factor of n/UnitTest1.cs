using NUnit.Framework;

namespace Tests
{
    public class Tests
    { 

        [Test]
        public void Test1()
        {
            var n = 7;
            var k = 2;

            var actual = KthFactor(n, k);

            var expected = 7;
            Assert.AreEqual(expected, actual);
        }

        public int KthFactor(int n, int k)
        { 
            for (var i = 1; i <= n; i++)
            {
                if (n % i != 0) continue;
                k--;
                if (k <= 0) return k == 0 ? i : -1;
            }

            return -1;
        }
    }
}