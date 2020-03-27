using System.Collections.Generic;
using NUnit.Framework;

namespace HowManyNumbersAreSmallerThanCurrentNumber
{
    public class SmallerNumbersThanCurrentTests
    {
        [Test]
        public void Test1()
        {
            var arr = new int[] { 8, 1, 2, 2, 3 };

            var res = SmallerNumbersThanCurrent(arr);

            var expectedRes = new int[] { 4, 0, 1, 1, 3 };

            CollectionAssert.AreEqual(expectedRes, res);
        }

        [Test]
        public void Test2()
        {
            var arr = new int[] { 6, 5, 4, 8 };

            var res = SmallerNumbersThanCurrent(arr);

            var expectedRes = new int[] { 2, 1, 0, 3 };

            CollectionAssert.AreEqual(expectedRes, res);
        }


        [Test]
        public void Test3()
        {
            var arr = new int[] { 7, 7, 7, 7 };

            var res = SmallerNumbersThanCurrent(arr);

            var expectedRes = new int[] { 0, 0, 0, 0 };

            CollectionAssert.AreEqual(expectedRes, res);
        }


        [Test]
        public void Test4()
        {
            var arr = new int[] { 0, 0, 0, 0 };

            var res = SmallerNumbersThanCurrent(arr);

            var expectedRes = new int[] { 0, 0, 0, 0 };

            CollectionAssert.AreEqual(expectedRes, res);
        }


        public int[] SmallerNumbersThanCurrent(int[] nums)
        {
            var sortedArr = MergeSort(nums);

            var dic = new Dictionary<int, int>();

            for (var i = 0; i < sortedArr.Length; i++)
            {
                if (dic.ContainsKey(sortedArr[i])) continue;

                dic.Add(sortedArr[i], i);
            }

            for (var i = 0; i < sortedArr.Length; i++)
            {
                nums[i] = dic[nums[i]];
            }

            return nums;
        }

        private int[] MergeSort(int[] nums)
        {
            if (nums.Length <= 1) return nums;

            var leftArr = CreateAndFillArr(nums, 0, nums.Length / 2 - 1);
            var rightArr = CreateAndFillArr(nums, nums.Length / 2, nums.Length - 1);

            var left = MergeSort(leftArr);
            var right = MergeSort(rightArr);

            return Merge(left, right);
        }


        private int[] Merge(int[] left, int[] right)
        {
            var lenght = left.Length + right.Length;
            var res = new int[lenght];

            int leftP = 0, rightP = 0;

            for (var i = 0; i < lenght; i++)
            {
                if (rightP >= right.Length || leftP < left.Length && left[leftP] <= right[rightP])
                {
                    res[i] = left[leftP++];
                }
                else
                {
                    res[i] = right[rightP++];
                }
            }

            return res;
        }

        private int[] CreateAndFillArr(int[] nums, int start, int end)
        {
            var res = new int[end - start + 1];
            for (var i = 0; i < end - start + 1; i++)
            {
                res[i] = nums[start + i];
            }

            return res;
        }

    }
}