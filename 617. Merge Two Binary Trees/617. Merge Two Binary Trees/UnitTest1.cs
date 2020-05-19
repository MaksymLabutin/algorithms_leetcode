using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        [Test]
        public void Test1()
        {
            //[1,3,2,5]
            //    [2,1,3,null,4,null,7]
            var t1 = new TreeNode(1)
            {
                left = new TreeNode(3)
                {
                    left = new TreeNode(5)
                },
                right = new TreeNode(2)
            };
            var t2 = new TreeNode(2)
            {
                left = new TreeNode(1)
                {
                    right = new TreeNode(4)
                },
                right = new TreeNode(3)
                {
                    right = new TreeNode(7)
                }
            };

            var actual = MergeTrees(t1, t2);

            Assert.AreEqual(3, actual.val);
            Assert.AreEqual(4, actual.left.val);
            Assert.AreEqual(5, actual.left.left.val);
            Assert.AreEqual(4, actual.left.right.val);


            Assert.AreEqual(5, actual.right.val);
            Assert.AreEqual(7, actual.right.right.val);

        }

        public TreeNode MergeTrees(TreeNode t1, TreeNode t2)
        {
            if (t1 == null) return t2;
            return t2 == null 
                ? t1 
                : new TreeNode(t1.val + t2.val) { left = MergeTrees(t1.left, t2.left), right = MergeTrees(t1.right, t2.right) };
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