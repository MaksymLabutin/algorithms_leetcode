using System;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    { 
        [Test]
        public void Test1()
        {
            var nums = new int[] {1, 2, 4, 3, 1, 2, 3, 4, 5};
            var actual = FindLengthOfLCIS(nums);
            var expected = 5;

            Assert.AreEqual(expected,actual);
        }

        public int FindLengthOfLCIS(int[] nums)
        {
            if (nums.Length == 0) return 0;

            var maxL = 1;
            var currL = 1;
            for (var i = 1; i < nums.Length; i++)
            {
                if (nums[i] > nums[i - 1])
                { 
                    currL++;
                }
                else
                {
                    currL = 1;
                }

                maxL = Math.Max(maxL, currL);
            }

            return maxL;
        }
    }
}