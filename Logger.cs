using System;
using System.IO;

namespace EasyLogger
{
    public class Logger
    {
        private String path = "";
        private String directoryName = "logs";
        private String fileName = "log";
        private String fileType = "txt";
        private String dateFormate = "yyyy'/'MM'/'dd HH:mm:ss";

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

            createDirectory();
        }

        public void write(String massage)
        {
            String filePath = path + "/" + directoryName + "/" + fileName + "." + fileType;
            String logMassage = "[" + getCurrentTime() + "] " + massage + "\n";
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

        public void setDirectoryPath(String directoryPath)
        {
            path = directoryPath;
            createDirectory();
        }

        public void setCustomFileType(String type)
        {
            fileType = type;
        }

        public void setCustomDateFormate(String formate)
        {
            dateFormate = formate;
        }

        private String getCurrentTime()
        {
            DateTime systemTime = DateTime.Now;
            return systemTime.ToString(dateFormate);
        }

        private void createDirectory()
        {
            String directoryPath = path + "/" + directoryName;
            try
            {
                if (Directory.Exists(directoryPath) == false)
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
