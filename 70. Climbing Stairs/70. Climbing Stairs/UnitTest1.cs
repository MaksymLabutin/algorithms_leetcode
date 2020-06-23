using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        [Test]
        public void Test1()
        {
            var n = 2;

            var actual = ClimbStairs(n);

            var expected = 2;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test2()
        {
            var n = 3;

            var actual = ClimbStairs(n);

            var expected = 3;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test3()
        {
            var n = 20;

            var actual = ClimbStairs(n);

            var expected = 10946;

            Assert.AreEqual(expected, actual);
        }

        public int ClimbStairs(int n)
        {
            if (n < 4) return n;
            var dp = new int[n];
            dp[0] = 1;
            dp[1] = 2;
            dp[2] = 3;

            for (var i = 3; i < n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }

            return dp[n - 1];
        }
    }
}