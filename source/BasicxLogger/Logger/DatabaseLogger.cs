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
using BasicxLogger.Base;

namespace BasicxLogger
{
    /// <summary>
    /// Logger that contains everything needed to log to an MySql database.
    /// </summary>
    public class DatabaseLogger : ILogger
    {
        /// <summary>
        /// Gets the database that the logger uses.
        /// </summary>
        public ILogDatabase Database { get; }
        /// <summary>
        /// Gets or Sets the <see cref="BasicxLogger.Timestamp"/> that is used by the logger.
        /// </summary>
        public Timestamp MessageTimestamp { get; } = Timestamp.Year_Month_Day_Hour24_Min_Sec;
        /// <summary>
        /// Gets or Sets a default message tag that will be used if no tag is selected.
        /// </summary>
        public LogTag DefaultTag { get; set; } = LogTag.none;
        /// <summary>
        /// Gets or Sets if each log entry should contain a unique id or not.
        /// </summary>
        public bool UseId { get; set; } = true;


        /// <summary>
        /// Initializes a new instance of the <see cref="BasicxLogger.DatabaseLogger"/> class.
        /// </summary>
        /// <param name="database">The database the logger should use.</param>
        public DatabaseLogger(ILogDatabase database)
        {
            Database = database;
        }


        /// <summary>
        /// Writes the given message to the table.
        /// </summary>
        /// <param name="message">The message that will be writen to the table</param>
        /// <returns>
        /// The unique id for the log entry if <see cref="BasicxLogger.DatabaseLogger.UseId"/> is true 
        /// or null if <see cref="BasicxLogger.DatabaseLogger.UseId"/> is false.
        /// </returns>
        public string Log(string message)
        {
            try
            {
                if (UseId)
                {
                    string id = IdHandler.UniqueId;

                    Database.LogToDatabase(DefaultTag, MessageTimestamp.GetTimestamp(), message, id);

                    return id;
                }
                else
                {
                    Database.LogToDatabase(DefaultTag, MessageTimestamp.GetTimestamp(), message);

                    return null;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// Writes the given message to the table.
        /// </summary>
        /// <param name="message">The message that will be writen to the table</param>
        /// <param name="messageTag">
        /// A Tag that will be added to the message, to make it easy to distinguish between differen log messages
        /// </param>
        /// <returns>
        /// The unique id for the log entry if <see cref="BasicxLogger.DatabaseLogger.UseId"/> is true 
        /// or null if <see cref="BasicxLogger.DatabaseLogger.UseId"/> is false.
        /// </returns>
        public string Log(LogTag messageTag, string message)
        {
            try
            {
                if (UseId)
                {
                    string id = IdHandler.UniqueId;

                    Database.LogToDatabase(messageTag, MessageTimestamp.GetTimestamp(), message, id);

                    return id;
                }
                else
                {
                    Database.LogToDatabase(messageTag, MessageTimestamp.GetTimestamp(), message);

                    return null;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Asynchronous writes the given message to the table.
        /// </summary>
        /// <param name="message">The message that will be writen to the table</param>
        /// <returns>
        /// The unique id for the log entry if <see cref="BasicxLogger.DatabaseLogger.UseId"/> is true 
        /// or null if <see cref="BasicxLogger.DatabaseLogger.UseId"/> is false.
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
        /// Asynchronous writes the given message to table.
        /// </summary>
        /// <param name="message">The message that will be writen to the table</param>
        /// <param name="messageTag">
        /// A Tag that will be added to the message, to make it easy to distinguish between differen log messages
        /// </param>
        /// <returns>
        /// The unique id for the log entry if <see cref="BasicxLogger.DatabaseLogger.UseId"/> is true 
        /// or null if <see cref="BasicxLogger.DatabaseLogger.UseId"/> is false.
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
