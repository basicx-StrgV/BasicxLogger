# BasicxLogger
An easy to use logger for any C# project.

You can just use the log method to create and write a default log file
or create the logger object with custom settings to create a custom log file.
 
## How to use

You can use the nuget package https://www.nuget.org/packages/BasicxLogger/
or clone the repository and add BasicxLogger to your existing solution in VisualStudio.

### Namespaces

- BasicxLogger
- BasicxLogger.LoggerFile
- BasicxLogger.LoggerDirectory

### Samples

#### Default Logger
```cs
using System;
using BasicxLogger;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            loggingSample();
        }

        private static void loggingSample()
        {
            //Create a logger object
            Logger logger = new Logger();
            //Write a log message
            logger.log("SampleMessage");
            /* 
              Output in the log file:
              [2021/05/13 00:25:38] SampleMessage
            */
        }
    }
}
```

#### Custom Logger
```cs
using System;
using BasicxLogger;
using BasicxLogger.LoggerFile;
using BasicxLogger.LoggerDirectory;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            loggingSample();
        }

        private static void loggingSample()
        {
            //Create a logger object
            Logger logger = new Logger(
                new LogFile("myLogFile", LogFileType.txt),
                new LogDirectory("C:\\Program Files", "myProgramFolder"));
            //Write a log message
            logger.log("SampleMessage");
            /* 
              Output in the log file:
              [2021/05/13 00:25:38] SampleMessage
            */
        }
    }
}
```