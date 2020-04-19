using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        [SetUp]
        public void SetUp()
        {
            _val = 0;
            _h = -1;
        }

        [Test]
        public void Test1()
        {
            var root = new TreeNode(2)
            {
                left = new TreeNode(1),
                right = new TreeNode(3)
            };

            var actual = FindBottomLeftValue(root);

            var expected = 1;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test2()
        {
            var root = new TreeNode(1)
            {
                left = new TreeNode(3)
                {
                    left = new TreeNode(4)
                },
                right = new TreeNode(3)
                {
                    left = new TreeNode(5)
                    {
                        left = new TreeNode(7)
                    },
                    right = new TreeNode(6)
                  
                }
            };

            var actual = FindBottomLeftValue(root);

            var expected = 7;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test3()
        {
            var root = new TreeNode(2);

            var actual = FindBottomLeftValue(root);

            var expected = 2;
            Assert.AreEqual(expected, actual);
        }

        private int _val; 
        private int _h = -1;

        public int FindBottomLeftValue(TreeNode root)
        {
            Visit(root, 0);
            return _val;
        }

        private void Visit(TreeNode node, int h)
        {
            if (node == null) return;

            if (node.left == null && node.right == null && h > _h)
            {
                _h = h;
                _val = node.val;
                return;
            }

            h++;
            Visit(node.left, h);
            Visit(node.right, h); 
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