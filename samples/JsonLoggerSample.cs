//--------------------------------------------------//
// Sample Code for BasixcLogger by basicx-StrgV     //
// https://github.com/basicx-StrgV/BasicxLogger     //
//--------------------------------------------------//
using BasicxLogger;
using BasicxLogger.Files;

namespace Sample
{
    class JsonLoggerSample
    {
        public void JsonLoggerLoggingSample()
        {
            //The json logger allows you to log your owne objects to a json file.
            //To use it you need to creat an object of the json logger with the model class it should use
            //and add a json file.
            JsonLogger<SampleJsonModel> jsonLogger = new JsonLogger<SampleJsonModel>(
                new JsonLogFile("C:\\yourFilePath\\Logs", "JsonLoggerSample"));

            //After that you can create an object of or model class and add the data,
            //that it should contain.
            SampleJsonModel logEntry = new SampleJsonModel()
            {
                MyMessageOne = "Sample Message One",
                MyMessageTwo = "Sample Message Two"
            };

            //Now use the Log method to add the object to the json log file
            jsonLogger.Log(logEntry);
            /* 
             * File: C:\yourFilePath\Logs\JsonLoggerSample.json
             * Output: 
             *  {
             *     "entrys": [
             *       {
             *         "MyMessageOne": "Sample Message One",
             *         "MyMessageTwo": "Sample Message Two"
             *       }
             *     ]
             *  }
             * 
             */
        }
    }

    //This is the model class we use for this sample
    class SampleJsonModel
    {
        public string MyMessageOne { get; set; }
        public string MyMessageTwo { get; set; }
    }
}
