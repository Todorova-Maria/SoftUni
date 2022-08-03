﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericBoxofInt
{
        public class Box
        {
            private List<int> boxes;

            public Box()
            {
                boxes = new List<int>();
            }
            public void Add(int box)
            {
                boxes.Add(box);
            }
            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();

                foreach (int box in boxes)
                {
                    sb.AppendLine($"{typeof(int)}: {box}");
                }
                return sb.ToString().TrimEnd();
            }
        }
    }



