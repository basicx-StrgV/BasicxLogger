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
        /// Gets the datetime format used by the current timestamp instance.
        /// </summary>
        public string Format { get { return String.Format(_format, DateSeparator); } }
        /// <summary>
        /// Gets or Sets the string, that is used to separate each part of the date.
        /// </summary>
        public string DateSeparator { get; set; } = "/";
        /// <summary>
        /// Gets or Sets the culture setting for the formation of AM and PM.
        /// </summary>
        public CultureInfo Culture { get; set; } = CultureInfo.InvariantCulture;


        private readonly string _format;


        private Timestamp(string format)
        {
            _format = format;
        }


        /// <summary>
        /// Get the current timestamp.
        /// </summary>
        /// <returns>
        /// Timstamp as string
        /// </returns>
        public string GetTimestamp()
        {
            return DateTime.Now.ToString(Format, Culture);
        }


        /// <summary>
        /// Gets a <see cref="BasicxLogger.Timestamp"/> with the selected format.
        /// </summary>
        /// <remarks>
        /// Formate: "yyyy'/'MM'/'dd HH:mm:ss"
        /// </remarks>
        public static Timestamp Year_Month_Day_Hour24_Min_Sec { get { return new Timestamp("yyyy'{0}'MM'{0}'dd HH:mm:ss"); } }
        /// <summary>
        /// Gets a <see cref="BasicxLogger.Timestamp"/> with the selected format.
        /// </summary>
        /// <remarks>
        /// Formate: "yyyy'/'MM'/'dd hh:mm:ss tt"
        /// </remarks>
        public static Timestamp Year_Month_Day_Hour12_Min_Sec { get { return new Timestamp("yyyy'{0}'MM'{0}'dd hh:mm:ss tt"); } }
        /// <summary>
        /// Gets a <see cref="BasicxLogger.Timestamp"/> with the selected format.
        /// </summary>
        /// <remarks>
        /// Formate: "yyyy'/'dd'/'MM HH:mm:ss"
        /// </remarks>
        public static Timestamp Year_Day_Month_Hour24_Min_Sec { get { return new Timestamp("yyyy'{0}'dd'{0}'MM HH:mm:ss"); } }
        /// <summary>
        /// Gets a <see cref="BasicxLogger.Timestamp"/> with the selected format.
        /// </summary>
        /// <remarks>
        /// Formate: "yyyy'/'dd'/'MM hh:mm:ss tt"
        /// </remarks>
        public static Timestamp Year_Day_Month_Hour12_Min_Sec { get { return new Timestamp("yyyy'{0}'dd'{0}'MM hh:mm:ss tt"); } }
        /// <summary>
        /// Gets a <see cref="BasicxLogger.Timestamp"/> with the selected format.
        /// </summary>
        /// <remarks>
        /// Formate: "dd'/'MM'/'yyyy HH:mm:ss"
        /// </remarks>
        public static Timestamp Day_Month_Year_Hour24_Min_Sec { get { return new Timestamp("dd'{0}'MM'{0}'yyyy HH:mm:ss"); } }
        /// <summary>
        /// Gets a <see cref="BasicxLogger.Timestamp"/> with the selected format.
        /// </summary>
        /// <remarks>
        /// Formate: "dd'/'MM'/'yyyy hh:mm:ss tt"
        /// </remarks>
        public static Timestamp Day_Month_Year_Hour12_Min_Sec { get { return new Timestamp("dd'{0}'MM'{0}'yyyy hh:mm:ss tt"); } }
        /// <summary>
        /// Gets a <see cref="BasicxLogger.Timestamp"/> with the selected format.
        /// </summary>
        /// <remarks>
        /// Formate: "MM'/'dd'/'yyyy HH:mm:ss"
        /// </remarks>
        public static Timestamp Month_Day_Year_Hour24_Min_Sec { get { return new Timestamp("MM'{0}'dd'{0}'yyyy HH:mm:ss"); } }
        /// <summary>
        /// Gets a <see cref="BasicxLogger.Timestamp"/> with the selected format.
        /// </summary>
        /// <remarks>
        /// Formate: "MM'/'dd'/'yyyy hh:mm:ss tt"
        /// </remarks>
        public static Timestamp Month_Day_Year_Hour12_Min_Sec { get { return new Timestamp("MM'{0}'dd'{0}'yyyy hh:mm:ss tt"); } }
    }
}
