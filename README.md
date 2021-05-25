
![BasicxLogger](https://i.imgur.com/tXTU4gj.png)


[![GitHub tag (latest by date)](https://img.shields.io/github/v/tag/basicx-StrgV/BasicxLogger?label=Version)](https://github.com/basicx-StrgV/BasicxLogger/releases)
[![Nuget](https://img.shields.io/nuget/dt/BasicxLogger?label=NuGet%20Downloads)](https://www.nuget.org/packages/BasicxLogger/)


## ⭐ Features

- Easy to use
- Can be used without configuration
- Fully customizable
- Use tags to easier differentiate between different log messages
- Log messages with IDs to easier locate them in a big log file
- Asynchronous logging
- Supports different file formats
  - txt
  - log
  - xml
 
## 📦 NuGet package

You can get the nuget package here: https://www.nuget.org/packages/BasicxLogger/

## 📖 Documentation

You can finde the documentation here: https://basicx-strgv.github.io/BasicxLogger/

## 📋 Samples

### Default Logger
```cs
using BasicxLogger;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a logger object
            Logger logger = new Logger();
            //Write a log message
            logger.log("SampleMessage");
            /* 
              Path: C:\myProgramRunningDirectory\Logs\log.txt 
              Output in the log file:
              [2021/05/13 11:25:38] SampleMessage
            */
        }
    }
}
```

### Custom Logger (File, Directory)
```cs
using BasicxLogger;
using BasicxLogger.LoggerFile;
using BasicxLogger.LoggerDirectory;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a logger object
            Logger logger = new Logger(
                new LogFile("myLogFile", LogFileType.txt),
                new LogDirectory("C:\\Program Files", "myProgramFolder"));
            //Write a log message
            logger.log("SampleMessage");
            /* 
              Path: C:\Program Files\myProgramFolder\myLogFile.txt
              Output in the log file:
              [2021/05/13 11:25:38] SampleMessage
            */
        }
    }
}
```

### Custom Logger (Message)
```cs
using BasicxLogger;
using BasicxLogger.Message;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a logger object
            Logger logger = new Logger(new MessageFormat(new Date(DateFormat.day_month_year, '.')));
            //Write a log message
            logger.log("SampleMessage");
            /* 
              Path: C:\myProgramRunningDirectory\Logs\log.txt 
              Output in the log file:
              [13.05.2021 11:25:38] SampleMessage
            */
        }
    }
}
```
