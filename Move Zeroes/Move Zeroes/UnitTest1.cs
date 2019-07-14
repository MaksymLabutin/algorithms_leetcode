using System;
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
            var arr = new int[] { 0, 1, 0, 3, 12 };
            MoveZeroes(arr);
            CollectionAssert.AreEqual(arr, new int[] { 1, 3, 12, 0, 0 });
        }
        [Test]
        public void Test2()
        {
            var arr = new int[] { 0, 0, 0, 3, 12 };
            MoveZeroes(arr);
            CollectionAssert.AreEqual(arr, new int[] { 3, 12, 0, 0, 0 });
        }

        [Test]
        public void Test3()
        {
            var arr = new int[] { 1, 1, 0, 3, 12, 0 };
            MoveZeroes(arr);
            CollectionAssert.AreEqual(arr, new int[] { 1, 1, 3, 12, 0, 0 });
        }
        [Test]
        public void Test4()
        {
            var arr = new int[] {-1, 1, 0, -3, 12, 0 };
            MoveZeroes(arr);
            CollectionAssert.AreEqual(arr, new int[] { -1, 1, -3, 12, 0, 0 });
        }

        public void MoveZeroes(int[] nums)
        {
            int zeroPointer = -1, pointer = 0;
            while (pointer < nums.Length)
            {
                if (nums[pointer] == 0 && zeroPointer < 0)
                {
                    zeroPointer = pointer;
                }
                else if (zeroPointer >= 0)
                {
                    var tmp = nums[pointer];
                    nums[pointer] = nums[zeroPointer];
                    nums[zeroPointer] = tmp;

                    zeroPointer = tmp == 0 ? zeroPointer : zeroPointer + 1;
                }

                pointer++;
            }
        }
    }
}