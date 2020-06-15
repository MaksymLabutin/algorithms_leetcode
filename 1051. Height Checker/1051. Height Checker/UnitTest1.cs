using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        [Test]
        public void Test1()
        {
            var heights = new int[] { 1, 1, 4, 2, 1, 3 };
            var actual = HeightChecker(heights);
            var expected = 3;
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Test2()
        {
            var heights = new int[] { 5, 1, 2, 3, 4 };
            var actual = HeightChecker(heights);
            var expected = 5;
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Test3()
        {
            var heights = new int[] { 1, 2, 3, 4, 5 };
            var actual = HeightChecker(heights);
            var expected = 0;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test4()
        {
            var heights = new int[] { 1};
            var actual = HeightChecker(heights);
            var expected = 0;
            Assert.AreEqual(expected, actual);
        }

        //space O(N)
        //complexity N + NlogN == O(N)
        public int HeightChecker(int[] heights)
        {
            if (heights.Length < 2) return 0;

            var sortedArr = Sort(heights.ToList());

            var moves = 0;

            for (var i = 0; i < heights.Length; i++)
            {
                if (sortedArr[i] != heights[i]) moves++;
            }

            return moves;
        }

        private List<int> Sort(List<int> arr)
        {
            if (arr.Count < 2) return arr;

            var mid = arr.Count / 2;

            var leftArr = Sort(arr.Take(mid).ToList());
            var rightArr = Sort(arr.TakeLast(arr.Count - mid).ToList());

            return Marge(leftArr, rightArr);
        }

        private List<int> Marge(List<int> leftArr, List<int> rightArr)
        {
            var l = leftArr.Count + rightArr.Count;
            var res = new List<int>(l);

            var lPointer = 0;
            var rPointer = 0;
            for (int i = 0; i < l; i++)
            {
                if (rPointer >= rightArr.Count || lPointer < leftArr.Count && leftArr[lPointer] < rightArr[rPointer])
                {
                    res.Add(leftArr[lPointer++]);
                }
                else
                {
                    res.Add(rightArr[rPointer++]);
                }
            }

            return res;
        }
    }
}