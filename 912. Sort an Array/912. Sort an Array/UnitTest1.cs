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
            var  nums = new int[]{ 5, 2, 3, 1};

            var actual = SortArray(nums);

            CollectionAssert.AreEqual(new int[]{1,2,3,5}, actual);
        }

        [Test]
        public void Test2()
        {
            var  nums = new int[]{ 5, 1, 1, 2, 0, 0};

            var actual = SortArray(nums);

            CollectionAssert.AreEqual(new int[]{0,0,1,1,2,5}, actual);
        }

        public int[] SortArray(int[] nums)
        { 
            if (nums.Length < 2) return nums;

            var mid = nums.Length / 2; 
            var lArr = SortArray(Copy(nums, 0, mid));
            var rArr = SortArray(Copy(nums, mid, nums.Length));

            return Merge(lArr, rArr);
        } 

        private int[] Merge(int[] lArr, int[] rArr)
        {
            var l = lArr.Length + rArr.Length;
            var res = new int[l];

            var lPointer = 0;
            var rPointer = 0;

            for (var i = 0; i < l; i++)
            {
                if (rPointer >= rArr.Length || lPointer < lArr.Length && lArr[lPointer] < rArr[rPointer])
                {
                    res[i] = lArr[lPointer++];
                }
                else
                {
                    res[i] = rArr[rPointer++];
                }
            }

            return res;
        }

        private int[] Copy(int[] origin, int from, int to)
        {
            var res = new int[to - from];
            var i = 0;
            while (from != to)
            {
                res[i++] = origin[from++];
            }

            return res;
        }
    }
}