//--------------------------------------------------//
// Created by basicx-StrgV                          //
// https://github.com/basicx-StrgV/BasicxLogger     //
//--------------------------------------------------//
namespace BasicxLogger.Models
{
#pragma warning disable
    /// <summary>
    /// Data model for one log message in a json log file
    /// </summary>
    public class LogMessageModel
    {
        /// <summary>
        /// The log message id
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// The log message timestamp
        /// </summary>
        public string timestamp { get; set; }
        /// <summary>
        /// The log message tag
        /// </summary>
        public string tag { get; set; }
        /// <summary>
        /// The log message
        /// </summary>
        public string message { get; set; }
    }
}
