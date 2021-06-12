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
using BasicxLogger.Models;
using BasicxLogger.LoggerFile;
using BasicxLogger.LoggerDirectory;
using BasicxLogger.Message;

#pragma warning disable
namespace BasicxLogger
{

    /// <summary>
    /// Default Logger class that contains everything needed to write a message to a log file.
    /// </summary>
    /// <remarks>
    /// This logger supports the following file formats: txt, log, xml and json
    /// </remarks>
    [Obsolete("The Logger class is obsolete and won't receive updates. Please use the FileLogger class instead", false)]
    public class Logger
    {
        //-Properties-----------------------------------------------------------------------------------
        /// <summary>
        /// Contains all informations about the log file
        /// </summary>
        public LogFile logFile { get; } = new LogFile("log", FileType.txt);
        /// <summary>
        /// Contains all informations about the log directory
        /// </summary>
        public LogDirectory logDirectory { get; } = new LogDirectory(Environment.CurrentDirectory, "Logs");
        /// <summary>
        /// Contains all informations about the formatting of the log messages
        /// </summary>
        public MessageFormat messageFormat { get; } = new MessageFormat(new Date(DateFormat.year_month_day, '/'), new Time(TimeFormat.hour24_min_sec, CultureInfo.InvariantCulture), Encoding.UTF8);
        //----------------------------------------------------------------------------------------------

        //-Constructors---------------------------------------------------------------------------------
        /// <summary>
        /// Constructor, to create a simple logger object that uses the default settings
        /// </summary>
        public Logger()
        {
            createDirectory();
        }
        /// <summary>
        /// Constructor, to create a logger object with custom settings. 
        /// </summary>
        /// <remarks>
        /// Everything that has no custom configuration will use the default settings.
        /// </remarks>
        public Logger(LogFile logFile)
        {
            this.logFile = logFile;
            createDirectory();
        }
        /// <summary>
        /// Constructor, to create a logger object with custom settings. 
        /// </summary>
        /// <remarks>
        /// Everything that has no custom configuration will use the default settings.
        /// </remarks>
        public Logger(LogFile logFile, LogDirectory logDirectory)
        {
            this.logFile = logFile;
            this.logDirectory = logDirectory;
            createDirectory();
        }
        /// <summary>
        /// Constructor, to create a logger object with custom settings. 
        /// </summary>
        /// <remarks>
        /// Everything that has no custom configuration will use the default settings.
        /// </remarks>
        public Logger(LogFile logFile, MessageFormat messageFormat)
        {
            this.messageFormat = messageFormat;
            this.logFile = logFile;
            createDirectory();
        }
        /// <summary>
        /// Constructor, to create a logger object with custom settings. 
        /// </summary>
        /// <remarks>
        /// Everything that has no custom configuration will use the default settings.
        /// </remarks>
        public Logger(LogFile logFile, LogDirectory logDirectory, MessageFormat messageFormat)
        {
            this.messageFormat = messageFormat;
            this.logFile = logFile;
            this.logDirectory = logDirectory;
            createDirectory();
        }
        /// <summary>
        /// Constructor, to create a logger object with custom settings. 
        /// </summary>
        /// <remarks>
        /// Everything that has no custom configuration will use the default settings.
        /// </remarks>
        public Logger(LogFile logFile, MessageFormat messageFormat, LogDirectory logDirectory)
        {
            this.messageFormat = messageFormat;
            this.logFile = logFile;
            this.logDirectory = logDirectory;
            createDirectory();
        }
        /// <summary>
        /// Constructor, to create a logger object with custom settings. 
        /// </summary>
        /// <remarks>
        /// Everything that has no custom configuration will use the default settings.
        /// </remarks>
        public Logger(LogDirectory logDirectory)
        {
            this.logDirectory = logDirectory;
            createDirectory();
        }
        /// <summary>
        /// Constructor, to create a logger object with custom settings. 
        /// </summary>
        /// <remarks>
        /// Everything that has no custom configuration will use the default settings.
        /// </remarks>
        public Logger(LogDirectory logDirectory, LogFile logFile)
        {
            this.logFile = logFile;
            this.logDirectory = logDirectory;
            createDirectory();
        }
        /// <summary>
        /// Constructor, to create a logger object with custom settings. 
        /// </summary>
        /// <remarks>
        /// Everything that has no custom configuration will use the default settings.
        /// </remarks>
        public Logger(LogDirectory logDirectory, MessageFormat messageFormat)
        {
            this.messageFormat = messageFormat;
            this.logDirectory = logDirectory;
            createDirectory();
        }
        /// <summary>
        /// Constructor, to create a logger object with custom settings. 
        /// </summary>
        /// <remarks>
        /// Everything that has no custom configuration will use the default settings.
        /// </remarks>
        public Logger(LogDirectory logDirectory, LogFile logFile, MessageFormat messageFormat)
        {
            this.messageFormat = messageFormat;
            this.logFile = logFile;
            this.logDirectory = logDirectory;
            createDirectory();
        }
        /// <summary>
        /// Constructor, to create a logger object with custom settings. 
        /// </summary>
        /// <remarks>
        /// Everything that has no custom configuration will use the default settings.
        /// </remarks>
        public Logger(LogDirectory logDirectory, MessageFormat messageFormat, LogFile logFile)
        {
            this.messageFormat = messageFormat;
            this.logFile = logFile;
            this.logDirectory = logDirectory;
            createDirectory();
        }
        /// <summary>
        /// Constructor, to create a logger object with custom settings. 
        /// </summary>
        /// <remarks>
        /// Everything that has no custom configuration will use the default settings.
        /// </remarks>
        public Logger(MessageFormat messageFormat)
        {
            this.messageFormat = messageFormat;
            createDirectory();
        }
        /// <summary>
        /// Constructor, to create a logger object with custom settings. 
        /// </summary>
        /// <remarks>
        /// Everything that has no custom configuration will use the default settings.
        /// </remarks>
        public Logger(MessageFormat messageFormat, LogFile logFile)
        {
            this.messageFormat = messageFormat;
            this.logFile = logFile;
            createDirectory();
        }
        /// <summary>
        /// Constructor, to create a logger object with custom settings. 
        /// </summary>
        /// <remarks>
        /// Everything that has no custom configuration will use the default settings.
        /// </remarks>
        public Logger(MessageFormat messageFormat, LogDirectory logDirectory)
        {
            this.messageFormat = messageFormat;
            this.logDirectory = logDirectory;
            createDirectory();
        }
        /// <summary>
        /// Constructor, to create a logger object with custom settings. 
        /// </summary>
        /// <remarks>
        /// Everything that has no custom configuration will use the default settings.
        /// </remarks>
        public Logger(MessageFormat messageFormat, LogFile logFile, LogDirectory logDirectory)
        {
            this.messageFormat = messageFormat;
            this.logFile = logFile;
            this.logDirectory = logDirectory;
            createDirectory();
        }
        /// <summary>
        /// Constructor, to create a logger object with custom settings. 
        /// </summary>
        /// <remarks>
        /// Everything that has no custom configuration will use the default settings.
        /// </remarks>
        public Logger(MessageFormat messageFormat, LogDirectory logDirectory, LogFile logFile)
        {
            this.messageFormat = messageFormat;
            this.logFile = logFile;
            this.logDirectory = logDirectory;
            createDirectory();
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
        public void log(string message)
        {
            try
            {
                if (!Directory.Exists(logDirectory.FullPath))
                {
                    createDirectory();
                }

                if (logFile.Type.Equals(FileType.xml))
                {
                    //Log to xml file
                    if (!File.Exists(getFullFilePath()))
                    {
                        createXmlFile();
                    }

                    logToXml(messageFormat.DefaultTag, message);
                }
                else if (logFile.Type.Equals(FileType.json))
                {
                    //Log to json file
                    if (!File.Exists(getFullFilePath()))
                    {
                        createJsonFile();
                    }

                    logToJson(messageFormat.DefaultTag, message);
                }
                else if (logFile.Type.Equals(FileType.txt) || logFile.Type.Equals(FileType.log))
                {
                    //Default log (.txt and .log file)
                    File.AppendAllText(getFullFilePath(), messageBuilder(messageFormat.DefaultTag, message), messageFormat.TextEncoding);
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
        public void log(Tag messageTag, string message)
        {
            try
            {
                if (!Directory.Exists(logDirectory.FullPath))
                {
                    createDirectory();
                }

                if (logFile.Type.Equals(FileType.xml))
                {
                    //Log to xml file
                    if (!File.Exists(getFullFilePath()))
                    {
                        createXmlFile();
                    }

                    logToXml(messageTag, message);
                }
                else if (logFile.Type.Equals(FileType.json))
                {
                    //Log to json file
                    if (!File.Exists(getFullFilePath()))
                    {
                        createJsonFile();
                    }

                    logToJson(messageTag, message);
                }
                else if (logFile.Type.Equals(FileType.txt) || logFile.Type.Equals(FileType.log))
                {
                    //Default log (.txt and .log file)
                    File.AppendAllText(getFullFilePath(), messageBuilder(messageTag, message), messageFormat.TextEncoding);
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
        public string logID(string message, bool verifyMessageID = false)
        {
            try
            {
                if (!Directory.Exists(logDirectory.FullPath))
                {
                    createDirectory();
                }

                string id = generateID();
                if (verifyMessageID)
                {
                    id = verifyID(id);
                }

                if (logFile.Type.Equals(FileType.xml))
                {
                    //Log to xml file
                    if (!File.Exists(getFullFilePath()))
                    {
                        createXmlFile();
                    }

                    logToXml(messageFormat.DefaultTag, message, id);
                }
                else if (logFile.Type.Equals(FileType.json))
                {
                    //Log to json file
                    if (!File.Exists(getFullFilePath()))
                    {
                        createJsonFile();
                    }

                    logToJson(messageFormat.DefaultTag, message, id);
                }
                else if (logFile.Type.Equals(FileType.txt) || logFile.Type.Equals(FileType.log))
                {
                    //Default log (.txt and .log file)
                    File.AppendAllText(getFullFilePath(), messageBuilder(messageFormat.DefaultTag, message, id), messageFormat.TextEncoding);
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
        public string logID(Tag messageTag, string message, bool verifyMessageID = false)
        {
            try
            {
                if (!Directory.Exists(logDirectory.FullPath))
                {
                    createDirectory();
                }

                string id = generateID();
                if (verifyMessageID)
                {
                    id = verifyID(id);
                }

                if (logFile.Type.Equals(FileType.xml))
                {
                    //Log to xml file
                    if (!File.Exists(getFullFilePath()))
                    {
                        createXmlFile();
                    }

                    logToXml(messageTag, message, id);
                }
                else if (logFile.Type.Equals(FileType.json))
                {
                    //Log to json file
                    if (!File.Exists(getFullFilePath()))
                    {
                        createJsonFile();
                    }

                    logToJson(messageTag, message, id);
                }
                else if (logFile.Type.Equals(FileType.txt) || logFile.Type.Equals(FileType.log))
                {
                    //Default log (.txt and .log file)
                    File.AppendAllText(getFullFilePath(), messageBuilder(messageTag, message, id), messageFormat.TextEncoding);
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
        public void logCustomID(string id, string message)
        {
            try
            {
                if (!Directory.Exists(logDirectory.FullPath))
                {
                    createDirectory();
                }

                if (logFile.Type.Equals(FileType.xml))
                {
                    //Log to xml file
                    if (!File.Exists(getFullFilePath()))
                    {
                        createXmlFile();
                    }

                    logToXml(messageFormat.DefaultTag, message, id);
                }
                else if (logFile.Type.Equals(FileType.json))
                {
                    //Log to json file
                    if (!File.Exists(getFullFilePath()))
                    {
                        createJsonFile();
                    }

                    logToJson(messageFormat.DefaultTag, message, id);
                }
                else if (logFile.Type.Equals(FileType.txt) || logFile.Type.Equals(FileType.log))
                {
                    //Default log (.txt and .log file)
                    File.AppendAllText(getFullFilePath(), messageBuilder(messageFormat.DefaultTag, message, id), messageFormat.TextEncoding);
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
        public void logCustomID(string id, Tag messageTag, string message)
        {
            try
            {
                if (!Directory.Exists(logDirectory.FullPath))
                {
                    createDirectory();
                }

                if (logFile.Type.Equals(FileType.xml))
                {
                    //Log to xml file
                    if (!File.Exists(getFullFilePath()))
                    {
                        createXmlFile();
                    }

                    logToXml(messageTag, message, id);
                }
                else if (logFile.Type.Equals(FileType.json))
                {
                    //Log to json file
                    if (!File.Exists(getFullFilePath()))
                    {
                        createJsonFile();
                    }

                    logToJson(messageTag, message, id);
                }
                else if (logFile.Type.Equals(FileType.txt) || logFile.Type.Equals(FileType.log))
                {
                    //Default log (.txt and .log file)
                    File.AppendAllText(getFullFilePath(), messageBuilder(messageTag, message, id), messageFormat.TextEncoding);
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
        public async Task logAsync(string message)
        {
            try
            {
                Task logTask = Task.Run(() => log(message));
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
        public async Task logAsync(Tag messageTag, string message)
        {
            try
            {
                Task logTask = Task.Run(() => log(messageTag, message));
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
        public async Task<string> logIDAsync(string message, bool verifyMessageID = false)
        {
            try
            {
                Task<string> logTask = Task.Run(() => logID(message, verifyMessageID));
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
        public async Task<string> logIDAsync(Tag messageTag, string message, bool verifyMessageID = false)
        {
            try
            {
                Task<string> logTask = Task.Run(() => logID(messageTag, message, verifyMessageID));
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
        public async Task logCustomIDAsync(string id, string message)
        {
            try
            {
                Task logTask = Task.Run(() => logCustomID(id, message));
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
        public async Task logCustomIDAsync(string id, Tag messageTag, string message)
        {
            try
            {
                Task logTask = Task.Run(() => logCustomID(id, messageTag, message));
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
        public string getFullFilePath()
        {
            return logDirectory.FullPath + "\\" + logFile.FullName;
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
        public void deleteLogFile()
        {
            try
            {
                File.Delete(getFullFilePath());
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //----------------------------------------------------------------------------------------------

        //-Private-Methods------------------------------------------------------------------------------

        private string getCurrentTime()
        {
            try
            {
                string start = "";
                string end = "";
                if (logFile.Type.Equals(FileType.txt) || logFile.Type.Equals(FileType.log))
                {
                    start = "[";
                    end = "] ";
                }

                if (messageFormat.Date.Format.Equals(DateFormat.none) &&
                        !messageFormat.Time.Format.Equals(TimeFormat.none))
                {
                    return DateTime.Now.ToString(start + messageFormat.Time.FormatString + end,
                                                messageFormat.Time.CultureFormat);
                }
                else if (!messageFormat.Date.Format.Equals(DateFormat.none) &&
                            messageFormat.Time.Format.Equals(TimeFormat.none))
                {
                    return DateTime.Now.ToString(start + messageFormat.Date.FormatString + end,
                                                messageFormat.Time.CultureFormat);
                }
                else if (messageFormat.Date.Format.Equals(DateFormat.none) &&
                            messageFormat.Time.Format.Equals(TimeFormat.none))
                {
                    return "";
                }
                else
                {
                    return DateTime.Now.ToString(start + messageFormat.Date.FormatString + (char)32 +
                                        messageFormat.Time.FormatString + end, messageFormat.Time.CultureFormat);
                }
            }
            catch (Exception)
            {
                return "[INVALID DATETIME FORMAT] ";
            }
        }

        private void createDirectory()
        {
            try
            {
                if (!Directory.Exists(logDirectory.FullPath))
                {
                    Directory.CreateDirectory(logDirectory.FullPath);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void createXmlFile()
        {
            try
            {
                if (!File.Exists(getFullFilePath()))
                {
                    XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
                    xmlWriterSettings.Encoding = messageFormat.TextEncoding;

                    XmlWriter xmlWriter = XmlWriter.Create(getFullFilePath(), xmlWriterSettings);

                    xmlWriter.WriteStartDocument();
                    xmlWriter.WriteStartElement(logFile.Name);
                    xmlWriter.WriteEndElement();
                    xmlWriter.Close();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void createJsonFile()
        {
            try
            {
                if (!File.Exists(getFullFilePath()))
                {
                    File.WriteAllText(getFullFilePath(), "[]");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private string generateID()
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

        private string verifyID(string id)
        {
            try
            {
                string tempId = id;

                if (File.Exists(logDirectory.FullPath + "/" + logFile.FullName))
                {
                    string fileContent = File.ReadAllText(logDirectory.FullPath + "/" + logFile.FullName);

                    while (fileContent.Contains(tempId))
                    {
                        tempId = generateID();
                    }
                }

                return tempId;
            }
            catch (Exception)
            {
                return id;
            }
        }

        private string messageBuilder(Tag messageTag, string message, string id = "")
        {
            string dateTimePart = getCurrentTime();
            string tagPart = "";
            string idPart = "";

            if (!messageTag.Equals(Tag.none))
            {
                tagPart = "[" + messageTag + "] ";
            }

            if (!id.Equals(""))
            {
                idPart = "[ID:" + id + "] ";
            }

            return dateTimePart + tagPart + idPart + message + "\n";
        }

        private void logToXml(Tag messageTag, string message, string id = "")
        {
            try
            {
                //Load the xml file
                XmlDocument xmlFile = new XmlDocument();
                xmlFile.Load(getFullFilePath());

                //Get the root node from the file
                XmlNode rootNode = xmlFile.SelectSingleNode(logFile.Name);

                //Create nodes and add data
                XmlNode logMessageNode = xmlFile.CreateElement("LogMessage");
                XmlAttribute idAttribute = xmlFile.CreateAttribute("id");
                if (!id.Equals(""))
                {
                    idAttribute.Value = id;
                }
                logMessageNode.Attributes.Append(idAttribute);

                XmlNode timestampNode = xmlFile.CreateElement("timestamp");
                if (!messageFormat.Date.Format.Equals(DateFormat.none) ||
                                !messageFormat.Time.Format.Equals(TimeFormat.none))
                {
                    timestampNode.InnerText = getCurrentTime();
                }
                logMessageNode.AppendChild(timestampNode);

                XmlNode tagNode = xmlFile.CreateElement("tag");
                if (!messageTag.Equals(Tag.none))
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
                xmlFile.Save(getFullFilePath());
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void logToJson(Tag messageTag, string message, string id = "")
        {
            try
            {
                string fileContent = File.ReadAllText(getFullFilePath());

                List<LogMessageModel> logs = JsonSerializer.Deserialize<List<LogMessageModel>>(fileContent);

                LogMessageModel newLog = new LogMessageModel();
                if (!id.Equals(""))
                {
                    newLog.id = id;
                }

                if (!messageFormat.Date.Format.Equals(DateFormat.none) ||
                                    !messageFormat.Time.Format.Equals(TimeFormat.none))
                {
                    newLog.timestamp = getCurrentTime();
                }

                if (!messageTag.Equals(Tag.none))
                {
                    newLog.tag = messageTag.ToString();
                }

                newLog.message = message;

                logs.Add(newLog);

                string newFileContent = JsonSerializer.Serialize(logs);

                FileStream fileWriter = File.OpenWrite(getFullFilePath());
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

namespace BasicxLogger.LoggerFile
{
    /// <summary>
    /// Contains all informations about the log file
    /// </summary>
    [Obsolete("This class is obsolete and won't receive updates. It only exists for the also obsolete Logger class", false)]
    public class LogFile
    {
        /// <summary>
        /// Name of the log file
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// File type of the log file
        /// </summary>
        public FileType Type { get; }
        /// <summary>
        /// Full file name (name + file type : e.g. sample.txt)
        /// </summary>
        public string FullName { get; }

        /// <summary>
        /// Constructor, to create a LogFile object.
        /// </summary>
        /// <remarks>
        /// Can be used to configure a custom file for the logger
        /// </remarks>
        /// <param name="name">
        /// Name of the log file
        /// </param>
        /// <param name="type">
        /// File type of the log file
        /// </param>
        public LogFile(string name, FileType type)
        {
            this.Name = name;
            this.Type = type;
            this.FullName = name + "." + type;
        }
    }
    /// <summary>
    /// Enum that contains every supported file type
    /// </summary>
    [Obsolete("This class is obsolete and won't receive updates. It only exists for the also obsolete Logger class", false)]
    public enum FileType
    {
        /// <summary>
        /// File type: .txt
        /// </summary>
        txt,
        /// <summary>
        /// File type: .log
        /// </summary>
        log,
        /// <summary>
        /// File type: .xml
        /// </summary>
        xml,
        /// <summary>
        /// File type: .json
        /// </summary>
        json
    }

}

namespace BasicxLogger.LoggerDirectory
{
    /// <summary>
    /// Contains all informations about the log directory
    /// </summary>
    [Obsolete("This class is obsolete and won't receive updates. It only exists for the also obsolete Logger class", false)]
    public class LogDirectory
    {
        /// <summary>
        /// Path were the log directory is located
        /// </summary>
        public string Path { get; }
        /// <summary>
        /// Name of the log directory
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Full directory path (path + name)
        /// </summary>
        public string FullPath { get; }

        /// <summary>
        /// Constructor, to create a LogDirectory object.
        /// </summary>
        /// <remarks>
        /// Can be used to configure a custom directory for the logger
        /// </remarks>
        /// <param name="path">
        /// Path where the directory is located
        /// </param>
        /// <param name="name">
        /// Name of the log directory
        /// </param>
        public LogDirectory(string path, string name)
        {
            this.Path = path;
            this.Name = name;
            this.FullPath = this.Path + "\\" + this.Name;
        }
    }

}

namespace BasicxLogger.Message
{
    /// <summary>
    /// Contains the information about the date formatting for the log message
    /// </summary>
    [Obsolete("This class is obsolete and won't receive updates. It only exists for the also obsolete Logger class", false)]
    public class Date
    {
        /// <summary>
        /// Enum that contains the formate of the date
        /// </summary>
        public DateFormat Format { get; }
        /// <summary>
        /// Char that separates each part of the date
        /// </summary>
        public char Separator { get; } = '/';
        /// <summary>
        /// Format string for the date (e.g. yyyy'-'MM'-'dd)
        /// </summary>
        public string FormatString { get; }


        private List<string> _dateFormateList;

        /// <summary>
        /// Constructor, to create a Date object.
        /// </summary>
        /// <remarks>
        /// Can be used to configure a custom date formate for the logger message formate
        /// </remarks>
        /// <param name="dateFormat">
        /// Enum that contains the formate of the date
        /// </param>
        public Date(DateFormat dateFormat)
        {
            InitalizeList();
            this.Format = dateFormat;
            FormatString = _dateFormateList[(int)this.Format];
        }
        /// <summary>
        /// Constructor, to create a Date object.
        /// </summary>
        /// <remarks>
        /// Can be used to configure a custom date formate for the logger message formate
        /// </remarks>
        /// <param name="dateFormat">
        /// Enum that contains the formate of the date
        /// </param>
        /// <param name="dateSeparator">
        /// Char that separates each part of the date
        /// </param>
        public Date(DateFormat dateFormat, char dateSeparator)
        {
            this.Separator = dateSeparator;
            InitalizeList();
            this.Format = dateFormat;
            FormatString = _dateFormateList[(int)this.Format];
        }


        private void InitalizeList()
        {
            _dateFormateList = new List<string>
            {
                "yyyy'" + Separator + "'MM'" + Separator + "'dd",
                "yyyy'" + Separator + "'dd'" + Separator + "'MM",
                "dd'" + Separator + "'MM'" + Separator + "'yyyy",
                "MM'" + Separator + "'dd'" + Separator + "'yyyy",
                ""
            };
        }
    }
    /// <summary>
    /// Enum that contains every supported date format
    /// </summary>
    [Obsolete("This class is obsolete and won't receive updates. It only exists for the also obsolete Logger class", false)]
    public enum DateFormat
    {
        /// <summary>
        /// Formate: "yyyy'/'MM'/'dd"
        /// </summary>
        year_month_day,
        /// <summary>
        /// Formate: "yyyy'/'dd'/'MM"
        /// </summary>
        year_day_month,
        /// <summary>
        /// Formate: "dd'/'MM'/'yyyy"
        /// </summary>
        day_month_year,
        /// <summary>
        /// Formate: "MM'/'dd'/'yyyy"
        /// </summary>
        month_day_year,
        /// <summary>
        /// Select, if you dont want to have the time in your log file
        /// </summary>
        none
    }
    /// <summary>
    /// Contains the information about the time formatting for the log message
    /// </summary>
    [Obsolete("This class is obsolete and won't receive updates. It only exists for the also obsolete Logger class", false)]
    public class Time
    {
        /// <summary>
        /// Enum that contains the formate of the time
        /// </summary>
        public TimeFormat Format { get; }
        /// <summary>
        /// Format string for the time (e.g. HH:mm:ss)
        /// </summary>
        public string FormatString { get; }
        /// <summary>
        /// Holds the culture information to correctly display AM/PM, when the 12 hour time formate is used
        /// </summary>
        public CultureInfo CultureFormat { get; } = CultureInfo.InvariantCulture;


        private List<string> _timeFormateList;

        /// <summary>
        /// Constructor, to create a Time object.
        /// </summary>
        /// <remarks>
        /// Can be used to configure a custom time formate for the logger message formate
        /// </remarks>
        /// <param name="timeFormat">
        /// Enum that contains the formate of the time
        /// </param>
        public Time(TimeFormat timeFormat)
        {
            InitalizeList();
            this.Format = timeFormat;
            FormatString = _timeFormateList[(int)this.Format];
        }
        /// <summary>
        /// Constructor, to create a Time object.
        /// </summary>
        /// <remarks>
        /// Can be used to configure a custom time formate for the logger message formate
        /// </remarks>
        /// <param name="timeFormat">
        /// Enum that contains the formate of the time
        /// </param>
        /// <param name="cultureInfo">
        /// The culture information to correctly display AM/PM, when the 12 hour time formate is used
        /// </param>
        public Time(TimeFormat timeFormat, CultureInfo cultureInfo)
        {
            InitalizeList();
            this.Format = timeFormat;
            this.CultureFormat = cultureInfo;
            FormatString = _timeFormateList[(int)this.Format];
        }

        private void InitalizeList()
        {
            _timeFormateList = new List<string>
            {
                "HH:mm",
                "HH:mm:ss",
                "HH:mm:ss.fff",
                "hh:mm tt",
                "hh:mm:ss tt",
                "hh:mm:ss.fff tt",
                ""
            };
        }
    }
    /// <summary>
    /// Enum that contains every supported time format
    /// </summary>
    [Obsolete("This class is obsolete and won't receive updates. It only exists for the also obsolete Logger class", false)]
    public enum TimeFormat
    {
        /// <summary>
        /// Formate: "HH:mm"
        /// </summary>
        hour24_min,
        /// <summary>
        /// Formate: "HH:mm:ss"
        /// </summary>
        hour24_min_sec,
        /// <summary>
        /// Formate: "HH:mm:ss.fff"
        /// </summary>
        hour24_min_sec_millisec,
        /// <summary>
        /// Formate:  "hh:mm tt"
        /// </summary>
        hour12_min,
        /// <summary>
        /// Formate:  "hh:mm:ss tt"
        /// </summary>
        hour12_min_sec,
        /// <summary>
        /// Formate: "hh:mm:ss.fff tt"
        /// </summary>
        hour12_min_sec_millisec,
        /// <summary>
        /// Select, if you dont want to have the time in your log file
        /// </summary>
        none
    }
    /// <summary>
    /// Contains all informations about the formatting of the log messages
    /// </summary>
    [Obsolete("This class is obsolete and won't receive updates. It only exists for the also obsolete Logger class", false)]
    public class MessageFormat
    {
        /// <summary>
        /// Contains the information about the date formatting for the log message
        /// </summary>
        public Date Date { get; } = new Date(DateFormat.year_month_day, '/');
        /// <summary>
        /// Contains the information about the time formatting for the log message
        /// </summary>
        public Time Time { get; } = new Time(TimeFormat.hour24_min_sec);
        /// <summary>
        /// A default message tag that will be used if no tag is selected
        /// </summary>
        public Tag DefaultTag { get; } = Tag.none;
        /// <summary>
        /// Encoding for the log message
        /// </summary>
        /// <remarks>
        /// This option is not supported for json logging and will be ignored if you log to a json file
        /// </remarks>
        public Encoding TextEncoding { get; } = Encoding.UTF8;

        /// <summary>
        /// Constructor, to create a MessageFormate object with custom settings, that can be used to customize the logger
        /// </summary>
        /// <remarks>
        /// Everything that has no custom configuration will use the default settings.
        /// </remarks>
        public MessageFormat(Tag defaultTag)
        {
            this.DefaultTag = defaultTag;
        }
        /// <summary>
        /// Constructor, to create a MessageFormate object with custom settings, that can be used to customize the logger
        /// </summary>
        /// <remarks>
        /// Everything that has no custom configuration will use the default settings.
        /// </remarks>
        public MessageFormat(Encoding encoding)
        {
            this.TextEncoding = encoding;
        }
        /// <summary>
        /// Constructor, to create a MessageFormate object with custom settings, that can be used to customize the logger
        /// </summary>
        /// <remarks>
        /// Everything that has no custom configuration will use the default settings.
        /// </remarks>
        public MessageFormat(Date date)
        {
            this.Date = date;
        }
        /// <summary>
        /// Constructor, to create a MessageFormate object with custom settings, that can be used to customize the logger
        /// </summary>
        /// <remarks>
        /// Everything that has no custom configuration will use the default settings.
        /// </remarks>
        public MessageFormat(Time time)
        {
            this.Time = time;
        }
        /// <summary>
        /// Constructor, to create a MessageFormate object with custom settings, that can be used to customize the logger
        /// </summary>
        /// <remarks>
        /// Everything that has no custom configuration will use the default settings.
        /// </remarks>
        public MessageFormat(Date date, Time time)
        {
            this.Date = date;
            this.Time = time;
        }
        /// <summary>
        /// Constructor, to create a MessageFormate object with custom settings, that can be used to customize the logger
        /// </summary>
        /// <remarks>
        /// Everything that has no custom configuration will use the default settings.
        /// </remarks>
        public MessageFormat(Date date, Tag defaultTag)
        {
            this.Date = date;
            this.DefaultTag = defaultTag;
        }
        /// <summary>
        /// Constructor, to create a MessageFormate object with custom settings, that can be used to customize the logger
        /// </summary>
        /// <remarks>
        /// Everything that has no custom configuration will use the default settings.
        /// </remarks>
        public MessageFormat(Date date, Encoding encoding)
        {
            this.Date = date;
            this.TextEncoding = encoding;
        }
        /// <summary>
        /// Constructor, to create a MessageFormate object with custom settings, that can be used to customize the logger
        /// </summary>
        /// <remarks>
        /// Everything that has no custom configuration will use the default settings.
        /// </remarks>
        public MessageFormat(Date date, Time time, Tag defaultTag)
        {
            this.Date = date;
            this.Time = time;
            this.DefaultTag = defaultTag;
        }
        /// <summary>
        /// Constructor, to create a MessageFormate object with custom settings, that can be used to customize the logger
        /// </summary>
        /// <remarks>
        /// Everything that has no custom configuration will use the default settings.
        /// </remarks>
        public MessageFormat(Date date, Tag defaultTag, Encoding encoding)
        {
            this.Date = date;
            this.DefaultTag = defaultTag;
            this.TextEncoding = encoding;
        }
        /// <summary>
        /// Constructor, to create a MessageFormate object with custom settings, that can be used to customize the logger
        /// </summary>
        /// <remarks>
        /// Everything that has no custom configuration will use the default settings.
        /// </remarks>
        public MessageFormat(Date date, Time time, Encoding encoding)
        {
            this.Date = date;
            this.TextEncoding = encoding;
            this.Time = time;
        }
        /// <summary>
        /// Constructor, to create a MessageFormate object with custom settings, that can be used to customize the logger
        /// </summary>
        /// <remarks>
        /// Everything that has no custom configuration will use the default settings.
        /// </remarks>
        public MessageFormat(Date date, Time time, Tag defaultTag, Encoding encoding)
        {
            this.Date = date;
            this.Time = time;
            this.DefaultTag = defaultTag;
            this.TextEncoding = encoding;
        }
        /// <summary>
        /// Constructor, to create a MessageFormate object with custom settings, that can be used to customize the logger
        /// </summary>
        /// <remarks>
        /// Everything that has no custom configuration will use the default settings.
        /// </remarks>
        public MessageFormat(Time time, Tag defaultTag)
        {
            this.Time = time;
            this.DefaultTag = defaultTag;
        }
        /// <summary>
        /// Constructor, to create a MessageFormate object with custom settings, that can be used to customize the logger
        /// </summary>
        /// <remarks>
        /// Everything that has no custom configuration will use the default settings.
        /// </remarks>
        public MessageFormat(Time time, Encoding encoding)
        {
            this.Time = time;
            this.TextEncoding = encoding;
        }
        /// <summary>
        /// Constructor, to create a MessageFormate object with custom settings, that can be used to customize the logger
        /// </summary>
        /// <remarks>
        /// Everything that has no custom configuration will use the default settings.
        /// </remarks>
        public MessageFormat(Time time, Tag defaultTag, Encoding encoding)
        {
            this.Time = time;
            this.DefaultTag = defaultTag;
            this.TextEncoding = encoding;
        }
    }
    /// <summary>
    /// Enum that contains every message tag you can use
    /// </summary>
    [Obsolete("This class is obsolete and won't receive updates. It only exists for the also obsolete Logger class", false)]
    public enum Tag
    {
        /// <summary>
        /// Tag: [INFO]
        /// </summary>
        INFO,
        /// <summary>
        /// Tag: [WARNING]
        /// </summary>
        WARNING,
        /// <summary>
        /// Tag: [ERROR]
        /// </summary>
        ERROR,
        /// <summary>
        /// Tag: [FATAL]
        /// </summary>
        FATAL,
        /// <summary>
        /// Tag: [EXCEPTION]
        /// </summary>
        EXCEPTION,
        /// <summary>
        /// Tag: [DEBUGGING]
        /// </summary>
        DEBUGGING,
        /// <summary>
        /// Tag: [MESSAGE]
        /// </summary>
        MESSAGE,
        /// <summary>
        /// Tag: [ALERT]
        /// </summary>
        ALERT,
        /// <summary>
        /// Tag: [EVENT]
        /// </summary>
        EVENT,
        /// <summary>
        /// Tag: [TEST]
        /// </summary>
        TEST,
        /// <summary>
        /// If you dont want to have a tag
        /// </summary>
        none
    }
}
