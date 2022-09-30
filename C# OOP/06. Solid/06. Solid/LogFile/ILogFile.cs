using System;
using System.Collections.Generic;
using System.Text;

namespace Solid
{
    public interface ILogFile
    { 
        int Size { get; }
        void Write(string message);
    }   
}
