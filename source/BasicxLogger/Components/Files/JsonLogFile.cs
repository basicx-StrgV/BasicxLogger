//--------------------------------------------------//
// Created by basicx-StrgV                          //
// https://github.com/basicx-StrgV/BasicxLogger     //
//--------------------------------------------------//
using System;
using System.IO;
using System.Text;
using System.Text.Json;
using BasicxLogger.Base;
using BasicxLogger.Models;

namespace BasicxLogger.Files
{
    /// <summary>
    /// Class that represents a log file with the file extension .json
    /// </summary>
    public class JsonLogFile : ILogFile
    {
        /// <summary>
        /// Gets or Sets the text encoding for the file
        /// </summary>
        public Encoding TextEncoding { get; set; } = Encoding.UTF8;

        /// <summary>
        /// Gets a string representing the directory's full path
        /// </summary>
        public string DirectoryName { get { return _file.DirectoryName; } }

        /// <summary>
        /// Gets the full path of the file
        /// </summary>
        public string FullName { get { return _file.FullName; } }

        /// <summary>
        /// Gets the string representing the extension part of the file
        /// </summary>
        public string Extension { get { return _file.Extension; } }


        private readonly FileInfo _file;


        /// <summary>
        /// Initializes a new instance of the <see cref="BasicxLogger.Files.JsonLogFile"/> class
        /// </summary>
        /// <param name="directoryPath">The path where the file will be stored</param>
        /// <param name="fileName">The name of the file, without the extension</param>
        public JsonLogFile(string directoryPath, string fileName)
        {
            if (!(directoryPath.EndsWith("\\") || directoryPath.EndsWith("/")))
            {
                directoryPath += '/';
            }

            _file = new FileInfo(directoryPath + fileName.Split('.')[0].Trim() + ".json");
        }

        /// <summary>
        /// Writes a log message with the given data to the log file
        /// </summary>
        /// <param name="messageTag">The message tag for the log message</param>
        /// <param name="timestamp">The timestamp for the log message</param>
        /// <param name="message">The message that should be logged</param>
        /// <param name="id">The id for the log message</param>
        public void WriteToFile(LogTag messageTag, string timestamp, string message, string id = "")
        {
            try
            {
                if (!Directory.Exists(_file.DirectoryName))
                {
                    Directory.CreateDirectory(_file.DirectoryName);
                }

                if (!File.Exists(_file.FullName))
                {
                    CreateJsonFile();
                }

                string fileContent = File.ReadAllText(_file.FullName);

                JsonLogModel<LogMessageModel> logFile = JsonSerializer.Deserialize<JsonLogModel<LogMessageModel>>(fileContent);

                LogMessageModel newLogEntry = new LogMessageModel();
                if (!id.Equals(""))
                {
                    newLogEntry.Id = id;
                }

                newLogEntry.Timestamp = timestamp;

                if (!messageTag.Equals(LogTag.none))
                {
                    newLogEntry.Tag = messageTag.ToString();
                }

                newLogEntry.Message = message;

                logFile.Entrys.Add(newLogEntry);

                string newFileContent = JsonSerializer.Serialize(logFile);

                FileStream fileWriter = File.OpenWrite(_file.FullName);
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

        /// <summary>
        /// Writes the given object to the log file
        /// </summary>
        /// <param name="logObject">The object that will be writen to the json file</param>
        public void WriteToFile<T>(T logObject)
        {
            try
            {
                if (!Directory.Exists(_file.DirectoryName))
                {
                    Directory.CreateDirectory(_file.DirectoryName);
                }

                if (!File.Exists(_file.FullName))
                {
                    CreateJsonFile();
                }

                string fileContent = File.ReadAllText(_file.FullName);

                JsonLogModel<T> logFile = JsonSerializer.Deserialize<JsonLogModel<T>>(fileContent);

                logFile.Entrys.Add(logObject);

                string newFileContent = JsonSerializer.Serialize(logFile);

                FileStream fileWriter = File.OpenWrite(_file.FullName);
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

        private void CreateJsonFile()
        {
            try
            {
                if (!File.Exists(_file.FullName))
                {
                    File.WriteAllText(_file.FullName, "{ \"entrys\": []}");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
