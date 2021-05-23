//--------------------------------------------------//
// Created by basicx-StrgV                          //
// https://github.com/basicx-StrgV/BasicxLogger     //
//--------------------------------------------------//
using System.Collections.Generic;

namespace BasicxLogger.Message
{
    public class Date
    {
        /// <summary>
        /// Formate of the date
        /// </summary>
        public DateFormat dateFormat { get; }
        /// <summary>
        /// Char that separates each part of the date
        /// </summary>
        public char dateSeparator { get; } = '/';
        /// <summary>
        /// Format string for the date (e.g. yyyy'-'MM'-'dd)
        /// </summary>
        public string dateFormatString { get; }


        private List<string> dateFormateList;


        public Date(DateFormat dateFormat)
        {
            initalizeList();
            this.dateFormat = dateFormat;
            dateFormatString = dateFormateList[(int)this.dateFormat];
        }

        public Date(DateFormat dateFormat, char dateSeparator)
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
                "yyyy'" + dateSeparator + "'MM'" + dateSeparator + "'dd",
                "yyyy'" + dateSeparator + "'dd'" + dateSeparator + "'MM",
                "dd'" + dateSeparator + "'MM'" + dateSeparator + "'yyyy",
                "MM'" + dateSeparator + "'dd'" + dateSeparator + "'yyyy",
                ""
            };
        }
    }
}
