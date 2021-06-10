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
using System.Threading.Tasks;

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
        /// The log file of the logger.
        /// </summary>
        /// <remarks>
        /// The file name must contain the full path and the file extension.
        /// Supportet file extension are: .txt, .log, .json, .xml
        /// </remarks>
        public FileInfo LogFile { get; } = new FileInfo(
            String.Format("{0}/{1}/Log.txt", Environment.CurrentDirectory, "Logs")); 

        /// <summary>
        /// Timestamp used for the logging
        /// </summary>
        public Timestamp MessageTimestamp { get; } = new Timestamp(TimestampFormat.year_month_day_hour24_min_sec);

        /// <summary>
        /// A default message tag that will be used if no tag is selected
        /// </summary>
        public LogTag DefaultTag { get; set; } = LogTag.none;

        /// <summary>
        /// The text encoding used by the logger
        /// </summary>
        public Encoding TextEncoding { get; set; } = Encoding.UTF8;
        //----------------------------------------------------------------------------------------------

        //-Constructors---------------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the <see cref="BasicxLogger.FileLogger"/> class
        /// </summary>
        /// <param name="logFile">The log file of the logger</param>
        public FileLogger(FileInfo logFile)
        {
            LogFile = logFile;
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
                WriteMessageToLogFile(DefaultTag, message);
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
                WriteMessageToLogFile(messageTag, message);
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
        public string LogId(string message)
        {
            try
            {
                string id = IdHandler.UniqueId;

                WriteMessageToLogFile(DefaultTag, message, id);

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
        public string LogId(LogTag messageTag, string message)
        {
            try
            {
                string id = IdHandler.UniqueId;

                WriteMessageToLogFile(messageTag, message, id);

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
                WriteMessageToLogFile(DefaultTag, message, id);
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
                WriteMessageToLogFile(messageTag, message, id);
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
        public async Task<string> LogIdAsync(string message)
        {
            try
            {
                Task<string> logTask = Task.Run(() => LogId(message));
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
        public async Task<string> LogIdAsync(LogTag messageTag, string message)
        {
            try
            {
                Task<string> logTask = Task.Run(() => LogId(messageTag, message));
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


        //----------------------------------------------------------------------------------------------

        //-Private-Methods------------------------------------------------------------------------------

        private void CreateDirectory()
        {
            try
            {
                if (!Directory.Exists(LogFile.DirectoryName))
                {
                    Directory.CreateDirectory(LogFile.DirectoryName);
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
                if (!File.Exists(LogFile.FullName))
                {
                    XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
                    xmlWriterSettings.Encoding = TextEncoding;

                    XmlWriter xmlWriter = XmlWriter.Create(LogFile.FullName, xmlWriterSettings);

                    xmlWriter.WriteStartDocument();
                    xmlWriter.WriteStartElement("entrys");
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
                if (!File.Exists(LogFile.FullName))
                {
                    File.WriteAllText(LogFile.FullName, "{ \"entrys\": []}");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void WriteMessageToLogFile(LogTag messageTag, string message, string id = "")
        {
            try
            {
                if (!Directory.Exists(LogFile.DirectoryName))
                {
                    CreateDirectory();
                }

                if (LogFile.Extension.Equals(".xml"))
                {
                    //Log to xml file
                    WriteXml(messageTag, message, id);
                }
                else if (LogFile.Extension.Equals(".json"))
                {
                    //Log to json file
                    WriteJson(messageTag, message, id);
                }
                else if (LogFile.Extension.Equals(".txt") || LogFile.Extension.Equals(".log"))
                {
                    //Default log (.txt and .log file)
                    File.AppendAllText(LogFile.FullName, MessageBuilder(messageTag, message, id), TextEncoding);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private string MessageBuilder(LogTag messageTag, string message, string id)
        {
            string dateTimePart = String.Format("[{0}] ", MessageTimestamp.GetTimestamp());
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

        private void WriteXml(LogTag messageTag, string message, string id)
        {
            try
            {
                if (!File.Exists(LogFile.FullName))
                {
                    CreateXmlFile();
                }

                //Load the xml file
                XmlDocument xmlFile = new XmlDocument();
                xmlFile.Load(LogFile.FullName);

                //Get the root node from the file
                XmlNode rootNode = xmlFile.SelectSingleNode("entrys");

                //Create nodes and add data
                XmlNode logMessageNode = xmlFile.CreateElement("LogMessage");
                XmlAttribute idAttribute = xmlFile.CreateAttribute("id");
                if (!id.Equals(""))
                {
                    idAttribute.Value = id;
                }
                logMessageNode.Attributes.Append(idAttribute);

                XmlNode timestampNode = xmlFile.CreateElement("timestamp");
                timestampNode.InnerText = MessageTimestamp.GetTimestamp();
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
                xmlFile.Save(LogFile.FullName);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void WriteJson(LogTag messageTag, string message, string id)
        {
            try
            {
                if (!File.Exists(LogFile.FullName))
                {
                    CreateJsonFile();
                }

                string fileContent = File.ReadAllText(LogFile.FullName);

                JsonLogModel logFile = JsonSerializer.Deserialize<JsonLogModel>(fileContent);

                LogMessageModel newLogEntry = new LogMessageModel();
                if (!id.Equals(""))
                {
                    newLogEntry.id = id;
                }

                newLogEntry.timestamp = MessageTimestamp.GetTimestamp();

                if (!messageTag.Equals(LogTag.none))
                {
                    newLogEntry.tag = messageTag.ToString();
                }

                newLogEntry.message = message;

                logFile.entrys.Add(newLogEntry);

                string newFileContent = JsonSerializer.Serialize(logFile);

                FileStream fileWriter = File.OpenWrite(LogFile.FullName);
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
