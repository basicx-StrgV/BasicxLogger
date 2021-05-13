using System;
using System.IO;
using EasyLogger.LoggerFile;
using EasyLogger.LoggerDirectory;

namespace EasyLogger
{
    public class Logger
    {
        public LogFile logFile { get; set; }
        public LogDirectory logDirectory { get; set; }
        public string dateFormate { get; set; } = "yyyy'/'MM'/'dd HH:mm:ss";

        public Logger()
        {
            try
            {
                this.logFile = new LogFile("log", LogFileType.txt);
                this.logDirectory = new LogDirectory(Environment.CurrentDirectory, "Logs");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public Logger(LogFile logFile)
        {
            try
            {
                this.logFile = logFile;
                this.logDirectory = new LogDirectory(Environment.CurrentDirectory, "Logs");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public Logger(LogDirectory logDirectory)
        {
            try
            {
                this.logFile = new LogFile("log", LogFileType.txt);
                this.logDirectory = logDirectory;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public Logger(LogFile logFile, LogDirectory logDirectory)
        {
            try
            {
                this.logFile = logFile;
                this.logDirectory = logDirectory;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public Logger(string dateFormate)
        {
            try
            {
                this.logFile = new LogFile("log", LogFileType.txt);
                this.logDirectory = new LogDirectory(Environment.CurrentDirectory, "Logs");
                this.dateFormate = dateFormate;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public Logger(LogFile logFile, string dateFormate)
        {
            try
            {
                this.logFile = logFile;
                this.logDirectory = new LogDirectory(Environment.CurrentDirectory, "Logs");
                this.dateFormate = dateFormate;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public Logger(LogDirectory logDirectory, string dateFormate)
        {
            try
            {
                this.logFile = new LogFile("log", LogFileType.txt);
                this.logDirectory = logDirectory;
                this.dateFormate = dateFormate;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public Logger(LogFile logFile, LogDirectory logDirectory, string dateFormate)
        {
            try
            {
                this.logFile = logFile;
                this.logDirectory = logDirectory;
                this.dateFormate = dateFormate;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void log(string message)
        { 
            try
            {
                if (!Directory.Exists(logDirectory.ToString()))
                {
                    createDirectory();
                }

                string filePath = logDirectory.ToString() + "/" + logFile.ToString();
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
            try
            {
                if (!Directory.Exists(logDirectory.ToString()))
                {
                    Directory.CreateDirectory(logDirectory.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
