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
        public Choose()
        {
            InitializeComponent();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }

        public static WindowsMediaPlayer wmp = new WindowsMediaPlayer();

        private void btn_choose1_Click(object sender, EventArgs e)
        {
            HandleChoose("C:\\Users\\Sofia\\Desktop\\Endless Runner\\Endless Runner\\MyClass\\Resources\\skins2.png");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HandleBuy("1");
        }

        private void btn_purplegirl_Click(object sender, EventArgs e)
        {
            HandleBuy("4");
        }

        private void btn_purpleboy_Click(object sender, EventArgs e)
        {
            HandleBuy("3");
        }

        private void btn_pinkgirl_Click(object sender, EventArgs e)
        {
            HandleChoose("C:\\Users\\Sofia\\Desktop\\Endless Runner\\Endless Runner\\MyClass\\Resources\\skins6.png");
        }

        private void btn_girl_Click(object sender, EventArgs e)
        {
            HandleBuy("2");
        }

        private void Choose_Load(object sender, EventArgs e)
        {

            var data = DataManager.LoadData();
            var skins = data.Skins;
            if (skins.Contains(btn_redboy.Tag))
            {
                panel1.Hide();
                button1.Visible = true;
                button1.Location = new Point(455, 155);
            }
            if (skins.Contains(btn_girl.Tag))
            {
                panel3.Hide();
                button2.Visible = true;
                button2.Location = new Point(72, 339);
            }
            if (skins.Contains(btn_purpleboy.Tag))
            {
                panel2.Hide();
                button3.Visible = true;
                button3.Location = new Point(265, 335);
            }
            if (skins.Contains(btn_purplegirl.Tag))
            {
                panel4.Hide();
                button4.Visible = true;
                button4.Location = new Point(455, 335);
            }
            money.Text = data.Coins.ToString();

        }
        private void HandleChoose(string skin)
        {
            SelectImage = skin;
            DialogResult = DialogResult.OK;
            Form1 form1 = new Form1(SelectImage);
            form1.Show();
            try
            {
                wmp.URL = @"C:\Users\Sofia\Desktop\Endless Runner\Endless Runner\WindowsFormsApp2\Resources\hhhhhhhhhhhhhhhh.wav";
                var data = DataManager.LoadData();
                wmp.settings.volume = data.Volume;
                wmp.settings.setMode("loop", true);
                wmp.controls.play();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error playing sound");
            }

            Hide();
        }
        private void HandleBuy(string id)
        {
            var data = DataManager.LoadData();
            if (data.Coins >= 10)
            {
                data.Coins -= 10;
                data.Skins.Add(id);
                DataManager.EditData(data);
                Choose choose = new Choose();
                choose.Show();
                Hide();
            }
            else MessageBox.Show("Недостатньо монет для покупки цього персонажа");
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            HandleChoose("C:\\Users\\Sofia\\Desktop\\Endless Runner\\Endless Runner\\MyClass\\Resources\\skins1.png");
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            HandleChoose("C:\\Users\\Sofia\\Desktop\\Endless Runner\\Endless Runner\\MyClass\\Resources\\skins7.png");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HandleChoose("C:\\Users\\Sofia\\Desktop\\Endless Runner\\Endless Runner\\MyClass\\Resources\\skins4.png");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            HandleChoose("C:\\Users\\Sofia\\Desktop\\Endless Runner\\Endless Runner\\MyClass\\Resources\\skins5.png");
        }
    }
}
