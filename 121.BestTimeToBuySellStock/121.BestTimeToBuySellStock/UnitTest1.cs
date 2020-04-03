using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    { 

        //[Test]
        //public void MergeSort_Test_1()
        //{
        //    var arr = new[] {1, 4, 3, 2, 5, 6, 7, -1, -2};

        //    var res = MergeSort(arr, 0, arr.Length - 1);

        //    var expectedRes = new[] {-2, -1, 1, 2, 3, 4, 5, 6, 7};

        //    CollectionAssert.AreEqual(expectedRes, res);
        //}


        //[Test]
        //public void MergeSort_Test_2()
        //{
        //    var arr = new[] { 5,4,3,2,1 };

        //    var res = MergeSort(arr, 0, arr.Length - 1);

        //    var expectedRes = new[] {1,2,3,4,5 };

        //    CollectionAssert.AreEqual(expectedRes, res);
        //}


        [Test]
        public void MaxProfit_Test_1()
        {
            var arr = new[] { 7, 1, 5, 3, 6, 4 };

            var res = MaxProfit(arr);

            var expectedRes = 5;

            Assert.AreEqual(expectedRes, res);
        }



        [Test]
        public void MaxProfit_Test_2()
        {
            var arr = new[] { 7, 6, 4, 3, 1 };

            var res = MaxProfit(arr);

            var expectedRes = 0;

            Assert.AreEqual(expectedRes, res);
        }

        [Test]
        public void MaxProfit_Test_3()
        {
            var arr = new[] { 2, 1, 2, 0, 1 };

            var res = MaxProfit(arr);

            var expectedRes = 1;

            Assert.AreEqual(expectedRes, res);
        }

        public int MaxProfit(int[] prices)
        {
            var minPrice = int.MaxValue;
            var maxProfit = 0;

            foreach (var price in prices)
            {
                if (price < minPrice) minPrice = price;
                else if (price - minPrice > maxProfit) maxProfit = price - minPrice;
            }

            return maxProfit;
        }

        //public int MaxProfit(int[] prices)
        //{

        //    var dic = new Dictionary<int, List<int>>();

        //    for (var i = 0; i < prices.Length; i++)
        //    {
        //        if (dic.ContainsKey(prices[i]))
        //        {
        //            dic[prices[i]].Add(i);
        //        }
        //        else
        //        {
        //            dic.Add(prices[i], new List<int>() { i });
        //        }
        //    }

        //    MergeSort(prices, 0, prices.Length - 1);

        //    var max = 0;

        //    for (var i = 0; i < prices.Length; i++)
        //    { 
        //        var end = prices.Length - 1;
        //        while (end > i)
        //        {
        //            if(prices[end] - prices[i] <= max) break;

        //            if (dic[prices[i]][0] < dic[prices[end]][dic[prices[end]].Count - 1]) max = prices[end] - prices[i];


        //            end--;
        //        }
        //    }


        //    return max;
        //}

        //private int[] MergeSort(int[] arr, int l, int r)
        //{
        //    if (l >= r) return arr;

        //    var mid = (l + r) / 2;

        //    MergeSort(arr, l, mid);
        //    MergeSort(arr, mid + 1, r);

        //    return Merge(arr, l, mid, r);
        //}

        //private int[] Merge(int[] arr, int l, int m, int r)
        //{
        //    var lLenght = m - l + 1;
        //    var rLenght = r - m;

        //    var lArr = new int[lLenght];
        //    var rArr = new int[rLenght];

        //    for (var i = 0; i < lLenght; i++)
        //    {
        //        lArr[i] = arr[l + i];
        //    }

        //    for (var j = 0; j < rLenght; j++)
        //    {
        //        rArr[j] = arr[m + j + 1]; 
        //    }

        //    var lPointer = 0;
        //    var rPointer = 0;

        //    while (l <= r)
        //    {
        //        if (rPointer >= rLenght || lPointer < lLenght && lArr[lPointer] < rArr[rPointer])
        //        {
        //            arr[l] = lArr[lPointer++];
        //        }
        //        else
        //        {
        //            arr[l] = rArr[rPointer++];
        //        }

        //        l++;
        //    }

        //    return arr;
        //}
    }
}