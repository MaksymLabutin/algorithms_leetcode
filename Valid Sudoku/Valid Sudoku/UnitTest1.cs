using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        [Test]
        public void Test1()
        {

            var res = IsValidSudoku(new char[][]
            {
                new char[]{ '5', '3', '.', '.', '7', '.', '.', '.', '.'},
                new char[]{ '6', '.', '.', '1', '9', '5', '.', '.', '.'},
                new char[]{ '.', '9', '8', '.', '.', '.', '.', '6', '.'},
                new char[]{ '8', '.', '.', '.', '6', '.', '.', '.', '3'},
                new char[]{ '4', '.', '.', '8', '.', '3', '.', '.', '1'},
                new char[]{ '7', '.', '.', '.', '2', '.', '.', '.', '6'},
                new char[]{ '.', '6', '.', '.', '.', '.', '2', '8', '.'},
                new char[]{ '.', '.', '.', '4', '1', '9', '.', '.', '5'},
                new char[]{ '.', '.', '.', '.', '8', '.', '.', '7', '9'},
            });

            Assert.IsTrue(res);
        }
        [Test]
        public void Test2()
        {

            var res = IsValidSudoku(new char[][]
            {
                new char[]{ '5', '3', '.', '.', '7', '.', '.', '.', '.'},
                new char[]{ '6', '.', '3', '1', '9', '5', '.', '.', '.'},
                new char[]{ '.', '9', '8', '.', '.', '.', '.', '6', '.'},
                new char[]{ '8', '.', '.', '.', '6', '.', '.', '.', '3'},
                new char[]{ '4', '.', '.', '8', '.', '3', '.', '.', '1'},
                new char[]{ '7', '.', '.', '.', '2', '.', '.', '.', '6'},
                new char[]{ '.', '6', '.', '.', '.', '.', '2', '8', '.'},
                new char[]{ '.', '.', '.', '4', '1', '9', '.', '.', '5'},
                new char[]{ '.', '.', '.', '.', '8', '.', '.', '7', '9'},
            });

            Assert.IsFalse(res);
        }
      

        public bool IsValidSudoku(char[][] board)
        { 
            var boxDic = new Dictionary<int, HashSet<int>>();
            var rowDic = new Dictionary<int, HashSet<int>>();
            var colDic = new Dictionary<int, HashSet<int>>();

            for (var row = 0; row < 9; row++)
            {
                for (var col = 0; col < 9; col++)
                {
                    if (board[row][col] == '.') continue;

                    if (!IsDicValid(col, board[row][col], colDic)) return false;
                    if (!IsDicValid(row, board[row][col], rowDic)) return false;
                    if (!IsDicValid(col / 3 + (row / 3) * 3, board[row][col], boxDic)) return false;
                }
            }

            return true;
        }

        private bool IsDicValid(int key, char value, Dictionary<int, HashSet<int>> dic)
        {
            if (dic.ContainsKey(key))
            {
                if (dic[key].Contains(value)) return false;
                dic[key].Add(value);
            }
            else
            {
                dic.Add(key, new HashSet<int>() { value });
            }
            return true;
        }


    }
}