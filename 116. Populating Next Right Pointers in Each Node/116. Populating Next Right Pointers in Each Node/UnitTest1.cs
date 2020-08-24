using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    { 

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        public Node Connect(Node root)
        {
            if (root == null) return null;

            var q = new Queue<Node>();
            q.Enqueue(root);

            while (q.Count != 0)
            {
                var size = q.Count;
                Node nodePrev = null; 

                while (size > 0)
                {
                    var node = q.Dequeue();

                    if (node.left != null)
                    {
                        q.Enqueue(node.left);
                        q.Enqueue(node.right);
                    } 

                    if(nodePrev != null) nodePrev.next = node;
                    nodePrev = node; 
                    size--;
                } 
            }

            return root;
        }

        public class Node
        {
            public int val;
            public Node left;
            public Node right;
            public Node next;

            public Node() { }

            public Node(int _val)
            {
                val = _val;
            }

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