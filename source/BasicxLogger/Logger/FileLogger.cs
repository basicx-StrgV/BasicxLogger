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
using System.Threading.Tasks;
using BasicxLogger.Files;

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
        /// <summary>
        /// Gets the <see cref="BasicxLogger.Files.ILogFile"/> that is used by the logger.
        /// </summary>
        public ILogFile LogFile { get; } = new TxtLogFile(
            String.Format("{0}/{1}/", Environment.CurrentDirectory, "Logs"), "Log");
        /// <summary>
        /// Gets or Sets the <see cref="BasicxLogger.Timestamp"/> that is used by the logger.
        /// </summary>
        public Timestamp MessageTimestamp { get; set; } = Timestamp.Year_Month_Day_Hour24_Min_Sec;
        /// <summary>
        /// Gets or Sets a default message tag that will be used if no tag is selected.
        /// </summary>
        public LogTag DefaultTag { get; set; } = LogTag.none;
        /// <summary>
        /// Gets or Sets if each log entry should contain a unique id or not.
        /// </summary>
        public bool UseId { get; set; } = true;


        /// <summary>
        /// Initializes a new instance of the <see cref="BasicxLogger.FileLogger"/> class,
        /// that uses the default settings.
        /// </summary>
        public FileLogger()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="BasicxLogger.FileLogger"/> class.
        /// </summary>
        /// <param name="logFile">The log file of the logger</param>
        public FileLogger(ILogFile logFile)
        {
            LogFile = logFile;
        }


        /// <summary>
        /// Writes the given message to the log file.
        /// </summary>
        /// <param name="message">The message that will be writen to the file</param>
        /// <returns>
        /// The unique id for the log entry if <see cref="BasicxLogger.FileLogger.UseId"/> is true 
        /// or null if <see cref="BasicxLogger.FileLogger.UseId"/> is false.
        /// </returns>
        public string Log(string message)
        {
            try
            {
                if (UseId)
                {
                    string id = IdHandler.UniqueId;
                    LogFile.WriteToFile(DefaultTag, MessageTimestamp.GetTimestamp(), message, id);
                    return id;
                }
                else
                {
                    LogFile.WriteToFile(DefaultTag, MessageTimestamp.GetTimestamp(), message);
                    return null;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// Writes the given message to the log file.
        /// </summary>
        /// <param name="message">The message that will be writen to the file</param>
        /// <param name="messageTag">
        /// A Tag that will be added to the message, to make it easy to distinguish between differen log messages
        /// </param>
        /// <returns>
        /// The unique id for the log entry if <see cref="BasicxLogger.FileLogger.UseId"/> is true 
        /// or null if <see cref="BasicxLogger.FileLogger.UseId"/> is false.
        /// </returns>
        public string Log(LogTag messageTag, string message)
        {
            try
            {
                if (UseId)
                {
                    string id = IdHandler.UniqueId;
                    LogFile.WriteToFile(messageTag, MessageTimestamp.GetTimestamp(), message, id);
                    return id;
                }
                else
                {
                    LogFile.WriteToFile(messageTag, MessageTimestamp.GetTimestamp(), message);
                    return null;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Asynchronous writes the given message to the log file.
        /// </summary>
        /// <param name="message">The message that will be writen to the file</param>
        /// <returns>
        /// The unique id for the log entry if <see cref="BasicxLogger.FileLogger.UseId"/> is true 
        /// or null if <see cref="BasicxLogger.FileLogger.UseId"/> is false.
        /// </returns>
        public async Task<string> LogAsync(string message)
        {
            try
            {
                Task<string> logTask = Task.Run(() => Log(message));
                await logTask;
                return logTask.Result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// Asynchronous writes the given message to the log file.
        /// </summary>
        /// <param name="message">The message that will be writen to the file</param>
        /// <param name="messageTag">
        /// A Tag that will be added to the message, to make it easy to distinguish between differen log messages
        /// </param>
        /// <returns>
        /// The unique id for the log entry if <see cref="BasicxLogger.FileLogger.UseId"/> is true 
        /// or null if <see cref="BasicxLogger.FileLogger.UseId"/> is false.
        /// </returns>
        public async Task<string> LogAsync(LogTag messageTag, string message)
        {
            try
            {
                Task<string> logTask = Task.Run(() => Log(messageTag, message));
                await logTask;
                return logTask.Result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
