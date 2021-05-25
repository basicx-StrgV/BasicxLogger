//--------------------------------------------------//
// Created by basicx-StrgV                          //
// https://github.com/basicx-StrgV/BasicxLogger     //
//--------------------------------------------------//
namespace BasicxLogger.LoggerFile
{
    /// <summary>
    /// Contains all informations about the log file
    /// </summary>
    public class LogFile
    {
        /// <summary>
        /// Name of the log file
        /// </summary>
        public string name { get; }
        /// <summary>
        /// File type of the log file
        /// </summary>
        public LogFileType type { get; }
        /// <summary>
        /// Full file name (name + file type : e.g. sample.txt)
        /// </summary>
        public string file { get; }

        /// <summary>
        /// Constructor, to create a LogFile object.
        /// </summary>
        /// <remarks>
        /// Can be used to configure a custom file for the logger
        /// </remarks>
        /// <param name="name">
        /// Name of the log file
        /// </param>
        /// <param name="type">
        /// File type of the log file
        /// </param>
        public LogFile(string name, LogFileType type)
        {
            this.name = name;
            this.type = type;
            file = name + "." + type;
        }
    }
}
