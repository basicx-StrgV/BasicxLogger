//--------------------------------------------------//
// Created by basicx-StrgV                          //
// https://github.com/basicx-StrgV/BasicxLogger     //
//--------------------------------------------------//
using System.Collections.Generic;

namespace BasicxLogger.Message
{
    /// <summary>
    /// Contains the information about the date formatting for the log message
    /// </summary>
    public class Date
    {
        /// <summary>
        /// Enum that contains the formate of the date
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

        /// <summary>
        /// Constructor, to create a Date object.
        /// </summary>
        /// <remarks>
        /// Can be used to configure a custom date formate for the logger message formate
        /// </remarks>
        /// <param name="dateFormat">
        /// Enum that contains the formate of the date
        /// </param>
        public Date(DateFormat dateFormat)
        {
            initalizeList();
            this.dateFormat = dateFormat;
            dateFormatString = dateFormateList[(int)this.dateFormat];
        }
        /// <summary>
        /// Constructor, to create a Date object.
        /// </summary>
        /// <remarks>
        /// Can be used to configure a custom date formate for the logger message formate
        /// </remarks>
        /// <param name="dateFormat">
        /// Enum that contains the formate of the date
        /// </param>
        /// <param name="dateSeparator">
        /// Char that separates each part of the date
        /// </param>
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
