using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    { 
        [Test]
        public void Test1()
        {
            var triangle = new List<IList<int>>()
            {
                new List<int>() {2},
                new List<int>() {3, 4},
                new List<int>() {6, 5, 7},
                new List<int>() {4, 1, 8, 3}
            };

            var actual = MinimumTotal(triangle);

            var expected = 11;

            Assert.AreEqual(expected, actual);
        }

        public int MinimumTotal(IList<IList<int>> triangle)
        {
            if (triangle.Count < 2) return triangle.Count == 0 ? 0 : triangle[0][0];

            var dp = new int[triangle.Count][];
            dp[triangle.Count - 1] = new int[triangle.Last().Count];
            for (int i = 0; i < triangle.Last().Count; i++)
            {
                dp[triangle.Count - 1][i] = triangle.Last()[i];
            }

            for (var i = triangle.Count - 2; i >= 0; i--)
            {
                dp[i] = new int[triangle[i].Count];
                for (var j = 0; j < triangle[i].Count; j++)
                {
                    dp[i][j] = Math.Min(dp[i + 1][j], dp[i + 1][j + 1]) + triangle[i][j];
                }
            }

            return dp[0][0];
        }
    }
}