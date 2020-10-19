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
            //[[0,30],[5,10],[15,20]]
            var intervals = new int[][]
            {
                new int[] {0, 30},
                new int[] {5, 10},
                new int[] {15, 20},
            };

            var actual = CanAttendMeetings(intervals);

            Assert.IsFalse(actual);
        }

        [Test]
        public void Test2()
        {
            var intervals = new int[][]
                {
                new int[] {7, 10},
                new int[] {2, 4},
                };

            var actual = CanAttendMeetings(intervals);

            Assert.IsTrue(actual);
        }

        [Test]
        public void Test3()
        {
            //[[9,10],[4,9],[4,17]]
            var intervals = new int[][]
                {
                new int[] {9, 10},
                new int[] {4, 9},
                new int[] {4, 17},
                };

            var actual = CanAttendMeetings(intervals);

            Assert.IsFalse(actual);
        }

        [Test]
        public void Test4()
        {
            //[[8,11],[17,20],[17,20]]
            var intervals = new int[][]
                {
                new int[] {8, 11},
                new int[] {17, 20},
                new int[] {17, 20},
                };

            var actual = CanAttendMeetings(intervals);

            Assert.IsFalse(actual);
        }

        [Test]
        public void Test5()
        {
            var intervals = new int[][]
                {
                new int[] {8, 8},
                new int[] {8, 8}
                };

            var actual = CanAttendMeetings(intervals);

            Assert.IsTrue(actual);
        }

        public bool CanAttendMeetings(int[][] intervals)
        {
            if (intervals.Length == 0) return true;

            var heap = new SortedList<int, int>(new CompareHeloper());

            foreach (var interval in intervals)
            {
                heap.Add(interval[0], interval[1]);
            }

            int? prevEnd = null;

            foreach (var i in heap)
            {
                if (prevEnd == null)
                {
                    prevEnd = i.Value;
                    continue;
                }

                if (prevEnd > i.Key) return false;
                 prevEnd = i.Value;
            }

            return true;
        }

        public class CompareHeloper : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                return x > y ? 1 : -1;
            }
        }
    }
}