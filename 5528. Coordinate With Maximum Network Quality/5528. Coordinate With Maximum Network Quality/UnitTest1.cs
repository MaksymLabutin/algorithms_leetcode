using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace _5528._Coordinate_With_Maximum_Network_Quality
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //[1,2,5],[2,1,7],[3,1,9]
            var towers = new int[][]
            {
                new int[] {1, 2, 5},
                new int[] {2, 1, 7},
                new int[] {3, 1, 9}
            };

            var radius = 2;

            var actual = BestCoordinate(towers, radius);

            var expected = new int[] {2, 1};

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test2()
        {
            //[[44,31,4],[47,27,27],[7,13,0],[13,21,20],[50,34,18],[47,44,28]]
            //13
            var towers = new int[][]
            {
                new int[] {44,31,4},
                new int[] {47,27,27},
                new int[] { 7, 13, 0 },
                new int[] { 13,21,20 },
                new int[] { 50,34,18 },
                new int[] { 47,44,28 },
            };

            var radius = 13;

            var actual = BestCoordinate(towers, radius);

            var expected = new int[] { 47, 27 };

            Assert.Equal(expected, actual);
        }


        [Fact]
        public void Test3()
        {
            //[[45,12,4],[13,21,27],[31,17,40],[25,29,45],[37,29,25],[16,37,48],[4,3,31]]
            //42
            var towers = new int[][]
            {
                new int[] {45,12,4},
                new int[] {13,21,27},
                new int[] { 31,17,40 },
                new int[] { 25,29,45 },
                new int[] { 37,29,25 },
                new int[] { 16,37,48 },
                new int[] { 4,3,31 },
            };

            var radius = 42;

            var actual = BestCoordinate(towers, radius);

            var expected = new int[] { 16, 37 };

            Assert.Equal(expected, actual);
        }



        [Fact]
        public void Test4()
        {
            //[[31,13,33],[24,45,38],[28,32,23],[7,23,22],[41,50,33],[47,21,3],[3,33,39],[11,38,5],[26,20,28],[48,39,16],[34,29,25]]
            //21
            var towers = new int[][]
            {
                new int[] {31,13,33},
                new int[] {24,45,38},
                new int[] { 28,32,23 },
                new int[] { 7,23,22 },
                new int[] { 41,50,33 },
                new int[] { 47,21,3 },
                new int[] { 3,33,39 },
                new int[] {11,38,5 },
                new int[] {26,20,28 },
                new int[] {48,39,16 },
                new int[] {34,29,25 },
            };

            var radius = 21;

            var actual = BestCoordinate(towers, radius);

            var expected = new int[] { 24, 45 };

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Test5()
        { 
            var towers = new int[][]
            {
                new int[] {28,6,30},
                new int[] {23,16,0},
                new int[] { 21,42,22 },
                new int[] { 50,33,34},
                new int[] { 14,7,50 },
                new int[] {  40,31,4 },
                new int[] { 39,45,17  },
                new int[] {46,21,12  },
                new int[] {45,36,45 },
                new int[] {35,43,43 },
                new int[] {29,41,48 },
                new int[] {22,27,5 },
                new int[] {42,44,45 },
                new int[] {10,49,50 },
                new int[] {47,43,26 },
                new int[] {40,36,25 },
                new int[] {10,25,6 },
                new int[] {27,30,30 },
                new int[] {50,35,20 },
                new int[] {11,0,44 },
                new int[] {34,29,28 },
            };

            var radius = 12;

            var actual = BestCoordinate(towers, radius);

            var expected = new int[] { 42, 44 };

            Assert.Equal(expected, actual);
        }


        public int[] BestCoordinate(int[][] towers, int radius)
        {
            if (towers.Length == 0) return new int[0];
            var res = new Dictionary<double, List<int[]>>();

            var max = 0;

            foreach (var tower in towers)
            {
                var quality = 0.0;
                foreach (var i in towers)
                { 
                    var d = GetDistance(tower, i);
                    if(radius >= d) quality += CountQ(i[2], d);
                }

                if(res.ContainsKey((int)quality)) res[(int)quality].Add(new []{ tower[0], tower[1] });
                else res.Add((int)quality, new List<int[]>(){ new[] { tower[0], tower[1] } });
                max = Math.Max(max, (int)quality);
            } 

            return res[max].OrderBy(_ => _[0]).ThenBy(_ => _[1]).First();
        }

        private double GetDistance(int[] p1, int[] p2) => Math.Sqrt(Math.Pow(p1[0] - p2[0], 2) + Math.Pow(p1[1] - p2[1], 2));

        private int CountQ(int q, double d) => (int)(q * 1.0/ (1 + d));
    }
}
