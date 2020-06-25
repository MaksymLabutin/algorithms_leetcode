using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        public int Rand10()
        {

            var val = int.MaxValue;

            while (val > 40)
            {
                val = Rand7() * 7 + Rand7() - 7;
            }

            return val % 10 + 1;
        }
    }
}