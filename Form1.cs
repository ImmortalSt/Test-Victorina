using MySqlConnector;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Test_Victorina
{
    public partial class Form1_Enter : Form
    {
        private bool _admin = false;

        public Form1_Enter()
        {
            CreateDatabaseAndtable();
            InitializeComponent();
            textBox_Pas.TextChanged += textBox_Pas_TextChanged;
        }

        //создание БД для пользователя
        private static void CreateDatabaseAndtable()
        {
            string connect = @"Server = 141.8.192.217; DataBase = a1153826_test; User ID = a1153826_test; Password = sev09rus";
            using (var connection = new MySqlConnection(connect))
            {
                connection.Open();
                string createTableSql = @"
                    CREATE TABLE IF NOT EXISTS LoginPassword (
	                    ID	INTEGER NOT NULL AUTO_INCREMENT PRIMARY KEY,
	                    Name_User	VARCHAR(50) NOT NULL,
	                    Login_User	VARCHAR(50) NOT NULL UNIQUE,
	                    Password_User	VARCHAR(50) NOT NULL UNIQUE,
                        Admin BOOLEAN NOT NULL);

                    CREATE TABLE IF NOT EXISTS Cataloge (
	                    ID_Cat	INTEGER  NOT NULL AUTO_INCREMENT PRIMARY KEY,
                        Thema	VARCHAR(50) NOT NULL);

                    CREATE TABLE IF NOT EXISTS Question (
	                    ID_Quest INTEGER NOT NULL AUTO_INCREMENT PRIMARY KEY,
                        Quest	VARCHAR(500) NOT NULL,
                        ID_Cat	INTEGER NOT NULL,    
                        FOREIGN KEY(ID_Cat) REFERENCES Cataloge(ID_Cat));

                    CREATE TABLE IF NOT EXISTS Answer (
	                    ID_Ans	INTEGER AUTO_INCREMENT NOT NULL PRIMARY KEY,
                        Answ_Option	VARCHAR(50) NOT NULL,
                        ID_Ques	INTEGER NOT NULL);

                    CREATE TABLE IF NOT EXISTS RightAnswer (
	                    ID	INTEGER AUTO_INCREMENT NOT NULL PRIMARY KEY,
                        ID_Quest	INTEGER NOT NULL,
                        RAnsw	VARCHAR(50) NOT NULL);

                    CREATE TABLE IF NOT EXISTS Result(
                        ID_Result INTEGER AUTO_INCREMENT NOT NULL PRIMARY KEY,
                        RAnswerUser INTEGER,
                        AnswerUser INTEGER,
                        Prosent FLOAT,
                        ID_User INTEGER,
                        ID_Cat INTEGER,
                        FOREIGN KEY(ID_User) REFERENCES LoginPassword(ID))";

                using (var command = new MySqlCommand(createTableSql, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        private void button_Reg_Click(object sender, EventArgs e)
        {
            Hide();
            Register register = new Register();
            register.ShowDialog();
        }

        //проверка логина и пароля для user
        static int ValidateUser(string login, string password)
        {
            string connect = @"Server = 141.8.192.217; DataBase = a1153826_test; User ID = a1153826_test; Password = sev09rus";
            using (var connection = new MySqlConnection(connect))
            {
                int count = 0;
                connection.Open();
                string selectSql = @"SELECT COUNT(*) FROM LoginPassword WHERE Login_User = @login AND Password_User = @password";
                using (var command = new MySqlCommand(selectSql, connection))
                {
                    command.Parameters.AddWithValue("@login", login);
                    command.Parameters.AddWithValue("@password", password);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            count = reader.GetInt32(0);
                            break;
                        }
                    }
                }
                return count;
            }
        }

        private void textBox_Pas_TextChanged(object sender, EventArgs e)
        {
            // Сохраняем оригинальный текст
            //originalPassword = textBox_Pas.Text;
        }

        // проверка на администратора
        static bool ValidateAdmin(string login)
        {
            string connect = @"Server = 141.8.192.217; DataBase = a1153826_test; User ID = a1153826_test; Password = sev09rus";
            using (var connection = new MySqlConnection(connect))
            {
                bool isAdmin = false;
                connection.Open();
                string selectSql = @"SELECT Admin FROM LoginPassword WHERE Login_User = @login";
                using (var command = new MySqlCommand(selectSql, connection))
                {
                    command.Parameters.AddWithValue("@login", login);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            isAdmin = reader.GetBoolean(0);
                            break;
                        }
                    }
                }
                return isAdmin;
            }
        }

        //вход в программу теста
        private void button_Enter_Click(object sender, EventArgs e)
        {
            string login = textBox_Log.Text;
            string password = textBox_Pas.Text; // Используем оригинальный текст

            int count = ValidateUser(login, password);
            _admin = ValidateAdmin(login);
            if (count == 1)
            {
                Hide();
                TestMain testMain = new TestMain(login, _admin);
                testMain.ShowDialog();

            }
            else if (count == 0)
            {
                var msgError = new MsgBoxError("Неверный логин или пароль.\nПожалуйста, попробуйте снова", "Message Error");
                msgError.ShowDialog();

                //MessageBox.Show(
                //    "Неверный логин или пароль.\nПожалуйста, попробуйте снова",
                //    "Ошибка авторизации",
                //    MessageBoxButtons.OK,
                //    MessageBoxIcon.Error
                //    );
            }
        }



        private void button_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //показть пароль, если его забыл
        private string GetResertPassword()
        {
            string login = textBox_Log.Text.Trim();
            string password = string.Empty;

            if (string.IsNullOrEmpty(login))
            {
                var msgError = new MsgBoxError("Вы забыли внести логин", "Message Error");
                msgError.ShowDialog();
                return string.Empty; // Возвращаем пустое значение при ошибке
            }

            try
            {
                string connect = @"Server = 141.8.192.217; DataBase = a1153826_test; User ID = a1153826_test; Password = sev09rus";

                using (var connection = new MySqlConnection(connect))
                {
                    connection.Open();

                    string selectSql = @"SELECT Password_User
                                FROM LoginPassword 
                                WHERE Login_User = @Login_User";

                    var command = new MySqlCommand(selectSql, connection);

                    command.Parameters.AddWithValue("@Login_User", login);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            password = reader.GetString(0);
                        }
                        else
                        {
                            var msgError = new MsgBoxError("Пользователь не найден", "Message Error");
                            msgError.ShowDialog();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var msgError = new MsgBoxError($"Произошла ошибка: {ex.Message}", "Message Error");
                msgError.ShowDialog();
            }

            return password;
        }

        private void button_ResetPassword_Click(object sender, EventArgs e)
        {
            string password = GetResertPassword();
            if (!string.IsNullOrEmpty(password))
            {
                var msg = new MsgBox($"Ваш пароль: {password}", "Восстановление пароля");
                msg.ShowDialog();
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
