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
using System.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using BasicxLogger.Message;
using BasicxLogger.LoggerDatabase;

namespace BasicxLogger
{
    /// <summary>
    /// Logger that contains everything needed to log to an MySql database.
    /// </summary>
    public class MySqlLogger : ILogger
    {
        //-Properties-----------------------------------------------------------------------------------
        /// <summary>
        /// Name of the table the logger will create and insert logs into
        /// </summary>
        public string Table{ get; }
        /// <summary>
        /// Holds all informations about the MySqlDatabase used for logging
        /// </summary>
        public MySqlDatabase Database { get; }
        /// <summary>
        /// A default message tag that will be used if no tag is selected
        /// </summary>
        public LogTag DefaultTag { get; } = LogTag.none;
        //----------------------------------------------------------------------------------------------

        //-Constructors---------------------------------------------------------------------------------
        /// <summary>
        /// Constructor to create a MySqlLogger
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

                CreateLogTable(Table);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// Constructor to create a MySqlLogger
        /// </summary>
        /// <param name="database">
        /// Holds all informations about the MySqlDatabase used for logging
        /// </param>
        /// <param name="logTable">
        /// Name of the table the logger will log to. This table will be created by the logger.
        /// </param>
        /// <param name="defaultTag">
        /// A default message tag that will be used if no tag is selected
        /// </param>
        public MySqlLogger(MySqlDatabase database, string logTable, LogTag defaultTag)
        {
            try
            {
                this.Database = database;
                this.Table = logTable;
                this.DefaultTag = defaultTag;

                CreateLogTable(Table);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //----------------------------------------------------------------------------------------------

        //-Public-Methods-------------------------------------------------------------------------------
        /// <summary>
        /// Inserts the given message and the current time stamp into the log table.
        /// </summary>
        /// <param name="message">
        /// The message that will be writen to the file
        /// </param>
        /// <exception cref="System.FormatException"></exception>
        /// <exception cref="System.AggregateException"></exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.InvalidOperationException"></exception>
        /// <exception cref="System.Data.Common.DbException"></exception>
        public void Log(string message)
        {
            Database.Connection.Open();

            LogToTable(DefaultTag, message);

            Database.Connection.Close();
        }

        /// <summary>
        /// Inserts the given message and the current time stamp into the log table.
        /// </summary>
        /// <param name="message">
        /// The message that will be writen to the file
        /// </param>
        /// <param name="messageTag">
        /// A Tag that will be added to the message, to make it easy to distinguish between differen log messages
        /// </param>
        /// <exception cref="System.FormatException"></exception>
        /// <exception cref="System.AggregateException"></exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.InvalidOperationException"></exception>
        /// <exception cref="System.Data.Common.DbException"></exception>
        public void Log(LogTag messageTag, string message)
        {
            Database.Connection.Open();

            LogToTable(messageTag, message);

            Database.Connection.Close();
        }

        /// <summary>
        /// Inserts the given message and the current time stamp into the log table.
        /// </summary>
        /// <param name="message">
        /// The message that will be writen to the file
        /// </param>
        /// <param name="verifyMessageID">
        /// Set to true if you want to make sure the message id is unique.
        /// If set to true, the loging of the message may take longer an use more ram depending on how big your database is.
        /// </param>
        /// <returns>
        /// The message ID that was automatically assigned to the message. It can be used to identify a specific message.
        /// </returns>
        /// <exception cref="System.FormatException"></exception>
        /// <exception cref="System.AggregateException"></exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.InvalidOperationException"></exception>
        /// <exception cref="System.Data.Common.DbException"></exception>
        public string LogId(string message, bool verifyMessageID = false)
        {
            Database.Connection.Open();

            string id = GetNewMessageId(verifyMessageID);

            LogToTable(DefaultTag, message, id);

            Database.Connection.Close();

            return id;
        }

        /// <summary>
        /// Inserts the given message and the current time stamp into the log table.
        /// </summary>
        /// <param name="message">
        /// The message that will be writen to the file
        /// </param>
        /// <param name="messageTag">
        /// A Tag that will be added to the message, to make it easy to distinguish between differen log messages
        /// </param>
        /// <param name="verifyMessageID">
        /// Set to true if you want to make sure the message id is unique.
        /// If set to true, the loging of the message may take longer an use more ram depending on how big your database is.
        /// </param>
        /// <returns>
        /// The message ID that was automatically assigned to the message. It can be used to identify a specific message.
        /// </returns>
        /// <exception cref="System.FormatException"></exception>
        /// <exception cref="System.AggregateException"></exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.InvalidOperationException"></exception>
        /// <exception cref="System.Data.Common.DbException"></exception>
        public string LogId(LogTag messageTag, string message, bool verifyMessageID = false)
        {
            Database.Connection.Open();

            string id = GetNewMessageId(verifyMessageID);

            LogToTable(messageTag, message, id);

            Database.Connection.Close();

            return id;
        }

        /// <summary>
        /// Inserts the given message and the current time stamp into the log table.
        /// </summary>
        /// <param name="id">
        /// The id of the log message
        /// </param>
        /// <param name="message">
        /// The message that will be writen to the file
        /// </param>
        /// <exception cref="System.FormatException"></exception>
        /// <exception cref="System.AggregateException"></exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.InvalidOperationException"></exception>
        /// <exception cref="System.Data.Common.DbException"></exception>
        public void LogCustomId(string id, string message)
        {
            Database.Connection.Open();

            LogToTable(DefaultTag, message, id);

            Database.Connection.Close();
        }

        /// <summary>
        /// Inserts the given message and the current time stamp into the log table.
        /// </summary>
        /// <param name="id">
        /// The id of the log message
        /// </param>
        /// <param name="message">
        /// The message that will be writen to the file
        /// </param>
        /// <param name="messageTag">
        /// A Tag that will be added to the message, to make it easy to distinguish between differen log messages
        /// </param>
        /// <exception cref="System.FormatException"></exception>
        /// <exception cref="System.AggregateException"></exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.InvalidOperationException"></exception>
        /// <exception cref="System.Data.Common.DbException"></exception>
        public void LogCustomId(string id, LogTag messageTag, string message)
        {
            Database.Connection.Open();

            LogToTable(messageTag, message, id);

            Database.Connection.Close();
        }

        //-Async-methods-----
        /// <summary>
        /// Asynchronous inserts the given message and the current time stamp into the log table.
        /// </summary>
        /// <param name="message">
        /// The message that will be writen to the file
        /// </param>
        /// <exception cref="System.FormatException"></exception>
        /// <exception cref="System.AggregateException"></exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.InvalidOperationException"></exception>
        /// <exception cref="System.Data.Common.DbException"></exception>
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
        /// Asynchronous inserts the given message and the current time stamp into the log table.
        /// </summary>
        /// <param name="message">
        /// The message that will be writen to the file
        /// </param>
        /// <param name="messageTag">
        /// A Tag that will be added to the message, to make it easy to distinguish between differen log messages
        /// </param>
        /// <exception cref="System.FormatException"></exception>
        /// <exception cref="System.AggregateException"></exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.InvalidOperationException"></exception>
        /// <exception cref="System.Data.Common.DbException"></exception>
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
        /// Asynchronous inserts the given message and the current time stamp into the log table.
        /// </summary>
        /// <param name="message">
        /// The message that will be writen to the file
        /// </param>
        /// <param name="verifyMessageID">
        /// Set to true if you want to make sure the message id is unique.
        /// If set to true, the loging of the message may take longer an use more ram depending on how big your database is.
        /// </param>
        /// <returns>
        /// The message ID that was automatically assigned to the message. It can be used to identify a specific message.
        /// </returns>
        /// <exception cref="System.FormatException"></exception>
        /// <exception cref="System.AggregateException"></exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.InvalidOperationException"></exception>
        /// <exception cref="System.Data.Common.DbException"></exception>
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
        /// Asynchronous inserts the given message and the current time stamp into the log table.
        /// </summary>
        /// <param name="message">
        /// The message that will be writen to the file
        /// </param>
        /// <param name="messageTag">
        /// A Tag that will be added to the message, to make it easy to distinguish between differen log messages
        /// </param>
        /// <param name="verifyMessageID">
        /// Set to true if you want to make sure the message id is unique.
        /// If set to true, the loging of the message may take longer an use more ram depending on how big your database is.
        /// </param>
        /// <returns>
        /// The message ID that was automatically assigned to the message. It can be used to identify a specific message.
        /// </returns>
        /// <exception cref="System.FormatException"></exception>
        /// <exception cref="System.AggregateException"></exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.InvalidOperationException"></exception>
        /// <exception cref="System.Data.Common.DbException"></exception>
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
        /// Asynchronous inserts the given message and the current time stamp into the log table.
        /// </summary>
        /// <param name="id">
        /// The id of the log message
        /// </param>
        /// <param name="message">
        /// The message that will be writen to the file
        /// </param>
        /// <exception cref="System.FormatException"></exception>
        /// <exception cref="System.AggregateException"></exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.InvalidOperationException"></exception>
        /// <exception cref="System.Data.Common.DbException"></exception>
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
        /// Asynchronous inserts the given message and the current time stamp into the log table.
        /// </summary>
        /// <param name="id">
        /// The id of the log message
        /// </param>
        /// <param name="message">
        /// The message that will be writen to the file
        /// </param>
        /// <param name="messageTag">
        /// A Tag that will be added to the message, to make it easy to distinguish between differen log messages
        /// </param>
        /// <exception cref="System.FormatException"></exception>
        /// <exception cref="System.AggregateException"></exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.InvalidOperationException"></exception>
        /// <exception cref="System.Data.Common.DbException"></exception>
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

        private string GetNewMessageId(bool verifyMessageID = false)
        {
            try
            {
                string id = GenerateId();
                if (verifyMessageID)
                {
                    id = VerifyId(id);
                }

                return id;
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

                while (GetIdEntryCount(id) > 0)
                {
                    tempId = GenerateId();
                }

                return tempId;
            }
            catch (Exception)
            {
                return id;
            }
        }

        private long GetIdEntryCount(string id)
        {
            try
            {
                string selectIdCountTemplate = "select count(*) from {0} where messageId = '{1}'";

                string selectIdCountCmdString = String.Format(selectIdCountTemplate, Table, id);

                MySqlCommand selectIdCountCmd = new MySqlCommand(selectIdCountCmdString, Database.Connection);

                DataTable dataTable = new DataTable();
                new MySqlDataAdapter(selectIdCountCmd).Fill(dataTable);

                long entrys = (long)dataTable.Select()[0].ItemArray[0];

                dataTable.Dispose();

                return entrys;
            }
            catch (Exception e)
            {
                throw e;
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
        //----------------------------------------------------------------------------------------------
    }
}
