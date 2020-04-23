using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    { 

        [Test]
        public void Test1()
        {
            var root = new TreeNode(3)
            {
                left = new TreeNode(9),
                right = new TreeNode(20)
                {
                    left = new TreeNode(15),
                    right = new TreeNode(7)
                }

            };

            var actual = ZigzagLevelOrder(root);

            var expected = new List<List<int>>()
            {
                new List<int>() {3},
                new List<int>() {20, 9},
                new List<int>() {15, 7},
            };


            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void Test2()
        {
            var root = new TreeNode(1)
            {
                left = new TreeNode(2)
                {
                    left = new TreeNode(4)
                },
                right = new TreeNode(3)
                {
                   right = new TreeNode(5)
                }

            };

            var actual = ZigzagLevelOrder(root);

            var expected = new List<List<int>>()
            {
                new List<int>() {1},
                new List<int>() {3, 2},
                new List<int>() {4, 5},
            };


            CollectionAssert.AreEqual(expected, actual);
        }

        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            var res = new List<IList<int>>();

            if (root == null) return res;
              
            var q = new Queue<TreeNode>();
            var isLeft = true;

            q.Enqueue(root);

            while (q.Count > 0)
            {
                var size = q.Count;
                var arr = new int[size];

                for (var i = 0; i < size; i++)
                {
                    var node = q.Dequeue();

                    if (isLeft) arr[i] = node.val;
                    else arr[size - i - 1] = node.val;

                    if (node.left != null) q.Enqueue(node.left);
                    if (node.right != null) q.Enqueue(node.right);

                }

                isLeft = !isLeft;
                res.Add(arr.ToList());
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