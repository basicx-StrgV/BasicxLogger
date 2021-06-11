//--------------------------------------------------//
// Created by basicx-StrgV                          //
// https://github.com/basicx-StrgV/BasicxLogger     //
//--------------------------------------------------//
using System;
using System.IO;
using System.Xml;
using System.Text;

namespace BasicxLogger
{
    /// <summary>
    /// Class that represents a log file with the file extension .xml
    /// </summary>
    public class XmlLogFile : ILogFile
    {
        /// <summary>
        /// Gets or Sets the text encoding for the file
        /// </summary>
        public Encoding TextEncoding { get; set; } = Encoding.UTF8;

        /// <summary>
        /// Gets a string representing the directory's full path
        /// </summary>
        public string DirectoryName { get { return _file.DirectoryName; } }

        /// <summary>
        /// Gets the full path of the file
        /// </summary>
        public string FullName { get { return _file.FullName; } }

        /// <summary>
        /// Gets the string representing the extension part of the file
        /// </summary>
        public string Extension { get { return _file.Extension; } }


        private readonly FileInfo _file;


        /// <summary>
        /// Initializes a new instance of the <see cref="BasicxLogger.XmlLogFile"/> class
        /// </summary>
        public XmlLogFile(string directoryPath, string fileName)
        {
            if (!(directoryPath.EndsWith("\\") || directoryPath.EndsWith("/")))
            {
                directoryPath += '/';
            }

            _file = new FileInfo(directoryPath + fileName.Split('.')[0].Trim() + ".xml");
        }

        /// <summary>
        /// Writes a log message with the given data to the log file
        /// </summary>
        /// <param name="messageTag">The message tag for the log message</param>
        /// <param name="timestamp">The timestamp for the log message</param>
        /// <param name="message">The message that should be logged</param>
        /// <param name="id">The id for the log message</param>
        public void WriteToFile(LogTag messageTag, string timestamp, string message, string id = "")
        {
            try
            {
                if (!Directory.Exists(_file.DirectoryName))
                {
                    Directory.CreateDirectory(_file.DirectoryName);
                }

                if (!File.Exists(_file.FullName))
                {
                    CreateXmlFile();
                }

                //Load the xml file
                XmlDocument xmlFile = new XmlDocument();
                xmlFile.Load(_file.FullName);

                //Get the root node from the file
                XmlNode rootNode = xmlFile.SelectSingleNode("entrys");

                //Create nodes and add data
                XmlNode logMessageNode = xmlFile.CreateElement("LogMessage");
                XmlAttribute idAttribute = xmlFile.CreateAttribute("id");
                if (!id.Equals(""))
                {
                    idAttribute.Value = id;
                }
                logMessageNode.Attributes.Append(idAttribute);

                XmlNode timestampNode = xmlFile.CreateElement("timestamp");
                timestampNode.InnerText = timestamp;
                logMessageNode.AppendChild(timestampNode);

                XmlNode tagNode = xmlFile.CreateElement("tag");
                if (!messageTag.Equals(LogTag.none))
                {
                    tagNode.InnerText = messageTag.ToString();
                }
                logMessageNode.AppendChild(tagNode);

                XmlNode messageNode = xmlFile.CreateElement("message");
                messageNode.InnerText = message;
                logMessageNode.AppendChild(messageNode);

                //Appand to root node
                rootNode.AppendChild(logMessageNode);

                //Save the xml file
                xmlFile.Save(_file.FullName);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void CreateXmlFile()
        {
            try
            {
                if (!File.Exists(_file.FullName))
                {
                    XmlWriterSettings xmlWriterSettings = new XmlWriterSettings
                    {
                        Encoding = TextEncoding
                    };

                    XmlWriter xmlWriter = XmlWriter.Create(_file.FullName, xmlWriterSettings);

                    xmlWriter.WriteStartDocument();
                    xmlWriter.WriteStartElement("entrys");
                    xmlWriter.WriteEndElement();
                    xmlWriter.Close();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
