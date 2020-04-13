using NUnit.Framework;

namespace Tests
{
    public class Tests
    { 

        [Test]
        public void Test1()
        {
            var S = "ab#c";
            var T = "ad#c";

            var res = BackspaceCompare(S, T);

            Assert.IsTrue(res);
        }


        [Test]
        public void Test2()
        {
            var S = "ab##";
            var T = "c#d#";

            var res = BackspaceCompare(S, T);

            Assert.IsTrue(res);
        }

        [Test]
        public void Test3()
        {
            var S = "a##c";
            var T = "#a#c";

            var res = BackspaceCompare(S, T);

            Assert.IsTrue(res);
        }

        [Test]
        public void Test4()
        {
            var S = "a#c";
            var T = "b";

            var res = BackspaceCompare(S, T);

            Assert.IsFalse(res);
        }


        [Test]
        public void Test5()
        {
            var S = "#####";
            var T = "";

            var res = BackspaceCompare(S, T);

            Assert.IsTrue(res);
        }

        [Test]
        public void Test6()
        { 
            var S = "xywrrmp";
            var T = "xywrrmu#p";

            var res = BackspaceCompare(S, T);

            Assert.IsTrue(res);
        }

        [Test]
        public void Test7()
        { 
            var S = "bxj##tw";
            var T = "bxj###tw#p";

            var res = BackspaceCompare(S, T);

            Assert.IsFalse(res);
        }

        [Test]
        public void Test8()
        { 
            var S = "bbbextm";
            var T = "bbb#extm";

            var res = BackspaceCompare(S, T);

            Assert.IsFalse(res);
        }

        [Test]
        public void Test9()
        { 
            var S = "bxj##tw";
            var T = "bxj###tw";

            var res = BackspaceCompare(S, T);

            Assert.IsFalse(res);
        }

        [Test]
        public void Test10()
        { 
            var S = "rheyggodcclgstf";
            var T = "#rheyggodcclgstf";

            var res = BackspaceCompare(S, T);

            Assert.IsTrue(res);
        }

        public bool BackspaceCompare(string S, string T)
        {
            var sPointer = S.Length - 1;
            var tPointer = T.Length - 1;
            
            while (sPointer >= 0 || tPointer >= 0)
            {
               
                sPointer = Backspace(S, sPointer);
                tPointer = Backspace(T, tPointer);

                if (sPointer < 0 && tPointer < 0) return true;

                if (sPointer < 0 || tPointer < 0 || S[sPointer--] != T[tPointer--]) return false;
            }

            return true;
        }

        private int Backspace(string s,int position)
        {
            if (position < 0 || s[position] != '#') return position;

            var symbolsToDelete = 2;

            while (symbolsToDelete != 0)
            {
                if (position == 0) return -1;
                symbolsToDelete = s[--position] == '#' ? symbolsToDelete + 1 : symbolsToDelete - 1;
            }

            return position;
        }
    }
}