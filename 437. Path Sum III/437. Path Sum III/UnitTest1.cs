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


        private int _sum;
        private int _res;
        private HashSet<(TreeNode, int)> _visited;
        private HashSet<TreeNode> _visited2;

        public int PathSum(TreeNode root, int sum)
        {
            if (root == null) return 0;
            if (root.left == null && root.right == null) return root.val == sum ? 1 : 0;

            _res = 0;
            _sum = sum;
            _visited = new HashSet<(TreeNode, int)>();
            _visited2 = new HashSet<TreeNode>();
            Visit(root, 0);

            return _res;
        }


        private void Visit(TreeNode root, int currSum)
        {

            var sum = root.val + currSum;
            if (_visited.Contains((root, sum)) && root.val != _sum) return;
            _visited.Add((root, sum));

            if (sum == _sum) _res++;
            else if (root.val == _sum && !_visited2.Contains(root))
            {
                _visited2.Add(root);
                _res++;
            }

            if (root.left != null)
            {
                Visit(root.left, sum);
                Visit(root.left, root.val);
            }

            if (root.right != null)
            {
                Visit(root.right, sum);
                Visit(root.right, root.val);
            }
        }

        //private void Visit(TreeNode root, int currSum)
        //{

        //    var sum = root.val + currSum;

        //    //if (_visited.Contains((root, sum))) return;
        //    //_visited.Add((root, sum));

        //    if (sum == _sum && !_added.Contains(root))
        //    {
        //        _res++;
        //        _added.Add(root);
        //    }
        //    if (root.val == _sum && !_added.Contains(root))
        //    {
        //        _res++;
        //        _added.Add(root);
        //    }

        //    if (root.left != null)
        //    {
        //        Visit(root.left, root.val);
        //        Visit(root.left, sum);
        //    }

        //    if (root.right != null)
        //    {
        //        Visit(root.right, root.val);
        //        Visit(root.right, sum);
        //    }
        //}

        //private void Visit(TreeNode root, int currSum)
        //{

        //    var sum = root.val + currSum;

        //    if (_visited.Contains((root, sum))) return;
        //    _visited.Add((root, sum));

        //    if (sum == _sum) _res++;

        //    //if (root.val != 0)
        //    //{
        //    //    if (_visited.Contains((root, 0))) return;
        //    //    _visited.Add((root, 0));
        //    //}

        //    //if (root.left == null && root.right == null && root.val == _sum) _res++;
        //    if (root.val == _sum) _res++;

        //    if (root.left != null)
        //    {
        //        Visit(root.left, root.val);
        //        Visit(root.left, sum);
        //    }

        //    if (root.right != null)
        //    {
        //        Visit(root.right, root.val);
        //        Visit(root.right, sum);
        //    }
        //}

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