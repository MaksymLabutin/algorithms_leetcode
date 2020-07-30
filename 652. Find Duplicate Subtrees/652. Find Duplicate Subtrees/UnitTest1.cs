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
            _res = new List<TreeNode>();
            _schema = new Dictionary<string, TreeNode>();
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

            Assert.AreEqual(2, actual[1].val);
            Assert.AreEqual(4, actual[0].val);
        }


        [Test]
        public void Test2()
        {
            var root = new TreeNode(0)
            {
                left = new TreeNode(0)
                {
                    left = new TreeNode(0)
                },
                right = new TreeNode(0)
                {
                    right = new TreeNode(0)
                    {
                        right = new TreeNode(0)
                    }
                }
            };

            var actual = FindDuplicateSubtrees(root);

            Assert.AreEqual(0, actual[0].val);
            Assert.AreEqual(1, actual.Count);
        }

        private List<TreeNode> _res = new List<TreeNode>();
        private Dictionary<string, TreeNode> _schema = new Dictionary<string, TreeNode>();

        public IList<TreeNode> FindDuplicateSubtrees(TreeNode root)
        {
            if (root == null) return new List<TreeNode>();

            Dfs(root);

            return _res.Distinct().ToList();
        }

        private string Dfs(TreeNode node)
        {
            if (node == null) return "null";

            var l = Dfs(node.left);
            var r = Dfs(node.right);

            var schema = $"{node.val} {l} {r}";

            if (_schema.ContainsKey(schema)) _res.Add(_schema[schema]);
            else _schema.Add(schema, node);

            return schema;
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