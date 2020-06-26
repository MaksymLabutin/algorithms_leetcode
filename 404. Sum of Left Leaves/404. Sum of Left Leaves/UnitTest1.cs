using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        [Test]
        public void Test1()
        {
            var actual = SumOfLeftLeaves(null);

            var expected = 0;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test2()
        {
            //[3,9,20,null,null,15,7]

            var root = new TreeNode(3)
            {
                left = new TreeNode(9),
                right = new TreeNode(20)
                {
                    left = new TreeNode(15),
                    right = new TreeNode(7)
                }
            };
            var actual = SumOfLeftLeaves(root);

            var expected = 24;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test3()
        {
            //[1,2,3,4,5]

            var root = new TreeNode(1)
            {
                left = new TreeNode(2)
                {
                    left = new TreeNode(4),
                    right = new TreeNode(5)
                },
                right = new TreeNode(3)

            };
            var actual = SumOfLeftLeaves(root);

            var expected = 4;
            Assert.AreEqual(expected, actual);
        }
 

        private int _res;

        public int SumOfLeftLeaves(TreeNode root)
        {
            _res = 0;
            if (root == null) return _res;

            Dfs(root,false);

            return _res;
        }

        private void Dfs(TreeNode node, bool isLeft)
        {
            if (node == null) return;

            if (isLeft && node.left == null && node.right == null) _res += node.val;

            Dfs(node.left, true);
            Dfs(node.right, false);
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