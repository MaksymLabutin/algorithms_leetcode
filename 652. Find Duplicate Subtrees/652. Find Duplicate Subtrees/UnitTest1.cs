using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            _trees = new Dictionary<int, List<TreeNode>>();
            _res = new List<TreeNode>();
        }

        [Test]
        public void Test1()
        {
            //[1,2,3,4,null,2,4,null,null,4]

            var root = new TreeNode(1)
            {
                left = new TreeNode(2)
                {
                    left = new TreeNode(4)
                },
                right = new TreeNode(3)
                {
                    left = new TreeNode(2)
                    {
                        left = new TreeNode(4)
                    },
                    right = new TreeNode(4)
                }
            };

            var actual = FindDuplicateSubtrees(root);

            Assert.AreEqual(2, actual[0].val);
            Assert.AreEqual(4, actual[1].val);
        }

        private Dictionary<int, List<TreeNode>> _trees = new Dictionary<int, List<TreeNode>>();
        private List<TreeNode> _res = new List<TreeNode>();
        public IList<TreeNode> FindDuplicateSubtrees(TreeNode root)
        {
            if (root == null) return null;

            if (_trees.ContainsKey(root.val))
            {
                var hasAny = false;
                foreach (var node in _trees[root.val])
                {
                    hasAny = HasSameStructure(root, node);
                    if (!hasAny) continue;
                    _res.Add(node);
                    break;
                }
                 
                if(!hasAny)
                {
                    _trees[root.val].Add(root);
                }
            }
            else
            {
                _trees.Add(root.val, new List<TreeNode>() { root });
            }

            FindDuplicateSubtrees(root.left);
            FindDuplicateSubtrees(root.right);
            return _res.Distinct().ToList();
        }

        public bool HasSameStructure(TreeNode node1, TreeNode node2)
        {
            if (node1 == null || node2 == null) return node1 == null && node2 == null;

            return node2.val == node1.val && HasSameStructure(node2.left, node1.left) && HasSameStructure(node2.right, node1.right);
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