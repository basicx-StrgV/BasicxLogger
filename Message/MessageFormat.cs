using System.Collections.Generic;
using System.Text;

namespace BasicxLogger.Message
{
    public class MessageFormat
    {
        public DateFormat dateFormat { get; } = DateFormat.year_month_day;
        public string dateFormatString { get; }
        public char dateSeparator { get; } = '/';
        public string timeFormatString { get; } = "HH:mm:ss";
        public Encoding encoding { get; } = Encoding.UTF8;


        private List<string> dateFormateList;


        public MessageFormat(DateFormat dateFormat)
        {
            initalizeList();
            this.dateFormat = dateFormat;
            dateFormatString = dateFormateList[(int)this.dateFormat];
        }

        public MessageFormat(DateFormat dateFormat, char dateSeparator)
        {
            this.dateSeparator = dateSeparator;
            initalizeList();
            this.dateFormat = dateFormat;
            dateFormatString = dateFormateList[(int)this.dateFormat];
        }

        public MessageFormat(DateFormat dateFormat, Encoding encoding)
        {
            initalizeList();
            this.dateFormat = dateFormat;
            dateFormatString = dateFormateList[(int)this.dateFormat];
            this.encoding = encoding;
        }

        public MessageFormat(DateFormat dateFormat, char dateSeparator, Encoding encoding)
        {
            this.dateSeparator = dateSeparator;
            initalizeList();
            this.dateFormat = dateFormat;
            dateFormatString = dateFormateList[(int)this.dateFormat];
            this.encoding = encoding;
        }

        public MessageFormat(char dateSeparator)
        {
            this.dateSeparator = dateSeparator;
            initalizeList();
            dateFormatString = dateFormateList[(int)dateFormat];
        }

        public MessageFormat(char dateSeparator, Encoding encoding)
        {
            this.dateSeparator = dateSeparator;
            initalizeList();
            dateFormatString = dateFormateList[(int)dateFormat];
            this.encoding = encoding;
        }

        public MessageFormat(Encoding encoding)
        {
            initalizeList();
            dateFormatString = dateFormateList[(int)dateFormat];
            this.encoding = encoding;
        }

        private void initalizeList()
        {
            dateFormateList = new List<string>
            {
                "yyyy'" + dateSeparator + "'MM'" + dateSeparator + "'dd ",
                "yyyy'" + dateSeparator + "'dd'" + dateSeparator + "'MM ",
                "dd'" + dateSeparator + "'MM'" + dateSeparator + "'yyyy ",
                "MM'" + dateSeparator + "'dd'" + dateSeparator + "'yyyy ",
                ""
            };
        }

    }
}
