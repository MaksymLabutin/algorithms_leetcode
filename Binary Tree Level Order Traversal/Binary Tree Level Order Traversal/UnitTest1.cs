using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        [Test]
        public void Test1()
        {
            var nodes = new TreeNode(3)
            {
                left = new TreeNode(9),
                right = new TreeNode(20)
                {
                    left = new TreeNode(15),
                    right = new TreeNode(7)
                }
            };

            var res = LevelOrder(nodes);

            CollectionAssert.AreEqual(res, new List<List<int>>
            {
                new List<int>(){3},
                new List<int>(){9,20},
                new List<int>(){15,7},
            });
        }

        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            var list = new List<IList<int>>();
            if (root == null) return list;

            var stack = new Stack<(int level, TreeNode node)>();

            stack.Push((0, root));

            while (stack.Count > 0)
            {
                var currentNode = stack.Pop();

                if (list.Count <= currentNode.level)
                {
                    list.Add(new List<int>());
                }

                list[currentNode.level].Add(currentNode.node.val);

                if (currentNode.node.right != null)
                {
                    stack.Push((currentNode.level + 1, currentNode.node.right));
                }

                if (currentNode.node.left != null)
                {
                    stack.Push((currentNode.level + 1, currentNode.node.left));
                }
            }

            return list;
        }

        public class TreeNode
        {
            public TreeNode(int x) { val = x; }

            public int val;
            public TreeNode left;
            public TreeNode right;
        }
    }
}