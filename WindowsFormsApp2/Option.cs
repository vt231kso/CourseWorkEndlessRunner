using MyClass;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class option_page : Form
    {
        public option_page()
        {
            InitializeComponent();
        }

        private void option_page_Load(object sender, EventArgs e)
        {
            var data = DataManager.LoadData();
            trackBar1.Value = data.Volume;
            if (trackBar1.Value == 0)
            {
                btn_sound.Image = Properties.Resources.sound_off;
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            AudioManager.wmp.URL = @"C:\Users\Sofia\Desktop\Endless Runner\Endless Runner\WindowsFormsApp2\Resources\hhhhhhhhhhhhhhhh.wav";
            AudioManager.wmp.controls.play();
            btn_sound.Image = Properties.Resources.sound_on;
            AudioManager.wmp.settings.volume = trackBar1.Value;
            var data = DataManager.LoadData();
            data.Volume = trackBar1.Value;
            
            DataManager.EditData(data);
            if (trackBar1.Value == 0)
            {
                btn_sound.Image = Properties.Resources.sound_off;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AudioManager.wmp.controls.stop();
           Menu menu = new Menu();
            menu.Show();
            this.Close(); // Закриваємо поточну форму
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void option_menu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_sound_Click(object sender, EventArgs e)
        {

        }
    }
}
