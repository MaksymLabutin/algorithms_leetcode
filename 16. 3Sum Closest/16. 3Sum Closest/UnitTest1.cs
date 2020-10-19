using System;
using Xunit;

namespace _16._3Sum_Closest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var nums = new int[] { -1, 2, 1, -4 };
            var target = 1;

            var actual = ThreeSumClosest(nums, target);

            var expected = 2;

            Assert.Equal(expected, actual);
        }

     
        [Fact]
        public void Test2()
        {

            var nums = new int[] { -1, 2, 1, -4, 5, 6, 7, -8, 9, 10 };
            var target = 22;

            var actual = ThreeSumClosest(nums, target);

            var expected = 22;

            Assert.Equal(expected, actual);
        }


        [Fact]
        public void Test3()
        {

            var nums = new int[] { 0, 0, 0 };
            var target = 1;

            var actual = ThreeSumClosest(nums, target);

            var expected = 0;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test4()
        {

            var nums = new int[] { 1, 1, -1, -1, 3 };
            var target = -1;

            var actual = ThreeSumClosest(nums, target);

            var expected = -1;

            Assert.Equal(expected, actual);
        }


        [Fact]
        public void Test5()
        { 
            var nums = new int[] { -3, -2, -5, 3, -4 };
            var target = -1;

            var actual = ThreeSumClosest(nums, target);

            var expected = -2;

            Assert.Equal(expected, actual);
        }


        public int ThreeSumClosest(int[] nums, int target)
        {
            var res = int.MaxValue / 2;

            for (var i = 0; i < nums.Length - 2; i++)
            {
                for (var j = i + 1; j < nums.Length - 1; j++)
                {
                    for (var pointer = j + 1; pointer < nums.Length; pointer++)
                    {
                        var sum = nums[i] + nums[j] + nums[pointer];
                        res = Math.Abs(sum - target) < Math.Abs(res - target) ? 
                            sum : res;
                    }
                }
            }

            return res;
        }
    }
}
