using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        [SetUp]
        public void Setup()
        {
            _val = new HashSet<int>();
        }

        [Test]
        public void Test1()
        {
            //[2,0,3,-4,1]
            //-1

            var root = new TreeNode(2)
            {
                left = new TreeNode(0)
                {
                    left = new TreeNode(-4),
                    right = new TreeNode(1)
                },
                right = new TreeNode(3)
            };

            var k = -1;

            var actual = FindTarget(root, k);

            Assert.IsTrue(actual);
        }

        [Test]
        public void Test2()
        {
            //[2,0,3,-4,1]
            //-1

            var root = new TreeNode(1)
            {
                left = new TreeNode(1)
               
            };

            var k = 2;

            var actual = FindTarget(root, k);

            Assert.IsTrue(actual);
        }

        [Test]
        public void Test3()
        {
            //[0,-1,2,-3,null,null,4]
            //-4

            var root = new TreeNode(0)
            {
                left = new TreeNode(-1)
                {
                    left = new TreeNode(-3)
                },
                right = new TreeNode(2)
                {
                    right = new TreeNode(4)
                }
               
            };

            var k = -4;

            var actual = FindTarget(root, k);

            Assert.IsTrue(actual);
        }


        private HashSet<int> _val = new HashSet<int>();
        public bool FindTarget(TreeNode root, int k)
        {
            if (root == null) return false;
            if (_val.Contains(root.val >= 0 || k < 0 ? k - root.val : k + root.val )) return true; 
            if (!_val.Contains(root.val)) _val.Add(root.val); 
            return FindTarget(root.left, k) || FindTarget(root.right, k);
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