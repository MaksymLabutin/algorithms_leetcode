using System;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {  
        [Test]
        public void Test1()
        {
            var cost = new int[] {10, 15, 20};

            var actual = MinCostClimbingStairs(cost);

            var expected = 15;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test2()
        {
            var cost = new int[] {10, 15};

            var actual = MinCostClimbingStairs(cost);

            var expected = 10;

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Test3()
        {
            var cost = new int[] { 1, 100, 1, 1, 1, 100, 1, 1, 100, 1 };

            var actual = MinCostClimbingStairs(cost);

            var expected = 6;

            Assert.AreEqual(expected, actual);
        }

        public int MinCostClimbingStairs(int[] cost)
        {
            if (cost.Length == 2) return Math.Min(cost[0], cost[1]);
            for (var i = 2; i < cost.Length; i++)
            {
                cost[i] += Math.Min(cost[i - 1], cost[i - 2]);
            }

            return Math.Min(cost[cost.Length - 1], cost[cost.Length - 2]);
        }
    }
}