using System;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var A = new int[][]
            {
                new []{ 1, 2, 3 },
                new []{ 4, 5, 6 },
                new []{ 7, 8, 9 }

            };

            var actual = MinFallingPathSum(A);

            var expected = 12;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test2()
        {
            var A = new int[][]
            {
                new []{ 1, 2, 3 },
                new []{ 4, 5, 6 }

            };

            var actual = MinFallingPathSum(A);

            var expected = 5;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test3()
        {
            var A = new int[][]
            {
                new []{ 1, 2, 3 }
            };

            var actual = MinFallingPathSum(A);

            var expected = 1;
            Assert.AreEqual(expected, actual);
        }

        public int MinFallingPathSum(int[][] A)
        { 
            for (var row = A.Length - 2; row >= 0; row--)
            {
                for (var col = 0; col < A[row].Length; col++)
                {
                    if (col > 0 && col + 1 < A[row].Length)
                    {
                        A[row][col] += Math.Min(A[row + 1][col - 1], Math.Min(A[row + 1][col], A[row + 1][col + 1]));
                    }
                    else if (col == 0)
                    {
                        A[row][col] += Math.Min(A[row + 1][col], A[row + 1][col + 1]);
                    }
                    else
                    { 
                        A[row][col] += Math.Min(A[row + 1][col], A[row + 1][col - 1]);
                    }
                } 
            }
            var min = int.MaxValue;

            for (var i = 0; i < A.Length; i++)
            {
                min = Math.Min(min, A[0][i]);

            }

            return min;
        }
    }
}