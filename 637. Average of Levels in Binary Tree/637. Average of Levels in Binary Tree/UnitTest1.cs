using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            //[3,9,20,15,7]
            var root = new TreeNode(3)
            {
                left = new TreeNode(9)
                {
                    left = new TreeNode(15),
                    right = new TreeNode(7)
                },
                right = new TreeNode(20)
            };

            var actual = AverageOfLevels(root);
                //[3.00000,14.50000,11.00000]
            CollectionAssert.AreEqual(new List<double>(){ 3.00000, 14.50000, 11.00000 }, actual);
        }

        public IList<double> AverageOfLevels(TreeNode root)
        {
            var res = new List<double>();

            var q = new Queue<TreeNode>();
            q.Enqueue(root);

            while (q.Count != 0)
            {
                double avarage = 0;
                var l = q.Count;

                for (var i = 0; i < l; i++)
                {
                    var node = q.Dequeue();
                    avarage += node.val;
                    if (node.left != null) q.Enqueue(node.left);
                    if (node.right != null) q.Enqueue(node.right);
                }

                res.Add(avarage / l);
            }

            return res;
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