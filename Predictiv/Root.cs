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
        public int[,] PictErrorMatrix;
        public int[,] DecodedMatrix;
        public int predictorUsed = 0;
        public byte[] bmpHeader;
        public int[,] DecErPredMatrix;
        public int scale;
       
        // ------------------------Fields for decoding
        public byte[] decBmpHeader;
        public int DecPredictorUsed ;
        public int[,] DecMatrix;

        //  BitWriter bitWriter;
        public string origImgPath;
        public string CodedImgPath;

        public Root()
        {
            OrigMatrix = new int[256, 256];
            PictErrorMatrix = new int[256, 256];
            PredMatrix = new int[256, 256];
            ErPredMatrix = new int[256, 256];
            TempMatrix= new int[256, 256];
            DecodedMatrix = new int[256, 256];
            bmpHeader = new byte[1078]; // folosit pentru decodare, reprezinta extensia pentru bmp
                                        // ------------------------Fields for decoding
            decBmpHeader = new byte[1078];
            DecErPredMatrix= new int[256, 256];
            DecMatrix= new int[256, 256];


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
                    PictErrorMatrix[i, j] = 0;

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
                    else
                      if (predictorUsed ==9)//jpegLS
                    {
                        currentPixel = (OrigMatrix[i - 1, j]- OrigMatrix[i, j - 1])+(OrigMatrix[i - 1, j - 1]/2);
                    }
                    //(A-B)+C/2

                    if (currentPixel > 255)
                        currentPixel = 255;
                    if (currentPixel < 0)
                        currentPixel = 0;
                    PredMatrix[i, j] = currentPixel;
                    ErPredMatrix[i-1, j-1] = OrigMatrix[i-1, j-1] - PredMatrix[i-1, j-1];

                    PictErrorMatrix[i - 1, j - 1] = 128 + ErPredMatrix[i - 1, j - 1] * scale;
                    if (PictErrorMatrix[i, j] > 255) PictErrorMatrix[i, j] = 255;
                    if (PictErrorMatrix[i, j] < 0) PictErrorMatrix[i, j] = 0;


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
            BitsWriter.InitWriter(CodedImgPath);
            foreach (byte bit in bmpHeader)
            {
               
                BitsWriter.WriteNBiti(bit, 8);
            }
            BitsWriter.WriteNBiti(Convert.ToUInt32(predictorUsed),4);
            
            for (int i = 0; i < 256; i++)
            {
                for (int j = 0; j < 256; j++)
                {
                    uint value = Convert.ToUInt32(ErPredMatrix[i, j] + 255);
                    BitsWriter.WriteNBiti(Convert.ToUInt32(value), 9);
                }
             }
                BitsWriter.WriteNBiti(0, 7);
            BitsWriter.CloseWriter();

        }
        public void GetHeaderForDecOdedtiveMatrix()//in loc de header luam din matrice matricea originala primul rand si prima coloana 
        {
            for (int i = 1; i < 256; i++)
            {
                DecMatrix[0, i] = OrigMatrix[0, i - 1];
                DecMatrix[i, 0] = OrigMatrix[i - 1, 0];
                DecMatrix[0, 0] = 128;
            }
           
        }
        public void Decode()
        {
            int currentPixel = 0;
            for (int i = 1; i < 256; i++)
            {
                for (int j = 1; j < 256; j++)
                {
                    if(i==0 && j == 0)
                    {
                        currentPixel = 128;
                    }

                    if (DecPredictorUsed == 0) //128
                    {
                        currentPixel = 128;
                    }
                    else
                     if (DecPredictorUsed == 1) //A
                    {
                        currentPixel = OrigMatrix[i - 1, j];
                    }
                    else
                     if (DecPredictorUsed == 2) //B
                    {
                        currentPixel = OrigMatrix[i, j - 1];
                    }
                    else
                     if (DecPredictorUsed == 3)//C
                    {
                        currentPixel = OrigMatrix[i - 1, j - 1];
                    }
                    else
                     if (DecPredictorUsed == 4) //A+B-C
                    {
                        currentPixel = OrigMatrix[i - 1, j] + OrigMatrix[i, j - 1] - OrigMatrix[i - 1, j - 1];
                    }
                    else
                     if (DecPredictorUsed == 5) //A+(B-C)/2
                    {
                        currentPixel = OrigMatrix[i - 1, j] + (OrigMatrix[i, j - 1] - OrigMatrix[i - 1, j - 1]) / 2;
                    }
                    else
                     if (DecPredictorUsed == 6) //B+(A-C)/2
                    {
                        currentPixel = OrigMatrix[i, j - 1] + (OrigMatrix[i - 1, j] - OrigMatrix[i - 1, j - 1]) / 2;
                    }
                    else
                     if (DecPredictorUsed == 7)//(A+B)/2
                    {
                        currentPixel = (OrigMatrix[i - 1, j] + OrigMatrix[i, j - 1]) / 2;
                    }
                    else
                     if (DecPredictorUsed == 8)//jpegLS
                    {
                        currentPixel = 0;
                    }

                    PredMatrix[i, j] = currentPixel;
                    int decValue = DecErPredMatrix[i, j] + PredMatrix[i, j];
                    if (decValue > 255)
                        decValue = 255;
                    if (decValue < 0)
                        decValue = 0;

                    DecMatrix[i, j] = decValue;


                }
            }
        }
        public void SaveDecodedFile()
        {
            BitsWriter.InitWriter(CodedImgPath);
            foreach (byte bit in decBmpHeader)
            {

                BitsWriter.WriteNBiti(bit, 8);
            }
           

            for (int i = 0; i < 256; i++)
            {
                for (int j = 0; j < 256; j++)
                {
                    uint value = Convert.ToUInt32(ErPredMatrix[i, j] + 255);
                    BitsWriter.WriteNBiti(Convert.ToUInt32(value), 9);
                }
            }
            BitsWriter.WriteNBiti(0, 7);
            BitsWriter.CloseWriter();

        }
    }
}
