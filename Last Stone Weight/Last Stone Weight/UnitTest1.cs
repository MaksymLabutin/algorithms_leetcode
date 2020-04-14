using System;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        
        [Test]
        public void LastStoneWeight_Test1()
        {
            var arr = new int[] { 2, 7, 4, 1, 8, 1 };

            var res = LastStoneWeight(arr);

            var expectedRes = 1;

            Assert.AreEqual(expectedRes, res);
        }

        [Test]
        public void LastStoneWeight_Test2()
        {
            var arr = new int[] { 2 };

            var res = LastStoneWeight(arr);

            var expectedRes = 2;

            Assert.AreEqual(expectedRes, res);
        }


        [Test]
        public void LastStoneWeight_Test3()
        {
            var arr = new int[] { 2, 2 };

            var res = LastStoneWeight(arr);

            var expectedRes = 0;

            Assert.AreEqual(expectedRes, res);
        }

        [Test]
        public void LastStoneWeight_Test4()
        {
            var arr = new int[] { 2, 2, 1, 3, 4, 5, 6, 11, 888, 123, 4 };

            var res = LastStoneWeight(arr);

            var expectedRes = 727;

            Assert.AreEqual(expectedRes, res);
        }


        [Test]
        public void MS_Test1()
        {
            var arr = new int[] { 1, 5, 3, 1, 2 };

            MergeSort(arr, 0, arr.Length - 1);

            CollectionAssert.AreEqual(new int[] { 1, 1, 2, 3, 5 }, arr);
        }

        [Test]
        public void MS_Test2()
        {
            var arr = new int[] { 5, 1, 3, 1, 2 };

            MergeSort(arr, 0, arr.Length - 1);

            CollectionAssert.AreEqual(new int[] { 1, 1, 2, 3, 5 }, arr);
        }

        public int LastStoneWeight(int[] stones)
        {
            MergeSort(stones, 0, stones.Length - 1);

            var pointer = stones.Length - 1;

            int y, x;

            while (pointer > 0)
            {
                y = stones[pointer];
                x = stones[pointer - 1];

                var diff = y - x;
                if (diff > 0)
                {
                    stones[pointer] = 0;
                    Swap(stones, diff, pointer--);
                }
                else
                {
                    stones[pointer] = 0;
                    stones[pointer - 1] = 0;
                    pointer = pointer - 2;
           
                }
            }


            return stones[0];
        }

        private void Swap(int[] arr, int val, int pointer)
        {
            for (var i = 0; i < pointer - 1; i++)
            {
                if (arr[i] <= val) continue;

                var tmp = val;
                val = arr[i];
                arr[i] = tmp;
            }

            arr[pointer - 1] = val;
        }

        private void MergeSort(int[] arr, int l, int r)
        {
            if (r - l < 1) return;

            var mid = (r + l) / 2;

            MergeSort(arr, 0, mid);
            MergeSort(arr, mid + 1, r);

            Merge(arr, l, mid, r);
        }

        private void Merge(int[] arr, int l, int m, int r)
        {
            var arrL = new int[m - l + 1];
            var arrR = new int[r - m];

            for (var i = 0; i < arrL.Length; i++)
            {
                arrL[i] = arr[l + i];
            }

            for (var i = 0; i < arrR.Length; i++)
            {
                arrR[i] = arr[m + 1 + i];
            }

            var lP = 0;
            var rP = 0;

            while (l <= r)
            {
                if (rP >= arrR.Length || lP < arrL.Length && arrL[lP] < arrR[rP])
                {
                    arr[l++] = arrL[lP++];
                }
                else
                {
                    arr[l++] = arrR[rP++];
                }
            }
        }
    }
}