using System;
using System.Collections.Generic;
using System.Text;

namespace Solid
{
    public class Logger : ILogger
    {
        public Logger(params IAppender[] appenders)
        {
            Appenders = new List<IAppender>();
            Appenders.AddRange(appenders);
        }

        public List<IAppender> Appenders { get; }

        public void Critical(string dateTime, string message)
        {
            Log(dateTime, ReportLevel.Critical, message);
        }

        public void Error(string dateTime, string message)
        {
            Log(dateTime, ReportLevel.Error, message);
        }

        public void Fatal(string dateTime, string message)
        {
            Log(dateTime, ReportLevel.Fatal, message);
        }

        public void Info(string dateTime, string message)
        {
            Log(dateTime, ReportLevel.Info, message);
        }

        public void Warning(string dateTime, string message)
        {
            Log(dateTime, ReportLevel.Warning, message);
        }
         
        public string GetLoggerInfo()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var appender in Appenders)
            {
                sb.AppendLine(appender.GetAppenderInfo());
            }
            return sb.ToString().TrimEnd();
        }
        private void Log(string dateTime,ReportLevel level, string message)
        {
            foreach (var appender in Appenders)
            {
                if (level >= appender.LogLevel)
                {
                    appender.Append(dateTime, level, message);
                }
            }
        }
    }
}
