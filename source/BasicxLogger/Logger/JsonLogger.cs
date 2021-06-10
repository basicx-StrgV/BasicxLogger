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
using System.IO;
using System.Text.Json;
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
        /// The log file of the logger.
        /// </summary>
        /// <remarks>
        /// The file name must contain the full path and the file extension.
        /// This logger only supports .json files
        /// </remarks>
        public FileInfo LogFile { get; } = new FileInfo(
            String.Format("{0}/{1}/Log.json", Environment.CurrentDirectory, "Logs"));
        //----------------------------------------------------------------------------------------------

        //-Constructors---------------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the <see cref="BasicxLogger.JsonLogger"/> class
        /// </summary>
        /// <param name="logFile">The log file of the logger</param>
        public JsonLogger(FileInfo logFile)
        {
            LogFile = logFile;
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
                if (!Directory.Exists(LogFile.DirectoryName))
                {
                    CreateDirectory();
                }

                if (!File.Exists(LogFile.FullName))
                {
                    CreateJsonFile();
                }

                LogToJson(logObject);
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

        //-Private-Methods------------------------------------------------------------------------------
        private void CreateDirectory()
        {
            try
            {
                if (!Directory.Exists(LogFile.DirectoryName))
                {
                    Directory.CreateDirectory(LogFile.DirectoryName);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void CreateJsonFile()
        {
            try
            {
                if (!File.Exists(LogFile.FullName))
                {
                    File.WriteAllText(LogFile.FullName, "{ \"entrys\": []}");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void LogToJson(T logObject)
        {
            try
            {
                string fileContent = File.ReadAllText(LogFile.FullName);

                CustomJsonLogModel<T> logFile = JsonSerializer.Deserialize<CustomJsonLogModel<T>>(fileContent);

                logFile.entrys.Add(logObject);

                string newFileContent = JsonSerializer.Serialize(logFile);

                FileStream fileWriter = File.OpenWrite(LogFile.FullName);
                Utf8JsonWriter jsonWriter = new Utf8JsonWriter(fileWriter, new JsonWriterOptions { Indented = true });

                JsonDocument jsonFile = JsonDocument.Parse(newFileContent);

                jsonFile.WriteTo(jsonWriter);

                jsonWriter.Flush();

                jsonWriter.Dispose();

                fileWriter.Close();
                fileWriter.Dispose();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //----------------------------------------------------------------------------------------------
    }
}
