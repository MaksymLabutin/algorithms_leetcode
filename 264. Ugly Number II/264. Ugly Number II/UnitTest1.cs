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
            var n = 1690;
            var actual = NthUglyNumber(n);
            var expected = 2123366400;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test2()
        {
            var n = 1;
            var actual = NthUglyNumber(n);
            var expected = 1;
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void Test3()
        {
            var n = 2;
            var actual = NthUglyNumber(n);
            var expected = 2;
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void Test4()
        {
            var n = 3;
            var actual = NthUglyNumber(n);
            var expected = 3;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test5()
        {
            var n = 4;
            var actual = NthUglyNumber(n);
            var expected = 4;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test6()
        {
            var n = 5;
            var actual = NthUglyNumber(n);
            var expected = 5;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test7()
        {
            var n = 6;
            var actual = NthUglyNumber(n);
            var expected = 6;
            Assert.AreEqual(expected, actual);
        }

        public int NthUglyNumber(int n)
        {
            int[] dp = new int[n];
            int index2 = 0;
            int index3 = 0;
            int index5 = 0;
            dp[0] = 1;
            for (int i = 1; i < dp.Length; i++)
            {
                dp[i] = Math.Min(Math.Min(dp[index2] * 2, dp[index3] * 3), dp[index5] * 5);
                if (dp[i] == dp[index2] * 2)
                    index2++;
                if (dp[i] == dp[index3] * 3)
                    index3++;
                if (dp[i] == dp[index5] * 5)
                    index5++;

            }
            return dp[n - 1];
        }
    }
}