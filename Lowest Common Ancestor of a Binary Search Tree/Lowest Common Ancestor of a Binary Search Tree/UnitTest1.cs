using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        private TreeNode root;

        [SetUp]
        public void SetUp()
        {

            root = new TreeNode(6)
            {
                left = new TreeNode(2)
                {
                    left = new TreeNode(0),
                    right = new TreeNode(4)
                    {
                        left = new TreeNode(3),
                        right = new TreeNode(5)
                    }
                },
                right = new TreeNode(8)
                {
                    left = new TreeNode(7),
                    right = new TreeNode(9)
                }
            };

        }

        [Test]
        public void Test1()
        {
            var p = new TreeNode(2);
            var q = new TreeNode(8);

            var ancestorNode = LowestCommonAncestor(root, q, p);

            Assert.Pass();
        }

        [Test]
        public void Test2()
        {
            
            var p = new TreeNode(5);
            var q = new TreeNode(4);

            var ancestorNode = LowestCommonAncestor(root, q, p);

            Assert.Pass();
        }


        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null) return null;
            if (root.val <= q.val && root.val >= p.val || root.val >= q.val && root.val <= p.val) return root;
             
            return root.val < q.val ? LowestCommonAncestor(root.right, p, q) : LowestCommonAncestor(root.left, p, q);
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