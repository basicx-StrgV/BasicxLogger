//--------------------------------------------------//
// Created by basicx-StrgV                          //
// https://github.com/basicx-StrgV/BasicxLogger     //
//--------------------------------------------------//
using System;
using System.Globalization;

namespace BasicxLogger
{
    /// <summary>
    /// Timestamp class to configure and create timestamps
    /// </summary>
    public class Timestamp
    {
        /// <summary>
        /// Gets the datetime format used by the current timestamp instance
        /// </summary>
        public string Format { get { return String.Format(_format, DateSeparator); } }
        /// <summary>
        /// Gets or Sets the char, that is used to separate each part of the date
        /// </summary>
        public char DateSeparator { get; set; } = '/';
        /// <summary>
        /// Gets or Sets the culture setting for the formation of AM and PM
        /// </summary>
        public CultureInfo Culture { get; set; } = CultureInfo.InvariantCulture;


        private string _format;


        /// <summary>
        /// Initializes a new instance of the <see cref="BasicxLogger.Timestamp"/> class
        /// </summary>
        /// <param name="format">Formating of the timstamp</param>
        private Timestamp(string format)
        {
            _format = format;
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


        /// <summary>
        /// Gets a <see cref="BasicxLogger.Timestamp"/> with the selected format
        /// </summary>
        /// <remarks>
        /// Formate: "yyyy'/'MM'/'dd HH:mm:ss"
        /// </remarks>
        public static Timestamp year_month_day_hour24_min_sec { get { return new Timestamp("yyyy'{0}'MM'{0}'dd HH:mm:ss"); } }
        /// <summary>
        /// Gets a <see cref="BasicxLogger.Timestamp"/> with the selected format
        /// </summary>
        /// <remarks>
        /// Formate: "yyyy'/'MM'/'dd hh:mm:ss tt"
        /// </remarks>
        public static Timestamp year_month_day_hour12_min_sec { get { return new Timestamp("yyyy'{0}'MM'{0}'dd hh:mm:ss tt"); } }
        /// <summary>
        /// Gets a <see cref="BasicxLogger.Timestamp"/> with the selected format
        /// </summary>
        /// <remarks>
        /// Formate: "yyyy'/'dd'/'MM HH:mm:ss"
        /// </remarks>
        public static Timestamp year_day_month_hour24_min_sec { get { return new Timestamp("yyyy'{0}'dd'{0}'MM HH:mm:ss"); } }
        /// <summary>
        /// Gets a <see cref="BasicxLogger.Timestamp"/> with the selected format
        /// </summary>
        /// <remarks>
        /// Formate: "yyyy'/'dd'/'MM hh:mm:ss tt"
        /// </remarks>
        public static Timestamp year_day_month_hour12_min_sec { get { return new Timestamp("yyyy'{0}'dd'{0}'MM hh:mm:ss tt"); } }
        /// <summary>
        /// Gets a <see cref="BasicxLogger.Timestamp"/> with the selected format
        /// </summary>
        /// <remarks>
        /// Formate: "dd'/'MM'/'yyyy HH:mm:ss"
        /// </remarks>
        public static Timestamp day_month_year_hour24_min_sec { get { return new Timestamp("dd'{0}'MM'{0}'yyyy HH:mm:ss"); } }
        /// <summary>
        /// Gets a <see cref="BasicxLogger.Timestamp"/> with the selected format
        /// </summary>
        /// <remarks>
        /// Formate: "dd'/'MM'/'yyyy hh:mm:ss tt"
        /// </remarks>
        public static Timestamp day_month_year_hour12_min_sec { get { return new Timestamp("dd'{0}'MM'{0}'yyyy hh:mm:ss tt"); } }
        /// <summary>
        /// Gets a <see cref="BasicxLogger.Timestamp"/> with the selected format
        /// </summary>
        /// <remarks>
        /// Formate: "MM'/'dd'/'yyyy HH:mm:ss"
        /// </remarks>
        public static Timestamp month_day_year_hour24_min_sec { get { return new Timestamp("MM'{0}'dd'{0}'yyyy HH:mm:ss"); } }
        /// <summary>
        /// Gets a <see cref="BasicxLogger.Timestamp"/> with the selected format
        /// </summary>
        /// <remarks>
        /// Formate: "MM'/'dd'/'yyyy hh:mm:ss tt"
        /// </remarks>
        public static Timestamp month_day_year_hour12_min_sec { get { return new Timestamp("MM'{0}'dd'{0}'yyyy hh:mm:ss tt"); } }
    }
}
