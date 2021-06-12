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
using MySql.Data.MySqlClient;
using BasicxLogger.Databases;

namespace BasicxLogger
{
    /// <summary>
    /// Logger that contains everything needed to log to an MySql database.
    /// </summary>
    public class MySqlLogger : ILogger
    {
        /// <summary>
        /// Name of the table the logger will create and insert logs into
        /// </summary>
        public string Table{ get; }
        /// <summary>
        /// Holds all informations about the MySqlDatabase used for logging
        /// </summary>
        public MySqlDatabase Database { get; }
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
        /// Initializes a new instance of the <see cref="BasicxLogger.MySqlLogger"/> class.
        /// </summary>
        /// <remarks>
        /// The messege formate will use the default settings with this constructor
        /// </remarks>
        /// <param name="database">
        /// Holds all informations about the MySqlDatabase used for logging
        /// </param>
        /// <param name="logTable">
        /// Name of the table the logger will log to. This table will be created by the logger.
        /// </param>
        public MySqlLogger(MySqlDatabase database, string logTable)
        {
            try
            {
                this.Database = database;
                this.Table = logTable;

                //CreateLogTable(Table);
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
                    Database.Connection.Open();

                    LogToTable(DefaultTag, message, id);

                    Database.Connection.Close();
                    return id;
                }
                else
                {
                    Database.Connection.Open();

                    LogToTable(DefaultTag, message);

                    Database.Connection.Close();
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
                    Database.Connection.Open();

                    LogToTable(messageTag, message, id);

                    Database.Connection.Close();
                    return id;
                }
                else
                {
                    Database.Connection.Open();

                    LogToTable(DefaultTag, message);

                    Database.Connection.Close();
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
        /// Asynchronous writes the given message to table.
        /// </summary>
        /// <param name="message">The message that will be writen to the table</param>
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


        private string GetTimestemp()
        {
            try
            {
                return DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            }
            catch (Exception)
            {
                return "0000/00/00 00:00:00";
            }
        }

        private bool CreateLogTable(string logTableName)
        {
            try
            {
                string createTableTemplate = "create table {0}(entryId int not null auto_increment," +
                                                                "messageId varchar(10)," +
                                                                "messageTimestamp datetime," +
                                                                "tag varchar(20)," +
                                                                "message varchar(100) not null," +
                                                                "primary key(entryId))";

                string createTableCmdString = String.Format(createTableTemplate, logTableName);

                Database.Connection.Open();

                MySqlCommand createTableCmd = new MySqlCommand(createTableCmdString, Database.Connection);

                Task<int> cmd = createTableCmd.ExecuteNonQueryAsync();
                cmd.Wait();

                Database.Connection.Close();

                return true;
            }
            catch (AggregateException) 
            {
                //Table already exists
                Database.Connection.Close();
                return false;
            }
            catch (Exception e)
            {
                Database.Connection.Close();
                throw e;
            }
        }
        
        private void LogToTable(LogTag messageTag, string message, string id = "")
        {
            try
            {
                string insertTemplate =
                "insert into {0}(entryId, messageId, messageTimestamp, tag, message) VALUES(null, {1}, {2}, {3}, '{4}')";

                string tag = "";
                if (messageTag.Equals(LogTag.none))
                {
                    tag = "null";
                }
                else
                {
                    tag = "'" + messageTag.ToString() + "'";
                }

                if (id.Equals(""))
                {
                    id = "null";
                }
                else
                {
                    id = "'" + id + "'";
                }

                string timestamp = "'" + GetTimestemp() + "'";
                if (timestamp.Equals(""))
                {
                    timestamp = "null";
                }

                string instertLogCmdString = String.Format(insertTemplate, Table, id, timestamp, tag, message);

                MySqlCommand instertLogCmd = new MySqlCommand(instertLogCmdString, Database.Connection);

                Task<int> cmd = instertLogCmd.ExecuteNonQueryAsync();
                cmd.Wait();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
