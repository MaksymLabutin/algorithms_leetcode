using NUnit.Framework;

namespace Tests
{
    public class Tests
    {


        [Test]
        public void Test1()
        {
            //1,null,0,0,1
            var root = new TreeNode(1)
            { 
                right = new TreeNode(0)
                {
                    left = new TreeNode(0),
                    right = new TreeNode(1)
                }
            };

            var actual = PruneTree(root);


            Assert.NotNull(actual);
            Assert.NotNull(actual.right);
            Assert.Null(actual.right.left);
            Assert.NotNull(actual.right.right);
        }

        public TreeNode PruneTree(TreeNode root)
        {
            if (root == null) return null;

            root.left = PruneTree(root.left);
            root.right = PruneTree(root.right);

            return root.val == 0 && root.left == null && root.right == null ? null : root;
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