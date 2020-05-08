using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
         
        [Test]
        public void Test1()
        {
            var nums = new[] { 3, 2, 1, 6, 0, 5 };

            var actual = ConstructMaximumBinaryTree(nums);
            
            Assert.AreEqual(6, actual.val);
            Assert.AreEqual(3, actual.left.val);
            Assert.AreEqual(2, actual.left.right.val);
            Assert.Null(actual.left.right.left);
            Assert.AreEqual(1, actual.left.right.right.val);
            Assert.Null(actual.left.right.right.left);
            Assert.Null(actual.left.right.right.right);
            Assert.Null(actual.left.left);


            Assert.AreEqual(5, actual.right.val);
            Assert.Null(actual.right.right);
            Assert.AreEqual(0, actual.right.left.val);
            Assert.Null(actual.right.left.right);
            Assert.Null(actual.right.left.left);

        }

        public TreeNode ConstructMaximumBinaryTree(int[] nums)
        {

            if (nums.Length == 0) return null;
            return Visit(nums, 0, nums.Length - 1);
        }

        private TreeNode Visit(int[] nums, int l, int r)
        {
            if (l >= r) return new TreeNode(nums[l]);

            var position = GetMax(nums, l, r);

            var node = new TreeNode(nums[position]);

            if(position - 1 >= l) node.left = Visit(nums, l, position - 1);
            if(position + 1 <= r) node.right = Visit(nums, position + 1, r); 
            return node;

        }

        private int GetMax(int[] nums, int l, int r)
        {

            int i = l;
            int val = nums[l];

            while (l <= r)
            {

                if (val < nums[l])
                {
                    val = nums[l];
                    i = l;
                }

                l++;
            }

            return i;
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