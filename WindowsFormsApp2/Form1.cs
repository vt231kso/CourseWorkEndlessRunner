using MyClass;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        private Player player;
        private Timer mainTimer;
        private int life;
        private PictureBox[] lifeIndicators;
        private bool collisionHandled = false;
        private Label labelScore;
        private Label labelHighScore;

        public Form1(string playerImageFilePath)
        {
            InitializeComponent();
            Init(playerImageFilePath);
        }

        private void Init(string playerImageFilePath)
        {
            GameController.Init();

            var playerTransform = new TransformData(
                new PointF(20, 250),
                new Size(50, 50)
            );

            player = new Player(
                playerTransform,
                Image.FromFile(playerImageFilePath)
            );

            life = 3;
            GameController.coinCount = 0;
            collisionHandled = false;

            InitLifeIndicators();
            InitScoreLabels();

            var data = DataManager.LoadData();
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

        private void InitScoreLabels()
        {
            labelScore = new Label();
            labelScore.Location = new Point(70, 18);
            labelScore.Size = new Size(100, 30);
            labelScore.Font = new Font("Arial", 14);
            labelScore.ForeColor = Color.Red;
            labelScore.BackColor = Color.Transparent;
            this.Controls.Add(labelScore);

            labelHighScore = new Label();
            labelHighScore.Location = new Point(478, 55);
            labelHighScore.Size = new Size(200, 30);
            labelHighScore.Font = new Font("Arial", 14);
            labelHighScore.ForeColor = Color.Red;
            labelHighScore.BackColor = Color.Transparent;
            this.Controls.Add(labelHighScore);
        }

        private void Update(object sender, EventArgs e)
        {
            player.UpdateScore();
            labelScore.Text = player.Score.ToString();

            if (player.Collide() && !collisionHandled)
            {
                collisionHandled = true;
                life--;

                if (life == 0)
                {
                    mainTimer.Stop();
                    GameOver();
                }
            }
            else if (!player.Collide())
            {
                collisionHandled = false;
            }

            UpdateLifeIndicators();
            player.ApplyPhysics();
            GameController.MoveMap();
            Invalidate();
        }

        private void UpdateLifeIndicators()
        {
            for (int i = 0; i < lifeIndicators.Length; i++)
            {
                lifeIndicators[i].Image = (i < life) ? Properties.Resources.life : Properties.Resources.life_white;
            }
        }

        private void GameOver()
        {
            AudioManager.wmp.controls.stop();
            restart_1.Visible = true;
            back_to_menu.Visible = true;
            pause.Enabled = false;

            SaveResult(player.Score, GameController.coinCount);
        }

        private void SaveResult(int score, int coins)
        {
            var data = DataManager.LoadData();
            if (score > data.MaxScore) data.MaxScore = score;
            data.LastScore = score;
            data.Coins += coins;
            DataManager.EditData(data);
        }

        private void DrawGame(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.DrawImage(
                GameController.back,
                new Rectangle(GameController.backgroundShift, 0, GameController.back.Width, GameController.back.Height)
            );
            g.DrawImage(
                GameController.back,
                new Rectangle(GameController.backgroundShift + GameController.back.Width, 0, GameController.back.Width, GameController.back.Height)
            );

            GameController.DrawObjets(g);
            player.DrawSprite(g);

            if (!mainTimer.Enabled)
            {
                AudioManager.wmp.controls.stop();
                restart_1.Visible = true;
            }
        }
    }
}