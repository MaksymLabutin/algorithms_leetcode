using System.Collections;
using System.Collections.Generic;
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
            var root = new TreeNode(1)
            {
                right = new TreeNode(2)
                {
                    left = new TreeNode(3)
                }
            };

            var res = PreorderTraversal(root);

            CollectionAssert.AreEqual(res, new List<int>() { 1, 2, 3 });
        }

        public IList<int> PreorderTraversal(TreeNode root)
        {


            var list = new List<int>();

            if (root == null) return list;

            var stack = new Stack<TreeNode>();

            stack.Push(root);

            while (stack.Count > 0)
            {
                var currBode = stack.Pop();

                list.Add(currBode.val);

                if (currBode.right != null)
                {
                    stack.Push(currBode.right);
                }

                if (currBode.left != null)
                {
                    stack.Push(currBode.left);
                }
            }

            return list;
        }
    }

    public class TreeNode
    {
        public TreeNode(int x) { val = x; }

        public int val;
        public TreeNode left;
        public TreeNode right;
    }
}