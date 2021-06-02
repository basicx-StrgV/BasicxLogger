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
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
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
        /// Holds all informations about the MySqlDatabase used for logging
        /// </summary>
        public MySqlDatabase mySqlDatabase { get; }
        /// <summary>
        /// Contains all informations about the formatting of the log messages
        /// </summary>
        public MessageFormat messageFormat { get; } = new MessageFormat(new Date(DateFormat.year_month_day, '/'), new Time(TimeFormat.hour24_min_sec, CultureInfo.InvariantCulture));
        //----------------------------------------------------------------------------------------------

        //-Constructors---------------------------------------------------------------------------------
        /// <summary>
        /// Constructor to create a MySqlLogger
        /// </summary>
        /// <remarks>
        /// The messege formate will use the default settings with this constructor
        /// </remarks>
        /// <param name="mySqlDatabase">Holds all informations about the MySqlDatabase used for logging</param>
        /// <param name="logTableName">Name of the table the logger will log to. This table will be created by the logger.</param>
        public MySqlLogger(MySqlDatabase mySqlDatabase, string logTableName)
        {
            try
            {
                this.mySqlDatabase = mySqlDatabase;

                createLogTable(logTableName);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// Constructor to create a MySqlLogger
        /// </summary>
        /// <param name="mySqlDatabase">Holds all informations about the MySqlDatabase used for logging</param>
        /// <param name="logTableName">Name of the table the logger will log to. This table will be created by the logger.</param>
        /// <param name="messageFormat">Contains all informations about the formatting of the log messages</param>
        public MySqlLogger(MySqlDatabase mySqlDatabase, string logTableName, MessageFormat messageFormat)
        {
            try
            {
                this.mySqlDatabase = mySqlDatabase;
                this.messageFormat = messageFormat;

                createLogTable(logTableName);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //----------------------------------------------------------------------------------------------

        //-Public-Methods-------------------------------------------------------------------------------
        public void log(string message)
        {
            throw new NotImplementedException();
        }

        public void log(Tag messageTag, string message)
        {
            throw new NotImplementedException();
        }

        public string logID(string message, bool verifyMessageID = false)
        {
            throw new NotImplementedException();
        }

        public string logID(Tag messageTag, string message, bool verifyMessageID = false)
        {
            throw new NotImplementedException();
        }

        public void logCustomID(string id, string message)
        {
            throw new NotImplementedException();
        }

        public void logCustomID(string id, Tag messageTag, string message)
        {
            throw new NotImplementedException();
        }

        //-Async-methods-----
        public Task logAsync(string message)
        {
            throw new NotImplementedException();
        }

        public Task logAsync(Tag messageTag, string message)
        {
            throw new NotImplementedException();
        }

        public Task<string> logIDAsync(string message, bool verifyMessageID = false)
        {
            throw new NotImplementedException();
        }

        public Task<string> logIDAsync(Tag messageTag, string message, bool verifyMessageID = false)
        {
            throw new NotImplementedException();
        }

        public Task logCustomIDAsync(string id, string message)
        {
            throw new NotImplementedException();
        }

        public Task logCustomIDAsync(string id, Tag messageTag, string message)
        {
            throw new NotImplementedException();
        }
        //-------------------

        //----------------------------------------------------------------------------------------------

        //-Private-Methods------------------------------------------------------------------------------
        private void createLogTable(string logTableName)
        {
            try
            {
                mySqlDatabase.connection.Open();

                string createTableCmdString = String.Format("create table {0}(entryId int not null auto_increment," +
                                                            "messageId varchar(10)," +
                                                            "messageTimestamp datetime not null," +
                                                            "tag varchar(20)," +
                                                            "message varchar(100) not null," +
                                                            "primary key(entryId))", logTableName);
                MySqlCommand createTableCmd = new MySqlCommand(createTableCmdString, mySqlDatabase.connection);

                Task<int> cmd = createTableCmd.ExecuteNonQueryAsync();
                cmd.Wait();

                mySqlDatabase.connection.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //----------------------------------------------------------------------------------------------
    }
}
