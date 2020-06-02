using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            //[1,2,3,4,5,6,7]
            //    [3,5]

            var root = new TreeNode(1)
            {
                left = new TreeNode(2)
                {
                    left = new TreeNode(4),
                    right = new TreeNode(5)
                },
                right = new TreeNode(3)
                {
                    left = new TreeNode(6),
                    right = new TreeNode(7)
                }
            };

            var to_delete = new int[] {3, 5};

            var actual = DelNodes(root, to_delete);

            var expected = new List<TreeNode>()
            {
              
                new TreeNode(6),
                new TreeNode(7),
                new TreeNode(1)
                {
                    left = new TreeNode(2)
                    {
                        left = new TreeNode(4)
                    }
                }
            };
             
            Assert.AreEqual(expected[0].val, actual[0].val);
            Assert.AreEqual(expected[1].val, actual[1].val);
            Assert.AreEqual(expected[2].val, actual[2].val);

        }

        [Test]
        public void Test2()
        {
            //[1,2,3,4,5,6,7]
            //    [3,5. 1]

            var root = new TreeNode(1)
            {
                left = new TreeNode(2)
                {
                    left = new TreeNode(4),
                    right = new TreeNode(5)
                },
                right = new TreeNode(3)
                {
                    left = new TreeNode(6),
                    right = new TreeNode(7)
                }
            };

            var to_delete = new int[] {3, 5, 1};

            var actual = DelNodes(root, to_delete);

            var expected = new List<TreeNode>()
            {
                
                new TreeNode(6),
                new TreeNode(7),
                new TreeNode(2)
                {
                    left = new TreeNode(4)
                }
            };
             
            Assert.AreEqual(expected[0].val, actual[0].val);
            Assert.AreEqual(expected[1].val, actual[1].val);
            Assert.AreEqual(expected[2].val, actual[2].val);

        }


        private HashSet<int> _toDelete;
        private List<TreeNode> _roots;
        public IList<TreeNode> DelNodes(TreeNode root, int[] to_delete)
        {
            if (root == null || to_delete.Length == 0) return root == null ? new List<TreeNode>() : new List<TreeNode>() { root };

            _toDelete = new HashSet<int>(to_delete); 

            _roots = new List<TreeNode>();

            root = Delete(root);
            if(root != null) _roots.Add(root);

            return _roots;
        }

        private TreeNode Delete(TreeNode node)
        {
            if (node == null) return null;

            node.left = Delete(node.left);
            node.right = Delete(node.right);

            if (!_toDelete.Contains(node.val)) return node;
            if(node.left != null) _roots.Add(node.left);
            if(node.right != null) _roots.Add(node.right);
            return null;
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