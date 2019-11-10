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

            var res = PostorderTraversal(root);

            CollectionAssert.AreEqual(res, new List<int>() { 3,2,1});

            Assert.Pass();
        }

        public IList<int> PostorderTraversal(TreeNode root)
        {
            var list = new List<int>();

            if (root == null) return;

            var stack = new Stack<TreeNode>();

            stack.Push(root);

            while (stack.Count > 0)
            {
                var currentNode = stack.Pop();
                if (currentNode.left == null && currentNode.right == null)
                {
                    list.Add(currentNode.val);
                    continue;
                }

                stack.Push(currentNode);

                if (currentNode.right != null)
                {

                    stack.Push(currentNode.right);
                    currentNode.right = null;
                }

                if (currentNode.left != null)
                { 
                    stack.Push(currentNode.left);
                    currentNode.left = null;
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