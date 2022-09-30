using System;
using System.Collections.Generic;
using System.Text;

namespace Solid
{
    public abstract class Appender : IAppender
    {
        protected Appender(ILayout layout)
        {
            Layout = layout;
        }

        public ILayout Layout { get; }
        public ReportLevel LogLevel { get; set; }

        public int Count { get; protected set; }

        public abstract void Append(string datetime, ReportLevel reportLevel, string message);

        public virtual string GetAppenderInfo()
       => @$"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType()} ,Report level: {LogLevel}, Messages appended: {Count}";
        
    }
}
