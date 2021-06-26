/****************************************************************************
 *       ____            _           _                                      *
 *      |  _ \          (_)         | |                                     *
 *      | |_) | __ _ ___ _  _____  _| |     ___   __ _  __ _  ___ _ __      *
 *      |  _ < / _` / __| |/ __\ \/ / |    / _ \ / _` |/ _` |/ _ \ '__|     *
 *      | |_) | (_| \__ \ | (__ >  <| |___| (_) | (_| | (_| |  __/ |        *
 *      |____/ \__,_|___/_|\___/_/\_\______\___/ \__, |\__, |\___|_|        *
 *                                                __/ | __/ |               *
 *                                               |___/ |___/                *
 *  by basicx-StrgV                                                         *
 *  https://github.com/basicx-StrgV/BasicxLogger                            *
 *                                                                          *
 * **************************************************************************/
using System;
using System.Collections;
using System.Threading.Tasks;
using System.Collections.Generic;
using BasicxLogger.Base;
using BasicxLogger.Exceptions;

namespace BasicxLogger
{
    /// <summary>
    /// A logger that allows you to add all loggers that use the ILogger interface and 
    /// log with all of them by only using one log method call.
    /// </summary>
    /// <remarks>
    /// The multi logger supports all logger that uses the ILogger intaterface.
    /// </remarks>
    public class MultiLogger : IList<ILogger>
    {
        /// <summary>
        /// Gets a value indicating whether the <see cref="BasicxLogger.MultiLogger"/> is read-only.
        /// </summary>
        /// <returns>
        /// true if the <see cref="BasicxLogger.MultiLogger"/> is read-only; otherwise, false.
        /// </returns>
        public bool IsReadOnly { get; } = false;
        /// <summary>
        /// Gets the number of elements contained in the <see cref="BasicxLogger.MultiLogger"/>.
        /// </summary>
        /// <returns>
        /// The number of elements contained in the <see cref="BasicxLogger.MultiLogger"/>.
        /// </returns>
        public int Count { get { return _loggerList.Count; } }
        /// <summary>
        /// Gets or sets the element at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the element to get or set.</param>
        /// <returns>
        /// The element at the specified index.
        /// </returns>
        ILogger IList<ILogger>.this[int index] { get { return _loggerList[index]; } set { _loggerList[index] = value; } }
        /// <summary>
        /// Gets or sets the element at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the element to get or set.</param>
        /// <returns>
        /// The element at the specified index.
        /// </returns>
        public ILogger this[int index] { get { return _loggerList[index]; } set { _loggerList[index] = value; } }


        private List<ILogger> _loggerList = new List<ILogger>();


        /// <summary>
        /// Initializes a new instance of the <see cref="BasicxLogger.MultiLogger"/> class
        /// </summary>
        public MultiLogger()
        {
        }


        /// <summary>
        /// Logs the given message with every <see cref="BasicxLogger.Base.ILogger"/> 
        /// that was added to the <see cref="BasicxLogger.MultiLogger"/>.
        /// </summary>
        /// <param name="message">The message that will be logged</param>
        /// <returns>
        /// A string array conataining all message id's that each logger returned.
        /// </returns>
        /// <exception cref="BasicxLogger.Exceptions.NoLoggerAddedException">
        /// The <see cref="BasicxLogger.MultiLogger"/> does not contain any <see cref="BasicxLogger.Base.ILogger"/>.
        /// </exception>
        public string[] Log(string message)
        {
            if (_loggerList.Count <= 0)
            {
                throw new NoLoggerAddedException("MultiLogger does not contain any ILogger to log with.");
            }

            try
            {
                List<string> idList = new List<string>();
                foreach (ILogger logger in _loggerList)
                {
                    string id = logger.Log(message);
                    if (id != null)
                    {
                        idList.Add(id);
                    }
                }

                if(idList.Count > 0)
                {
                    return idList.ToArray();
                }
                else
                {
                    return new string[1];
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// Logs the given message with every <see cref="BasicxLogger.Base.ILogger"/> 
        /// that was added to the <see cref="BasicxLogger.MultiLogger"/>.
        /// </summary>
        /// <param name="message">The message that will be logged</param>
        /// <param name="messageTag">
        /// A Tag that will be added to the message, to make it easy to distinguish between differen log messages
        /// </param>
        /// <returns>
        /// A string array conataining all message id's that each logger returned.
        /// </returns>
        /// <exception cref="BasicxLogger.Exceptions.NoLoggerAddedException">
        /// The <see cref="BasicxLogger.MultiLogger"/> does not contain any <see cref="BasicxLogger.Base.ILogger"/>.
        /// </exception>
        public string[] Log(LogTag messageTag, string message)
        {
            if (_loggerList.Count <= 0)
            {
                throw new NoLoggerAddedException("MultiLogger does not contain any ILogger to log with.");
            }

            try 
            {
                List<string> idList = new List<string>();
                foreach (ILogger logger in _loggerList)
                {
                    string id = logger.Log(messageTag, message);
                    if (id != null)
                    {
                        idList.Add(id);
                    }
                }

                if (idList.Count > 0)
                {
                    return idList.ToArray();
                }
                else
                {
                    return new string[1];
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// Asynchronous logs the given message with every <see cref="BasicxLogger.Base.ILogger"/> 
        /// that was added to the <see cref="BasicxLogger.MultiLogger"/>.
        /// </summary>
        /// <param name="message">The message that will be logged</param>
        /// <returns>
        /// A string array conataining all message id's that each logger returned.
        /// </returns>
        /// <exception cref="BasicxLogger.Exceptions.NoLoggerAddedException">
        /// The <see cref="BasicxLogger.MultiLogger"/> does not contain any <see cref="BasicxLogger.Base.ILogger"/>.
        /// </exception>
        public async Task<string[]> LogAsync(string message)
        {
            try
            {
                Task<string[]> logTask = Task.Run(() => Log(message));
                await logTask;
                return logTask.Result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// Asynchronous logs the given message with every <see cref="BasicxLogger.Base.ILogger"/> 
        /// that was added to the <see cref="BasicxLogger.MultiLogger"/>.
        /// </summary>
        /// <param name="message">The message that will be logged</param>
        /// <param name="messageTag">
        /// A Tag that will be added to the message, to make it easy to distinguish between differen log messages
        /// </param>
        /// <returns>
        /// A string array conataining all message id's that each logger returned.
        /// </returns>
        /// <exception cref="BasicxLogger.Exceptions.NoLoggerAddedException">
        /// The <see cref="BasicxLogger.MultiLogger"/> does not contain any <see cref="BasicxLogger.Base.ILogger"/>.
        /// </exception>
        public async Task<string[]> LogAsync(LogTag messageTag, string message)
        {
            try
            {
                Task<string[]> logTask = Task.Run(() => Log(messageTag,  message));
                await logTask;
                return logTask.Result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        /// <summary>
        /// Determines the index of a specific item in the <see cref="BasicxLogger.MultiLogger"/>.
        /// </summary>
        /// <param name="item">The object to locate in the <see cref="BasicxLogger.MultiLogger"/>.</param>
        /// <returns>
        /// The index of item if found in the list; otherwise, -1.
        /// </returns>
        public int IndexOf(ILogger item)
        {
            return _loggerList.IndexOf(item);
        }
        /// <summary>
        /// Inserts an item to the <see cref="BasicxLogger.MultiLogger"/> at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="item">The object to insert into the <see cref="BasicxLogger.MultiLogger"/>.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">index is not a valid index in the <see cref="BasicxLogger.MultiLogger"/>.</exception>
        /// <exception cref="System.NotSupportedException">The <see cref="BasicxLogger.MultiLogger"/> is read-only.</exception>
        public void Insert(int index, ILogger item)
        {
            try
            {
                _loggerList.Insert(index, item);
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new ArgumentOutOfRangeException(String.Format("{0} is not a valid index in the MultiLogger", index));
            }
            catch (NotSupportedException)
            {
                throw new NotSupportedException("MultiLogger is read-only");
            }
        }
        /// <summary>
        /// Removes the <see cref="BasicxLogger.MultiLogger"/> item at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the item to remove.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">index is not a valid index in the <see cref="BasicxLogger.MultiLogger"/>.</exception>
        /// <exception cref="System.NotSupportedException">The <see cref="BasicxLogger.MultiLogger"/> is read-only.</exception>
        public void RemoveAt(int index)
        {
            try
            {
                _loggerList.RemoveAt(index);
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new ArgumentOutOfRangeException(String.Format("{0} is not a valid index in the MultiLogger", index));
            }
            catch (NotSupportedException)
            {
                throw new NotSupportedException("MultiLogger is read-only");
            }
        }
        /// <summary>
        /// Adds an item to the <see cref="BasicxLogger.MultiLogger"/>.
        /// </summary>
        /// <param name="item">The object to add to the <see cref="BasicxLogger.MultiLogger"/>.</param>
        /// <exception cref="System.NotSupportedException">The <see cref="BasicxLogger.MultiLogger"/> is read-only.</exception>
        public void Add(ILogger item)
        {
            try
            {
                _loggerList.Add(item);
            }
            catch (NotSupportedException)
            {
                throw new NotSupportedException("MultiLogger is read-only");
            }
        }
        /// <summary>
        /// Removes all items from the <see cref="BasicxLogger.MultiLogger"/>.
        /// </summary>
        /// <exception cref="System.NotSupportedException">The <see cref="BasicxLogger.MultiLogger"/> is read-only.</exception>
        public void Clear()
        {
            try
            {
                _loggerList.Clear();
            }
            catch (NotSupportedException)
            {
                throw new NotSupportedException("MultiLogger is read-only");
            }
        }
        /// <summary>
        /// Determines whether the <see cref="BasicxLogger.MultiLogger"/> contains a specific value.
        /// </summary>
        /// <param name="item">The object to locate in the <see cref="BasicxLogger.MultiLogger"/>.</param>
        /// <returns>
        /// true if item is found in the System.Collections.Generic.ICollection`1; otherwise, false.
        /// </returns>
        public bool Contains(ILogger item)
        {
            return _loggerList.Contains(item);
        }
        /// <summary>
        /// Copies the elements of the <see cref="BasicxLogger.MultiLogger"/> to an <see cref="System.Array"/>,
        /// starting at a particular <see cref="System.Array"/> index.
        /// </summary>
        /// <param name="array">
        /// The one-dimensional System.Array that is the destination of the elements copied 
        /// from <see cref="BasicxLogger.MultiLogger"/>. The <see cref="System.Array"/> must have zero-based indexing.
        /// </param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        /// <exception cref="System.ArgumentNullException">array is null.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">arrayIndex is less than 0.</exception>
        /// <exception cref="System.ArgumentException">
        /// The number of elements in the source <see cref="BasicxLogger.MultiLogger"/>
        /// is greater than the available space from arrayIndex to the end of the destination array.
        /// </exception>
        public void CopyTo(ILogger[] array, int arrayIndex)
        {
            try
            {
                _loggerList.CopyTo(array, arrayIndex);
            }
            catch (ArgumentException)
            {
                throw new ArgumentException("The number of elements in the MultiLogger " +
                    "is greater than the available space from arrayIndex to the end of the destination array.");
            }
            catch (Exception e)
            {
                throw e;
            }    
        }
        /// <summary>
        /// Removes the first occurrence of a specific object from the <see cref="BasicxLogger.MultiLogger"/>.
        /// </summary>
        /// <param name="item">The object to remove from the <see cref="BasicxLogger.MultiLogger"/>.</param>
        /// <returns>
        /// true if item was successfully removed from the <see cref="BasicxLogger.MultiLogger"/> otherwise, false. 
        /// This method also returns false if item is not found in the original <see cref="BasicxLogger.MultiLogger"/>.
        /// </returns>
        /// <exception cref="System.NotSupportedException">The <see cref="BasicxLogger.MultiLogger"/> is read-only.</exception>
        public bool Remove(ILogger item)
        {
            try
            {
                return _loggerList.Remove(item);
            }
            catch (NotSupportedException)
            {
                throw new NotSupportedException("MultiLogger is read-only");
            }
        }
        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="BasicxLogger.Base.ILogger"/> collection.
        /// </summary>
        /// <returns>
        /// An <see cref="System.Collections.IEnumerator"/> object that can be used to
        /// iterate through the <see cref="BasicxLogger.Base.ILogger"/> collection.
        /// </returns>
        public IEnumerator GetEnumerator()
        {
            foreach (ILogger i in _loggerList)
            {
                yield return i;
            }
        }
        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="BasicxLogger.Base.ILogger"/> collection.
        /// </summary>
        /// <returns>
        /// An <see cref="System.Collections.IEnumerator"/> object that can be used to
        /// iterate through the <see cref="BasicxLogger.Base.ILogger"/> collection.
        /// </returns>
        IEnumerator<ILogger> IEnumerable<ILogger>.GetEnumerator()
        {
            foreach (ILogger i in _loggerList)
            {
                yield return i;
            }
        }
    }
}
