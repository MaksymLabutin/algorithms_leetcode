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

        public int NumSquares(int n)
        {
            if (n == 0) return 0;
            var squares = new List<Int64> { 1, 1 };

            for (var i = 2; i < n; i++)
            {
                Int64 val = i * i;

                if (val > n) break;

                squares.Add(val);
            }

            if (squares[squares.Count - 1] == n) return 1;

            var dp = new int[squares[squares.Count - 1]];


            return 1;
        }

        //public int NumSquares(int n)
        //{
        //    if (n == 0) return 0;
        //    var dp = new List<Int64> { 1, 1 };

        //    for (var i = 2; i < n; i++)
        //    {
        //        Int64 val = i * i;

        //        if (val > n) break;

        //        dp.Add(val);
        //    }

        //    if (dp[dp.Count - 1] == n) return 1;

        //    var answer = int.MaxValue;

        //    for (var j = dp.Count - 1; j >= 0; j--)
        //    {
        //        var currSum = dp[j];
        //        var currAttemps = 1;
        //        var i = j;
        //        while (currSum != n)
        //        {
        //            if (currAttemps > answer) break;
        //            if (i < 0) i = 0;
        //            currSum += dp[i];
        //            if (currSum > n)
        //            {
        //                currSum -= dp[i];
        //                i--;
        //            }
        //            else
        //            {
        //                currAttemps++;
        //            }
        //        }

        //        answer = Math.Min(answer, currAttemps);
        //    }

        //    return answer;
        //}
    }
}