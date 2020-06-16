using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    { 

        [Test]
        public void Test1()
        {
            //    ["WordDictionary", "addWord", "addWord", "addWord", "search", "search", "search", "search"]
            //[[],["bad"],["dad"],["mad"],["pad"],["bad"],[".ad"],["b.."]]

            WordDictionary wd = new WordDictionary();
            wd.AddWord("bad");
            wd.AddWord("dad");
            wd.AddWord("mad"); 
            Assert.IsFalse(wd.Search("pad"));
            Assert.IsTrue(wd.Search("bad"));
            Assert.IsTrue(wd.Search(".ad"));
            Assert.IsTrue(wd.Search("b.."));
        }

        public class WordDictionary
        {
            private readonly TrieNode _root;
            /** Initialize your data structure here. */
            public WordDictionary()
            {
                _root = new TrieNode();
            }

            /** Adds a word into the data structure. */
            public void AddWord(string word)
            {
                var node = _root;
                foreach (var symbol in word)
                {
                    if (node.Children.ContainsKey(symbol)) node = node.Children[symbol];
                    else
                    {
                        var trieNode = new TrieNode();
                        node.Children.Add(symbol, trieNode);
                        node = trieNode;
                    }
                }

                node.IsWord = true;
            }

            /** Returns if the word is in the data structure. A word could contain the dot character '.' to represent any one letter. */
            public bool Search(string word)
            {
                return IsExist(word, _root);
            }

            private bool IsExist(string word, TrieNode node)
            {

                for (int i = 0; i < word.Length; i++)
                {
                    if (word[i] == '.')
                    {
                        foreach (var child in node.Children)
                        {
                            var isExist = IsExist(word.Substring(i + 1, word.Length - i - 1), child.Value);
                            if (isExist) return true;
                        }

                        return false;
                    }
                    else
                    {
                        if (!node.Children.ContainsKey(word[i])) return false;
                        node = node.Children[word[i]];
                    }
                }

                return node.IsWord;
            }
        } 

        private class TrieNode
        {
            public bool IsWord { get; set; }
            public Dictionary<char, TrieNode> Children { get; set; } = new Dictionary<char, TrieNode>();
        }
    }
}