using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    { 

        [Test]
        public void Test1()
        {
            var nums = new int[] {0, 1};
            var actual = FindErrorNums(nums);
            var expected = new int[] {1, 1};
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void Test2()
        {
            var nums = new int[] {1, 1};
            var actual = FindErrorNums(nums);
            var expected = new int[] {1, 2};
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void Test3()
        {
            var nums = new int[] {1, 2, 2, 4};
            var actual = FindErrorNums(nums);
            var expected = new int[] { 2, 3 };
            CollectionAssert.AreEqual(expected, actual);
        }

        public int[] FindErrorNums(int[] nums)
        {
            var hs = new HashSet<int>();

            var duplicate = 0;

            var currSum = 0;
            var maxSum = nums.Length;

            for (var i = 0; i < nums.Length; i++)
            {
                maxSum += i;
                currSum += nums[i];

                if (hs.Contains(nums[i])) duplicate = nums[i];
                else hs.Add(nums[i]);
            }

            return new int[] {duplicate, maxSum - currSum + duplicate };
        }
    }
}