using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Predictiv
{
   static class BitsWriter
    {

        static FileStream writer;
        public static int writeCounter = 0;
        public static byte buffer;
        public static void InitWriter(string filename)
        {
            writeCounter = 0;
            writer = new FileStream(filename, FileMode.Create, FileAccess.Write);
        }
        public static void CloseWriter()
        {
            writer.Close();
        }
        public static void WriteBit(int bit)
        {
            buffer = (byte)(buffer | (bit << (7 - writeCounter % 8)));
            writeCounter++;

            if (writeCounter % 8 == 0)
            {
                writer.WriteByte(buffer);
                buffer = 0;
            }
        }

        public static void WriteNBiti(uint biti, int numberOfBits)
        {
           
            for (int i = 0; i < numberOfBits; i++)
                WriteBit((int)(biti >> numberOfBits - i - 1));
        }
    }
}
