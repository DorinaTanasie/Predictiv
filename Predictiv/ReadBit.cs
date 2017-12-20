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
        public BitReader(string path)
        {

            fsSource = new FileStream(path, FileMode.Open);
            NumberOfReadBits = 0;
        }

        public void Dispose()
        {
            fsSource.Dispose();
        }

        public UInt32 Read_Bit()
        {

            if (NumberOfReadBits == 0)
            {
                //citesc un byte si il pun in buffer 
                BuferC = fsSource.ReadByte();
                NumberOfReadBits = 8;
            }

            var result = Convert.ToUInt32(BuferC % 2); // deoarece iau bitul de la stanga
            BuferC = BuferC / 2;
            //iau bit din buffer
            NumberOfReadBits--;

            //returnez bit
            return result;

        }
        public UInt32 Read_N_Bits(int nr)
        {
            UInt32 result = 0;
            for (var i = 0; i < nr; i++)
            {

                result = result + (uint)Math.Pow(2, i) * Read_Bit();

            }
            return result;
        }

    }
}
