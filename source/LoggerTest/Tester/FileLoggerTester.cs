using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using BasicxLogger;
using BasicxLogger.Databases;

namespace LoggerTest
{
#pragma warning disable
    public class FileLoggerTester
    {
        private FileLogger _logger;

        private List<string> _testIDList = new List<string>();

        public FileLoggerTester(FileLogger fileLogger)
        {
            _logger = fileLogger;
        }

        public bool Test()
        {
            try
            {
                DeleteOldLogFile();

                WriteTestLogs();

                if (File.Exists(_logger.LogFile.FullName))
                {
                    switch (_logger.LogFile.Extension)
                    {
                        case ".xml":
                            return TestXmlFile();
                        case ".json":
                            return TestJsonFile();
                        default:
                            return TestTextFile();
                    }
                }

                return false;
            }
            catch(Exception)
            {
                return false;
            }
        }

        private void WriteTestLogs()
        {
            //-Default Log Test-----------------------------------------------
            _logger.Log("Test Message 1");

            _logger.Log(LogTag.TEST, "Test Message 2");

            string TestId1 = _logger.LogId("Test Message 3");
            _testIDList.Add(TestId1);

            string TestId2 = _logger.LogId(LogTag.TEST, "Test Message 4");
            _testIDList.Add(TestId2);

            _logger.LogCustomId("TestID1", "Test Message 5");

            _logger.LogCustomId("TestID2", LogTag.TEST, "Test Message 6");
            //----------------------------------------------------------------

            //-Async Log Test-------------------------------------------------
            Task test1 = _logger.LogAsync("Test Message 1");
            test1.Wait();

            Task test2 = _logger.LogAsync(LogTag.TEST, "Test Message 2");
            test2.Wait();

            Task<string> test3 = _logger.LogIdAsync("Test Message 3");
            test3.Wait();
            _testIDList.Add(test3.Result);

            Task<string> test4 = _logger.LogIdAsync(LogTag.TEST, "Test Message 4");
            test4.Wait();
            _testIDList.Add(test4.Result);

            Task test5 = _logger.LogCustomIdAsync("TestID1", "Test Message 5");
            test5.Wait();

            Task test6 = _logger.LogCustomIdAsync("TestID2", LogTag.TEST, "Test Message 6");
            test6.Wait();
            //----------------------------------------------------------------
        }
    
        private void DeleteOldLogFile()
        {
            if (_logger.LogFile.Exists)
            {
                File.Delete(_logger.LogFile.FullName);
            }
        }
    
        private bool TestTextFile()
        {
            //Read the text/log file
            List<string> testFile = File.ReadAllLines(_logger.LogFile.FullName).ToList();

            //Check if every test log is at the position we expect it to be
            if (//Default
                (testFile[0].Contains("Test Message 1")) &&
                (testFile[1].Contains("Test Message 2") && testFile[1].Contains("[TEST]")) &&
                (testFile[2].Contains("Test Message 3") && testFile[2].Contains(_testIDList[0])) &&
                (testFile[3].Contains("Test Message 4") && testFile[3].Contains("[TEST]") &&
                testFile[3].Contains(_testIDList[1])) &&
                (testFile[4].Contains("Test Message 5") && testFile[4].Contains("[ID:TestID1]")) &&
                (testFile[5].Contains("Test Message 6") && testFile[5].Contains("[TEST]") &&
                testFile[5].Contains("[ID:TestID2]"))
                && //Async
                (testFile[6].Contains("Test Message 1")) &&
                (testFile[7].Contains("Test Message 2") && testFile[7].Contains("[TEST]")) &&
                (testFile[8].Contains("Test Message 3") && testFile[8].Contains(_testIDList[2])) &&
                (testFile[9].Contains("Test Message 4") && testFile[9].Contains("[TEST]") &&
                testFile[9].Contains(_testIDList[3])) &&
                (testFile[10].Contains("Test Message 5") && testFile[10].Contains("[ID:TestID1]")) &&
                (testFile[11].Contains("Test Message 6") && testFile[11].Contains("[TEST]") &&
                testFile[11].Contains("[ID:TestID2]"))
                )
            {
                return true;
            }

            return false;
        }
    
        private bool TestXmlFile()
        {
            return false;
        }

        private bool TestJsonFile()
        {
            //Read and deseralize the json file
            JsonLogModel testLog = JsonSerializer.Deserialize<JsonLogModel>(
                                                                File.ReadAllText(_logger.LogFile.FullName));

            //Check if every test log is at the position we expect it to be
            if (//Default
                (testLog.entrys[0].message.Contains("Test Message 1")) &&
                (testLog.entrys[1].message.Contains("Test Message 2") && testLog.entrys[1].tag.Contains("TEST")) &&
                (testLog.entrys[2].message.Contains("Test Message 3") && testLog.entrys[2].id.Contains(_testIDList[0])) &&
                (testLog.entrys[3].message.Contains("Test Message 4") && testLog.entrys[3].tag.Contains("TEST") &&
                testLog.entrys[3].id.Contains(_testIDList[1])) &&
                (testLog.entrys[4].message.Contains("Test Message 5") && testLog.entrys[4].id.Contains("TestID1")) &&
                (testLog.entrys[5].message.Contains("Test Message 6") && testLog.entrys[5].tag.Contains("TEST") &&
                testLog.entrys[5].id.Contains("TestID2"))
                && //Async
                (testLog.entrys[6].message.Contains("Test Message 1")) &&
                (testLog.entrys[7].message.Contains("Test Message 2") && testLog.entrys[7].tag.Contains("TEST")) &&
                (testLog.entrys[8].message.Contains("Test Message 3") && testLog.entrys[8].id.Contains(_testIDList[2])) &&
                (testLog.entrys[9].message.Contains("Test Message 4") && testLog.entrys[9].tag.Contains("TEST") &&
                testLog.entrys[9].id.Contains(_testIDList[3])) &&
                (testLog.entrys[10].message.Contains("Test Message 5") && testLog.entrys[10].id.Contains("TestID1")) &&
                (testLog.entrys[11].message.Contains("Test Message 6") && testLog.entrys[11].tag.Contains("TEST") &&
                testLog.entrys[11].id.Contains("TestID2"))
                )
            {
                return true;
            }

            return false;
        }
    }
}
