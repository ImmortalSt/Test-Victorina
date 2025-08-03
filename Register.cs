using MySqlConnector;
using System;
using System.Windows.Forms;

namespace Test_Victorina
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private static void AddUser(string name, string log, string pass)
        {
            string connect = @"Server = 141.8.192.217; DataBase = a1153826_test; User ID = a1153826_test; Password = sev09rus";

            using (var connection = new MySqlConnection(connect))
            {
                connection.Open();
                string insertSql = "INSERT INTO LoginPassword (Name_User, Login_User, Password_User)" +
                    " VALUES (@name, @log, @pass)";
                using (var command = new MySqlCommand(insertSql, connection))
                {
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@log", log);
                    command.Parameters.AddWithValue("@pass", pass);

                    command.ExecuteNonQuery();
                }
            }
        }

        private void textBox_Name_TextChanged(object sender, EventArgs e)
        {
            string name = textBox_Name.Text;
        }

        private void textBox_Login_TextChanged(object sender, EventArgs e)
        {
            string log = textBox_Login.Text;
        }

        private void textBox_Password_TextChanged(object sender, EventArgs e)
        {
            string pass = textBox_Password.Text;
        }

        private void button_Reg_Click(object sender, EventArgs e)
        {
            string name = textBox_Name.Text;
            string log = textBox_Login.Text;
            string pass = textBox_Password.Text;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(log) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show(
                    "Вы пропустили обязательное поле!",
                    "Ошибка регистрации",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            AddUser(name, log, pass);

            var msg = new MsgBox("Регистрация прошла успешно!", "Регистрация");
            msg.ShowDialog();
            //MessageBox.Show("Pегистрация прошла успешно!");
            Hide();
        }
    }
}
