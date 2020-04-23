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
                left = new TreeNode(3)
                {
                    left = new TreeNode(5),
                    right = new TreeNode(4)
                },
                right = new TreeNode(2)
                {
                    right = new TreeNode(9)
                }
            };

            var actual = LargestValues(root);

            var expected = new List<int>() {1, 3, 9};
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void Test2()
        {

            var root = new TreeNode(1)
            {
                left = new TreeNode(3)
                {
                    left = new TreeNode(5),
                    right = new TreeNode(4)
                },
                right = new TreeNode(2)
                {
                    right = new TreeNode(9)
                    {
                        left = new TreeNode(10)
                    }
                }
            };

            var actual = LargestValues(root);

            var expected = new List<int>() {1, 3, 9, 10};
            CollectionAssert.AreEqual(expected, actual);
        }

        public IList<int> LargestValues(TreeNode root)
        {
            var res = new List<int>();

            if (root == null) return res;

            var q = new Queue<TreeNode>();
            q.Enqueue(root);

            while (q.Count > 0)
            {
                var size = q.Count;

                var max = int.MinValue;

                for (var i = 0; i < size; i++)
                {
                    var node = q.Dequeue();

                    if (max < node.val) max = node.val;

                    if(node.left != null) q.Enqueue(node.left);
                    if(node.right != null) q.Enqueue(node.right);
                }

                res.Add(max);
            }

            return res;
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