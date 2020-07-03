using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
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
                right = new TreeNode(1)
                {
                    left = new TreeNode(1),
                    right = new TreeNode(1)
                    {

                        left = new TreeNode(1),
                        right = new TreeNode(1)
                        {
                            right = new TreeNode(1)
                            {
                                right = new TreeNode(1)
                            }
                        }
                    }
                }
            };

            var actual = LongestZigZag(root);
            var exected = 2;

            Assert.AreEqual(exected, actual);
        }

        private int _max;
        public int LongestZigZag(TreeNode root)
        {
            _max = 0;
            LongestZigZag(root.left, true, 0);
            LongestZigZag(root.right, false, 0);

            return _max;
        }

        public void LongestZigZag(TreeNode node, bool isLeft, int h)
        {
            if (node != null)
            {
                if (!isLeft)
                {
                    LongestZigZag(node.right, false, 0);
                    LongestZigZag(node.left, true, h + 1);
                }
                else
                {
                    LongestZigZag(node.right, false, h + 1);
                    LongestZigZag(node.left, true, 0);
                  
                } 
            }

            _max = Math.Max(h, _max); 
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