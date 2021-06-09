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
using System.Threading.Tasks;
using System.Collections.Generic;
using BasicxLogger.Message;

namespace BasicxLogger
{
    /// <summary>
    /// A logger that allows you to add all loggers that use the ILogger interface and 
    /// log with all of them by only using one log method call.
    /// </summary>
    /// <remarks>
    /// The multi logger supports all logger that uses the ILogger intaterface.
    /// </remarks>
    public class MultiLogger
    {
        private List<ILogger> _loggerList = new List<ILogger>();
        //----------------------------------------------------------------------------------------------

        //-Public-Methods-------------------------------------------------------------------------------
        /// <summary>
        /// Logs the given message and the current time stamp with every logger that was added to the multi logger.
        /// </summary>
        /// <remarks>
        /// If the log file and/or directory is missing, the method will automatically create them.
        /// </remarks>
        /// <param name="message">
        /// The message that will be writen to the file
        /// </param>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.NotSupportedException"></exception>
        /// <exception cref="System.NullReferenceException"></exception>
        /// <exception cref="System.UnauthorizedAccessException"></exception>
        /// <exception cref="System.IO.IOException"></exception>
        /// <exception cref="System.IO.PathTooLongException"></exception>
        /// <exception cref="System.IO.DirectoryNotFoundException"></exception>
        /// <exception cref="System.Security.SecurityException"></exception>
        /// <exception cref="BasicxLogger.NoLoggerAddedException"></exception>
        public void Log(string message)
        {
            try
            {
                if(_loggerList.Count > 0)
                {
                    foreach (ILogger logger in _loggerList)
                    {
                        logger.Log(message);
                    }
                }
                else
                {
                    throw new NoLoggerAddedException("The multi logger does not contain any loggers.");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Logs the given message with the given tag and the current time stamp with every logger that was added to the multi logger.
        /// </summary>
        /// <remarks>
        /// If the log file and/or directory is missing, the method will automatically create them.
        /// </remarks>
        /// <param name="message">
        /// The message that will be writen to the file
        /// </param>
        /// <param name="messageTag">
        /// A Tag that will be added to the message, to make it easy to distinguish between differen log messages
        /// </param>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.NotSupportedException"></exception>
        /// <exception cref="System.NullReferenceException"></exception>
        /// <exception cref="System.UnauthorizedAccessException"></exception>
        /// <exception cref="System.IO.IOException"></exception>
        /// <exception cref="System.IO.PathTooLongException"></exception>
        /// <exception cref="System.IO.DirectoryNotFoundException"></exception>
        /// <exception cref="System.Security.SecurityException"></exception>
        /// <exception cref="BasicxLogger.NoLoggerAddedException"></exception>
        /// <exception cref="BasicxLogger.NoLoggerAddedException"></exception>
        public void Log(LogTag messageTag, string message)
        {
            try
            {
                if (_loggerList.Count > 0)
                {
                    foreach (ILogger logger in _loggerList)
                    {
                        logger.Log(messageTag, message);
                    }
                }
                else
                {
                    throw new NoLoggerAddedException("The multi logger does not contain any loggers.");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Logs the given message, a message ID and the current time stamp with every logger that was added to the multi logger.
        /// </summary>
        /// <remarks>
        /// If the log file and/or directory is missing, the method will automatically create them.
        /// ID verification ist not supportet with the multi logger.
        /// </remarks>
        /// <param name="message">
        /// The message that will be writen to the file
        /// </param>
        /// <returns>
        /// The message ID that was automatically assigned to the message. It can be used to identify a specific message.
        /// </returns>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.NotSupportedException"></exception>
        /// <exception cref="System.NullReferenceException"></exception>
        /// <exception cref="System.UnauthorizedAccessException"></exception>
        /// <exception cref="System.IO.IOException"></exception>
        /// <exception cref="System.IO.PathTooLongException"></exception>
        /// <exception cref="System.IO.DirectoryNotFoundException"></exception>
        /// <exception cref="System.Security.SecurityException"></exception>
        /// <exception cref="BasicxLogger.NoLoggerAddedException"></exception>
        public string LogId(string message)
        {
            try
            {
                if (_loggerList.Count > 0)
                {
                    string id = GenerateId();

                    foreach (ILogger logger in _loggerList)
                    {
                        logger.LogCustomId(id, message);
                    }

                    return id;
                }
                else
                {
                    throw new NoLoggerAddedException("The multi logger does not contain any loggers.");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Logs the given message with the given tag, a message ID and the current time stamp with every logger that was added to the multi logger.
        /// </summary>
        /// <remarks>
        /// If the log file and/or directory is missing, the method will automatically create them.
        /// ID verification ist not supportet with the multi logger.
        /// </remarks>
        /// <param name="message">
        /// The message that will be writen to the file
        /// </param>
        /// <param name="messageTag">
        /// A Tag that will be added to the message, to make it easy to distinguish between differen log messages
        /// </param>
        /// <returns>
        /// The message ID that was automatically assigned to the message. It can be used to identify a specific message.
        /// </returns>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.NotSupportedException"></exception>
        /// <exception cref="System.NullReferenceException"></exception>
        /// <exception cref="System.UnauthorizedAccessException"></exception>
        /// <exception cref="System.IO.IOException"></exception>
        /// <exception cref="System.IO.PathTooLongException"></exception>
        /// <exception cref="System.IO.DirectoryNotFoundException"></exception>
        /// <exception cref="System.Security.SecurityException"></exception>
        /// <exception cref="BasicxLogger.NoLoggerAddedException"></exception>
        public string LogId(LogTag messageTag, string message)
        {
            try
            {
                if (_loggerList.Count > 0)
                {
                    string id = GenerateId();

                    foreach (ILogger logger in _loggerList)
                    {
                        logger.LogCustomId(id, messageTag, message);
                    }

                    return id;
                }
                else
                {
                    throw new NoLoggerAddedException("The multi logger does not contain any loggers.");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Logs the given message, the given ID and the current time stamp with every logger that was added to the multi logger.
        /// </summary>
        /// <remarks>
        /// If the log file and/or directory is missing, the method will automatically create them.
        /// </remarks>
        /// <param name="id">
        /// The id of the log message
        /// </param>
        /// <param name="message">
        /// The message that will be writen to the file
        /// </param>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.NotSupportedException"></exception>
        /// <exception cref="System.NullReferenceException"></exception>
        /// <exception cref="System.UnauthorizedAccessException"></exception>
        /// <exception cref="System.IO.IOException"></exception>
        /// <exception cref="System.IO.PathTooLongException"></exception>
        /// <exception cref="System.IO.DirectoryNotFoundException"></exception>
        /// <exception cref="System.Security.SecurityException"></exception>
        /// <exception cref="BasicxLogger.NoLoggerAddedException"></exception>
        public void LogCustomId(string id, string message)
        {
            try
            {
                if (_loggerList.Count > 0)
                {
                    foreach (ILogger logger in _loggerList)
                    {
                        logger.LogCustomId(id, message);
                    }
                }
                else
                {
                    throw new NoLoggerAddedException("The multi logger does not contain any loggers.");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Logs the given message with the given tag, the given ID and the current time stampwith every logger that was added to the multi logger.
        /// </summary>
        /// <remarks>
        /// If the log file and/or directory is missing, the method will automatically create them.
        /// </remarks>
        /// <param name="id">
        /// The id of the log message
        /// </param>
        /// <param name="message">
        /// The message that will be writen to the file
        /// </param>
        /// <param name="messageTag">
        /// A Tag that will be added to the message, to make it easy to distinguish between differen log messages
        /// </param>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.NotSupportedException"></exception>
        /// <exception cref="System.NullReferenceException"></exception>
        /// <exception cref="System.UnauthorizedAccessException"></exception>
        /// <exception cref="System.IO.IOException"></exception>
        /// <exception cref="System.IO.PathTooLongException"></exception>
        /// <exception cref="System.IO.DirectoryNotFoundException"></exception>
        /// <exception cref="System.Security.SecurityException"></exception>
        /// <exception cref="BasicxLogger.NoLoggerAddedException"></exception>
        public void LogCustomId(string id, LogTag messageTag, string message)
        {
            try
            {
                if (_loggerList.Count > 0)
                {
                    foreach (ILogger logger in _loggerList)
                    {
                        logger.LogCustomId(id, messageTag, message);
                    }
                }
                else
                {
                    throw new NoLoggerAddedException("The multi logger does not contain any loggers.");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //-Async-methods-----
        /// <summary>
        /// Asynchronous logs the given message and the current time stamp with every logger that was added to the multi logger.
        /// </summary>
        /// <remarks>
        /// If the log file and/or directory is missing, the method will automatically create them.
        /// </remarks>
        /// <param name="message">
        /// The message that will be writen to the file
        /// </param>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.NotSupportedException"></exception>
        /// <exception cref="System.NullReferenceException"></exception>
        /// <exception cref="System.UnauthorizedAccessException"></exception>
        /// <exception cref="System.IO.IOException"></exception>
        /// <exception cref="System.IO.PathTooLongException"></exception>
        /// <exception cref="System.IO.DirectoryNotFoundException"></exception>
        /// <exception cref="System.Security.SecurityException"></exception>
        /// <exception cref="BasicxLogger.NoLoggerAddedException"></exception>
        /// <exception cref="BasicxLogger.NoLoggerAddedException"></exception>
        public async Task LogAsync(string message)
        {
            try
            {
                if (_loggerList.Count > 0)
                {
                    foreach (ILogger logger in _loggerList)
                    {
                        await logger.LogAsync(message);
                    }
                }
                else
                {
                    throw new NoLoggerAddedException("The multi logger does not contain any loggers.");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Asynchronous logs the given message with the given tag and the current time stamp with every logger that was added to the multi logger.
        /// </summary>
        /// <remarks>
        /// If the log file and/or directory is missing, the method will automatically create them.
        /// </remarks>
        /// <param name="message">
        /// The message that will be writen to the file
        /// </param>
        /// <param name="messageTag">
        /// A Tag that will be added to the message, to make it easy to distinguish between differen log messages
        /// </param>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.NotSupportedException"></exception>
        /// <exception cref="System.NullReferenceException"></exception>
        /// <exception cref="System.UnauthorizedAccessException"></exception>
        /// <exception cref="System.IO.IOException"></exception>
        /// <exception cref="System.IO.PathTooLongException"></exception>
        /// <exception cref="System.IO.DirectoryNotFoundException"></exception>
        /// <exception cref="System.Security.SecurityException"></exception>
        /// <exception cref="BasicxLogger.NoLoggerAddedException"></exception>
        /// <exception cref="BasicxLogger.NoLoggerAddedException"></exception>
        public async Task LogAsync(LogTag messageTag, string message)
        {
            try
            {
                if (_loggerList.Count > 0)
                {
                    foreach (ILogger logger in _loggerList)
                    {
                        await logger.LogAsync(messageTag, message);
                    }
                }
                else
                {
                    throw new NoLoggerAddedException("The multi logger does not contain any loggers.");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Asynchronous logs the given message, a message ID and the current time stamp with every logger that was added to the multi logger.
        /// </summary>
        /// <remarks>
        /// If the log file and/or directory is missing, the method will automatically create them.
        /// ID verification ist not supportet with the multi logger.
        /// </remarks>
        /// <param name="message">
        /// The message that will be writen to the file
        /// </param>
        /// <returns>
        /// The message ID that was automatically assigned to the message. It can be used to identify a specific message.
        /// </returns>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.NotSupportedException"></exception>
        /// <exception cref="System.NullReferenceException"></exception>
        /// <exception cref="System.UnauthorizedAccessException"></exception>
        /// <exception cref="System.IO.IOException"></exception>
        /// <exception cref="System.IO.PathTooLongException"></exception>
        /// <exception cref="System.IO.DirectoryNotFoundException"></exception>
        /// <exception cref="System.Security.SecurityException"></exception>
        /// <exception cref="BasicxLogger.NoLoggerAddedException"></exception>
        public async Task<string> LogIdAsync(string message)
        {
            try
            {
                if (_loggerList.Count > 0)
                {
                    string id = GenerateId();

                    foreach (ILogger logger in _loggerList)
                    {
                        await logger.LogCustomIdAsync(id, message);
                    }
                    
                    return id;
                }
                else
                {
                    throw new NoLoggerAddedException("The multi logger does not contain any loggers.");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Asynchronous logs the given message with the given tag, a message ID and the current time stamp with every logger that was added to the multi logger.
        /// </summary>
        /// <remarks>
        /// If the log file and/or directory is missing, the method will automatically create them.
        /// ID verification ist not supportet with the multi logger.
        /// </remarks>
        /// <param name="message">
        /// The message that will be writen to the file
        /// </param>
        /// <param name="messageTag">
        /// A Tag that will be added to the message, to make it easy to distinguish between differen log messages
        /// </param>
        /// <returns>
        /// The message ID that was automatically assigned to the message. It can be used to identify a specific message.
        /// </returns>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.NotSupportedException"></exception>
        /// <exception cref="System.NullReferenceException"></exception>
        /// <exception cref="System.UnauthorizedAccessException"></exception>
        /// <exception cref="System.IO.IOException"></exception>
        /// <exception cref="System.IO.PathTooLongException"></exception>
        /// <exception cref="System.IO.DirectoryNotFoundException"></exception>
        /// <exception cref="System.Security.SecurityException"></exception>
        /// <exception cref="BasicxLogger.NoLoggerAddedException"></exception>
        public async Task<string> LogIdAsync(LogTag messageTag, string message)
        {
            try
            {
                if (_loggerList.Count > 0)
                {
                    string id = GenerateId();

                    foreach (ILogger logger in _loggerList)
                    {
                        await logger.LogCustomIdAsync(id, messageTag, message);
                    }

                    return id;
                }
                else
                {
                    throw new NoLoggerAddedException("The multi logger does not contain any loggers.");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Asynchronous logs the given message, the given ID and the current time stamp with every logger that was added to the multi logger.
        /// </summary>
        /// <remarks>
        /// If the log file and/or directory is missing, the method will automatically create them.
        /// </remarks>
        /// <param name="id">
        /// The id of the log message
        /// </param>
        /// <param name="message">
        /// The message that will be writen to the file
        /// </param>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.NotSupportedException"></exception>
        /// <exception cref="System.NullReferenceException"></exception>
        /// <exception cref="System.UnauthorizedAccessException"></exception>
        /// <exception cref="System.IO.IOException"></exception>
        /// <exception cref="System.IO.PathTooLongException"></exception>
        /// <exception cref="System.IO.DirectoryNotFoundException"></exception>
        /// <exception cref="System.Security.SecurityException"></exception>
        /// <exception cref="BasicxLogger.NoLoggerAddedException"></exception>
        public async Task LogCustomIdAsync(string id, string message)
        {
            try
            {
                if (_loggerList.Count > 0)
                {
                    foreach (ILogger logger in _loggerList)
                    {
                        await logger.LogCustomIdAsync(id, message);
                    }
                }
                else
                {
                    throw new NoLoggerAddedException("The multi logger does not contain any loggers.");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Asynchronous logs the given message with the given tag, the given ID and the current time stampwith every logger that was added to the multi logger.
        /// </summary>
        /// <remarks>
        /// If the log file and/or directory is missing, the method will automatically create them.
        /// </remarks>
        /// <param name="id">
        /// The id of the log message
        /// </param>
        /// <param name="message">
        /// The message that will be writen to the file
        /// </param>
        /// <param name="messageTag">
        /// A Tag that will be added to the message, to make it easy to distinguish between differen log messages
        /// </param>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.NotSupportedException"></exception>
        /// <exception cref="System.NullReferenceException"></exception>
        /// <exception cref="System.UnauthorizedAccessException"></exception>
        /// <exception cref="System.IO.IOException"></exception>
        /// <exception cref="System.IO.PathTooLongException"></exception>
        /// <exception cref="System.IO.DirectoryNotFoundException"></exception>
        /// <exception cref="System.Security.SecurityException"></exception>
        /// <exception cref="BasicxLogger.NoLoggerAddedException"></exception>
        public async Task logCustomIdAsync(string id, LogTag messageTag, string message)
        {
            try
            {
                if (_loggerList.Count > 0)
                {
                    foreach (ILogger logger in _loggerList)
                    {
                        await logger.LogCustomIdAsync(id, messageTag, message);
                    }
                }
                else
                {
                    throw new NoLoggerAddedException("The multi logger does not contain any loggers.");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //-------------------

        /// <summary>
        /// Adds the given logger to the multi logger
        /// </summary>
        /// <param name="logger">The logger to add</param>
        public void AddLogger(ILogger logger)
        {
            _loggerList.Add(logger);
        }

        //----------------------------------------------------------------------------------------------

        //-Private-Methods------------------------------------------------------------------------------
        private string GenerateId()
        {
            string id = "";

            List<string> idParts = new List<string>();

            while (idParts.Count != 10)
            {
                idParts.Add(new Random().Next(0, 16).ToString("X"));
            }

            foreach (string part in idParts)
            {
                id = id + part;
            }

            return id;
        }
        //----------------------------------------------------------------------------------------------
    }
}
