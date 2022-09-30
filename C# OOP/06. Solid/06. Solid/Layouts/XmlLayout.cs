using System;
using System.Collections.Generic;
using System.Text;

namespace Solid
{
    public class XmlLayout : ILayout
    {
        public string Format => @" 
 <log>
    <date>{0} PM</date>
    <level>{1}</level>
    <message>{2}</message>
</log>";

      
        }
    }

