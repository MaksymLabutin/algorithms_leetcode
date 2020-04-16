using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            //[3,9,20,null,null,15,7]
            var root = new TreeNode(3)
            {
                left = new TreeNode(9),
                right = new TreeNode(20)
                {
                    left = new TreeNode(15),
                    right = new TreeNode(7)
                }
            };

            var res = MinDepth(root);

            var expected = 2;

            Assert.AreEqual(expected, res);
        }

        public int MinDepth(TreeNode root)
        {
            if (root == null) return 0;
            var q = new Queue<TreeNode>();

            var step = 0;

            q.Enqueue(root);

            while (q.Count > 0)
            { 
                var size = q.Count;
                step++;

                for (var i = 0; i < size; i++)
                {
                    var node = q.Dequeue();

                    if (node.left == null && node.right == null) return step;

                    if(node.left != null) q.Enqueue(node.left);
                    if(node.right != null) q.Enqueue(node.right); 
                }
            }

            return step;
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }
    }
}