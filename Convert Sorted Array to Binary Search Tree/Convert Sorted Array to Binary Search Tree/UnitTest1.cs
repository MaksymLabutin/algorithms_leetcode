using System;
using System.Linq;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var arr = new int[] { -10, -3, 0, 5, 9 };

            var res = SortedArrayToBST(arr);

            Assert.AreEqual(res.left, -3);
        }


        public TreeNode SortedArrayToBST(int[] nums)
        {
            if (nums.Length == 0) return null;

            var node = new TreeNode(nums[nums.Length / 2]);
            if (nums.Length == 1) return node;

            node.left = SortedArrayToBST(nums.Take(nums.Length / 2).ToArray());
            node.right = SortedArrayToBST(nums.Skip(nums.Length / 2 + 1).Take(nums.Length).ToArray());

            return node;
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