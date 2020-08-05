using NUnit.Framework;

namespace Tests
{
    public class Tests
    { 
        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        private int answer;
        public int CountBattleships(char[][] board)
        {
            answer = 0;
            for (var i = 0; i < board.Length; i++)
            {
                for (var j = 0; j < board[0].Length; j++)
                {
                    if(board[i][j] == '.') continue;
                    answer += 1;
                    Dfs(board, i, j);
                }
            }

            return answer;
        }

        private void Dfs(char[][] board, int i, int j)
        {
            if (board[i][j] == '.' || i >= board.Length || i < 0 || j < 0 || j >= board[0].Length) return; 

            board[i][j] = '.';

            Dfs(board, i + 1, j);
            Dfs(board, i - 1, j);
            Dfs(board, i, j + 1);
            Dfs(board, i, j - 1);
        }
    }
}