using System;
using System.Collections.Generic;
using System.Text;

namespace Solid
{
    public class SimpleLayout : ILayout
    {
        public string Format
            => "{0} - {1} - {2}";

        public SimpleLayout()
        {
            string.Format(Format, "1", "2", "3"); 
        }
    }
}
