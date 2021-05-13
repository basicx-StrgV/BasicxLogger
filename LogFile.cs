namespace EasyLogger
{
    public class LogFile
    {
        public string name { get; set; }
        public LogFileType type { get; set; }

        public LogFile(string name, LogFileType type)
        {
            this.name = name;
            this.type = type;
        }

        public override string ToString()
        {
            return name + "." + type;
        }
    }
}
