using System.Collections.Generic;

namespace BasicxLogger.Message
{
    public class MessageFormat
    {
        public DateFormat dateFormat { get; }
        public string dateFormatString { get; }
        public char dateSeparator { get; } = '/';
        public string timeFormatString { get; } = "HH:mm:ss";


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
