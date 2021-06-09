//--------------------------------------------------//
// Created by basicx-StrgV                          //
// https://github.com/basicx-StrgV/BasicxLogger     //
//--------------------------------------------------//
using System.Text;

namespace BasicxLogger.Message
{
    /// <summary>
    /// Contains all informations about the formatting of the log messages
    /// </summary>
    public class LogMessageFormat
    {
        /// <summary>
        /// Contains the information about the date formatting for the log message
        /// </summary>
        public LogDate Date { get; } = new LogDate(DateFormat.year_month_day, '/');
        /// <summary>
        /// Contains the information about the time formatting for the log message
        /// </summary>
        public LogTime Time { get; } = new LogTime(TimeFormat.hour24_min_sec);
        /// <summary>
        /// A default message tag that will be used if no tag is selected
        /// </summary>
        public LogTag DefaultTag { get; } = LogTag.none;
        /// <summary>
        /// Encoding for the log message
        /// </summary>
        /// <remarks>
        /// This option is not supported for json logging and will be ignored if you log to a json file
        /// </remarks>
        public Encoding TextEncoding { get; } = Encoding.UTF8;

        /// <summary>
        /// Constructor, to create a MessageFormate object with custom settings, that can be used to customize the logger
        /// </summary>
        /// <remarks>
        /// Everything that has no custom configuration will use the default settings.
        /// </remarks>
        public LogMessageFormat(LogTag defaultTag)
        {
            this.DefaultTag = defaultTag;
        }
        /// <summary>
        /// Constructor, to create a MessageFormate object with custom settings, that can be used to customize the logger
        /// </summary>
        /// <remarks>
        /// Everything that has no custom configuration will use the default settings.
        /// </remarks>
        public LogMessageFormat(Encoding encoding)
        {
            this.TextEncoding = encoding;
        }
        /// <summary>
        /// Constructor, to create a MessageFormate object with custom settings, that can be used to customize the logger
        /// </summary>
        /// <remarks>
        /// Everything that has no custom configuration will use the default settings.
        /// </remarks>
        public LogMessageFormat(LogDate date)
        {
            this.Date = date;
        }
        /// <summary>
        /// Constructor, to create a MessageFormate object with custom settings, that can be used to customize the logger
        /// </summary>
        /// <remarks>
        /// Everything that has no custom configuration will use the default settings.
        /// </remarks>
        public LogMessageFormat(LogDate date, LogTime time)
        {
            this.Date = date;
            this.Time = time;
        }
        /// <summary>
        /// Constructor, to create a MessageFormate object with custom settings, that can be used to customize the logger
        /// </summary>
        /// <remarks>
        /// Everything that has no custom configuration will use the default settings.
        /// </remarks>
        public LogMessageFormat(LogDate date, LogTag defaultTag)
        {
            this.Date = date;
            this.DefaultTag = defaultTag;
        }
        /// <summary>
        /// Constructor, to create a MessageFormate object with custom settings, that can be used to customize the logger
        /// </summary>
        /// <remarks>
        /// Everything that has no custom configuration will use the default settings.
        /// </remarks>
        public LogMessageFormat(LogDate date, Encoding encoding)
        {
            this.Date = date;
            this.TextEncoding = encoding;
        }
        /// <summary>
        /// Constructor, to create a MessageFormate object with custom settings, that can be used to customize the logger
        /// </summary>
        /// <remarks>
        /// Everything that has no custom configuration will use the default settings.
        /// </remarks>
        public LogMessageFormat(LogDate date, LogTime time, LogTag defaultTag)
        {
            this.Date = date;
            this.Time = time;
            this.DefaultTag = defaultTag;
        }
        /// <summary>
        /// Constructor, to create a MessageFormate object with custom settings, that can be used to customize the logger
        /// </summary>
        /// <remarks>
        /// Everything that has no custom configuration will use the default settings.
        /// </remarks>
        public LogMessageFormat(LogDate date, LogTag defaultTag, Encoding encoding)
        {
            this.Date = date;
            this.DefaultTag = defaultTag;
            this.TextEncoding = encoding;
        }
        /// <summary>
        /// Constructor, to create a MessageFormate object with custom settings, that can be used to customize the logger
        /// </summary>
        /// <remarks>
        /// Everything that has no custom configuration will use the default settings.
        /// </remarks>
        public LogMessageFormat(LogDate date, LogTime time, Encoding encoding)
        {
            this.Date = date;
            this.TextEncoding = encoding;
            this.Time = time;
        }
        /// <summary>
        /// Constructor, to create a MessageFormate object with custom settings, that can be used to customize the logger
        /// </summary>
        /// <remarks>
        /// Everything that has no custom configuration will use the default settings.
        /// </remarks>
        public LogMessageFormat(LogDate date, LogTime time, LogTag defaultTag, Encoding encoding)
        {
            this.Date = date;
            this.Time = time;
            this.DefaultTag = defaultTag;
            this.TextEncoding = encoding;
        }
        /// <summary>
        /// Constructor, to create a MessageFormate object with custom settings, that can be used to customize the logger
        /// </summary>
        /// <remarks>
        /// Everything that has no custom configuration will use the default settings.
        /// </remarks>
        public LogMessageFormat(LogTime time)
        {
            this.Time = time;
        }
        /// <summary>
        /// Constructor, to create a MessageFormate object with custom settings, that can be used to customize the logger
        /// </summary>
        /// <remarks>
        /// Everything that has no custom configuration will use the default settings.
        /// </remarks>
        public LogMessageFormat(LogTime time, LogTag defaultTag)
        {
            this.Time = time;
            this.DefaultTag = defaultTag;
        }
        /// <summary>
        /// Constructor, to create a MessageFormate object with custom settings, that can be used to customize the logger
        /// </summary>
        /// <remarks>
        /// Everything that has no custom configuration will use the default settings.
        /// </remarks>
        public LogMessageFormat(LogTime time, Encoding encoding)
        {
            this.Time = time;
            this.TextEncoding = encoding;
        }
        /// <summary>
        /// Constructor, to create a MessageFormate object with custom settings, that can be used to customize the logger
        /// </summary>
        /// <remarks>
        /// Everything that has no custom configuration will use the default settings.
        /// </remarks>
        public LogMessageFormat(LogTime time, LogTag defaultTag, Encoding encoding)
        {
            this.Time = time;
            this.DefaultTag = defaultTag;
            this.TextEncoding = encoding;
        }
    }
}
