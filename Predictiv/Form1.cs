using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
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
       
        Bitmap Original;
        private void SaveImage(SaveFileDialog sFD)
        {

            sFD.Filter = "Images|*.bmp";
            ImageFormat format = ImageFormat.Bmp;
            if (sFD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string ext = System.IO.Path.GetExtension(sFD.FileName);
                ImgErrorMatrix.Image.Save(sFD.FileName, format);
            }
        }
        
        private void LoadImage(OpenFileDialog oFD)
        {
            oFD.Title = "Open Image";
            oFD.Filter = "bmp files (*.bmp)|*.bmp";
            if (oFD.ShowDialog() == DialogResult.OK)
            {
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
            root.predictorUsed =3;
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
            freq= root.GetFrequencies(root.OrigMatrix);
            for(int i = 0; i < freq.Length; i++)
            {
                this.chart1.Series["Histogram"].Points.AddXY(i, freq[i]);
            }
        }

        private void radErrorPrediction_CheckedChanged(object sender, EventArgs e)
        {
            int[] freq = new int[511];
            freq = root.GetFrequencies(root.ErPredMatrix);
            for (int i = 0; i < freq.Length; i++)
            {
                this.chart1.Series["Histogram"].Points.AddXY(i-256, freq[i]);
            }
        }

        private void radDecoded_CheckedChanged(object sender, EventArgs e)
        {
            int[] freq = new int[256];
            freq = root.GetFrequencies(root.PredMatrix);
            for (int i = 0; i < freq.Length; i++)
            {
                this.chart1.Series["Histogram"].Points.AddXY(i, freq[i]);
            }
        }
    }
}
