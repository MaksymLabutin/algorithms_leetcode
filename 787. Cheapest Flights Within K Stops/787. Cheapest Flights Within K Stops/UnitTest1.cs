using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace Tests
{
    public class Tests
    {


        [Test]
        public void Test1()
        {
            var n = 3;
            var edges = new int[][]
            {
                new[] {0, 2, 500},
                new[] {1, 2, 100},
                new[] {0, 1, 100}
            };
            var src = 0;
            var dst = 2;
            var k = 1;

            var actual = FindCheapestPrice(n, edges, src, dst, k);

            var expected = 200;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test2()
        {
            var n = 3;
            var edges = new int[][]
            {
                new[] {0, 2, 500},
                new[] {1, 2, 100},
                new[] {0, 1, 100}
            };
            var src = 0;
            var dst = 2;
            var k = 0;

            var actual = FindCheapestPrice(n, edges, src, dst, k);

            var expected = 500;

            Assert.AreEqual(expected, actual);
        }

        //Bellman-Ford algo
        public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int K)
        {
            var dp = new double[K + 2][];

            for (var i = 0; i < K + 2; i++)
            {
                dp[i] = new double[n];
                for (var j = 0; j < n; j++)
                {
                    dp[i][j] = int.MaxValue;
                }
            } 

            dp[0][src] = 0;

            for (var i = 1; i < K + 2; i++)
            {
                dp[i][src] = 0;

                foreach (var flight in flights)
                {
                    dp[i][flight[1]] = Math.Min(dp[i][flight[1]], dp[i - 1][flight[0]] + flight[2]);
                }
            }

            return dp[K + 1][dst] < int.MaxValue ? (int)dp[K + 1][dst] : -1;
        }

        //private Dictionary<int, Node> _sources;
        //private int _minPrice;

        //public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int K)
        //{
        //    _sources = new Dictionary<int, Node>();
        //    _minPrice = int.MaxValue; 

        //    for (var i = 1; i <= n; i++)
        //    {
        //        _sources.Add(i - 1, new Node());
        //    }

        //    foreach (var flight in flights)
        //    {
        //        var node = _sources[flight[0]];
        //        node.Airport = flight[0];
        //        _sources[flight[1]].Airport = flight[1];
        //        node.DestinationPrice.Add(_sources[flight[1]], flight[2]);
        //    }

        //    FindCheapestPrice(0, src, dst, K);

        //    return _minPrice == int.MaxValue ? -1 : _minPrice;
        //}


        //private void FindCheapestPrice(int price, int src, int dst, int k)
        //{
        //    if (k < -1 || price > _minPrice) return;

        //    if (src == dst) _minPrice = Math.Min(price, _minPrice);

        //    var source = _sources[src];

        //    foreach (var flight in source.DestinationPrice)
        //    {
        //        FindCheapestPrice(price + flight.Value, flight.Key.Airport, dst, k - 1);
        //    }
        //}

        //private class Node
        //{
        //    public int Airport { get; set; }
        //    public Dictionary<Node, int> DestinationPrice { get; set; } = new Dictionary<Node, int>();
        //}
    }
}