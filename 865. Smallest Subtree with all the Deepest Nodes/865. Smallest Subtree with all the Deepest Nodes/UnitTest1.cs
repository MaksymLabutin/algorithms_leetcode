using System;
using System.Globalization;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void SetUp()
        {
            _deepestNode = null;
            _k = Int32.MaxValue; 
        }

        [Test]
        public void Test1()
        {
            var root = new TreeNode(3)
            {
                left = new TreeNode(5)
                {
                    left = new TreeNode(6)
                    {
                        left = new TreeNode(1),
                        right = new TreeNode(1)
                    },
                    right = new TreeNode(2)
                    {
                        left = new TreeNode(7),
                        right = new TreeNode(4)
                    }
                },
                right = new TreeNode(1)
                {
                    left = new TreeNode(0),
                    right = new TreeNode(8)
                }
            };

            var actual = SubtreeWithAllDeepest(root);

            Assert.AreEqual(5, actual.val);

            Assert.AreEqual(2, actual.right.val);
            Assert.AreEqual(7, actual.right.left.val);
            Assert.AreEqual(4, actual.right.right.val);
            Assert.AreEqual(6, actual.left.val);
            Assert.AreEqual(1, actual.left.left.val);
            Assert.AreEqual(1, actual.left.right.val);
        }

        [Test]
        public void Test2()
        {
            var root = new TreeNode(3)
            {
                left = new TreeNode(5)
                {
                    left = new TreeNode(6),
                    right = new TreeNode(2)
                    {
                        left = new TreeNode(7),
                        right = new TreeNode(4)
                    }
                },
                right = new TreeNode(1)
                {
                    left = new TreeNode(0),
                    right = new TreeNode(8)
                }
            };

            var actual = SubtreeWithAllDeepest(root);

            Assert.AreEqual(2, actual.val);
            Assert.AreEqual(7, actual.left.val);
            Assert.AreEqual(4, actual.right.val);
        }


        private TreeNode _deepestNode;
        private int _k = Int32.MaxValue;
        public TreeNode SubtreeWithAllDeepest(TreeNode root)
        {
            if (root == null) return null;

            Visit(root, 0);

            return _deepestNode;
        }

        private int Visit(TreeNode root, int deep)
        {
            if (root == null) return 0;

            var l = Visit(root.left, deep + 1);
            var r = Visit(root.right, deep + 1); 

            if (l == r && _k > deep)
            {
                _k = deep;
                _deepestNode = root;
            }

            return deep;
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