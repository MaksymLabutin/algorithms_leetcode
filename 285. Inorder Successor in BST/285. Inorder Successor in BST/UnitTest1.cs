using System;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        [SetUp]
        public void SetUp()
        {
            successor = new TreeNode(int.MaxValue);
            
        }

        [Test]
        public void Test1()
        {
            var p = new TreeNode(1);
            var root = new TreeNode(2)
            {
                left = p,
                right = new TreeNode(3)
            };

            var actual = InorderSuccessor(root, p);

            Assert.AreEqual(actual, root);
        }

        [Test]
        public void Test2()
        {
            var expected = new TreeNode(3);
            var root = new TreeNode(2)
            {
                left = new TreeNode(1),
                right = expected
            };

            var actual = InorderSuccessor(root, root);

            Assert.AreEqual(expected, actual);
        }

        private TreeNode successor = new TreeNode(int.MaxValue);
        public TreeNode InorderSuccessor(TreeNode root, TreeNode p)
        {
            if (root == null) return null;

            successor = successor?.val > root.val && p.val < root.val? root : successor;
            InorderSuccessor(root.left, p);
            InorderSuccessor(root.right, p);
            return successor.val == Int32.MaxValue ? null : successor;
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