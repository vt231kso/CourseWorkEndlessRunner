using MyClass;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using static MyClass.DataManager;

using System.Windows.Forms;
using WMPLib;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        Player player;
        Timer mainTimer;
        int life;
        PictureBox[] lifeIndicators;
        public static WindowsMediaPlayer back = new WindowsMediaPlayer();
        private string playerImageFilePath;
        private Label labelScore;
        private Label labelHighScore;

        public Form1(string playerImageFilePath)
        {
            InitializeComponent();
            this.Width = 606;
            this.Height = 400;
            this.DoubleBuffered = true;
            life = 3;
            collisionHandled = false;
            this.Paint += new PaintEventHandler(DrawGame);
            this.KeyUp += new KeyEventHandler(OnKeyboardUp);
            this.KeyDown += new KeyEventHandler(OnKeyboardDown);
            mainTimer = new Timer();
            mainTimer.Interval = 20;
            mainTimer.Tick += new EventHandler(Update);
            continue_1.Visible = false;
            restart_1.Visible = false;
            back_to_menu.Visible = false;

            
            this.playerImageFilePath = playerImageFilePath; 
            Init(playerImageFilePath);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void OnKeyboardDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                    if (!player.isJumping)
                    {
                        player.isCrouching = true;
                        player.isJumping = false;
                        player.size = new Size(player.size.Width, 50);
                        player.position = new PointF(player.position.X, 255);
                    }
                    break;
            }
        }

        private void OnKeyboardUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (!player.isCrouching)
                    {
                        player.isCrouching = false;
                        player.Addforce();
                        player.position = new PointF(player.position.X, 250);
                    }
                    break;
                case Keys.Down:
                    player.isCrouching = false;
                    player.size = new Size(player.size.Width, 50);
                    player.position = new PointF(player.position.X, 250);
                    break;
            }
        }

        private void InitScoreLabels()
        {
            // Ініціалізація Label для поточного рахунку
            labelScore = new Label();
            labelScore.Location = new Point(70, 18);
            labelScore.Size = new Size(100, 30);
            labelScore.Font = new Font("Arial", 14);
            labelScore.ForeColor = Color.Red;
            labelScore.BackColor = Color.Transparent;
            this.Controls.Add(labelScore);

            // Ініціалізація Label для найкращого рахунку
            labelHighScore = new Label();
            labelHighScore.Location = new Point(478, 55);
            labelHighScore.Size = new Size(200, 30);
            labelHighScore.Font = new Font("Arial", 14);
            labelHighScore.ForeColor = Color.Red;
            labelHighScore.BackColor = Color.Transparent;
            this.Controls.Add(labelHighScore);
        }

        public void Init(string playerImageFilePath)
        {
            GameController.Init();
            Image playerImage = Image.FromFile(playerImageFilePath);
            player = new Player(new PointF(20, 250), new Size(50, 50), playerImage);
            life = 3;
            GameController.coinCount = 0;
            collisionHandled = false;
            InitLifeIndicators();
            InitScoreLabels();
            labelHighScore.Visible = true;
            labelScore.Visible = true;
          
            var data =LoadData();
            labelHighScore.Text = data.MaxScore.ToString();
           

            UpdateLifeIndicators();
            mainTimer.Start();
            Invalidate();
        }

        private void InitLifeIndicators()
        {
            lifeIndicators = new PictureBox[3];
            for (int i = 0; i < lifeIndicators.Length; i++)
            {
                lifeIndicators[i] = new PictureBox();
                lifeIndicators[i].Size = new Size(30, 30);
                lifeIndicators[i].BackColor = Color.Transparent;
                lifeIndicators[i].Location = new Point(400 + 60 * i, 10);
                lifeIndicators[i].SizeMode = PictureBoxSizeMode.StretchImage;
                this.Controls.Add(lifeIndicators[i]);
            }
        }

        public void Update(object sender, EventArgs e)
        {
            player.UpdateScore();
            label1.Text = GameController.coinCount.ToString();
            labelScore.Text = player.score.ToString();

            bool hasCollided = player.Collide(); // Викликаємо метод один раз

            if (hasCollided && !collisionHandled)
            {
                collisionHandled = true;
                --life;
                back.URL = @"C:\Users\Sofia\Desktop\Endless Runner\Endless Runner\WindowsFormsApp2\Resources\background sound.wav";
                back.controls.play();

                if (life == 0)
                {
                    mainTimer.Stop();
                    pictureBox2gameover.Visible = true;
                    GameOver();
                }
            }
            else if (!hasCollided)
            {
                collisionHandled = false;
            }
        }


        private bool collisionHandled = false;
        private void UpdateLifeIndicators()
        {
            for (int i = 0; i < lifeIndicators.Length; i++)
            {
                if (i < life)
                {
                    lifeIndicators[i].Image = Properties.Resources.life;
                }
                else
                {
                    lifeIndicators[i].Image = Properties.Resources.life_white;
                }
            }
        }

        private void GameOver()
        {
            AudioManager.wmp.controls.stop(); ;
            restart_1.Visible = true;
            back_to_menu.Visible = true;
            pause.Enabled = false;

        
            SaveResult(player.score,GameController.coinCount);
        }

        private void DrawGame(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.DrawImage(GameController.back, new Rectangle(GameController.backgroundShift, 0, GameController.back.Width, GameController.back.Height));
            g.DrawImage(GameController.back, new Rectangle(GameController.backgroundShift + GameController.back.Width, 0, GameController.back.Width, GameController.back.Height));
            GameController.DrawObjets(g);
            player.DrawSprite(g);

            if (!mainTimer.Enabled)
            {
                AudioManager.wmp.controls.stop();

                restart_1.Visible = true;
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            continue_1.Visible = false;
            restart_1.Visible = false;
            back_to_menu.Visible = false;
            mainTimer.Enabled = true;
            AudioManager.wmp.settings.setMode("loop", true);
            AudioManager.wmp.controls.play();
        }

        private void restart_1_Click_1(object sender, EventArgs e)
        {
          
            pictureBox2gameover.Visible = false;
            Choose choose = new Choose();
            choose.Show();
            this.Hide();
        }

        private void back_to_menu_Click_1(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Hide();
        }

        private void pause_Click(object sender, EventArgs e)
        {
            mainTimer.Stop();
            AudioManager.wmp.controls.pause();
            pictureBox2gameover.Visible = false;
            continue_1.Visible = true;
            restart_1.Visible = true;
            back_to_menu.Visible = true;
        }

        private void SaveResult(int score,int coins)
        {
            var data =LoadData();
            if (score > data.MaxScore)
            {
                data.MaxScore = score;
            }
            data.LastScore = score;
            data.Coins += coins;
           EditData(data);
        }

        private void pictureBox2gameover_Click(object sender, EventArgs e)
        {

        }
    }
}
