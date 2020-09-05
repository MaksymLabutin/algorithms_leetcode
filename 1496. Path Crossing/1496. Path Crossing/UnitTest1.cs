using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    { 
        [Test]
        public void Test1()
        {
            var path = "NES";
            var actual = IsPathCrossing(path);
            Assert.IsFalse(actual);
        }

        [Test]
        public void Test2()
        {
            var path = "NESWW";
            var actual = IsPathCrossing(path);
            Assert.IsTrue(actual);
        }


        [Test]
        public void Test3()
        {
            var path = "W";
            var actual = IsPathCrossing(path);
            Assert.IsFalse(actual);
        }

        public bool IsPathCrossing(string path)
        { 
            var memo = new HashSet<(int, int)>();
            (int x, int y) position = (0, 0);
            memo.Add(position);

            foreach (var direction in path)
            { 
                switch (direction)
                {
                    case 'N':
                        position.y += 1;
                        break;
                    case 'S':
                        position.y -= 1;
                        break;  
                    case 'E':
                        position.x += 1;
                        break;  
                    case 'W':
                        position.x -= 1;
                        break;  
                }

                if (memo.Contains(position)) return true;
                memo.Add(position);
            }

            return false;
        }
    }
}