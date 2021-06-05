//--------------------------------------------------//
// Created by basicx-StrgV                          //
// https://github.com/basicx-StrgV/BasicxLogger     //
//--------------------------------------------------//
namespace BasicxLogger.Message
{
    /// <summary>
    /// Enum that contains every supported time format
    /// </summary>
    public enum TimeFormat
    {
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
        hour12_min_sec_millisec,
        /// <summary>
        /// Select, if you dont want to have the time in your log file
        /// </summary>
        none
    }
}
