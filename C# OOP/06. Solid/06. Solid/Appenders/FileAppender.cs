using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Solid
{
    public class FileAppender : Appender
    {
        private const string FilePath = "../../../Output/result.txt";

        public FileAppender(ILayout layout, ILogFile logFile)  
            : base(layout)
        {
            LogFile = logFile;
        }
       
        public ILogFile LogFile { get; set; }
        public override void Append(string datetime, ReportLevel reportLevel, string message)
        {
            string appendMessage = string.Format(Layout.Format, datetime, reportLevel, message);
            LogFile.Write(appendMessage);
            File.AppendAllText(FilePath, appendMessage + Environment.NewLine);
            Count++;
        }

        public override string GetAppenderInfo()
        {
            return base.GetAppenderInfo() + $", File size: {LogFile.Size}";
        }


    }
}
