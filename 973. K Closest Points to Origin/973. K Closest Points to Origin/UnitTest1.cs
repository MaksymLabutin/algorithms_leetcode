using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        [Test]
        public void Test1()
        {
            var points = new int[][]
            {
                new int[]{1, 3},
                new int[]{-2,2}
            };
            var K = 1;

            var actual = KClosest(points, K);

            var expected = new int[][] { new int[] { -2, 2 } };

            CollectionAssert.AreEqual(expected, actual);
        }
        //Input: points = [[3,3],[5,-1],[-2,4]], K = 2
        //Output: [[3,3],[-2,4]]
        [Test]
        public void Test2()
        {
            var points = new int[][]
            {
                new int[]{3,3},
                new int[]{ 5, -1 },
                new int[]{ -2,4}
            };
            var K = 2;

            var actual = KClosest(points, K);

            var expected = new int[][] { new int[] { 3, 3 }, new int[]{ -2, 4 }  };

            CollectionAssert.AreEqual(expected, actual);
        }

        public int[][] KClosest(int[][] points, int K)
        {

            var arr = new List<Node>();

            foreach (var point in points)
            {
                var val = GetEuclideanDistanceSqrt(point);
                arr.Add(new Node(val, point));
            } 
            return arr.OrderBy(_ => _.Val).Take(K).Select(_ => _.Points).ToArray();
        }
        

        private double GetEuclideanDistanceSqrt(int[] points)
        {
            int x0 = points[0];
            int y0 = 0;

            int x1 = 0;
            int y1 = points[1];

            int dX = x1 - x0;
            int dY = y1 - y0;
            var d = dX * dX + dY * dY;
            return d;
        }

        private class Node
        {
            public Node(double val, int[] points)
            {
                Val = val;
                Points = points;
            }

            public double Val { get; set; }
            public int[] Points { get; set; }
        }
    }
}