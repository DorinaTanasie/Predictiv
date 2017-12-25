using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Predictiv
{
    public static class BitsReader
    {
        public static int readCounter=0;
        public static byte buffer;
        
        static FileStream reader;
        
        public static void InitReader(string filename)
        {
            readCounter = 0;
            reader = new FileStream(filename, FileMode.Open, FileAccess.Read);
        }
        
          
        

       

        public static byte ReadBit()
        {

            
            if (readCounter % 8 == 0)
                buffer = (byte)reader.ReadByte();

            byte value = (byte)((buffer >> (7 - (readCounter % 8))) & 0x01);
            readCounter++;

            return value;
        }

        public static  uint ReadNBit(int numberOfBits)
        {
            uint value = 0;

            for (int i = 0; i <numberOfBits; i++)
            {
                byte bit = ReadBit();
                value = (uint)(value | (uint)(bit << (numberOfBits - i-1))); 
            }

            return value;
        }

      



    }
}
