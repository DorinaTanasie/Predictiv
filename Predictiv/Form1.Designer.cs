namespace Predictiv
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.ImgOriginalImage = new System.Windows.Forms.PictureBox();
            this.ImgErrorMatrix = new System.Windows.Forms.PictureBox();
            this.btn_LoadImage = new System.Windows.Forms.Button();
            this.btn_Predict = new System.Windows.Forms.Button();
            this.btn_Store = new System.Windows.Forms.Button();
            this.rad128 = new System.Windows.Forms.RadioButton();
            this.radA = new System.Windows.Forms.RadioButton();
            this.radB = new System.Windows.Forms.RadioButton();
            this.radC = new System.Windows.Forms.RadioButton();
            this.radABC = new System.Windows.Forms.RadioButton();
            this.radAplusBminusCdiv2 = new System.Windows.Forms.RadioButton();
            this.radBplusAminusCdiv2 = new System.Windows.Forms.RadioButton();
            this.RadABdiv2 = new System.Windows.Forms.RadioButton();
            this.radJpegLs = new System.Windows.Forms.RadioButton();
            this.radOriginal = new System.Windows.Forms.RadioButton();
            this.radErrorPrediction = new System.Windows.Forms.RadioButton();
            this.radDecoded = new System.Windows.Forms.RadioButton();
            this.numericUpDownK = new System.Windows.Forms.NumericUpDown();
            this.btnErrorMatrix = new System.Windows.Forms.Button();
            this.ImgDecodedImage = new System.Windows.Forms.PictureBox();
            this.btnSaveDecoded = new System.Windows.Forms.Button();
            this.btnDecode = new System.Windows.Forms.Button();
            this.btnLoadEncoded = new System.Windows.Forms.Button();
            this.numericUpDownScale = new System.Windows.Forms.NumericUpDown();
            this.lblScale = new System.Windows.Forms.Label();
            this.lblK = new System.Windows.Forms.Label();
            this.OFD = new System.Windows.Forms.OpenFileDialog();
            this.SFD = new System.Windows.Forms.SaveFileDialog();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.ImgOriginalImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImgErrorMatrix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImgDecodedImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // ImgOriginalImage
            // 
            this.ImgOriginalImage.Location = new System.Drawing.Point(12, 0);
            this.ImgOriginalImage.Name = "ImgOriginalImage";
            this.ImgOriginalImage.Size = new System.Drawing.Size(290, 250);
            this.ImgOriginalImage.TabIndex = 0;
            this.ImgOriginalImage.TabStop = false;
            // 
            // ImgErrorMatrix
            // 
            this.ImgErrorMatrix.Location = new System.Drawing.Point(350, 0);
            this.ImgErrorMatrix.Name = "ImgErrorMatrix";
            this.ImgErrorMatrix.Size = new System.Drawing.Size(254, 250);
            this.ImgErrorMatrix.TabIndex = 1;
            this.ImgErrorMatrix.TabStop = false;
            // 
            // btn_LoadImage
            // 
            this.btn_LoadImage.Location = new System.Drawing.Point(12, 256);
            this.btn_LoadImage.Name = "btn_LoadImage";
            this.btn_LoadImage.Size = new System.Drawing.Size(75, 23);
            this.btn_LoadImage.TabIndex = 2;
            this.btn_LoadImage.Text = "Load Image";
            this.btn_LoadImage.UseVisualStyleBackColor = true;
            this.btn_LoadImage.Click += new System.EventHandler(this.btn_LoadImage_Click);
            // 
            // btn_Predict
            // 
            this.btn_Predict.Location = new System.Drawing.Point(93, 256);
            this.btn_Predict.Name = "btn_Predict";
            this.btn_Predict.Size = new System.Drawing.Size(75, 23);
            this.btn_Predict.TabIndex = 3;
            this.btn_Predict.Text = "Predict";
            this.btn_Predict.UseVisualStyleBackColor = true;
            this.btn_Predict.Click += new System.EventHandler(this.btn_Predict_Click);
            // 
            // btn_Store
            // 
            this.btn_Store.Location = new System.Drawing.Point(189, 256);
            this.btn_Store.Name = "btn_Store";
            this.btn_Store.Size = new System.Drawing.Size(75, 23);
            this.btn_Store.TabIndex = 4;
            this.btn_Store.Text = "Store";
            this.btn_Store.UseVisualStyleBackColor = true;
            this.btn_Store.Click += new System.EventHandler(this.btn_Store_Click);
            // 
            // rad128
            // 
            this.rad128.AutoSize = true;
            this.rad128.Location = new System.Drawing.Point(44, 285);
            this.rad128.Name = "rad128";
            this.rad128.Size = new System.Drawing.Size(43, 17);
            this.rad128.TabIndex = 5;
            this.rad128.TabStop = true;
            this.rad128.Text = "128";
            this.rad128.UseVisualStyleBackColor = true;
            this.rad128.CheckedChanged += new System.EventHandler(this.rad128_CheckedChanged);
            // 
            // radA
            // 
            this.radA.AutoSize = true;
            this.radA.Location = new System.Drawing.Point(44, 308);
            this.radA.Name = "radA";
            this.radA.Size = new System.Drawing.Size(32, 17);
            this.radA.TabIndex = 6;
            this.radA.TabStop = true;
            this.radA.Text = "A";
            this.radA.UseVisualStyleBackColor = true;
            this.radA.CheckedChanged += new System.EventHandler(this.radA_CheckedChanged);
            // 
            // radB
            // 
            this.radB.AutoSize = true;
            this.radB.Location = new System.Drawing.Point(44, 331);
            this.radB.Name = "radB";
            this.radB.Size = new System.Drawing.Size(32, 17);
            this.radB.TabIndex = 7;
            this.radB.TabStop = true;
            this.radB.Text = "B";
            this.radB.UseVisualStyleBackColor = true;
            this.radB.CheckedChanged += new System.EventHandler(this.radB_CheckedChanged);
            // 
            // radC
            // 
            this.radC.AutoSize = true;
            this.radC.Location = new System.Drawing.Point(44, 354);
            this.radC.Name = "radC";
            this.radC.Size = new System.Drawing.Size(32, 17);
            this.radC.TabIndex = 8;
            this.radC.TabStop = true;
            this.radC.Text = "C";
            this.radC.UseVisualStyleBackColor = true;
            this.radC.CheckedChanged += new System.EventHandler(this.radC_CheckedChanged);
            // 
            // radABC
            // 
            this.radABC.AutoSize = true;
            this.radABC.Location = new System.Drawing.Point(44, 377);
            this.radABC.Name = "radABC";
            this.radABC.Size = new System.Drawing.Size(55, 17);
            this.radABC.TabIndex = 9;
            this.radABC.TabStop = true;
            this.radABC.Text = "A+B-C";
            this.radABC.UseVisualStyleBackColor = true;
            this.radABC.CheckedChanged += new System.EventHandler(this.radABC_CheckedChanged);
            // 
            // radAplusBminusCdiv2
            // 
            this.radAplusBminusCdiv2.AutoSize = true;
            this.radAplusBminusCdiv2.Location = new System.Drawing.Point(44, 400);
            this.radAplusBminusCdiv2.Name = "radAplusBminusCdiv2";
            this.radAplusBminusCdiv2.Size = new System.Drawing.Size(72, 17);
            this.radAplusBminusCdiv2.TabIndex = 10;
            this.radAplusBminusCdiv2.TabStop = true;
            this.radAplusBminusCdiv2.Text = "A+(B-C)/2";
            this.radAplusBminusCdiv2.UseVisualStyleBackColor = true;
            this.radAplusBminusCdiv2.CheckedChanged += new System.EventHandler(this.radAplusBminusCdiv2_CheckedChanged);
            // 
            // radBplusAminusCdiv2
            // 
            this.radBplusAminusCdiv2.AutoSize = true;
            this.radBplusAminusCdiv2.Location = new System.Drawing.Point(44, 423);
            this.radBplusAminusCdiv2.Name = "radBplusAminusCdiv2";
            this.radBplusAminusCdiv2.Size = new System.Drawing.Size(72, 17);
            this.radBplusAminusCdiv2.TabIndex = 11;
            this.radBplusAminusCdiv2.TabStop = true;
            this.radBplusAminusCdiv2.Text = "B+(A-C)/2";
            this.radBplusAminusCdiv2.UseVisualStyleBackColor = true;
            this.radBplusAminusCdiv2.CheckedChanged += new System.EventHandler(this.radBplusAminusCdiv2_CheckedChanged);
            // 
            // RadABdiv2
            // 
            this.RadABdiv2.AutoSize = true;
            this.RadABdiv2.Location = new System.Drawing.Point(44, 446);
            this.RadABdiv2.Name = "RadABdiv2";
            this.RadABdiv2.Size = new System.Drawing.Size(62, 17);
            this.RadABdiv2.TabIndex = 12;
            this.RadABdiv2.TabStop = true;
            this.RadABdiv2.Text = "(A+B)/2";
            this.RadABdiv2.UseVisualStyleBackColor = true;
            this.RadABdiv2.CheckedChanged += new System.EventHandler(this.RadABdiv2_CheckedChanged);
            // 
            // radJpegLs
            // 
            this.radJpegLs.AutoSize = true;
            this.radJpegLs.Location = new System.Drawing.Point(44, 469);
            this.radJpegLs.Name = "radJpegLs";
            this.radJpegLs.Size = new System.Drawing.Size(56, 17);
            this.radJpegLs.TabIndex = 13;
            this.radJpegLs.TabStop = true;
            this.radJpegLs.Text = "jpegLs";
            this.radJpegLs.UseVisualStyleBackColor = true;
            this.radJpegLs.CheckedChanged += new System.EventHandler(this.radJpegLs_CheckedChanged);
            // 
            // radOriginal
            // 
            this.radOriginal.AutoSize = true;
            this.radOriginal.Location = new System.Drawing.Point(330, 377);
            this.radOriginal.Name = "radOriginal";
            this.radOriginal.Size = new System.Drawing.Size(60, 17);
            this.radOriginal.TabIndex = 14;
            this.radOriginal.TabStop = true;
            this.radOriginal.Text = "Original";
            this.radOriginal.UseVisualStyleBackColor = true;
            this.radOriginal.CheckedChanged += new System.EventHandler(this.radOriginal_CheckedChanged);
            // 
            // radErrorPrediction
            // 
            this.radErrorPrediction.AutoSize = true;
            this.radErrorPrediction.Location = new System.Drawing.Point(330, 400);
            this.radErrorPrediction.Name = "radErrorPrediction";
            this.radErrorPrediction.Size = new System.Drawing.Size(97, 17);
            this.radErrorPrediction.TabIndex = 15;
            this.radErrorPrediction.TabStop = true;
            this.radErrorPrediction.Text = "Error Prediction";
            this.radErrorPrediction.UseVisualStyleBackColor = true;
            this.radErrorPrediction.CheckedChanged += new System.EventHandler(this.radErrorPrediction_CheckedChanged);
            // 
            // radDecoded
            // 
            this.radDecoded.AutoSize = true;
            this.radDecoded.Location = new System.Drawing.Point(330, 423);
            this.radDecoded.Name = "radDecoded";
            this.radDecoded.Size = new System.Drawing.Size(69, 17);
            this.radDecoded.TabIndex = 16;
            this.radDecoded.TabStop = true;
            this.radDecoded.Text = "Decoded";
            this.radDecoded.UseVisualStyleBackColor = true;
            this.radDecoded.CheckedChanged += new System.EventHandler(this.radDecoded_CheckedChanged);
            // 
            // numericUpDownK
            // 
            this.numericUpDownK.Location = new System.Drawing.Point(138, 305);
            this.numericUpDownK.Name = "numericUpDownK";
            this.numericUpDownK.Size = new System.Drawing.Size(48, 20);
            this.numericUpDownK.TabIndex = 18;
            // 
            // btnErrorMatrix
            // 
            this.btnErrorMatrix.Location = new System.Drawing.Point(383, 256);
            this.btnErrorMatrix.Name = "btnErrorMatrix";
            this.btnErrorMatrix.Size = new System.Drawing.Size(157, 23);
            this.btnErrorMatrix.TabIndex = 19;
            this.btnErrorMatrix.Text = "Show Error Matrix";
            this.btnErrorMatrix.UseVisualStyleBackColor = true;
            // 
            // ImgDecodedImage
            // 
            this.ImgDecodedImage.Location = new System.Drawing.Point(647, 0);
            this.ImgDecodedImage.Name = "ImgDecodedImage";
            this.ImgDecodedImage.Size = new System.Drawing.Size(254, 250);
            this.ImgDecodedImage.TabIndex = 20;
            this.ImgDecodedImage.TabStop = false;
            // 
            // btnSaveDecoded
            // 
            this.btnSaveDecoded.Location = new System.Drawing.Point(826, 256);
            this.btnSaveDecoded.Name = "btnSaveDecoded";
            this.btnSaveDecoded.Size = new System.Drawing.Size(129, 23);
            this.btnSaveDecoded.TabIndex = 23;
            this.btnSaveDecoded.Text = "Save Decoded";
            this.btnSaveDecoded.UseVisualStyleBackColor = true;
            // 
            // btnDecode
            // 
            this.btnDecode.Location = new System.Drawing.Point(739, 256);
            this.btnDecode.Name = "btnDecode";
            this.btnDecode.Size = new System.Drawing.Size(75, 23);
            this.btnDecode.TabIndex = 22;
            this.btnDecode.Text = "Decode";
            this.btnDecode.UseVisualStyleBackColor = true;
            // 
            // btnLoadEncoded
            // 
            this.btnLoadEncoded.Location = new System.Drawing.Point(619, 256);
            this.btnLoadEncoded.Name = "btnLoadEncoded";
            this.btnLoadEncoded.Size = new System.Drawing.Size(114, 23);
            this.btnLoadEncoded.TabIndex = 21;
            this.btnLoadEncoded.Text = "Load Encoded";
            this.btnLoadEncoded.UseVisualStyleBackColor = true;
            // 
            // numericUpDownScale
            // 
            this.numericUpDownScale.Location = new System.Drawing.Point(329, 259);
            this.numericUpDownScale.Name = "numericUpDownScale";
            this.numericUpDownScale.Size = new System.Drawing.Size(48, 20);
            this.numericUpDownScale.TabIndex = 24;
            // 
            // lblScale
            // 
            this.lblScale.AutoSize = true;
            this.lblScale.Location = new System.Drawing.Point(283, 262);
            this.lblScale.Name = "lblScale";
            this.lblScale.Size = new System.Drawing.Size(37, 13);
            this.lblScale.TabIndex = 25;
            this.lblScale.Text = "Scale:";
            // 
            // lblK
            // 
            this.lblK.AutoSize = true;
            this.lblK.Location = new System.Drawing.Point(115, 308);
            this.lblK.Name = "lblK";
            this.lblK.Size = new System.Drawing.Size(17, 13);
            this.lblK.TabIndex = 26;
            this.lblK.Text = "K:";
            // 
            // OFD
            // 
            this.OFD.FileName = "openFileDialog1";
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.DimGray;
            chartArea4.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea4);
            this.chart1.Location = new System.Drawing.Point(474, 285);
            this.chart1.Margin = new System.Windows.Forms.Padding(0);
            this.chart1.Name = "chart1";
            series4.ChartArea = "ChartArea1";
            series4.CustomProperties = "PointWidth=0.01";
            series4.IsVisibleInLegend = false;
            series4.Name = "Histogram";
            this.chart1.Series.Add(series4);
            this.chart1.Size = new System.Drawing.Size(533, 300);
            this.chart1.TabIndex = 27;
            this.chart1.Text = "chart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 582);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.lblK);
            this.Controls.Add(this.lblScale);
            this.Controls.Add(this.numericUpDownScale);
            this.Controls.Add(this.btnSaveDecoded);
            this.Controls.Add(this.btnDecode);
            this.Controls.Add(this.btnLoadEncoded);
            this.Controls.Add(this.ImgDecodedImage);
            this.Controls.Add(this.btnErrorMatrix);
            this.Controls.Add(this.numericUpDownK);
            this.Controls.Add(this.radDecoded);
            this.Controls.Add(this.radErrorPrediction);
            this.Controls.Add(this.radOriginal);
            this.Controls.Add(this.radJpegLs);
            this.Controls.Add(this.RadABdiv2);
            this.Controls.Add(this.radBplusAminusCdiv2);
            this.Controls.Add(this.radAplusBminusCdiv2);
            this.Controls.Add(this.radABC);
            this.Controls.Add(this.radC);
            this.Controls.Add(this.radB);
            this.Controls.Add(this.radA);
            this.Controls.Add(this.rad128);
            this.Controls.Add(this.btn_Store);
            this.Controls.Add(this.btn_Predict);
            this.Controls.Add(this.btn_LoadImage);
            this.Controls.Add(this.ImgErrorMatrix);
            this.Controls.Add(this.ImgOriginalImage);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.ImgOriginalImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImgErrorMatrix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImgDecodedImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ImgOriginalImage;
        private System.Windows.Forms.PictureBox ImgErrorMatrix;
        private System.Windows.Forms.Button btn_LoadImage;
        private System.Windows.Forms.Button btn_Predict;
        private System.Windows.Forms.Button btn_Store;
        private System.Windows.Forms.RadioButton rad128;
        private System.Windows.Forms.RadioButton radA;
        private System.Windows.Forms.RadioButton radB;
        private System.Windows.Forms.RadioButton radC;
        private System.Windows.Forms.RadioButton radABC;
        private System.Windows.Forms.RadioButton radAplusBminusCdiv2;
        private System.Windows.Forms.RadioButton radBplusAminusCdiv2;
        private System.Windows.Forms.RadioButton RadABdiv2;
        private System.Windows.Forms.RadioButton radJpegLs;
        private System.Windows.Forms.RadioButton radOriginal;
        private System.Windows.Forms.RadioButton radErrorPrediction;
        private System.Windows.Forms.RadioButton radDecoded;
        private System.Windows.Forms.NumericUpDown numericUpDownK;
        private System.Windows.Forms.Button btnErrorMatrix;
        private System.Windows.Forms.PictureBox ImgDecodedImage;
        private System.Windows.Forms.Button btnSaveDecoded;
        private System.Windows.Forms.Button btnDecode;
        private System.Windows.Forms.Button btnLoadEncoded;
        private System.Windows.Forms.NumericUpDown numericUpDownScale;
        private System.Windows.Forms.Label lblScale;
        private System.Windows.Forms.Label lblK;
        private System.Windows.Forms.OpenFileDialog OFD;
        private System.Windows.Forms.SaveFileDialog SFD;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}

