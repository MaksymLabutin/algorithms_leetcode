using System.Runtime.Serialization.Formatters;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        private TreeNode _root;

        [SetUp]
        public void SetUp()
        {

            _root = new TreeNode(3)
            {
                left = new TreeNode(5)
                {
                    left = new TreeNode(6),
                    right = new TreeNode(2)
                    {
                        left = new TreeNode(7),
                        right = new TreeNode(4)
                    }
                },
                right = new TreeNode(1)
                {
                    left = new TreeNode(0),
                    right = new TreeNode(8)
                }
            };
        }


        [Test]
        public void Test1()
        {
            var p = new TreeNode(1);
            var q = new TreeNode(1);

            var res = LowestCommonAncestor(_root, p, q);

            Assert.AreEqual(1, res.val);
        }

        [Test]
        public void Test2()
        {
            var p = new TreeNode(4);
            var q = new TreeNode(6);

            var res = LowestCommonAncestor(_root, p, q);

            Assert.AreEqual(5, res.val);
        }

        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null) return null;

            var left = LowestCommonAncestor(root.left, p, q);
            var right = LowestCommonAncestor(root.right, p, q);

            if (left != null && right != null) return root;

            if (root.val == p.val || root.val == q.val) return root;

            if (left != null) return left;
            return right ?? null;
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