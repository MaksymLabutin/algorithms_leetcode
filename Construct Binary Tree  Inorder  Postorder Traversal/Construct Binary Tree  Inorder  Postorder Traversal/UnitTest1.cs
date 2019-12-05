using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var inorder = new int[] { 9, 3, 15, 20, 7 };
            var postorder = new int[] { 9, 15, 7, 20, 3 };

            var node = BuildTree(inorder, postorder);

            Assert.IsTrue(true);
        }
          
        // answer [1,null,2,3,4,5,6,7,null,8,9,11,12,13]

        [Test]
        public void Test2()
        {
            var inorder = new int[] { 1, 8, 5, 9, 3, 11, 6, 12, 2, 13, 7, 4 };
            var postorder = new int[] { 8, 9, 5, 11, 12, 6, 3, 13, 7, 4, 2, 1 };

            var node = BuildTree(inorder, postorder);

            Assert.IsTrue(true);
        }

        //answer [1,2,3,4,5,6,7,null,8,9,11,12,13]
        [Test]
        public void Test3()
        {
            var inorder = new int[] { 4, 8, 2, 9, 5, 11, 1, 12, 6, 13, 3, 7 };
            var postorder = new int[] { 8, 4, 9, 11, 5, 2, 12, 13, 6, 7, 3, 1 };

            var node = BuildTree(inorder, postorder);

            Assert.IsTrue(true);
        }


        private Dictionary<int, int> map; 
        private int _rigthPos;

        public TreeNode BuildTree(int[] inorder, int[] postorder)
        {
            if (postorder.Length == 0) return null;
             
            _rigthPos = postorder.Length - 1;
            map = new Dictionary<int, int>();

            for (var i = 0; i < inorder.Length; i++)
            {
                map.Add(inorder[i], i);
            }

            var root = Visit(postorder, 0, postorder.Length - 1);

            return root;
        }

        public TreeNode Visit(int[] postorder, int iLeft, int iRight)
        {
            if (iLeft > iRight) return null;

            var val = postorder[_rigthPos];

            var node = new TreeNode(val);

            var index = map[val];

            _rigthPos--;

            node.right = Visit(postorder, index + 1, iRight);

            node.left = Visit(postorder, iLeft, index - 1);

            return node;
        }



        //public TreeNode BuildTree(int[] inorder, int[] postorder)
        //{
        //    if (postorder.Length == 0) return null;

        //    var node = new TreeNode(postorder[postorder.Length - 1]);

        //    var index = inorder.ToList().IndexOf(postorder[postorder.Length - 1]);

        //    if (index > 0)
        //    { 
        //        node.left = BuildTree(inorder.Take(index).ToArray(),
        //            postorder.Take(index).ToArray());
        //    }

        //    if (index + 1 < inorder.Length)
        //    {
        //        node.right = BuildTree(inorder.TakeLast(inorder.Length - index - 1).ToArray(), postorder.Skip(index).Take(inorder.Length - index - 1).ToArray());
        //    }

        //    return node;
        //}




        private int GetPostion(int[] arr, int val)
        {
            return arr.ToList().IndexOf(val);
        }

        public class TreeNode
        {
            public TreeNode(int x) { val = x; }

            public int val;
            public TreeNode left;
            public TreeNode right;
        }
    }
}