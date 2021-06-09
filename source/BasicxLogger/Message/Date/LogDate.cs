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
    public class LogDate
    {
        /// <summary>
        /// Enum that contains the formate of the date
        /// </summary>
        public DateFormat Format { get; }
        /// <summary>
        /// Char that separates each part of the date
        /// </summary>
        public char Separator { get; } = '/';
        /// <summary>
        /// Format string for the date (e.g. yyyy'-'MM'-'dd)
        /// </summary>
        public string FormatString { get; }


        private List<string> _dateFormateList;

        /// <summary>
        /// Constructor, to create a Date object.
        /// </summary>
        /// <remarks>
        /// Can be used to configure a custom date formate for the logger message formate
        /// </remarks>
        /// <param name="dateFormat">
        /// Enum that contains the formate of the date
        /// </param>
        public LogDate(DateFormat dateFormat)
        {
            InitalizeList();
            this.Format = dateFormat;
            FormatString = _dateFormateList[(int)this.Format];
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
        public LogDate(DateFormat dateFormat, char dateSeparator)
        {
            this.Separator = dateSeparator;
            InitalizeList();
            this.Format = dateFormat;
            FormatString = _dateFormateList[(int)this.Format];
        }


        private void InitalizeList()
        {
            _dateFormateList = new List<string>
            {
                "yyyy'" + Separator + "'MM'" + Separator + "'dd",
                "yyyy'" + Separator + "'dd'" + Separator + "'MM",
                "dd'" + Separator + "'MM'" + Separator + "'yyyy",
                "MM'" + Separator + "'dd'" + Separator + "'yyyy",
                ""
            };
        }
    }
}
