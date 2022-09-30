using System;
using System.Collections.Generic;
using System.Text;

namespace Solid
{
    public class LoggerFactory
    { 
        public ILogger LoggerAdd (string dateTime, string message, ReportLevel messageLogLevel, ILogger logger)
        {
            
             if (messageLogLevel == ReportLevel.Info)
            {
                logger.Info(dateTime, message);
            }
            else if (messageLogLevel == ReportLevel.Warning)
            {
                logger.Warning(dateTime, message);
            }
            else if (messageLogLevel == ReportLevel.Error)
            {
                logger.Error(dateTime, message);
            }
            else if (messageLogLevel == ReportLevel.Critical)
            {
                logger.Critical(dateTime, message);
            }
            else if (messageLogLevel == ReportLevel.Fatal)
            {
                logger.Fatal(dateTime, message);
            }
            return logger;
        } 
    }
}
