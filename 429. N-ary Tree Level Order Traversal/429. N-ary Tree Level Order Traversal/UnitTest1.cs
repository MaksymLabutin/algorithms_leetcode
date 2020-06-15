using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        [Test]
        public void Test1()
        {
            var root = new Node(1)
            {
                children = new List<Node>()
                {
                    new Node(3)
                    {
                        children = new List<Node>()
                        {
                            new Node(5),
                            new Node(6)
                        }
                    },
                    new Node(2),
                    new Node(4)
                }
            };

            var actual = LevelOrder(root);
            var expected = new List<List<int>>
            {
                new List<int>() {1},
                new List<int>() {3, 2, 4},
                new List<int>() {5, 6}
            };

            CollectionAssert.AreEqual(expected, actual);
        }

        public IList<IList<int>> LevelOrder(Node root)
        {
            var res = new List<IList<int>>();

            if (root == null) return res;

            var q = new Queue<Node>();
            q.Enqueue(root);

            while (q.Count > 0)
            {
                var l = q.Count;

                var list = new List<int>();
                for (var i = 0; i < l; i++)
                {
                    var node = q.Dequeue();
                    list.Add(node.val);
                    foreach (var child in node.children)
                    {
                        q.Enqueue(child);
                    }
                }

                res.Add(list);
            }

            return res;
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