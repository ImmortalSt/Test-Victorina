using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Test_Victorina
{
    public partial class AdminDelete : Form
    {
        private string _login;

        public AdminDelete()
        {
            InitializeComponent();
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            Hide();

            // новый экземпляр формы TestMain с тем же логином
            Admin admin = new Admin(_login);
            admin.Show();
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

        private void AdminDelete_Load(object sender, EventArgs e)
        {
            cB_Cataloge.DropDownStyle = ComboBoxStyle.DropDownList; // нельзя написать в ячейке тема теста

            // получение всех тем из каталога
            List<string> catalogeItems = ValidateCataloge();
            cB_Cataloge.Items.AddRange(catalogeItems.ToArray());
        }

        //удалить из БД тему 
        private static void DeleteThema(string thema)
        {
            string connect = @"Server = 141.8.192.217; DataBase = a1153826_test; User ID = a1153826_test; Password = sev09rus";

            using (var connection = new MySqlConnection(connect))
            {
                connection.Open();

                //Последовательное удаление данных из всех связанных таблиц
                string deleteRightAnswerSql = @"DELETE FROM RightAnswer 
                                                WHERE ID_Quest IN (
                                                    SELECT ID_Quest 
                                                    FROM Question 
                                                    WHERE ID_Cat IN (
                                                        SELECT ID_Cat 
                                                        FROM Cataloge 
                                                        WHERE Thema = @thema))";

                string deleteAnswerSql = @"DELETE FROM Answer
                                            WHERE ID_Ques IN (
                                                SELECT ID_Quest 
                                                FROM Question 
                                                WHERE ID_Cat IN (
                                                    SELECT ID_Cat 
                                                    FROM Cataloge 
                                                    WHERE Thema = @thema))";

                string deleteQuestionSql = @"DELETE FROM Question 
                                                WHERE ID_Cat IN (
                                                    SELECT ID_Cat
                                                    FROM Cataloge
                                                    WHERE Thema = @thema)";

                string deleteCatalogeSql = @"DELETE FROM Cataloge 
                                                WHERE Thema = @thema";

                // Выполнение каждого запроса отдельно
                using (var command = new MySqlCommand(deleteRightAnswerSql, connection))
                {
                    command.Parameters.AddWithValue("@thema", thema);
                    command.ExecuteNonQuery();
                }

                using (var command = new MySqlCommand(deleteAnswerSql, connection))
                {
                    command.Parameters.AddWithValue("@thema", thema);
                    command.ExecuteNonQuery();
                }

                using (var command = new MySqlCommand(deleteQuestionSql, connection))
                {
                    command.Parameters.AddWithValue("@thema", thema);
                    command.ExecuteNonQuery();
                }

                using (var command = new MySqlCommand(deleteCatalogeSql, connection))
                {
                    command.Parameters.AddWithValue("@thema", thema);
                    command.ExecuteNonQuery();
                }
            }
        }

        private void btn_DelThema_Click(object sender, EventArgs e)
        {
            // Проверка, что cB_Cataloge и textBox_Thema не пусты
            if (!string.IsNullOrEmpty(cB_Cataloge.Text))
            {
                //удаление в БД
                string thema = cB_Cataloge.Text;
                DeleteThema(thema);

                // Удаление текста из cB_Cataloge
                cB_Cataloge.Items.Remove(cB_Cataloge.Text);

                var msg = new MsgBox($"Тема {thema} удалена успешно!", "Удаление темы теста");
                msg.ShowDialog();
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите тему и выберите каталог.");
            }
        }




    }
}
