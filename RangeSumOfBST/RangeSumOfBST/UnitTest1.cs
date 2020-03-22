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
            var root = new TreeNode(10)
            {
                left = new TreeNode(5)
                {
                    left = new TreeNode(3),
                    right = new TreeNode(7)
                },
                right = new TreeNode(15)
                {
                    right = new TreeNode(18)
                }
            };

            int L = 7, R = 15;

            var res = RangeSumBST(root, L, R);

            var expectedRes = 32;

            Assert.AreEqual(expectedRes, res);
        }


        [Test]
        public void Test2()
        {

            //10,5,15,3,7,13,18,1,null,6
            var root = new TreeNode(10)
            {
                left = new TreeNode(5)
                {
                    left = new TreeNode(3)
                    {
                        left = new TreeNode(1)
                    },
                    right = new TreeNode(7)
                    {
                        left = new TreeNode(6)
                    }
                },
                right = new TreeNode(15)
                {
                    left = new TreeNode(13),
                    right = new TreeNode(18)
                }
            };

            int L = 6, R = 10;

            var res = RangeSumBST(root, L, R);

            var expectedRes = 23;

            Assert.AreEqual(expectedRes, res);
        }

        private int answer = 0;

        public int RangeSumBST(TreeNode root, int L, int R)
        {
            answer = 0;
            Visit(root, L, R);
            return answer;
        }

        private void Visit(TreeNode node, int L, int R)
        {
            if (node == null) return;
             
            if (L <= node.val && node.val <= R) answer += node.val;
            if (node.val < R) Visit(node.right, L, R);
            if (L < node.val) Visit(node.left, L, R);
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