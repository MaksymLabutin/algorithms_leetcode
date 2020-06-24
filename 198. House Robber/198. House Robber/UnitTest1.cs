using System;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    { 

        [Test]
        public void Test1()
        {
            var nums = new int[] {1, 2, 3, 1};
            var actual = Rob(nums);
            var excpected = 4;
            Assert.AreEqual(excpected, actual);
        }

        [Test]
        public void Test2()
        {
            var nums = new int[] { 2, 7, 9, 3, 1 };
            var actual = Rob(nums);
            var excpected = 12;
            Assert.AreEqual(excpected, actual);
        }

        [Test]
        public void Test3()
        {
            var nums = new int[] { 1, 2, 3, 1, 1, 1, 1, 2, 3, 2, 3, 3, 3, 3, 2, 12, 132, 123 };
            var actual = Rob(nums);
            var excpected = 150;
            Assert.AreEqual(excpected, actual);
        }


        [Test]
        public void Test4()
        {
            var nums = new int[] {2, 1, 1, 2 };
            var actual = Rob(nums);
            var excpected = 4;
            Assert.AreEqual(excpected, actual);
        }

        public int Rob(int[] nums)
        {
            if (nums.Length < 2) return nums.Length == 0 ? 0 : nums[0]; 
             

            for (var i = 2; i < nums.Length; i++)
            {
                if(i > 2) nums[i] += Math.Max(nums[i - 2], nums[i - 3]);
                else nums[i] += nums[i - 2];
            }

            return Math.Max(nums[nums.Length - 1], nums[nums.Length - 2]);
        }
    }
}