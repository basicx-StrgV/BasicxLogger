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

namespace BasicxLogger
{
    /// <summary>
    /// A logger that allows you to log your owne objects to a json file
    /// </summary>
    public class JsonLogger<T>
    {
        //-Properties-----------------------------------------------------------------------------------
        /// <summary>
        /// Gets the <see cref="BasicxLogger.JsonLogFile"/> that is used by the logger.
        /// </summary>
        public JsonLogFile LogFile { get; } = new JsonLogFile(
            String.Format("{0}/{1}/", Environment.CurrentDirectory, "Logs"), "Log");
        //----------------------------------------------------------------------------------------------

        //-Constructors---------------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the <see cref="BasicxLogger.JsonLogger{T}"/> class.
        /// </summary>
        /// <param name="directoryPath">The path where the file will be stored</param>
        /// <param name="fileName">The name of the file, without the extension</param>
        public JsonLogger(string directoryPath, string fileName)
        {
            LogFile = new JsonLogFile(directoryPath, fileName);
        }
        //----------------------------------------------------------------------------------------------

        //-Public-Methods-------------------------------------------------------------------------------
        /// <summary>
        /// Adds the given object to the log file.
        /// </summary>
        /// <remarks>
        /// If the log file and/or directory is missing, the method will automatically create them.
        /// </remarks>
        /// <param name="logObject">
        /// The object that will be added to the json file
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
        public void Log(T logObject)
        {
            try
            {
                LogFile.WriteToFile(logObject);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //-Async-methods-----
        /// <summary>
        /// Asynchronous adds the given object to the log file.
        /// </summary>
        /// <remarks>
        /// If the log file and/or directory is missing, the method will automatically create them.
        /// </remarks>
        /// <param name="logObject">
        /// The object that will be added to the json file
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
        public async Task LogAsync(T logObject)
        {
            try
            {
                Task logTask = Task.Run(() => Log(logObject));
                await logTask;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //-------------------

        //----------------------------------------------------------------------------------------------
    }
}
