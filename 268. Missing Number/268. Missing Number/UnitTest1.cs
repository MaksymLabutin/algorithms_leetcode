using System;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        [Test]
        public void Test1()
        {
            //[3,0,1]
            var nums = new int[] { 3, 0, 1 };

            var actual = MissingNumber(nums);

            var expected = 2;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test2()
        {
            //[3,0,1]
            var nums = new int[] { 9, 6, 4, 2, 3, 5, 7, 0, 1 };

            var actual = MissingNumber(nums);

            var expected = 8;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test3()
        {
            var nums = new int[] { 3, 0, 1, 2 };

            var actual = MissingNumber(nums);

            var expected = 4;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test4()
        {
            var nums = new int[] { 1 };

            var actual = MissingNumber(nums);

            var expected = 0;

            Assert.AreEqual(expected, actual);
        }

        public int MissingNumber(int[] nums)
        {
            if (nums.Length == 0) return 0;

            Int64 currSum = 0;
            var max = nums[0];
            var hasNill = false;

            for (int i = 0; i < nums.Length; i++)
            {
                max = Math.Max(nums[i], max);
                currSum += nums[i];
                hasNill = hasNill || nums[i] == 0;
            }

            Int64 expectedSum = 0;

            for (int i = 0; i <= max; i++)
            {
                expectedSum += i;
            }

            var missingNumber = (int)(expectedSum - currSum);
            return missingNumber == 0 && hasNill ? max + 1 : missingNumber;
        }
    }
}