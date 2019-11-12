using System;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    { 
        [Test]
        public void Test1()
        {
            var nodes = new TreeNode(3)
            {
                left = new TreeNode(9),
                right = new TreeNode(20)
                {
                    left = new TreeNode(15),
                    right = new TreeNode(7)
                }
            };

            var res = MaxDepth(nodes);

            Assert.AreEqual(res, 3);
        }


        public int MaxDepth(TreeNode root)
        {
            if (root == null) return 0;
             
            var left = MaxDepth(root.left);
            var right = MaxDepth(root.right);

            return Math.Max(left, right) + 1;
        }

        public class TreeNode
        {
            public TreeNode(int x) { val = x; }

            public int val;
            public TreeNode left;
            public TreeNode right;
        }
    }
}