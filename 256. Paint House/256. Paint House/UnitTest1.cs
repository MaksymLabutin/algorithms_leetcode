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
            var costs = new int[][]
            {
                new []{ 17, 2, 17 },
                new []{ 16, 16, 5 },
                new []{ 14, 3, 19 }
            };

            var actual = MinCost(costs);

            var expected = 10;

            Assert.AreEqual(expected, actual);
        }

        public int MinCost(int[][] costs)
        {
            if (costs.Length == 0 || costs[0].Length == 0) return 0;

            var dp = new int[costs.Length, costs[0].Length];

            dp[0, 0] = costs[0][0];
            dp[0, 1] = costs[0][1];
            dp[0, 2] = costs[0][2];

            for (var i = 1; i < costs.Length; i++)
            {
                dp[i,0] = Math.Min(dp[i - 1, 1], dp[i - 1, 2]) + costs[i][0];
                dp[i,1] = Math.Min(dp[i - 1, 0], dp[i - 1, 2]) + costs[i][1];
                dp[i,2] = Math.Min(dp[i - 1, 0], dp[i - 1, 1]) + costs[i][2];
            }

            return Math.Min(dp[costs.Length - 1, 0], Math.Min(dp[costs.Length- 1, 1], dp[costs.Length - 1, 2]));
        }


        //private Dictionary<(int, int), int> _memo;
        //public int MinCost(int[][] costs)
        //{
        //    _memo = new Dictionary<(int, int), int>();
        //    return MinCost(costs, 0, -1);
        //}

        //private int MinCost(int[][] costs, int row, int col)
        //{
        //    if (row >= costs.Length) return 0;

        //    var min = int.MaxValue;

        //    for (var i = 0; i < costs[row].Length; i++)
        //    {
        //        if(i == col) continue;

        //        var cost = 0;
        //        if (_memo.ContainsKey((row, i)))
        //        {
        //            cost = _memo[(row, i)];
        //        }
        //        else
        //        {
        //            cost = MinCost(costs, row + 1, i) + costs[row][i];
        //            _memo.Add((row, i), cost);
        //        }

        //        min = Math.Min(min, cost);
        //    }

        //    return min;

        //}
    }
}