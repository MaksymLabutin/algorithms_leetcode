using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        
        [Test]
        public void Test1()
        {
            var moves = "UD";

            var actual = JudgeCircle(moves);

            Assert.True(actual);
        }

        public bool JudgeCircle(string moves)
        {
            var up = 0;
            var r = 0; 

            foreach (var move in moves)
            {
                switch (move)
                {
                    case 'U':
                        up++;
                        break;
                    case 'R':
                        r++;
                        break;
                    case 'D':
                        up--;
                        break;
                    case 'L':
                        r--;
                        break;
                }
            }

            return up == 0 && r == 0;
        }
    }
}