using System;

namespace Solid
{
    public class Program
    {
        static void Main(string[] args)
        {
            LayoutFactory layoutFactory = new LayoutFactory();
            AppenderFactory appenderFactory = new AppenderFactory();  
            LoggerFactory loggerFactory = new LoggerFactory();  
            

            ILogger logger = new Logger();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split();
                string typeAppender = info[0];
                string LayoutInfo = info[1];

                ILayout layout = layoutFactory.Create(LayoutInfo);
                IAppender appender = appenderFactory.Create(typeAppender, layout);  

                if (info.Length == 3)
                {
                    bool isValidLogLevel = Enum.TryParse(info[2], true, out ReportLevel logLevel);
                    if (isValidLogLevel)
                    {
                        appender.LogLevel = logLevel;
                    } 
                    else
                    {
                        continue;
                    }
                }

                logger.Appenders.Add(appender);
            }

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] information = input.Split("|");

                string logLevel = information[0];
                string dateTime = information[1];
                string message = information[2];

                bool isValidLogLevel = Enum.TryParse(logLevel, true, out ReportLevel messageLogLevel); 
                if(!isValidLogLevel)
                {
                    continue;
                } 
               else
                {
                    loggerFactory.LoggerAdd(dateTime, message, messageLogLevel, logger);
                }
            }

            Console.WriteLine("Logger info");
            Console.WriteLine(logger.GetLoggerInfo());

        }
    }
}
