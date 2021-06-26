//--------------------------------------------------//
// Created by basicx-StrgV                          //
// https://github.com/basicx-StrgV/BasicxLogger     //
//--------------------------------------------------//
using System;

namespace BasicxLogger.Exceptions
{
    /// <summary>
    /// The exception that is thrown when a Log method of the <see cref="BasicxLogger.MultiLogger"/> is called 
    /// but no <see cref="BasicxLogger.Base.ILogger"/> was added befor  
    /// </summary>
    public class NoLoggerAddedException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BasicxLogger.Exceptions.NoLoggerAddedException"/> class
        /// </summary>
        public NoLoggerAddedException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BasicxLogger.Exceptions.NoLoggerAddedException"/> class
        /// </summary>
        public NoLoggerAddedException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BasicxLogger.Exceptions.NoLoggerAddedException"/> class
        /// </summary>
        public NoLoggerAddedException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
