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
            var tree1 = new TreeNode(2)
            {
                left = new TreeNode(1),
                right = new TreeNode(4)
            };

            var tree2 = new TreeNode(1)
            {
                left = new TreeNode(0),
                right = new TreeNode(3)
            };

            var res = GetAllElements(tree1, tree2);

            CollectionAssert.AreEqual(new List<int>() { 0, 1, 1, 2, 3, 4 }, res);
        }

        [Test]
        public void Test2()
        {
            var tree1 = new TreeNode(2)
            {
                left = new TreeNode(1),
                right = new TreeNode(4)
            };
            var res = GetAllElements(tree1, null);

            CollectionAssert.AreEqual(new List<int>() { 1, 2, 4 }, res);
        }

        [Test]
        public void Test3()
        {
            var tree1 = new TreeNode(1)
            { 
                right = new TreeNode(8)
            }; 
            var tree2 = new TreeNode(8)
            {
                left = new TreeNode(1), 
            };
            var res = GetAllElements(tree1, tree2);

            CollectionAssert.AreEqual(new List<int>() { 1, 1, 8, 8 }, res);
        }

        public IList<int> GetAllElements(TreeNode root1, TreeNode root2)
        { 
            if (root2 == null && root1 == null) return new List<int>(); 

            if (root2 == null || root1 == null) return ReadForOneNode(root2 ?? root1);

            var list1 = ReadForOneNode(root1);
            var list2 = ReadForOneNode(root2);

            var list = new List<int>();

            var i2 = 0;

            for (var i = 0; i < list1.Count; i++)
            {
                while (true)
                {
                    if (i2 >= list2.Count || list2[i2] > list1[i])  break;

                    list.Add(list2[i2++]);
                } 
                list.Add(list1[i]);
            }

            if (i2 < list2.Count)
            {
                while (true)
                {
                    if (i2 >= list2.Count) break;

                    list.Add(list2[i2++]);
                } 
            }

            return list;
        }

        private List<int> ReadForOneNode(TreeNode root)
        {
            var stack = new Stack<TreeNode>();
            var list = new List<int>();

            stack.Push(root);

            while (stack.Count > 0)
            {
                var currNode = stack.Pop();

                if (currNode.right != null) stack.Push(currNode.right);
                if (currNode.right == null && currNode.left == null)
                {
                    list.Add(currNode.val);
                    continue;
                }
                else
                {
                    currNode.right = null;
                    stack.Push(currNode);
                }
                if (currNode.left != null) stack.Push(currNode.left);
                currNode.left = null;
            }

            return list;
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