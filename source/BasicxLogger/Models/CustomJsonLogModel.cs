//--------------------------------------------------//
// Created by basicx-StrgV                          //
// https://github.com/basicx-StrgV/BasicxLogger     //
//--------------------------------------------------//
using System.Collections.Generic;

namespace BasicxLogger
{
    /// <summary>
    /// Data model for the custom json log file
    /// </summary>
    public class CustomJsonLogModel<T>
    {
        /// <summary>
        /// List of custom log objects
        /// </summary>
        public List<T> entrys { get; set; }
    }
}
