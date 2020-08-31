using System;
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

            var expected = new List<string> { "oath", "eat" };

            CollectionAssert.AreEqual(expected, actual);
        }


        [Test]
        public void Test2()
        {
            //[["b","b","a","a","b","a"],["b","b","a","b","a","a"],["b","b","b","b","b","b"],["a","a","a","b","a","a"],["a","b","a","a","b","b"]]
            //    ["abbbababaa"]
            char[][] board = new[]
                {
                new[] {'b','b','a','a','b','a'},
                new[] {'b','b','a','b','a','a'},
                new[] {'b','b','b','b','b','b'},
                new[] { 'a', 'a', 'a', 'b', 'a', 'a' },
                new[] { 'a', 'b', 'a', 'a', 'b', 'b' }
            };

            var words = new string[] { "abbbababaa" };

            var actual = FindWords(board, words);

            var expected = new List<string> { "abbbababaa" };

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void Test3()
        {
            //[["b","a","a","b","a","b"],["a","b","a","a","a","a"],["a","b","a","a","a","b"],["a","b","a","b","b","a"],["a","a","b","b","a","b"],["a","a","b","b","b","a"],["a","a","b","a","a","b"]]
            //    ["aab","bbaabaabaaaaabaababaaaaababb","aabbaaabaaabaabaaaaaabbaaaba","babaababbbbbbbaabaababaabaaa","bbbaaabaabbaaababababbbbbaaa","babbabbbbaabbabaaaaaabbbaaab","bbbababbbbbbbababbabbbbbabaa","babababbababaabbbbabbbbabbba","abbbbbbaabaaabaaababaabbabba","aabaabababbbbbbababbbababbaa","aabbbbabbaababaaaabababbaaba","ababaababaaabbabbaabbaabbaba","abaabbbaaaaababbbaaaaabbbaab","aabbabaabaabbabababaaabbbaab","baaabaaaabbabaaabaabababaaaa","aaabbabaaaababbabbaabbaabbaa","aaabaaaaabaabbabaabbbbaabaaa","abbaabbaaaabbaababababbaabbb","baabaababbbbaaaabaaabbababbb","aabaababbaababbaaabaabababab","abbaaabbaabaabaabbbbaabbbbbb","aaababaabbaaabbbaaabbabbabab","bbababbbabbbbabbbbabbbbbabaa","abbbaabbbaaababbbababbababba","bbbbbbbabbbababbabaabababaab","aaaababaabbbbabaaaaabaaaaabb","bbaaabbbbabbaaabbaabbabbaaba","aabaabbbbaabaabbabaabababaaa","abbababbbaababaabbababababbb","aabbbabbaaaababbbbabbababbbb","babbbaabababbbbbbbbbaabbabaa"]
        char[][] board = new[]
                {
                new[] {'b','a','a','b','a','b'},
                new[] {'a','b','a','a','a','a'},
                new[] {'a','b','a','a','a','b'},
                new[] {'a','b','a','b','b','a'},
                new[] { 'a', 'a', 'b', 'b', 'a', 'b' },
                new[] { 'a','a','b','b','b','a' },
                new[] {'a','a','b','a','a','b' },
            };

            var words = new string[] { "aab", "bbaabaabaaaaabaababaaaaababb", "aabbaaabaaabaabaaaaaabbaaaba", "babaababbbbbbbaabaababaabaaa", "bbbaaabaabbaaababababbbbbaaa", "babbabbbbaabbabaaaaaabbbaaab", "bbbababbbbbbbababbabbbbbabaa", "babababbababaabbbbabbbbabbba", "abbbbbbaabaaabaaababaabbabba", "aabaabababbbbbbababbbababbaa", "aabbbbabbaababaaaabababbaaba", "ababaababaaabbabbaabbaabbaba", "abaabbbaaaaababbbaaaaabbbaab", "aabbabaabaabbabababaaabbbaab", "baaabaaaabbabaaabaabababaaaa", "aaabbabaaaababbabbaabbaabbaa", "aaabaaaaabaabbabaabbbbaabaaa", "abbaabbaaaabbaababababbaabbb", "baabaababbbbaaaabaaabbababbb", "aabaababbaababbaaabaabababab", "abbaaabbaabaabaabbbbaabbbbbb", "aaababaabbaaabbbaaabbabbabab", "bbababbbabbbbabbbbabbbbbabaa", "abbbaabbbaaababbbababbababba", "bbbbbbbabbbababbabaabababaab", "aaaababaabbbbabaaaaabaaaaabb", "bbaaabbbbabbaaabbaabbabbaaba", "aabaabbbbaabaabbabaabababaaa", "abbababbbaababaabbababababbb", "aabbbabbaaaababbbbabbababbbb", "babbbaabababbbbbbbbbaabbabaa" };

            var actual = FindWords(board, words);

            var expected = new List<string> { "aab", "abaabbbaaaaababbbaaaaabbbaab", "ababaababaaabbabbaabbaabbaba", "aabbbbabbaababaaaabababbaaba" };

            CollectionAssert.AreEqual(expected, actual);
        }

        public IList<string> FindWords(char[][] board, string[] words)
        {
            if (words.Length == 0 || board.Length == 0) return new List<string>();

            var trie = new Trie(words);

            var res = trie.GetAllWords(board);

            return res;
        }

        private class Trie
        {
            private readonly TrieNode _root;
            private readonly List<string> _res;
            public Trie(string[] words)
            {
                _root = new TrieNode();
                _res = new List<string>();
                Init(words);
            }

            public List<string> GetAllWords(char[][] board)
            {
                foreach (var rootChild in _root.Children)
                {
                    for (var row = 0; row < board.Length; row++)
                    {
                        for (var col = 0; col < board[row].Length; col++)
                        {
                            if(board[row][col] != rootChild.Key) continue;
                            Search(board, rootChild.Value, row, col, "");
                        }
                    }
                }

                return _res;
            }

            private void Init(string[] words)
            {
                if (words.Length == 0) return;

                foreach (var word in words)
                {
                    var node = _root;
                    foreach (var symbol in word)
                    {
                        if (!node.Children.ContainsKey(symbol))
                        {
                            node.Children.Add(symbol, new TrieNode(symbol));
                        }

                        node = node.Children[symbol];
                    }

                    node.IsWord = true;
                }
            }

            private void Search(char[][] board, TrieNode node, int row, int col, string word)
            {
                if (row >= board.Length ||
                    col >= board[0].Length ||
                    row < 0 ||
                    col < 0 ||
                    board[row][col] == '#' ||
                    board[row][col] != node.Symbol)
                    return;

                var tmp = board[row][col];
                board[row][col] = '#';

                word += node.Symbol;

                if (node.IsWord && !_res.Contains(word)) _res.Add(word);

                foreach (var nodeChild in node.Children)
                {
                    Search(board, nodeChild.Value, row + 1, col, word);
                    Search(board, nodeChild.Value, row - 1, col, word);
                    Search(board, nodeChild.Value, row, col + 1, word);
                    Search(board, nodeChild.Value, row, col - 1, word);
                }

                board[row][col] = tmp; 
            }
        }

        private class TrieNode
        {
            public TrieNode() { }

            public TrieNode(char symbol)
            {
                Symbol = symbol;
            }

            public char Symbol { get; set; }
            public bool IsWord { get; set; }
            public Dictionary<char, TrieNode> Children { get; set; } = new Dictionary<char, TrieNode>();
        }

        //public IList<string> FindWords(char[][] board, string[] words)
        //{
        //    if (words.Length == 0) return new List<string>();

        //    var trie = new Trie(board);

        //    var res = new List<string>();

        //    foreach (var word in words)
        //    {
        //        if (trie.Exist(word)) res.Add(word);
        //    }

        //    return res;
        //}

        //private class Trie
        //{
        //    private readonly TrieNode _root;
        //    public Trie(char[][] board)
        //    {
        //        _root = new TrieNode();
        //        Init(board);
        //    }

        //    public bool Exist(string word)
        //    {
        //        if (string.IsNullOrEmpty(word)) return true;

        //        var node = _root;
        //        foreach (var symbol in word)
        //        {
        //            if (!node.Children.ContainsKey(symbol)) return false;
        //            node = node.Children[symbol];
        //        }
        //        return true;
        //    }

        //    private void Init(char[][] board)
        //    {
        //        for (int row = 0; row < board.Length; row++)
        //        {
        //            for (int col = 0; col < board[row].Length; col++)
        //            {
        //                Dfs(board, _root, row, col);
        //            }
        //        }
        //    }



        //    private void Dfs(char[][] board, TrieNode node, int row, int col)
        //    {
        //        if (row >= board.Length ||
        //            col >= board[0].Length ||
        //            row < 0 ||
        //            col < 0 ||
        //            board[row][col] == '#')
        //            return;

        //        var tmp = board[row][col];
        //        board[row][col] = '#';

        //        TrieNode currNode = null;
        //        if (node.Children.ContainsKey(tmp)) currNode = node.Children[tmp];
        //        else
        //        {
        //            currNode = new TrieNode(tmp);
        //            node.Children.Add(tmp, currNode);
        //        }

        //        Dfs(board, currNode, row + 1, col);
        //        Dfs(board, currNode, row - 1, col);
        //        Dfs(board, currNode, row, col + 1);
        //        Dfs(board, currNode, row, col - 1);

        //        board[row][col] = tmp;
        //    }
        //}
    }
}