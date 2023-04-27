namespace Vision_app
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.currentImage = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonCapture = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.sliderTimer3 = new System.Windows.Forms.TabPage();
            this.capturedImg = new System.Windows.Forms.Label();
            this.capturedImage = new System.Windows.Forms.PictureBox();
            this.sliderPanel = new System.Windows.Forms.Panel();
            this.PM1 = new System.Windows.Forms.Button();
            this.checkHide = new System.Windows.Forms.CheckBox();
            this.ED1 = new System.Windows.Forms.Button();
            this.QR1 = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.edgeDetect = new System.Windows.Forms.PictureBox();
            this.sliderPanel2 = new System.Windows.Forms.Panel();
            this.PM2 = new System.Windows.Forms.Button();
            this.checkHide2 = new System.Windows.Forms.CheckBox();
            this.ED2 = new System.Windows.Forms.Button();
            this.QR2 = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.uploadBtn = new System.Windows.Forms.Button();
            this.VIResult = new System.Windows.Forms.TextBox();
            this.VIStart = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comparedImg = new System.Windows.Forms.PictureBox();
            this.masterImg = new System.Windows.Forms.PictureBox();
            this.sliderPanel3 = new System.Windows.Forms.Panel();
            this.PM3 = new System.Windows.Forms.Button();
            this.ED3 = new System.Windows.Forms.Button();
            this.QR3 = new System.Windows.Forms.Button();
            this.checkHide3 = new System.Windows.Forms.CheckBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.sliderTimer = new System.Windows.Forms.Timer(this.components);
            this.sliderTimer2 = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker3 = new System.ComponentModel.BackgroundWorker();
            this.sliderTimer4 = new System.Windows.Forms.Timer(this.components);
            this.compareImg = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.currentImage)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.sliderTimer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.capturedImage)).BeginInit();
            this.sliderPanel.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edgeDetect)).BeginInit();
            this.sliderPanel2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comparedImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.masterImg)).BeginInit();
            this.sliderPanel3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.compareImg)).BeginInit();
            this.SuspendLayout();
            // 
            // currentImage
            // 
            this.currentImage.Location = new System.Drawing.Point(586, 71);
            this.currentImage.Name = "currentImage";
            this.currentImage.Size = new System.Drawing.Size(640, 480);
            this.currentImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.currentImage.TabIndex = 1;
            this.currentImage.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(248, 458);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(255, 21);
            this.textBox1.TabIndex = 2;
            // 
            // buttonCapture
            // 
            this.buttonCapture.Location = new System.Drawing.Point(249, 519);
            this.buttonCapture.Name = "buttonCapture";
            this.buttonCapture.Size = new System.Drawing.Size(187, 33);
            this.buttonCapture.TabIndex = 3;
            this.buttonCapture.Text = "저장하기!";
            this.buttonCapture.UseVisualStyleBackColor = true;
            this.buttonCapture.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.sliderTimer3);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.ItemSize = new System.Drawing.Size(60, 20);
            this.tabControl1.Location = new System.Drawing.Point(0, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1264, 683);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 4;
            // 
            // sliderTimer3
            // 
            this.sliderTimer3.Controls.Add(this.capturedImg);
            this.sliderTimer3.Controls.Add(this.capturedImage);
            this.sliderTimer3.Controls.Add(this.sliderPanel);
            this.sliderTimer3.Controls.Add(this.currentImage);
            this.sliderTimer3.Controls.Add(this.buttonCapture);
            this.sliderTimer3.Controls.Add(this.textBox1);
            this.sliderTimer3.Location = new System.Drawing.Point(4, 24);
            this.sliderTimer3.Name = "sliderTimer3";
            this.sliderTimer3.Padding = new System.Windows.Forms.Padding(3);
            this.sliderTimer3.Size = new System.Drawing.Size(1256, 655);
            this.sliderTimer3.TabIndex = 1;
            this.sliderTimer3.Text = "QRPage";
            this.sliderTimer3.UseVisualStyleBackColor = true;
            // 
            // capturedImg
            // 
            this.capturedImg.AutoSize = true;
            this.capturedImg.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.capturedImg.Location = new System.Drawing.Point(246, 71);
            this.capturedImg.Name = "capturedImg";
            this.capturedImg.Size = new System.Drawing.Size(115, 16);
            this.capturedImg.TabIndex = 9;
            this.capturedImg.Text = "캡처된 이미지";
            // 
            // capturedImage
            // 
            this.capturedImage.Location = new System.Drawing.Point(248, 102);
            this.capturedImage.Name = "capturedImage";
            this.capturedImage.Size = new System.Drawing.Size(320, 320);
            this.capturedImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.capturedImage.TabIndex = 8;
            this.capturedImage.TabStop = false;
            // 
            // sliderPanel
            // 
            this.sliderPanel.BackColor = System.Drawing.Color.Gray;
            this.sliderPanel.Controls.Add(this.PM1);
            this.sliderPanel.Controls.Add(this.checkHide);
            this.sliderPanel.Controls.Add(this.ED1);
            this.sliderPanel.Controls.Add(this.QR1);
            this.sliderPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sliderPanel.Location = new System.Drawing.Point(3, 3);
            this.sliderPanel.Name = "sliderPanel";
            this.sliderPanel.Size = new System.Drawing.Size(200, 649);
            this.sliderPanel.TabIndex = 7;
            // 
            // PM1
            // 
            this.PM1.BackColor = System.Drawing.Color.Gray;
            this.PM1.FlatAppearance.BorderSize = 0;
            this.PM1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.PM1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.PM1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PM1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.PM1.ForeColor = System.Drawing.Color.White;
            this.PM1.Location = new System.Drawing.Point(0, 272);
            this.PM1.Name = "PM1";
            this.PM1.Size = new System.Drawing.Size(200, 130);
            this.PM1.TabIndex = 15;
            this.PM1.TabStop = false;
            this.PM1.Text = "Pattern Matching";
            this.PM1.UseVisualStyleBackColor = false;
            this.PM1.Click += new System.EventHandler(this.button7_Click);
            // 
            // checkHide
            // 
            this.checkHide.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkHide.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.checkHide.FlatAppearance.BorderSize = 0;
            this.checkHide.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gray;
            this.checkHide.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.checkHide.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.checkHide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkHide.Font = new System.Drawing.Font("굴림", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.checkHide.ForeColor = System.Drawing.Color.White;
            this.checkHide.Location = new System.Drawing.Point(0, 519);
            this.checkHide.Name = "checkHide";
            this.checkHide.Size = new System.Drawing.Size(200, 130);
            this.checkHide.TabIndex = 10;
            this.checkHide.Text = "<";
            this.checkHide.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkHide.UseVisualStyleBackColor = true;
            this.checkHide.CheckedChanged += new System.EventHandler(this.checkHide_CheckedChanged);
            // 
            // ED1
            // 
            this.ED1.BackColor = System.Drawing.Color.Gray;
            this.ED1.FlatAppearance.BorderSize = 0;
            this.ED1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.ED1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.ED1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ED1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ED1.ForeColor = System.Drawing.Color.White;
            this.ED1.Location = new System.Drawing.Point(0, 136);
            this.ED1.Name = "ED1";
            this.ED1.Size = new System.Drawing.Size(200, 130);
            this.ED1.TabIndex = 9;
            this.ED1.TabStop = false;
            this.ED1.Text = "Edge Detecting";
            this.ED1.UseVisualStyleBackColor = false;
            this.ED1.Click += new System.EventHandler(this.button3_Click);
            // 
            // QR1
            // 
            this.QR1.BackColor = System.Drawing.Color.Gray;
            this.QR1.FlatAppearance.BorderSize = 0;
            this.QR1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.QR1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.QR1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.QR1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.QR1.ForeColor = System.Drawing.Color.White;
            this.QR1.Location = new System.Drawing.Point(0, 0);
            this.QR1.Name = "QR1";
            this.QR1.Size = new System.Drawing.Size(200, 130);
            this.QR1.TabIndex = 8;
            this.QR1.TabStop = false;
            this.QR1.Text = "QRCode Reading";
            this.QR1.UseVisualStyleBackColor = false;
            this.QR1.Click += new System.EventHandler(this.button2_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.edgeDetect);
            this.tabPage3.Controls.Add(this.sliderPanel2);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1256, 655);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(405, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 27);
            this.label1.TabIndex = 2;
            this.label1.Text = "Edge Detect";
            // 
            // edgeDetect
            // 
            this.edgeDetect.Location = new System.Drawing.Point(410, 68);
            this.edgeDetect.Name = "edgeDetect";
            this.edgeDetect.Size = new System.Drawing.Size(640, 480);
            this.edgeDetect.TabIndex = 1;
            this.edgeDetect.TabStop = false;
            // 
            // sliderPanel2
            // 
            this.sliderPanel2.BackColor = System.Drawing.Color.Gray;
            this.sliderPanel2.Controls.Add(this.PM2);
            this.sliderPanel2.Controls.Add(this.checkHide2);
            this.sliderPanel2.Controls.Add(this.ED2);
            this.sliderPanel2.Controls.Add(this.QR2);
            this.sliderPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.sliderPanel2.Location = new System.Drawing.Point(3, 3);
            this.sliderPanel2.Name = "sliderPanel2";
            this.sliderPanel2.Size = new System.Drawing.Size(200, 649);
            this.sliderPanel2.TabIndex = 0;
            // 
            // PM2
            // 
            this.PM2.BackColor = System.Drawing.Color.Gray;
            this.PM2.FlatAppearance.BorderSize = 0;
            this.PM2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.PM2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.PM2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PM2.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.PM2.ForeColor = System.Drawing.Color.White;
            this.PM2.Location = new System.Drawing.Point(0, 272);
            this.PM2.Name = "PM2";
            this.PM2.Size = new System.Drawing.Size(200, 130);
            this.PM2.TabIndex = 14;
            this.PM2.TabStop = false;
            this.PM2.Text = "Pattern Matching";
            this.PM2.UseVisualStyleBackColor = false;
            this.PM2.Click += new System.EventHandler(this.button8_Click);
            // 
            // checkHide2
            // 
            this.checkHide2.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkHide2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.checkHide2.FlatAppearance.BorderSize = 0;
            this.checkHide2.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gray;
            this.checkHide2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.checkHide2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.checkHide2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkHide2.Font = new System.Drawing.Font("굴림", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.checkHide2.ForeColor = System.Drawing.Color.White;
            this.checkHide2.Location = new System.Drawing.Point(0, 519);
            this.checkHide2.Name = "checkHide2";
            this.checkHide2.Size = new System.Drawing.Size(200, 130);
            this.checkHide2.TabIndex = 13;
            this.checkHide2.Text = "<";
            this.checkHide2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkHide2.UseVisualStyleBackColor = true;
            this.checkHide2.CheckedChanged += new System.EventHandler(this.checkHide2_CheckedChanged_1);
            // 
            // ED2
            // 
            this.ED2.BackColor = System.Drawing.Color.Gray;
            this.ED2.FlatAppearance.BorderSize = 0;
            this.ED2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.ED2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.ED2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ED2.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ED2.ForeColor = System.Drawing.Color.White;
            this.ED2.Location = new System.Drawing.Point(0, 136);
            this.ED2.Name = "ED2";
            this.ED2.Size = new System.Drawing.Size(200, 130);
            this.ED2.TabIndex = 12;
            this.ED2.TabStop = false;
            this.ED2.Text = "Edge Detecting";
            this.ED2.UseVisualStyleBackColor = false;
            this.ED2.Click += new System.EventHandler(this.button5_Click);
            // 
            // QR2
            // 
            this.QR2.BackColor = System.Drawing.Color.Gray;
            this.QR2.FlatAppearance.BorderSize = 0;
            this.QR2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.QR2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.QR2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.QR2.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.QR2.ForeColor = System.Drawing.Color.White;
            this.QR2.Location = new System.Drawing.Point(0, 0);
            this.QR2.Name = "QR2";
            this.QR2.Size = new System.Drawing.Size(200, 130);
            this.QR2.TabIndex = 11;
            this.QR2.TabStop = false;
            this.QR2.Text = "QRCode Reading";
            this.QR2.UseVisualStyleBackColor = false;
            this.QR2.Click += new System.EventHandler(this.button4_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.compareImg);
            this.tabPage1.Controls.Add(this.uploadBtn);
            this.tabPage1.Controls.Add(this.VIResult);
            this.tabPage1.Controls.Add(this.VIStart);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.comparedImg);
            this.tabPage1.Controls.Add(this.masterImg);
            this.tabPage1.Controls.Add(this.sliderPanel3);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1256, 655);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // uploadBtn
            // 
            this.uploadBtn.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.uploadBtn.Location = new System.Drawing.Point(377, 16);
            this.uploadBtn.Name = "uploadBtn";
            this.uploadBtn.Size = new System.Drawing.Size(94, 23);
            this.uploadBtn.TabIndex = 5;
            this.uploadBtn.Text = "사진 선택";
            this.uploadBtn.UseVisualStyleBackColor = true;
            this.uploadBtn.Click += new System.EventHandler(this.uploadBtn_Click);
            // 
            // VIResult
            // 
            this.VIResult.Location = new System.Drawing.Point(231, 411);
            this.VIResult.Multiline = true;
            this.VIResult.Name = "VIResult";
            this.VIResult.Size = new System.Drawing.Size(318, 103);
            this.VIResult.TabIndex = 5;
            // 
            // VIStart
            // 
            this.VIStart.Location = new System.Drawing.Point(612, 411);
            this.VIStart.Name = "VIStart";
            this.VIStart.Size = new System.Drawing.Size(233, 82);
            this.VIStart.TabIndex = 4;
            this.VIStart.Text = "검사 시작!";
            this.VIStart.UseVisualStyleBackColor = true;
            this.VIStart.Click += new System.EventHandler(this.VIStart_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(228, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Master Image";
            // 
            // comparedImg
            // 
            this.comparedImg.Location = new System.Drawing.Point(747, 45);
            this.comparedImg.Name = "comparedImg";
            this.comparedImg.Size = new System.Drawing.Size(480, 360);
            this.comparedImg.TabIndex = 2;
            this.comparedImg.TabStop = false;
            this.comparedImg.Paint += new System.Windows.Forms.PaintEventHandler(this.comparedImg_Paint);
            this.comparedImg.MouseDown += new System.Windows.Forms.MouseEventHandler(this.comparedImg_MouseDown);
            this.comparedImg.MouseMove += new System.Windows.Forms.MouseEventHandler(this.comparedImg_MouseMove);
            // 
            // masterImg
            // 
            this.masterImg.Location = new System.Drawing.Point(231, 45);
            this.masterImg.Name = "masterImg";
            this.masterImg.Size = new System.Drawing.Size(480, 360);
            this.masterImg.TabIndex = 1;
            this.masterImg.TabStop = false;
            // 
            // sliderPanel3
            // 
            this.sliderPanel3.BackColor = System.Drawing.Color.Gray;
            this.sliderPanel3.Controls.Add(this.PM3);
            this.sliderPanel3.Controls.Add(this.ED3);
            this.sliderPanel3.Controls.Add(this.QR3);
            this.sliderPanel3.Controls.Add(this.checkHide3);
            this.sliderPanel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.sliderPanel3.Location = new System.Drawing.Point(3, 3);
            this.sliderPanel3.Name = "sliderPanel3";
            this.sliderPanel3.Size = new System.Drawing.Size(200, 649);
            this.sliderPanel3.TabIndex = 0;
            // 
            // PM3
            // 
            this.PM3.BackColor = System.Drawing.Color.Gray;
            this.PM3.FlatAppearance.BorderSize = 0;
            this.PM3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.PM3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.PM3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PM3.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.PM3.ForeColor = System.Drawing.Color.White;
            this.PM3.Location = new System.Drawing.Point(0, 272);
            this.PM3.Name = "PM3";
            this.PM3.Size = new System.Drawing.Size(200, 130);
            this.PM3.TabIndex = 19;
            this.PM3.TabStop = false;
            this.PM3.Text = "Pattern Matching";
            this.PM3.UseVisualStyleBackColor = false;
            // 
            // ED3
            // 
            this.ED3.BackColor = System.Drawing.Color.Gray;
            this.ED3.FlatAppearance.BorderSize = 0;
            this.ED3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.ED3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.ED3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ED3.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ED3.ForeColor = System.Drawing.Color.White;
            this.ED3.Location = new System.Drawing.Point(0, 136);
            this.ED3.Name = "ED3";
            this.ED3.Size = new System.Drawing.Size(200, 130);
            this.ED3.TabIndex = 18;
            this.ED3.TabStop = false;
            this.ED3.Text = "Edge Detecting";
            this.ED3.UseVisualStyleBackColor = false;
            this.ED3.Click += new System.EventHandler(this.ED3_Click);
            // 
            // QR3
            // 
            this.QR3.BackColor = System.Drawing.Color.Gray;
            this.QR3.FlatAppearance.BorderSize = 0;
            this.QR3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.QR3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.QR3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.QR3.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.QR3.ForeColor = System.Drawing.Color.White;
            this.QR3.Location = new System.Drawing.Point(0, 0);
            this.QR3.Name = "QR3";
            this.QR3.Size = new System.Drawing.Size(200, 130);
            this.QR3.TabIndex = 17;
            this.QR3.TabStop = false;
            this.QR3.Text = "QRCode Reading";
            this.QR3.UseVisualStyleBackColor = false;
            this.QR3.Click += new System.EventHandler(this.QR3_Click);
            // 
            // checkHide3
            // 
            this.checkHide3.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkHide3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.checkHide3.FlatAppearance.BorderSize = 0;
            this.checkHide3.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gray;
            this.checkHide3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.checkHide3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.checkHide3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkHide3.Font = new System.Drawing.Font("굴림", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.checkHide3.ForeColor = System.Drawing.Color.White;
            this.checkHide3.Location = new System.Drawing.Point(0, 519);
            this.checkHide3.Name = "checkHide3";
            this.checkHide3.Size = new System.Drawing.Size(200, 130);
            this.checkHide3.TabIndex = 16;
            this.checkHide3.Text = "<";
            this.checkHide3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkHide3.UseVisualStyleBackColor = true;
            this.checkHide3.CheckedChanged += new System.EventHandler(this.checkHide3_CheckedChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.button1);
            this.tabPage4.Controls.Add(this.button2);
            this.tabPage4.Controls.Add(this.button3);
            this.tabPage4.Location = new System.Drawing.Point(4, 24);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1256, 655);
            this.tabPage4.TabIndex = 4;
            this.tabPage4.Text = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gray;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(6, 278);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 130);
            this.button1.TabIndex = 22;
            this.button1.TabStop = false;
            this.button1.Text = "Pattern Matching";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Gray;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(6, 142);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(200, 130);
            this.button2.TabIndex = 21;
            this.button2.TabStop = false;
            this.button2.Text = "Edge Detecting";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Gray;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(6, 6);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(200, 130);
            this.button3.TabIndex = 20;
            this.button3.TabStop = false;
            this.button3.Text = "QRCode Reading";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            // 
            // sliderTimer
            // 
            this.sliderTimer.Interval = 10;
            this.sliderTimer.Tick += new System.EventHandler(this.sliderTimer_Tick);
            // 
            // sliderTimer2
            // 
            this.sliderTimer2.Interval = 10;
            this.sliderTimer2.Tick += new System.EventHandler(this.sliderTimer2_Tick);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.WorkerReportsProgress = true;
            this.backgroundWorker2.WorkerSupportsCancellation = true;
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker2.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker2_ProgressChanged);
            // 
            // backgroundWorker3
            // 
            this.backgroundWorker3.WorkerReportsProgress = true;
            this.backgroundWorker3.WorkerSupportsCancellation = true;
            this.backgroundWorker3.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker3.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker3_ProgressChanged);
            // 
            // sliderTimer4
            // 
            this.sliderTimer4.Interval = 10;
            // 
            // compareImg
            // 
            this.compareImg.Location = new System.Drawing.Point(947, 411);
            this.compareImg.Name = "compareImg";
            this.compareImg.Size = new System.Drawing.Size(280, 210);
            this.compareImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.compareImg.TabIndex = 6;
            this.compareImg.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.currentImage)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.sliderTimer3.ResumeLayout(false);
            this.sliderTimer3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.capturedImage)).EndInit();
            this.sliderPanel.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edgeDetect)).EndInit();
            this.sliderPanel2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comparedImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.masterImg)).EndInit();
            this.sliderPanel3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.compareImg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox currentImage;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonCapture;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage sliderTimer3;
        private System.Windows.Forms.TabPage tabPage3;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel sliderPanel;
        private System.Windows.Forms.Button QR1;
        private System.Windows.Forms.Button ED1;
        private System.Windows.Forms.Timer sliderTimer;
        private System.Windows.Forms.CheckBox checkHide;
        private System.Windows.Forms.Label capturedImg;
        private System.Windows.Forms.PictureBox capturedImage;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Panel sliderPanel2;
        private System.Windows.Forms.CheckBox checkHide2;
        private System.Windows.Forms.Button ED2;
        private System.Windows.Forms.Button QR2;
        private System.Windows.Forms.Timer sliderTimer2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox edgeDetect;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.ComponentModel.BackgroundWorker backgroundWorker3;
        private System.Windows.Forms.Button PM1;
        private System.Windows.Forms.Button PM2;
        private System.Windows.Forms.Panel sliderPanel3;
        private System.Windows.Forms.CheckBox checkHide3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox comparedImg;
        private System.Windows.Forms.PictureBox masterImg;
        private System.Windows.Forms.TextBox VIResult;
        private System.Windows.Forms.Button VIStart;
        private System.Windows.Forms.Button uploadBtn;
        private System.Windows.Forms.Button PM3;
        private System.Windows.Forms.Button ED3;
        private System.Windows.Forms.Button QR3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Timer sliderTimer4;
        private System.Windows.Forms.PictureBox compareImg;
    }
}

