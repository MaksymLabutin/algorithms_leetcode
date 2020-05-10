using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {


        [Test]
        public void Test1()
        {
            var matrix = new int[,]
            {
                {1, 4, 7, 11, 15, 20},
                {2, 5, 8, 12, 19, 21},
                {3, 6, 9, 16, 22, 23},
                {10, 13, 14, 17, 24, 25},
                {18, 21, 23, 26, 30, 34}
            };

            var target = 5;
            var actual = SearchMatrix(matrix, target);

            Assert.True(actual);
        }

        [Test]
        public void Test2()
        {
            var matrix = new int[,]
            {
                {1, 4, 7, 11, 15},
                {2, 5, 8, 12, 19},
                {3, 6, 9, 16, 22},
                {10, 13, 14, 17, 24},
                {18, 21, 23, 26, 30}
            };

            var target = 20;
            var actual = SearchMatrix(matrix, target);

            Assert.False(actual);
        }

        [Test]
        public void Test3()
        {
            var matrix = new int[,]
            {
                {1, 4, 7, 11, 15},
                {2, 5, 8, 12, 19},
                {3, 6, 9, 16, 22},
                {10, 13, 14, 17, 24},
                {18, 21, 23, 26, 30}
            };

            var target = 1;
            var actual = SearchMatrix(matrix, target);

            Assert.True(actual);
        }

        [Test]
        public void Test4()
        {
            var matrix = new int[,]
            {
                {1, 4, 7, 11, 15},
                {2, 5, 8, 12, 19},
                {3, 6, 9, 16, 22},
                {10, 13, 14, 17, 24},
                {18, 21, 23, 26, 30}
            };

            var target = 4;
            var actual = SearchMatrix(matrix, target);

            Assert.True(actual);
        }


        [Test]
        public void Test5()
        {
            var matrix = new int[,]
            {
                {1, 4, 7, 11, 15},
                {2, 5, 8, 12, 19},
                {3, 6, 9, 16, 22},
                {10, 13, 14, 17, 24},
                {18, 21, 23, 26, 30}
            };

            var target = 7;
            var actual = SearchMatrix(matrix, target);

            Assert.True(actual);
        }

        [Test]
        public void Test6()
        {
            var matrix = new int[,]
            {
                {1, 4, 7, 11, 15},
                {2, 5, 8, 12, 19},
                {3, 6, 9, 16, 22},
                {10, 13, 14, 17, 24},
                {18, 21, 23, 26, 30}
            };

            var target = 11;
            var actual = SearchMatrix(matrix, target);

            Assert.True(actual);
        }

        [Test]
        public void Test7()
        {
            var matrix = new int[,]
            {
                {1, 4, 7, 11, 15},
                {2, 5, 8, 12, 19},
                {3, 6, 9, 16, 22},
                {10, 13, 14, 17, 24},
                {18, 21, 23, 26, 30}
            };

            var target = 15;
            var actual = SearchMatrix(matrix, target);

            Assert.True(actual);
        }


        [Test]
        public void Test8()
        {
            var matrix = new int[,]
            {
                {1, 4, 7, 11, 15},
                {2, 5, 8, 12, 19},
                {3, 6, 9, 16, 22},
                {10, 13, 14, 17, 24},
                {18, 21, 23, 26, 30}
            };

            var target = 2;
            var actual = SearchMatrix(matrix, target);

            Assert.True(actual);
        }

        [Test]
        public void Test9()
        {
            var matrix = new int[,]
            {
                {1, 4, 7, 11, 15},
                {2, 5, 8, 12, 19},
                {3, 6, 9, 16, 22},
                {10, 13, 14, 17, 24},
                {18, 21, 23, 26, 30}
            };

            var target = 8;
            var actual = SearchMatrix(matrix, target);

            Assert.True(actual);
        }


        [Test]
        public void Test10()
        {
            var matrix = new int[,]
            {
                {1, 4, 7, 11, 15},
                {2, 5, 8, 12, 19},
                {3, 6, 9, 16, 22},
                {10, 13, 14, 17, 24},
                {18, 21, 23, 26, 30}
            };

            var target = 12;
            var actual = SearchMatrix(matrix, target);

            Assert.True(actual);
        }


      

        [Test]
        public void Test12()
        {
            var matrix = new int[,]
            {
                {1, 4, 7, 11, 15},
                {2, 5, 8, 12, 19},
                {3, 6, 9, 16, 22},
                {10, 13, 14, 17, 24},
                {18, 21, 23, 26, 30}
            };

            var target = 3;
            var actual = SearchMatrix(matrix, target);

            Assert.True(actual);
        }

        [Test]
        public void Test13()
        {
            var matrix = new int[,]
            {
                {1, 4, 7, 11, 15},
                {2, 5, 8, 12, 19},
                {3, 6, 9, 16, 22},
                {10, 13, 14, 17, 24},
                {18, 21, 23, 26, 30}
            };

            var target = 6;
            var actual = SearchMatrix(matrix, target);

            Assert.True(actual);
        }


        [Test]
        public void Test14()
        {
            var matrix = new int[,]
            {
                {1, 4, 7, 11, 15},
                {2, 5, 8, 12, 19},
                {3, 6, 9, 16, 22},
                {10, 13, 14, 17, 24},
                {18, 21, 23, 26, 30}
            };

            var target = 9;
            var actual = SearchMatrix(matrix, target);

            Assert.True(actual);
        }

        [Test]
        public void Test29()
        {
            var matrix = new int[,]
            {
                {1, 4, 7, 11, 15},
                {2, 5, 8, 12, 19},
                {3, 6, 9, 16, 22},
                {10, 13, 14, 17, 24},
                {18, 21, 23, 26, 30}
            };

            var target = 16;
            var actual = SearchMatrix(matrix, target);

            Assert.True(actual);
        }

        [Test]
        public void Test16()
        {
            var matrix = new int[,]
            {
                {1, 4, 7, 11, 15},
                {2, 5, 8, 12, 19},
                {3, 6, 9, 16, 22},
                {10, 13, 14, 17, 24},
                {18, 21, 23, 26, 30}
            };

            var target = 22;
            var actual = SearchMatrix(matrix, target);

            Assert.True(actual);
        }


        [Test]
        public void Test17()
        {
            var matrix = new int[,]
            {
                {1, 4, 7, 11, 15},
                {2, 5, 8, 12, 19},
                {3, 6, 9, 16, 22},
                {10, 13, 14, 17, 24},
                {18, 21, 23, 26, 30}
            };

            var target = 18;
            var actual = SearchMatrix(matrix, target);

            Assert.True(actual);
        }



        [Test]
        public void Test18()
        {
            var matrix = new int[,]
            {
                {1, 4, 7, 11, 15},
                {2, 5, 8, 12, 19},
                {3, 6, 9, 16, 22},
                {10, 13, 14, 17, 24},
                {18, 21, 23, 26, 30}
            };

            var target = 21;
            var actual = SearchMatrix(matrix, target);

            Assert.True(actual);
        }

        [Test]
        public void Test19()
        {
            var matrix = new int[,]
            {
                {1, 4, 7, 11, 15},
                {2, 5, 8, 12, 19},
                {3, 6, 9, 16, 22},
                {10, 13, 14, 17, 24},
                {18, 21, 23, 26, 30}
            };

            var target = 23;
            var actual = SearchMatrix(matrix, target);

            Assert.True(actual);
        }

        [Test]
        public void Test20()
        {
            var matrix = new int[,]
            {
                {1, 4, 7, 11, 15},
                {2, 5, 8, 12, 19},
                {3, 6, 9, 16, 22},
                {10, 13, 14, 17, 24},
                {18, 21, 23, 26, 30}
            };

            var target = 26;
            var actual = SearchMatrix(matrix, target);

            Assert.True(actual);
        }

        [Test]
        public void Test21()
        {
            var matrix = new int[,]
            {
                {1, 4, 7, 11, 15},
                {2, 5, 8, 12, 19},
                {3, 6, 9, 16, 22},
                {10, 13, 14, 17, 24},
                {18, 21, 23, 26, 30}
            };

            var target = 30;
            var actual = SearchMatrix(matrix, target);

            Assert.True(actual);
        }

        [Test]
        public void Test22()
        {
            var matrix = new int[,]
            {
                {18, 21, 23, 26, 30}
            };

            var target = 30;
            var actual = SearchMatrix(matrix, target);

            Assert.True(actual);
        }

        [Test]
        public void Test23()
        {
            var matrix = new int[,]
            {
                {18, 21, 23, 26, 30}
            };

            var target = 31;
            var actual = SearchMatrix(matrix, target);

            Assert.False(actual);
        }
        [Test]
        public void Test24()
        {
            var matrix = new int[,]
            {
                {18, 21, 23, 26, 30}
            };

            var target = 26;
            var actual = SearchMatrix(matrix, target);

            Assert.True(actual);
        }

        [Test]
        public void Test25()
        {
            var matrix = new int[,]
            {
                {18, 21, 23, 26, 30}
            };

            var target = 18;
            var actual = SearchMatrix(matrix, target);

            Assert.True(actual);
        }

        [Test]
        public void Test26()
        {
            var matrix = new int[,]
            {
                {1, 5 },
                {2, 6},
                {3, 7},
                {10, 8},
                {18, 9}
            };

            var target = 5;
            var actual = SearchMatrix(matrix, target);

            Assert.True(actual);
        }


    


        [Test]
        public void Test11()
        {
            var matrix = new int[,]
            {
                {1, 4, 7, 11, 15},
                {2, 5, 8, 12, 19},
                {3, 6, 9, 16, 22},
                {10, 13, 14, 17, 24},
                {18, 21, 23, 26, 30}
            };

            var target = 19;
            var actual = SearchMatrix(matrix, target);

            Assert.True(actual);
        }

        [Test]
        public void Should_be_false_When_matrix_empty()
        {
            var matrix = new int[,]
            {
                {}
            };

            var target = 19;
            var actual = SearchMatrix(matrix, target);

            Assert.False(actual);
        }

        public bool SearchMatrix(int[,] matrix, int target)
        {
            var rowCount = matrix.GetLength(0);
            var colCount = matrix.GetLength(1);

            var row = rowCount - 1;
            var col = 0;

            while (row >= 0 && col < colCount)
            {
                if (matrix[row, col] == target)
                    return true;

                if (target < matrix[row, col])
                    row--;
                else
                    col++;
            }

            return false;
        }

        //private int _target;
        //private int[,] _matrix;
        //private HashSet<(int, int, int, int)> _nodes;
        //public bool SearchMatrix(int[,] matrix, int target)
        //{
        //    _nodes = new HashSet<(int, int, int, int)>();
        //    _matrix = matrix;
        //    _target = target;
        //    var col = matrix.GetLength(1) - 1;
        //    var row = matrix.GetLength(0) - 1;

        //    if (row < 0 || col < 0) return false;

        //    return BS(0, row, 0, col);
        //}

        //private bool BS(int rowStart, int rowEnd, int colStart, int colEnd)
        //{
        //    if (_nodes.Contains((rowStart, rowEnd, colStart, colEnd))) return false;
        //    _nodes.Add((rowStart, rowEnd, colStart, colEnd));

        //    var min = _matrix[rowStart, colStart];
        //    var max = _matrix[rowEnd, colEnd];

        //    if (max <= _target || min >= _target) return max == _target || min == _target;

        //    var colMid = (colEnd + colStart) / 2; 
        //    var rowMid = (rowEnd + rowStart) / 2;

        //    return BS(rowStart, rowMid, colStart, colMid) || BS(rowStart, rowMid, colMid, colEnd) || BS(rowMid, rowEnd, colStart, colMid) || BS(rowMid, rowEnd, colMid, colEnd);

        //}
    }
}