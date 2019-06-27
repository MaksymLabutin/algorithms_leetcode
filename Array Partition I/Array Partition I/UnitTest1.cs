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
            var arr = new int[] {1, 4, 3, 2};

            var res = ArrayPairSum(arr);
            
            Assert.AreEqual(res, 4);
        }

        [Test]
        public void Test2()
        {
            var arr = new int[] { 10000, -10000};

            var res = ArrayPairSum(arr);
            
            Assert.AreEqual(res, 0);
        }

        [Test]
        public void Test3()
        {
            var arr = new int[] { 10000, 10000 , 10000 , 10000 };

            var res = ArrayPairSum(arr);
            
            Assert.AreEqual(res, 20000);
        }

        [Test]
        public void Test4()
        {
            var arr = new int[] { 10000 };

            var res = ArrayPairSum(arr);
            
            Assert.AreEqual(res, 20000);
        }

        [Test]
        public void Test5()
        {
            var arr = new int[] { 7,3,1,0,0,6 };

            var res = ArrayPairSum(arr);
            
            Assert.AreEqual(res, 7);
        }

        public int ArrayPairSum(int[] nums)
        {
            var length = nums.Length;
            var sortedArray = Mergesort(nums.Take(length / 2).ToArray(), nums.Skip(length / 2).ToArray());
           
            var count = 0;
            for (var i = 0; i < length - 1; i += 2)
            {
                count += sortedArray[i];
            }
            return count;
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