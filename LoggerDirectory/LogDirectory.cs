namespace BasicxLogger.LoggerDirectory
{
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

        public LogDirectory(string path, string name)
        {
            this.path = path;
            this.name = name;
            directory = this.path + "\\" + this.name;
        }
    }
}
