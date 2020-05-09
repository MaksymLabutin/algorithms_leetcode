using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        [Test]
        public void Test1()
        {
            //[1,1,1,1,1,null,1]
            var root = new TreeNode(1)
            {
                left = new TreeNode(1)
                {
                    left = new TreeNode(1),
                    right = new TreeNode(1)
                },
                right = new TreeNode(1)
                {
                    right = new TreeNode(1)
                }
            };

            var actual = IsUnivalTree(root);
            Assert.True(actual);
        }



        public bool IsUnivalTree(TreeNode root)
        {
            if (root == null) return true;

            if (root.left != null && root.val != root.left.val) return false;
            if (root.right != null && root.val != root.right.val) return false;

            return IsUnivalTree(root.left) &&
                   IsUnivalTree(root.right);

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