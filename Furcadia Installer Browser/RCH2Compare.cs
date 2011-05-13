/*** RCH2Compare Class
 * (c) 2010 by IceDragon of QuickFox.org
 * 
 * <icedragon@quickfox.org>
 * http://www.icerealm.org/
 */

using System;
using System.Collections.Generic;

namespace LibRCH2
{
    /// <summary>
    /// This class is responsible for comparing two RCH2Container objects and
    /// determining if they are identical, which files are different between
    /// the two, and which files are unique to each container.
    /// </summary>
    public class RCH2Compare
    {
        /*** Data Members ***/
        public List<RCH2File> IdenticalFiles = new List<RCH2File>();
        public CompareFile File1;
        public CompareFile File2;

        /*** Properties ***/
        /// <summary>
        /// TRUE if two install packages are considered identical.
        /// </summary>
        public bool Identical
        {
            get {
                if (compared)
                    return (File1.DifferentFiles.Count +
                    File1.UniqueFiles.Count +
                    File2.DifferentFiles.Count +
                    File2.UniqueFiles.Count) == 0;
                else
                    return Compare();
            }
        }
        public RCH2Container SourceContainer1
        {
            get { return File1.Container; }
            set { File1 = new CompareFile(ref value); }
        }
        public RCH2Container SourceContainer2
        {
            get { return File2.Container; }
            set { File2 = new CompareFile(ref value); }
        }

        /*** Constructor ***/
        public RCH2Compare(ref RCH2Container file1, ref RCH2Container file2) : this(ref file1, ref file2, true) { }
        public RCH2Compare(ref RCH2Container file1, ref RCH2Container file2, bool doCompare)
        {
            SourceContainer1 = file1;
            SourceContainer2 = file2;

            if (doCompare)
                Compare();
        }

        /*** Methods ***/
        /// <summary>
        /// Performs a comparison between the two installer packages and returns
        /// if the two of them carry the same content within.
        /// 
        /// Information on what's different and what's the same is stored within
        /// the public data members.
        /// </summary>
        /// <returns>TRUE if both install packages carry the same data. FALSE otherwise.</returns>
        public bool Compare()
        {
            // If one of the containers is null, we have a problem.
            if (File1.Container == null || File2.Container == null)
                throw new Exception("Attempted to compare with a null RCH2 container");

            // Clear the files in case and something's already inside.
            File1.DifferentFiles.Clear();
            File1.UniqueFiles.Clear();
            File2.DifferentFiles.Clear();
            File2.UniqueFiles.Clear();
            IdenticalFiles.Clear();

            // Rearrange the second container into a dictionary for quick access.
            Dictionary<string, RCH2File> file2_list = new Dictionary<string, RCH2File>(File2.Container.Count);

            foreach (RCH2File file in File2.Container.Files)
                file2_list[file.Path] = file;

            // Compare the two lists.
            foreach (RCH2File file in File1.Container.Files)
            {
                RCH2File file2;
                if (file2_list.TryGetValue(file.Path, out file2))
                {
                    // Compare the two files.
                    if (file.CRCSum != file2.CRCSum)
                    {
                        File1.DifferentFiles.Add(file);
                        File2.DifferentFiles.Add(file2);
                    }
                    else
                        IdenticalFiles.Add(file);

                    // Remove this path from the second list so what's left is
                    // the unique ones.
                    file2_list.Remove(file.Path);
                }
                else
                    File1.UniqueFiles.Add(file);
            }

            foreach (RCH2File file in file2_list.Values)
                File2.UniqueFiles.Add(file);

            // Return if the two files are identical.
            compared = true;
            return Identical;
        }

        #region Internal Stuff
        public struct CompareFile
        {
            public RCH2Container Container;
            public List<RCH2File> DifferentFiles;
            public List<RCH2File> UniqueFiles;

            public CompareFile(ref RCH2Container rch2)
            {
                Container = rch2;
                DifferentFiles = new List<RCH2File>();
                UniqueFiles = new List<RCH2File>();
            }
        };

        private bool compared = false;
        #endregion
    }
}
