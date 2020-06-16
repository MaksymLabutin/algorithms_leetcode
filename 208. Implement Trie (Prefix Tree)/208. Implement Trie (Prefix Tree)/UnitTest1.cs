using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        [Test]
        public void Test1()
        {
            Trie trie = new Trie();

            trie.Insert("apple");
            Assert.IsTrue(trie.Search("apple"));   // returns true
            Assert.IsFalse(trie.Search("app"));     // returns false
            Assert.IsTrue(trie.StartsWith("app")); // returns true
            trie.Insert("app");
            Assert.IsTrue(trie.Search("app"));     // returns true 
        }

        public class Trie
        {
            private readonly TrieNode root;
            /** Initialize your data structure here. */
            public Trie()
            {
                root = new TrieNode();
            }

            /** Inserts a word into the trie. */
            public void Insert(string word)
            {
                var node = root;
                foreach (var symbol in word)
                {
                    if (node.children.ContainsKey(symbol))
                    {
                        node = node.children[symbol];
                    }
                    else
                    {
                        var trieNode = new TrieNode();
                        node.children.Add(symbol, trieNode);
                        node = trieNode;
                    } 
                }

                node.IsWord = true;
            }

            /** Returns if the word is in the trie. */
            public bool Search(string word)
            {
                var node = root;
                foreach (var symbol in word)
                {
                    if (node.children.ContainsKey(symbol))
                    {
                        node = node.children[symbol];
                    }
                    else
                    {
                        return false;
                    }
                }
                return node.IsWord;
            }

            /** Returns if there is any word in the trie that starts with the given prefix. */
            public bool StartsWith(string prefix)
            {
                var node = root;
                foreach (var symbol in prefix)
                {
                    if (node.children.ContainsKey(symbol))
                    {
                        node = node.children[symbol];
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;
            }
        }


        private class TrieNode
        { 
            public Dictionary<char, TrieNode> children{ get; set; } = new Dictionary<char, TrieNode>();
            public bool IsWord { get; set; }
        }
    }
}