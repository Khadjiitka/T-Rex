namespace T_Rex
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblScore = new Label();
            pictureBox1 = new PictureBox();
            trex = new PictureBox();
            obstacle1 = new PictureBox();
            obstacle2 = new PictureBox();
            obstacle3 = new PictureBox();
            GameTimer = new System.Windows.Forms.Timer(components);
            lblGameOver = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trex).BeginInit();
            ((System.ComponentModel.ISupportInitialize)obstacle1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)obstacle2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)obstacle3).BeginInit();
            SuspendLayout();
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.Location = new Point(28, 23);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(50, 20);
            lblScore.TabIndex = 0;
            lblScore.Text = "label1";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Location = new Point(1, 383);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(860, 50);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // trex
            // 
            trex.BackColor = Color.Transparent;
            trex.Image = Properties.Resources.dino_run;
            trex.Location = new Point(190, 316);
            trex.Name = "trex";
            trex.Size = new Size(88, 92);
            trex.SizeMode = PictureBoxSizeMode.AutoSize;
            trex.TabIndex = 2;
            trex.TabStop = false;
            // 
            // obstacle1
            // 
            obstacle1.BackColor = Color.Transparent;
            obstacle1.Image = Properties.Resources.cactus1;
            obstacle1.Location = new Point(351, 359);
            obstacle1.Name = "obstacle1";
            obstacle1.Size = new Size(37, 49);
            obstacle1.SizeMode = PictureBoxSizeMode.StretchImage;
            obstacle1.TabIndex = 3;
            obstacle1.TabStop = false;
            obstacle1.Tag = "obstacle";
            // 
            // obstacle2
            // 
            obstacle2.BackColor = Color.Transparent;
            obstacle2.Image = Properties.Resources.cactus2;
            obstacle2.Location = new Point(439, 359);
            obstacle2.Name = "obstacle2";
            obstacle2.Size = new Size(58, 49);
            obstacle2.SizeMode = PictureBoxSizeMode.StretchImage;
            obstacle2.TabIndex = 4;
            obstacle2.TabStop = false;
            obstacle2.Tag = "obstacle";
            // 
            // obstacle3
            // 
            obstacle3.BackColor = Color.Transparent;
            obstacle3.Image = Properties.Resources.flying;
            obstacle3.Location = new Point(284, 288);
            obstacle3.Name = "obstacle3";
            obstacle3.Size = new Size(57, 38);
            obstacle3.SizeMode = PictureBoxSizeMode.StretchImage;
            obstacle3.TabIndex = 5;
            obstacle3.TabStop = false;
            obstacle3.Tag = "obstacle";
            // 
            // GameTimer
            // 
            GameTimer.Enabled = true;
            GameTimer.Interval = 15;
            GameTimer.Tick += GameTimerEvent;
            // 
            // lblGameOver
            // 
            lblGameOver.AutoSize = true;
            lblGameOver.Location = new Point(391, 147);
            lblGameOver.Name = "lblGameOver";
            lblGameOver.Size = new Size(50, 20);
            lblGameOver.TabIndex = 6;
            lblGameOver.Text = "label1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(862, 433);
            Controls.Add(lblGameOver);
            Controls.Add(obstacle3);
            Controls.Add(obstacle2);
            Controls.Add(obstacle1);
            Controls.Add(trex);
            Controls.Add(pictureBox1);
            Controls.Add(lblScore);
            Name = "Form1";
            Tag = "obstacle";
            Text = "T-Rex Endless  Runner";
            Paint += FormPaintEvent;
            KeyDown += KeyIsDown;
            KeyUp += KeyIsUp;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trex).EndInit();
            ((System.ComponentModel.ISupportInitialize)obstacle1).EndInit();
            ((System.ComponentModel.ISupportInitialize)obstacle2).EndInit();
            ((System.ComponentModel.ISupportInitialize)obstacle3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblScore;
        private PictureBox pictureBox1;
        private PictureBox trex;
        private PictureBox obstacle1;
        private PictureBox obstacle2;
        private PictureBox obstacle3;
        private System.Windows.Forms.Timer GameTimer;
        private Label lblGameOver;
    }
}
