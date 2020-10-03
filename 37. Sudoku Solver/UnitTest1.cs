using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization.Formatters;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        [Test]
        public void Test1()
        {
            var board = new char[][]
            {
                new[] {'5', '3', '.',  '.', '7', '.',  '.', '.', '.'},
                new[] {'6', '.', '.',  '1', '9', '5',  '.', '.', '.'},
                new[] {'.', '9', '8',  '.', '.', '.',  '.', '6', '.'},

                new[] {'8', '.', '.',  '.', '6', '.',  '.', '.', '3'},
                new[] {'4', '.', '.',  '8', '.', '3',  '.', '.', '1'},
                new[] {'7', '.', '.',  '.', '2', '.',  '.', '.', '6'},

                new[] {'.', '6', '.',  '.', '.', '.',  '2', '8', '.'},
                new[] {'.', '.', '.',  '4', '1', '9',  '.', '.', '5'},
                new[] {'.', '.', '.',  '.', '8', '.',  '.', '7', '9'}
            };

            SolveSudoku(board);

            Assert.Pass();
        }

        private List<HashSet<char>> rows;
        private List<HashSet<char>> cols;
        private List<HashSet<char>> squers;

        public void SolveSudoku(char[][] board)
        {
            rows = InitRows(board);
            cols = InitCols(board);
            squers = InitBlocks(board);

            SolveSudoku(board, 0, 0);
        }

        public bool SolveSudoku(char[][] board, int row, int col)
        {
            if (col >= board.Length)
            {
                row++;
                col = 0;
            }
            if (row >= board.Length) return true;

            if (board[row][col] == '.')
            {
                for (var i = 1; i <= board.Length; i++)
                {
                    var c = char.Parse(i.ToString());
                    
                    if (rows[row].Contains(c) ||
                        cols[col].Contains(c) ||
                        squers[GetSquers(row, col)].Contains(c)) continue;

                    board[row][col] = c;
                    rows[row].Add(c);
                    cols[col].Add(c);
                    squers[GetSquers(row, col)].Add(c);

                    if (SolveSudoku(board, row, col + 1)) return true;

                    board[row][col] = '.';
                    rows[row].Remove(c);
                    cols[col].Remove(c);
                    squers[GetSquers(row, col)].Remove(c);
                }
            }
            else
            {
                if (SolveSudoku(board, row, col + 1)) return true;
            }

            return false;
        }

        private int GetSquers(int row, int col)
        {
            var i = row / 3 * 3;
            var i1 = (col / 3);
            return i + i1;
        }

        private List<HashSet<char>> InitRows(char[][] board)
        {
            var res = new List<HashSet<char>>();

            foreach (var row in board)
            {
                var hashSet = new HashSet<char>();
                for (int col = 0; col < board.Length; col++)
                {
                    if (row[col] == '.') continue;
                    hashSet.Add(row[col]);
                }
                res.Add(hashSet);
            }

            return res;
        }

        private List<HashSet<char>> InitCols(char[][] board)
        {
            var res = new List<HashSet<char>>();

            foreach (var row in board)
            {
                for (var col = 0; col < board.Length; col++)
                {
                    if (res.Count < col + 1) res.Add(new HashSet<char>());
                    if (row[col] == '.') continue;
                    res[col].Add(row[col]);
                }
            }

            return res;
        }

        private List<HashSet<char>> InitBlocks(char[][] board)
        {
            var res = new List<HashSet<char>>();

            for (var row = 0; row < board.Length; row++)
            {
                for (var col = 0; col < board.Length; col++)
                {
                    if (res.Count < col + 1) res.Add(new HashSet<char>());
                    if (board[row][col] == '.') continue;
                    res[GetSquers(row, col)].Add(board[row][col]);
                }
            }

            return res;
        }
    }
}