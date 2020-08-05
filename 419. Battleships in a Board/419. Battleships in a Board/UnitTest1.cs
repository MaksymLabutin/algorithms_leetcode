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
                new char[] {'X', '.', '.', 'X'},
                new char[] {'.', '.', '.', 'X'},
                new char[] {'.', '.', '.', 'X'},
            };

            var actual = CountBattleships(board);

            var expected = 2;

            Assert.AreEqual(expected, actual);
        }

        private int _answer;
        public int CountBattleships(char[][] board)
        {
            _answer = 0;
            for (var i = 0; i < board.Length; i++)
            {
                for (var j = 0; j < board[0].Length; j++)
                {
                    if(board[i][j] == '.') continue;
                    _answer += 1;
                    Dfs(board, i, j);
                }
            }

            return _answer;
        }

        private void Dfs(char[][] board, int i, int j)
        {
            if ( i >= board.Length || i < 0 || j < 0 || j >= board[0].Length || board[i][j] == '.') return; 

            board[i][j] = '.';

            Dfs(board, i + 1, j);
            Dfs(board, i - 1, j);
            Dfs(board, i, j + 1);
            Dfs(board, i, j - 1);
        }
    }
}