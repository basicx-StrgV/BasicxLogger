//--------------------------------------------------//
// Created by basicx-StrgV                          //
// https://github.com/basicx-StrgV/BasicxLogger     //
//--------------------------------------------------//
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


        private List<string> timeFormateList;


        public Time(TimeFormat timeFormat)
        {
            initalizeList();
            this.timeFormat = timeFormat;
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
