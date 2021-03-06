using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using BasicxLogger;
using BasicxLogger.Models;
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
            _logger.UseId = false;
            _logger.Log("Test Message 1");

            _logger.Log(LogTag.TEST, "Test Message 2");

            _logger.UseId = true;
            string TestId1 = _logger.Log("Test Message 3");
            _testIDList.Add(TestId1);

            string TestId2 = _logger.Log(LogTag.TEST, "Test Message 4");
            _testIDList.Add(TestId2);
            //----------------------------------------------------------------

            //-Async Log Test-------------------------------------------------
            _logger.UseId = false;
            Task test1 = _logger.LogAsync("Test Message 1");
            test1.Wait();

            Task test2 = _logger.LogAsync(LogTag.TEST, "Test Message 2");
            test2.Wait();

            _logger.UseId = true;
            Task<string> test3 = _logger.LogAsync("Test Message 3");
            test3.Wait();
            _testIDList.Add(test3.Result);

            Task<string> test4 = _logger.LogAsync(LogTag.TEST, "Test Message 4");
            test4.Wait();
            _testIDList.Add(test4.Result);
            //----------------------------------------------------------------
        }
    
        private void DeleteOldLogFile()
        {
            if (File.Exists(_logger.LogFile.FullName))
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
                testFile[3].Contains(_testIDList[1]))
                && //Async
                (testFile[4].Contains("Test Message 1")) &&
                (testFile[5].Contains("Test Message 2") && testFile[5].Contains("[TEST]")) &&
                (testFile[6].Contains("Test Message 3") && testFile[6].Contains(_testIDList[2])) &&
                (testFile[7].Contains("Test Message 4") && testFile[7].Contains("[TEST]") &&
                testFile[7].Contains(_testIDList[3]))
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
            JsonLogModel<LogMessageModel> testLog = JsonSerializer.Deserialize<JsonLogModel<LogMessageModel>>(
                                                                File.ReadAllText(_logger.LogFile.FullName));

            //Check if every test log is at the position we expect it to be
            if (//Default
                (testLog.Entrys[0].Message.Contains("Test Message 1")) &&
                (testLog.Entrys[1].Message.Contains("Test Message 2") && testLog.Entrys[1].Tag.Contains("TEST")) &&
                (testLog.Entrys[2].Message.Contains("Test Message 3") && testLog.Entrys[2].Id.Contains(_testIDList[0])) &&
                (testLog.Entrys[3].Message.Contains("Test Message 4") && testLog.Entrys[3].Tag.Contains("TEST") &&
                testLog.Entrys[3].Id.Contains(_testIDList[1]))
                && //Async
                (testLog.Entrys[4].Message.Contains("Test Message 1")) &&
                (testLog.Entrys[5].Message.Contains("Test Message 2") && testLog.Entrys[5].Tag.Contains("TEST")) &&
                (testLog.Entrys[6].Message.Contains("Test Message 3") && testLog.Entrys[6].Id.Contains(_testIDList[2])) &&
                (testLog.Entrys[7].Message.Contains("Test Message 4") && testLog.Entrys[7].Tag.Contains("TEST") &&
                testLog.Entrys[7].Id.Contains(_testIDList[3]))
                )
            {
                return true;
            }

            return false;
        }
    }
}
