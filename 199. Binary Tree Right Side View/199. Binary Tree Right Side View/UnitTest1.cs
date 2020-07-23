using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        [Test]
        public void Test1()
        {
            //1,2,3,null,5,null,4
            var node = new TreeNode(1)
            {
                left = new TreeNode(2)
                {
                    right = new TreeNode(5)
                },
                right = new TreeNode(3)
                {
                    right = new TreeNode(4)
                }
            };

            var actual = RightSideView(node);

            var expected = new List<int> {1, 3, 4};

            CollectionAssert.AreEqual(expected, actual);
        }

        public IList<int> RightSideView(TreeNode root)
        {
            if(root == null) return new List<int>();

            var q = new Queue<TreeNode>();
            q.Enqueue(root);

            var res = new List<int>();
            while (q.Count > 0)
            {
                TreeNode node = null;

                var size = q.Count;
                for (var i = 0; i < size; i++)
                {
                    node = q.Dequeue();

                    if (node.left != null) q.Enqueue(node.left);
                    if (node.right != null) q.Enqueue(node.right);
                }

                if(node != null) res.Add(node.val);
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