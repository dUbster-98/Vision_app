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
using ZXing;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics.Tracing;

namespace Vision_app
{
    public partial class Form1 : Form
    {

        static string VideoFrame = "VideoFrame";
        static BarcodeReader barcodeReader = new BarcodeReader();

        public Form1()
        {
            InitializeComponent();
            //Cam_init();
        }

        private void Cam_init()
        {

            VideoCapture videoCapture = new VideoCapture(0);
            Mat frame = new Mat();

            videoCapture.Set(VideoCaptureProperties.FrameWidth, 640);
            videoCapture.Set(VideoCaptureProperties.FrameHeight, 480);

            while (true)
            {
                if (videoCapture.IsOpened() == true)
                {
                    videoCapture.Read(frame);
                    Cv2.ImShow("VideoFrame", frame);
                    if (Cv2.WaitKey(1) == 27) break;
                }
            }
            //Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            //Result result = barcodeReader.Decode(frame.ToImage<Bgr, byte>());

            videoCapture.Release();
            Cv2.DestroyAllWindows();
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            string imagePath = "C:/QRCode.png";         
            pictureBox2.Load(imagePath);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;

            Bitmap qrCodeImage = new Bitmap(imagePath);
            Result barcodeResult = barcodeReader.Decode(qrCodeImage);

            // 바코드 결과 출력
            if (barcodeResult != null)
            {
                ResultPoint[] border = barcodeResult.ResultPoints;
                Rectangle rect = new Rectangle((int)border[0].X, (int)border[0].Y, (int)(border[2].X - border[0].X), (int)(border[2].Y - border[0].Y));
                using (Graphics graphics= Graphics.FromImage(qrCodeImage))
                {
                    Pen pen = new Pen(Color.Red,2);
                    graphics.DrawRectangle(pen, rect);
                }

                textBox1.Text = "QR 코드 내용: " + barcodeResult.Text;
            }
            else
            {
                textBox1.Text = "QR 코드를 읽어올 수 없습니다.";
            }
            qrCodeImage.Dispose();
        }

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {

        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
