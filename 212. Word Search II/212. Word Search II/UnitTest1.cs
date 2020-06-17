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
                new[] {'o', 'a', 'a', 'n'},
                new[] {'e', 't', 'a', 'e'},
                new[] {'i', 'h', 'k', 'r'},
                new[] {'i', 'f', 'l', 'v'}
            };

            var words = new string[] { "oath", "pea", "eat", "rain" };

            var actual = FindWords(board, words);

            var expected = new List<string> { "eat", "oath" };

            CollectionAssert.AreEqual(expected, actual);
        }

        public IList<string> FindWords(char[][] board, string[] words)
        {
            var trie = new Trie();

            trie.Init(board);

            var res = new List<string>();

            foreach (var word in words)
            {
                if(trie.Exist(word)) res.Add(word);
            }

            return res;
        }

        private class Trie
        {
            private readonly TrieNode _root;
            public Trie()
            {
                _root = new TrieNode();
            }

            public void Init(char[][] board)
            {
                for (int row = 0; row < board.GetLength(0); row++)
                {
                    for (int col = 0; col < board.GetLength(1); col++)
                    {
                        if (_root.Children.ContainsKey(board[row][col]))
                        {

                        }
                    }
                }
            }

            public bool Exist(string word)
            {
                
            }
        }

        private class TrieNode
        {
            public Dictionary<char, TrieNode> Children { get; set; } = new Dictionary<char, TrieNode>();
        }
    }
}