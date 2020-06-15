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

            var actual = Postorder(root);

            var expected = new List<int>(){ 5, 6, 3, 2, 4, 1 };
            CollectionAssert.AreEqual(expected, actual);
        }

        private List<int> _res;
        public IList<int> Postorder(Node root)
        {
            _res = new List<int>();
            Visit(root);

            return _res; 
        }

        private void Visit(Node node)
        {
            if(node == null) return;

            foreach (var child in node.children)
            {
                Visit(child);
            }

            _res.Add(node.val);
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