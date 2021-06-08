//--------------------------------------------------//
// Created by basicx-StrgV                          //
// https://github.com/basicx-StrgV/BasicxLogger     //
//--------------------------------------------------//
namespace BasicxLogger.Message
{
    /// <summary>
    /// Enum that contains every message tag you can use
    /// </summary>
    public enum Tag
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
        /// If you dont want to have a tag
        /// </summary>
        none
    }
}
