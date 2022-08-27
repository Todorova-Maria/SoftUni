using System;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;
namespace CustomDoublyLinkedList
{

    public class StartUp
    {
        static void Main(string[] args)
        {
            List list = new List();

            list.Add(10);
            list.Add(20);
            list.Add(20);
            list.Add(10);
            list.Add(20);
            list.Add(20);
            list.Add(10);
            list.Add(20);
            list.Add(20);
            list.RemoveAt(1);
            list.RemoveAt(1);
            list.RemoveAt(1);
            list.RemoveAt(1);
            bool isTrue = list.Contains(5);
            list.Swap(0, 1);

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }

            list.Print();
            Console.WriteLine(list.Count);
            Console.WriteLine(isTrue);
        }
    }
}