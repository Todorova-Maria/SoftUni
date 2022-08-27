using System;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;
namespace CustomStack
{

    public class StartUp
    {
        static void Main(string[] args)
        {
            Stack stack = new Stack();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);
            stack.Pop();
            stack.ForEach(Console.WriteLine);
        }
    }
}