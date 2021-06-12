//--------------------------------------------------//
// Created by basicx-StrgV                          //
// https://github.com/basicx-StrgV/BasicxLogger     //
//--------------------------------------------------//
namespace BasicxLogger
{
    /// <summary>
    /// Interface that represents a database for the <see cref="BasicxLogger.DatabaseLogger"/>
    /// </summary>
    public interface ILogDatabase
    {
        /// <summary>
        /// URL of the database server
        /// </summary>
        string Server { get; }
        /// <summary>
        /// Name of the database that will contain the logs
        /// </summary>
        string Database { get; }
        /// <summary>
        /// Name of the table the logger will create and insert logs into
        /// </summary>
        string Table { get; }


        /// <summary>
        /// Writes a log message with the given data to the Table in the Database.
        /// </summary>
        /// <param name="messageTag">The message tag for the log message</param>
        /// <param name="timestamp">The timestamp for the log message</param>
        /// <param name="message">The message that should be logged</param>
        /// <param name="id">The id for the log message</param>
        void LogToDatabase(LogTag messageTag, string timestamp, string message, string id = "");
    }
}
