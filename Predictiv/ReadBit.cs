using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Predictiv
{
    public class BitReader : IDisposable
    {

        public int BuferC;
        public int NumberOfReadBits;
        FileStream fsSource;
        public static int readCounter = 0;
        public static byte buffer;
        public BitReader(string path)
        {

            fsSource = new FileStream(path, FileMode.Open);
            NumberOfReadBits = 0;
            readCounter = 0;
        }

        public void Dispose()
        {
            fsSource.Dispose();
        }

        public byte Read_Bit()
        {

            //if (NumberOfReadBits == 0)
            //{
            //    //citesc un byte si il pun in buffer 
            //    BuferC = fsSource.ReadByte();
            //    NumberOfReadBits = 8;
            //}

            //var result = Convert.ToUInt32(BuferC % 2); // deoarece iau bitul de la stanga
            //BuferC = BuferC / 2;
            ////iau bit din buffer
            //NumberOfReadBits--;

            ////returnez bit
            //return result;

            if (readCounter % 8 == 0)
                buffer = (byte)fsSource.ReadByte();

            byte value = (byte)((buffer >> (7 - (readCounter % 8))) & 0x01);
            readCounter++;

            return value;

        }
        public UInt32 Read_N_Bits(int nr)
        {
            //    UInt32 result = 0;
            //    for (var i = 0; i < nr; i++)
            //    {

            //        result = result + (uint)Math.Pow(2, i) * Read_Bit();

            //    }
            //    return result;
            //}
            uint value = 0;

            for (int i = 0; i < nr; i++)
            {
                byte bit = Read_Bit();
                value = (uint)(value | (uint)(bit << (nr - i - 1)));
            }

            return value;

        }
    }
}
