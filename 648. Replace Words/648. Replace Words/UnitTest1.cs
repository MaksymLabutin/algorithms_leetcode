using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    { 

        [Test]
        public void Test1()
        {
            //["cat","bat","rat"]
            //"the cattle was rattled by the battery"

            var dic = new List<string> {"cat", "bat", "rat"};
            var sentence = "the cattle was rattled by the battery";

            var actual = ReplaceWords(dic, sentence);

            var expected = "the cat was rat by the bat";

            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void Test2()
        { 
            var dic = new List<string> { "a", "aa", "aaa", "aaaa" };
            var sentence = "a aa a aaaa aaa aaa aaa aaaaaa bbb baba ababa";

            var actual = ReplaceWords(dic, sentence);

            var expected = "a a a a a a a a bbb baba a";

            Assert.AreEqual(expected, actual);
        }

        public string ReplaceWords(IList<string> dict, string sentence)
        {
            var trie = new Trie();
            InitTrie(dict, trie); 
            return GetReplacedSentece(sentence, trie);
        } 

        private void InitTrie(IList<string> dict, Trie trie)
        {
            foreach (var word in dict)
            {
                trie.Insert(word);
            }
        }

        private string GetReplacedSentece(string sentence, Trie trie)
        {
            var words = sentence.Split(' ');

            for (var i = 0; i < words.Length; i++)
            {
                words[i] = trie.GetRoot(words[i]);
            }

            return string.Join(" ", words);
        }

        public class Trie
        { 
            private readonly TrieNode _root;

            public Trie()
            {
                _root = new TrieNode();
            }

            public void Insert(string word)
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

            public string GetRoot(string word)
            {
                var node = _root;
                var i = 0;
                for (; i < word.Length; i++)
                {
                    if (!node.Children.ContainsKey(word[i]))
                    {
                        if(!node.IsWord) i = 0;
                        break;
                    }

                    if(node.IsWord) break;
                    
                    node = node.Children[word[i]];
                }

                return i == 0 ? word : word.Substring(0, i);
            }
        }

        private class TrieNode
        {
            public bool IsWord { get; set; }
            public Dictionary<char, TrieNode> Children { get; set; } = new Dictionary<char, TrieNode>();
        }
    }
}