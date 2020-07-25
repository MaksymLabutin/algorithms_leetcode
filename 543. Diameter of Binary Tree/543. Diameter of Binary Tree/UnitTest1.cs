using System;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void SetUp()
        {
            _max = 0;
        }

        [Test]
        public void Test1()
        {
            var root = new TreeNode(1);
            var actual = DiameterOfBinaryTree(root);
            var expected = 0;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test2()
        {
            var root = new TreeNode(1)
            {
                left = new TreeNode(2)
                {
                    left = new TreeNode(2),
                    right = new TreeNode(3),
                },
                right = new TreeNode(3),
            };
            var actual = DiameterOfBinaryTree(root);
            var expected = 3;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test3()
        {
            var root = new TreeNode(4)
            {
                left = new TreeNode(2)
                {
                    left = new TreeNode(1),
                    right = new TreeNode(3),
                }, 
            };
            var actual = DiameterOfBinaryTree(root);
            var expected = 2;
            Assert.AreEqual(expected, actual);
        }

        private int _max = 0; 
        public int DiameterOfBinaryTree(TreeNode root)
        {
            if (root == null) return 0;
            Dfs(root, 0);
            return _max;
        }

        private int Dfs(TreeNode node, int level)
        {
            if (node == null) return level - 1;

            var l = Dfs(node.left, level + 1);
            var r = Dfs(node.right, level + 1);

            _max = Math.Max(l - level + r - level, _max);

            return Math.Max(r,l);
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