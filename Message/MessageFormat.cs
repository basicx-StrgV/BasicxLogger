//--------------------------------------------------//
// Created by basicx-StrgV                          //
// https://github.com/basicx-StrgV/BasicxLogger     //
//--------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicxLogger.Message
{
    public class MessageFormat
    {
        //Remove later---------------------------------------------------
        [Obsolete("This propertie is obsolete and will be removed soon. Please use MessageFormat.Date.dateFormat instead", false)]
        /// <summary>
        /// This propertie is obsolete and will be removed soon. Please use MessageFormat.Date.dateFormat instead
        /// </summary>
        public DateFormat dateFormat { get; } = DateFormat.year_month_day;
        [Obsolete("This propertie is obsolete and will be removed soon. Please use MessageFormat.Date.dateFormatString instead", false)]
        /// <summary>
        /// This propertie is obsolete and will be removed soon. Please use MessageFormat.Date.dateFormatString instead
        /// </summary>
        public string dateFormatString { get; }
        [Obsolete("This propertie is obsolete and will be removed soon. Please use MessageFormat.Date.dateSeparator instead", false)]
        /// <summary>
        /// This propertie is obsolete and will be removed soon. Please use MessageFormat.Date.dateSeparator instead
        /// </summary>
        public char dateSeparator { get; } = '/';
        [Obsolete("This propertie is obsolete and will be removed soon. Please use MessageFormat.Time.timeFormatString instead", false)]
        /// <summary>
        /// This propertie is obsolete and will be removed soon. Please use MessageFormat.Time.timeFormatString instead
        /// </summary>
        public string timeFormatString { get; } = "HH:mm:ss";
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

        //Remove in next Version
        private List<string> dateFormateList;

        //Remove in next Version---------------------------------------------------
        [Obsolete("This constructor is obsolete and will be removed with the next update. Please use the 'Date' object in the constructor to configure the date formate", true)]
        public MessageFormat(DateFormat dateFormat)
        {
            initalizeList();
            this.dateFormat = dateFormat;
            dateFormatString = dateFormateList[(int)this.dateFormat];
        }
        [Obsolete("This constructor is obsolete and will be removed with the next update. Please use the 'Date' object in the constructor to configure the date formate", true)]
        public MessageFormat(DateFormat dateFormat, char dateSeparator)
        {
            this.dateSeparator = dateSeparator;
            initalizeList();
            this.dateFormat = dateFormat;
            dateFormatString = dateFormateList[(int)this.dateFormat];
        }
        [Obsolete("This constructor is obsolete and will be removed with the next update. Please use the 'Date' object in the constructor to configure the date formate", true)]
        public MessageFormat(DateFormat dateFormat, Encoding encoding)
        {
            initalizeList();
            this.dateFormat = dateFormat;
            dateFormatString = dateFormateList[(int)this.dateFormat];
            this.encoding = encoding;
        }
        [Obsolete("This constructor is obsolete and will be removed with the next update. Please use the 'Date' object in the constructor to configure the date formate", true)]
        public MessageFormat(DateFormat dateFormat, char dateSeparator, Encoding encoding)
        {
            this.dateSeparator = dateSeparator;
            initalizeList();
            this.dateFormat = dateFormat;
            dateFormatString = dateFormateList[(int)this.dateFormat];
            this.encoding = encoding;
        }
        [Obsolete("This constructor is obsolete and will be removed with the next update. Please use the 'Date' object in the constructor to configure the date formate", true)]
        public MessageFormat(char dateSeparator)
        {
            this.dateSeparator = dateSeparator;
            initalizeList();
            dateFormatString = dateFormateList[(int)dateFormat];
        }
        [Obsolete("This constructor is obsolete and will be removed with the next update. Please use the 'Date' object in the constructor to configure the date formate", true)]
        public MessageFormat(char dateSeparator, Encoding encoding)
        {
            this.dateSeparator = dateSeparator;
            initalizeList();
            dateFormatString = dateFormateList[(int)dateFormat];
            this.encoding = encoding;
        }
        //----------------------------------------------------------------------

        public MessageFormat(Encoding encoding)
        {
            this.encoding = encoding;

            //Remove in next Version
            dateFormat = date.dateFormat;
            dateSeparator = date.dateSeparator;
            dateFormatString = date.dateFormatString;
            timeFormatString = time.timeFormatString;
        }

        public MessageFormat(Date date)
        {
            this.date = date;

            //Remove later
            dateFormat = this.date.dateFormat;
            dateSeparator = this.date.dateSeparator;
            dateFormatString = this.date.dateFormatString;
            timeFormatString = time.timeFormatString;
        }

        public MessageFormat(Date date, Time time)
        {
            this.date = date;
            this.time = time;

            //Remove later
            dateFormat = this.date.dateFormat;
            dateSeparator = this.date.dateSeparator;
            dateFormatString = this.date.dateFormatString;
            timeFormatString = this.time.timeFormatString;
        }

        public MessageFormat(Date date, Tag defaultTag)
        {
            this.date = date;
            this.defaultTag = defaultTag;

            //Remove later
            dateFormat = this.date.dateFormat;
            dateSeparator = this.date.dateSeparator;
            dateFormatString = this.date.dateFormatString;
            timeFormatString = time.timeFormatString;
        }

        public MessageFormat(Date date, Encoding encoding)
        {
            this.date = date;
            this.encoding = encoding;

            //Remove later
            dateFormat = this.date.dateFormat;
            dateSeparator = this.date.dateSeparator;
            dateFormatString = this.date.dateFormatString;
            timeFormatString = time.timeFormatString;
        }

        public MessageFormat(Date date, Time time, Tag defaultTag)
        {
            this.date = date;
            this.time = time;
            this.defaultTag = defaultTag;

            //Remove later
            dateFormat = this.date.dateFormat;
            dateSeparator = this.date.dateSeparator;
            dateFormatString = this.date.dateFormatString;
            timeFormatString = this.time.timeFormatString;
        }

        public MessageFormat(Date date, Tag defaultTag, Encoding encoding)
        {
            this.date = date;
            this.defaultTag = defaultTag;
            this.encoding = encoding;

            //Remove later
            dateFormat = this.date.dateFormat;
            dateSeparator = this.date.dateSeparator;
            dateFormatString = this.date.dateFormatString;
            timeFormatString = time.timeFormatString;
        }

        public MessageFormat(Date date, Time time, Encoding encoding)
        {
            this.date = date;
            this.encoding = encoding;
            this.time = time;

            //Remove later
            dateFormat = this.date.dateFormat;
            dateSeparator = this.date.dateSeparator;
            dateFormatString = this.date.dateFormatString;
            timeFormatString = this.time.timeFormatString;
        }

        public MessageFormat(Date date, Time time, Tag defaultTag, Encoding encoding)
        {
            this.date = date;
            this.time = time;
            this.defaultTag = defaultTag;
            this.encoding = encoding;

            //Remove later
            dateFormat = this.date.dateFormat;
            dateSeparator = this.date.dateSeparator;
            dateFormatString = this.date.dateFormatString;
            timeFormatString = this.time.timeFormatString;
        }

        public MessageFormat(Time time)
        {
            this.time = time;

            //Remove later
            dateFormat = date.dateFormat;
            dateSeparator = date.dateSeparator;
            dateFormatString = date.dateFormatString;
            timeFormatString = this.time.timeFormatString;
        }

        public MessageFormat(Time time, Tag defaultTag)
        {
            this.time = time;
            this.defaultTag = defaultTag;

            //Remove later
            dateFormat = date.dateFormat;
            dateSeparator = date.dateSeparator;
            dateFormatString = date.dateFormatString;
            timeFormatString = this.time.timeFormatString;
        }

        public MessageFormat(Time time, Encoding encoding)
        {
            this.time = time;
            this.encoding = encoding;

            //Remove later
            dateFormat = date.dateFormat;
            dateSeparator = date.dateSeparator;
            dateFormatString = date.dateFormatString;
            timeFormatString = this.time.timeFormatString;
        }

        public MessageFormat(Time time, Tag defaultTag, Encoding encoding)
        {
            this.time = time;
            this.defaultTag = defaultTag;
            this.encoding = encoding;

            //Remove later
            dateFormat = date.dateFormat;
            dateSeparator = date.dateSeparator;
            dateFormatString = date.dateFormatString;
            timeFormatString = this.time.timeFormatString;
        }

        //Remove in next Version
        private void initalizeList()
        {
            dateFormateList = new List<string>
            {
                "yyyy'" + dateSeparator + "'MM'" + dateSeparator + "'dd",
                "yyyy'" + dateSeparator + "'dd'" + dateSeparator + "'MM",
                "dd'" + dateSeparator + "'MM'" + dateSeparator + "'yyyy",
                "MM'" + dateSeparator + "'dd'" + dateSeparator + "'yyyy",
                ""
            };
        }
    }
}
