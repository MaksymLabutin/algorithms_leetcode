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
                left = new TreeNode(1)
            };

            var actual = CountUnivalSubtrees(root);

            var expected = 2;

            Assert.AreEqual(expected, actual);
        }

        private int answer = 0;
        public int CountUnivalSubtrees(TreeNode root)
        {
            if (root == null) return answer;

            CountUnivalSubtrees(root, root.val);

            return answer;
        }

        private bool CountUnivalSubtrees(TreeNode node, int val)
        {
            if (node == null) return true;

            var l = CountUnivalSubtrees(node.left, node.val);
            var r = CountUnivalSubtrees(node.right, node.val);

            if (l && r) answer += 1;

            return l && r && val == node.val;
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