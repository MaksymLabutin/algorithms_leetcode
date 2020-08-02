using System;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            var nums = new int[] { 1, 2, 3, 4, 5 };
            var acutal = FindUnsortedSubarray(nums);
            var expected = 0;

            Assert.AreEqual(expected, acutal);
        }
        [Test]
        public void Test2()
        {
            var nums = new int[] { 2, 6, 4, 8, 10, 9, 15 };
            var acutal = FindUnsortedSubarray(nums);
            var expected = 5;

            Assert.AreEqual(expected, acutal);
        }

        [Test]
        public void Test3()
        {
            var nums = new int[] { 1, 2, 3, 4, 5, 1, 2, 3, 4, 5 };
            var acutal = FindUnsortedSubarray(nums);
            var expected = 8;

            Assert.AreEqual(expected, acutal);
        }

        [Test]
        public void Test4()
        {
            var nums = new int[] { 2, 3, 3, 2, 4 };
            var acutal = FindUnsortedSubarray(nums);
            var expected = 3;

            Assert.AreEqual(expected, acutal);
        }

        [Test]
        public void Test5()
        {
            var nums = new int[] {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 1, 1, 1, 1, 2, 1, 2, 1, 2, 1, 2, 3, 4, 5, 6, 7, 8 };
            var acutal = FindUnsortedSubarray(nums);
            var expected = 26;

            Assert.AreEqual(expected, acutal);
        }


        [Test]
        public void Test6()
        {
            var nums = new int[] {1, 3, 5, 4, 2 };
            var acutal = FindUnsortedSubarray(nums);
            var expected = 4;

            Assert.AreEqual(expected, acutal);
        }

        public int FindUnsortedSubarray(int[] nums)
        {
            var max = nums[0];
            var start = int.MaxValue;
            var end = -1;

            for (var i = 0; i < nums.Length; i++)
            {
                max = Math.Max(max, nums[i]);
                if (max == nums[i]) continue;

                var j = 0;
                while (nums[j] <= nums[i] || i == j)
                {
                    j++;
                }

                start = Math.Min(j, start);
                end = i + 1;
            }

            return start != int.MaxValue ? end - start : 0;
        }
    }
}