using System;
using System.Collections.Generic;
using System.Text;
using BasicxLogger;
using BasicxLogger.Message;
using BasicxLogger.LoggerFile;
using BasicxLogger.LoggerDatabase;
using BasicxLogger.LoggerDirectory;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace LoggerTest
{
    public class FileLoggerTester
    {
        FileLogger logger;

        List<string> testIDList = new List<string>();

        public FileLoggerTester(FileLogger fileLogger)
        {
            logger = fileLogger;
        }

        public bool test()
        {
            try
            {
                deleteOldLogFile();

                writeTestLogs();

                if (File.Exists(logger.getFullFilePath()))
                {
                    switch (logger.logFile.type)
                    {
                        case LogFileType.xml:


                            break;
                        case LogFileType.json:
                            //Read and deseralize the json file
                            List<LogMessageModel> testLog = JsonSerializer.Deserialize<List<LogMessageModel>>(
                                                                                File.ReadAllText(logger.getFullFilePath()));

                            //Check if every test log is at the position we expect it to be
                            if (//Default
                                (testLog[0].message.Contains("Test Message 1")) &&
                                (testLog[1].message.Contains("Test Message 2") && testLog[1].tag.Contains("TEST")) &&
                                (testLog[2].message.Contains("Test Message 3") && testLog[2].id.Contains(testIDList[0])) &&
                                (testLog[3].message.Contains("Test Message 4") && testLog[3].tag.Contains("TEST") && 
                                testLog[3].id.Contains(testIDList[1])) &&
                                (testLog[4].message.Contains("Test Message 5") && testLog[4].id.Contains("TestID1")) &&
                                (testLog[5].message.Contains("Test Message 6") && testLog[5].tag.Contains("TEST") && 
                                testLog[5].id.Contains("TestID2"))
                                && //Async
                                (testLog[6].message.Contains("Test Message 1")) &&
                                (testLog[7].message.Contains("Test Message 2") && testLog[7].tag.Contains("TEST")) &&
                                (testLog[8].message.Contains("Test Message 3") && testLog[8].id.Contains(testIDList[2])) &&
                                (testLog[9].message.Contains("Test Message 4") && testLog[9].tag.Contains("TEST") &&
                                testLog[9].id.Contains(testIDList[3])) &&
                                (testLog[10].message.Contains("Test Message 5") && testLog[10].id.Contains("TestID1")) &&
                                (testLog[11].message.Contains("Test Message 6") && testLog[11].tag.Contains("TEST") &&
                                testLog[11].id.Contains("TestID2"))
                                )
                            {
                                return true;
                            }

                            return false;

                        default:
                            //Read the text/log file
                            List<string> testFile = File.ReadAllLines(logger.getFullFilePath()).ToList();

                            //Check if every test log is at the position we expect it to be
                            if (//Default
                                (testFile[0].Contains("Test Message 1")) &&
                                (testFile[1].Contains("Test Message 2") && testFile[1].Contains("[TEST]")) &&
                                (testFile[2].Contains("Test Message 3") && testFile[2].Contains(testIDList[0])) &&
                                (testFile[3].Contains("Test Message 4") && testFile[3].Contains("[TEST]") && 
                                testFile[3].Contains(testIDList[1])) &&
                                (testFile[4].Contains("Test Message 5") && testFile[4].Contains("[ID:TestID1]")) &&
                                (testFile[5].Contains("Test Message 6") && testFile[5].Contains("[TEST]") && 
                                testFile[5].Contains("[ID:TestID2]"))
                                && //Async
                                (testFile[6].Contains("Test Message 1")) &&
                                (testFile[7].Contains("Test Message 2") && testFile[7].Contains("[TEST]")) &&
                                (testFile[8].Contains("Test Message 3") && testFile[8].Contains(testIDList[2])) &&
                                (testFile[9].Contains("Test Message 4") && testFile[9].Contains("[TEST]") &&
                                testFile[9].Contains(testIDList[3])) &&
                                (testFile[10].Contains("Test Message 5") && testFile[10].Contains("[ID:TestID1]")) &&
                                (testFile[11].Contains("Test Message 6") && testFile[11].Contains("[TEST]") &&
                                testFile[11].Contains("[ID:TestID2]"))
                                )
                            {
                                return true;
                            }
                            
                            return false;
                    }
                }

                return false;
            }
            catch(Exception)
            {
                return false;
            }
        }

        private void writeTestLogs()
        {
            //-Default Log Test-----------------------------------------------
            logger.log("Test Message 1");

            logger.log(Tag.TEST, "Test Message 2");

            string TestId1 = logger.logID("Test Message 3");
            testIDList.Add(TestId1);

            string TestId2 = logger.logID(Tag.TEST, "Test Message 4");
            testIDList.Add(TestId2);

            logger.logCustomID("TestID1", "Test Message 5");

            logger.logCustomID("TestID2", Tag.TEST, "Test Message 6");
            //----------------------------------------------------------------

            //-Async Log Test-------------------------------------------------
            Task test1 = logger.logAsync("Test Message 1");
            test1.Wait();

            Task test2 = logger.logAsync(Tag.TEST, "Test Message 2");
            test2.Wait();

            Task<string> test3 = logger.logIDAsync("Test Message 3");
            test3.Wait();
            testIDList.Add(test3.Result);

            Task<string> test4 = logger.logIDAsync(Tag.TEST, "Test Message 4");
            test4.Wait();
            testIDList.Add(test4.Result);

            Task test5 = logger.logCustomIDAsync("TestID1", "Test Message 5");
            test5.Wait();

            Task test6 = logger.logCustomIDAsync("TestID2", Tag.TEST, "Test Message 6");
            test6.Wait();
            //----------------------------------------------------------------
        }
    
        private void deleteOldLogFile()
        {
            if (File.Exists(logger.getFullFilePath()))
            {
                File.Delete(logger.getFullFilePath());
            }
        }
    }
}
