using System;
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
            var intervals = new int[][]
            {
                new int[] {15, 18},
                new int[] {8, 10},
                new int[] {1, 3},
                new int[] {2, 6}
            };

            var actual = Merge(intervals);

            var expected = new int[][]
            {
                new int[] {1, 6},
                new int[] {8, 10},
                new int[] {15, 18},
            };

            CollectionAssert.AreEqual(expected, actual);
        }


        [Test]
        public void Test2()
        {
            var intervals = new int[][]
            {
                new int[] {15, 18},
                new int[] {8, 10},
                new int[] {-2, -1},
                new int[] {2, 6}
            };

            var actual = Merge(intervals);

            var expected = new int[][]
            {
                new int[] {-2, -1},
                new int[] {2, 6},
                new int[] {8, 10},
                new int[] {15, 18},
            };

            CollectionAssert.AreEqual(expected, actual);
        }


        [Test]
        public void Test3()
        {
            var intervals = new int[][]
            {
                new int[] {15, 18},
                new int[] {8, 10},
                new int[] {-2, -1},
                new int[] {2, 6},
                new int[] {17, 18},
                new int[] { 18, 19},
                new int[] { 18, 18},
            };

            var actual = Merge(intervals);

            var expected = new int[][]
            {
                new int[] {-2, -1},
                new int[] {2, 6},
                new int[] {8, 10},
                new int[] {15, 19},
            };

            CollectionAssert.AreEqual(expected, actual);
        }

        public int[][] Merge(int[][] intervals)
        {
            if(intervals.Length == 0) return new int[0][];

            intervals = intervals.OrderBy(_ => _[0]).ToArray();

            var res = new List<int[]>(); 

            var i = 0;
            while (i < intervals.Length)
            {
                var l = intervals[i][0];
                var r = intervals[i][1];

                while (i + 1 < intervals.Length && r >= intervals[i + 1][0])
                {
                    r = Math.Max(intervals[i + 1][1], r);
                    i++;
                }

                res.Add(new int[]{ l, r });

                i++;
            }

            return res.ToArray();
        }
    }
}