/****************************************************************************
 *       ____            _           _                                      *
 *      |  _ \          (_)         | |                                     *
 *      | |_) | __ _ ___ _  _____  _| |     ___   __ _  __ _  ___ _ __      *
 *      |  _ < / _` / __| |/ __\ \/ / |    / _ \ / _` |/ _` |/ _ \ '__|     *
 *      | |_) | (_| \__ \ | (__ >  <| |___| (_) | (_| | (_| |  __/ |        *
 *      |____/ \__,_|___/_|\___/_/\_\______\___/ \__, |\__, |\___|_|        *
 *                                                __/ | __/ |               *
 *                                               |___/ |___/                *
 *  by basicx-StrgV                                                         *
 *  https://github.com/basicx-StrgV/BasicxLogger                            *
 *                                                                          *
 * **************************************************************************/
using System;
using System.IO;
using System.Text;
using BasicxLogger.Message;
using BasicxLogger.LoggerFile;
using BasicxLogger.LoggerDirectory;

namespace BasicxLogger
{
    public class Logger
    {
        public LogFile logFile { get; } = new LogFile("log", LogFileType.txt);
        public LogDirectory logDirectory { get; } = new LogDirectory(Environment.CurrentDirectory, "Logs");
        public MessageFormat messageFormat { get; } = new MessageFormat(DateFormat.year_month_day, '/');


        public Logger()
        {
            createDirectory();
        }

        public Logger(LogFile logFile)
        {
            this.logFile = logFile;
            createDirectory();
        }

        public Logger(LogFile logFile, LogDirectory logDirectory)
        {
            this.logFile = logFile;
            this.logDirectory = logDirectory;
            createDirectory();
        }

        public Logger(LogFile logFile, MessageFormat messageFormat)
        {
            this.messageFormat = messageFormat;
            this.logFile = logFile;
            createDirectory();
        }

        public Logger(LogFile logFile, LogDirectory logDirectory, MessageFormat messageFormat)
        {
            this.messageFormat = messageFormat;
            this.logFile = logFile;
            this.logDirectory = logDirectory;
            createDirectory();
        }

        public Logger(LogFile logFile, MessageFormat messageFormat, LogDirectory logDirectory)
        {
            this.messageFormat = messageFormat;
            this.logFile = logFile;
            this.logDirectory = logDirectory;
            createDirectory();
        }

        public Logger(LogDirectory logDirectory)
        {
            this.logDirectory = logDirectory;
            createDirectory();
        }

        public Logger(LogDirectory logDirectory, LogFile logFile)
        {
            this.logFile = logFile;
            this.logDirectory = logDirectory;
            createDirectory();
        }

        public Logger(LogDirectory logDirectory, MessageFormat messageFormat)
        {
            this.messageFormat = messageFormat;
            this.logDirectory = logDirectory;
            createDirectory();
        }

        public Logger(LogDirectory logDirectory, LogFile logFile, MessageFormat messageFormat)
        {
            this.messageFormat = messageFormat;
            this.logFile = logFile;
            this.logDirectory = logDirectory;
            createDirectory();
        }

        public Logger(LogDirectory logDirectory, MessageFormat messageFormat, LogFile logFile)
        {
            this.messageFormat = messageFormat;
            this.logFile = logFile;
            this.logDirectory = logDirectory;
            createDirectory();
        }

        public Logger(MessageFormat messageFormat)
        {
            this.messageFormat = messageFormat;
            createDirectory();
        }

        public Logger(MessageFormat messageFormat, LogFile logFile)
        {
            this.messageFormat = messageFormat;
            this.logFile = logFile;
            createDirectory();
        }

        public Logger(MessageFormat messageFormat, LogDirectory logDirectory)
        {
            this.messageFormat = messageFormat;
            this.logDirectory = logDirectory;
            createDirectory();
        }

        public Logger(MessageFormat messageFormat, LogFile logFile, LogDirectory logDirectory)
        {
            this.messageFormat = messageFormat;
            this.logFile = logFile;
            this.logDirectory = logDirectory;
            createDirectory();
        }

        public Logger(MessageFormat messageFormat, LogDirectory logDirectory, LogFile logFile)
        {
            this.messageFormat = messageFormat;
            this.logFile = logFile;
            this.logDirectory = logDirectory;
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
                if (!Directory.Exists(logDirectory.directory))
                {
                    createDirectory();
                }

                string logMassage = "[" + getCurrentTime() + "] " + message + "\n";

                File.AppendAllText(logDirectory.directory + "/" + logFile.file, logMassage);
            }
            catch (Exception e)
            {
                throw e;
            }
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
        public void log(string message, Encoding encoding)
        {
            try
            {
                if (!Directory.Exists(logDirectory.directory))
                {
                    createDirectory();
                }

                string logMassage = "[" + getCurrentTime() + "] " + message + "\n";

                File.AppendAllText(logDirectory.directory + "/" + logFile.file, logMassage, encoding);
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
                return systemTime.ToString(messageFormat.dateFormatString +  messageFormat.timeFormatString);
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
                if (!Directory.Exists(logDirectory.directory))
                {
                    Directory.CreateDirectory(logDirectory.directory);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
