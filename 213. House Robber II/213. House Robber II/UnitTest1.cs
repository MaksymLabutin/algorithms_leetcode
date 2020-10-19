using System;
using System.Collections.Generic;
using Xunit;

namespace _213._House_Robber_II
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var nums = new int[] {2, 3, 2};

            var actual = Rob(nums);

            var expected = 3;

            Assert.Equal(expected, actual);
        }


        [Fact]
        public void Test2()
        {
            var nums = new int[] { 1, 2, 3, 1 };

            var actual = Rob(nums);

            var expected = 4;

            Assert.Equal(expected, actual);
        }


        [Fact]
        public void Test3()
        {
            var nums = new int[] { 0 };

            var actual = Rob(nums);

            var expected = 0;

            Assert.Equal(expected, actual);
        }


        [Fact]
        public void Test4()
        {
            var nums = new int[] { 2, 1, 1, 2 };

            var actual = Rob(nums);

            var expected = 3;

            Assert.Equal(expected, actual);
        }


        [Fact]
        public void Test5()
        {
            var nums = new int[] {6, 6, 4, 8, 4, 3, 3, 10};

            var actual = Rob(nums);

            var expected = 27;

            Assert.Equal(expected, actual);
        }



        [Fact]
        public void Test6()
        {
            var nums = new int[] { 1, 2, 3, 4, 5, 1, 2, 3, 4, 5 };

            var actual = Rob(nums);

            var expected = 16;

            Assert.Equal(expected, actual);
        }


        public int Rob(int[] nums)
        {
            if (nums.Length < 3) return nums.Length == 0 ? 0 : nums.Length == 1 ?  nums[0] : Math.Max(nums[0], nums[1]);

            var max1 = Rob(nums, 0, nums.Length- 1);
            var max2 = Rob(nums, 1, nums.Length);

            return Math.Max(max1, max2);
        }

        public int Rob(int[] nums, int start, int end)
        {
            var t1 = 0;
            var t2 = 0;

            for (var i = start; i < end; i++)
            {
                var tmp = t1;
                t1 = Math.Max(nums[i] + t2, t1);
                t2 = tmp;
            }

            return t1;
        }
    }
}
