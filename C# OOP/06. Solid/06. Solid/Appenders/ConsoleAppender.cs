using System;
using System.Collections.Generic;
using System.Text;

namespace Solid
{
    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout)  
            : base(layout)
        {
        }

        public override void Append(string datetime, ReportLevel reportLevel, string message)
        {
            Console.WriteLine(string.Format(Layout.Format, datetime, reportLevel, message));
            Count++;
        }

     
    }
}
