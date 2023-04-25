using System;
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
using System.Security.Cryptography;

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
            tabControl1.ItemSize = new System.Drawing.Size(0, 1);
            tabControl1.SelectedIndex = 0;
            
            capture.Open(0, VideoCaptureAPIs.ANY);

            if (!capture.IsOpened())
            {
                Close();
                return;
            }

            ClientSize = new System.Drawing.Size(capture.FrameWidth, capture.FrameHeight);

            backgroundWorker1.RunWorkerAsync();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            capture.Dispose();
            backgroundWorker1.CancelAsync();
            backgroundWorker2.CancelAsync();
            backgroundWorker3.CancelAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var bgWorker = (BackgroundWorker)sender;

            while (!bgWorker.CancellationPending)
            {
                using (var frameMat = capture.RetrieveMat())  // using으로 해당 리소스 범위를 벗어나면 자동으로 리소스를 해제해줌
                                                              // 비디오 프레임을 캡처한다
                {
                    var frameBitmap = BitmapConverter.ToBitmap(frameMat);
                    bgWorker.ReportProgress(0, frameBitmap);         // ProgressChanged 이벤트를 발생시킨다
                }
                Thread.Sleep(33); // 1초에 10번 갱신, fps 10
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e) // UI와 통신하는 이벤트
        {                      
            var frameBitmap = (Bitmap)e.UserState;          // UserState로 프레임을 받아온다
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

                currentImage.Image = dst.ToBitmap();

                textBox1.Text = "QR 코드 내용: " + barcodeResult.Text;
                src.Dispose();
            }
            else
            {
                
            }
            
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            var bgWorker = (BackgroundWorker)sender;

            while (!bgWorker.CancellationPending)
            {
                using (var frameMat = capture.RetrieveMat())
                {
                    var frameBitmap = frameMat.ToBitmap();
                    bgWorker.ReportProgress(0, frameBitmap);
                }
                Thread.Sleep(33);
            }
        }

        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var frameBitmap = (Bitmap)e.UserState;
            edgeDetect.Image?.Dispose();

            Mat src = frameBitmap.ToMat();
            Mat dst = src.Clone();
            Cv2.Flip(src, src, FlipMode.Y);

            Mat target = new Mat();
            OpenCvSharp.Point[][] contours;
            HierarchyIndex[] hierarchy;

            Mat element = Cv2.GetStructuringElement(MorphShapes.Rect, new OpenCvSharp.Size(3,3));

            Cv2.CvtColor(src, dst, ColorConversionCodes.BGR2GRAY);
            Cv2.Threshold(dst, dst, 230, 255, ThresholdTypes.Binary);
            Cv2.MorphologyEx(dst, dst, MorphTypes.Close, element, new OpenCvSharp.Point(-1, -1), 2);
            Cv2.BitwiseNot(dst, dst);

            Cv2.FindContours(dst, out contours, out hierarchy, RetrievalModes.Tree, ContourApproximationModes.ApproxTC89KCOS);
            Cv2.DrawContours(src, contours, -1, new Scalar(0, 0, 255), 2, LineTypes.AntiAlias, hierarchy, 3);

            /*
            for (int i = 0; i < contours.Length; i++)
            {
                for (int j = 0; j < contours[i].Length; j++)
                {
                    Cv2.Circle(src, contours[i][j], 1, new Scalar(0, 0, 255), 3);
                }
            }
            */

            edgeDetect.Image = src.ToBitmap();
 
        }

        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {
            var bgWorker = (BackgroundWorker)sender;

            while (!bgWorker.CancellationPending)
            {
                using (var frameMat = capture.RetrieveMat())
                {
                    var frameBitmap = BitmapConverter.ToBitmap(frameMat);
                    bgWorker.ReportProgress(0, frameBitmap);
                }
                Thread.Sleep(33);
            }
        }

        private void backgroundWorker3_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void checkHide_CheckedChanged(object sender, EventArgs e)
        {
            if (checkHide.Checked == true)
            {
                QR1.Text = " QR";
                ED1.Text = " ED";
                PM1.Text = " PM";
                checkHide.Text = ">";
                QR1.TextAlign = ContentAlignment.MiddleLeft;
                ED1.TextAlign = ContentAlignment.MiddleLeft;
                PM1.TextAlign = ContentAlignment.MiddleLeft;
            }
            else
            {
                QR1.Text = "QRCode Reading";
                ED1.Text = "Edge Detecting";
                PM1.Text = "Pattern Matching";
                checkHide.Text = "<";
                QR1.TextAlign = ContentAlignment.MiddleCenter;
                ED1.TextAlign = ContentAlignment.MiddleCenter;
                PM1.TextAlign = ContentAlignment.MiddleCenter;
            }

            sliderTimer.Start();
        }

        private void checkHide2_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkHide2.Checked == true)
            {
                QR2.Text = " QR";
                ED2.Text = " ED";
                PM2.Text = " PM";
                checkHide2.Text = ">";
                QR2.TextAlign = ContentAlignment.MiddleLeft;
                ED2.TextAlign = ContentAlignment.MiddleLeft;
                PM2.TextAlign = ContentAlignment.MiddleLeft;
            }
            else
            {
                QR2.Text = "QRCode Reading";
                ED2.Text = "Edge Detecting";
                PM2.Text = "Pattern Matching";
                checkHide2.Text = "<";
                QR2.TextAlign = ContentAlignment.MiddleCenter;
                ED2.TextAlign = ContentAlignment.MiddleCenter;
                PM2.TextAlign = ContentAlignment.MiddleCenter;
            }

            sliderTimer2.Start();
        }

        private void checkHide3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkHide3.Checked == true)
            {
                QR3.Text = " QR";
                ED3.Text = " ED";
                PM3.Text = " PM";
                checkHide3.Text = ">";
                QR3.TextAlign = ContentAlignment.MiddleLeft;
                ED3.TextAlign = ContentAlignment.MiddleLeft;
                PM3.TextAlign = ContentAlignment.MiddleLeft;
            }
            else
            {
                QR3.Text = "QRCode Reading";
                ED3.Text = "Edge Detecting";
                PM3.Text = "Pattern Matching";
                checkHide3.Text = "<";
                QR3.TextAlign = ContentAlignment.MiddleCenter;
                ED3.TextAlign = ContentAlignment.MiddleCenter;
                PM3.TextAlign = ContentAlignment.MiddleCenter;
            }

            slderTimer3.Start();
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

        private void sliderTimer2_Tick(object sender, EventArgs e)
        {
            if (checkHide2.Checked == true)
            {
                _posSliding -= STEP_SLIDING;
                if (_posSliding <= MIN_SLIDING_WIDTH)
                    sliderTimer2.Stop();
            }
            else
            {
                _posSliding += STEP_SLIDING;
                if (_posSliding >= MAX_SLIDING_WIDTH)
                    sliderTimer2.Stop();
            }

            sliderPanel2.Width = _posSliding;
        }

        private void slderTimer3_Tick(object sender, EventArgs e)
        {
            if (checkHide3.Checked == true)
            {
                _posSliding -= STEP_SLIDING;
                if (_posSliding <= MIN_SLIDING_WIDTH)
                    slderTimer3.Stop();
            }
            else
            {
                _posSliding += STEP_SLIDING;
                if (_posSliding >= MAX_SLIDING_WIDTH)
                    slderTimer3.Stop();
            }

            sliderPanel3.Width = _posSliding;
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

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;

            try
            {
                backgroundWorker1.RunWorkerAsync();
                backgroundWorker2.CancelAsync();
                backgroundWorker3.CancelAsync();
            }
            catch { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;

            try
            {
                backgroundWorker2.RunWorkerAsync();
                backgroundWorker1.CancelAsync();
                backgroundWorker3.CancelAsync();
            }
            catch { }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;

            try
            {
                backgroundWorker3.RunWorkerAsync();
                backgroundWorker1.CancelAsync();
                backgroundWorker2.CancelAsync();
            }
            catch { }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;

            try
            {
                backgroundWorker1.RunWorkerAsync();  // 스레드로 비동기 백그라운드를 실행
                backgroundWorker2.CancelAsync();
                backgroundWorker3.CancelAsync();
            }
            catch { }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;

            try
            {
                backgroundWorker2.RunWorkerAsync();
                backgroundWorker1.CancelAsync();
                backgroundWorker3.CancelAsync();
            }
            catch { }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;

            try
            {
                backgroundWorker3.RunWorkerAsync();
                backgroundWorker1.CancelAsync();
                backgroundWorker2.CancelAsync();
            }
            catch { }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;

            try
            {
                backgroundWorker1.RunWorkerAsync();
                backgroundWorker2.CancelAsync();
                backgroundWorker3.CancelAsync();
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;

            try
            {
                backgroundWorker2.RunWorkerAsync();
                backgroundWorker1.CancelAsync();
                backgroundWorker3.CancelAsync();
            }
            catch { }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;

            try
            {
                backgroundWorker3.RunWorkerAsync();
                backgroundWorker1.CancelAsync();
                backgroundWorker2.CancelAsync();
            }
            catch { }
        }

    }

}
