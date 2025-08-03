using System;
using System.Windows.Forms;

namespace Test_Victorina
{
    public partial class Password : Form
    {
        public Password()
        {
            InitializeComponent();
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
                Admin admin = new Admin();
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
