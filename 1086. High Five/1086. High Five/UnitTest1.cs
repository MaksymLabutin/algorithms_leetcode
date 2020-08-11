using System;
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
            var items = new int[][] {
                new[] { 1, 91 },
                new int[] { 1, 92 },
                new int[] { 2, 93 },
                new int[] { 2, 97},
                new int[] {1, 60},
                new int[] {2, 77},
                new int[] {1, 65},
                new int[] {1, 87},
                new int[] {1, 100},
                new int[] {2, 100},
                new int[] {2, 76}
            };

            var actual = HighFive(items);

            var expected = new int[][]{new []{1,87}, new []{2,88}};

            CollectionAssert.AreEqual(expected, actual);
        }

        public int[][] HighFive(int[][] items)
        {
            var students = new Dictionary<int, List<int>>();

            foreach (var item in items)
            {
                if (!students.ContainsKey(item[0]))
                {
                    students.Add(item[0], new List<int> { item[1] });
                }
                else
                {
                    if (students[item[0]].Count >= 5)
                    {
                        var min = students[item[0]].Min();

                        if (min >= item[1]) continue;
                        students[item[0]].Remove(min);
                        students[item[0]].Add(item[1]);
                    }
                    else
                    {
                        students[item[0]].Add(item[1]);
                    }
                }
            }

            var keyValuePairs = students.OrderBy(_ => _.Key).ToDictionary(_ => _.Key, _ => _.Value);

            var res = new int[keyValuePairs.Count][];

            var i = 0;
            foreach (var keyValuePair in keyValuePairs)
            {
                res[i] = new int[] { keyValuePair.Key, (int) keyValuePair.Value.Average()};
                i++;
            }

            return res;
        }

    }
}