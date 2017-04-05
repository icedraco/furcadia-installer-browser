using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using LibRCH2;

namespace Furcadia_Installer_Browser
{
    public class FIB
    {
        /*** Class Variables ***/
        public static List<string> DeleteQueue;


        /*** Static Functions - Delete Queue Management ***/
        /// <summary>
        /// Schedule a specific file for deletion when the application quits.
        /// </summary>
        /// <param name="path">Full or relative path to the filename</param>
        public static void DelSchedule(string path)
        {
            if (!DeleteQueue.Contains(path))
                DeleteQueue.Add(path);
        }
        /// <summary>
        /// Delete all the files in the queue. Usually executed before the
        /// application closes.
        /// </summary>
        public static void EmptyDeleteQueue()
        {
            foreach (string path in DeleteQueue)
            {
                try
                {
                    File.Delete(path);
                }
                catch
                {
                    // If it fails, do nothing...
                }
            }

            DeleteQueue.Clear();
        }

        /*** Static Functions - Miscellaneous ***/
        public static void Init()
        {
            DeleteQueue = new List<string>();
        }

        /// <summary>
        /// Process the path from an RCH2File instance and transform the % and $
        /// characters that act as variables into directory separator characters.
        /// This helps extract everything into a single folder rather than where
        /// the variables tell.
        /// </summary>
        /// <param name="path">RCH2File path</param>
        /// <returns>Path without the variables</returns>
        public static string ProcessPath(string path)
        {
            StringBuilder result = new StringBuilder("");
            for (int i = 0; i < path.Length; i++)
                result.Append((path[i] != '%' && path[i] != '$') ? path[i] : Path.DirectorySeparatorChar);
            return result.ToString();
        }
        /// <summary>
        /// Returns a temporary path to a specific filename (including it).
        /// </summary>
        /// <param name="filename">Filename to use in the temporary path</param>
        /// <returns>Full temporary path to the file specified</returns>
        public static string GetTemporaryPath(string filename)
        {
            return Path.GetTempPath() + Path.DirectorySeparatorChar + filename;
        }
        /// <summary>
        /// Find an RCH2File instance that represents a specific path.
        /// </summary>
        /// <param name="rch2">RCH2 container instance to look in</param>
        /// <param name="filePath">File path to look for</param>
        /// <returns>An RCH2File instance representing a specific path, or null if not found</returns>
        public static RCH2File FindFileByPath(RCH2Container rch2, string filePath)
        {
            foreach (RCH2File file in rch2.Files)
                if (file.Path == filePath)
                    return file;
            return null;
        }

    }
}
