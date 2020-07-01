using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    { 

        [Test]
        public void Test1()
        {
            //Given nums = [-2, 0, 3, -5, 2, -1]

            //sumRange(0, 2)-> 1
            //sumRange(2, 5)-> - 1
            //sumRange(0, 5)-> - 3

            var nums = new int[] {-2, 0, 3, -5, 2, -1};
            var numArr = new NumArray(nums);

            Assert.AreEqual(1, numArr.SumRange(0, 2));
            Assert.AreEqual(-1, numArr.SumRange(2, 5));
            Assert.AreEqual(-3, numArr.SumRange(0, 5));
             
        }

        public class NumArray
        {
            private int[] _nums; 
            public NumArray(int[] nums)
            {
                _nums = new int[nums.Length];
                nums.CopyTo(_nums, 0);
                for (var i = 1; i < _nums.Length; i++)
                {
                    _nums[i] += _nums[i - 1];
                }
            }

            public int SumRange(int i, int j)
            {
                if (i == 0) return _nums[j];
                
                return _nums[j] - _nums[i - 1];
            }
             
        }

    }
}