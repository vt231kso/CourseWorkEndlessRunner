using System;
using System.Windows.Forms;


namespace WindowsFormsApp2
{
    public partial class Menu : Form
    {


        public Menu()
        {
            InitializeComponent();
        }

        private void btn_start_Click(object sender, EventArgs e)
        {

            Choose choose = new Choose();
            choose.Show();
            this.Hide();

        }

        private void btn_start_MouseHover_1(object sender, EventArgs e)
        {
            btn_start.Image = Properties.Resources.start_hover;
        }

        private void btn_start_MouseLeave_1(object sender, EventArgs e)
        {
            btn_start.Image = Properties.Resources.start_normal;
        }

        private void btn_option_MouseHover_1(object sender, EventArgs e)
        {
            btn_option.Image = Properties.Resources.option_hover;
        }

        private void btn_option_MouseLeave_1(object sender, EventArgs e)
        {
            btn_option.Image = Properties.Resources.option_normal;
        }

        private void btn_exit_MouseHover_1(object sender, EventArgs e)
        {
            btn_exit.Image = Properties.Resources.exit_hover;
        }

        private void btn_exit_MouseLeave_1(object sender, EventArgs e)
        {
            btn_exit.Image = Properties.Resources.exit_normal;
        }

        private void btn_option_Click(object sender, EventArgs e)
        {
            option_page option = new option_page();
            option.Show();
            this.Hide();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
        }

        private void Menu_Load_1(object sender, EventArgs e)
        {
        }

        private void btn_shop_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
