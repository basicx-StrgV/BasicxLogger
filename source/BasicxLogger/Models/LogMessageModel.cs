//--------------------------------------------------//
// Created by basicx-StrgV                          //
// https://github.com/basicx-StrgV/BasicxLogger     //
//--------------------------------------------------//
using System.Text.Json.Serialization;

namespace BasicxLogger.Models
{
    /// <summary>
    /// Data model for one log message in a json log file
    /// </summary>
    public class LogMessageModel
    {
        /// <summary>
        /// The log message id
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// The log message timestamp
        /// </summary>
        [JsonPropertyName("timestamp")]
        public string Timestamp { get; set; }

        /// <summary>
        /// The log message tag
        /// </summary>
        [JsonPropertyName("tag")]
        public string Tag { get; set; }

        /// <summary>
        /// The log message
        /// </summary>
        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}
