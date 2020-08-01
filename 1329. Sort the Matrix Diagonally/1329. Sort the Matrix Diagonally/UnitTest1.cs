using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public class Tests
    {
        

        [Test]
        public void Test1()
        {
            //[[3,3,1,1],[2,2,1,2],[1,1,1,2]]
            Assert.Pass();
        }


        public int[][] DiagonalSort(int[][] mat)
        {  

            for (var col = 0; col < mat.Length; col++)
            {
                var diagonal = GetDiagonal(mat, 0, col);
                diagonal = diagonal.OrderBy(_ => _).ToList();
                InsertSortedDiagonal(mat, diagonal, 0, col);
            }

            for (var row = 1; row < mat[0].Length; row++)
            {
                var diagonal = GetDiagonal(mat, row, 0);
                diagonal = diagonal.OrderBy(_ => _).ToList(); 
                InsertSortedDiagonal(mat, diagonal, row, 0);
            }

            return mat;
        }

        private List<int> GetDiagonal(int[][] mat, int row, int col)
        {
            var list = new List<int>();

            while (row < mat.Length && col < mat[0].Length)
            {
                list.Add(mat[row][col]);
                row++;
                col++;
            }

            return list;
        }

        private void InsertSortedDiagonal(int[][] mat, List<int> diagonal,int row, int col)
        {
            foreach (var val in diagonal)
            {
                mat[row][col] = val;
                row++;
                col++;
            }
        }
    }
}