using System;
using BasicxLogger;
using BasicxLogger.Message;
using BasicxLogger.LoggerFile;
using BasicxLogger.LoggerDatabase;
using BasicxLogger.LoggerDirectory;
using System.IO;

namespace LoggerTest
{
    class Program
    {
        //-Logger-------------------------------------------------------------

        //File Logger TXT file
        FileLogger txtFileLogger;
        //File Logger LOG file
        FileLogger logFileLogger;
        //File Logger xml file
        FileLogger xmlFileLogger;
        //File Logger JSON file
        FileLogger jsonFileLogger;

        //Json Logger
        JsonLogger<JsonLoggerTestModel> jsonLogger;

        //MySql Logger
        MySqlLogger mySqlLogger;

        //Multi Logger
        MultiLogger multiLogger;

        //--------------------------------------------------------------------

        static void Main(string[] args)
        {
            new Program();
        }
        Program()
        {
            run();
        }

        private void run()
        {
            if (Directory.Exists(DirConfig.TestOutputDir))
            {
                Directory.CreateDirectory(DirConfig.TestOutputDir);
            }

            defaultTest();

            Console.WriteLine("\n--------------------------------------------\n");

            customTest();
        }

        private void customTest()
        {
            //---Test-code-for-any-sorts-of-tests-goes-here---

        }

        private void defaultTest()
        {
            initalizeLogger();

            multiLoggerSetup();

            //-Test all logger ----------------------------------------------

            Console.Write("\nFileLogger(.txt): ");
            outputTestStatus(new FileLoggerTester(txtFileLogger).test());

            Console.Write("\nFileLogger(.log): ");
            outputTestStatus(new FileLoggerTester(logFileLogger).test());

            Console.Write("\nFileLogger(.json): ");
            outputTestStatus(new FileLoggerTester(jsonFileLogger).test());

            //---------------------------------------------------------------
        }

        private void initalizeLogger()
        {
            //File Logger TXT file
            txtFileLogger = new FileLogger(
                                new LogDirectory(DirConfig.TestOutputDir, "FileLoggerTestOutput"),
                                new LogFile("FileLoggerTest", LogFileType.txt),
                                new MessageFormat(
                                    new Date(DateFormat.year_month_day, '/'),
                                    new Time(TimeFormat.hour24_min_sec)));
            //File Logger LOG file
            logFileLogger = new FileLogger(
                                new LogDirectory(DirConfig.TestOutputDir, "FileLoggerTestOutput"),
                                new LogFile("FileLoggerTest", LogFileType.log),
                                new MessageFormat(
                                    new Date(DateFormat.year_month_day, '/'),
                                    new Time(TimeFormat.hour24_min_sec)));
            //File Logger xml file
            xmlFileLogger = new FileLogger(
                                new LogDirectory(DirConfig.TestOutputDir, "FileLoggerTestOutput"),
                                new LogFile("FileLoggerTest", LogFileType.xml),
                                new MessageFormat(
                                    new Date(DateFormat.year_month_day, '/'),
                                    new Time(TimeFormat.hour24_min_sec)));
            //File Logger JSON file
            jsonFileLogger = new FileLogger(
                                new LogDirectory(DirConfig.TestOutputDir, "FileLoggerTestOutput"),
                                new LogFile("FileLoggerTest", LogFileType.json),
                                new MessageFormat(
                                    new Date(DateFormat.year_month_day, '/'),
                                    new Time(TimeFormat.hour24_min_sec)));

            //Json Logger
            jsonLogger = new JsonLogger<JsonLoggerTestModel>(
                            new LogDirectory(DirConfig.TestOutputDir, "JsonLoggerTestOutput"),
                            "JsonLoggerTest");

            //MySql Logger
            try
            {
                mySqlLogger = new MySqlLogger(new MySqlDatabase("localhost", "test", "root", "admin"), "logTest");
            }
            catch (Exception)
            {
                multiLogger = null;
            }

            //Multi Logger
            multiLogger = new MultiLogger();
        }
    
        private void multiLoggerSetup()
        {
            multiLogger.addLogger(txtFileLogger);
            multiLogger.addLogger(logFileLogger);
            multiLogger.addLogger(xmlFileLogger);
            multiLogger.addLogger(jsonFileLogger);
        }
    
        private void outputTestStatus(bool testSuccess)
        {
            if (testSuccess)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("PASS\n");
                Console.ResetColor();
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("FAIL\n");
                Console.ResetColor();
            }
        }
    }
}
