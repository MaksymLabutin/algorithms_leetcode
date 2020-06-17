using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        [Test]
        public void Test1()
        {
            char[][] board = new[]
            {
                new[] {'A', 'B', 'C', 'E'},
                new[] {'S', 'F', 'C', 'S'},
                new[] {'A', 'D', 'E', 'E'}
            };

            var word = "ABCCED";

            var actual = Exist(board, word);

            Assert.IsTrue(actual);
        }

        [Test]
        public void Test2()
        {
            char[][] board = new[]
            {
                new[] {'A', 'B', 'C', 'E'},
                new[] {'S', 'F', 'C', 'S'},
                new[] {'A', 'D', 'E', 'E'}
            };

            var word = "SEE";

            var actual = Exist(board, word);

            Assert.IsTrue(actual);
        }

        [Test]
        public void Test3()
        {
            char[][] board = new[]
            {
                new[] {'A', 'B', 'C', 'E'},
                new[] {'S', 'F', 'C', 'S'},
                new[] {'A', 'D', 'E', 'E'}
            };

            var word = "ABCB";

            var actual = Exist(board, word);

            Assert.IsFalse(actual);
        }

         

        public bool Exist(char[][] board, string word)
        {
            for (var row = 0; row < board.Length; row++)
            {
                for (int col = 0; col < board[row].Length; col++)
                {
                    if (board[row][col] == word[0])
                    {
                        var isExist = Search(board, word.Substring(1, word.Length - 1), new HashSet<(int, int)>(), row,
                            col);
                        if (isExist) return true;
                    }
                }
            }

            return false;
        }

        private bool Search(char[][] board, string word, HashSet<(int, int)> visited, int rowIndex, int colIndex)
        {
            if (visited.Contains((rowIndex, colIndex))) return false;

            if (string.IsNullOrEmpty(word)) return true;


            visited.Add((rowIndex, colIndex));
            var isExist = false;

            if (rowIndex > 0 && board[rowIndex - 1][colIndex] == word[0])
            {
                isExist = Search(board, word.Substring(1, word.Length - 1), visited, rowIndex - 1, colIndex);
            }
            if (!isExist && rowIndex + 1 < board.Length && board[rowIndex + 1][colIndex] == word[0])
            { 
                isExist = Search(board, word.Substring(1, word.Length - 1), visited, rowIndex + 1, colIndex);
            }
            if (!isExist && colIndex > 0 && board[rowIndex][colIndex - 1] == word[0])
            { 
                isExist = Search(board, word.Substring(1, word.Length - 1), visited, rowIndex, colIndex - 1);
            }
            if (!isExist && colIndex + 1 < board[rowIndex].Length && board[rowIndex][colIndex + 1] == word[0])
            { 
                isExist = Search(board, word.Substring(1, word.Length - 1), visited, rowIndex, colIndex + 1);
            }

            if(!isExist) visited.Remove((rowIndex, colIndex));

            return isExist;

        }
    }
}