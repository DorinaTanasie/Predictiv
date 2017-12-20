using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Predictiv
{
    public  class Root
    {
        public  int[,] OrigMatrix;
        public int[,] PredMatrix;
        public int[,] ErPredMatrix;
        public int[,] TempMatrix;
        public int[,] DecodedMatrix;
        public int predictorUsed = 0;
        public byte[] bmpHeader;
        
        BitWriter bitWriter;
        public string origImgPath;
        public string CodedImgPath;

        public Root()
        {
            OrigMatrix = new int[256, 256];
            PredMatrix = new int[256, 256];
            ErPredMatrix = new int[256, 256];
            TempMatrix= new int[256, 256];
            DecodedMatrix = new int[256, 256];
            bmpHeader = new byte[1078]; // folosit pentru decodare, reprezinta extensia pentru bmp
            

        }
        public  void Init()
        {
            for (int i = 0; i < 256; i++)
                for (int j = 0; j < 256; j++)
                {
                    OrigMatrix[i, j] = 0;
                    PredMatrix[i, j] = 0;
                    ErPredMatrix[i, j] = 0;
                    DecodedMatrix[i, j] = 0;
                    TempMatrix[i, j] = 0;
                 
                }
        }
        public void OriginalImageMatrix(Bitmap OriginalImage)
        {
            for (int i = 0; i < 256; i++)
            {
                for (int j = 0; j < 256; j++)
                {
                    OrigMatrix[i, j] = OriginalImage.GetPixel(i, j).B;
                }
            }
            GetHeaderForPredictiveMatrix();//apel doar de test
        }


      public void GetHeaderForPredictiveMatrix()//in loc de header luam din matrice matricea originala primul rand si prima coloana 
        {
            for (int i = 1; i < 256; i++)
            {
                PredMatrix[0, i] = OrigMatrix[0, i - 1];
                PredMatrix[i, 0] = OrigMatrix[i - 1, 0];
                PredMatrix[0, 0] = 128;
            }
            Encoded();
        }

        /// <summary>
        /// A= a[i-1,j]
        /// B= a[i,j-1]
        /// C= a[i-1,j-1]
        /// </summary>


        public void Encoded()
        {
            int currentPixel=0;
            for (int i = 1; i < 256; i++)
            {
                for (int j = 1; j < 256; j++)
                {
                    
                  
                     if (predictorUsed == 0) //128
                    {
                        currentPixel = 128;
                    }
                     else
                      if (predictorUsed == 1) //A
                    {
                        currentPixel = OrigMatrix[i - 1, j];
                    }
                    else
                      if (predictorUsed == 2) //B
                    {
                        currentPixel = OrigMatrix[i , j-1];
                    }
                    else
                      if (predictorUsed == 3)//C
                    {
                        currentPixel = OrigMatrix[i - 1, j - 1];
                    }
                    else
                      if (predictorUsed == 4) //A+B-C
                    {
                        currentPixel = OrigMatrix[i - 1, j] + OrigMatrix[i, j - 1] - OrigMatrix[i - 1, j - 1];
                    }
                    else
                      if (predictorUsed == 5) //A+(B-C)/2
                    {
                        currentPixel = OrigMatrix[i - 1, j] + (OrigMatrix[i, j - 1] - OrigMatrix[i - 1, j - 1]) / 2;
                    }
                    else
                      if (predictorUsed == 6) //B+(A-C)/2
                    {
                        currentPixel = OrigMatrix[i, j - 1] + (OrigMatrix[i-1,j] - OrigMatrix[i - 1, j - 1]) / 2;
                    }
                    else
                      if (predictorUsed == 7)//(A+B)/2
                    {
                        currentPixel = (OrigMatrix[i - 1, j] + OrigMatrix[i, j - 1]) / 2;
                    }
                    else
                      if (predictorUsed == 8)//jpegLS
                    {
                        currentPixel = 0;
                    }


                    if (currentPixel > 255)
                        currentPixel = 255;
                    if (currentPixel < 0)
                        currentPixel = 0;
                    PredMatrix[i, j] = currentPixel;
                    ErPredMatrix[i-1, j-1] = OrigMatrix[i-1, j-1] - PredMatrix[i-1, j-1];

                }
            }
        }
        public  Bitmap DrawImage(int[,] matrix)
        {
            Bitmap bitmap = new Bitmap(256, 256);
            for (int i = 0; i < 256; i++)
            {
                for (int j = 0; j < 256; j++)
                {
                    int value = matrix[i, j];

                    if (value < 0)
                        value = 0;
                    if (value > 255)
                        value = 255;
                    Color color = Color.FromArgb(255, value, value, value);
                    bitmap.SetPixel(j, i, color);
                }
            }

            return bitmap;
        }
        public int[] GetFrequencies(int[,] matrix)
        {
            int[] histograma = new int[511];
            for (int i = 0; i < 256; i++)
            {
                for (int j = 0; j < 256; j++)
                {
                    int indexValue = matrix[i, j]+256;
                    histograma[indexValue]++;
                }
            }

            return histograma;
        }

       
        public void SaveEncodedFile()
        {
         
            bitWriter = new BitWriter(CodedImgPath);


            foreach (byte bit in bmpHeader)
            {
                bitWriter.Write_N_Bit(bit, 8);
            }
            bitWriter.Write_N_Bit(predictorUsed, 4);
            for(int i = 0; i < 256; i++)
            {
                for(int j = 0; j < 256; j++)
                {
                    int value = ErPredMatrix[i, j];
                    bitWriter.Write_N_Bit(value,9);
                }
            }
            bitWriter.Write_N_Bit(0,7);
            bitWriter.Dispose();

        }
    }
}
