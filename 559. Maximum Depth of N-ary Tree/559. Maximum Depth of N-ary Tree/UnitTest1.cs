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
            //[1,null,3,2,4,null,5,6]
            var root = new Node(1)
            {
                children = new List<Node>()
                {
                    new Node(2)
                    {
                        children = new List<Node>()
                        {
                            new Node(1)
                        }
                    },
                    new Node(3),
                    new Node(4)
                }

            };

            var actual = MaxDepth(root);

            var expected = 3;

            Assert.AreEqual(expected, actual);
        }

        public int MaxDepth(Node root)
        {
            if (root == null) return 0;

            var maxH = Visit(root, 1);

            return maxH;
        }

        private int Visit(Node node, int h)
        {
            if (node == null) return h - 1;
            var _h = h;

            foreach (var child in node.children)
            {
                var currH = Visit(child, h + 1);
                _h = Math.Max(_h, currH);
            }

            return _h;
        }

        public class Node
        {
            public int val;
            public IList<Node> children = new List<Node>();

            public Node() { }

            public Node(int _val)
            {
                val = _val;
            }

            public Node(int _val, IList<Node> _children)
            {
                val = _val;
                children = _children;
            }
        }
    }
}