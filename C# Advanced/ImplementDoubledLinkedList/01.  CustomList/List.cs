using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDoublyLinkedList
{
    public class List
    {

        private const int CountArray = 2;
        private int[] items;

        public List()
        {
            items = new int[CountArray];
        }

        public int Count { get; set; }
        public int this[int i]  {
            get
            {
                if(i < 0 || i >= Count)
                {
                    throw new IndexOutOfRangeException();
                }
                return items[i]; 
            }
            set
            {
                items[i] = value;
            }
        }

        public void Add (int element)
        { 
            if (Count == items.Length)
            {
                int[] temp = new int[items.Length * 2];
                for (int i = 0; i < items.Length; i++)
                {
                    temp[i] = items[i];
                }
                items = temp;
            }
            items[Count++] = element;
        }  

        public int RemoveAt (int index)
        { 
            if (index >= Count || index < 0)
            {
                throw new IndexOutOfRangeException();
            } 
              int n = items[index];
                items[index] = 0;

            for (int i = index + 1; i < items.Length; i++)
            {
                    int tempN = items[i];
                    items[i] = items[index];
                    items[index] = tempN;
                    index++;
            }
            Count--; 

            if (Count <= items.Length / 4)
            {
                int[] tempArr = new int[items.Length/2];
                for (int i = 0; i < tempArr.Length; i++)
                {
                    tempArr[i] = items[i];
                }
                items = tempArr;

            }
            return n;


        } 

        public bool Contains (int element)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] == element)
                {
                    return true;
                } 
            }
            return false;
        }

        public void Swap (int firstIndex, int secondIndex)
        {
            if(firstIndex < 0 || firstIndex >= Count || secondIndex < 0 || secondIndex >= Count)
            {
                throw new IndexOutOfRangeException(); 
            }
            int temp = items[firstIndex];
            items[firstIndex] = items[secondIndex];
            items[secondIndex] = temp;
        }

        public void Print()
        {
            Console.WriteLine(String.Join(" ",items));
        }
    }
}
