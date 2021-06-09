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
using System.Xml;
using System.Text;
using System.Text.Json;
using System.Globalization;
using System.Threading.Tasks;
using System.Collections.Generic;
using BasicxLogger.Message;
using BasicxLogger.LoggerFile;
using BasicxLogger.LoggerDirectory;

namespace BasicxLogger
{
    /// <summary>
    /// File logger that contains everything needed to write a message to a log file.
    /// </summary>
    /// <remarks>
    /// This logger supports the following file formats: txt, log, xml and json
    /// </remarks>
    public class FileLogger : ILogger
    {
        //-Properties-----------------------------------------------------------------------------------
        /// <summary>
        /// Contains all informations about the log file
        /// </summary>
        public LogFile LoggingFile { get; } = new LogFile("log", FileType.txt);
        /// <summary>
        /// Contains all informations about the log directory
        /// </summary>
        public LogDirectory FileDirectory { get; } = new LogDirectory(Environment.CurrentDirectory, "Logs");
        /// <summary>
        /// Contains all informations about the formatting of the log messages
        /// </summary>
        public LogMessageFormat MessageFormat { get; } = new LogMessageFormat(new LogDate(DateFormat.year_month_day, '/'), new LogTime(TimeFormat.hour24_min_sec, CultureInfo.InvariantCulture), Encoding.UTF8);
        //----------------------------------------------------------------------------------------------

        //-Constructors---------------------------------------------------------------------------------
        /// <summary>
        /// Constructor, to create a simple logger object that uses the default settings
        /// </summary>
        public FileLogger()
        {
            CreateDirectory();
        }
        /// <summary>
        /// Constructor, to create a logger object with custom settings. 
        /// </summary>
        /// <remarks>
        /// Everything that has no custom configuration will use the default settings.
        /// </remarks>
        public FileLogger(LogFile logFile)
        {
            this.LoggingFile = logFile;
            CreateDirectory();
        }
        /// <summary>
        /// Constructor, to create a logger object with custom settings. 
        /// </summary>
        /// <remarks>
        /// Everything that has no custom configuration will use the default settings.
        /// </remarks>
        public FileLogger(LogFile logFile, LogDirectory logDirectory)
        {
            this.LoggingFile = logFile;
            this.FileDirectory = logDirectory;
            CreateDirectory();
        }
        /// <summary>
        /// Constructor, to create a logger object with custom settings. 
        /// </summary>
        /// <remarks>
        /// Everything that has no custom configuration will use the default settings.
        /// </remarks>
        public FileLogger(LogFile logFile, LogMessageFormat messageFormat)
        {
            this.MessageFormat = messageFormat;
            this.LoggingFile = logFile;
            CreateDirectory();
        }
        /// <summary>
        /// Constructor, to create a logger object with custom settings. 
        /// </summary>
        /// <remarks>
        /// Everything that has no custom configuration will use the default settings.
        /// </remarks>
        public FileLogger(LogFile logFile, LogDirectory logDirectory, LogMessageFormat messageFormat)
        {
            this.MessageFormat = messageFormat;
            this.LoggingFile = logFile;
            this.FileDirectory = logDirectory;
            CreateDirectory();
        }
        /// <summary>
        /// Constructor, to create a logger object with custom settings. 
        /// </summary>
        /// <remarks>
        /// Everything that has no custom configuration will use the default settings.
        /// </remarks>
        public FileLogger(LogFile logFile, LogMessageFormat messageFormat, LogDirectory logDirectory)
        {
            this.MessageFormat = messageFormat;
            this.LoggingFile = logFile;
            this.FileDirectory = logDirectory;
            CreateDirectory();
        }
        /// <summary>
        /// Constructor, to create a logger object with custom settings. 
        /// </summary>
        /// <remarks>
        /// Everything that has no custom configuration will use the default settings.
        /// </remarks>
        public FileLogger(LogDirectory logDirectory)
        {
            this.FileDirectory = logDirectory;
            CreateDirectory();
        }
        /// <summary>
        /// Constructor, to create a logger object with custom settings. 
        /// </summary>
        /// <remarks>
        /// Everything that has no custom configuration will use the default settings.
        /// </remarks>
        public FileLogger(LogDirectory logDirectory, LogFile logFile)
        {
            this.LoggingFile = logFile;
            this.FileDirectory = logDirectory;
            CreateDirectory();
        }
        /// <summary>
        /// Constructor, to create a logger object with custom settings. 
        /// </summary>
        /// <remarks>
        /// Everything that has no custom configuration will use the default settings.
        /// </remarks>
        public FileLogger(LogDirectory logDirectory, LogMessageFormat messageFormat)
        {
            this.MessageFormat = messageFormat;
            this.FileDirectory = logDirectory;
            CreateDirectory();
        }
        /// <summary>
        /// Constructor, to create a logger object with custom settings. 
        /// </summary>
        /// <remarks>
        /// Everything that has no custom configuration will use the default settings.
        /// </remarks>
        public FileLogger(LogDirectory logDirectory, LogFile logFile, LogMessageFormat messageFormat)
        {
            this.MessageFormat = messageFormat;
            this.LoggingFile = logFile;
            this.FileDirectory = logDirectory;
            CreateDirectory();
        }
        /// <summary>
        /// Constructor, to create a logger object with custom settings. 
        /// </summary>
        /// <remarks>
        /// Everything that has no custom configuration will use the default settings.
        /// </remarks>
        public FileLogger(LogDirectory logDirectory, LogMessageFormat messageFormat, LogFile logFile)
        {
            this.MessageFormat = messageFormat;
            this.LoggingFile = logFile;
            this.FileDirectory = logDirectory;
            CreateDirectory();
        }
        /// <summary>
        /// Constructor, to create a logger object with custom settings. 
        /// </summary>
        /// <remarks>
        /// Everything that has no custom configuration will use the default settings.
        /// </remarks>
        public FileLogger(LogMessageFormat messageFormat)
        {
            this.MessageFormat = messageFormat;
            CreateDirectory();
        }
        /// <summary>
        /// Constructor, to create a logger object with custom settings. 
        /// </summary>
        /// <remarks>
        /// Everything that has no custom configuration will use the default settings.
        /// </remarks>
        public FileLogger(LogMessageFormat messageFormat, LogFile logFile)
        {
            this.MessageFormat = messageFormat;
            this.LoggingFile = logFile;
            CreateDirectory();
        }
        /// <summary>
        /// Constructor, to create a logger object with custom settings. 
        /// </summary>
        /// <remarks>
        /// Everything that has no custom configuration will use the default settings.
        /// </remarks>
        public FileLogger(LogMessageFormat messageFormat, LogDirectory logDirectory)
        {
            this.MessageFormat = messageFormat;
            this.FileDirectory = logDirectory;
            CreateDirectory();
        }
        /// <summary>
        /// Constructor, to create a logger object with custom settings. 
        /// </summary>
        /// <remarks>
        /// Everything that has no custom configuration will use the default settings.
        /// </remarks>
        public FileLogger(LogMessageFormat messageFormat, LogFile logFile, LogDirectory logDirectory)
        {
            this.MessageFormat = messageFormat;
            this.LoggingFile = logFile;
            this.FileDirectory = logDirectory;
            CreateDirectory();
        }
        /// <summary>
        /// Constructor, to create a logger object with custom settings. 
        /// </summary>
        /// <remarks>
        /// Everything that has no custom configuration will use the default settings.
        /// </remarks>
        public FileLogger(LogMessageFormat messageFormat, LogDirectory logDirectory, LogFile logFile)
        {
            this.MessageFormat = messageFormat;
            this.LoggingFile = logFile;
            this.FileDirectory = logDirectory;
            CreateDirectory();
        }
        //----------------------------------------------------------------------------------------------

        //-Public-Methods-------------------------------------------------------------------------------
        /// <summary>
        /// Writes the given message and the current time stamp to the log file.
        /// </summary>
        /// <remarks>
        /// If the log file and/or directory is missing, the method will automatically create them.
        /// </remarks>
        /// <param name="message">
        /// The message that will be writen to the file
        /// </param>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.NotSupportedException"></exception>
        /// <exception cref="System.NullReferenceException"></exception>
        /// <exception cref="System.UnauthorizedAccessException"></exception>
        /// <exception cref="System.IO.IOException"></exception>
        /// <exception cref="System.IO.PathTooLongException"></exception>
        /// <exception cref="System.IO.DirectoryNotFoundException"></exception>
        /// <exception cref="System.Security.SecurityException"></exception>
        public void Log(string message)
        {
            try
            {
                if (!Directory.Exists(FileDirectory.FullPath))
                {
                    CreateDirectory();
                }

                if (LoggingFile.Type.Equals(FileType.xml))
                {
                    //Log to xml file
                    if (!File.Exists(GetFullFilePath()))
                    {
                        CreateXmlFile();
                    }

                    LogToXml(MessageFormat.DefaultTag, message);
                }
                else if (LoggingFile.Type.Equals(FileType.json))
                {
                    //Log to json file
                    if (!File.Exists(GetFullFilePath()))
                    {
                        CreateJsonFile();
                    }

                    LogToJson(MessageFormat.DefaultTag, message);
                }
                else if (LoggingFile.Type.Equals(FileType.txt) || LoggingFile.Type.Equals(FileType.log))
                {
                    //Default log (.txt and .log file)
                    File.AppendAllText(GetFullFilePath(), MessageBuilder(MessageFormat.DefaultTag, message), MessageFormat.TextEncoding);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Writes the given message with the given tag and the current time stamp to the log file.
        /// </summary>
        /// <remarks>
        /// If the log file and/or directory is missing, the method will automatically create them.
        /// </remarks>
        /// <param name="message">
        /// The message that will be writen to the file
        /// </param>
        /// <param name="messageTag">
        /// A Tag that will be added to the message, to make it easy to distinguish between differen log messages
        /// </param>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.NotSupportedException"></exception>
        /// <exception cref="System.NullReferenceException"></exception>
        /// <exception cref="System.UnauthorizedAccessException"></exception>
        /// <exception cref="System.IO.IOException"></exception>
        /// <exception cref="System.IO.PathTooLongException"></exception>
        /// <exception cref="System.IO.DirectoryNotFoundException"></exception>
        /// <exception cref="System.Security.SecurityException"></exception>
        public void Log(LogTag messageTag, string message)
        {
            try
            {
                if (!Directory.Exists(FileDirectory.FullPath))
                {
                    CreateDirectory();
                }

                if (LoggingFile.Type.Equals(FileType.xml))
                {
                    //Log to xml file
                    if (!File.Exists(GetFullFilePath()))
                    {
                        CreateXmlFile();
                    }

                    LogToXml(messageTag, message);
                }
                else if (LoggingFile.Type.Equals(FileType.json))
                {
                    //Log to json file
                    if (!File.Exists(GetFullFilePath()))
                    {
                        CreateJsonFile();
                    }

                    LogToJson(messageTag, message);
                }
                else if (LoggingFile.Type.Equals(FileType.txt) || LoggingFile.Type.Equals(FileType.log))
                {
                    //Default log (.txt and .log file)
                    File.AppendAllText(GetFullFilePath(), MessageBuilder(messageTag, message), MessageFormat.TextEncoding);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Writes the given message, a message ID and the current time stamp to the log file.
        /// </summary>
        /// <remarks>
        /// If the log file and/or directory is missing, the method will automatically create them.
        /// </remarks>
        /// <param name="message">
        /// The message that will be writen to the file
        /// </param>
        /// <param name="verifyMessageID">
        /// Set to true if you want to make sure the message id is unique.
        /// If set to true, the loging of the message may take longer an use more ram depending on how big your log file is.
        /// When the log file exceeds the length of 1,073,741,823 chars (a little over 1GB file size) the ID will not be verifyed.
        /// </param>
        /// <returns>
        /// The message ID that was automatically assigned to the message. It can be used to identify a specific message.
        /// </returns>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.NotSupportedException"></exception>
        /// <exception cref="System.NullReferenceException"></exception>
        /// <exception cref="System.UnauthorizedAccessException"></exception>
        /// <exception cref="System.IO.IOException"></exception>
        /// <exception cref="System.IO.PathTooLongException"></exception>
        /// <exception cref="System.IO.DirectoryNotFoundException"></exception>
        /// <exception cref="System.Security.SecurityException"></exception>
        public string LogId(string message, bool verifyMessageID = false)
        {
            try
            {
                if (!Directory.Exists(FileDirectory.FullPath))
                {
                    CreateDirectory();
                }

                string id = GenerateId();
                if (verifyMessageID)
                {
                    id = VerifyId(id);
                }

                if (LoggingFile.Type.Equals(FileType.xml))
                {
                    //Log to xml file
                    if (!File.Exists(GetFullFilePath()))
                    {
                        CreateXmlFile();
                    }

                    LogToXml(MessageFormat.DefaultTag, message, id);
                }
                else if (LoggingFile.Type.Equals(FileType.json))
                {
                    //Log to json file
                    if (!File.Exists(GetFullFilePath()))
                    {
                        CreateJsonFile();
                    }

                    LogToJson(MessageFormat.DefaultTag, message, id);
                }
                else if (LoggingFile.Type.Equals(FileType.txt) || LoggingFile.Type.Equals(FileType.log))
                {
                    //Default log (.txt and .log file)
                    File.AppendAllText(GetFullFilePath(), MessageBuilder(MessageFormat.DefaultTag, message, id), MessageFormat.TextEncoding);
                }

                return id;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Writes the given message with the given tag, a message ID and the current time stamp to the log file.
        /// </summary>
        /// <remarks>
        /// If the log file and/or directory is missing, the method will automatically create them.
        /// </remarks>
        /// <param name="message">
        /// The message that will be writen to the file
        /// </param>
        /// <param name="messageTag">
        /// A Tag that will be added to the message, to make it easy to distinguish between differen log messages
        /// </param>
        /// <param name="verifyMessageID">
        /// Set to true if you want to make sure the message id is unique.
        /// If set to true, the loging of the message may take longer an use more ram depending on how big your log file is.
        /// When the log file exceeds the length of 1,073,741,823 chars (a little over 1GB file size) the ID will not be verifyed.
        /// </param>
        /// <returns>
        /// The message ID that was automatically assigned to the message. It can be used to identify a specific message.
        /// </returns>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.NotSupportedException"></exception>
        /// <exception cref="System.NullReferenceException"></exception>
        /// <exception cref="System.UnauthorizedAccessException"></exception>
        /// <exception cref="System.IO.IOException"></exception>
        /// <exception cref="System.IO.PathTooLongException"></exception>
        /// <exception cref="System.IO.DirectoryNotFoundException"></exception>
        /// <exception cref="System.Security.SecurityException"></exception>
        public string LogId(LogTag messageTag, string message, bool verifyMessageID = false)
        {
            try
            {
                if (!Directory.Exists(FileDirectory.FullPath))
                {
                    CreateDirectory();
                }

                string id = GenerateId();
                if (verifyMessageID)
                {
                    id = VerifyId(id);
                }

                if (LoggingFile.Type.Equals(FileType.xml))
                {
                    //Log to xml file
                    if (!File.Exists(GetFullFilePath()))
                    {
                        CreateXmlFile();
                    }

                    LogToXml(messageTag, message, id);
                }
                else if (LoggingFile.Type.Equals(FileType.json))
                {
                    //Log to json file
                    if (!File.Exists(GetFullFilePath()))
                    {
                        CreateJsonFile();
                    }

                    LogToJson(messageTag, message, id);
                }
                else if (LoggingFile.Type.Equals(FileType.txt) || LoggingFile.Type.Equals(FileType.log))
                {
                    //Default log (.txt and .log file)
                    File.AppendAllText(GetFullFilePath(), MessageBuilder(messageTag, message, id), MessageFormat.TextEncoding);
                }

                return id;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Writes the given message, the given ID and the current time stamp to the log file.
        /// </summary>
        /// <remarks>
        /// If the log file and/or directory is missing, the method will automatically create them.
        /// </remarks>
        /// <param name="id">
        /// The id of the log message
        /// </param>
        /// <param name="message">
        /// The message that will be writen to the file
        /// </param>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.NotSupportedException"></exception>
        /// <exception cref="System.NullReferenceException"></exception>
        /// <exception cref="System.UnauthorizedAccessException"></exception>
        /// <exception cref="System.IO.IOException"></exception>
        /// <exception cref="System.IO.PathTooLongException"></exception>
        /// <exception cref="System.IO.DirectoryNotFoundException"></exception>
        /// <exception cref="System.Security.SecurityException"></exception>
        public void LogCustomId(string id, string message)
        {
            try
            {
                if (!Directory.Exists(FileDirectory.FullPath))
                {
                    CreateDirectory();
                }

                if (LoggingFile.Type.Equals(FileType.xml))
                {
                    //Log to xml file
                    if (!File.Exists(GetFullFilePath()))
                    {
                        CreateXmlFile();
                    }

                    LogToXml(MessageFormat.DefaultTag, message, id);
                }
                else if (LoggingFile.Type.Equals(FileType.json))
                {
                    //Log to json file
                    if (!File.Exists(GetFullFilePath()))
                    {
                        CreateJsonFile();
                    }

                    LogToJson(MessageFormat.DefaultTag, message, id);
                }
                else if (LoggingFile.Type.Equals(FileType.txt) || LoggingFile.Type.Equals(FileType.log))
                {
                    //Default log (.txt and .log file)
                    File.AppendAllText(GetFullFilePath(), MessageBuilder(MessageFormat.DefaultTag, message, id), MessageFormat.TextEncoding);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Writes the given message with the given tag, the given ID and the current time stamp to the log file.
        /// </summary>
        /// <remarks>
        /// If the log file and/or directory is missing, the method will automatically create them.
        /// </remarks>
        /// <param name="id">
        /// The id of the log message
        /// </param>
        /// <param name="message">
        /// The message that will be writen to the file
        /// </param>
        /// <param name="messageTag">
        /// A Tag that will be added to the message, to make it easy to distinguish between differen log messages
        /// </param>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.NotSupportedException"></exception>
        /// <exception cref="System.NullReferenceException"></exception>
        /// <exception cref="System.UnauthorizedAccessException"></exception>
        /// <exception cref="System.IO.IOException"></exception>
        /// <exception cref="System.IO.PathTooLongException"></exception>
        /// <exception cref="System.IO.DirectoryNotFoundException"></exception>
        /// <exception cref="System.Security.SecurityException"></exception>
        public void LogCustomId(string id, LogTag messageTag, string message)
        {
            try
            {
                if (!Directory.Exists(FileDirectory.FullPath))
                {
                    CreateDirectory();
                }

                if (LoggingFile.Type.Equals(FileType.xml))
                {
                    //Log to xml file
                    if (!File.Exists(GetFullFilePath()))
                    {
                        CreateXmlFile();
                    }

                    LogToXml(messageTag, message, id);
                }
                else if (LoggingFile.Type.Equals(FileType.json))
                {
                    //Log to json file
                    if (!File.Exists(GetFullFilePath()))
                    {
                        CreateJsonFile();
                    }

                    LogToJson(messageTag, message, id);
                }
                else if (LoggingFile.Type.Equals(FileType.txt) || LoggingFile.Type.Equals(FileType.log))
                {
                    //Default log (.txt and .log file)
                    File.AppendAllText(GetFullFilePath(), MessageBuilder(messageTag, message, id), MessageFormat.TextEncoding);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //-Async-methods-----
        /// <summary>
        /// Asynchronous writes the given message and the current time stamp to the log file.
        /// </summary>
        /// <remarks>
        /// If the log file and/or directory is missing, the method will automatically create them.
        /// </remarks>
        /// <param name="message">
        /// The message that will be writen to the file
        /// </param>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.NotSupportedException"></exception>
        /// <exception cref="System.NullReferenceException"></exception>
        /// <exception cref="System.UnauthorizedAccessException"></exception>
        /// <exception cref="System.IO.IOException"></exception>
        /// <exception cref="System.IO.PathTooLongException"></exception>
        /// <exception cref="System.IO.DirectoryNotFoundException"></exception>
        /// <exception cref="System.Security.SecurityException"></exception>
        public async Task LogAsync(string message)
        {
            try
            {
                Task logTask = Task.Run(() => Log(message));
                await logTask;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Asynchronous writes the given message with the given tag and the current time stamp to the log file.
        /// </summary>
        /// <remarks>
        /// If the log file and/or directory is missing, the method will automatically create them.
        /// </remarks>
        /// <param name="message">
        /// The message that will be writen to the file
        /// </param>
        /// <param name="messageTag">
        /// A Tag that will be added to the message, to make it easy to distinguish between differen log messages
        /// </param>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.NotSupportedException"></exception>
        /// <exception cref="System.NullReferenceException"></exception>
        /// <exception cref="System.UnauthorizedAccessException"></exception>
        /// <exception cref="System.IO.IOException"></exception>
        /// <exception cref="System.IO.PathTooLongException"></exception>
        /// <exception cref="System.IO.DirectoryNotFoundException"></exception>
        /// <exception cref="System.Security.SecurityException"></exception>
        public async Task LogAsync(LogTag messageTag, string message)
        {
            try
            {
                Task logTask = Task.Run(() => Log(messageTag, message));
                await logTask;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Asynchronous writes the given message, a message ID and the current time stamp to the log file.
        /// </summary>
        /// <remarks>
        /// If the log file and/or directory is missing, the method will automatically create them.
        /// </remarks>
        /// <param name="message">
        /// The message that will be writen to the file
        /// </param>
        /// <param name="verifyMessageID">
        /// Set to true if you want to make sure the message id is unique.
        /// If set to true, the loging of the message may take longer an use more ram depending on how big your log file is.
        /// When the log file exceeds the length of 1,073,741,823 chars (a little over 1GB file size) the ID will not be verifyed.
        /// </param>
        /// <returns>
        /// The message ID that was automatically assigned to the message. It can be used to identify a specific message.
        /// </returns>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.NotSupportedException"></exception>
        /// <exception cref="System.NullReferenceException"></exception>
        /// <exception cref="System.UnauthorizedAccessException"></exception>
        /// <exception cref="System.IO.IOException"></exception>
        /// <exception cref="System.IO.PathTooLongException"></exception>
        /// <exception cref="System.IO.DirectoryNotFoundException"></exception>
        /// <exception cref="System.Security.SecurityException"></exception>
        public async Task<string> LogIdAsync(string message, bool verifyMessageID = false)
        {
            try
            {
                Task<string> logTask = Task.Run(() => LogId(message, verifyMessageID));
                await logTask;
                return logTask.Result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Asynchronous writes the given message with the given tag, a message ID and the current time stamp to the log file.
        /// </summary>
        /// <remarks>
        /// If the log file and/or directory is missing, the method will automatically create them.
        /// </remarks>
        /// <param name="message">
        /// The message that will be writen to the file
        /// </param>
        /// <param name="messageTag">
        /// A Tag that will be added to the message, to make it easy to distinguish between differen log messages
        /// </param>
        /// <param name="verifyMessageID">
        /// Set to true if you want to make sure the message id is unique.
        /// If set to true, the loging of the message may take longer an use more ram depending on how big your log file is.
        /// When the log file exceeds the length of 1,073,741,823 chars (a little over 1GB file size) the ID will not be verifyed.
        /// </param>
        /// <returns>
        /// The message ID that was automatically assigned to the message. It can be used to identify a specific message.
        /// </returns>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.NotSupportedException"></exception>
        /// <exception cref="System.NullReferenceException"></exception>
        /// <exception cref="System.UnauthorizedAccessException"></exception>
        /// <exception cref="System.IO.IOException"></exception>
        /// <exception cref="System.IO.PathTooLongException"></exception>
        /// <exception cref="System.IO.DirectoryNotFoundException"></exception>
        /// <exception cref="System.Security.SecurityException"></exception>
        public async Task<string> LogIdAsync(LogTag messageTag, string message, bool verifyMessageID = false)
        {
            try
            {
                Task<string> logTask = Task.Run(() => LogId(messageTag, message, verifyMessageID));
                await logTask;
                return logTask.Result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Asynchronous writes the given message, the given ID and the current time stamp to the log file.
        /// </summary>
        /// <remarks>
        /// If the log file and/or directory is missing, the method will automatically create them.
        /// </remarks>
        /// <param name="id">
        /// The id of the log message
        /// </param>
        /// <param name="message">
        /// The message that will be writen to the file
        /// </param>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.NotSupportedException"></exception>
        /// <exception cref="System.NullReferenceException"></exception>
        /// <exception cref="System.UnauthorizedAccessException"></exception>
        /// <exception cref="System.IO.IOException"></exception>
        /// <exception cref="System.IO.PathTooLongException"></exception>
        /// <exception cref="System.IO.DirectoryNotFoundException"></exception>
        /// <exception cref="System.Security.SecurityException"></exception>
        public async Task LogCustomIdAsync(string id, string message)
        {
            try
            {
                Task logTask = Task.Run(() => LogCustomId(id, message));
                await logTask;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Asynchronous writes the given message with the given tag, the given ID and the current time stamp to the log file.
        /// </summary>
        /// <remarks>
        /// If the log file and/or directory is missing, the method will automatically create them.
        /// </remarks>
        /// <param name="id">
        /// The id of the log message
        /// </param>
        /// <param name="message">
        /// The message that will be writen to the file
        /// </param>
        /// <param name="messageTag">
        /// A Tag that will be added to the message, to make it easy to distinguish between differen log messages
        /// </param>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.NotSupportedException"></exception>
        /// <exception cref="System.NullReferenceException"></exception>
        /// <exception cref="System.UnauthorizedAccessException"></exception>
        /// <exception cref="System.IO.IOException"></exception>
        /// <exception cref="System.IO.PathTooLongException"></exception>
        /// <exception cref="System.IO.DirectoryNotFoundException"></exception>
        /// <exception cref="System.Security.SecurityException"></exception>
        public async Task LogCustomIdAsync(string id, LogTag messageTag, string message)
        {
            try
            {
                Task logTask = Task.Run(() => LogCustomId(id, messageTag, message));
                await logTask;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //-------------------

        /// <returns>
        /// The full file path (e.g. C:\mypath\myfile.txt)
        /// </returns>
        public string GetFullFilePath()
        {
            return FileDirectory.FullPath + "\\" + LoggingFile.FullName;
        }

        /// <summary>
        /// Deletes the log file, that was created by the logger.
        /// </summary>
        /// <remarks>
        /// All logs will be lost. If you log again after deleting the log file, the logger will create a new file.
        /// </remarks>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.NotSupportedException"></exception>
        /// <exception cref="System.UnauthorizedAccessException"></exception>
        /// <exception cref="System.IO.IOException"></exception>
        /// <exception cref="System.IO.PathTooLongException"></exception>
        /// <exception cref="System.IO.DirectoryNotFoundException"></exception>
        public void DeleteLogFile()
        {
            try
            {
                File.Delete(GetFullFilePath());
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //----------------------------------------------------------------------------------------------

        //-Private-Methods------------------------------------------------------------------------------

        private string GetCurrentTime()
        {
            try
            {
                string start = "";
                string end = "";
                if (LoggingFile.Type.Equals(FileType.txt) || LoggingFile.Type.Equals(FileType.log))
                {
                    start = "[";
                    end = "] ";
                }

                if (MessageFormat.Date.Format.Equals(DateFormat.none) &&
                        !MessageFormat.Time.Format.Equals(TimeFormat.none))
                {
                    return DateTime.Now.ToString(start + MessageFormat.Time.FormatString + end,
                                                MessageFormat.Time.CultureFormat);
                }
                else if (!MessageFormat.Date.Format.Equals(DateFormat.none) &&
                            MessageFormat.Time.Format.Equals(TimeFormat.none))
                {
                    return DateTime.Now.ToString(start + MessageFormat.Date.FormatString + end,
                                                MessageFormat.Time.CultureFormat);
                }
                else if (MessageFormat.Date.Format.Equals(DateFormat.none) &&
                            MessageFormat.Time.Format.Equals(TimeFormat.none))
                {
                    return "";
                }
                else
                {
                    return DateTime.Now.ToString(start + MessageFormat.Date.FormatString + (char)32 +
                                        MessageFormat.Time.FormatString + end, MessageFormat.Time.CultureFormat);
                }
            }
            catch (Exception)
            {
                return "[INVALID DATETIME FORMAT] ";
            }
        }

        private void CreateDirectory()
        {
            try
            {
                if (!Directory.Exists(FileDirectory.FullPath))
                {
                    Directory.CreateDirectory(FileDirectory.FullPath);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void CreateXmlFile()
        {
            try
            {
                if (!File.Exists(GetFullFilePath()))
                {
                    XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
                    xmlWriterSettings.Encoding = MessageFormat.TextEncoding;

                    XmlWriter xmlWriter = XmlWriter.Create(GetFullFilePath(), xmlWriterSettings);

                    xmlWriter.WriteStartDocument();
                    xmlWriter.WriteStartElement(LoggingFile.Name);
                    xmlWriter.WriteEndElement();
                    xmlWriter.Close();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void CreateJsonFile()
        {
            try
            {
                if (!File.Exists(GetFullFilePath()))
                {
                    File.WriteAllText(GetFullFilePath(), "[]");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private string GenerateId()
        {
            string id = "";

            List<string> idParts = new List<string>();

            while (idParts.Count != 10)
            {
                idParts.Add(new Random().Next(0, 16).ToString("X"));
            }

            foreach (string part in idParts)
            {
                id = id + part;
            }

            return id;
        }

        private string VerifyId(string id)
        {
            try
            {
                string tempId = id;

                if (File.Exists(FileDirectory.FullPath + "/" + LoggingFile.FullName))
                {
                    string fileContent = File.ReadAllText(FileDirectory.FullPath + "/" + LoggingFile.FullName);

                    while (fileContent.Contains(tempId))
                    {
                        tempId = GenerateId();
                    }
                }

                return tempId;
            }
            catch (Exception)
            {
                return id;
            }
        }

        private string MessageBuilder(LogTag messageTag, string message, string id = "")
        {
            string dateTimePart = GetCurrentTime();
            string tagPart = "";
            string idPart = "";

            if (!messageTag.Equals(LogTag.none))
            {
                tagPart = "[" + messageTag + "] ";
            }

            if (!id.Equals(""))
            {
                idPart = "[ID:" + id + "] ";
            }

            return dateTimePart + tagPart + idPart + message + "\n";
        }

        private void LogToXml(LogTag messageTag, string message, string id = "")
        {
            try
            {
                //Load the xml file
                XmlDocument xmlFile = new XmlDocument();
                xmlFile.Load(GetFullFilePath());

                //Get the root node from the file
                XmlNode rootNode = xmlFile.SelectSingleNode(LoggingFile.Name);

                //Create nodes and add data
                XmlNode logMessageNode = xmlFile.CreateElement("LogMessage");
                XmlAttribute idAttribute = xmlFile.CreateAttribute("id");
                if (!id.Equals(""))
                {
                    idAttribute.Value = id;
                }
                logMessageNode.Attributes.Append(idAttribute);

                XmlNode timestampNode = xmlFile.CreateElement("timestamp");
                if (!MessageFormat.Date.Format.Equals(DateFormat.none) ||
                                !MessageFormat.Time.Format.Equals(TimeFormat.none))
                {
                    timestampNode.InnerText = GetCurrentTime();
                }
                logMessageNode.AppendChild(timestampNode);

                XmlNode tagNode = xmlFile.CreateElement("tag");
                if (!messageTag.Equals(LogTag.none))
                {
                    tagNode.InnerText = messageTag.ToString();
                }
                logMessageNode.AppendChild(tagNode);

                XmlNode messageNode = xmlFile.CreateElement("message");
                messageNode.InnerText = message;
                logMessageNode.AppendChild(messageNode);

                //Appand to root node
                rootNode.AppendChild(logMessageNode);

                //Save the xml file
                xmlFile.Save(GetFullFilePath());
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void LogToJson(LogTag messageTag, string message, string id = "")
        {
            try
            {
                string fileContent = File.ReadAllText(GetFullFilePath());

                List<LogMessageModel> logs = JsonSerializer.Deserialize<List<LogMessageModel>>(fileContent);

                LogMessageModel newLog = new LogMessageModel();
                if (!id.Equals(""))
                {
                    newLog.id = id;
                }

                if (!MessageFormat.Date.Format.Equals(DateFormat.none) ||
                                    !MessageFormat.Time.Format.Equals(TimeFormat.none))
                {
                    newLog.timestamp = GetCurrentTime();
                }

                if (!messageTag.Equals(LogTag.none))
                {
                    newLog.tag = messageTag.ToString();
                }

                newLog.message = message;

                logs.Add(newLog);

                string newFileContent = JsonSerializer.Serialize(logs);

                FileStream fileWriter = File.OpenWrite(GetFullFilePath());
                Utf8JsonWriter jsonWriter = new Utf8JsonWriter(fileWriter, new JsonWriterOptions { Indented = true });

                JsonDocument jsonFile = JsonDocument.Parse(newFileContent);

                jsonFile.WriteTo(jsonWriter);

                jsonWriter.Flush();

                jsonWriter.Dispose();

                fileWriter.Close();
                fileWriter.Dispose();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //----------------------------------------------------------------------------------------------
    }
}
