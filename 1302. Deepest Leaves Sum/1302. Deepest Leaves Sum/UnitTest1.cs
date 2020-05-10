using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {


        [Test]
        public void Test1()
        {
            var root = new TreeNode(1)
            {
                right = new TreeNode(2),
                left = new TreeNode(3)
            };

            var actual = DeepestLeavesSum(root);

            var expected = 5;
            Assert.AreEqual(expected, actual);
        }

        public int DeepestLeavesSum(TreeNode root)
        {
            if (root == null) return 0;

            var q = new Queue<TreeNode>();
            q.Enqueue(root);

            var sum = root.val;

            while (q.Count > 0)
            {
                var size = q.Count;
                sum = 0;
                while (size != 0)
                {
                    var node = q.Dequeue();

                    sum += node.val;
                    if(node.left != null) q.Enqueue(node.left);
                    if(node.right != null) q.Enqueue(node.right);

                    size--;
                }
            }


            return sum;
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