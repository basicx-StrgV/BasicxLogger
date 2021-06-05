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
    public class MessageFormat
    {
        /// <summary>
        /// Contains the information about the date formatting for the log message
        /// </summary>
        public Date date { get; } = new Date(DateFormat.year_month_day, '/');
        /// <summary>
        /// Contains the information about the time formatting for the log message
        /// </summary>
        public Time time { get; } = new Time(TimeFormat.hour24_min_sec);
        /// <summary>
        /// A default message tag that will be used if no tag is selected
        /// </summary>
        public Tag defaultTag { get; } = Tag.none;
        /// <summary>
        /// Encoding for the log message
        /// </summary>
        /// <remarks>
        /// This option is not supported for json logging and will be ignored if you log to a json file
        /// </remarks>
        public Encoding encoding { get; } = Encoding.UTF8;

        /// <summary>
        /// Constructor, to create a MessageFormate object with custom settings, that can be used to customize the logger
        /// </summary>
        /// <remarks>
        /// Everything that has no custom configuration will use the default settings.
        /// </remarks>
        public MessageFormat(Encoding encoding)
        {
            this.encoding = encoding;
        }
        /// <summary>
        /// Constructor, to create a MessageFormate object with custom settings, that can be used to customize the logger
        /// </summary>
        /// <remarks>
        /// Everything that has no custom configuration will use the default settings.
        /// </remarks>
        public MessageFormat(Date date)
        {
            this.date = date;
        }
        /// <summary>
        /// Constructor, to create a MessageFormate object with custom settings, that can be used to customize the logger
        /// </summary>
        /// <remarks>
        /// Everything that has no custom configuration will use the default settings.
        /// </remarks>
        public MessageFormat(Date date, Time time)
        {
            this.date = date;
            this.time = time;
        }
        /// <summary>
        /// Constructor, to create a MessageFormate object with custom settings, that can be used to customize the logger
        /// </summary>
        /// <remarks>
        /// Everything that has no custom configuration will use the default settings.
        /// </remarks>
        public MessageFormat(Date date, Tag defaultTag)
        {
            this.date = date;
            this.defaultTag = defaultTag;
        }
        /// <summary>
        /// Constructor, to create a MessageFormate object with custom settings, that can be used to customize the logger
        /// </summary>
        /// <remarks>
        /// Everything that has no custom configuration will use the default settings.
        /// </remarks>
        public MessageFormat(Date date, Encoding encoding)
        {
            this.date = date;
            this.encoding = encoding;
        }
        /// <summary>
        /// Constructor, to create a MessageFormate object with custom settings, that can be used to customize the logger
        /// </summary>
        /// <remarks>
        /// Everything that has no custom configuration will use the default settings.
        /// </remarks>
        public MessageFormat(Date date, Time time, Tag defaultTag)
        {
            this.date = date;
            this.time = time;
            this.defaultTag = defaultTag;
        }
        /// <summary>
        /// Constructor, to create a MessageFormate object with custom settings, that can be used to customize the logger
        /// </summary>
        /// <remarks>
        /// Everything that has no custom configuration will use the default settings.
        /// </remarks>
        public MessageFormat(Date date, Tag defaultTag, Encoding encoding)
        {
            this.date = date;
            this.defaultTag = defaultTag;
            this.encoding = encoding;
        }
        /// <summary>
        /// Constructor, to create a MessageFormate object with custom settings, that can be used to customize the logger
        /// </summary>
        /// <remarks>
        /// Everything that has no custom configuration will use the default settings.
        /// </remarks>
        public MessageFormat(Date date, Time time, Encoding encoding)
        {
            this.date = date;
            this.encoding = encoding;
            this.time = time;
        }
        /// <summary>
        /// Constructor, to create a MessageFormate object with custom settings, that can be used to customize the logger
        /// </summary>
        /// <remarks>
        /// Everything that has no custom configuration will use the default settings.
        /// </remarks>
        public MessageFormat(Date date, Time time, Tag defaultTag, Encoding encoding)
        {
            this.date = date;
            this.time = time;
            this.defaultTag = defaultTag;
            this.encoding = encoding;
        }
        /// <summary>
        /// Constructor, to create a MessageFormate object with custom settings, that can be used to customize the logger
        /// </summary>
        /// <remarks>
        /// Everything that has no custom configuration will use the default settings.
        /// </remarks>
        public MessageFormat(Time time)
        {
            this.time = time;
        }
        /// <summary>
        /// Constructor, to create a MessageFormate object with custom settings, that can be used to customize the logger
        /// </summary>
        /// <remarks>
        /// Everything that has no custom configuration will use the default settings.
        /// </remarks>
        public MessageFormat(Time time, Tag defaultTag)
        {
            this.time = time;
            this.defaultTag = defaultTag;
        }
        /// <summary>
        /// Constructor, to create a MessageFormate object with custom settings, that can be used to customize the logger
        /// </summary>
        /// <remarks>
        /// Everything that has no custom configuration will use the default settings.
        /// </remarks>
        public MessageFormat(Time time, Encoding encoding)
        {
            this.time = time;
            this.encoding = encoding;
        }
        /// <summary>
        /// Constructor, to create a MessageFormate object with custom settings, that can be used to customize the logger
        /// </summary>
        /// <remarks>
        /// Everything that has no custom configuration will use the default settings.
        /// </remarks>
        public MessageFormat(Time time, Tag defaultTag, Encoding encoding)
        {
            this.time = time;
            this.defaultTag = defaultTag;
            this.encoding = encoding;
        }
    }
}
