//--------------------------------------------------//
// Created by basicx-StrgV                          //
// https://github.com/basicx-StrgV/BasicxLogger     //
//--------------------------------------------------//
using System;
using System.Globalization;
using System.Collections.Generic;

namespace BasicxLogger
{
    /// <summary>
    /// Timestamp class to configure and create timestamps
    /// </summary>
    public class Timestamp
    {
        /// <summary>
        /// Format of the timestamp
        /// </summary>
        public string Format { get; }
        /// <summary>
        /// Culture setting for the formation of AM and PM
        /// </summary>
        public CultureInfo Culture { get; } = CultureInfo.InvariantCulture;

        private char _dateSeparator = '/';
        private List<string> _timestampFormateList;

        /// <summary>
        /// Initializes a new instance of the <see cref="BasicxLogger.Timestamp"/> class
        /// </summary>
        /// <param name="format">Formating of the timstamp</param>
        public Timestamp(TimestampFormat format)
        {
            InitalizeList();
            Format = _timestampFormateList[(int)format];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BasicxLogger.Timestamp"/> class
        /// </summary>
        /// <param name="format">Formating of the timstamp</param>
        /// <param name="dateSeparator">Char that separates the day, month and year</param>
        public Timestamp(TimestampFormat format, char dateSeparator)
        {
            _dateSeparator = dateSeparator;
            InitalizeList();
            Format = _timestampFormateList[(int)format];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BasicxLogger.Timestamp"/> class
        /// </summary>
        /// <param name="format">Formating of the timstamp</param>
        public Timestamp(string format)
        {
            InitalizeList();
            Format = format;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BasicxLogger.Timestamp"/> class
        /// </summary>
        /// <param name="format">Formating of the timstamp</param>
        /// <param name="cultureInfo">Culture information to customize the formation of AM and PM</param>
        public Timestamp(TimestampFormat format, CultureInfo cultureInfo)
        {
            Culture = cultureInfo;
            InitalizeList();
            Format = _timestampFormateList[(int)format];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BasicxLogger.Timestamp"/> class
        /// </summary>
        /// <param name="format">Formating of the timstamp</param>
        /// <param name="dateSeparator">Char that separates the day, month and year</param>
        /// <param name="cultureInfo">Culture information to customize the formation of AM and PM</param>
        public Timestamp(TimestampFormat format, char dateSeparator, CultureInfo cultureInfo)
        {
            Culture = cultureInfo;
            _dateSeparator = dateSeparator;
            InitalizeList();
            Format = _timestampFormateList[(int)format];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BasicxLogger.Timestamp"/> class
        /// </summary>
        /// <param name="format">Formating of the timstamp</param>
        /// <param name="cultureInfo">Culture information to customize the formation of AM and PM</param>
        public Timestamp(string format, CultureInfo cultureInfo)
        {
            Culture = cultureInfo;
            InitalizeList();
            Format = format;
        }


        /// <summary>
        /// Get the current timestamp
        /// </summary>
        /// <returns>
        /// Timstamp as string
        /// </returns>
        public string GetTimestamp()
        {
            return DateTime.Now.ToString(Format, Culture);
        }


        private void InitalizeList()
        {
            _timestampFormateList = new List<string>
            {
                String.Format("yyyy'{0}'MM'{0}'dd HH:mm", _dateSeparator),
                String.Format("yyyy'{0}'MM'{0}'dd HH:mm:ss", _dateSeparator),
                String.Format("yyyy'{0}'MM'{0}'dd HH:mm:ss.fff", _dateSeparator),
                String.Format("yyyy'{0}'MM'{0}'dd hh:mm tt", _dateSeparator),
                String.Format("yyyy'{0}'MM'{0}'dd hh:mm:ss tt", _dateSeparator),
                String.Format("yyyy'{0}'MM'{0}'dd hh:mm:ss.fff tt", _dateSeparator),
                //-------------------------------
                String.Format("yyyy'{0}'dd'{0}'MM HH:mm", _dateSeparator),
                String.Format("yyyy'{0}'dd'{0}'MM HH:mm:ss", _dateSeparator),
                String.Format("yyyy'{0}'dd'{0}'MM HH:mm:ss.fff", _dateSeparator),
                String.Format("yyyy'{0}'dd'{0}'MM hh:mm tt", _dateSeparator),
                String.Format("yyyy'{0}'dd'{0}'MM hh:mm:ss tt", _dateSeparator),
                String.Format("yyyy'{0}'dd'{0}'MM hh:mm:ss.fff tt", _dateSeparator),
                //-------------------------------
                String.Format("dd'{0}'MM'{0}'yyyy HH:mm", _dateSeparator),
                String.Format("dd'{0}'MM'{0}'yyyy HH:mm:ss", _dateSeparator),
                String.Format("dd'{0}'MM'{0}'yyyy HH:mm:ss.fff", _dateSeparator),
                String.Format("dd'{0}'MM'{0}'yyyy hh:mm tt", _dateSeparator),
                String.Format("dd'{0}'MM'{0}'yyyy hh:mm:ss tt", _dateSeparator),
                String.Format("dd'{0}'MM'{0}'yyyy hh:mm:ss.fff tt", _dateSeparator),
                //-------------------------------
                String.Format("MM'{0}'dd'{0}'yyyy HH:mm", _dateSeparator),
                String.Format("MM'{0}'dd'{0}'yyyy HH:mm:ss", _dateSeparator),
                String.Format("MM'{0}'dd'{0}'yyyy HH:mm:ss.fff", _dateSeparator),
                String.Format("MM'{0}'dd'{0}'yyyy hh:mm tt", _dateSeparator),
                String.Format("MM'{0}'dd'{0}'yyyy hh:mm:ss tt", _dateSeparator),
                String.Format("MM'{0}'dd'{0}'yyyy hh:mm:ss.fff tt", _dateSeparator),
                //-------------------------------
                String.Format("yyyy'{0}'MM'{0}'dd", _dateSeparator),
                String.Format("yyyy'{0}'dd'{0}'MM", _dateSeparator),
                String.Format("dd'{0}'MM'{0}'yyyy", _dateSeparator),
                String.Format("MM'{0}'dd'{0}'yyyy", _dateSeparator),
                //-------------------------------
                "HH:mm",
                "HH:mm:ss",
                "HH:mm:ss.fff",
                "hh:mm tt",
                "hh:mm:ss tt",
                "hh:mm:ss.fff tt"
            };
        }
    }
}
