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
            int[] nums = new int[] { 1, 2, 3, 3, 3 };
            Solution solution = new Solution(nums);

            // pick(3) should return either index 2, 3, or 4 randomly. Each index should have equal probability of returning.
            var four = solution.Pick(3);

            // pick(1) should return 0. Since in the array only nums[0] is equal to 1.
            var one = solution.Pick(1);

            Assert.AreEqual(one, 0);
        }

        public class Solution
        {
            private readonly Dictionary<int, List<int>> _memo;
            private readonly Random _r;
            public Solution(int[] nums)
            {
                _memo = new Dictionary<int, List<int>>();
                _r = new Random();
                for (int i = 0; i < nums.Length; i++)
                {
                    if (_memo.ContainsKey(nums[i])) _memo[nums[i]].Add(i);
                    else _memo.Add(nums[i], new List<int>() { i });
                }
            }

            public int Pick(int target)
            {

                var list = _memo[target];
                return list[_r.Next(list.Count)];
            }
        }
    }
}