using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            var root = new TreeNode(4)
            {
                left = new TreeNode(2)
                {
                    left = new TreeNode(1),
                    right = new TreeNode(3)
                },
                right = new TreeNode(7)
            };

            var res = InsertIntoBST(root, 5);

            Assert.AreEqual(res.right.left.val, 5);
        }

        public TreeNode InsertIntoBST(TreeNode root, int val)
        {
            if (root == null) return null;

            if (root.val > val)
            {
                if (root.left == null)
                {
                    root.left = new TreeNode(val);
                }
                else
                {
                    InsertIntoBST(root.left, val);
                }
            }
            else
            {
                if (root.right == null)
                {
                    root.right = new TreeNode(val);
                }
                else
                {
                    InsertIntoBST(root.right, val);
                }
            }

            return root;
        }

        public class TreeNode
        {
            public TreeNode(int x) { val = x; }

            public int val;
            public TreeNode left;
            public TreeNode right;
        }
    }
}