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
        /// Logs the given message and the current time.
        /// </summary>
        /// <param name="message">
        /// The message that will be loged
        /// </param>
        void Log(string message);
        /// <summary>
        /// Logs the given message with the given tag and the current time stamp.
        /// </summary>
        /// <param name="message">
        /// The message that will be loged
        /// </param>
        /// <param name="messageTag">
        /// A Tag that will be added to the message, to make it easy to distinguish between differen log messages
        /// </param>
        void Log(LogTag messageTag, string message);
        /// <summary>
        /// Logs the given message, a message ID and the current time stamp.
        /// </summary>
        /// <param name="message">
        /// The message that will be loged
        /// </param>
        /// <returns>
        /// The message ID that was automatically assigned to the message. It can be used to identify a specific message.
        /// </returns>
        string LogId(string message);
        /// <summary>
        /// Logs the given message with the given tag, a message ID and the current time stamp.
        /// </summary>
        /// <param name="message">
        /// The message that will be loged
        /// </param>
        /// <param name="messageTag">
        /// A Tag that will be added to the message, to make it easy to distinguish between differen log messages
        /// </param>
        /// <returns>
        /// The message ID that was automatically assigned to the message. It can be used to identify a specific message.
        /// </returns>
        string LogId(LogTag messageTag, string message);
        /// <summary>
        /// Logs the given message, the given ID and the current time stamp.
        /// </summary>
        /// <param name="id">
        /// The id of the log message
        /// </param>
        /// <param name="message">
        /// The message that will be loged
        /// </param>
        void LogCustomId(string id, string message);
        /// <summary>
        /// Logs the given message with the given tag, the given ID and the current time stamp.
        /// </summary>
        /// <param name="id">
        /// The id of the log message
        /// </param>
        /// <param name="message">
        /// The message that will be loged
        /// </param>
        /// <param name="messageTag">
        /// A Tag that will be added to the message, to make it easy to distinguish between differen log messages
        /// </param>
        void LogCustomId(string id, LogTag messageTag, string message);
        /// <summary>
        /// Asynchronous logs the given message and the current time stamp.
        /// </summary>
        /// <param name="message">
        /// The message that will be loged
        /// </param>
        Task LogAsync(string message);
        /// <summary>
        /// Asynchronous logs the given message with the given tag and the current time stamp.
        /// </summary>
        /// <param name="message">
        /// The message that will be loged
        /// </param>
        /// <param name="messageTag">
        /// A Tag that will be added to the message, to make it easy to distinguish between differen log messages
        /// </param>
        Task LogAsync(LogTag messageTag, string message);
        /// <summary>
        /// Asynchronous logs the given message, a message ID and the current time stamp.
        /// </summary>
        /// <param name="message">
        /// The message that will be loged
        /// </param>
        /// <returns>
        /// The message ID that was automatically assigned to the message. It can be used to identify a specific message.
        /// </returns>
        Task<string> LogIdAsync(string message);
        /// <summary>
        /// Asynchronous logs the given message with the given tag, a message ID and the current time stamp.
        /// </summary>
        /// <param name="message">
        /// The message that will be loged
        /// </param>
        /// <param name="messageTag">
        /// A Tag that will be added to the message, to make it easy to distinguish between differen log messages
        /// </param>
        /// <returns>
        /// The message ID that was automatically assigned to the message. It can be used to identify a specific message.
        /// </returns>
        Task<string> LogIdAsync(LogTag messageTag, string message);
        /// <summary>
        /// Asynchronous logs the given message, the given ID and the current time stamp.
        /// </summary>
        /// <param name="id">
        /// The id of the log message
        /// </param>
        /// <param name="message">
        /// The message that will be loged
        /// </param>
        Task LogCustomIdAsync(string id, string message);
        /// <summary>
        /// Asynchronous logs the given message with the given tag, the given ID and the current time stamp.
        /// </summary>
        /// <param name="id">
        /// The id of the log message
        /// </param>
        /// <param name="message">
        /// The message that will be loged
        /// </param>
        /// <param name="messageTag">
        /// A Tag that will be added to the message, to make it easy to distinguish between differen log messages
        /// </param>
        Task LogCustomIdAsync(string id, LogTag messageTag, string message);
    }
}
