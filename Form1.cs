using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Media;
using System.Net.Http.Headers;
using System.Security.Cryptography;

namespace T_Rex
{
    public partial class Form1 : Form
    {
        Image backgroundImage;
        Image backgroundImage2;

        int backgroundHeight;
        int backgroundWidth;
        int bgPositionX = 0, bgPositionY = 0;
        int bg2PositionX = 0;
        int cactusSpeed = 12;
        int formWidth;
        int attackTimer = 0;
        int attackR = 0;
        int score = 0;
        int speed = 10;
        int[] flyingPosition = { 290, 363, 290, 363 };

        bool jumping =  false;
        bool changeAnim = false;
        bool flyingAttack = false;
        bool gameover = false;

        Random random = new Random();

        List<PictureBox> obstacles = new List<PictureBox>();
        PictureBox hitBox = new PictureBox();
        PrivateFontCollection newFont = new PrivateFontCollection();

        SoundPlayer hitSound;
        SoundPlayer plusOneSound;


        public Form1()
        {
            InitializeComponent();
            GameSetUp();
            Reset();
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if(!gameover)
            {
                if(e.KeyCode == Keys.Up && !jumping)
                {
                    jumping = true;
                }
                if (e.KeyCode == Keys.Down && !jumping)
                {

                    if(changeAnim == false)
                    {
                        trex.Image = Properties.Resources.dino_crouch;
                        changeAnim = true;
                    }
                    trex.Top = 352;
                }
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && !gameover)
            {
                trex.Image = Properties.Resources.dino_run;
                trex.Top = 313;
                changeAnim = false;
            }
            if(e.KeyCode == Keys.Enter && gameover)
            {
                Reset();
            }
        }

        private void FormPaintEvent(object sender, PaintEventArgs e)
        {
            Graphics Canvas = e.Graphics;
            Canvas.DrawImage(backgroundImage,bgPositionX,bgPositionY,backgroundWidth,backgroundHeight);
            Canvas.DrawImage(backgroundImage2, bg2PositionX, bgPositionY, backgroundWidth, backgroundHeight);
            Canvas.SmoothingMode = SmoothingMode.AntiAlias;
            Canvas.InterpolationMode = InterpolationMode.HighQualityBicubic;
        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            MoveBackgrounds();
            this.Invalidate();

            MoveObstacles   ();

            lblScore.Text = "Score: " + score;

            hitBox.Left = trex.Right - (hitBox.Width + 20);
            hitBox.Top = trex.Top + 5;

            if(jumping)
            {
                trex.Top -= speed;
                if (trex.Top < 150)
                {
                    speed = -10;
                }
                if(trex.Top >312)
                {
                    jumping = false;
                    trex.Top = 313;
                    speed = 10;
                }
            }
            foreach(PictureBox x in obstacles)
            {
               if(x.Bounds.IntersectsWith(hitBox.Bounds))
                {
                    GameTimer.Stop();
                    trex.Image = Properties.Resources.dead;
                    gameover = true;
                    hitSound = new SoundPlayer(Properties.Resources.hit);
                    lblGameOver.Visible = true;
                    trex.Top = 313;
                }

            }    
        }



        private void GameSetUp()
        {
            backgroundWidth = 900;
            backgroundHeight = 450;
            bg2PositionX = 900; 
            backgroundImage = Properties.Resources.bgPixels;
            backgroundImage2 = Properties.Resources.bgPixels; //для бесшовной прокрутки фона
            //Убирает мерцание при перерисовке (двойная буферизация)
            this.DoubleBuffered = true; //включает отрисовку в скрытом буфере перед показом на экране
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true); //вручную задаёт стиль рендеринга формы, делая отрисовку ещё более плавной
            formWidth = this.ClientSize.Width; //Сохраняет ширину клиентской области окна (без рамок и заголовков) для дальнейшего использования
            this.BackColor = Color.Black;
            obstacles.Add(obstacle1);
            obstacles.Add(obstacle2);
            obstacles.Add(obstacle3);

            newFont.AddFontFile("font/pixel.ttf");
            lblScore.Font = new Font(newFont.Families[0], 30, FontStyle.Bold);
            lblScore.ForeColor = Color.White;
            lblScore.BackColor = Color.Transparent;
            lblScore.Text = "Score: 0";

            lblGameOver = new Label();
            lblGameOver.AutoSize = true;
            lblGameOver.Font = new Font(newFont.Families[0], 48, FontStyle.Bold); 
            lblGameOver.ForeColor = Color.Red;
            lblGameOver.BackColor = Color.Transparent;
            lblGameOver.Text = "GAME OVER";
            lblGameOver.Visible = false;
            // Центрируем надпись
            lblGameOver.Left = (this.ClientSize.Width - lblGameOver.PreferredWidth) / 2;
            lblGameOver.Top = (this.ClientSize.Height - lblGameOver.PreferredHeight) / 2;

            this.Controls.Add(lblGameOver);
            lblGameOver.BringToFront(); // на передний план

            hitBox.BackColor = Color.Transparent;
            hitBox.Width = trex.Width / 2;
            hitBox.Height = trex.Height - 10;

            this.Controls.Add(hitBox) ; //прямоугольника столкновения (hitbox), которым определяется, попал ли игрок в препятствие.
       //     hitBox.BringToFront(); //на передний план
            gameover = false;

            attackR = random.Next(12, 20);
        }

        private void Reset() // перезагрузка
        {
            trex.Image = Properties.Resources.dino_run;
            trex.Top = 313;
            obstacle1.Left = formWidth + random.Next(100, 200);
            obstacle2.Left = formWidth + random.Next(600, 800);
            obstacle3.Left = formWidth + random.Next(200, 400);

            GameTimer.Start();
            lblGameOver.Visible = false;
            score = 0;
            attackTimer = 0;
            speed = 10;
            gameover = false;
            changeAnim = false;
            jumping = false;
            cactusSpeed = 12;
        }

        private void MoveBackgrounds()
        {
            bgPositionX -= 1;
            bg2PositionX -= 1;

            if (bgPositionX < -backgroundWidth)
            {
                bgPositionX = bg2PositionX + backgroundWidth;
            }
            if (bg2PositionX < -backgroundWidth)
            {
                bg2PositionX = bgPositionX + backgroundWidth;
            }
        }

        private void MoveObstacles() // препятствия
        {
            plusOneSound = new SoundPlayer(Properties.Resources.plusone);
            if(!flyingAttack)
            {
                obstacle1.Left -= cactusSpeed;
                obstacle2.Left -= cactusSpeed;
            }
            else
            {
                obstacle3.Left -= cactusSpeed;
            }

            if(attackTimer == attackR)
            {
                flyingAttack = true;
                attackR = random.Next(12, 20);
            }
            if(attackTimer ==0)
            {
                flyingAttack = false;
            }

            if(obstacle1.Left < -100)
            {
                obstacle1.Left = obstacle2.Left + obstacle2.Width + formWidth + random.Next(100, 300);
                attackTimer += 1;
                score += 1;
                plusOneSound.Play();
            }
            if (obstacle2.Left < -100)
            {
                obstacle2.Left = obstacle1.Left + obstacle1.Width + formWidth + random.Next(100, 300);
                attackTimer += 1;
                score += 1;
                plusOneSound.Play();
            }
            if (obstacle3.Left < -100)
            {
                obstacle3.Left =  formWidth + random.Next(300, 400);
                attackTimer -= 1;
                score -= 1;
                plusOneSound.Play();
            }
        }
    }
}
