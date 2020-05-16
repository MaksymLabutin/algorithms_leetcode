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
            var nums = new int[] { 4, 2, 3 };
            var actual = CheckPossibility(nums); 

            Assert.True(actual);
        }

        [Test]
        public void Test2()
        {
            var nums = new int[] { 4, 2, 1 };
            var actual = CheckPossibility(nums); 

            Assert.False(actual);
        }

        [Test]
        public void Test3()
        {
            var nums = new int[] {3, 4, 2, 3};
            var actual = CheckPossibility(nums); 

            Assert.False(actual);
        }

        [Test]
        public void Test4()
        {
            var nums = new int[] {2, 3, 3, 2, 4};
            var actual = CheckPossibility(nums); 

            Assert.True(actual);
        }

        [Test]
        public void Test5()
        {
            var nums = new int[] {-1, 4, 2, 3};
            var actual = CheckPossibility(nums); 

            Assert.True(actual);
        }

        public bool CheckPossibility(int[] nums)
        { 
            var maxToModify = 1;

            for (var i = nums.Length - 1; i > 0; i--)
            {
                if (nums[i] >= nums[i - 1] && i + 1 < nums.Length && nums[i - 1] <= nums[i + 1]) continue;
                maxToModify--;
                nums[i] = i + 1 >= nums.Length ? int.MaxValue : nums[i + 1];
                
            }
             
            return maxToModify >= 0;
        }
    }
}