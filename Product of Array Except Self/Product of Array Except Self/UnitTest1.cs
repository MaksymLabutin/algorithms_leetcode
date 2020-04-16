using System;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        [Test]
        public void Test1()
        {
            var arr = new int[] {1, 2, 3, 4};

            var res = ProductExceptSelf(arr);

            var expected = new int[] {24, 12, 8, 6};

            CollectionAssert.AreEqual(expected, res);
        }


        [Test]
        public void Test2()
        {
            var arr = new int[] {0,0};

            var res = ProductExceptSelf(arr);

            var expected = new int[] {0,0};

            CollectionAssert.AreEqual(expected, res);
        }

        [Test]
        public void Test3()
        {
            var arr = new int[] {1,0};

            var res = ProductExceptSelf(arr);

            var expected = new int[] {0, 1};

            CollectionAssert.AreEqual(expected, res);
        }

        public int[] ProductExceptSelf(int[] nums)
        {

            Int32 product = 1;
            var zeroCount = 0;
            var zeroPosition = 0;
            for (var i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    zeroCount++;
                    zeroPosition = i;
                    if (zeroCount >= 2) return new int[nums.Length];
                    continue;
                }
                product *= nums[i];
               
            }

            if (zeroCount > 0)
            {
                nums = new int[nums.Length];
                nums[zeroPosition] = product;
                return nums;
            }

            for (var i = 0; i < nums.Length; i++)
            {
                nums[i] = product / nums[i];
            }

            return nums;
        }
    }
}