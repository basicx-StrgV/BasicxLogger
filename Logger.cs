using System;
using System.IO;

namespace EasyLogger
{
    public class Logger
    {
        public string logDirectoryPath { get; set; }
        public string logDirectoryName { get; set; } = "Logs";
        public string logFileName { get; set; } = "log";
        public LogFileType logFileType { get; set; } = LogFileType.txt;
        public string dateFormate { get; set; } = "yyyy'/'MM'/'dd HH:mm:ss";

        public Logger()
        {
            try
            {
                logDirectoryPath = Environment.CurrentDirectory;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public Logger(LogFileType logFileType)
        {
            try
            {
                logDirectoryPath = Environment.CurrentDirectory;
                this.logFileType = logFileType;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public Logger(LogFileType logFileType, string logFileName)
        {
            try
            {
                logDirectoryPath = Environment.CurrentDirectory;
                this.logFileType = logFileType;
                this.logFileName = logFileName;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public Logger(LogFileType logFileType, string logFileName, string logDirectoryName)
        {
            try
            {
                logDirectoryPath = Environment.CurrentDirectory;
                this.logFileType = logFileType;
                this.logFileName = logFileName;
                this.logDirectoryName = logDirectoryName;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public Logger(LogFileType logFileType, string logFileName, string logDirectoryName, string logDirectoryPath)
        {
            try
            {
                this.logFileType = logFileType;
                this.logFileName = logFileName;
                this.logDirectoryName = logDirectoryName;
                this.logDirectoryPath = logDirectoryPath;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public Logger(LogFileType logFileType, string logFileName, string logDirectoryName, string logDirectoryPath, string dateFormate)
        {
            try
            {
                this.logFileType = logFileType;
                this.logFileName = logFileName;
                this.logDirectoryName = logDirectoryName;
                this.logDirectoryPath = logDirectoryPath;
                this.dateFormate = dateFormate;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public Logger(string logDirectoryName)
        {
            try
            {
                logDirectoryPath = Environment.CurrentDirectory;
                this.logDirectoryName = logDirectoryName;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public Logger(string logDirectoryName, string logDirectoryPath)
        {
            try
            {
                this.logDirectoryName = logDirectoryName;
                this.logDirectoryPath = logDirectoryPath;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public Logger(string logDirectoryName, string logDirectoryPath, string dateFormate)
        {
            try
            {
                this.logDirectoryName = logDirectoryName;
                this.logDirectoryPath = logDirectoryPath;
                this.dateFormate = dateFormate;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public Logger(string logFileName, string logDirectoryName, string logDirectoryPath, string dateFormate)
        {
            try
            {
                this.logFileName = logFileName;
                this.logDirectoryName = logDirectoryName;
                this.logDirectoryPath = logDirectoryPath;
                this.dateFormate = dateFormate;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void write(string message)
        { 
            try
            {
                if (!Directory.Exists(logDirectoryPath + "/" + logDirectoryName))
                {
                    createDirectory();
                }

                string filePath = logDirectoryPath + "/" + logDirectoryName + "/" + logFileName + "." + logFileType;
                string logMassage = "[" + getCurrentTime() + "] " + message + "\n";

                File.AppendAllText(filePath, logMassage);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private string getCurrentTime()
        {
            try
            {
                DateTime systemTime = DateTime.Now;
                return systemTime.ToString(dateFormate);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return "ERROR 0000/00/00 00:00:00";
            }
        }

        private void createDirectory()
        {
            string directoryPath = logDirectoryPath + "/" + logDirectoryName;
            try
            {
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
