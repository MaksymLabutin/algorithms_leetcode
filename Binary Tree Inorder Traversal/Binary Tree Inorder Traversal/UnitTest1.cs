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

            var res = InorderTraversal(root);

            CollectionAssert.AreEqual(res, new List<int>() { 1, 3, 2 });
        }

        [Test]
        public void Test2()
        {
            //[1,null,2,3,4,5,null]
            var root = new TreeNode(1)
            {
                right = new TreeNode(2)
                {
                    left = new TreeNode(3)
                    {
                        left = new TreeNode(5)
                    },
                    right = new TreeNode(4)
                }
            };

            var res = InorderTraversal(root);

            CollectionAssert.AreEqual(res, new List<int>() { 1, 5, 3, 2, 4 });
        }

        public IList<int> InorderTraversal(TreeNode root)
        {
            var list = new List<int>();

            if (root == null) return list;

            var stack = new Stack<TreeNode>();

            stack.Push(root);

            while (stack.Count > 0)
            {
                var currentNode = stack.Pop();

                if (currentNode.right != null)
                {
                    stack.Push(currentNode.right);
                    currentNode.right = null;
                }
                
                if (currentNode.left == null)
                {
                    list.Add(currentNode.val);
                }
                else
                {
                    stack.Push(currentNode);
                    stack.Push(currentNode.left);
                    currentNode.left = null;
                }


            }

            return list;
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