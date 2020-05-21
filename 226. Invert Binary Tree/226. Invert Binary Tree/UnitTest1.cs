using NUnit.Framework;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Tests
{
    public class Tests
    {


        [Test]
        public void Test1()
        {
            var root = new TreeNode(1)
            {
                left = new TreeNode(2)
            };

            var actual = InvertTree(root);
            Assert.AreEqual(1, actual.val);
            Assert.AreEqual(2, actual.right.val);
            Assert.Null(actual.left);
        }

        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null) return null;
            var q = new Queue<TreeNode>();
            q.Enqueue(root);

            while (q.Count > 0)
            {
                var l = q.Count;

                for (var i = 0; i < l; i++)
                {
                    var node = q.Dequeue();
                    var tmp = node.left;
                    node.left = node.right;
                    node.right = tmp;

                    if (node.left != null) q.Enqueue(node.left);
                    if (node.right != null) q.Enqueue(node.right);
                }

            }

            return root;
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }
    }
}