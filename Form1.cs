using MySqlConnector;
using System;
using System.Windows.Forms;

namespace Test_Victorina
{

    public partial class Form1_Enter : Form
    {
        private string originalPassword = string.Empty;

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
	                    Password_User	VARCHAR(50) NOT NULL UNIQUE);

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
                string selectSql = "SELECT COUNT(*) FROM LoginPassword WHERE Login_User = @login AND Password_User = @password";
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

        //вход в программу теста
        private void button_Enter_Click(object sender, EventArgs e)
        {
            string login = textBox_Log.Text;
            string password = textBox_Pas.Text; // Используем оригинальный текст

            int count = ValidateUser(login, password);
            if (count == 1)
            {
                TestMain testMain = new TestMain(login);
                testMain.ShowDialog();

            }
            else if (count == 0)
            {
                MessageBox.Show("Неверный логин или пароль. Пожалуйста, попробуйте снова");
            }
        }



        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
