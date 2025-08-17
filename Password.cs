using System;
using System.Drawing;
using System.Windows.Forms;

namespace Test_Victorina
{
    public partial class Password : Form
    {
        private string _login;
        private bool _admin;
        private TestMain _main;

        public Password(string login, bool admin)
        {
            InitializeComponent();
            //this._main = _main;
            _login = login;
            _admin = admin;
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Enter_Click(object sender, EventArgs e)
        {
            string password = textBox_Pas.Text; // Используем оригинальный текст
            if (password == "admin")
            {
                Hide();
                Admin admin = new Admin(_login, _admin);
                admin.ShowDialog();
            }
            else
            {
                MessageBox.Show(
                    "Неверный пароль.\nПожалуйста, попробуйте снова",
                    "Ошибка авторизации",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }
        }

        //показ * вместо пароля при нажатии на картинку
        private bool closeOpen = true;

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (closeOpen)
            {
                closeOpen = false;
                pictureBox2.Image = Image.FromFile("icon/show.jpg");
                textBox_Pas.PasswordChar = '\0';
            }
            else
            {
                closeOpen = true;
                pictureBox2.Image = Image.FromFile("icon/clos.jpg");
                textBox_Pas.PasswordChar = '*';
            }
        }
    }
}
