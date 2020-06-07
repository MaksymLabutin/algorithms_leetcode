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
        public void Test5()
        {
            // [2,4,3,1,null,0,5,null,6,null,null,null,7]
            var root = new TreeNode(2)
            {
                left = new TreeNode(4)
                {
                    left = new TreeNode(1)
                    {
                        right = new TreeNode(6)
                    }
                },
                right = new TreeNode(3)
                {
                    left = new TreeNode(0),
                    right = new TreeNode(5)
                    {
                        right = new TreeNode(7)
                    }
                }
            };

            var actual = MaxAncestorDiff(root);

            var expected = 5;

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
         
        public int MaxAncestorDiff(TreeNode root)
        { 
            if (root == null) return 0;

            var res = Visit(root, root.val, root.val);
            return res.max - res.min;
        }

        private (int max, int min) Visit(TreeNode node, int max, int min)
        {
            if (node == null) return (max, min);

            var currMax = Math.Max(node.val, max);
            var currMin = Math.Min(node.val, min);

            var l = Visit(node.left, currMax, currMin);
            var r = Visit(node.right, currMax, currMin);

            return l.max - l.min > r.max - r.min ? l : r;
        }


        //private void Visit(TreeNode node, int val)
        //{
        //    if (node == null) return;

        //    if(_visited.Contains((node.val, val))) return;
        //    _visited.Add((node.val, val));

        //    _max = _max > Math.Abs(node.val - val) ? _max : Math.Abs(node.val - val);
        //    Visit(node.left, Math.Max(node.val, val));
        //    Visit(node.right, Math.Max(node.val, val));
        //    Visit(node.left, Math.Min(node.val, val));
        //    Visit(node.right, Math.Min(node.val, val));
        //}

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