using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CountOfSmallerNumbersAfterSelf
{
    public class Tests
    { 
        [Test]
        public void CountSmaller_1()
        {
            var arr = new[] {5, 2, 6, 1};

            var res = CountSmaller(arr);

            var expectedArr = new[] {2, 1, 1, 0};

            CollectionAssert.AreEqual(expectedArr, res);
        }


        [Test]
        public void CountSmaller_2()
        {
            var arr = new[] { 5,5 };

            var res = CountSmaller(arr);

            var expectedArr = new[] { 0,0 };

            CollectionAssert.AreEqual(expectedArr, res);
        }


        [Test]
        public void CountSmaller_3()
        {
            var arr = new[] { 1,2,3,4,5 };

            var res = CountSmaller(arr);

            var expectedArr = new[] { 0, 0,0,0,0 };

            CollectionAssert.AreEqual(expectedArr, res);
        }



        [Test]
        public void CountSmaller_4()
        {
            var arr = new[] { 5,4,3,2,1 };

            var res = CountSmaller(arr);

            var expectedArr = new[] { 4,3,2,1,0 };

            CollectionAssert.AreEqual(expectedArr, res);
        }

        private static int _counter;

        public IList<int> CountSmaller(int[] nums)
        {
            _counter = 0;
            if (nums == null
                || nums.Length == 0)
            {
                return new List<int>();
            }

            int[] result = new int[nums.Length];

            MergeSort(nums, 0, nums.Length - 1, result);

            Console.WriteLine("Arr count: " + nums.Length + " counter = " + _counter);

            return result.ToList();
        }


        private static void MergeSort(int[] nums, int start, int end, int[] result)
        {
            if (start >= end)
            {
                return;
            }

            int mid = (start + end) / 2;

            MergeSort(nums, start, mid, result);
            MergeSort(nums, mid + 1, end, result);

            for (int i = start; i <= mid; i++)
            {
                int rightIndex = mid + 1;
                int count = 0;
                while (rightIndex <= end)
                {
                    if (nums[i] > nums[rightIndex])
                    {
                        count++;
                    }
                    rightIndex++;
                    _counter++;
                }

                result[i] += count;
            }
        }

    }
}