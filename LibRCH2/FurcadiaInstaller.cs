using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace LibRCH2
{
    public class FurcadiaInstaller
    {
        /*** Constants ***/
        private const int SEARCH_BUFFER_LENGTH = 8192;
        private static long[] RCH2_OFFSETS = { 0x9fa00, 0x30000, 0x2f000 };

        /*** Static Functions ***/
        public static RCH2Container GetFileContainer(string fileName)
        {
            BinaryReader br = new BinaryReader(new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read));

            // Find where in the installer the RCH2 package resides.
            if (FindContainer(ref br) < 0)
                return null;

            // Read the data.
            try
            {
                return new RCH2Container(ref br);
            }
            catch
            {
                return null;
            }
        }

        public static long FindContainer(ref BinaryReader br)
        {
            // Try the known offsets first.
            foreach (long offset in RCH2_OFFSETS)
            {
                br.BaseStream.Position = offset;
                if (RCH2Container.CheckMagicNumber(ref br))
                {
                    br.BaseStream.Position = offset;
                    return offset;
                }
            }

            // If we didn't find the right magic number yet, go through the
            // entire file. This is kinda tedious.
            br.BaseStream.Position = 0;

            string extended_magic = RCH2Container.MAGIC_NUMBER + RCH2File.MAGIC_NUMBER;
            byte[] buffer = new byte[0];
            int j = 0;
            int i = 0;
            while (i < extended_magic.Length)
            {
                // If we ran out of buffer, get some more from the file.
                if (j >= buffer.Length)
                {
                    if (br.BaseStream.Position >= br.BaseStream.Length)
                        return -1; // Failed to locate.

                    buffer = br.ReadBytes(SEARCH_BUFFER_LENGTH);
                    j = 0;
                }

                i = (buffer[j++] == extended_magic[i]) ? i + 1 : 0;
            }

            return br.BaseStream.Position - buffer.Length + j - i;
        }
    }
}
