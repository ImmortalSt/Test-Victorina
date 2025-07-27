using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Test_Victorina
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        //добавление темы в Каталог
        private static void AddCataloge(string thema)
        {
            string connect = @"Server = 141.8.192.217; DataBase = a1153826_test; User ID = a1153826_test; Password = sev09rus";
            using (var connection = new MySqlConnection(connect))
            {
                connection.Open();
                string insertSql = "INSERT INTO Cataloge (Thema) VALUES (@thema)";
                using (var command = new MySqlCommand(insertSql, connection))
                {
                    command.Parameters.AddWithValue("@thema", thema);

                    command.ExecuteNonQuery();
                }
            }
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

        //получение из БД ID темы
        private static int ValidateTheme(string thema)
        {
            string connect = @"Server = 141.8.192.217; DataBase = a1153826_test; User ID = a1153826_test; Password = sev09rus";

            int id_cat = 0;
            using (var connection = new MySqlConnection(connect))
            {
                connection.Open();
                string selectCataloge = "SELECT ID_Cat FROM Cataloge WHERE Thema = @thema";
                using (var command = new MySqlCommand(selectCataloge, connection))
                {
                    command.Parameters.AddWithValue("@thema", thema);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            id_cat = reader.GetInt32(0);
                        }
                    }
                }

            }
            return id_cat;
        }

        //добавление вопроса в БД
        private static void AddQuestion(string ques, int id_cat)
        {
            string connect = @"Server = 141.8.192.217; DataBase = a1153826_test; User ID = a1153826_test; Password = sev09rus";

            using (var connection = new MySqlConnection(connect))
            {
                connection.Open();
                string insertSql = "INSERT INTO Question (Quest, ID_Cat) VALUES (@ques, @id_cat)";
                using (var command = new MySqlCommand(insertSql, connection))
                {
                    command.Parameters.AddWithValue("@ques", ques);
                    command.Parameters.AddWithValue("@id_cat", id_cat);
                    command.ExecuteNonQuery();
                }
            }
        }

        //получение из БД ID вопроса
        private static int ValidateQues(string ques)
        {
            string connect = @"Server = 141.8.192.217; DataBase = a1153826_test; User ID = a1153826_test; Password = sev09rus";

            int id_ques = 0;
            using (var connection = new MySqlConnection(connect))
            {
                connection.Open();
                string selectCataloge = "SELECT ID_Quest FROM Question WHERE Quest = @ques";
                using (var command = new MySqlCommand(selectCataloge, connection))
                {
                    command.Parameters.AddWithValue("@ques", ques);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            id_ques = reader.GetInt32(0);
                        }
                    }
                }

            }
            return id_ques;
        }

        //добавление ответа на вопрос в БД
        private static void AddAnswer(string answ, int id_ques)
        {
            string connect = @"Server = 141.8.192.217; DataBase = a1153826_test; User ID = a1153826_test; Password = sev09rus";

            using (var connection = new MySqlConnection(connect))
            {
                connection.Open();
                string insertSql = "INSERT INTO Answer (Answ_Option, ID_Ques) VALUES (@answ, @id_ques)";
                using (var command = new MySqlCommand(insertSql, connection))
                {
                    command.Parameters.AddWithValue("@answ", answ);
                    command.Parameters.AddWithValue("@id_ques", id_ques);
                    command.ExecuteNonQuery();
                }
            }
        }

        //добавление правильного ответа на вопрос в БД
        private static void AddRAnswer(string RAnsw, int id_quest)
        {
            string connect = @"Server = 141.8.192.217; DataBase = a1153826_test; User ID = a1153826_test; Password = sev09rus";

            using (var connection = new MySqlConnection(connect))
            {
                connection.Open();
                string insertSql = "INSERT INTO RightAnswer (RAnsw,ID_Quest) VALUES (@RAnsw, @id_quest)";
                using (var command = new MySqlCommand(insertSql, connection))
                {
                    command.Parameters.AddWithValue("@RAnsw", RAnsw);
                    command.Parameters.AddWithValue("@id_quest", id_quest);
                    command.ExecuteNonQuery();
                }
            }
        }


        private void cB_Cataloge_SelectedIndexChanged(object sender, EventArgs e)
        {
            // использовать для обработки изменения выбранного элемента в ComboBox


        }

        private void Admin_Load(object sender, EventArgs e)
        {
            cB_Cataloge.DropDownStyle = ComboBoxStyle.DropDownList; // нельзя написать в ячейке тема теста

            // получение всех тем из каталога
            List<string> catalogeItems = ValidateCataloge();
            cB_Cataloge.Items.AddRange(catalogeItems.ToArray());
        }

        private void btn_Cataloge_Click(object sender, EventArgs e)
        {
            // Проверка, что cB_Cataloge и textBox_Thema не пусты
            if (!string.IsNullOrEmpty(textBox_Thema.Text))
            {
                // Добавление текста из textBox_Thema в cB_Cataloge.Items
                cB_Cataloge.Items.Add(textBox_Thema.Text);

                //запись в БД
                string thema = textBox_Thema.Text;
                AddCataloge(thema);

                // Очистка textBox_Thema после добавления
                textBox_Thema.Clear();
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите тему и выберите каталог.");
            }

        }

        private void textBox_Thema_TextChanged(object sender, EventArgs e)
        {
            //string thema = textBox_Thema.Text;
        }

        //добавление вопроса в БД
        private void btn_Ques_Click(object sender, EventArgs e)
        {
            string ques = textBox_Ques.Text;
            string thema = cB_Cataloge.Text;
            int id_cat = ValidateTheme(thema);
            if (!string.IsNullOrEmpty(ques) && !string.IsNullOrEmpty(thema) && id_cat > 0)
            {
                AddQuestion(ques, id_cat);
                MessageBox.Show("Вопрос успешно добавлен.");
                btn_Ques.Enabled = false;

            }
            else
            {
                MessageBox.Show("Пожалуйста, введите вопрос и выберите тему.");
            }
        }

        //добавление ответа
        private void btn_Answ_Click(object sender, EventArgs e)
        {
            string ques = textBox_Ques.Text;
            string answ1 = tB_Answ1.Text;
            string answ2 = tB_Answ2.Text;
            string answ3 = tB_Answ3.Text;
            int id_ques = ValidateQues(ques);
            if (!string.IsNullOrEmpty(ques) && !string.IsNullOrEmpty(answ1) && !string.IsNullOrEmpty(answ2) && !string.IsNullOrEmpty(answ3) && id_ques > 0)
            {
                AddAnswer(answ1, id_ques);
                AddAnswer(answ2, id_ques);
                AddAnswer(answ3, id_ques);
                MessageBox.Show("Ответы успешно добавлены.");
                btn_Answ.Enabled = false;
            }
            else
            {
                MessageBox.Show("Вопрос не найден. Пожалуйста, добавьте вопрос сначала.");
            }
        }

        //добавить правильные ответы
        private void btn_RAnsw_Click(object sender, EventArgs e)
        {
            string ques = textBox_Ques.Text;
            string RAnsw1Text = tB_RAnsw1.Text;
            string RAnsw2Text = tB_RAnsw2.Text;
            int id_ques = ValidateQues(ques);
            if (!string.IsNullOrEmpty(ques) && !string.IsNullOrEmpty(RAnsw1Text) && !string.IsNullOrEmpty(RAnsw2Text) && id_ques > 0)
            {
                AddRAnswer(RAnsw1Text, id_ques);
                AddRAnswer(RAnsw2Text, id_ques);
                MessageBox.Show("Правильне ответы успешно добавлены.");
                textBox_Ques.Clear();
                tB_Answ1.Clear();
                tB_Answ2.Clear();
                tB_Answ3.Clear();
                tB_RAnsw1.Clear();
                tB_RAnsw2.Clear();
                btn_Ques.Enabled = true;
                btn_Answ.Enabled = true;
            }
            else if (!string.IsNullOrEmpty(ques) && !string.IsNullOrEmpty(RAnsw1Text) && id_ques > 0)
            {
                AddRAnswer(RAnsw1Text, id_ques);
                MessageBox.Show("Правильне ответы успешно добавлены.");
                textBox_Ques.Clear();
                tB_Answ1.Clear();
                tB_Answ2.Clear();
                tB_Answ3.Clear();
                tB_RAnsw1.Clear();
                tB_RAnsw2.Clear();
                btn_Ques.Enabled = true;
                btn_Answ.Enabled = true;
            }
            else if (!string.IsNullOrEmpty(ques) && !string.IsNullOrEmpty(RAnsw2Text) && id_ques > 0)
            {
                AddRAnswer(RAnsw2Text, id_ques);
                MessageBox.Show("Правильне ответы успешно добавлены.");
                textBox_Ques.Clear();
                tB_Answ1.Clear();
                tB_Answ2.Clear();
                tB_Answ3.Clear();
                tB_RAnsw1.Clear();
                tB_RAnsw2.Clear();
                btn_Ques.Enabled = true;
                btn_Answ.Enabled = true;
            }
            else
            {
                MessageBox.Show("Вопрос не найден. Пожалуйста, добавьте вопрос сначала.");
            }

        }

        //выход
        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btn_DelThema_Click(object sender, EventArgs e)
        {
            AdminDelete adminDel = new AdminDelete();
            adminDel.ShowDialog();


            //// выбор темы из ComboBox
            //string selectedThema = cB_Cataloge.SelectedItem?.ToString();

            //if (!string.IsNullOrEmpty(selectedThema))
            //{
            //    // Удаление темы из базы данных
            //    DeleteThema(selectedThema);

            //    // Удаление темы из ComboBox
            //    cB_Cataloge.Items.Remove(selectedThema);

            //    MessageBox.Show("Тема успешно удалена.");
            //}
            //else
            //{
            //    MessageBox.Show("Пожалуйста, выберите тему для удаления.");
            //}
        }

    }

}
