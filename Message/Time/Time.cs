//--------------------------------------------------//
// Created by basicx-StrgV                          //
// https://github.com/basicx-StrgV/BasicxLogger     //
//--------------------------------------------------//
using System.Globalization;
using System.Collections.Generic;

namespace BasicxLogger.Message
{
    public class Time
    {
        /// <summary>
        /// Formate of the time
        /// </summary>
        public TimeFormat timeFormat { get; }
        /// <summary>
        /// Format string for the time (e.g. HH:mm:ss)
        /// </summary>
        public string timeFormatString { get; }
        /// <summary>
        /// Holds the culture information to correctly display AM/PM, when the 12 hour time formate is used
        /// </summary>
        public CultureInfo cultureInfo { get; } = CultureInfo.InvariantCulture;


        private List<string> timeFormateList;


        public Time(TimeFormat timeFormat)
        {
            initalizeList();
            this.timeFormat = timeFormat;
            timeFormatString = timeFormateList[(int)this.timeFormat];
        }

        public Time(TimeFormat timeFormat, CultureInfo cultureInfo)
        {
            initalizeList();
            this.timeFormat = timeFormat;
            this.cultureInfo = cultureInfo;
            timeFormatString = timeFormateList[(int)this.timeFormat];
        }

        private void initalizeList()
        {
            timeFormateList = new List<string>
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
