//--------------------------------------------------//
// Created by basicx-StrgV                          //
// https://github.com/basicx-StrgV/BasicxLogger     //
//--------------------------------------------------//
using System;
using System.IO;
using System.Text;

namespace BasicxLogger
{
    /// <summary>
    /// Class that represents a log file with the file extension .txt
    /// </summary>
    public class TxtLogFile : ILogFile
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
        /// Initializes a new instance of the <see cref="BasicxLogger.TxtLogFile"/> class
        /// </summary>
        public TxtLogFile(string directoryPath, string fileName)
        {
            if (!(directoryPath.EndsWith("\\") || directoryPath.EndsWith("/")))
            {
                directoryPath += '/';
            }

            _file = new FileInfo(directoryPath + fileName.Split('.')[0].Trim() + ".txt");
            
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
            if (!Directory.Exists(_file.DirectoryName))
            {
                Directory.CreateDirectory(_file.DirectoryName);
            }

            File.AppendAllText(_file.FullName, MessageBuilder(messageTag, timestamp, message, id), TextEncoding);
        }

        private string MessageBuilder(LogTag messageTag, string timestamp, string message, string id)
        {
            string dateTimePart = String.Format("[{0}] ", timestamp);
            string tagPart = "";
            string idPart = "";

            if (!messageTag.Equals(LogTag.none))
            {
                tagPart = "[" + messageTag + "] ";
            }

            if (!id.Equals(""))
            {
                idPart = "[ID:" + id + "] ";
            }

            return dateTimePart + tagPart + idPart + message + "\n";
        }
    }
}
