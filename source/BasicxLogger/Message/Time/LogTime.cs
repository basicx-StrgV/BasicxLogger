//--------------------------------------------------//
// Created by basicx-StrgV                          //
// https://github.com/basicx-StrgV/BasicxLogger     //
//--------------------------------------------------//
using System.Globalization;
using System.Collections.Generic;

namespace BasicxLogger.Message
{
    /// <summary>
    /// Contains the information about the time formatting for the log message
    /// </summary>
    public class LogTime
    {
        /// <summary>
        /// Enum that contains the formate of the time
        /// </summary>
        public TimeFormat Format { get; }
        /// <summary>
        /// Format string for the time (e.g. HH:mm:ss)
        /// </summary>
        public string FormatString { get; }
        /// <summary>
        /// Holds the culture information to correctly display AM/PM, when the 12 hour time formate is used
        /// </summary>
        public CultureInfo CultureFormat { get; } = CultureInfo.InvariantCulture;


        private List<string> _timeFormateList;

        /// <summary>
        /// Constructor, to create a Time object.
        /// </summary>
        /// <remarks>
        /// Can be used to configure a custom time formate for the logger message formate
        /// </remarks>
        /// <param name="timeFormat">
        /// Enum that contains the formate of the time
        /// </param>
        public LogTime(TimeFormat timeFormat)
        {
            InitalizeList();
            this.Format = timeFormat;
            FormatString = _timeFormateList[(int)this.Format];
        }
        /// <summary>
        /// Constructor, to create a Time object.
        /// </summary>
        /// <remarks>
        /// Can be used to configure a custom time formate for the logger message formate
        /// </remarks>
        /// <param name="timeFormat">
        /// Enum that contains the formate of the time
        /// </param>
        /// <param name="cultureInfo">
        /// The culture information to correctly display AM/PM, when the 12 hour time formate is used
        /// </param>
        public LogTime(TimeFormat timeFormat, CultureInfo cultureInfo)
        {
            InitalizeList();
            this.Format = timeFormat;
            this.CultureFormat = cultureInfo;
            FormatString = _timeFormateList[(int)this.Format];
        }

        private void InitalizeList()
        {
            _timeFormateList = new List<string>
            {
                "HH:mm",
                "HH:mm:ss",
                "HH:mm:ss.fff",
                "hh:mm tt",
                "hh:mm:ss tt",
                "hh:mm:ss.fff tt",
                ""
            };
        }
    }
}
