//--------------------------------------------------//
// Sample Code for BasixcLogger by basicx-StrgV     //
// https://github.com/basicx-StrgV/BasicxLogger     //
//--------------------------------------------------//
using BasicxLogger;
using BasicxLogger.Files;
using BasicxLogger.Databases;

namespace Sample
{
    class MultiLoggerSample
    {
        public void UsingMultiLoggerSample()
        {
            //The multi logger allows you to log with multiple loggers at ones.
            //All logger classes that implement the ILogger interface are supported.
            MultiLogger multiLogger = new MultiLogger();

            //Use the Add method to add a logger to the multi logger.
            multiLogger.Add(new FileLogger(new TxtLogFile("C:\\yourFilePath\\Logs", "LoggerSample")));
            multiLogger.Add(new DatabaseLogger(new MySqlDatabase("localhost", "sampleDB", "sampleTable", "user", "pw")));
            multiLogger.Add(new FileLogger(new JsonLogFile("C:\\yourFilePath\\Logs", "LoggerSample")));

            //Using the Log method will log the given message with all loggers that you added to the multi logger.
            multiLogger.Log("Sample message");

            //You can also loop through every logger that was added to the multi logger
            foreach (ILogger i in multiLogger)
            {
                i.DefaultTag = LogTag.INFO;
            }

            //Or select a logger by its index.
            multiLogger[1].UseId = false;
        }
    }
}
