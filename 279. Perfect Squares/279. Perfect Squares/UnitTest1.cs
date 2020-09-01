using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            var n = 12;

            var actual = NumSquares(n);

            var expected = 3;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test2()
        {
            var n = 43;

            var actual = NumSquares(n);

            var expected = 3;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test3()
        {
            var n = 1;

            var actual = NumSquares(n);

            var expected = 1;

            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void Test4()
        {
            var n = 3;

            var actual = NumSquares(n);

            var expected = 3;

            Assert.AreEqual(expected, actual);
        }

        public int NumSquares(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;

            var dp = new int[n + 1];
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = int.MaxValue;
            }

            dp[0] = 0;

            var squers = new List<int>();
            for (var i = 1; i < n; i++)
            {
                Int64 val = i * i;

                if (val > n) break;

                squers.Add((int)val);
            } 

            for (var i = 1; i <= n; i++)
            {
                for (var s = 0; s < squers.Count; s++)
                {
                    if(i < squers[s]) break;
                    
                    dp[i] = Math.Min(dp[i], dp[i - squers[s]] + 1);
                }
            }

            return dp[n];
        }

       
    }
}