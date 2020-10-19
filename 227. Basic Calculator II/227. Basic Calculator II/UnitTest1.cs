using System;
using System.Collections.Generic;
using Xunit;

namespace _227._Basic_Calculator_II
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var s = "3+2*2";

            var actual = Calculate(s);

            var expected = 7;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test2()
        {
            var s = "3+2*2/3+2";

            var actual = Calculate(s);

            var expected = 6;

            Assert.Equal(expected, actual);
        }


        [Fact]
        public void Test3()
        {
            var s = " 3+5 / 2 +11-12+45/2*5";

            var actual = Calculate(s);

            var expected = 114;

            Assert.Equal(expected, actual);
        }


        [Fact]
        public void Test4()
        {
            var s = " ";

            var actual = Calculate(s);

            var expected = 0;

            Assert.Equal(expected, actual);
        }


        [Fact]
        public void Test5()
        {
            var s = "14/3*2";

            var actual = Calculate(s);

            var expected = 8;

            Assert.Equal(expected, actual);
        }


        public int Calculate(string s)
        {
            s = s.Replace(" ", "");

            if (string.IsNullOrEmpty(s)) return 0;

            var operators = new Queue<char>();
            var numbers = new Queue<int>();

            var pointer = 0;

            while (pointer < s.Length)
            {
                switch (s[pointer])
                { 
                    case '+':
                    case '-':
                    case '/':
                    case '*':
                        operators.Enqueue(s[pointer]);
                        break;
                    default:
                        {
                            var data = GetNumber(pointer, s);
                            pointer = data.pointer - 1;
                            numbers.Enqueue(data.number);
                            break;
                        }
                }

                pointer++;
            }

            var res = numbers.Dequeue();
            while (operators.Count != 0)
            {
                var op = operators.Dequeue();
                var l = numbers.Dequeue();

                if (( op =='+' || op == '-' ) &&!CanMakeOperation(operators))
                {
                    while (operators.Count != 0)
                    {
                        if (CanMakeOperation(operators)) break;
                        var cOp = operators.Dequeue();
                        l = Calculate(cOp, l, numbers.Dequeue());
                    }
                }
                res = Calculate(op, res, l);
            }

            return res;
        }

        private int Calculate(char op, int left, int right)
        {
            if (op == '+' || op == '-') return op == '+' ? left + right : left - right;
            return op == '/' ? left / right : left * right;
        }

        private bool CanMakeOperation(Queue<char> operatios)
        {
            return operatios.Count == 0 || operatios.Peek() == '-' || operatios.Peek() == '+';
        }

        private (int pointer, int number) GetNumber(int pointer, string s)
        {
            var start = pointer;
            while (pointer < s.Length && s[pointer] != '+' && s[pointer] != '-' && s[pointer] != '/' && s[pointer] != '*') pointer++;
            var num = int.Parse(s.Substring(start, pointer - start));

            return (pointer, num);
        }
    }
}
