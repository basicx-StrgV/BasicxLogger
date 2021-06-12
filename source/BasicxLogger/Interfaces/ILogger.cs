//--------------------------------------------------//
// Created by basicx-StrgV                          //
// https://github.com/basicx-StrgV/BasicxLogger     //
//--------------------------------------------------//
using System.Threading.Tasks;

namespace BasicxLogger
{
    /// <summary>
    /// Interface for BasicxLogger
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Gets the <see cref="BasicxLogger.Timestamp"/> that is used by the logger.
        /// </summary>
        Timestamp MessageTimestamp { get; }
        /// <summary>
        /// Gets or Sets a default message tag that will be used if no tag is selected.
        /// </summary>
        LogTag DefaultTag { get; set; }
        /// <summary>
        /// Gets or Sets if each log entry should contain a unique id or not.
        /// </summary>
        bool UseId { get; set; }


        /// <summary>
        /// Logs the given message.
        /// </summary>
        /// <param name="message">The message that will be logged</param>
        /// <returns>
        /// The unique id for the log entry if <see cref="BasicxLogger.ILogger.UseId"/> is true 
        /// or null if <see cref="BasicxLogger.ILogger.UseId"/> is false.
        /// </returns>
        string Log(string message);
        /// <summary>
        /// Logs the given message.
        /// </summary>
        /// <param name="message">The message that will be logged</param>
        /// <param name="messageTag">
        /// A Tag that will be added to the message, to make it easy to distinguish between differen log messages
        /// </param>
        /// <returns>
        /// The unique id for the log entry if <see cref="BasicxLogger.ILogger.UseId"/> is true 
        /// or null if <see cref="BasicxLogger.ILogger.UseId"/> is false.
        /// </returns>
        string Log(LogTag messageTag, string message);
        /// <summary>
        /// Asynchronous logs the given message.
        /// </summary>
        /// <param name="message">The message that will be logged</param>
        /// <returns>
        /// The unique id for the log entry if <see cref="BasicxLogger.ILogger.UseId"/> is true 
        /// or null if <see cref="BasicxLogger.ILogger.UseId"/> is false.
        /// </returns>
        Task<string> LogAsync(string message);
        /// <summary>
        /// Asynchronous logs the given message.
        /// </summary>
        /// <param name="message">The message that will be logged</param>
        /// <param name="messageTag">
        /// A Tag that will be added to the message, to make it easy to distinguish between differen log messages
        /// </param>
        /// <returns>
        /// The unique id for the log entry if <see cref="BasicxLogger.ILogger.UseId"/> is true 
        /// or null if <see cref="BasicxLogger.ILogger.UseId"/> is false.
        /// </returns>
        Task<string> LogAsync(LogTag messageTag, string message);
    }
}
