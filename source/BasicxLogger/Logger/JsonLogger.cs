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
using System.Collections.Generic;
using BasicxLogger.LoggerFile;
using BasicxLogger.LoggerDirectory;

namespace BasicxLogger
{
    /// <summary>
    /// A logger that allows you to log your owne objects to a json file
    /// </summary>
    public class JsonLogger<T>
    {
        //-Properties-----------------------------------------------------------------------------------
        /// <summary>
        /// Contains all informations about the log file
        /// </summary>
        public LogFile LoggingFile { get; } = new LogFile("log", FileType.json);
        /// <summary>
        /// Contains all informations about the log directory
        /// </summary>
        public LogDirectory FileDirectory { get; } = new LogDirectory(Environment.CurrentDirectory, "Logs");
        //----------------------------------------------------------------------------------------------

        //-Constructors---------------------------------------------------------------------------------
        /// <summary>
        /// Constructor, to create a simple logger object that uses the default settings
        /// </summary>
        public JsonLogger()
        {
            CreateDirectory();
        }
        /// <summary>
        /// Constructor, to create a logger object with custom settings. 
        /// </summary>
        /// <remarks>
        /// Everything that has no custom configuration will use the default settings.
        /// </remarks>
        public JsonLogger(string fileName)
        {
            LoggingFile = new LogFile(fileName, FileType.json);
            CreateDirectory();
        }
        /// <summary>
        /// Constructor, to create a logger object with custom settings. 
        /// </summary>
        /// <remarks>
        /// Everything that has no custom configuration will use the default settings.
        /// </remarks>
        public JsonLogger(string fileName, LogDirectory logDirectory)
        {
            LoggingFile = new LogFile(fileName, FileType.json);
            this.FileDirectory = logDirectory;
            CreateDirectory();
        }
        /// <summary>
        /// Constructor, to create a logger object with custom settings. 
        /// </summary>
        /// <remarks>
        /// Everything that has no custom configuration will use the default settings.
        /// </remarks>
        public JsonLogger(LogDirectory logDirectory)
        {
            this.FileDirectory = logDirectory;
            CreateDirectory();
        }
        /// <summary>
        /// Constructor, to create a logger object with custom settings. 
        /// </summary>
        /// <remarks>
        /// Everything that has no custom configuration will use the default settings.
        /// </remarks>
        public JsonLogger(LogDirectory logDirectory, string fileName)
        {
            LoggingFile = new LogFile(fileName, FileType.json);
            this.FileDirectory = logDirectory;
            CreateDirectory();
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
                if (!Directory.Exists(FileDirectory.FullPath))
                {
                    CreateDirectory();
                }

                if (!File.Exists(GetFullFilePath()))
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

        /// <returns>
        /// The full file path (e.g. C:\mypath\myfile.json)
        /// </returns>
        public string GetFullFilePath()
        {
            return FileDirectory.FullPath + "\\" + LoggingFile.FullName;
        }

        /// <summary>
        /// Deletes the log file, that was created by the logger.
        /// </summary>
        /// <remarks>
        /// All logs will be lost. If you log again after deleting the log file, the logger will create a new file.
        /// </remarks>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.NotSupportedException"></exception>
        /// <exception cref="System.UnauthorizedAccessException"></exception>
        /// <exception cref="System.IO.IOException"></exception>
        /// <exception cref="System.IO.PathTooLongException"></exception>
        /// <exception cref="System.IO.DirectoryNotFoundException"></exception>
        public void DeleteLogFile()
        {
            try
            {
                File.Delete(GetFullFilePath());
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //----------------------------------------------------------------------------------------------

        //-Private-Methods------------------------------------------------------------------------------
        private void CreateDirectory()
        {
            try
            {
                if (!Directory.Exists(FileDirectory.FullPath))
                {
                    Directory.CreateDirectory(FileDirectory.FullPath);
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
                if (!File.Exists(GetFullFilePath()))
                {
                    File.WriteAllText(GetFullFilePath(), "[]");
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
                string fileContent = File.ReadAllText(GetFullFilePath());

                List<T> logs = JsonSerializer.Deserialize<List<T>>(fileContent);

                logs.Add(logObject);

                string newFileContent = JsonSerializer.Serialize(logs);

                FileStream fileWriter = File.OpenWrite(GetFullFilePath());
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
