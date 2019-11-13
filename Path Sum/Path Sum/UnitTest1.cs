using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {

            var nodes = new TreeNode(5)
            {
                left = new TreeNode(4)
                {
                    left = new TreeNode(11)
                    {
                        left = new TreeNode(7),
                        right = new TreeNode(2)
                    }
                },
                right = new TreeNode(8)
                {
                    left = new TreeNode(13),
                    right = new TreeNode(4)
                    {
                        right = new TreeNode(1)
                    }
                }
            };

            var res = HasPathSum(nodes, 22);
            Assert.IsTrue(res);
        }
   [Test]
        public void Test2()
        {

            var nodes = new TreeNode(5)
            {
                left = new TreeNode(4)
                {
                    left = new TreeNode(11)
                    {
                        left = new TreeNode(7), 
                    }
                },
                right = new TreeNode(8)
                {
                    left = new TreeNode(13),
                    right = new TreeNode(4)
                    {
                        right = new TreeNode(1)
                    }
                }
            };

            var res = HasPathSum(nodes, 22);
            Assert.IsFalse(res);
        }

        public bool HasPathSum(TreeNode root, int sum)
        {

            if (root == null) return false;
             
            sum -= root.val;
            if (root.left == null && root.right == null) return sum == 0;

            return HasPathSum(root.left, sum) || HasPathSum(root.right, sum);
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