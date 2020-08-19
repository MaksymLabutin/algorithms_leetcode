using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void SetUp()
        {
            _graph = null;
        }

        [Test]
        public void Test1()
        {
            //[[1,0]] 
            var prerequisites = new int[][] { new[] { 1, 0 } };
            var numCourses = 2;
            var actual = FindOrder(numCourses, prerequisites);

            var expected = new[] { 0, 1 };
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void Test2()
        {
            var prerequisites = new int[][] { new[] { 1, 0 }, new[] { 2, 0 }, new[] { 3, 1 }, new[] { 3, 2 } };
            var numCourses = 4;
            var actual = FindOrder(numCourses, prerequisites);

            var expected = new[] { 0, 1, 2, 3 };
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void Test3()
        {
            var prerequisites = new int[][] { new[] { 1, 0 }, new[] { 2, 0 }, new[] { 3, 1 }, new[] { 3, 2 } };
            var numCourses = 6;
            var actual = FindOrder(numCourses, prerequisites);

            var expected = new[] { 0,1,2,3,4,5 };
            CollectionAssert.AreEqual(expected, actual);
        }


        [Test]
        public void Test4()
        {
            var prerequisites = new int[][] { new[] { 0, 1 }, new[] { 1, 0 } };
            var numCourses = 2;
            var actual = FindOrder(numCourses, prerequisites);

            CollectionAssert.IsEmpty(actual);
        }

        //[[1,0],[2,3],[3,1],[3,2]]
        [Test]
        public void Test5()
        {
            var prerequisites = new int[][] { new[] { 0, 1 }, new[] { 2, 3 }, new[] { 3, 1 }, new[] { 3, 2 } };
            var numCourses = 6;
            var actual = FindOrder(numCourses, prerequisites);

            CollectionAssert.IsEmpty(actual);
        }
         
        [Test]
        public void Test6()
        {
            var prerequisites = new int[][] { new[] { 0, 1 } };
            var numCourses = 2;
            var actual = FindOrder(numCourses, prerequisites);

            var expected = new[] { 1,0};
            CollectionAssert.AreEqual(expected, actual);
        }
         
        [Test]
        public void Test7()
        {
            var prerequisites = new int[][] { new[] { 1,0 }, new []{2,0} };
            var numCourses = 3;
            var actual = FindOrder(numCourses, prerequisites);

            var expected = new[] { 0,1,2};
            CollectionAssert.AreEqual(expected, actual);
        }

         
        [Test]
        public void Test8()
        {
            var prerequisites = new int[][] { new[] { 1,0 }, new []{0,2} , new []{2,1} };
            var numCourses = 3;
            var actual = FindOrder(numCourses, prerequisites);

            CollectionAssert.IsEmpty(actual);
        }

        //7
        //[[1,0],[0,3],[0,2],[3,2],[2,5],[4,5],[5,6],[2,4]]
        [Test]
        public void Test9()
        {
            var prerequisites = new int[][] { new[] { 1,0 }, new []{0,3} , new []{ 0, 2 }, new []{ 3, 2 }, new []{ 2, 5 }, new []{ 4, 5 }, new []{ 5, 6 }, new []{ 2, 4 } };
            var numCourses = 7;
            var actual = FindOrder(numCourses, prerequisites);
            var expected = new int[] { 6, 5, 4, 2, 3, 0, 1 };
            CollectionAssert.AreEqual(expected,actual);
        }

        private Graph _graph;
        public int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            _graph = new Graph(numCourses);

            foreach (var prerequisite in prerequisites)
            {
                _graph.AddEdge(prerequisite[0], prerequisite[1]);
            }

            if (_graph.isCyclic()) return new int[0];

            var visited = new HashSet<int>();
            var stack = new Stack<int>();

            for (var i = 0; i < numCourses; i++)
            {
                if (!visited.Contains(i)) Dfs(visited, i, stack);
            }

            Dfs(visited, numCourses - 1, stack); 

            return stack.Reverse().ToArray();
        }

        private void Dfs(ISet<int> visited, int val, Stack<int> vert)
        {
            if (visited.Contains(val)) return;
            visited.Add(val);

            foreach (var adj in _graph.Adjacency[val])
            {
                if (!visited.Contains(adj)) Dfs(visited, adj, vert);
            }

            vert.Push(val);
        } 
        
    }

    public class Graph
    {
        public Graph(int val)
        {
            Val = val;
            Adjacency = new List<List<int>>(val);
            for (var i = 0; i < val; i++)
            {
                Adjacency.Add(new List<int>());
            }
        }

        public int Val { get; set; }
        public List<List<int>> Adjacency { get; set; }

        public void AddEdge(int v, int w)
        {
            Adjacency[v].Add(w);
        }

        public bool isCyclic()
        {

            // Mark all the vertices as not visited and  
            // not part of recursion stack  
            bool[] visited = new bool[Val];
            bool[] recStack = new bool[Val];


            // Call the recursive helper function to  
            // detect cycle in different DFS trees  
            for (int i = 0; i < Val; i++)
                if (isCyclicUtil(i, visited, recStack))
                    return true;

            return false;
        }
        private bool isCyclicUtil(int i, bool[] visited,
            bool[] recStack)
        {

            // Mark the current node as visited and  
            // part of recursion stack  
            if (recStack[i])
                return true;

            if (visited[i])
                return false;

            visited[i] = true;

            recStack[i] = true;
            List<int> children = Adjacency[i];

            foreach (int c in children)
                if (isCyclicUtil(c, visited, recStack))
                    return true;

            recStack[i] = false;

            return false;
        }
    }
}