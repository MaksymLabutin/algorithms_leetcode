using System;
using System.Linq;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    { 

        [Test]
        public void Test1()
        {
            var nums = new int[] {1, 2, 3};

            var actual = MaximumProduct(nums);

            var expected = 6;
            Assert.AreEqual(expected, actual);
        }

        public int MaximumProduct(int[] nums)
        {
            if (nums.Length == 0) return 0;

            nums = nums.ToArray().OrderBy(_ => _).ToArray();

            return Math.Max(nums[0] * nums[1] * nums[nums.Length - 1],
                nums[nums.Length - 1] * nums[nums.Length - 2] * nums[nums.Length - 3]);
        }
    }
}