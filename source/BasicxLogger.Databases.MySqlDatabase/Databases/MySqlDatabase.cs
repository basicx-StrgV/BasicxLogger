//--------------------------------------------------//
// Created by basicx-StrgV                          //
// https://github.com/basicx-StrgV/BasicxLogger     //
//--------------------------------------------------//
using System;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BasicxLogger.Databases
{
    /// <summary>
    /// Class that represents a database
    /// </summary>
    public class MySqlDatabase : ILogDatabase
    {
        /// <summary>
        /// URL of the MySql database server
        /// </summary>
        /// <remarks>
        /// Set by the constructor
        /// </remarks>
        public string Server { get { return _server; } }
        /// <summary>
        /// Name of the database that will contain the logs
        /// </summary>
        /// <remarks>
        /// Set by the constructor
        /// </remarks>
        public string Database { get { return _database; } }
        /// <summary>
        /// Name of the table the logger will create and insert logs into
        /// </summary>
        public string Table { get { return _table; } }


        private readonly string _table;
        private readonly string _server;
        private readonly string _database;
        private readonly string _user;
        private readonly string _password;
        private readonly string _port;
        private readonly string _sslMode;

        private readonly MySqlConnection _connection;

        private readonly string _connectionStringTemplate = "server={0}; port={1}; user id={2}; password={3}; database={4}; SslMode={5}";


        /// <summary>
        /// Initializes a new instance of the <see cref="BasicxLogger.Databases.MySqlDatabase"/> class.
        /// </summary>
        /// <param name="server">URL of the MySql database server</param>
        /// <param name="database">Name of the database that will contain the logs</param>
        /// <param name="table">Name of the table the logger will create and insert logs into</param>
        /// <param name="user">Username of the database user you want to use</param>
        /// <param name="password">Password of the given user</param>
        /// <param name="port">Port of the database server</param>
        /// <param name="sslMode">SSL Mode setting</param>
        public MySqlDatabase(string server, string database, string table, string user, string password, string port = "3306", string sslMode = "none")
        {
            _server = server;
            _database = database;
            _user = user;
            _password = password;
            _port = port;
            _sslMode = sslMode;

            _connection = new MySqlConnection(String.Format(_connectionStringTemplate,
                                                _server, _port, _user, _password, _database, _sslMode));

            _table = table;

            CreateLogTable();
        }


        /// <summary>
        /// Writes a log message with the given data to the Table in the Database.
        /// </summary>
        /// <param name="messageTag">The message tag for the log message</param>
        /// <param name="timestamp">The timestamp for the log message</param>
        /// <param name="message">The message that should be logged</param>
        /// <param name="id">The id for the log message</param>
        public void LogToDatabase(LogTag messageTag, string timestamp, string message, string id = "")
        {
            try
            {
                CreateLogTable();

                string insertTemplate =
                "insert into {0}(entryId, messageId, messageTimestamp, tag, message) VALUES(null, {1}, {2}, {3}, '{4}')";

                _connection.Open();

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

                timestamp = "'" + timestamp + "'";


                string instertLogCmdString = String.Format(insertTemplate, Table, id, timestamp, tag, message);

                MySqlCommand instertLogCmd = new MySqlCommand(instertLogCmdString, _connection);

                Task<int> cmd = instertLogCmd.ExecuteNonQueryAsync();
                cmd.Wait();

                _connection.Close();
            }
            catch (Exception e)
            {
                _connection.Close();
                throw e;
            }
        }

        private bool CreateLogTable()
        {
            try
            {
                string createTableTemplate = "create table {0}(entryId int not null auto_increment," +
                                                                "messageId varchar(50)," +
                                                                "messageTimestamp datetime not null," +
                                                                "tag varchar(50)," +
                                                                "message varchar(500) not null," +
                                                                "primary key(entryId))";

                string createTableCmdString = String.Format(createTableTemplate, _table);

                _connection.Open();

                MySqlCommand createTableCmd = new MySqlCommand(createTableCmdString, _connection);

                Task<int> cmd = createTableCmd.ExecuteNonQueryAsync();
                cmd.Wait();

                _connection.Close();

                return true;
            }
            catch (AggregateException)
            {
                //Table already exists
                _connection.Close();
                return false;
            }
            catch (Exception e)
            {
                _connection.Close();
                throw e;
            }
        }
    }
}
