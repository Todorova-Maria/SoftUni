using System;
using System.Collections.Generic;
using System.Text;

namespace Solid
{
    public class AppenderFactory
    { 
        public IAppender Create (string type, ILayout layout)
        { 
            IAppender appender = null;  
            if(type == nameof(ConsoleAppender))
            {
                appender = new ConsoleAppender(layout);
            } 
            else if(type == nameof(FileAppender))
            {
                ILogFile logFile = new LogFile();
                appender = new FileAppender(layout, logFile);
            } 
            else
            {
                throw new ArgumentException("Invalid type");
            }
            return appender;
        }
    }
}
