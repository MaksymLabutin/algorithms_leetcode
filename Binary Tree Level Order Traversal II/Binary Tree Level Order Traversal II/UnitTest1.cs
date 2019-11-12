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

            var res = LevelOrderBottom(nodes);

            CollectionAssert.AreEqual(res, new List<List<int>>
            {
                new List<int>(){15,7},
                new List<int>(){9,20},
                new List<int>(){3},
            });
        }

        public IList<IList<int>> LevelOrderBottom(TreeNode root)
        {
            var list = new List<IList<int>>();

            if (root == null) return list;

            var map = new Dictionary<int, List<int>>();

            Visit(root, map, 0);

            foreach (var vals in map.Values)
            {
                list.Insert(0, vals);
            }

            return list;
        }

        public void Visit(TreeNode node, Dictionary<int, List<int>> map, int level)
        {
            if (map.ContainsKey(level))
            {
                map[level].Add(node.val);
            }
            else
            {
                map.Add(level, new List<int>() { node.val });
            }

            if (node.left != null)
            {
                Visit(node.left, map, level + 1);
            }

            if (node.right != null)
            {
                Visit(node.right, map, level + 1);
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
}