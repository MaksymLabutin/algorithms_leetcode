using System;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        [Test]
        public void Test1()
        {
            var nums = new int[] { 1, 0, 1, 1, 0 };

            var actual = FindMaxConsecutiveOnes(nums);

            var expected = 4;

            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void Test2()
        {
            var nums = new int[] { 1, 0, 1, 1, 0, 1 };

            var actual = FindMaxConsecutiveOnes(nums);

            var expected = 4;

            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void Test3()
        {
            var nums = new int[] { 1, 1, 0, 1 };

            var actual = FindMaxConsecutiveOnes(nums);

            var expected = 4;

            Assert.AreEqual(expected, actual);
        }



        public int FindMaxConsecutiveOnes(int[] nums)
        {
            if (nums.Length == 0) return 0;

            var max = 1;
            var currMax = 0;
            var prevMax = 0;

            foreach (var num in nums)
            {
                if (num == 0)
                {
                    max = Math.Max(max, prevMax);
                    prevMax = currMax;
                    currMax = 0; 
                }
                else
                {
                    currMax++;
                }
                prevMax++;

            }

            max = Math.Max(prevMax, max);
            max = Math.Max(currMax, max);

            return max;
        }
    }
}