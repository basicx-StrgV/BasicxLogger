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
using System.Globalization;
using System.Threading.Tasks;
using System.Collections.Generic;
using BasicxLogger.Message;
using BasicxLogger.LoggerFile;
using BasicxLogger.LoggerDirectory;

namespace BasicxLogger
{
    /// <summary>
    /// Logger class that contains everything needed to write a message to a log file
    /// </summary>
    public class Logger
    {
        //-Properties-----------------------------------------------------------------------------------
        /// <summary>
        /// Contains all informations about the log file
        /// </summary>
        public LogFile logFile { get; } = new LogFile("log", LogFileType.txt);
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
                if (!Directory.Exists(logDirectory.directory))
                {
                    createDirectory();
                }

                if (logFile.type.Equals(LogFileType.xml))
                {
                    //Log to xml file
                    if (!File.Exists(getFullFilePath()))
                    {
                        createXmlFile();
                    }

                    logToXml(messageFormat.defaultTag, message);
                }
                else if(logFile.type.Equals(LogFileType.txt) || logFile.type.Equals(LogFileType.log))
                {
                    //Default log (.txt and .log file)
                    File.AppendAllText(getFullFilePath(), messageBuilder(message, messageFormat.defaultTag), messageFormat.encoding);
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
                if (!Directory.Exists(logDirectory.directory))
                {
                    createDirectory();
                }

                if (logFile.type.Equals(LogFileType.xml))
                {
                    //Log to xml file
                    if (!File.Exists(getFullFilePath()))
                    {
                        createXmlFile();
                    }

                    logToXml(messageTag, message);
                }
                else if (logFile.type.Equals(LogFileType.txt) || logFile.type.Equals(LogFileType.log))
                {
                    //Default log (.txt and .log file)
                    File.AppendAllText(getFullFilePath(), messageBuilder(message, messageTag), messageFormat.encoding);
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
                if (!Directory.Exists(logDirectory.directory))
                {
                    createDirectory();
                }

                string id = generateID();
                if (verifyMessageID)
                {
                    id = verifyID(id);
                }

                if (logFile.type.Equals(LogFileType.xml))
                {
                    //Log to xml file
                    if (!File.Exists(getFullFilePath()))
                    {
                        createXmlFile();
                    }

                    logToXml(messageFormat.defaultTag, message, id);
                }
                else if (logFile.type.Equals(LogFileType.txt) || logFile.type.Equals(LogFileType.log))
                {
                    //Default log (.txt and .log file)
                    File.AppendAllText(getFullFilePath(), messageBuilder(message, messageFormat.defaultTag, id), messageFormat.encoding);
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
                if (!Directory.Exists(logDirectory.directory))
                {
                    createDirectory();
                }

                string id = generateID();
                if (verifyMessageID)
                {
                    id = verifyID(id);
                }

                if (logFile.type.Equals(LogFileType.xml))
                {
                    //Log to xml file
                    if (!File.Exists(getFullFilePath()))
                    {
                        createXmlFile();
                    }

                    logToXml(messageTag, message, id);
                }
                else if (logFile.type.Equals(LogFileType.txt) || logFile.type.Equals(LogFileType.log))
                {
                    //Default log (.txt and .log file)
                    File.AppendAllText(getFullFilePath(), messageBuilder(message, messageTag, id), messageFormat.encoding);
                }

                return id;
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
        //-------------------

        /// <returns>
        /// The full file path (e.g. C:\mypath\myfile.txt)
        /// </returns>
        public string getFullFilePath()
        {
            return logDirectory.directory + "\\" + logFile.file;
        }

        /// <summary>
        /// Deletes the log file, that was created by the logger.
        /// </summary>
        /// <remarks>
        /// All logs will be lost. If you log again after deleting the log file the logger will create a new file.
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
            catch(Exception e)
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
                if (logFile.type.Equals(LogFileType.txt) || logFile.type.Equals(LogFileType.log))
                {
                    start = "[";
                    end = "] ";
                }

                if (messageFormat.date.dateFormat.Equals(DateFormat.none) &&
                        !messageFormat.time.timeFormat.Equals(TimeFormat.none))
                {
                    return DateTime.Now.ToString(start + messageFormat.time.timeFormatString + end, 
                                                messageFormat.time.cultureInfo);
                }
                else if (!messageFormat.date.dateFormat.Equals(DateFormat.none) &&
                            messageFormat.time.timeFormat.Equals(TimeFormat.none))
                {
                    return DateTime.Now.ToString(start + messageFormat.date.dateFormatString + end, 
                                                messageFormat.time.cultureInfo);
                }
                else if (messageFormat.date.dateFormat.Equals(DateFormat.none) && 
                            messageFormat.time.timeFormat.Equals(TimeFormat.none))
                {
                    return "";
                }
                else
                {
                    return DateTime.Now.ToString(start + messageFormat.date.dateFormatString + (char)32 +
                                        messageFormat.time.timeFormatString + end, messageFormat.time.cultureInfo);
                }
            }
            catch(Exception)
            {
                return "[INVALID DATETIME FORMAT] ";
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
    
        private void createXmlFile()
        {
            try
            {
                if (!File.Exists(getFullFilePath()))
                {
                    XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
                    xmlWriterSettings.Encoding = messageFormat.encoding;

                    XmlWriter xmlWriter = XmlWriter.Create(getFullFilePath(), xmlWriterSettings);

                    xmlWriter.WriteStartDocument();
                    xmlWriter.WriteStartElement(logFile.name);
                    xmlWriter.WriteEndElement();
                    xmlWriter.Close();
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

                if (File.Exists(logDirectory.directory + "/" + logFile.file))
                {
                    string fileContent = File.ReadAllText(logDirectory.directory + "/" + logFile.file);

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

        private string messageBuilder(string message, Tag messageTag, string id = "")
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
                XmlNode rootNode = xmlFile.SelectSingleNode(logFile.name);

                //Create nodes and add data
                XmlNode logMessageNode = xmlFile.CreateElement("LogMessage");
                if (!id.Equals(""))
                {
                    XmlAttribute idAttribute = xmlFile.CreateAttribute("id");
                    idAttribute.Value = id;
                    logMessageNode.Attributes.Append(idAttribute);
                }

                XmlNode datetimeNode = xmlFile.CreateElement("datetime");
                if (!messageFormat.date.dateFormat.Equals(DateFormat.none) ||
                                !messageFormat.time.timeFormat.Equals(TimeFormat.none))
                {
                    datetimeNode.InnerText = getCurrentTime();
                    logMessageNode.AppendChild(datetimeNode);
                }


                XmlNode tagNode = xmlFile.CreateElement("tag");
                if (!messageTag.Equals(Tag.none))
                {
                    tagNode.InnerText = messageTag.ToString();
                    logMessageNode.AppendChild(tagNode);
                }

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
        //----------------------------------------------------------------------------------------------
    }
}
