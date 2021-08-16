//--------------------------------------------------//
// Created by basicx-StrgV                          //
// https://github.com/basicx-StrgV/BasicxLogger     //
//--------------------------------------------------//
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using BasicxLogger.Base;

namespace BasicxLogger.Databases
{
    /// <summary>
    /// Class that represents a Sql database for the BasicxLogger
    /// </summary>
    public class SqlServerDatabase : ILogDatabase
    {
        /// <summary>
        /// Gets the URL of the Sql database server
        /// </summary>
        public string Server { get { return _server; } }

        /// <summary>
        /// Gets the name of the database that will contain the logs
        /// </summary>
        public string Database { get { return _database; } }

        /// <summary>
        /// Gets the name of the table the logger will create and insert logs into
        /// </summary>
        public string Table { get { return _table; } }

        private readonly string _table;
        private readonly string _server;
        private readonly string _database;
        private readonly string _user;
        private readonly string _password;

        private readonly SqlConnection _connection;

        private readonly string _connectionStringTemplate = 
            "Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}";

        /// <summary>
        /// Initializes a new instance of the <see cref="BasicxLogger.Databases.SqlServerDatabase"/> class.
        /// </summary>
        /// <param name="server">URL of the Sql Server</param>
        /// <param name="database">Name of the database that will contain the logs</param>
        /// <param name="table">Name of the table the logger will create and insert logs into</param>
        /// <param name="user">Username of the database user you want to use</param>
        /// <param name="password">Password of the given user</param>
        public SqlServerDatabase(string server, string database, string table, string user, string password)
        {
            _server = server;
            _database = database;
            _user = user;
            _password = password;

            _connection = new SqlConnection(String.Format(_connectionStringTemplate, _server, _database, _user, _password));

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
                "insert into {0}(messageId, messageTimestamp, tag, message) VALUES({1}, {2}, {3}, '{4}')";

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

                SqlCommand instertLogCmd = new SqlCommand(instertLogCmdString, _connection);

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
                string createTableTemplate = "create table {0} (" +
                                                        "entryId int IDENTITY(1,1) PRIMARY KEY," +
                                                        "messageId nvarchar(50) NULL," +
                                                        "messageTimestamp datetime NOT NULL," +
                                                        "tag nvarchar(50) NULL," +
                                                        "message nvarchar(500) NOT NULL)";

                string createTableCmdString = String.Format(createTableTemplate, _table);

                _connection.Open();

                SqlCommand createTableCommand = new SqlCommand(createTableCmdString, _connection);

                createTableCommand.ExecuteNonQuery();

                _connection.Close();

                return true;
            }
            catch (SqlException e)
            {
                _connection.Close();

                //Workarpund, because the exeption is always the same
                if (e.Message.Contains("There is already an object named"))
                {
                    //Table already exists
                    return false;
                }
                else
                {
                    throw e;
                }
            }
            catch (Exception e)
            {
                _connection.Close();
                throw e;
            }
        }
    }
}
