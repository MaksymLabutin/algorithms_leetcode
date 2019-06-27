using System;
using System.Linq;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var nums = new int[] { 4, 3, 2, 1, 5 };

            var res = Mergesort(nums.Take(nums.Length / 2).ToArray(), nums.Skip(nums.Length / 2).ToArray());

            Assert.That(res, Is.EqualTo(new int[5] { 1, 2, 3, 4, 5 }));
        }

        [Test]
        public void Test2()
        {
            var nums = new int[] { 10, 1, 5, 55, 123, 6666, 12343335, 1122 };

            var res = Mergesort(nums.Take(nums.Length / 2).ToArray(), nums.Skip(nums.Length / 2).ToArray());

            Assert.That(res, Is.EqualTo(new int[] { 1, 5, 10, 55, 123, 1122, 6666, 12343335 }));
        }

        public int[] Mergesort(int[] arr1, int[] arr2)
        {
            var arr2Length = arr2.Length;
            var arr1Length = arr1.Length;

            if (arr2Length > 1)
            {
                arr1 = Mergesort(arr1.Take(arr1Length / 2).ToArray(), arr1.Skip(arr1Length / 2).ToArray());
                arr2 = Mergesort(arr2.Take(arr2Length / 2).ToArray(), arr2.Skip(arr2Length / 2).ToArray());
            }

            var i1 = arr1Length + arr2Length;
            var arr = new int[i1];

            int i = 0, j = 0;

            for (; i1 > i + j;)
            {
                if (arr1Length > i && arr2Length > j)
                {
                    arr[i + j] = arr1[i] > arr2[j] ? arr2[j++] : arr1[i++];
                }
                else
                {
                    arr[i + j] = j >= arr2Length ? arr1[i++] : arr2[j++];
                }
            } 
            return arr;
        }
    }
}