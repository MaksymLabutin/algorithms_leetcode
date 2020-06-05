using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        [Test]
        public void Test1()
        {
            var root = new TreeNode(8)
            {
                left = new TreeNode(3)
                {
                    left = new TreeNode(1),
                    right = new TreeNode(6)
                    {
                        left = new TreeNode(4),
                        right = new TreeNode(7)
                    }
                },
                right = new TreeNode(10)
                {
                    right = new TreeNode(14)
                    {
                        left = new TreeNode(13)
                    }
                }
            };

            var actual = MaxAncestorDiff(root);

            var expected = 7;

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Test2()
        {
            var root = new TreeNode(8)
            {
                left = new TreeNode(9)
            };

            var actual = MaxAncestorDiff(root);

            var expected = 1;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test3()
        {
            // [2,null,0,1]
            var root = new TreeNode(2)
            {
                right = new TreeNode(0)
                {
                    left = new TreeNode(1)
                }
            };

            var actual = MaxAncestorDiff(root);

            var expected = 2;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test4()
        {
            //[1,null,2,null,0,3]
            var root = new TreeNode(1)
            {
                right = new TreeNode(2)
                {
                    right = new TreeNode(0)
                    {
                        left = new TreeNode(3)
                    }
                }
            };

            var actual = MaxAncestorDiff(root);

            var expected = 3;

            Assert.AreEqual(expected, actual);
        }


        private int _max;
        private HashSet<(int, int)> _visited;
        public int MaxAncestorDiff(TreeNode root)
        {
            _max = 0;
            if (root == null) return _max;
            _visited = new HashSet<(int, int)>();
            Visit(root, root.val);
            return _max;
        }

        private void Visit(TreeNode node, int val)
        {
            if (node == null) return;

            if(_visited.Contains((node.val, val))) return;
            _visited.Add((node.val, val));

            _max = _max > Math.Abs(node.val - val) ? _max : Math.Abs(node.val - val);
            Visit(node.left, Math.Max(node.val, val));
            Visit(node.right, Math.Max(node.val, val));
            Visit(node.left, Math.Min(node.val, val));
            Visit(node.right, Math.Min(node.val, val));
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