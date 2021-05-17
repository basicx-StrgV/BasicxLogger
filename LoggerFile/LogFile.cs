namespace BasicxLogger.LoggerFile
{
    public class LogFile
    {
        public string name { get; }
        public LogFileType type { get; }
        public string file { get; }


        public LogFile(string name, LogFileType type)
        {
            this.name = name;
            this.type = type;
            file = name + "." + type;
        }
    }
}
