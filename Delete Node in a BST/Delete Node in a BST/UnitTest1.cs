using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        private TreeNode _root;

        [SetUp]
        public void Setup()
        {
            _root = new TreeNode(5)
            {
                left = new TreeNode(3)
                {
                    left = new TreeNode(2),
                    right = new TreeNode(4)
                },
                right = new TreeNode(6)
                {
                    right = new TreeNode(7)
                }
            };
        }

        [Test]
        public void Test1()
        {

            var res = DeleteNode(_root, 3);

            Assert.AreEqual(res.left.val, 4);
        }
        [Test]
        public void Test2()
        {

            var res = DeleteNode(_root, 2);

            Assert.IsNull(res.left.left);
        }
        [Test]
        public void Test3()
        {

            var res = DeleteNode(_root, 6);

            Assert.AreEqual(res.right.val, 7);
        }

        [Test]
        public void Test4()
        {

            var res = DeleteNode(_root, 5);

            Assert.AreEqual(res.val, 6);
        }

        [Test]
        public void Test5()
        {

            var res = DeleteNode(_root, 5);

            Assert.AreEqual(res.right.val, 7);
        }


        public TreeNode DeleteNode(TreeNode root, int key)
        {
            if (root == null) return null;

            if (root.val == key)
            {
                if (root.left == null)
                {
                    return root.right;
                }

                if (root.right == null)
                {
                    return root.left;
                }

                var tmp = FintSuccesor(root.right);
                root.val = tmp.val;
                root.right = DeleteNode(root.right, tmp.val);

                return root;
            }

            if (root.val > key)
            {
                root.left = DeleteNode(root.left, key);
            }
            else
            {
                root.right = DeleteNode(root.right, key);
            }

            return root;
        }

        private TreeNode FintSuccesor(TreeNode root)
        {
            while (root.left != null)
            {
                root = root.left;
            }

            return root;
        }

        //[2,0,33,null,1,25,40,null,null,11,31,34,45,10,18,29,32,null,36,43,46,4,null,12,24,26,30,null,null,35,39,42,44,null,48,3,9,null,14,22,null,null,27,null,null,null,null,38,null,41,null,null,null,47,49,null,null,5,null,13,15,21,23,null,28,37,null,null,null,null,null,null,null,null,8,null,null,null,17,19,null,null,null,null,null,null,null,7,null,16,null,null,20,6]
        //33

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }
    }
}
