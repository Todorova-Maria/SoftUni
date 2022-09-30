using System;
using System.Collections.Generic;
using System.Text;

namespace Solid
{
    public interface IAppender
    {
        public ILayout Layout { get;}
        public int Count { get;}
        public ReportLevel LogLevel { get; set; }
        void Append(string datetime, ReportLevel reportLevel, string message);
        string GetAppenderInfo();

    }
}
