//--------------------------------------------------//
// Created by basicx-StrgV                          //
// https://github.com/basicx-StrgV/BasicxLogger     //
//--------------------------------------------------//
namespace BasicxLogger.Message
{
    /// <summary>
    /// Enum that contains every supported date format
    /// </summary>
    public enum DateFormat
    {
        /// <summary>
        /// Formate: "yyyy'/'MM'/'dd"
        /// </summary>
        year_month_day,
        /// <summary>
        /// Formate: "yyyy'/'dd'/'MM"
        /// </summary>
        year_day_month,
        /// <summary>
        /// Formate: "dd'/'MM'/'yyyy"
        /// </summary>
        day_month_year,
        /// <summary>
        /// Formate: "MM'/'dd'/'yyyy"
        /// </summary>
        month_day_year,
        /// <summary>
        /// Select, if you dont want to have the time in your log file
        /// </summary>
        none
    }
}
