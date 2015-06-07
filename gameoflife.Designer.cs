namespace GameofLife
{
    partial class gameoflife
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
            this.components = new System.ComponentModel.Container();
            this.worldBox = new System.Windows.Forms.PictureBox();
            this.resetButton = new System.Windows.Forms.Button();
            this.worldTimer = new System.Windows.Forms.Timer(this.components);
            this.stepButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.gridBox = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.worldSize = new System.Windows.Forms.Label();
            this.timeSlider = new System.Windows.Forms.HScrollBar();
            this.checkWrap = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.saveButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.checkDecay = new System.Windows.Forms.CheckBox();
            this.checkDead = new System.Windows.Forms.CheckBox();
            this.hmirrorButton = new System.Windows.Forms.Button();
            this.vmirrorButton = new System.Windows.Forms.Button();
            this.loadImageButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.colorThreshold = new System.Windows.Forms.TextBox();
            this.refreshbutton = new System.Windows.Forms.Button();
            this.invertThresh = new System.Windows.Forms.CheckBox();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.colorButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.worldBox)).BeginInit();
            this.SuspendLayout();
            // 
            // worldBox
            // 
            this.worldBox.BackColor = System.Drawing.Color.Black;
            this.worldBox.Location = new System.Drawing.Point(4, 7);
            this.worldBox.Name = "worldBox";
            this.worldBox.Size = new System.Drawing.Size(600, 600);
            this.worldBox.TabIndex = 0;
            this.worldBox.TabStop = false;
            this.worldBox.Click += new System.EventHandler(this.worldBox_Click);
            this.worldBox.Paint += new System.Windows.Forms.PaintEventHandler(this.worldBox_Paint);
            this.worldBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.worldBox_MouseClick);
            this.worldBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.worldBox_MouseDown);
            this.worldBox.MouseEnter += new System.EventHandler(this.worldBox_MouseEnter);
            this.worldBox.MouseHover += new System.EventHandler(this.worldBox_MouseHover);
            this.worldBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.worldBox_MouseUp);
            this.worldBox.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.worldBox_MouseWheel);
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(691, 41);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.TabIndex = 1;
            this.resetButton.Text = "Reset";
            this.resetButton.UseMnemonic = false;
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // worldTimer
            // 
            this.worldTimer.Interval = 50;
            this.worldTimer.Tick += new System.EventHandler(this.worldTimer_Tick);
            // 
            // stepButton
            // 
            this.stepButton.Location = new System.Drawing.Point(610, 41);
            this.stepButton.Name = "stepButton";
            this.stepButton.Size = new System.Drawing.Size(75, 23);
            this.stepButton.TabIndex = 2;
            this.stepButton.Text = "Step";
            this.stepButton.UseVisualStyleBackColor = true;
            this.stepButton.Click += new System.EventHandler(this.stepButton_Click);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(610, 12);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 4;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(691, 12);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 3;
            this.stopButton.Text = "Stop";
            this.stopButton.UseMnemonic = false;
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // gridBox
            // 
            this.gridBox.AutoSize = true;
            this.gridBox.Location = new System.Drawing.Point(610, 119);
            this.gridBox.Name = "gridBox";
            this.gridBox.Size = new System.Drawing.Size(75, 17);
            this.gridBox.TabIndex = 5;
            this.gridBox.Text = "Show Grid";
            this.gridBox.UseVisualStyleBackColor = true;
            this.gridBox.CheckedChanged += new System.EventHandler(this.gridBox_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(643, 90);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(42, 20);
            this.textBox1.TabIndex = 6;
            this.textBox1.Text = "50";
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // worldSize
            // 
            this.worldSize.AutoSize = true;
            this.worldSize.Location = new System.Drawing.Point(607, 93);
            this.worldSize.Name = "worldSize";
            this.worldSize.Size = new System.Drawing.Size(30, 13);
            this.worldSize.TabIndex = 7;
            this.worldSize.Text = "Size:";
            // 
            // timeSlider
            // 
            this.timeSlider.Location = new System.Drawing.Point(610, 67);
            this.timeSlider.Maximum = 1000;
            this.timeSlider.Minimum = 50;
            this.timeSlider.Name = "timeSlider";
            this.timeSlider.Size = new System.Drawing.Size(156, 17);
            this.timeSlider.TabIndex = 8;
            this.timeSlider.Value = 450;
            this.timeSlider.Scroll += new System.Windows.Forms.ScrollEventHandler(this.timeSlider_Scroll);
            // 
            // checkWrap
            // 
            this.checkWrap.AutoSize = true;
            this.checkWrap.BackColor = System.Drawing.SystemColors.Control;
            this.checkWrap.Location = new System.Drawing.Point(610, 142);
            this.checkWrap.Name = "checkWrap";
            this.checkWrap.Size = new System.Drawing.Size(81, 17);
            this.checkWrap.TabIndex = 10;
            this.checkWrap.Text = "Wrap Sides";
            this.checkWrap.UseVisualStyleBackColor = false;
            this.checkWrap.CheckedChanged += new System.EventHandler(this.checkWrap_CheckedChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(691, 90);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 12;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(691, 119);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(75, 23);
            this.loadButton.TabIndex = 13;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // checkDecay
            // 
            this.checkDecay.AutoSize = true;
            this.checkDecay.BackColor = System.Drawing.SystemColors.Control;
            this.checkDecay.Location = new System.Drawing.Point(610, 186);
            this.checkDecay.Name = "checkDecay";
            this.checkDecay.Size = new System.Drawing.Size(86, 17);
            this.checkDecay.TabIndex = 15;
            this.checkDecay.Text = "Decay Dead";
            this.checkDecay.UseVisualStyleBackColor = false;
            this.checkDecay.CheckedChanged += new System.EventHandler(this.checkDecay_CheckedChanged);
            // 
            // checkDead
            // 
            this.checkDead.AutoSize = true;
            this.checkDead.Location = new System.Drawing.Point(610, 163);
            this.checkDead.Name = "checkDead";
            this.checkDead.Size = new System.Drawing.Size(82, 17);
            this.checkDead.TabIndex = 14;
            this.checkDead.Text = "Show Dead";
            this.checkDead.UseVisualStyleBackColor = true;
            this.checkDead.CheckedChanged += new System.EventHandler(this.checkDead_CheckedChanged);
            // 
            // hmirrorButton
            // 
            this.hmirrorButton.Location = new System.Drawing.Point(610, 209);
            this.hmirrorButton.Name = "hmirrorButton";
            this.hmirrorButton.Size = new System.Drawing.Size(156, 23);
            this.hmirrorButton.TabIndex = 16;
            this.hmirrorButton.Text = "Horizontal Mirror";
            this.hmirrorButton.UseVisualStyleBackColor = true;
            this.hmirrorButton.Click += new System.EventHandler(this.hmirrorButton_Click);
            // 
            // vmirrorButton
            // 
            this.vmirrorButton.Location = new System.Drawing.Point(610, 238);
            this.vmirrorButton.Name = "vmirrorButton";
            this.vmirrorButton.Size = new System.Drawing.Size(156, 23);
            this.vmirrorButton.TabIndex = 17;
            this.vmirrorButton.Text = "Vertical Mirror";
            this.vmirrorButton.UseVisualStyleBackColor = true;
            this.vmirrorButton.Click += new System.EventHandler(this.vmirrorButton_Click);
            // 
            // loadImageButton
            // 
            this.loadImageButton.Location = new System.Drawing.Point(610, 367);
            this.loadImageButton.Name = "loadImageButton";
            this.loadImageButton.Size = new System.Drawing.Size(75, 23);
            this.loadImageButton.TabIndex = 18;
            this.loadImageButton.Text = "Load Image";
            this.loadImageButton.UseVisualStyleBackColor = true;
            this.loadImageButton.Click += new System.EventHandler(this.loadImageButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(607, 398);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Color Threshold:";
            // 
            // colorThreshold
            // 
            this.colorThreshold.Location = new System.Drawing.Point(691, 395);
            this.colorThreshold.Name = "colorThreshold";
            this.colorThreshold.Size = new System.Drawing.Size(33, 20);
            this.colorThreshold.TabIndex = 19;
            this.colorThreshold.Text = "127";
            this.colorThreshold.TextChanged += new System.EventHandler(this.colorThreshold_TextChanged);
            // 
            // refreshbutton
            // 
            this.refreshbutton.Location = new System.Drawing.Point(691, 367);
            this.refreshbutton.Name = "refreshbutton";
            this.refreshbutton.Size = new System.Drawing.Size(75, 23);
            this.refreshbutton.TabIndex = 21;
            this.refreshbutton.Text = "Refresh";
            this.refreshbutton.UseVisualStyleBackColor = true;
            this.refreshbutton.Click += new System.EventHandler(this.refreshbutton_Click);
            // 
            // invertThresh
            // 
            this.invertThresh.AutoSize = true;
            this.invertThresh.Location = new System.Drawing.Point(730, 398);
            this.invertThresh.Name = "invertThresh";
            this.invertThresh.Size = new System.Drawing.Size(53, 17);
            this.invertThresh.TabIndex = 22;
            this.invertThresh.Text = "Invert";
            this.invertThresh.UseVisualStyleBackColor = true;
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Location = new System.Drawing.Point(610, 418);
            this.hScrollBar1.Maximum = 255;
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(156, 17);
            this.hScrollBar1.TabIndex = 23;
            this.hScrollBar1.Value = 127;
            this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
            // 
            // colorButton
            // 
            this.colorButton.Location = new System.Drawing.Point(610, 267);
            this.colorButton.Name = "colorButton";
            this.colorButton.Size = new System.Drawing.Size(156, 23);
            this.colorButton.TabIndex = 24;
            this.colorButton.Text = "Screen Color";
            this.colorButton.UseVisualStyleBackColor = true;
            this.colorButton.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(610, 296);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 23);
            this.button1.TabIndex = 25;
            this.button1.Text = "Live Color";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // gameoflife
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 611);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.colorButton);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.invertThresh);
            this.Controls.Add(this.refreshbutton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.colorThreshold);
            this.Controls.Add(this.loadImageButton);
            this.Controls.Add(this.vmirrorButton);
            this.Controls.Add(this.hmirrorButton);
            this.Controls.Add(this.checkDecay);
            this.Controls.Add(this.checkDead);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.checkWrap);
            this.Controls.Add(this.timeSlider);
            this.Controls.Add(this.worldSize);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.gridBox);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.stepButton);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.worldBox);
            this.Name = "gameoflife";
            this.Text = "Conway\'s Game of Life";
            this.Load += new System.EventHandler(this.gameoflife_Load);
            ((System.ComponentModel.ISupportInitialize)(this.worldBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox worldBox;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Timer worldTimer;
        private System.Windows.Forms.Button stepButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.CheckBox gridBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label worldSize;
        private System.Windows.Forms.HScrollBar timeSlider;
        private System.Windows.Forms.CheckBox checkWrap;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.CheckBox checkDecay;
        private System.Windows.Forms.CheckBox checkDead;
        private System.Windows.Forms.Button hmirrorButton;
        private System.Windows.Forms.Button vmirrorButton;
        private System.Windows.Forms.Button loadImageButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox colorThreshold;
        private System.Windows.Forms.Button refreshbutton;
        private System.Windows.Forms.CheckBox invertThresh;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button colorButton;
        private System.Windows.Forms.Button button1;
    }
}

