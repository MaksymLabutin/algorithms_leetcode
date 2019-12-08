using System;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        [SetUp]
        public void SetUp()
        {
            _prev = null;

        }

        [Test]
        public void Test1()
        {
            var root = new TreeNode(2)
            {
                left = new TreeNode(1),
                right = new TreeNode(3)
            };

            var res = IsValidBST(root);

            Assert.IsTrue(res);
        }

        [Test]
        public void Test2()
        {
            var root = new TreeNode(5)
            {
                left = new TreeNode(1),
                right = new TreeNode(7)
                {
                    left = new TreeNode(4),
                    right = new TreeNode(8)
                }
            };

            var res = IsValidBST(root);

            Assert.IsFalse(res);
        }

        [Test]
        public void Test3()
        {
            var root = new TreeNode(1)
            {
                left = new TreeNode(1)
            };

            var res = IsValidBST(root);

            Assert.IsFalse(res);
        }

        [Test]
        public void Test4()
        {
            var root = new TreeNode(Int32.MinValue);

            var res = IsValidBST(root);

            Assert.IsTrue(res);
        }

        [Test]
        public void Test5()
        {
            var root = new TreeNode(Int32.MaxValue);

            var res = IsValidBST(root);

            Assert.IsTrue(res);
        }

        [Test]
        public void Test6()
        {
            //[2147483644,-2147483648,2147483646,null,null,2147483645,2147483647]
            var root = new TreeNode(2147483644)
            {
                left = new TreeNode(-2147483648),
                right = new TreeNode(2147483646)
                { 
                    left = new TreeNode(2147483645),
                    right = new TreeNode(2147483647) 
                }
            };

            var res = IsValidBST(root);

            Assert.IsTrue(res);
        }

        private int? _prev;

        public bool IsValidBST(TreeNode root)
        {
            if (root == null) return true;

            var leftRes = IsValidBST(root.left); 
             
            var rootRes = _prev == null || root.val > _prev;
            _prev = root.val; 

            var rightRes = IsValidBST(root.right);

            return leftRes && rightRes && rootRes;
        }


    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
}