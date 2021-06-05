//--------------------------------------------------//
// Created by basicx-StrgV                          //
// https://github.com/basicx-StrgV/BasicxLogger     //
//--------------------------------------------------//
using System;
using MySql.Data.MySqlClient;

namespace BasicxLogger.LoggerDatabase
{
    /// <summary>
    /// Holds all informations about the MySqlDatabase used for logging
    /// </summary>
    public class MySqlDatabase
    {
        /// <summary>
        /// URL of the MySql database server
        /// </summary>
        /// <remarks>
        /// Set by the constructor
        /// </remarks>
        public string server { get; }
        /// <summary>
        /// Name of the database that will contain the logs
        /// </summary>
        /// <remarks>
        /// Set by the constructor
        /// </remarks>
        public string database { get; }
        /// <summary>
        /// Username of the database user you want to use
        /// </summary>
        /// <remarks>
        /// Set by the constructor
        /// </remarks>
        public string user { get; }
        /// <summary>
        /// Password of the given user
        /// </summary>
        /// <remarks>
        /// Set by the constructor
        /// </remarks>
        public string password { get; }
        /// <summary>
        /// Port of the database server
        /// </summary>
        /// <remarks>
        /// Set by the constructor
        /// </remarks>
        public string port { get; }
        /// <summary>
        /// SSL Mode setting
        /// </summary>
        /// <remarks>
        /// Set by the constructor
        /// </remarks>
        public string sslMode { get; }
        /// <summary>
        /// Connection string for the MySql database
        /// </summary>
        /// <remarks>
        /// Set by the constructor
        /// </remarks>
        public string connectionString { get; }
        /// <summary>
        /// The database connection
        /// </summary>
        /// <remarks>
        /// Set by the constructor
        /// </remarks>
        public MySqlConnection connection { get; }


        private string connectionStringTemplate = "server={0}; port={1}; user id={2}; password={3}; database={4}; SslMode={5}";


        /// <summary>
        /// Constructor to creates a new MySqlDatabase object
        /// </summary>
        /// <param name="server">URL of the MySql database server</param>
        /// <param name="database">Name of the database that will contain the logs</param>
        /// <param name="user">Username of the database user you want to use</param>
        /// <param name="password">Password of the given user</param>
        /// <param name="port">Port of the database server</param>
        /// <param name="sslMode">SSL Mode setting</param>
        public MySqlDatabase(string server, string database, string user, string password, string port = "3306", string sslMode = "none")
        {
            this.server = server;
            this.database = database;
            this.user = user;
            this.password = password;
            this.port = port;
            this.sslMode = sslMode;

            connectionString = String.Format(connectionStringTemplate,
                                                this.server, this.port, this.user, this.password, this.database, this.sslMode);

            connection = new MySqlConnection(connectionString);
        }
    }
}
