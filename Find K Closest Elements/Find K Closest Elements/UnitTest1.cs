using System;
using System.Runtime.InteropServices.ComTypes;
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
            var res = FindClosestElements(new int[] { 1, 2, 3, 4, 5 }, 4, 3);

            CollectionAssert.AreEqual(res, new int[] { 1, 2, 3, 4 });
        }

        [Test]
        public void Test2()
        {
            var res = FindClosestElements(new int[] { 1, 2, 3, 4, 5 }, 4, 1);

            CollectionAssert.AreEqual(res, new int[] { 1, 2, 3, 4 });
        }

        [Test]
        public void Test3()
        {
            var res = FindClosestElements(new int[] { 1, 2, 3, 4, 5 }, 4, 6);

            CollectionAssert.AreEqual(res, new int[] { 2, 3, 4, 5 });
        }

        [Test]
        public void Test4()
        {
            var res = FindClosestElements(new int[] { 0, 2, 3, 4, 5 }, 4, 1);

            CollectionAssert.AreEqual(res, new int[] { 0, 2, 3, 4 });
        }

        [Test]
        public void Test5()
        {
            var res = FindClosestElements(new int[] { 0, 2, 3, 4, 5 }, 10000, 1);

            CollectionAssert.AreEqual(res, new int[] { 0, 2, 3, 4, 5 });
        }

        [Test]
        public void Test6()
        {
            var res = FindClosestElements(new int[] { 0 }, 1, 3);

            CollectionAssert.AreEqual(res, new int[] { 0 });
        }

        [Test]
        public void Test7()
        {
            var res = FindClosestElements(new int[] { 0, 0, 1, 2, 3, 3, 4, 7, 7, 8 }, 3, 5);

            CollectionAssert.AreEqual(res, new int[] { 3, 3, 4 });
        }

        [Test]
        public void Test8()
        {
            var res = FindClosestElements(new int[] { 1, 2, 3, 4, 5 }, 4, -1);

            CollectionAssert.AreEqual(res, new int[] { 1, 2, 3, 4 });
        }

        [Test]
        public void Test9()
        {
            var res = FindClosestElements(new int[] { 0, 0, 0, 1, 3, 5, 6, 7, 8, 8 }, 2, 2);

            CollectionAssert.AreEqual(res, new int[] { 1, 3 });
        }

        public int[] FindClosestElements(int[] arr, int k, int x)
        {
            if (arr.Length < 1) return new int[] { };

            if (k >= arr.Length) return arr;

            int left = 0, right = arr.Length - 1;

            while (left <= right)
            {
                var mid = left + (right - left) / 2;

                if (arr[mid] == x)
                {
                    left = mid;
                    break;
                }

                if (arr[mid] > x)
                {
                    if (mid > 0 && arr[mid - 1] < x)
                    {
                        left = mid - 1;
                        break;
                    }
                    right = mid - 1;
                }
                else
                {
                    if (mid > 0 && arr[mid - 1] > x)
                    {
                        left = mid;
                        break;
                    }

                    left = mid + 1;
                }
            }

            var res = new int[k];

            left = left == arr.Length ? left - 1 : left;

            int leftPointer = left, rightPointer = left;

            while (rightPointer - leftPointer + 1 < k)
            {
                if (rightPointer >= arr.Length - 1 || leftPointer > 0 && Math.Abs(arr[leftPointer - 1] - x) <= Math.Abs(arr[rightPointer + 1] - x))
                {
                    leftPointer--;
                    if (arr[leftPointer] == x) rightPointer--;
                }
                else
                {
                    rightPointer++;
                }
            }

            var index = 0;
            while (leftPointer <= rightPointer)
            {
                res[index] = arr[leftPointer];
                index++;
                leftPointer++;
            }

            return res;
        }
    }
}