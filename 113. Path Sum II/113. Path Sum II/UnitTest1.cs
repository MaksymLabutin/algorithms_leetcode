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
            var root = new TreeNode(5)
            {
                left = new TreeNode(4)
                {
                    left = new TreeNode(11)
                    {
                        left = new TreeNode(7),
                        right = new TreeNode(2)
                    }
                },
                right = new TreeNode(8)
                {
                    left = new TreeNode(13),
                    right = new TreeNode(4)
                    {
                        left = new TreeNode(5),
                        right = new TreeNode(1)
                    }
                }
            };

            var sum = 22;

            var actual = PathSum(root, sum);

            var expected = new List<IList<int>>()
            {
                new List<int>(){5,4,11,2},
                new List<int>(){ 5, 8, 4, 5 }
            };

            CollectionAssert.AreEqual(expected, actual);
        }

        private List<IList<int>> _res = new List<IList<int>>();

        public IList<IList<int>> PathSum(TreeNode root, int sum)
        {
            _res = new List<IList<int>>();
            if (root == null) return _res;
            Visit(root, new List<int>(), sum);

            return _res;
        }

        private void Visit(TreeNode root, IList<int> thread, int sum)
        {
            if(root == null) return;

            sum -= root.val;
            thread.Add(root.val);
            if (sum <= 0 && root.left == null && root.right == null)
            {
                if(sum < 0) return;
                _res.Add(thread);
            }

            if (root.left != null && root.right != null)
            { 
                Visit(root.right, new List<int>(thread), sum);
                Visit(root.left, thread, sum);
            }
            else
            {
                Visit(root.left, thread, sum);
                Visit(root.right, thread, sum);
            }
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