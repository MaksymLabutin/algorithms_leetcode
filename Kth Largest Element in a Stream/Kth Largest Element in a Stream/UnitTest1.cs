using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        private KthLargest _kthLargest;

        [SetUp]
        public void Setup()
        {
            _kthLargest = new KthLargest(3, new int[] { 4, 5, 8, 2 });
        }

        [Test]
        public void Test1()
        {
            var res = _kthLargest.Add(3);
            Assert.AreEqual(4, res);

            var res2 = _kthLargest.Add(5);
            Assert.AreEqual(5, res2);

            var res3 = _kthLargest.Add(10);
            Assert.AreEqual(5, res3);

            var res4 = _kthLargest.Add(9);
            Assert.AreEqual(8, res4);

            var res5 = _kthLargest.Add(4);
            Assert.AreEqual(8, res5);
        } 
    }

    public class KthLargest
    {
        private TreeNode _root;
        private readonly int _k;

        public KthLargest(int k, int[] nums)
        {
            if(k > nums.Length) throw new Exception("Empty nums");

            _root = new TreeNode(nums[0]);
            _k = k;

            for (var index = 1; index < nums.Length; index++)
            {
                AddNode(nums[index]);
            }

        }

        public int Add(int val)
        {
            AddNode(val); 
            return FintKth(_k, _root).val;
        }

        private void AddNode(int val)
        {
            var tmp = _root;  
            while (true)
            {
                tmp.counter += 1;

                if (val > tmp.val)
                {
                    if (tmp.right != null)
                    {
                        tmp = tmp.right;
                        continue;
                    }
                    tmp.right = new TreeNode(val); 
                }
                else
                {
                    if (tmp.left != null)
                    {
                        tmp = tmp.left;
                        continue;
                    }
                    tmp.left = new TreeNode(val);
                } 
                break;
            }
             
        }

        private TreeNode FintKth(int k, TreeNode node)
        {
            if (node == null || k > node.counter) return null;

            var treeNode = FintKth(k, node.counter > k ? node.right : node.left);
             
            return treeNode ?? node;
        }
    }

    public class TreeNode
    {
        public int val;
        public int counter = 1;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
}