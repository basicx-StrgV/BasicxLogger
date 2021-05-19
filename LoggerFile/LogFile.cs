namespace BasicxLogger.LoggerFile
{
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


        public LogFile(string name, LogFileType type)
        {
            this.name = name;
            this.type = type;
            file = name + "." + type;
        }
    }
}
