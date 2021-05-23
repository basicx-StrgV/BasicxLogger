//--------------------------------------------------//
// Created by basicx-StrgV                          //
// https://github.com/basicx-StrgV/BasicxLogger     //
//--------------------------------------------------//
using System;
using System.Text;

namespace BasicxLogger.Message
{
    public class MessageFormat
    {
        //Remove in next update---------------------------------------------------
        [Obsolete("This propertie is obsolete and will be removed with the next update. Please use MessageFormat.Date.dateFormat instead", true)]
        public DateFormat dateFormat { get; }
        [Obsolete("This propertie is obsolete and will be removed with the next update. Please use MessageFormat.Date.dateFormatString instead", true)]
        public string dateFormatString { get; }
        [Obsolete("This propertie is obsolete and will be removed with the next update. Please use MessageFormat.Date.dateSeparator instead", true)]
        public char dateSeparator { get; }
        [Obsolete("This propertie is obsolete and will be removed with the next update. Please use MessageFormat.Time.timeFormatString instead", true)]
        public string timeFormatString { get; }
        //----------------------------------------------------------------------

        /// <summary>
        /// Contains the information about the date formation for the log message
        /// </summary>
        public Date date { get; } = new Date(DateFormat.year_month_day, '/');
        /// <summary>
        /// Contains the information about the time formation for the log message
        /// </summary>
        public Time time { get; } = new Time(TimeFormat.hour24_min_sec);
        /// <summary>
        /// A default message tag that will be used if no tag is selected
        /// </summary>
        public Tag defaultTag { get; } = Tag.none;
        /// <summary>
        /// Encoding for the log message
        /// </summary>
        public Encoding encoding { get; } = Encoding.UTF8;


        public MessageFormat(Encoding encoding)
        {
            this.encoding = encoding;
        }

        public MessageFormat(Date date)
        {
            this.date = date;
        }

        public MessageFormat(Date date, Time time)
        {
            this.date = date;
            this.time = time;
        }

        public MessageFormat(Date date, Tag defaultTag)
        {
            this.date = date;
            this.defaultTag = defaultTag;
        }

        public MessageFormat(Date date, Encoding encoding)
        {
            this.date = date;
            this.encoding = encoding;
        }

        public MessageFormat(Date date, Time time, Tag defaultTag)
        {
            this.date = date;
            this.time = time;
            this.defaultTag = defaultTag;
        }

        public MessageFormat(Date date, Tag defaultTag, Encoding encoding)
        {
            this.date = date;
            this.defaultTag = defaultTag;
            this.encoding = encoding;
        }

        public MessageFormat(Date date, Time time, Encoding encoding)
        {
            this.date = date;
            this.encoding = encoding;
            this.time = time;
        }

        public MessageFormat(Date date, Time time, Tag defaultTag, Encoding encoding)
        {
            this.date = date;
            this.time = time;
            this.defaultTag = defaultTag;
            this.encoding = encoding;
        }

        public MessageFormat(Time time)
        {
            this.time = time;
        }

        public MessageFormat(Time time, Tag defaultTag)
        {
            this.time = time;
            this.defaultTag = defaultTag;
        }

        public MessageFormat(Time time, Encoding encoding)
        {
            this.time = time;
            this.encoding = encoding;
        }

        public MessageFormat(Time time, Tag defaultTag, Encoding encoding)
        {
            this.time = time;
            this.defaultTag = defaultTag;
            this.encoding = encoding;
        }
    }
}
