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
using OpenCvSharp.XPhoto;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Vision_app
{
    public partial class Form1 : Form
    {
        VideoCapture capture = new VideoCapture();
        Mat frame = new Mat();
        static BarcodeReader barcodeReader = new BarcodeReader();

        static string upload_file = string.Empty;

        //슬라이딩 메뉴의 최대, 최소 폭 크기
        const int MAX_SLIDING_WIDTH = 200;
        const int MIN_SLIDING_WIDTH = 50;
        //슬라이딩 메뉴가 보이는/접히는 속도 조절
        const int STEP_SLIDING = 10;
        //최초 슬라이딩 메뉴 크기
        int _posSliding = 200;

        private System.Drawing.Point LastPoint;
        private double ratio = 1.0F;
        private System.Drawing.Point imgPoint;
        private Rectangle imgRect;
        private System.Drawing.Point clickPoint;


        public Form1()
        {
            InitializeComponent();
            comparedImg.MouseWheel += new MouseEventHandler(comparedImg_MouseWheel);
            comparedImg.SizeMode = PictureBoxSizeMode.StretchImage;

            // VICapturedImg = new Bitmap(@"E:\01.bmp");
            imgPoint = new System.Drawing.Point(comparedImg.Width / 2, comparedImg.Height / 2);
            imgRect = new Rectangle(0, 0, comparedImg.Width, comparedImg.Height);
            ratio = 1.0;
            clickPoint = imgPoint;

            comparedImg.Invalidate();

        }
        private static Bitmap ApplyConvolutionFilter(
            Bitmap sourceBitmap,
            double[,] filterArray,
            double factor = 1,
            int bias = 0,
            bool grayscale = false
        )
        {
            BitmapData sourceBitmapData = sourceBitmap.LockBits
            (
                new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height),
                ImageLockMode.ReadOnly,
                PixelFormat.Format32bppArgb
            );

            byte[] sourceByteArray = new byte[sourceBitmapData.Stride * sourceBitmapData.Height];
            byte[] targetByteArray = new byte[sourceBitmapData.Stride * sourceBitmapData.Height];

            Marshal.Copy(sourceBitmapData.Scan0, sourceByteArray, 0, sourceByteArray.Length);

            sourceBitmap.UnlockBits(sourceBitmapData);

            if (grayscale == true)
            {
                float rgb = 0;

                for (int k = 0; k < sourceByteArray.Length; k += 4)
                {
                    rgb = sourceByteArray[k] * 0.11f;
                    rgb += sourceByteArray[k + 1] * 0.59f;
                    rgb += sourceByteArray[k + 2] * 0.3f;

                    sourceByteArray[k] = (byte)rgb;
                    sourceByteArray[k + 1] = sourceByteArray[k];
                    sourceByteArray[k + 2] = sourceByteArray[k];
                    sourceByteArray[k + 3] = 255;
                }
            }

            double blue = 0.0;
            double green = 0.0;
            double red = 0.0;

            int filterWidth = filterArray.GetLength(1);
            int filterHeight = filterArray.GetLength(0);

            int filterOffset = (filterWidth - 1) / 2;
            int sourceOffset = 0;
            int targetOffset = 0;

            for (int offsetY = filterOffset; offsetY < sourceBitmap.Height - filterOffset; offsetY++)
            {
                for (int offsetX = filterOffset; offsetX < sourceBitmap.Width - filterOffset; offsetX++)
                {
                    blue = 0;
                    green = 0;
                    red = 0;

                    targetOffset = offsetY * sourceBitmapData.Stride + offsetX * 4;

                    for (int filterY = -filterOffset; filterY <= filterOffset; filterY++)
                    {
                        for (int filterX = -filterOffset; filterX <= filterOffset; filterX++)
                        {
                            sourceOffset = targetOffset + (filterX * 4) + (filterY * sourceBitmapData.Stride);

                            blue += (double)(sourceByteArray[sourceOffset]) *
                                     filterArray[filterY + filterOffset, filterX + filterOffset];

                            green += (double)(sourceByteArray[sourceOffset + 1]) *
                                     filterArray[filterY + filterOffset, filterX + filterOffset];

                            red += (double)(sourceByteArray[sourceOffset + 2]) *
                                     filterArray[filterY + filterOffset, filterX + filterOffset];
                        }
                    }

                    blue = factor * blue + bias;
                    green = factor * green + bias;
                    red = factor * red + bias;

                    if (blue > 255)
                    {
                        blue = 255;
                    }
                    else if (blue < 0)
                    {
                        blue = 0;
                    }

                    if (green > 255)
                    {
                        green = 255;
                    }
                    else if (green < 0)
                    {
                        green = 0;
                    }

                    if (red > 255)
                    {
                        red = 255;
                    }
                    else if (red < 0)
                    {
                        red = 0;
                    }

                    targetByteArray[targetOffset] = (byte)blue;
                    targetByteArray[targetOffset + 1] = (byte)green;
                    targetByteArray[targetOffset + 2] = (byte)red;
                    targetByteArray[targetOffset + 3] = 255;
                }
            }

            Bitmap targetBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);

            BitmapData targetBitmapData = targetBitmap.LockBits
            (
                new Rectangle(0, 0, targetBitmap.Width, targetBitmap.Height),
                ImageLockMode.WriteOnly,
                PixelFormat.Format32bppArgb
            );

            Marshal.Copy(targetByteArray, 0, targetBitmapData.Scan0, targetByteArray.Length);

            targetBitmap.UnlockBits(targetBitmapData);

            return targetBitmap;
        }
        public static double[,] kernelMatrix
        {
            get
            {
                return new double[,]
                {
                    { -1, -1, -1, -1, -1 },
                    { -1, -1, -1, -1, -1 },
                    { -1, -1, 24, -1, -1 },
                    { -1, -1, -1, -1, -1 },
                    { -1, -1, -1, -1, -1 }
                };
            }
        }
        public static Bitmap ApplyRGBLaplacian(Bitmap bmpData)
        {
            Bitmap targetBitmap = ApplyConvolutionFilter
            (
                bmpData,
                kernelMatrix,
                1.0,
                0,
                true
            );

            return targetBitmap;
        }


        public static Bitmap ApplyBinaryLaplaceFilter(Bitmap bmpData)
        {
            int[,] kernelMatrix = new int[3, 3]  { { 0, 1, 0 },
                                                { 1, -4, 1 },
                                                {0, 1, 0} };

            int width = bmpData.Width;
            int height = bmpData.Height;
            Bitmap copiedImage = new Bitmap(bmpData.Width, bmpData.Height, PixelFormat.Format8bppIndexed);
            BitmapData LockedImage = bmpData.LockBits(new Rectangle(0, 0, bmpData.Width, bmpData.Height), ImageLockMode.ReadOnly, PixelFormat.Format8bppIndexed);
            BitmapData DestData = copiedImage.LockBits(new Rectangle(0, 0, copiedImage.Width, copiedImage.Height), ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);

            int size = 3;
            int radius = size / 2;

            int gray = 0;


            unsafe
            {
                var ptr = (byte*)LockedImage.Scan0;
                var cptr = (byte*)DestData.Scan0;

                Parallel.For(0, height, (int row) =>
                {
                    byte* tempPtr = (byte*)DestData.Scan0 + row * DestData.Stride;
                    for (int col = 0; col < width; col++)
                    {

                        cptr[col] = 0;
                    }
                });

                Parallel.For(1, height - 1, (int row) =>
                {
                    for (int col = 1; col < width - 1; col++)
                    {
                        gray = *(ptr + row * DestData.Stride + col - 1) + *(ptr + (row - 1) * DestData.Stride + col) -
                            4 * (*(ptr + DestData.Stride * row + col)) + *(ptr + (row + 1) * DestData.Stride + col) + *(ptr + row * DestData.Stride + col + 1); //bytes[i, j - 1] + bytes[i - 1, j] - 4 * bytes[i, j] + bytes[i + 1, j] + bytes[i, j + 1];
                        gray += 128;
                        if (gray > 158)
                        {
                            gray = 0;
                        }
                        else
                        {
                            gray = 255;
                        }
                        *(cptr + row * DestData.Stride + col) = (byte)gray;//result[i*width + j] = (byte)gray;
                    }
                });
            }

            bmpData.UnlockBits(LockedImage);
            copiedImage.UnlockBits(DestData);

            return copiedImage;
        }

        private void comparedImg_MouseWheel(object sender, MouseEventArgs e)
        {
            int lines = e.Delta * SystemInformation.MouseWheelScrollLines / 120;
            PictureBox pb = (PictureBox)sender;

            if (lines > 0)
            {
                ratio *= 1.1F;
                if (ratio > 100.0) ratio = 100.0f;

                imgRect.Width = (int)Math.Round(comparedImg.Width * ratio);
                imgRect.Height = (int)Math.Round(comparedImg.Height * ratio);
                imgRect.X = -(int)Math.Round(1.1F * (imgPoint.X - imgRect.X) - imgPoint.X);
                imgRect.Y = -(int)Math.Round(1.1F * (imgPoint.Y - imgRect.Y) - imgPoint.Y);
            }
            else if (lines < 0)
            {
                ratio *= 0.9F;
                if (ratio < 1) ratio = 1;

                imgRect.Width = (int)Math.Round(comparedImg.Width * ratio);
                imgRect.Height = (int)Math.Round(comparedImg.Height * ratio);
                imgRect.X = -(int)Math.Round(0.9F * (imgPoint.X - imgRect.X) - imgPoint.X);
                imgRect.Y = -(int)Math.Round(0.9F * (imgPoint.Y - imgRect.Y) - imgPoint.Y);
            }

            if (imgRect.X > 0) imgRect.X = 0;             // 범위지정
            if (imgRect.Y > 0) imgRect.Y = 0;
            if (imgRect.X + imgRect.Width < comparedImg.Width) imgRect.X = comparedImg.Width - imgRect.Width;
            if (imgRect.Y + imgRect.Height < comparedImg.Height) imgRect.Y = comparedImg.Height - imgRect.Height;

            comparedImg.Invalidate();  // Paint 이벤트가 일어날 때 처리해서 이미지를 갱신
        }
        
        private void comparedImg_Paint(object sender, PaintEventArgs e)
        {
            if (comparedImg.Image != null)
            {
                e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

                e.Graphics.DrawImage(comparedImg.Image, imgRect);   // 새로 이미지를 그린다
                comparedImg.Focus();
            }
        }

        private void comparedImg_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                clickPoint = new System.Drawing.Point(e.X, e.Y);
            }
            comparedImg.Invalidate();
        }

        private void comparedImg_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                imgRect.X = imgRect.X + (int)Math.Round((double)(e.X - clickPoint.X) / 5);
                if (imgRect.X >= 0) imgRect.X = 0;
                if (Math.Abs(imgRect.X) >= Math.Abs(imgRect.Width - comparedImg.Width)) imgRect.X = -(imgRect.Width - comparedImg.Width);
                imgRect.Y = imgRect.Y + (int)Math.Round((double)(e.Y - clickPoint.Y) / 5);
                if (imgRect.Y >= 0) imgRect.Y = 0;
                if (Math.Abs(imgRect.Y) >= Math.Abs(imgRect.Height - comparedImg.Height)) imgRect.Y = -(imgRect.Height - comparedImg.Height);
            }
            else
            {
                LastPoint = e.Location;
            }

            comparedImg.Invalidate();
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
                using (var frameMat = capture.RetrieveMat())
                {
                    var frameBitmap = BitmapConverter.ToBitmap(frameMat);
                    bgWorker.ReportProgress(0, frameBitmap);

                }

                Thread.Sleep(33);
            }
        }
        /*
         private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
         {
             var bgWorker = (BackgroundWorker)sender;

             while (!bgWorker.CancellationPending)
             {
                 using (var frameMat = capture3.RetrieveMat())  // using으로 해당 리소스 범위를 벗어나면 자동으로 리소스를 해제해줌
                                                                // 비디오 프레임을 캡처한다
                 {
                     var frameBitmap = BitmapConverter.ToBitmap(frameMat);
                     bgWorker.ReportProgress(0, frameBitmap);         // ProgressChanged 이벤트를 발생시킨다
                 }

                 Thread.Sleep(33); // 1초에 30번 갱신, fps 30
             }
         }
        */

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
            }
            else
            {
                
            }
            
        }

        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var frameBitmap = (Bitmap)e.UserState;
            edgeDetect.Image?.Dispose();

            Mat src = frameBitmap.ToMat();


            //Bitmap bitmap1 = ApplyBinaryLaplaceFilter(frameBitmap);

            
            Mat dst = src.Clone();
            Cv2.Flip(src, src, FlipMode.Y);

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

        private void backgroundWorker3_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var frameBitmap = (Bitmap)e.UserState;
            compareImg.Image?.Dispose();
            
            Mat src = frameBitmap.ToMat();
            Mat gray = new Mat();
            
            Cv2.CvtColor(src, gray, ColorConversionCodes.BGR2GRAY);
            
            compareImg.Image = gray.ToBitmap();

        }

        private void VIStart_Click(object sender, EventArgs e)
        {

            capture.Read(frame);                     // 현재 화면 저장

            Mat src = Cv2.ImRead(upload_file);
            Cv2.CvtColor(src, src, ColorConversionCodes.BGR2GRAY);

            Mat target = new Mat();
            Cv2.CvtColor(frame, target, ColorConversionCodes.BGR2GRAY); // 현재 화면 캡처 후 그레이화
            
            ORB orb = ORB.Create(nFeatures: 40000, scaleFactor: 1.2f, nLevels: 8, edgeThreshold: 31, 
                                 firstLevel: 0, wtaK: 2, scoreType: ORBScoreType.Harris, patchSize: 31, fastThreshold: 20);

            KeyPoint[] kp1, kp2;
            Mat des1 = new Mat();
            Mat des2 = new Mat();

            orb.DetectAndCompute(src, null, out kp1, des1);
            orb.DetectAndCompute(target, null, out kp2, des2);

            BFMatcher bf = new BFMatcher(NormTypes.Hamming, crossCheck: true);
            DMatch[] matches = bf.Match(des1, des2);
            Array.Sort(matches, (x, y) => x.Distance.CompareTo(y.Distance));
            DMatch[] topMatches = matches.Take(100).ToArray();

            /*
            for (int i = 0; i < 100; i++)
            {
                int idx = matches[i].QueryIdx;
                Point2f pt = kp1[idx].Pt;
                Cv2.Circle(src, (int)pt.X, (int)pt.Y, 3, Scalar.Blue, 3);
            }

            for (int i = 0; i < 100; i++)
            {
                int idx = matches[i].QueryIdx;
                Point2f pt = kp2[idx].Pt;
                Cv2.Circle(target, (int)pt.X, (int)pt.Y, 3, Scalar.Blue, 3);
            }
            */
            
            List<Point2f> srcPoints = new List<Point2f>();
            List<Point2f> dstPoints = new List<Point2f>();

            for (int i = 0; i < topMatches.Length; i++)
            {
                srcPoints.Add(kp1[topMatches[i].QueryIdx].Pt);
                dstPoints.Add(kp2[topMatches[i].TrainIdx].Pt);
            }

            KeyPoint[] topKeypoints1 = kp1.OrderByDescending(kp => kp.Response).Take(100).ToArray();
            KeyPoint[] topKeypoints2 = kp2.OrderByDescending(kp => kp.Response).Take(100).ToArray();

            Mat result1 = new Mat();
            Mat result2 = new Mat();

            Cv2.DrawKeypoints(src, topKeypoints1, result1, new Scalar(0, 0, 255), DrawMatchesFlags.Default);
            Cv2.DrawKeypoints(target, topKeypoints2, result2, new Scalar(0, 0, 255), DrawMatchesFlags.Default);
            

            // 유사도를 계산
            double sumofDistance = 0.0;        
            for (int i = 0; i <topMatches.Length; i++)
            {
                sumofDistance += topMatches[i].Distance;
            }
            double meanDistance = sumofDistance / topMatches.Length;

            double similarity = 1.0 / meanDistance;

            masterImg.Image = result1.ToBitmap();
            comparedImg.Image = result2.ToBitmap();
            VIResult.Text = similarity.ToString();

            Thread.Sleep(1000);
            
        }

        private void checkHide_CheckedChanged(object sender, EventArgs e)
        {
            if (checkHide.Checked == true)
            {
                QR1.Text = " QR";
                ED1.Text = " ED";
                PM1.Text = " PM";
                EF1.Text = " EF";
                checkHide.Text = ">";
                QR1.TextAlign = ContentAlignment.MiddleLeft;
                ED1.TextAlign = ContentAlignment.MiddleLeft;
                PM1.TextAlign = ContentAlignment.MiddleLeft;
                EF1.TextAlign = ContentAlignment.MiddleLeft;
            }
            else
            {
                QR1.Text = "QRCode Reading";
                ED1.Text = "Edge Detecting";
                PM1.Text = "Pattern Matching";
                EF1.Text = "Edge Finder";
                checkHide.Text = "<";
                QR1.TextAlign = ContentAlignment.MiddleCenter;
                ED1.TextAlign = ContentAlignment.MiddleCenter;
                PM1.TextAlign = ContentAlignment.MiddleCenter;
                EF1.TextAlign = ContentAlignment.MiddleCenter;
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
                EF2.Text = " EF";
                checkHide2.Text = ">";
                QR2.TextAlign = ContentAlignment.MiddleLeft;
                ED2.TextAlign = ContentAlignment.MiddleLeft;
                PM2.TextAlign = ContentAlignment.MiddleLeft;
                EF2.TextAlign = ContentAlignment.MiddleLeft;
            }
            else
            {
                QR2.Text = "QRCode Reading";
                ED2.Text = "Edge Detecting";
                PM2.Text = "Pattern Matching";
                EF2.Text = "Edge Finder";
                checkHide2.Text = "<";
                QR2.TextAlign = ContentAlignment.MiddleCenter;
                ED2.TextAlign = ContentAlignment.MiddleCenter;
                PM2.TextAlign = ContentAlignment.MiddleCenter;
                EF2.TextAlign = ContentAlignment.MiddleCenter;
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
                EF3.Text = " EF";
                checkHide3.Text = ">";
                QR3.TextAlign = ContentAlignment.MiddleLeft;
                ED3.TextAlign = ContentAlignment.MiddleLeft;
                PM3.TextAlign = ContentAlignment.MiddleLeft;
                EF3.TextAlign = ContentAlignment.MiddleLeft;
            }
            else
            {
                QR3.Text = "QRCode Reading";
                ED3.Text = "Edge Detecting";
                PM3.Text = "Pattern Matching";
                EF3.Text = "Edge Finder";
                checkHide3.Text = "<";
                QR3.TextAlign = ContentAlignment.MiddleCenter;
                ED3.TextAlign = ContentAlignment.MiddleCenter;
                PM3.TextAlign = ContentAlignment.MiddleCenter;
                EF3.TextAlign = ContentAlignment.MiddleCenter;
            }
            sliderTimer4.Start();
        }

        private void checkHide4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkHide4.Checked == true)
            {
                button3.Text = " QR";
                button2.Text = " ED";
                button1.Text = " PM";
                EF4.Text = " EF";
                checkHide4.Text = ">";
                button3.TextAlign = ContentAlignment.MiddleLeft;
                button2.TextAlign = ContentAlignment.MiddleLeft;
                button1.TextAlign = ContentAlignment.MiddleLeft;
                EF4.TextAlign = ContentAlignment.MiddleLeft;
            }
            else
            {
                button3.Text = "QRCode Reading";
                button2.Text = "Edge Detecting";
                button1.Text = "Pattern Matching";
                EF4.Text = "Edge Finder";
                checkHide4.Text = "<";
                button3.TextAlign = ContentAlignment.MiddleCenter;
                button2.TextAlign = ContentAlignment.MiddleCenter;
                button1.TextAlign = ContentAlignment.MiddleCenter;
                EF4.TextAlign = ContentAlignment.MiddleCenter;
            }
            sliderTimer5.Start();
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

        private void sliderTimer4_Tick(object sender, EventArgs e)
        {
            if (checkHide3.Checked == true)
            {
                _posSliding -= STEP_SLIDING;
                if (_posSliding <= MIN_SLIDING_WIDTH)
                    sliderTimer4.Stop();
            }
            else
            {
                _posSliding += STEP_SLIDING;
                if (_posSliding >= MAX_SLIDING_WIDTH)
                    sliderTimer4.Stop();
            }

            sliderPanel3.Width = _posSliding;
        }

        private void sliderTimer5_Tick(object sender, EventArgs e)
        {
            if (checkHide4.Checked == true)
            {
                _posSliding -= STEP_SLIDING;
                if (_posSliding <= MIN_SLIDING_WIDTH)
                    sliderTimer5.Stop();
            }
            else
            {
                _posSliding += STEP_SLIDING;
                if (_posSliding >= MAX_SLIDING_WIDTH)
                    sliderTimer5.Stop();
            }

            sliderPanel4.Width = _posSliding;
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

        private void uploadBtn_Click(object sender, EventArgs e)
        {
            upload_file = string.Empty;

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = "C:/";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                upload_file = dialog.FileName;
            }
            else if (dialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            Mat gray = new Mat();
            var bitmapFromFile = Bitmap.FromFile(upload_file);
            Bitmap bitmap1 = new Bitmap(bitmapFromFile);
            Mat src = BitmapConverter.ToMat(bitmap1);

            Cv2.CvtColor(src, gray, ColorConversionCodes.BGR2GRAY);
            masterImg.Image = gray.ToBitmap();
            masterImg.SizeMode = PictureBoxSizeMode.StretchImage;

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            string upload_file1 = string.Empty;

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = "C:/";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                upload_file1 = dialog.FileName;
            }
            else if (dialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            Mat gray = new Mat();
            var bitmapFromFile = Bitmap.FromFile(upload_file1);
            Bitmap bitmap1 = new Bitmap(bitmapFromFile);

            pictureBox1.Image = ApplyBinaryLaplaceFilter(bitmap1);
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

        private void QR3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;

            try
            {
                backgroundWorker1.RunWorkerAsync();
                backgroundWorker2.CancelAsync();
                backgroundWorker3.CancelAsync();        
            } catch { }
        }

        private void ED3_Click(object sender, EventArgs e)
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

        private void EF1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 3;

            try
            {
                backgroundWorker1.CancelAsync();
            }
            catch { }
        }

        private void EF2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 3;
            try
            {
                backgroundWorker2.CancelAsync();
            }
            catch { }
        }

        private void EF3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 3;
            try
            {
                backgroundWorker3.CancelAsync();
            }
            catch { }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;

            try
            {
                backgroundWorker1.RunWorkerAsync();
            }
            catch { }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;

            try
            {
                backgroundWorker2.RunWorkerAsync();
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
                
            try
            {
                backgroundWorker3.RunWorkerAsync();
            }
            catch { }
        }

    }

}
