
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomStack
{
    public class Stack
    {
        private const int InitialCapacity = 4;
        private int[] elements;

        public Stack()
        {
            elements = new int[InitialCapacity];
        }
        public int Count { get; private set; }

        public void Push(int element)
        {
            if (Count == elements.Length)
            {
                Resize();
            }
            elements[Count++] = element;
        }

        public int Pop()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }
            int element = elements[Count - 1];
            Count--;

            if (Count <= elements.Length / 4)
            {

                Shrink();
            }
            return element;
        }
        public int Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException(); 
            }
            return elements[Count - 1]; 
        }

        public void ForEach (Action <int> action)
        {
            for (int i = 0; i < Count; i++)
            {
                action(elements[i]); 
            }
        }
        private void Shrink()
        {
            int[] newArray = new int[elements.Length / 2];
            for (int i = 0; i < elements.Length / 2; i++)
            {
                newArray[i] = elements[i];
            }
            elements = newArray;
        }

        private void Resize()
        {
            int[] newArray = new int[elements.Length * 2];

            for (int i = 0; i < elements.Length; i++)
            {
                newArray[i] = elements[i];
            }
            elements = newArray;
        }
    }
}
