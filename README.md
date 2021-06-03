
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
- Log your owne objects to a json file
- Log to multiple files and/or databases at ones
- Log to a MySQL database
- Supports different file formats
  - txt
  - log
  - xml
  - json

## 📄 Logger

- FileLogger
- MySqlLogger
- JsonLogger
- MultiLogger

 
## 📦 NuGet package

You can get the nuget package here: https://www.nuget.org/packages/BasicxLogger/

## 📖 Documentation

You can finde the documentation here: https://basicx-strgv.github.io/BasicxLogger/

## 📋 Samples

### FileLogger
```cs
using BasicxLogger;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a logger object
            FileLogger logger = new FileLogger();
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

### FileLogger (Custom File and Directory)
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
            FileLogger logger = new FileLogger(
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

### FileLogger (Custom Message)
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
            FileLogger logger = new FileLogger(
				new MessageFormat(
					new Date(DateFormat.day_month_year, '.')));
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
