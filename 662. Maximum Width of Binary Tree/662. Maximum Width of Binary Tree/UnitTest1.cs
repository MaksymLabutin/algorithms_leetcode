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
            var root = new TreeNode(1)
            {
                left = new TreeNode(1)
                {
                    left = new TreeNode(1)
                    {
                        left = new TreeNode(1)
                    }
                }
            };

            var actual = WidthOfBinaryTree(root);

            var expected = 1;

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Test2()
        {
            var root = new TreeNode(1)
            {
                left = new TreeNode(1)
                {
                    left = new TreeNode(1)
                    {
                        left = new TreeNode(1)
                    }
                },
                right = new TreeNode(1)
                {
                    right = new TreeNode(1)
                    {
                        right = new TreeNode(1)
                    }
                }
            };

            var actual = WidthOfBinaryTree(root);

            var expected = 8;

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Test3()
        {
            //[3,null,2,1,4]
            var root = new TreeNode(1)
            { 
                right = new TreeNode(1)
                {
                    right = new TreeNode(1),
                    left = new TreeNode(1)
                }
            };

            var actual = WidthOfBinaryTree(root);

            var expected = 2;

            Assert.AreEqual(expected, actual);
        }

        public int WidthOfBinaryTree(TreeNode root)
        {

            if (root == null) return 0;
            var maxWidth = 1;

            var q = new Queue<(TreeNode, int)>();
            q.Enqueue((root, 0));

            while (q.Count > 0)
            {
                var lenght = q.Count;
                var start = -1;
                var end = -1; 
                while (lenght > 0)
                {
                    var node = q.Dequeue();

                    if (node.Item1 != null)
                    {
                        if (start == -1)
                        { 
                            start = node.Item2;
                        }
                        end = node.Item2;

                        q.Enqueue((node.Item1.left, node.Item2 * 2));
                        q.Enqueue((node.Item1.right, node.Item2 * 2 + 1));
                    } 
                    lenght--;
                } 

                maxWidth = Math.Max(end - start + 1, maxWidth);
            }

            return maxWidth;
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