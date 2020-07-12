using System;
using System.Collections;
using System.ComponentModel;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
         
        [Test]
        public void Test1()
        {
            uint n = 43261596;

            var actual = reverseBits(n);

            uint expected = 964176192;

            Assert.AreEqual(expected, actual);
        }

        //my
        public uint reverseBits(uint n)
        {
            var bytes = BitConverter.GetBytes(n);
            BitArray bits = new BitArray(bytes);

            for (var i = 0; i < bits.Length / 2; i++)
            {
                var tmp = bits[i];
                bits[i] = bits[bits.Length - i - 1];
                bits[bits.Length - i - 1] = tmp;
            }

            byte[] res = new byte[bits.Length / 8];
            bits.CopyTo(res, 0);

            return BitConverter.ToUInt32(res);
        }

        //public uint reverseBits(uint n)
        //{
        //    uint input = n;
        //    uint output = 0;
        //    uint mask = (uint)1 << 31;
        //    while (input > 0)
        //    {
        //        output += mask * (input % 2);
        //        input /= 2;
        //        mask /= 2;
        //    }
        //    return output;
        //}
    }
}