//--------------------------------------------------//
// Created by basicx-StrgV                          //
// https://github.com/basicx-StrgV/BasicxLogger     //
//--------------------------------------------------//
namespace BasicxLogger
{
    /// <summary>
    /// Enum that contains every supported timestamp format
    /// </summary>
    public enum TimestampFormat
    {
        /// <summary>
        /// Formate: "yyyy'/'MM'/'dd HH:mm"
        /// </summary>
        year_month_day_hour24_min,
        /// <summary>
        /// Formate: "yyyy'/'MM'/'dd HH:mm:ss"
        /// </summary>
        year_month_day_hour24_min_sec,
        /// <summary>
        /// Formate: "yyyy'/'MM'/'dd HH:mm:ss.fff"
        /// </summary>
        year_month_day_hour24_min_sec_millisec,
        /// <summary>
        /// Formate: "yyyy'/'MM'/'dd hh:mm tt"
        /// </summary>
        year_month_day_hour12_min,
        /// <summary>
        /// Formate: "yyyy'/'MM'/'dd hh:mm:ss tt"
        /// </summary>
        year_month_day_hour12_min_sec,
        /// <summary>
        /// Formate: "yyyy'/'MM'/'dd hh:mm:ss.fff tt"
        /// </summary>
        year_month_day_hour12_min_sec_millisec,
        //---------------------------------------------------------------
        /// <summary>
        /// Formate: "yyyy'/'dd'/'MM HH:mm"
        /// </summary>
        year_day_month_hour24_min,
        /// <summary>
        /// Formate: "yyyy'/'dd'/'MM HH:mm:ss"
        /// </summary>
        year_day_month_hour24_min_sec,
        /// <summary>
        /// Formate: "yyyy'/'dd'/'MM HH:mm:ss.fff"
        /// </summary>
        year_day_month_hour24_min_sec_millisec,
        /// <summary>
        /// Formate: "yyyy'/'dd'/'MM hh:mm tt"
        /// </summary>
        year_day_month_hour12_min,
        /// <summary>
        /// Formate: "yyyy'/'dd'/'MM hh:mm:ss tt"
        /// </summary>
        year_day_month_hour12_min_sec,
        /// <summary>
        /// Formate: "yyyy'/'dd'/'MM hh:mm:ss.fff tt"
        /// </summary>
        year_day_month_hour12_min_sec_millisec,
        //---------------------------------------------------------------
        /// <summary>
        /// Formate: "dd'/'MM'/'yyyy HH:mm"
        /// </summary>
        day_month_year_hour24_min,
        /// <summary>
        /// Formate: "dd'/'MM'/'yyyy HH:mm:ss"
        /// </summary>
        day_month_year_hour24_min_sec,
        /// <summary>
        /// Formate: "dd'/'MM'/'yyyy HH:mm:ss.fff"
        /// </summary>
        day_month_year_hour24_min_sec_millisec,
        /// <summary>
        /// Formate: "dd'/'MM'/'yyyy hh:mm tt"
        /// </summary>
        day_month_year_hour12_min,
        /// <summary>
        /// Formate: "dd'/'MM'/'yyyy hh:mm:ss tt"
        /// </summary>
        day_month_year_hour12_min_sec,
        /// <summary>
        /// Formate: "dd'/'MM'/'yyyy hh:mm:ss.fff tt"
        /// </summary>
        day_month_year_hour12_min_sec_millisec,
        //---------------------------------------------------------------
        /// <summary>
        /// Formate: "MM'/'dd'/'yyyy HH:mm"
        /// </summary>
        month_day_year_hour24_min,
        /// <summary>
        /// Formate: "MM'/'dd'/'yyyy HH:mm:ss"
        /// </summary>
        month_day_year_hour24_min_sec,
        /// <summary>
        /// Formate: "MM'/'dd'/'yyyy HH:mm:ss.fff"
        /// </summary>
        month_day_year_hour24_min_sec_millisec,
        /// <summary>
        /// Formate: "MM'/'dd'/'yyyy hh:mm tt"
        /// </summary>
        month_day_year_hour12_min,
        /// <summary>
        /// Formate: "MM'/'dd'/'yyyy hh:mm:ss tt"
        /// </summary>
        month_day_year_hour12_min_sec,
        /// <summary>
        /// Formate: "MM'/'dd'/'yyyy hh:mm:ss.fff tt"
        /// </summary>
        month_day_year_hour12_min_sec_millisec,
        //---------------------------------------------------------------
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
        //---------------------------------------------------------------
        /// <summary>
        /// Formate: "HH:mm"
        /// </summary>
        hour24_min,
        /// <summary>
        /// Formate: "HH:mm:ss"
        /// </summary>
        hour24_min_sec,
        /// <summary>
        /// Formate: "HH:mm:ss.fff"
        /// </summary>
        hour24_min_sec_millisec,
        /// <summary>
        /// Formate:  "hh:mm tt"
        /// </summary>
        hour12_min,
        /// <summary>
        /// Formate:  "hh:mm:ss tt"
        /// </summary>
        hour12_min_sec,
        /// <summary>
        /// Formate: "hh:mm:ss.fff tt"
        /// </summary>
        hour12_min_sec_millisec
    }
}
