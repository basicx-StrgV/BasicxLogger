/****************************************************************
 *   ______                _                                    *
 *  |  ____|              | |                                   *
 *  | |__   __ _ ___ _   _| |     ___   __ _  __ _  ___ _ __    *
 *  |  __| / _` / __| | | | |    / _ \ / _` |/ _` |/ _ \ '__|   *
 *  | |___| (_| \__ \ |_| | |___| (_) | (_| | (_| |  __/ |      *
 *  |______\__,_|___/\__, |______\___/ \__, |\__, |\___|_|      *
 *                    __/ |             __/ | __/ |             *
 *                   |___/             |___/ |___/              *
 *  by basicx-StrgV                                             *
 *  https://github.com/basicx-StrgV/EasyLogger                  *
 *                                                              *
 * **************************************************************/
using System;
using System.IO;
using EasyLogger.LoggerFile;
using EasyLogger.LoggerDirectory;

namespace EasyLogger
{
    public class Logger
    {
        public LogFile logFile { get; }
        public LogDirectory logDirectory { get; }
        public string dateFormate { get; } = "yyyy'/'MM'/'dd HH:mm:ss";

        public Logger()
        {
            this.logFile = new LogFile("log", LogFileType.txt);
            this.logDirectory = new LogDirectory(Environment.CurrentDirectory, "Logs");
            createDirectory();
        }

        public Logger(LogFile logFile)
        {
            this.logFile = logFile;
            this.logDirectory = new LogDirectory(Environment.CurrentDirectory, "Logs");
            createDirectory();
        }

        public Logger(LogDirectory logDirectory)
        {
            this.logFile = new LogFile("log", LogFileType.txt);
            this.logDirectory = logDirectory;
            createDirectory();
        }

        public Logger(LogFile logFile, LogDirectory logDirectory)
        {
            this.logFile = logFile;
            this.logDirectory = logDirectory;
            createDirectory();
        }

        public Logger(string dateFormate)
        {
            this.logFile = new LogFile("log", LogFileType.txt);
            this.logDirectory = new LogDirectory(Environment.CurrentDirectory, "Logs");
            this.dateFormate = dateFormate;
            createDirectory();
        }

        public Logger(LogFile logFile, string dateFormate)
        {
            this.logFile = logFile;
            this.logDirectory = new LogDirectory(Environment.CurrentDirectory, "Logs");
            this.dateFormate = dateFormate;
            createDirectory();
        }

        public Logger(LogDirectory logDirectory, string dateFormate)
        {
            this.logFile = new LogFile("log", LogFileType.txt);
            this.logDirectory = logDirectory;
            this.dateFormate = dateFormate;
            createDirectory();
        }

        public Logger(LogFile logFile, LogDirectory logDirectory, string dateFormate)
        {
            this.logFile = logFile;
            this.logDirectory = logDirectory;
            this.dateFormate = dateFormate;
            createDirectory();
        }

        /// <summary>
        /// Writes the given message and the current time stamp to the log file.
        /// </summary>
        /// <remarks>
        /// If the log file and/or directory is missing, the method will automatically create them.
        /// </remarks>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.NotSupportedException"></exception>
        /// <exception cref="System.UnauthorizedAccessException"></exception>
        /// <exception cref="System.IO.IOException"></exception>
        /// <exception cref="System.IO.PathTooLongException"></exception>
        /// <exception cref="System.IO.DirectoryNotFoundException"></exception>
        /// <exception cref="System.Security.SecurityException"></exception>
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
                throw e;
            }
        }

        private string getCurrentTime()
        {
            try
            {
                DateTime systemTime = DateTime.Now;
                return systemTime.ToString(dateFormate);
            }
            catch(Exception)
            {
                return "INVALID DATE FORMAT";
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
                throw e;
            }
        }
    }
}
