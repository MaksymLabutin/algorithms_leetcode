using System;
using System.Collections;
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
            var arrays = new List<IList<int>>
            {
                new List<int>() {1, 2, 3},
                new List<int>() {4, 5},
                new List<int>() {1, 2, 3},
            };

            var actual = MaxDistance(arrays);

            var expected = 4;
            Assert.AreEqual(expected, actual);
        }

        public int MaxDistance(IList<IList<int>> arrays)
        {
            var minHeap = new SortedList<int, int>(new MinHeapCompare());
            var maxHeap = new SortedList<int, int>(new MaxHeapCompare());
            var maxL = 2;

            for (int i = 0; i < arrays.Count; i++)
            {
                minHeap.Add(arrays[i][0], i);
                if (minHeap.Count > maxL) minHeap.RemoveAt(minHeap.Count - 1);
            }

            for (int i = 0; i < arrays.Count; i++)
            {
                maxHeap.Add(arrays[i][arrays[i].Count - 1], i);
                if (maxHeap.Count > maxL) maxHeap.RemoveAt(maxHeap.Count - 1);
            }

            var max = int.MinValue;
            foreach (var i in maxHeap)
            {
                foreach (var i1 in minHeap)
                {
                    if(i.Value == i1.Value) continue;
                    max = Math.Max(i.Key - i1.Key, max);
                }
            } 

            return max;
        }

        public class MaxHeapCompare : IComparer<int>
        { 
            public int Compare(int x, int y)
            {
                return x > y ? -1 : 1;
            }
        }

        public class MinHeapCompare : IComparer<int>
        { 
            public int Compare(int x, int y)
            {
                return x > y ? 1 : -1;
            }
        }
    }
}