using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
       

        [Test]
        public void Test1()
        { 
            StringIterator stringIterator = new StringIterator("L1e2t1C1o1d1e1");

            Assert.AreEqual('L', stringIterator.Next());  
            Assert.AreEqual('e', stringIterator.Next());  
            Assert.AreEqual('e', stringIterator.Next()); 
            Assert.AreEqual('t', stringIterator.Next()); 
            Assert.AreEqual('C', stringIterator.Next()); 
            Assert.AreEqual('o', stringIterator.Next());
            Assert.IsTrue(stringIterator.HasNext()); 
            Assert.AreEqual('d', stringIterator.Next());
            Assert.IsTrue(stringIterator.HasNext()); 
        }

        [Test]
        public void Test2()
        { 
            StringIterator stringIterator = new StringIterator("L1e002t1C1o1d1e1");

            Assert.AreEqual('L', stringIterator.Next());  
            Assert.AreEqual('e', stringIterator.Next());  
            Assert.AreEqual('e', stringIterator.Next()); 
            Assert.AreEqual('t', stringIterator.Next()); 
            Assert.AreEqual('C', stringIterator.Next()); 
            Assert.AreEqual('o', stringIterator.Next());
            Assert.IsTrue(stringIterator.HasNext()); 
            Assert.AreEqual('d', stringIterator.Next());
            Assert.IsTrue(stringIterator.HasNext()); 
        }

        [Test]
        public void Test3()
        { 
            StringIterator stringIterator = new StringIterator("L2e2t2C2o2d2e23");
        Assert.AreEqual('L', stringIterator.Next());  
            Assert.AreEqual('L', stringIterator.Next());  
            Assert.AreEqual('e', stringIterator.Next()); 
            Assert.AreEqual('e', stringIterator.Next()); 
            Assert.AreEqual('t', stringIterator.Next()); 
            Assert.AreEqual('t', stringIterator.Next());
            Assert.IsTrue(stringIterator.HasNext()); 
            Assert.AreEqual('C', stringIterator.Next());
            Assert.IsTrue(stringIterator.HasNext()); 
        }
         
        [Test]
        public void Test4()
        { 
            StringIterator stringIterator = new StringIterator("x6");
        Assert.AreEqual('x', stringIterator.Next());  
            Assert.AreEqual('x', stringIterator.Next());  
            Assert.AreEqual('x', stringIterator.Next()); 
            Assert.AreEqual('x', stringIterator.Next()); 
            Assert.AreEqual('x', stringIterator.Next()); 
            Assert.AreEqual('x', stringIterator.Next());
            Assert.IsFalse(stringIterator.HasNext()); 
            Assert.AreEqual(' ', stringIterator.Next());
            Assert.IsFalse(stringIterator.HasNext());  
        }
         

        public class StringIterator
        {
            private readonly string _s;
            private int _i;
            private int _iNext;
            private int _currentVal;
            public StringIterator(string compressedString)
            {
                _s = compressedString;
                _i = 0;
                _currentVal = 1;
                _iNext = 0;
            }

            public char Next()
            {
                if (_currentVal > 1)
                {
                    _currentVal--;
                    return _s[_i];
                }
                _i = _iNext;

                if (HasNextVal()) return _s[_i];
                return ' ';
            }

            public bool HasNext()
            {
                return _currentVal > 1 || _iNext < _s.Length;
            }

            private bool HasNextVal()
            {
                var res = false;
                while (_i < _s.Length)
                {
                    if (_s[_i] <= 'z' && _s[_i] >= 'a' || _s[_i] <= 'Z' && _s[_i] >= 'A')
                    {
                        _currentVal = 1;
                        res = true;
                        break;
                    }
                    _i++;
                }

                var i = _i + 1;
                var numberStr = "";

                while (i < _s.Length)
                {
                    if (_s[i] >= '0' && _s[i] <= '9')   
                    {
                        numberStr += _s[i];
                        i++;
                    }
                    else break;
                }

                _iNext = i;
                if (i > _i && !string.IsNullOrEmpty(numberStr)) _currentVal = int.Parse(numberStr);
                return res;
            }

        }

    }
}