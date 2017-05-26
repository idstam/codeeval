using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://www.codeeval.com/open_challenges/9/

namespace StackImplementation
{
    class Program
    {

        static void Main(string[] args)
        {
            using (var r = new StreamReader(args[0]))
            {
                string line;
                line = r.ReadLine();
                

                do
                {
                    if (line.Trim() == "") continue;
                    
                    var stack = new IntStack();

                    var numbers = line.Split(new char[] { ' ' });
                    foreach(var n in numbers)
                    {
                        int fromFile = int.Parse(n);
                        stack.Push(fromFile);
                    }
                    int? fromStack = stack.Pop();                    
                    while(fromStack.HasValue)
                    {
                        Console.Write(fromStack);
                        fromStack = stack.Pop();
                        fromStack = stack.Pop();
                        if(fromStack.HasValue)
                        {
                            Console.Write(" ");
                        }
                    }
                    Console.WriteLine();

                    line = r.ReadLine();
                }
                while (line != null);
            }
            Console.ReadLine();

        }

        public class IntStack
        {
            public int[] _stack;
            public int _curSize;
            public int _storageSize = 10;
            public IntStack()
            {
                _stack = new int[_storageSize];
            }

            public void Push(int value)
            {
                if (_stack.Length == _curSize)
                {
                    resizeStorage(_storageSize);
                }
                _stack[_curSize] = value;
                _curSize++;
            }
            public int? Pop()
            {
                if (_curSize == 0)
                {
                    return null;
                }
                else
                {
                    _curSize--;
                    int retVal = _stack[_curSize];
                    return retVal;
                }
            }

            private void resizeStorage(int extra)
            {
                int[] foo = new int[_curSize + _storageSize];
                for (int i = 0; i < _curSize; i++)
                {
                    foo[i] = _stack[i];
                }
                _stack = foo;
            }

        }

    }
}
