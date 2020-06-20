using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            var root = new TreeNode(10)
            {
                left = new TreeNode(5)
                {
                    left = new TreeNode(3)
                    {
                        left = new TreeNode(3),
                        right = new TreeNode(-2)
                    },
                    right = new TreeNode(2)
                    {
                        right = new TreeNode(1)
                    }

                },
                right = new TreeNode(-3)
                {
                    right = new TreeNode(11)
                }
            };

            var actual = PathSum(root, 8);

            var expected = 3;

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Test2()
        {
            var root = new TreeNode(1)
            {
                right = new TreeNode(2)
                {
                    right = new TreeNode(3)
                    {
                        right = new TreeNode(4)
                        {
                            right = new TreeNode(5)
                        }
                    }
                }
            };

            var actual = PathSum(root, 3);

            var expected = 2;

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Test3()
        {
            var root = new TreeNode(0)
            {
                right = new TreeNode(1),
                left = new TreeNode(1)
            };

            var actual = PathSum(root, 1);

            var expected = 4;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test4()
        {
            var root = new TreeNode(1)
            {
                right = new TreeNode(2)
            };

            var actual = PathSum(root, 2);

            var expected = 1;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test5()
        {
            //[5,4,8,11,null,13,4,7,2,null,null,5,1]

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

            var actual = PathSum(root, 22);

            var expected = 3;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test6()
        {
            var root = new TreeNode(1)
            {
                left = new TreeNode(2)
            };

            var actual = PathSum(root, 1);

            var expected = 1;

            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void Test7()
        {
            //[1,-2,-3,1,3,-2,null,-1]

            var root = new TreeNode(1)
            {
                left = new TreeNode(-2)
                {
                    left = new TreeNode(1)
                    {
                        left = new TreeNode(-1)
                    },
                    right = new TreeNode(3)
                },
                right = new TreeNode(-3)
                {
                    left = new TreeNode(2)
                }
            };

            var actual = PathSum(root, 1);

            var expected = 3;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test8()
        {
            //[1,0,1,1,2,0,-1,0,1,-1,0,-1,0,1,0]


            var root = new TreeNode(1)
            {
                left = new TreeNode(0)
                {
                    left = new TreeNode(1)
                    {
                        left = new TreeNode(1),
                        right = new TreeNode(0)
                    },
                    right = new TreeNode(2)
                    {
                        left = new TreeNode(0),
                        right = new TreeNode(-1)
                    }
                },
                right = new TreeNode(1)
                {
                    left = new TreeNode(0)
                    {
                        left = new TreeNode(0),
                        right = new TreeNode(-1)
                    },
                    right = new TreeNode(-1)
                    {
                        left = new TreeNode(0),
                        right = new TreeNode(1)
                    }
                }
            };

            var actual = PathSum(root, 2);

            var expected =
                13;

            Assert.AreEqual(expected, actual);
        }


        private int _res;
        public int PathSum(TreeNode root, int sum)
        { 
            if (root == null) return 0;
            _res = 0;
            SumPath(root, sum, new List<int>()); 
            return _res;
        }
         
        private void SumPath(TreeNode node, int sum, List<int> vals)
        { 
            if (node == null) return;

            vals.Add(node.val);

            SumPath(node.left, sum, vals);
            SumPath(node.right, sum, vals);

            var curSum = 0;

            for (var i = vals.Count - 1; i >= 0; i--)
            {
                curSum += vals[i];
                if (curSum == sum) _res++;
            }

            vals.RemoveAt(vals.Count - 1);

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