using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    { 
        [Test]
        public void Test1()
        {
            //[1, 2, 3],[4,5,6],[7,8,9]
            int[][] matrix = new int[][]
            {
                new int[] {1, 2, 3},
                new int[] {4, 5, 6},
                new int[] {7, 8, 9},
            };

            Rotate(matrix);

            int[][] expected = new int[][]
            {
                new int[] {7,4,1},
                new int[] {8,5,2},
                new int[] {9,6,3},
            };
             
            CollectionAssert.AreEqual(expected, matrix); 
        }

        public void Rotate(int[][] matrix)
        {
            if (matrix.Length == 0) return;

            for (var row = 0; row < (matrix.Length + 1) / 2; row++)
            {
                for (var col = 0; col < matrix.Length / 2; col++)
                {
                    var tmp = matrix[col][matrix.Length - row - 1];
                    matrix[col][matrix.Length - row - 1] = matrix[row][col];
                    var tmp2 = matrix[matrix.Length - row - 1][matrix.Length - col - 1];
                    matrix[matrix.Length - row - 1][matrix.Length - col - 1] = tmp;
                    tmp = matrix[matrix.Length - col - 1][row];
                    matrix[matrix.Length - col - 1][row] = tmp2;
                    matrix[row][col] = tmp;
                }
            }
        }


        //public void Rotate(int[][] matrix)
        //{
        //    if(matrix.Length == 0) return; 

        //    for (int row = 0; row < matrix.Length / 2; row++)
        //    {
        //        var insert = Read(matrix, State.Top, row);
        //        Swap(matrix, insert, row, State.Right);
        //    } 
        //}


        //private void Swap(int[][] matrix, List<int> insert, int n, State state)
        //{
        //    if(state == State.Top) return;
        //    var memo = Read(matrix, state, n);

        //    var index = 0;
        //    //arr1 is line, arr2 is col
        //    for (var i = n; i < matrix.Length - n; i++)
        //    {
        //        switch (state)
        //        {
        //            case State.Top:
        //                matrix[n][i] = insert[index];
        //                break;
        //            case State.Right:
        //                matrix[i][matrix.Length - n - 1] = insert[index];
        //                break;
        //            case State.Down:
        //                matrix[matrix.Length - n - 1][i] = insert[index];
        //                break;
        //            case State.Left:
        //                matrix[matrix.Length - 1 - i][n] = insert[index];
        //                break; 
        //        }
        //        index++;
        //    }

        //    Swap(matrix, memo, n, (State)((byte)state << 1));
        //}

        //private List<int> Read(int[][] matrix, State state, int n)
        //{
        //    var res = new List<int>();

        //    for (var i = n; i < matrix.Length - n; i++)
        //    {
        //        switch (state)
        //        {
        //            case State.Top:
        //                res.Add(matrix[n][i]);
        //                break;
        //            case State.Right: 
        //                res.Add(matrix[i][matrix.Length - n - 1]);
        //                break;
        //            case State.Down: 
        //                res.Add(matrix[matrix.Length - n - 1][i]);
        //                break;
        //            case State.Left: 
        //                res.Add(matrix[matrix.Length - 1 - i][n]);
        //                break; 
        //        }

        //    }

        //    return res;
        //}

        //enum State
        //{
        //    Top = 0,
        //    Right = 1,
        //    Down = 2,
        //    Left = 4
        //}

        //for (var col = row; col<matrix.Length - row - 1; col++)
        //{
        //    var tmp = matrix[row][matrix.Length - col - 1];
        //    var tmp2 = 0;
        //    matrix[row][matrix.Length - col - 1] = matrix[row][col];
        //    tmp2 = matrix[matrix.Length - row - 1][matrix.Length - row - 1];
        //    matrix[matrix.Length - row - 1][matrix.Length - row - 1] = tmp;
        //    tmp = matrix[matrix.Length - row - 1][col];
        //    matrix[matrix.Length - row - 1][col] = tmp2;
        //    matrix[row][col] = tmp;
        //}
    }
}