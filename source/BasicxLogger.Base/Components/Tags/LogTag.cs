//--------------------------------------------------//
// Created by basicx-StrgV                          //
// https://github.com/basicx-StrgV/BasicxLogger     //
//--------------------------------------------------//
namespace BasicxLogger
{
    /// <summary>
    /// Enum that contains the message tags, that can be used for logging
    /// </summary>
    public enum LogTag
    {
        /// <summary>
        /// Tag: [INFO]
        /// </summary>
        INFO,
        /// <summary>
        /// Tag: [WARNING]
        /// </summary>
        WARNING,
        /// <summary>
        /// Tag: [ERROR]
        /// </summary>
        ERROR,
        /// <summary>
        /// Tag: [FATAL]
        /// </summary>
        FATAL,
        /// <summary>
        /// Tag: [EXCEPTION]
        /// </summary>
        EXCEPTION,
        /// <summary>
        /// Tag: [DEBUGGING]
        /// </summary>
        DEBUGGING,
        /// <summary>
        /// Tag: [MESSAGE]
        /// </summary>
        MESSAGE,
        /// <summary>
        /// Tag: [ALERT]
        /// </summary>
        ALERT,
        /// <summary>
        /// Tag: [EVENT]
        /// </summary>
        EVENT,
        /// <summary>
        /// Tag: [TEST]
        /// </summary>
        TEST,
        /// <summary>
        /// No Tag. Default value for the DefaultTag
        /// </summary>
        none
    }
}
