using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Predictiv
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            btn_Predict.Enabled = false;
            radOriginal.Enabled = false;
            radErrorPrediction.Enabled = false;
            radDecoded.Enabled = false;


        }
        Root root = new Root();
        BitReader bitReader;

        Bitmap Original;
        private void SaveImage(SaveFileDialog sFD)
        {
          
            sFD.Title = "Save an Image File";
            FileInfo fileInfo = new FileInfo(root.origImgPath);
            string originalName = fileInfo.Name;
            sFD.FileName = originalName + root.predictorUsed + ".pre";

            if (sFD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                root.CodedImgPath = sFD.FileName;
                root.SaveEncodedFile();

            }
        }

        private void LoadImage(OpenFileDialog oFD)
        {
            oFD.Title = "Open Image";
           // oFD.Filter = "bmp files (*.bmp)|*.bmp";
            if (oFD.ShowDialog() == DialogResult.OK)
            {

                root.origImgPath = oFD.FileName;
                bitReader = new BitReader(root.origImgPath);
                for (int i = 0; i < 1078; i++)
                {
                    root.bmpHeader[i] = (byte)bitReader.Read_N_Bits(8);
                }
                bitReader.Dispose();
                ImgOriginalImage.Image = new Bitmap(oFD.FileName);
                Original = new Bitmap(oFD.FileName);

            }




        }

        private void btn_LoadImage_Click(object sender, EventArgs e)
        {
            LoadImage(OFD);
        }
        private void btn_Store_Click(object sender, EventArgs e)
        {
            SaveImage(SFD);
        }

        private void btn_Predict_Click(object sender, EventArgs e)
        {
            root.Init();
            root.OriginalImageMatrix(Original);
            ImgErrorMatrix.Image = root.DrawImage(root.ErPredMatrix);
            ImgErrorMatrix.Image.RotateFlip(RotateFlipType.Rotate90FlipX);
            radOriginal.Enabled = true;
            radErrorPrediction.Enabled = true;



        }



        private void rad128_CheckedChanged(object sender, EventArgs e)
        {

            root.predictorUsed = 0;
            btn_Predict.Enabled = true;


        }

        private void radA_CheckedChanged(object sender, EventArgs e)
        {


            root.predictorUsed = 1;
            btn_Predict.Enabled = true;

        }

        private void radB_CheckedChanged(object sender, EventArgs e)
        {
            root.predictorUsed = 2;
            btn_Predict.Enabled = true;
        }

        private void radC_CheckedChanged(object sender, EventArgs e)
        {
            root.predictorUsed = 3;
            btn_Predict.Enabled = true;
        }

        private void radABC_CheckedChanged(object sender, EventArgs e)
        {
            root.predictorUsed = 4;
            btn_Predict.Enabled = true;
        }

        private void radAplusBminusCdiv2_CheckedChanged(object sender, EventArgs e)
        {
            root.predictorUsed = 5;
            btn_Predict.Enabled = true;
        }

        private void radBplusAminusCdiv2_CheckedChanged(object sender, EventArgs e)
        {
            root.predictorUsed = 6;
            btn_Predict.Enabled = true;
        }

        private void RadABdiv2_CheckedChanged(object sender, EventArgs e)
        {
            root.predictorUsed = 7;
            btn_Predict.Enabled = true;
        }

        private void radJpegLs_CheckedChanged(object sender, EventArgs e)
        {
            root.predictorUsed = 8;
            btn_Predict.Enabled = true;
        }

        private void radOriginal_CheckedChanged(object sender, EventArgs e)
        {

            int[] freq = new int[256];
            freq = root.GetFrequencies(root.OrigMatrix);
            for (int i = 0; i < freq.Length; i++)
            {
                this.chart1.Series["Histograma"].Points.AddXY(i - 256, freq[i]);
            }
        }

        private void radErrorPrediction_CheckedChanged(object sender, EventArgs e)
        {

            int[] freq = new int[511];
            freq = root.GetFrequencies(root.ErPredMatrix);
            for (int i = 0; i < freq.Length; i++)
            {

                this.chart1.Series["Histograma"].Points.AddXY(i - 256, freq[i]);
            }
        }

        private void radDecoded_CheckedChanged(object sender, EventArgs e)
        {
            int[] freq = new int[511];
            freq = root.GetFrequencies(root.DecMatrix);
            for (int i = 0; i < freq.Length; i++)
            {

                this.chart1.Series["Histograma"].Points.AddXY(i - 256, freq[i]);
            }
        }

        private void btnLoadEncoded_Click(object sender, EventArgs e)
        {
            LoadDecodedFile(OFD);
        }
        private void LoadDecodedFile(OpenFileDialog oFD)
        {
            oFD.Title = "Open Image";
            
            if (oFD.ShowDialog() == DialogResult.OK)
            {

                root.origImgPath = oFD.FileName;
                bitReader = new BitReader(root.origImgPath);
                for (int i = 0; i < 1078; i++)
                {
                    root.decBmpHeader[i] = (byte)bitReader.Read_N_Bits(8);
                }
                root.DecPredictorUsed= (byte)bitReader.Read_N_Bits(4);

                for (int i = 0; i < 256; i++)
                {
                    for (int j = 0; j < 256; j++)
                    {
                        root.DecErPredMatrix[i, j] = Convert.ToInt32(bitReader.Read_N_Bits(9))-255;
                    }
                }
                bitReader.Dispose();


            }
        }

        private void btnDecode_Click(object sender, EventArgs e)
        {
            root.Decode();
            root.GetHeaderForDecOdedtiveMatrix();
            ImgDecodedImage.Image = root.DrawImage(root.DecMatrix);
            ImgDecodedImage.Image.RotateFlip(RotateFlipType.Rotate90FlipX);

            radDecoded.Enabled = true;
        }

        private void btnSaveDecoded_Click(object sender, EventArgs e)
        {
            
                SFD.Title = "Save an Image ";
                FileInfo fileInfo = new FileInfo(root.origImgPath);
                string originalName = fileInfo.Name;
                SFD.FileName = originalName + root.DecPredictorUsed + ".pre"+".decoded";

                if (SFD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    root.CodedImgPath = SFD.FileName;
                  

                }
            }
    }
}
