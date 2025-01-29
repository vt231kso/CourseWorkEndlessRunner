using MyClass;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;


namespace WindowsFormsApp2
{
    public partial class Choose : Form
    {
        public string SelectImage;
        private readonly string skinFolderPath = "C:\\Users\\Sofia\\Desktop\\Endless Runner\\Endless Runner\\MyClass\\Resources\\";
        private AudioManager audioManager;
        private int coins;
        private List<string> ownedSkins;
        public Choose()
        {
            InitializeComponent();
            audioManager = new AudioManager();
            ownedSkins = new List<string>();

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }


        private void btn_choose1_Click(object sender, EventArgs e)
        {
            HandleChoose(4);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HandleBuy(1);
        }

        private void btn_purplegirl_Click(object sender, EventArgs e)
        {
            HandleBuy(4);
        }

        private void btn_purpleboy_Click(object sender, EventArgs e)
        {
            HandleBuy(3);
        }

        private void btn_pinkgirl_Click(object sender, EventArgs e)
        {
            HandleChoose(5);
        }

        private void btn_girl_Click(object sender, EventArgs e)
        {
            HandleBuy(2);
        }

        private void Choose_Load(object sender, EventArgs e)
        {

          
            UpdateUI();

        }
        private void HandleChoose(int skin)
        {
            SkinManager skinManager = new SkinManager();
            SelectImage = skinManager.GetSkinPath(skin);
            DialogResult = DialogResult.OK;
            Form1 form1 = new Form1(SelectImage);
            form1.Show();
            try
            {
                var data = DataManager.LoadData();
               AudioManager.PlayAudio(@"C:\Users\Sofia\Desktop\Endless Runner\Endless Runner\WindowsFormsApp2\Resources\hhhhhhhhhhhhhhhh.wav");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error playing sound");
            }

            Hide();
        }
        private void UpdateUI()
        {
            var data = DataManager.LoadData();
            var skins = data.Skins.Select(int.Parse).ToList();

            if (skins.Contains(1))
            {
                panel1.Hide();
                button1.Visible = true;
                button1.Location = new Point(455, 155);
            }
            if (skins.Contains(2))
            {
                panel3.Hide();
                button2.Visible = true;
                button2.Location = new Point(72, 339);
            }
            if (skins.Contains(3))
            {
                panel2.Hide();
                button3.Visible = true;
                button3.Location = new Point(265, 335);
            }
            if (skins.Contains(4))
            {
                panel4.Hide();
                button4.Visible = true;
                button4.Location = new Point(455, 335);
            }

            // Оновлення тексту кількості монет
            money.Text = data.Coins.ToString();
        }

        private void HandleBuy(int skinIndex)
        {
            SkinManager skinManager = new SkinManager();
            string id= skinIndex.ToString();

            if (SkinShop.PurchaseSkin(id, ref coins, ownedSkins))
            {
                var data = DataManager.LoadData();
                data.Coins = coins;
                data.Skins = ownedSkins.Select(skin => skin.ToString()).ToList();
                DataManager.EditData(data);

                money.Text = coins.ToString();
                UpdateUI();

                MessageBox.Show("Шкіра успішно куплена!");
            }
            else
            {
                MessageBox.Show("Не вистачає монет для покупки цієї шкіри");
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            HandleChoose(0);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            HandleChoose(1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HandleChoose(2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            HandleChoose(3);
        }
    }
}
