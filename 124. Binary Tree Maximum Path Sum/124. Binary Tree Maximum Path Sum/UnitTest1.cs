using System;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        [Test]
        public void Test1()
        {
            var root = new TreeNode(1, new TreeNode(2), new TreeNode(3));
            var actual = MaxPathSum(root);
            var expected = 6;
            Assert.AreEqual(expected, actual);
        }


        private int _max;

        public int MaxPathSum(TreeNode root)
        {
            _max = root.val;
            Visit(root);
            return _max;
        }

        private int Visit(TreeNode node)
        {
            if (node == null) return 0;
            var l = Visit(node.left);
            var r = Visit(node.right);
            var sum = l + r + node.val;
            _max = Math.Max(_max, sum);

            return Math.Max(l, r) + node.val > 0 ? Math.Max(l, r) + node.val : 0;
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