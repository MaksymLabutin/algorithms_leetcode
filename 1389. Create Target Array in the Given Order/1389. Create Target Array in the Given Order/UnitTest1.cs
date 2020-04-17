using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            var nums = new int[] { 0, 1, 2, 3, 4 };
            var index = new int[] { 0, 1, 2, 2, 1 };

            var res = CreateTargetArray(nums, index);

            var expected = new int[] { 0, 4, 1, 3, 2 };

            CollectionAssert.AreEqual(expected, res);
        }

        [Test]
        public void Test2()
        {
            var nums = new int[] { 1, 2, 3, 4, 0 };
            var index = new int[] { 0, 1, 2, 3, 0 };

            var res = CreateTargetArray(nums, index);

            var expected = new int[] { 0, 1, 2, 3, 4 };

            CollectionAssert.AreEqual(expected, res);
        }

        [Test]
        public void Test3()
        {
            var nums = new int[] { 1, 2, 3, 4, 5};
            var index = new int[] { 4,4,4,4,4 };

            var res = CreateTargetArray(nums, index);

            var expected = new int[] { 4,3,2,1, 5};

            CollectionAssert.AreEqual(expected, res);
        }


        public int[] CreateTargetArray(int[] nums, int[] index)
        {
            var initialArr = new int[nums.Length];

            for (int i = 0; i < initialArr.Length; i++)
            {
                initialArr[i] = -1;
            }

            for (var i = 0; i < nums.Length; i++)
            {
                if (initialArr[index[i]] != -1)
                {
                    Insert(initialArr, index[i], nums[i]);
                }
                else
                {
                    initialArr[index[i]] = nums[i];
                }

            }

            return initialArr;
        }

        private void Insert(int[] arr, int index, int val)
        {
            var tmp = arr[index];
            arr[index] = val;
            val = tmp;
            var i = index + 1 >= arr.Length ? 0 : index + 1;
            
            while (i != index)
            {
                tmp = arr[i];
                arr[i] = val;

                i = i + 1 >= arr.Length ? 0 : i + 1;
                val = tmp;
                if(val == -1) break;
                
            }
        }
    }
}