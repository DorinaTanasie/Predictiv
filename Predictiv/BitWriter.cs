using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Predictiv
{
    class BitWriter : IDisposable
    {
        public int BufferWriter; //can be an array of a byte
        public int NumberOfBitWritel;
        private byte result;
        BinaryWriter fsOutput;
        public BitWriter(string path)
        {

            fsOutput = new BinaryWriter(new FileStream(path, FileMode.Create));
            NumberOfBitWritel = 0;
        }

        public void Write_Bit(uint val)
        {

            val = val % 2;
            result = Convert.ToByte(result + Math.Pow(2, NumberOfBitWritel) * val);
            //var result = Convert.ToUInt32(val % 2); // deoarece iau bitul de la stanga
            //  val = val / 2;

            if (ISBufferFull())
            {
                //write BufferWriter into output file
                NumberOfBitWritel = 0;
                fsOutput.Write(result);
                result = 0;
                return;
            }
            NumberOfBitWritel++;

        }
        private bool ISBufferFull()
        {
            return NumberOfBitWritel == 7;
        }
        public void Write_N_Bit(int numberOfBits, uint value)
        {   //numberOfBits va fi o valoare intre [1--32]
            // valoarea trebuie sa fie un numar fara semn care poate fi salvata pe cel putin 32 biti

            for (int k = numberOfBits - 1; k >= 0; k--)
            {

                Write_Bit(value);
                value = value >> 1;
            }
        }

        public void Dispose()
        {
            fsOutput.Flush();
            fsOutput.Dispose();
        }
    }
}
