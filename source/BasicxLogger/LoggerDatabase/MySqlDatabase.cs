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
        public string Server { get; }
        /// <summary>
        /// Name of the database that will contain the logs
        /// </summary>
        /// <remarks>
        /// Set by the constructor
        /// </remarks>
        public string DatabaseName { get; }
        /// <summary>
        /// Username of the database user you want to use
        /// </summary>
        /// <remarks>
        /// Set by the constructor
        /// </remarks>
        public string User { get; }
        /// <summary>
        /// Password of the given user
        /// </summary>
        /// <remarks>
        /// Set by the constructor
        /// </remarks>
        public string Password { get; }
        /// <summary>
        /// Port of the database server
        /// </summary>
        /// <remarks>
        /// Set by the constructor
        /// </remarks>
        public string Port { get; }
        /// <summary>
        /// SSL Mode setting
        /// </summary>
        /// <remarks>
        /// Set by the constructor
        /// </remarks>
        public string SslMode { get; }
        /// <summary>
        /// The database connection
        /// </summary>
        /// <remarks>
        /// Set by the constructor
        /// </remarks>
        public MySqlConnection Connection { get; }


        private string _connectionStringTemplate = "server={0}; port={1}; user id={2}; password={3}; database={4}; SslMode={5}";


        /// <summary>
        /// Constructor to creates a new MySqlDatabase object
        /// </summary>
        /// <param name="server">URL of the MySql database server</param>
        /// <param name="databaseName">Name of the database that will contain the logs</param>
        /// <param name="user">Username of the database user you want to use</param>
        /// <param name="password">Password of the given user</param>
        /// <param name="port">Port of the database server</param>
        /// <param name="sslMode">SSL Mode setting</param>
        public MySqlDatabase(string server, string databaseName, string user, string password, string port = "3306", string sslMode = "none")
        {
            this.Server = server;
            this.DatabaseName = databaseName;
            this.User = user;
            this.Password = password;
            this.Port = port;
            this.SslMode = sslMode;

            Connection = new MySqlConnection(String.Format(_connectionStringTemplate,
                                                this.Server, this.Port, this.User, this.Password, this.DatabaseName, this.SslMode));
        }
    }
}
