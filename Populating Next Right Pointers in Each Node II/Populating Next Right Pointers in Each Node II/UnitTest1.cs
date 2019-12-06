using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var root = new Node()
            {
                val = 1,
                left = new Node()
                {
                    val = 2,
                    left = new Node()
                    {
                        val = 4
                    },
                    right = new Node()
                    {
                        val = 5
                    }
                },
                right = new Node()
                {
                    val = 3,
                    left = new Node()
                    {
                        val = 6
                    },
                    right = new Node()
                    {
                        val = 7
                    }
                }
            };

            Connect(root);

            Assert.Pass();
        }

        private Stack<Node> _nodes = new Stack<Node>();

        public Node Connect(Node root)
        {
            if (root == null) return null;

            root.next = _nodes.Count == 0 ? null : _nodes.Pop();

            Connect(root.right);

            Connect(root.left);

            _nodes.Push(root);

            return root;
        }

        public class Node
        { 

            public int val;
            public Node left;
            public Node right;
            public Node next;

            public Node() { }
            public Node(int _val, Node _left, Node _right, Node _next)
            {
                val = _val;
                left = _left;
                right = _right;
                next = _next;
            }
        }


    }
}