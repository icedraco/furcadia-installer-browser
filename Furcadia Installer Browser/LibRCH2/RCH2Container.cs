using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace LibRCH2
{
    /// <summary>
    /// This class represents an RCH2.0 "container", which is a single file
    /// that contains other files within it.
    /// </summary>
    public class RCH2Container
    {
        /*** Constants ***/
        public const string MAGIC_NUMBER = "RCH2.0";

        /*** Data Members ***/
        private BinaryReader br = null;
        public List<RCH2File> Files = new List<RCH2File>();
       
        /*** Properties ***/
        public int Count { get { return Files.Count; } }

        /*** Static Functions ***/
        public static RCH2Container CreateFromReader(ref BinaryReader br)
        {
            return new RCH2Container(ref br);
        }

        /// <summary>
        /// Checks whether the magic number readen from an open binary reader
        /// instance is correct or not.
        /// 
        /// NOTE: The binary reader is not reset to its previous position after
        ///       the check!
        /// </summary>
        /// <param name="br"></param>
        /// <returns></returns>
        public static bool CheckMagicNumber(ref BinaryReader br)
        {
            byte[] magic = br.ReadBytes(MAGIC_NUMBER.Length);
            return Encoding.ASCII.GetString(magic) == MAGIC_NUMBER;
        }

        /*** Constructor ***/
        public RCH2Container()
        {
        }

        /// <summary>
        /// Initialize a new RCH2 container instance from an already open
        /// BinaryReader.
        /// 
        /// The initialization begins from the current position of the BinaryReader
        /// and not from the beginning of the file!
        /// 
        /// The reader doesn't get closed at the end of the process, nor does the
        /// position get reset to what it was!
        /// </summary>
        /// <param name="br">An open binary reader to read from</param>
        public RCH2Container(ref BinaryReader br)
        {
            SetBinaryReader(ref br);
            ProcessData();
        }

        /// <summary>
        /// Initialize a new RCH2 container instance from a specific filename.
        /// </summary>
        /// <param name="fileName">Filename to read data from</param>
        public RCH2Container(string fileName)
        {
            Open(fileName);
        }

        /*** Methods ***/
        public void SetBinaryReader(ref BinaryReader br)
        {
            this.br = br;
        }

        /// <summary>
        /// Opens a file and initializes the object from within it.
        /// 
        /// An exception is thrown if something goes wrong.
        /// </summary>
        /// <param name="fileName">Filename to read data from</param>
        public void Open(string fileName)
        {
            br = new BinaryReader(new FileStream(fileName, FileMode.Open, FileAccess.Read));
            ProcessData();
        }

        /// <summary>
        /// Begins processing data from a currently open BinaryReader, be it
        /// from the Open() method, or SetBinaryReader().
        /// 
        /// An exception is thrown if something goes wrong.
        /// </summary>
        public void ProcessData()
        {
            // Clear the file list since we're starting afresh here.
            Files.Clear();

            // Check magic number.
            if (!CheckMagicNumber(ref br))
                throw new Exception("Not an RCH2.0 file or bad magic number");

            // Start creating file entries from the rest.
            RCH2File file;
            while ((file = RCH2File.CreateFromReader(ref br)) != null)
                Files.Add(file);
        }
    }
}
