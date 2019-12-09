using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        private TreeNode _root;

        [SetUp]
        public void Setup()
        {
            _root= new TreeNode(4)
            {
                left = new TreeNode(2)
                {
                    left = new TreeNode(1),
                    right = new TreeNode(3)
                },
                right = new TreeNode(7)
            };
        }

        [Test]
        public void Test1()
        {
            var val = 2;

            var res = SearchBST(_root, val);

            Assert.AreEqual(val, res.val);
        }

        [Test]
        public void Test2()
        {
            var val = 5;

            var res = SearchBST(_root, val);

            Assert.IsNull(res);
        }

        public TreeNode SearchBST(TreeNode root, int val)
        {
            if (root == null) return null;
            if (root.val == val) return root; 

            if (root.val > val)
            {
                return SearchBST(root.left, val); 
            }else
            {
                return SearchBST(root.right, val); 
            } 
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