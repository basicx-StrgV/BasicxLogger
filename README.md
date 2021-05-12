# EasyLogger
An easy to use logger for any C# project.

You can just use the write method to create and write a default log file
or customize the settings of the logger to create a custom log file.
 
## How to use

You can clone the repository and add EasyLogger to your existing solution in VisualStudio

```cs
using System;
using EasyLogger;

namespace Saple
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
            logger.write("SampleMessage");
            /* 
              Output in the log file:
              [2021/05/13 00:25:38] SampleMessage
            */
        }
    }
}
```