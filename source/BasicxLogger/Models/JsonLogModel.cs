//--------------------------------------------------//
// Created by basicx-StrgV                          //
// https://github.com/basicx-StrgV/BasicxLogger     //
//--------------------------------------------------//
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BasicxLogger.Models
{
    /// <summary>
    /// Data model for the json log file
    /// </summary>
    public class JsonLogModel<T>
    {
        /// <summary>
        /// List of log messages
        /// </summary>
        [JsonPropertyName("entrys")]
        public List<T> Entrys { get; set; }
    }
}
