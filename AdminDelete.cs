using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Test_Victorina
{
    public partial class AdminDelete : Form
    {
        private string _login;

        public AdminDelete(string login)
        {
            InitializeComponent();
            _login = login;

        }

        private void AdminDelete_Load(object sender, EventArgs e)
        {
            cB_Cataloge.DropDownStyle = ComboBoxStyle.DropDownList;
            // Получение всех тем
            List<string> catalogeItems = ValidateCataloge();
            cB_Cataloge.Items.AddRange(catalogeItems.ToArray());

            // Подписка на событие изменения выбранной темы
            cB_Cataloge.SelectedIndexChanged += (s, ev) => AddQuestion(null, CheckState.Unchecked);
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
            int a = 0;
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

        private List<string> currentAnswers;            //список вопросов

        //получение списка вопросов
        private static List<string> GetQuestionsByThema(string thema)
        {
            string connect = @"Server = 141.8.192.217; DataBase = a1153826_test; User ID = a1153826_test; Password = sev09rus";

            List<string> questions = new List<string>();
            using (var connection = new MySqlConnection(connect))
            {
                connection.Open();
                string selectQuestions = @"SELECT Question.Quest FROM Question INNER JOIN Cataloge ON Question.ID_Cat = Cataloge.ID_Cat
                                            WHERE Cataloge.Thema = @thema";
                using (var command = new MySqlCommand(selectQuestions, connection))
                {
                    command.Parameters.AddWithValue("@thema", thema);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            questions.Add(reader.GetString(0));
                        }
                    }
                }
            }

            return questions;
        }

        //получить количество вопросов на заданную тему
        private static int ValidateCountToThema(string thema)
        {
            string connect = @"Server = 141.8.192.217; DataBase = a1153826_test; User ID = a1153826_test; Password = sev09rus";

            int count = 0;
            using (var connection = new MySqlConnection(connect))
            {
                connection.Open();
                string selectCataloge = "SELECT COUNT(*) FROM Question INNER JOIN Cataloge ON Question.ID_Cat = Cataloge.ID_Cat WHERE Cataloge.Thema = @thema";
                using (var command = new MySqlCommand(selectCataloge, connection))
                {
                    command.Parameters.AddWithValue("@thema", thema);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            count = reader.GetInt32(0);
                        }
                    }
                }

            }

            return count;
        }

        private void AddQuestion(object item, CheckState check)
        {
            string thema = cB_Cataloge.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(thema))
            {
                int count = ValidateCountToThema(thema);

                if (count > 0)
                {
                    currentAnswers = GetQuestionsByThema(thema);

                    // Очистка существующего списка перед добавлением новых элементов
                    checkedLB_Quest.Items.Clear();

                    // Добавление всех вопросов в CheckedListBox
                    foreach (var question in currentAnswers)
                    {
                        checkedLB_Quest.Items.Add(question, CheckState.Unchecked);
                    }
                }
                else
                {
                    var msgError = new MsgBoxError("Нет вопросов для выбранной темы", "Выбор вопросов");
                    msgError.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите тему из списка");
            }

        }

        //удаление вопроса из теста (выбранныый вопрос в checkedLB_Quest)

        //удалить из БД конкретный вопрос
        private static void DeleteQuestion(string questionText, string thema)
        {
            string connect = @"Server = 141.8.192.217; DataBase = a1153826_test; User ID = a1153826_test; Password = sev09rus";

            using (var connection = new MySqlConnection(connect))
            {
                connection.Open();

                // Находим ID вопроса по тексту и теме
                string getQuestionIdSql = @"SELECT q.ID_Quest 
                                  FROM Question q
                                  INNER JOIN Cataloge c ON q.ID_Cat = c.ID_Cat
                                  WHERE q.Quest = @question AND c.Thema = @thema";

                int questionId = 0;
                using (var command = new MySqlCommand(getQuestionIdSql, connection))
                {
                    command.Parameters.AddWithValue("@question", questionText);
                    command.Parameters.AddWithValue("@thema", thema);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            questionId = reader.GetInt32(0);
                        }
                    }
                }

                if (questionId == 0)
                {
                    throw new Exception("Вопрос не найден в базе данных");
                }

                // Удаляем связанные данные
                string deleteRightAnswerSql = @"DELETE FROM RightAnswer WHERE ID_Quest = @id";
                string deleteAnswerSql = @"DELETE FROM Answer WHERE ID_Ques = @id";
                string deleteQuestionSql = @"DELETE FROM Question WHERE ID_Quest = @id";

                using (var command = new MySqlCommand(deleteRightAnswerSql, connection))
                {
                    command.Parameters.AddWithValue("@id", questionId);
                    command.ExecuteNonQuery();
                }

                using (var command = new MySqlCommand(deleteAnswerSql, connection))
                {
                    command.Parameters.AddWithValue("@id", questionId);
                    command.ExecuteNonQuery();
                }

                using (var command = new MySqlCommand(deleteQuestionSql, connection))
                {
                    command.Parameters.AddWithValue("@id", questionId);
                    command.ExecuteNonQuery();
                }
            }
        }

        private void btn_DelQuest_Click(object sender, EventArgs e)
        {
            // выбран ли вопрос
            if (checkedLB_Quest.SelectedItems.Count == 0)
            {
                var msgError = new MsgBoxError("Пожалуйста, выберите вопрос для удаления", "Выбор вопросов");
                msgError.ShowDialog();
                //MessageBox.Show("Пожалуйста, выберите вопрос для удаления");
                return;
            }

            string selectedQuestion = checkedLB_Quest.SelectedItem.ToString();
            string thema = cB_Cataloge.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(thema))
            {
                var msgError = new MsgBoxError("Пожалуйста, выберите тему теста", "Выбор темы теста");
                msgError.ShowDialog();
                //MessageBox.Show("Пожалуйста, выберите тему теста");
                return;
            }

            try
            {
                DeleteQuestion(selectedQuestion, thema);

                // Удаляем выбранный элемент из списка
                checkedLB_Quest.Items.Remove(selectedQuestion);

                var msg = new MsgBox("Вопрос успешно удален", "Успех");
                msg.ShowDialog();
                //MessageBox.Show("Вопрос успешно удален", "Успех");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении вопроса: {ex.Message}");
            }
        }
    }
}
