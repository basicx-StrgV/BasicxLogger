//--------------------------------------------------//
// Created by basicx-StrgV                          //
// https://github.com/basicx-StrgV/BasicxLogger     //
//--------------------------------------------------//
using System;

namespace BasicxLogger
{
    class NoLoggerAddedException : Exception
    {
        public NoLoggerAddedException()
        {
        }

        public NoLoggerAddedException(string message) : base(message)
        {
        }

        public NoLoggerAddedException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
