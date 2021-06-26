//--------------------------------------------------//
// Created by basicx-StrgV                          //
// https://github.com/basicx-StrgV/BasicxLogger     //
//--------------------------------------------------//
using System.Text;

namespace BasicxLogger.Base
{
    /// <summary>
    /// Interface that represents a file for the <see cref="BasicxLogger.FileLogger"/>
    /// </summary>
    public interface ILogFile
    {
        /// <summary>
        /// Gets or Sets the text encoding for the file.
        /// </summary>
        Encoding TextEncoding { get; set; }

        /// <summary>
        /// Gets a string representing the directory's full path.
        /// </summary>
        string DirectoryName { get; }

        /// <summary>
        /// Gets the full path of the file.
        /// </summary>
        string FullName { get; }

        /// <summary>
        /// Gets the string representing the extension part of the file.
        /// </summary>
        string Extension { get; }

        /// <summary>
        /// Writes a log message with the given data to the log file.
        /// </summary>
        /// <param name="messageTag">The message tag for the log message</param>
        /// <param name="timestamp">The timestamp for the log message</param>
        /// <param name="message">The message that should be logged</param>
        /// <param name="id">The id for the log message</param>
        void WriteToFile(LogTag messageTag, string timestamp, string message, string id = "");
    }
}
