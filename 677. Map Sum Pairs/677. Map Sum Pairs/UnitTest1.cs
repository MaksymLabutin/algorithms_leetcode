using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    { 
        [Test]
        public void Test1()
        {
            //["MapSum", "insert", "sum", "insert", "sum", "sum"]
            //    [[], ["aa",3], ["a"], ["aa",2], ["a"], ["aa"]]

            var mapSum = new MapSum();
            mapSum.Insert("aa", 3);
            Assert.AreEqual(3, mapSum.Sum("a"));
            mapSum.Insert("aa", 2);
            Assert.AreEqual(2, mapSum.Sum("a"));
            Assert.AreEqual(2, mapSum.Sum("aa"));
            Assert.Pass();
        }

        public class MapSum
        {
            private readonly TrieNode _root;

            /** Initialize your data structure here. */
            public MapSum()
            {
                _root = new TrieNode();
            }

            public void Insert(string key, int val)
            {
                var isOverrided = true;

                var node = _root;
                 
                foreach (var symbol in key)
                {
                    if (node.Children.ContainsKey(symbol))
                    {
                        node = node.Children[symbol];

                    }
                    else
                    { 
                        var trieNode = new TrieNode();
                        node.Children.Add(symbol, trieNode);
                        node = trieNode;
                        isOverrided = false;
                    }
                    node.PrefixSum += val;

                }

                var overridedNode = _root;
                if (isOverrided)
                { 
                    foreach (var symbol in key)
                    {
                        overridedNode = overridedNode.Children[symbol];
                        overridedNode.PrefixSum -= node.Val;
                    }
                }

                node.Val = val;
            }

            public int Sum(string prefix)
            {
                var node = _root;
                foreach (var symbol in prefix)
                {
                    if (!node.Children.ContainsKey(symbol)) return 0;
                    node = node.Children[symbol];
                }

                return node.PrefixSum;
            }
        }

        private class TrieNode
        {  
            public int Val { get; set; }
            public int PrefixSum { get; set; }
            public Dictionary<char, TrieNode> Children { get; set; } = new Dictionary<char, TrieNode>();
        }
    }
}