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
        public string Name { get; }
        /// <summary>
        /// File type of the log file
        /// </summary>
        public FileType Type { get; }
        /// <summary>
        /// Full file name (name + file type : e.g. sample.txt)
        /// </summary>
        public string FullName { get; }

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
        public LogFile(string name, FileType type)
        {
            this.Name = name;
            this.Type = type;
            this.FullName = name + "." + type;
        }
    }
}
