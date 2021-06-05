//--------------------------------------------------//
// Created by basicx-StrgV                          //
// https://github.com/basicx-StrgV/BasicxLogger     //
//--------------------------------------------------//
namespace BasicxLogger.LoggerDirectory
{
    /// <summary>
    /// Contains all informations about the log directory
    /// </summary>
    public class LogDirectory
    {
        /// <summary>
        /// Path were the log directory is located
        /// </summary>
        public string path { get; }
        /// <summary>
        /// Name of the log directory
        /// </summary>
        public string name { get; }
        /// <summary>
        /// Full directory path (path + name)
        /// </summary>
        public string directory { get; }

        /// <summary>
        /// Constructor, to create a LogDirectory object.
        /// </summary>
        /// <remarks>
        /// Can be used to configure a custom directory for the logger
        /// </remarks>
        /// <param name="path">
        /// Path where the directory is located
        /// </param>
        /// <param name="name">
        /// Name of the log directory
        /// </param>
        public LogDirectory(string path, string name)
        {
            this.path = path;
            this.name = name;
            directory = this.path + "\\" + this.name;
        }
    }
}
