using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace LibRCH2
{
    /// <summary>
    /// This class represents a single file inside an RCH2.0 container.
    /// </summary>
    public class RCH2File
    {
        /*** Constants ***/
        public const string MAGIC_NUMBER = "FZ";
        private const uint FILENAME_SIZE_THRESHOLD = 20000;

        /*** Data Members ***/
        private BinaryReader br;
        private uint nFileSize = 0;
        private uint nCRCSum = 0;
        private string sFilename = "";
        private long nDataPosition = -1;

        /*** Properties ***/
        public uint Size { get { return nFileSize; } }
        public string Filename { get { return System.IO.Path.GetFileName(sFilename); } }
        public string Path { get { return sFilename; } }
        public uint CRCSum { get { return nCRCSum; } }
        public bool CRCVerified { get { return VerifyData(); } }

        /*** Static Functions ***/
        public static RCH2File CreateFromReader(ref BinaryReader br)
        {
            try
            {
                RCH2File file = new RCH2File(ref br);
                return file;
            }
            catch (Exception e)
            {
                return null;
            }
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

        /*** Constructors ***/
        public RCH2File()
        {
        }

        public RCH2File(ref BinaryReader br)
        {
            SetBinaryReader(ref br);
            ProcessData();
        }

        /*** Methods ***/
        public void SetBinaryReader(ref BinaryReader br)
        {
            this.br = br;
        }

        public void ProcessData()
        {
            // Check magic number of the segment.
            if (!CheckMagicNumber(ref br))
                throw new Exception("Not an RCH2.0 file segment or bad magic number");

            ushort fnSize = br.ReadUInt16();

            // Check if the size is too big. If it is, that's it - we're at the end.
            if (fnSize >= FILENAME_SIZE_THRESHOLD)
            {
                br.BaseStream.Position -= 2; // Go back 2 bytes - this is probably no longer our turf.
                throw new Exception("Filename size threshold exceeded - probably an end of RCH2.0 container");
            }

            sFilename = Encoding.ASCII.GetString(br.ReadBytes(fnSize));
            nFileSize = br.ReadUInt32();
            nCRCSum = br.ReadUInt32();
            nDataPosition = br.BaseStream.Position;
            br.BaseStream.Position += nFileSize;
        }

        /// <summary>
        /// Verifies if the data within the file segment has the same CRC32
        /// checksum as the one written in the headers. If it isn't, the data
        /// may be corrupt.
        /// </summary>
        /// <returns>TRUE if the data is considered intact, FALSE otherwise.</returns>
        public bool VerifyData()
        {
            ICSharpCode.SharpZipLib.Checksums.Crc32 checksum = new ICSharpCode.SharpZipLib.Checksums.Crc32();
            checksum.Reset();

            br.BaseStream.Position = GetDataPosition(true);
            ICSharpCode.SharpZipLib.BZip2.BZip2InputStream bzis = new ICSharpCode.SharpZipLib.BZip2.BZip2InputStream(br.BaseStream);
            byte[] buffer = new byte[4096];
            int i = 0;
            while ((i = bzis.Read(buffer, 0, 4096)) > 0)
                checksum.Update(buffer, 0, i);

            return checksum.Value == nCRCSum;
        }

        /// <summary>
        /// Extracts data from within the file segment into a file specified by
        /// the caller.
        /// </summary>
        /// <param name="targetFileName">Filename where to write the extracted contents to</param>
        public void Extract(string targetFileName)
        {
            br.BaseStream.Position = GetDataPosition(true);
            using (FileStream fs = new FileStream(targetFileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                ICSharpCode.SharpZipLib.BZip2.BZip2InputStream bzis = new ICSharpCode.SharpZipLib.BZip2.BZip2InputStream(br.BaseStream);
                byte[] buffer = new byte[4096];
                int size;

                while ((size = bzis.Read(buffer, 0, 4096)) > 0)
                    fs.Write(buffer, 0, size);
                fs.Close();
            }
        }


        /*** Private Functions & Methods ***/
        private byte[] GetByteArray()
        {
            br.BaseStream.Position = GetDataPosition(true);
            return br.ReadBytes((int)nFileSize);
        }

        private long GetDataPosition(bool throwIfNotSet)
        {
            if (throwIfNotSet && nDataPosition < 0)
                throw new Exception("Requested data position while none was set yet");
            return nDataPosition;
        }
    }
}
