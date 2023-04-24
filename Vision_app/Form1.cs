﻿using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using ZXing;
using System.Threading;

using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics.Tracing;
using Tesseract;
using ZXing.Common.Detector;

namespace Vision_app
{
    public partial class Form1 : Form
    {
        VideoCapture capture = new VideoCapture();
        Mat frame = new Mat();
        static BarcodeReader barcodeReader = new BarcodeReader();

        //슬라이딩 메뉴의 최대, 최소 폭 크기
        const int MAX_SLIDING_WIDTH = 200;
        const int MIN_SLIDING_WIDTH = 50;
        //슬라이딩 메뉴가 보이는/접히는 속도 조절
        const int STEP_SLIDING = 10;
        //최초 슬라이딩 메뉴 크기
        int _posSliding = 200;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            capture.Open(0, VideoCaptureAPIs.ANY);

            if (!capture.IsOpened())
            {
                Close();
                return;
            }

            ClientSize = new System.Drawing.Size(capture.FrameWidth, capture.FrameHeight);
            backgroundWorker1.RunWorkerAsync();  // 스레드로 비동기 백그라운드를 실행
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            backgroundWorker1.CancelAsync();
            capture.Dispose();
        }
        
        private void backgroundWoker1_DoWork(object sender, DoWorkEventArgs e) // 실제 작업할 내용을 지정하는 이벤트
        {           
            var bgWorker = (BackgroundWorker)sender;

            while (!bgWorker.CancellationPending)
            {
                using (var frameMat = capture.RetrieveMat())  // 해당 리소스 범위를 벗어나면 자동으로 리소스를 해제해줌
                {
                    var frameBitmap = BitmapConverter.ToBitmap(frameMat);
                    bgWorker.ReportProgress(0, frameBitmap);
                }
                Thread.Sleep(100); // 1초에 10번 갱신, fps 10
            }           
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {                      
            var frameBitmap = (Bitmap)e.UserState;
            currentImage.Image?.Dispose();

            Result barcodeResult = barcodeReader.Decode(frameBitmap);

            Mat src = frameBitmap.ToMat();
            Mat dst = new Mat(src.Size(), MatType.CV_8UC3);

            Cv2.Flip(src, dst, FlipMode.Y);
            currentImage.Image = dst.ToBitmap();
                                          
            if (barcodeResult != null)
            {              
                string qrText = barcodeResult.ToString();
                Mat QRCapture = new Mat();

                Cv2.Resize(dst, QRCapture, new OpenCvSharp.Size(320, 320));             
                                
                OpenCvSharp.Point messagePosition = new OpenCvSharp.Point(QRCapture.Width / 2, QRCapture.Height / 2);
                Cv2.PutText(QRCapture, qrText, messagePosition, HersheyFonts.HersheyComplex, 0.5, Scalar.White);

                capturedImage.Image = QRCapture.ToBitmap();
                /*
                ResultPoint[] border = barcodeResult.ResultPoints;
                Cv2.Rectangle(capture, new OpenCvSharp.Rect((int)border[0].X, (int)border[0].Y, 
                    (int)(border[2].X - border[0].X), (int)(border[2].Y - border[0].Y)), Scalar.Red);
                
                using (Graphics graphics = Graphics.FromImage(frameBitmap))
                {
                    Pen pen = new Pen(Color.Red, 2);
                    graphics.DrawRectangle(pen, graphics);
                }
                */
                currentImage.Image = dst.ToBitmap();

                textBox1.Text = "QR 코드 내용: " + barcodeResult.Text;
                src.Dispose();
            }
            else
            {
                
            }
            
        }

        private void checkHide_CheckedChanged(object sender, EventArgs e)
        {
            if (checkHide.Checked == true)
            {
                button2.Text = " QR";
                button3.Text = " B";
                checkHide.Text = ">";
                button2.TextAlign = ContentAlignment.MiddleLeft;
                button3.TextAlign = ContentAlignment.MiddleLeft;
            }
            else
            {
                button2.Text = "버튼1";
                button3.Text = "버튼2";
                checkHide.Text = "<";
                button2.TextAlign = ContentAlignment.MiddleCenter;
                button3.TextAlign = ContentAlignment.MiddleCenter;
            }

            sliderTimer.Start();
        }

        private void sliderTimer_Tick(object sender, EventArgs e)
        {
            if (checkHide.Checked == true)
            {
                _posSliding -= STEP_SLIDING;
                if(_posSliding <= MIN_SLIDING_WIDTH)
                    sliderTimer.Stop();
            }
            else
            {
                _posSliding += STEP_SLIDING;
                if(_posSliding >= MAX_SLIDING_WIDTH)
                    sliderTimer.Stop();
            }

            sliderPanel.Width = _posSliding;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
            capture.Read(frame);
            try
            {
                string save_name = DateTime.Now.ToString("yyMMddhhmmss");
                Cv2.ImWrite("C:/capture/" + save_name + ".png", frame);
            }
            catch
            { 

            }              
        }

        
        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            Mat frame = new Mat();


            while (true)
            {
                if (capture.IsOpened() == true)
                {
                    capture.Read(frame);
                    Cv2.ImShow("VideoFrame", frame);
                    if (Cv2.WaitKey(1) == 27) break;
                }
            }
            //Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            //Result result = barcodeReader.Decode(frame.ToImage<Bgr, byte>());

            capture.Release();
            Cv2.DestroyAllWindows();
        }

    }
}
