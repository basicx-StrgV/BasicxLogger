using System;
using System.IO;

namespace EasyLogger
{
    public class Logger
    {
        private string path = "";
        private string directoryName = "logs";
        private string fileName = "log";
        private string fileType = "txt";
        private string dateFormate = "yyyy'/'MM'/'dd HH:mm:ss";

        public Logger()
        {
            try
            {
                path = Environment.CurrentDirectory;
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
            }
            catch(DirectoryNotFoundException e)
            {
                Console.WriteLine(e);
            }
            catch(IOException e)
            {
                Console.WriteLine(e);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void write(string massage)
        {
            if(Directory.Exists(path + "/" + directoryName))
            {
                string filePath = path + "/" + directoryName + "/" + fileName + "." + fileType;
                string logMassage = "[" + getCurrentTime() + "] " + massage + "\n";
                try
                {
                    File.AppendAllText(filePath, logMassage);
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine(e);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e);
                }
                catch (PathTooLongException e)
                {
                    Console.WriteLine(e);
                }
                catch (DirectoryNotFoundException e)
                {
                    Console.WriteLine(e);
                }
                catch (IOException e)
                {
                    Console.WriteLine(e);
                }
                catch (UnauthorizedAccessException e)
                {
                    Console.WriteLine(e);
                }
                catch (NotSupportedException e)
                {
                    Console.WriteLine(e);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            else
            {
                createDirectory();
            }
        }

        public void changeDirectoryPath(string directoryPath)
        {
            path = directoryPath;
        }

        public void setCustomFileType(string type)
        {
            fileType = type;
        }

        public void setCustomDateFormate(string formate)
        {
            dateFormate = formate;
        }

        private string getCurrentTime()
        {
            DateTime systemTime = DateTime.Now;
            return systemTime.ToString(dateFormate);
        }

        private void createDirectory()
        {
            string directoryPath = path + "/" + directoryName;
            try
            {
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
            }
            catch (PathTooLongException e)
            {
                Console.WriteLine(e);
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e);
            }
            catch (IOException e)
            {
                Console.WriteLine(e);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

    }
}
