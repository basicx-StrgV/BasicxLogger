//--------------------------------------------------//
// Created by basicx-StrgV                          //
// https://github.com/basicx-StrgV/BasicxLogger     //
//--------------------------------------------------//
using System.Collections.Generic;

namespace BasicxLogger
{
    /// <summary>
    /// Data model for the json log file
    /// </summary>
    public class JsonLogModel
    {
        /// <summary>
        /// List of log messages
        /// </summary>
        public List<LogMessageModel> entrys { get; set; }
    }
}
