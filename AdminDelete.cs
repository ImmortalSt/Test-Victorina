using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Test_Victorina
{
    public partial class AdminDelete : Form
    {
        private string _login;
        private TestMain _main;

        public AdminDelete(string login)
        {
            InitializeComponent();
            this._main = _main;
            _login = login;
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //чтение из БД Каталога тем
        private static List<string> ValidateCataloge()
        {
            string connect = @"Server = 141.8.192.217; DataBase = a1153826_test; User ID = a1153826_test; Password = sev09rus";

            List<string> list = new List<string>();
            using (var connection = new MySqlConnection(connect))
            {
                connection.Open();
                string selectCataloge = "SELECT Thema FROM Cataloge";
                using (var command = new MySqlCommand(selectCataloge, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(reader.GetString(0));
                        }
                    }
                }

            }
            return list;
        }

        //удалить из БД тему 
        private static void DeleteThema(string thema)
        {
            string connect = @"Server = 141.8.192.217; DataBase = a1153826_test; User ID = a1153826_test; Password = sev09rus";

            using (var connection = new MySqlConnection(connect))
            {
                connection.Open();
                string deletetSql = "DELETE FROM Cataloge WHERE Thema = @thema";
                using (var command = new MySqlCommand(deletetSql, connection))
                {
                    command.Parameters.AddWithValue("@thema", thema);

                    command.ExecuteNonQuery();
                }
            }
        }

        private void AdminDelete_Load(object sender, EventArgs e)
        {
            cB_Cataloge.DropDownStyle = ComboBoxStyle.DropDownList; // нельзя написать в ячейке тема теста

            // получение всех тем из каталога
            List<string> catalogeItems = ValidateCataloge();
            cB_Cataloge.Items.AddRange(catalogeItems.ToArray());
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            Hide();
            _main.ShowDialog();
        }
    }
}
