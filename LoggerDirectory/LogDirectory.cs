namespace BasicxLogger.LoggerDirectory
{
    public class LogDirectory
    {
        public string path { get; }
        public string name { get; }
        public string directory { get; }

        public LogDirectory(string path, string name)
        {
            this.path = path;
            this.name = name;
            directory = this.path + "\\" + this.name;
        }
    }
}
