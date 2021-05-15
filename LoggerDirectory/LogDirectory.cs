namespace BasicxLogger.LoggerDirectory
{
    public class LogDirectory
    {
        public string path { get; set; }
        public string name { get; set; }

        public LogDirectory(string path, string name)
        {
            this.path = path;
            this.name = name;
        }

        public override string ToString()
        {
            return path + "/" + name;
        }
    }
}
