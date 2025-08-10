using System;
using System.Windows.Forms;

namespace Test_Victorina
{
    public partial class Password : Form
    {
        private string _login;
        private TestMain _main;

        public Password()
        {
            InitializeComponent();
            this._main = _main;
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
                Admin admin = new Admin(_login, _main);
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
    }
}
