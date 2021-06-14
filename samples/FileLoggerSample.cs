//--------------------------------------------------//
// Sample Code for BasixcLogger by basicx-StrgV     //
// https://github.com/basicx-StrgV/BasicxLogger     //
//--------------------------------------------------//
using BasicxLogger;
using BasicxLogger.Files;

namespace Sample
{
    class FileLoggerSample
    {
        public void FileLoggerWithTxtFile()
        {
            //Create a txt log file object
            TxtLogFile logFile = new TxtLogFile("C:\\yourFilePath\\Logs", "SampleLogFile");
            //File classes are containt in the namespace: "BasicxLogger.Files"

            //Create the logger object and add your file
            FileLogger logger = new FileLogger(logFile);

            //Use the Log method to write your message to the log file
            logger.Log("Sample Message");
            /* 
             * File: C:\yourFilePath\Logs\SampleLogFile.txt
             * Output: "[2021/06/14 17:31:57] [ID:13463B6256456030C9] Sample Message"
             */

            //You can also add a Tag to your message
            logger.Log(LogTag.INFO, "Sample Message");
            /* 
             * File: C:\yourFilePath\Logs\SampleLogFile.txt
             * Output: "[2021/06/14 17:35:54] [INFO] [ID:13463B6257D23D0E90] Sample Message"
             */
        }

        public void FileLoggerWithJsonFile()
        {
            //Create a json log file object
            JsonLogFile logFile = new JsonLogFile("C:\\yourFilePath\\Logs", "SampleLogFile");
            //Create the logger object and add your file
            FileLogger logger = new FileLogger(logFile);

            //Use the Log method to write your message to the log file
            logger.Log(LogTag.DEBUGGING, "Sample Message");
            /* 
             * File: C:\yourFilePath\Logs\SampleLogFile.json
             * Output:
             *  {
             *    "entrys": [
             *       {
             *         "id": "13463B62730C34D2E2",
             *         "timestamp": "2021/06/14 18:05:24",
             *         "tag": "DEBUGGING",
             *         "message": "Sample Message"
             *       }
             *     ]
             *   }
             */
        }

        public void FileLoggerDefaultTagConfiguration()
        {
            TxtLogFile logFile = new TxtLogFile("C:\\yourFilePath\\Logs", "SampleLogFile");

            FileLogger logger = new FileLogger(logFile);
            //You can set a default tag for logging, that will be used when no other Tag is selected.
            logger.DefaultTag = LogTag.INFO;

            //Now all log messages will use the default tag that you selected.
            logger.Log("Sample Message");
            /* 
             * File: C:\yourFilePath\Logs\SampleLogFile.txt
             * Output: "[2021/06/14 17:43:49] [INFO] [ID:13463B625AED19660F] Sample Message"
             */

            //If you add a Tag to the log method it will use that Tag instead.
            logger.Log(LogTag.ALERT, "Sample Message");
            /* 
             * File: C:\yourFilePath\Logs\SampleLogFile.txt
             * Output: "[2021/06/14 17:43:49] [ALERT] [ID:13463B625AED1B2859] Sample Message"
             */
        }

        public void FileLoggerUseIdConfiguration()
        {
            TxtLogFile logFile = new TxtLogFile("C:\\yourFilePath\\Logs", "SampleLogFile");

            FileLogger logger = new FileLogger(logFile);
            //You can deactivate the ID the logger adds to each message by changing the value of UseId to false.
            logger.UseId = false;

            //Now your messages will not contain an ID
            logger.Log("Sample Message");
            /* 
             * File: C:\yourFilePath\Logs\SampleLogFile.txt
             * Output: "[2021/06/14 17:50:02] Sample Message"
             */
        }

        public void FileLoggerTimestampConfiguration()
        {
            TxtLogFile logFile = new TxtLogFile("C:\\yourFilePath\\Logs", "SampleLogFile");

            FileLogger logger = new FileLogger(logFile);
            //You can change the timestamp that is used by the logger.
            //This is usefull, if you want to use a 12h clock instead of a 24h clock
            logger.MessageTimestamp = Timestamp.Year_Month_Day_Hour12_Min_Sec;

            //If you use a 12h clock the timestamp will automaticly contain AM or PM.
            logger.Log("Sample Message");
            /* 
             * File: C:\yourFilePath\Logs\SampleLogFile.txt
             * Output: "[2021/06/14 05:55:07 PM] [ID:13463B625F731335E2] Sample Message"
             */

            //You can also change the date separator that the timestamp has betwen the year, month and day
            logger.MessageTimestamp.DateSeparator = "-";

            logger.Log("Sample Message");
            /* 
             * File: C:\yourFilePath\Logs\SampleLogFile.txt
             * Output: "[2021-06-14 05:58:42 PM] [ID:13463B6260C22C7B2] Sample Message"
             */
        }
    }
}
