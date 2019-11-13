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
                left = new TreeNode(2)
                {
                    left = new TreeNode(3),
                    right = new TreeNode(4)
                },
                right = new TreeNode(2)
                {
                    left = new TreeNode(4),
                    right = new TreeNode(3)
                }
            };

            var res = IsSymmetric(nodes);

            Assert.IsTrue(res);
        }

        [Test]
        public void Test2()
        {
            var nodes = new TreeNode(3)
            {
                left = new TreeNode(2)
                {
                    right = new TreeNode(4)
                },
                right = new TreeNode(2)
                {
                    right = new TreeNode(4)
                }
            };

            var res = IsSymmetric(nodes);

            Assert.IsFalse(res);
        }

        public bool IsSymmetric(TreeNode root)
        {
            return IsMirror(root, root);
        }


        private bool IsMirror(TreeNode rNode, TreeNode lNode)
        {
            if (lNode == null && rNode == null) return true;
            if (lNode == null || rNode == null) return false;

            return rNode.val == lNode.val && IsMirror(lNode.left, rNode.right) && IsMirror(lNode.right, rNode.left);
        }


        //old
        //public bool IsSymmetric(TreeNode root)
        //{
        //    if (root == null) return true;

        //    var map = new Dictionary<int, List<int?>>();

        //    Visit(root, map, 0);

        //    for (var i = 1; i < map.Count - 1; i++)
        //    {
        //        for (var j = 0; j < map[i].Count / 2; j++)
        //        {
        //            if (map[i].ElementAt(j) != map[i].ElementAt(map[i].Count - 1 - j)) return false;
        //        }
        //    }

        //    return true;
        //}

        //public void Visit(TreeNode node, Dictionary<int, List<int?>> map, int level)
        //{ 
        //    if (map.ContainsKey(level))
        //    {
        //        map[level].Add(node?.val);
        //    }
        //    else
        //    {
        //        map.Add(level, new List<int?>() { node?.val });
        //    }

        //    if (node == null) return;

        //    Visit(node.left, map, level + 1);
        //    Visit(node.right, map, level + 1);

        //}

        public class TreeNode
        {
            public TreeNode(int x) { val = x; }

            public int val;
            public TreeNode left;
            public TreeNode right;
        }
    }
}