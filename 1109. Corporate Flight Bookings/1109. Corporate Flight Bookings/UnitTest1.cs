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
            //bookings = [[1, 2, 10],[2,3,20],[2,5,25]], n = 5
            //Output: [10,55,45,25,25]
            var bookings = new int[][]
            {
                new []{ 1, 2, 10 },
                new []{ 2,3,20 },
                new []{ 2,5,25 }
            };

            var n = 5;

            var actual = CorpFlightBookings(bookings, n);

            var expected = new int[] {10, 55, 45, 25, 25};

            CollectionAssert.AreEqual(expected, actual);
        }

        public int[] CorpFlightBookings(int[][] bookings, int n)
        {
            var dic = new Dictionary<(int, int), Int64>();

            foreach (var booking in bookings)
            {
                var i = booking[0];
                var j = booking[1];
                var k = booking[2];

                if (dic.ContainsKey((i, j))) dic[(i, j)] += k;
                else dic.Add((i, j), k);
            }

            var res = new int[n];

            foreach (var l in dic)
            {
                var i = l.Key.Item1;
                var j = l.Key.Item2;

                for (int k = i; k <= j; k++)
                {
                    res[k - 1] += (int)l.Value;
                }
            }

            return res;
        }

        //public int[] CorpFlightBookings(int[][] bookings, int n)
        //{
        //    int[] total = new int[n];
        //    foreach (int[] booking in bookings)
        //    {
        //        // mark the changes that this index includes
        //        total[booking[0] - 1] += booking[2];
        //        if (booking[1] < n)
        //            total[booking[1]] -= booking[2];
        //    }
        //    int runningCount = 0;
        //    for (int i = 0; i < n; i++)
        //    {
        //        if (total[i] != 0)
        //            runningCount += total[i];
        //        total[i] = runningCount;
        //    } 
        //    return total;
        //}
    }
}