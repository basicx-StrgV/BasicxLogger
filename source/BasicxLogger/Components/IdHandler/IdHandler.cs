//--------------------------------------------------//
// Created by basicx-StrgV                          //
// https://github.com/basicx-StrgV/BasicxLogger     //
//--------------------------------------------------//
using System;

namespace BasicxLogger
{
    /// <summary>
    /// A static class used for id generation
    /// </summary>
    public static class IdHandler
    {
        /// <summary>
        /// Gets a unique id string
        /// </summary>
        /// <returns>
        /// A string that conatins a unique id
        /// </returns>
        public static string UniqueId { get { return GenerateUniqueId(); } }

        private static string GenerateUniqueId()
        {
            string idPartOne = int.Parse(DateTime.UtcNow.ToString("yyyyMMdd")).ToString("X");
            string idPartTwo = int.Parse(DateTime.UtcNow.ToString("HHmmss")).ToString("X");
            string idPartThree = int.Parse(DateTime.UtcNow.ToString("fffffff")).ToString("X");
            string uniqueId = idPartOne + idPartTwo + idPartThree;
            return uniqueId;
        }
    }
}
