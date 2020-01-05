using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        

        [Test]
        public void IsTrue_1()
        {
            var tree1 = new TreeNode(1)
            {
                left = new TreeNode(2),
                right = new TreeNode(3)
            };

            var tree2 = new TreeNode(1)
            {
                left = new TreeNode(2),
                right = new TreeNode(3)
            };

            var res = IsSameTree(tree2, tree1);

            Assert.IsTrue(res);
        }

        [Test]
        public void IsFalse_1()
        {
            var tree1 = new TreeNode(1)
            {
                left = new TreeNode(2)
            };

            var tree2 = new TreeNode(1)
            {
                right = new TreeNode(2)
            };

            var res = IsSameTree(tree2, tree1);

            Assert.IsFalse(res);
        }

        [Test]
        public void IsFalse_2()
        {
            var tree1 = new TreeNode(1)
            {
                left = new TreeNode(2),
                right = new TreeNode(3)
            };

            var tree2 = new TreeNode(1)
            {
                left = new TreeNode(3),
                right = new TreeNode(2)
            };

            var res = IsSameTree(tree2, tree1);

            Assert.IsFalse(res);
        }


        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null || q == null) return p == q;
            return p.val == q.val && IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
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