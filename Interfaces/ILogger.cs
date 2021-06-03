﻿//--------------------------------------------------//
// Created by basicx-StrgV                          //
// https://github.com/basicx-StrgV/BasicxLogger     //
//--------------------------------------------------//
using System.Threading.Tasks;
using BasicxLogger.Message;

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
        void log(string message);
        /// <summary>
        /// Logs the given message with the given tag and the current time stamp.
        /// </summary>
        /// <param name="message">
        /// The message that will be loged
        /// </param>
        /// <param name="messageTag">
        /// A Tag that will be added to the message, to make it easy to distinguish between differen log messages
        /// </param>
        void log(Tag messageTag, string message);
        /// <summary>
        /// Logs the given message, a message ID and the current time stamp.
        /// </summary>
        /// <param name="message">
        /// The message that will be loged
        /// </param>
        /// <param name="verifyMessageID">
        /// Set to true if you want to make sure the message id is unique.
        /// If set to true, the loging of the message may take longer an use more ram depending on how big your log file is.
        /// When the log file exceeds the length of 1,073,741,823 chars (a little over 1GB file size) the ID will not be verifyed.
        /// </param>
        /// <returns>
        /// The message ID that was automatically assigned to the message. It can be used to identify a specific message.
        /// </returns>
        string logID(string message, bool verifyMessageID = false);
        /// <summary>
        /// Logs the given message with the given tag, a message ID and the current time stamp.
        /// </summary>
        /// <param name="message">
        /// The message that will be loged
        /// </param>
        /// <param name="messageTag">
        /// A Tag that will be added to the message, to make it easy to distinguish between differen log messages
        /// </param>
        /// <param name="verifyMessageID">
        /// Set to true if you want to make sure the message id is unique.
        /// If set to true, the loging of the message may take longer an use more ram depending on how big your log file is.
        /// When the log file exceeds the length of 1,073,741,823 chars (a little over 1GB file size) the ID will not be verifyed.
        /// </param>
        /// <returns>
        /// The message ID that was automatically assigned to the message. It can be used to identify a specific message.
        /// </returns>
        string logID(Tag messageTag, string message, bool verifyMessageID = false);
        /// <summary>
        /// Logs the given message, the given ID and the current time stamp.
        /// </summary>
        /// <param name="id">
        /// The id of the log message
        /// </param>
        /// <param name="message">
        /// The message that will be loged
        /// </param>
        void logCustomID(string id, string message);
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
        void logCustomID(string id, Tag messageTag, string message);
        /// <summary>
        /// Asynchronous logs the given message and the current time stamp.
        /// </summary>
        /// <param name="message">
        /// The message that will be loged
        /// </param>
        Task logAsync(string message);
        /// <summary>
        /// Asynchronous logs the given message with the given tag and the current time stamp.
        /// </summary>
        /// <param name="message">
        /// The message that will be loged
        /// </param>
        /// <param name="messageTag">
        /// A Tag that will be added to the message, to make it easy to distinguish between differen log messages
        /// </param>
        Task logAsync(Tag messageTag, string message);
        /// <summary>
        /// Asynchronous logs the given message, a message ID and the current time stamp.
        /// </summary>
        /// <param name="message">
        /// The message that will be loged
        /// </param>
        /// <param name="verifyMessageID">
        /// Set to true if you want to make sure the message id is unique.
        /// If set to true, the loging of the message may take longer an use more ram depending on how big your log file is.
        /// When the log file exceeds the length of 1,073,741,823 chars (a little over 1GB file size) the ID will not be verifyed.
        /// </param>
        /// <returns>
        /// The message ID that was automatically assigned to the message. It can be used to identify a specific message.
        /// </returns>
        Task<string> logIDAsync(string message, bool verifyMessageID = false);
        /// <summary>
        /// Asynchronous logs the given message with the given tag, a message ID and the current time stamp.
        /// </summary>
        /// <param name="message">
        /// The message that will be loged
        /// </param>
        /// <param name="messageTag">
        /// A Tag that will be added to the message, to make it easy to distinguish between differen log messages
        /// </param>
        /// <param name="verifyMessageID">
        /// Set to true if you want to make sure the message id is unique.
        /// If set to true, the loging of the message may take longer an use more ram depending on how big your log file is.
        /// When the log file exceeds the length of 1,073,741,823 chars (a little over 1GB file size) the ID will not be verifyed.
        /// </param>
        /// <returns>
        /// The message ID that was automatically assigned to the message. It can be used to identify a specific message.
        /// </returns>
        Task<string> logIDAsync(Tag messageTag, string message, bool verifyMessageID = false);
        /// <summary>
        /// Asynchronous logs the given message, the given ID and the current time stamp.
        /// </summary>
        /// <param name="id">
        /// The id of the log message
        /// </param>
        /// <param name="message">
        /// The message that will be loged
        /// </param>
        Task logCustomIDAsync(string id, string message);
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
        Task logCustomIDAsync(string id, Tag messageTag, string message);
    }
}