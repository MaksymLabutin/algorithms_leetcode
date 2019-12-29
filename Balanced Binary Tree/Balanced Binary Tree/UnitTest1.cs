using System;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    { 

        [Test]
        public void Test1()
        {
            var root = new TreeNode(3)
            {
                left = new TreeNode(9),
                right = new TreeNode(20)
                {
                    left = new TreeNode(15),
                    right = new TreeNode(7),
                }
            };

            var res = IsBalanced(root);


            Assert.IsTrue(res);
        }

        [Test]
        public void Test2()
        {
            var root = new TreeNode(1)
            {
                left = new TreeNode(2),
                right = new TreeNode(2)
                {
                    left = new TreeNode(15),
                    right = new TreeNode(7)
                    {
                        left = new TreeNode(15),
                        right = new TreeNode(7),
                    }
                }
            };
            var res = IsBalanced(root);

            Assert.IsFalse(res);
        }


        [Test]
        public void Test3()
        {
            var root = new TreeNode(1)
            {
                left = new TreeNode(2)
                {
                    left = new TreeNode(3)
                    {
                        left = new TreeNode(4),

                    }
                },
                right = new TreeNode(2)
                {
                    right = new TreeNode(3)
                    {
                        right = new TreeNode(4)
                    }

                }
            };
            var res = IsBalanced(root);

            Assert.IsFalse(res);
        }


        [Test]
        public void Test4()
        {

            var root = new TreeNode(1)
            {
                right = new TreeNode(2)
                {
                    left = new TreeNode(3)
                }
            };
            var res = IsBalanced(root);

            Assert.IsFalse(res);
        }

        private bool a = true;
        public bool IsBalanced(TreeNode root)
        {
            if (root == null) return true;
             
            return Math.Abs(Height(root.left) - Height(root.right)) < 2 && IsBalanced(root.left) && IsBalanced(root.right);
        }


        private int Height(TreeNode node)
        {
            if (node == null) return -1;

            return 1 + Math.Max(Height(node.left), Height(node.right));
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