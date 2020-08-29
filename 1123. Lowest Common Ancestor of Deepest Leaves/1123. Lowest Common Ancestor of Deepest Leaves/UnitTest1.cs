using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        [Test]
        public void Test1()
        {
            var root = new TreeNode(1)
            {
                left = new TreeNode(2),
                right = new TreeNode(3)
            };

            var actual = LcaDeepestLeaves(root);

            Assert.AreEqual(1, actual.val);
        }

        [Test]
        public void Test2()
        {
            var root = new TreeNode(1)
            {
                left = new TreeNode(2),
                right = new TreeNode(3)
                {
                    left = new TreeNode(4)
                }
            };

            var actual = LcaDeepestLeaves(root);

            Assert.AreEqual(4, actual.val);
        }

        public TreeNode LcaDeepestLeaves(TreeNode root)
        {
            return LcaDeepestLeaves(root, 0).node;
        }

        private (TreeNode node, int d) LcaDeepestLeaves(TreeNode node, int d)
        {
            if (node == null) return (null, d);

            var l = LcaDeepestLeaves(node.left, d + 1);
            var r = LcaDeepestLeaves(node.right, d + 1);

            if (l.node != null && r.node != null)
            {
                if (r.d == l.d) return(node, l.d);

                return l.d > r.d ? l : r;
            }
            if (l.node == null && r.node == null) return (node, d);

            return l.node != null ? l : r;
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