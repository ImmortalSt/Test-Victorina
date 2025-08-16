using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Test_Victorina
{
    public partial class AdminRedaction : Form
    {
        private string _login;

        private List<string> currentQuest;            //список вопросов
        private List<string> currentAnw;              //список ответов
        private List<string> currentRAnw;             //список правильных ответов
        private int selectedQuestionId;

        public AdminRedaction(string login)
        {
            InitializeComponent();
            _login = login;
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

        private void AdminRedaction_Load(object sender, EventArgs e)
        {
            cB_Cataloge.DropDownStyle = ComboBoxStyle.DropDownList;

            // Получение всех тем
            List<string> catalogeItems = ValidateCataloge();
            cB_Cataloge.Items.AddRange(catalogeItems.ToArray());

            // Подписка на событие изменения выбранной темы
            cB_Cataloge.SelectedIndexChanged += (s, ev) => AddQuestion(null, CheckState.Unchecked);

            // обработчик для выбора вопроса
            checkedLB_Quest.SelectedIndexChanged += (s, ev) => AddAnswer();

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

        private void AddQuestion(object item, CheckState check)
        {
            string thema = cB_Cataloge.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(thema))
            {
                int count = ValidateCountToThema(thema);

                if (count > 0)
                {
                    currentQuest = GetQuestionsByThema(thema);

                    // Очистка существующего списка перед добавлением новых элементов
                    checkedLB_Quest.Items.Clear();

                    // Добавление всех вопросов в CheckedListBox
                    foreach (var question in currentQuest)
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



        //добавление вариантов ответов и правильных ответов по выбранному вопросу
        private void AddAnswer()
        {
            // Получаем выбранный вопрос
            if (checkedLB_Quest.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите вопрос");
                return;
            }

            string selectedQuestion = checkedLB_Quest.SelectedItem.ToString();
            string thema = cB_Cataloge.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(thema))
            {
                MessageBox.Show("Пожалуйста, выберите тему теста");
                return;
            }

            try
            {
                // Получаем ID вопроса
                selectedQuestionId = GetQuestionId(selectedQuestion, thema);
                if (selectedQuestionId <= 0)
                {
                    throw new Exception("Вопрос не найден в базе данных");
                }

                // Заполняем текстовые поля
                textBox_Ques.Text = selectedQuestion;

                // Получаем варианты ответов
                currentAnw = GetQuestionsAnswer(selectedQuestionId);
                tB_Answ1.Text = currentAnw.Count > 0 ? currentAnw[0] : "";
                tB_Answ2.Text = currentAnw.Count > 1 ? currentAnw[1] : "";
                tB_Answ3.Text = currentAnw.Count > 2 ? currentAnw[2] : "";

                // Получаем правильные ответы
                currentRAnw = GetQuestionsRAnswer(selectedQuestionId);
                tB_RAnsw1.Text = currentRAnw.Count > 0 ? currentRAnw[0] : "";
                tB_RAnsw2.Text = currentRAnw.Count > 1 ? currentRAnw[1] : "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при получении данных: {ex.Message}");
            }

        }

        // Получение ID вопроса по тексту и теме
        private int GetQuestionId(string question, string thema)
        {
            string connect = @"Server = 141.8.192.217; DataBase = a1153826_test; User ID = a1153826_test; Password = sev09rus";

            using (var connection = new MySqlConnection(connect))
            {
                connection.Open();
                string query = @"SELECT q.ID_Quest 
                                    FROM Question q
                                    INNER JOIN Cataloge c ON q.ID_Cat = c.ID_Cat
                                    WHERE q.Quest = @question AND c.Thema = @thema";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@question", question);
                    command.Parameters.AddWithValue("@thema", thema);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.GetInt32(0);
                        }
                    }
                }
            }
            return 0;
        }

        // Получение списка вариантов ответов
        private List<string> GetQuestionsAnswer(int questionId)
        {
            string connect = @"Server = 141.8.192.217; DataBase = a1153826_test; User ID = a1153826_test; Password = sev09rus";
            List<string> answers = new List<string>();

            using (var connection = new MySqlConnection(connect))
            {
                connection.Open();
                string query = @"SELECT Answ_Option 
                                    FROM Answer 
                                    WHERE ID_Ques = @questionId";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@questionId", questionId);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            answers.Add(reader.GetString(0));
                        }
                    }
                }
            }
            return answers;
        }

        // Получение списка правильных ответов
        private List<string> GetQuestionsRAnswer(int questionId)
        {
            string connect = @"Server = 141.8.192.217; DataBase = a1153826_test; User ID = a1153826_test; Password = sev09rus";

            List<string> RAnswers = new List<string>();

            using (var connection = new MySqlConnection(connect))
            {
                connection.Open();
                string query = @"SELECT RAnsw 
                                    FROM RightAnswer 
                                    WHERE ID_Quest = @questionId";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@questionId", questionId);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            RAnswers.Add(reader.GetString(0));
                        }
                    }
                }
            }
            return RAnswers;

        }

        // обновить вопрос + варианты ответов + правильные ответы
        private static void UpdateQuestion(string questionText, string newquestionText, string thema, string[] answers, string[] rightAnswers)
        {
            // Проверка, что текст вопроса не пустой
            if (string.IsNullOrWhiteSpace(questionText) || string.IsNullOrWhiteSpace(newquestionText))
            {
                MessageBox.Show("Пожалуйста, введите текст вопроса", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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
                    command.Parameters.AddWithValue("@question", questionText.Trim());
                    command.Parameters.AddWithValue("@thema", thema.Trim());

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
                    throw new Exception($"Вопрос '{questionText}' не найден в теме '{thema}'");
                }

                // Обновляем сам вопрос
                string updateQuestionSql = @"UPDATE Question 
                                    SET Quest = @newQuestionText 
                                    WHERE ID_Quest = @id";

                using (var command = new MySqlCommand(updateQuestionSql, connection))
                {
                    command.Parameters.AddWithValue("@newQuestionText", newquestionText.Trim());
                    command.Parameters.AddWithValue("@id", questionId);
                    command.ExecuteNonQuery();
                }

                // Удаляем старые ответы
                string deleteAnswersSql = @"DELETE FROM Answer WHERE ID_Ques = @id";
                string deleteRightAnswersSql = @"DELETE FROM RightAnswer WHERE ID_Quest = @id";

                using (var deleteCommand = new MySqlCommand(deleteAnswersSql, connection))
                {
                    deleteCommand.Parameters.AddWithValue("@id", questionId);
                    deleteCommand.ExecuteNonQuery();
                }

                using (var deleteRightCommand = new MySqlCommand(deleteRightAnswersSql, connection))
                {
                    deleteRightCommand.Parameters.AddWithValue("@id", questionId);
                    deleteRightCommand.ExecuteNonQuery();
                }

                // Добавляем новые ответы
                string insertAnswerSql = @"INSERT INTO Answer (ID_Ques, Answ_Option) 
                                 VALUES (@id, @answer)";
                using (var insertCommand = new MySqlCommand(insertAnswerSql, connection))
                {
                    insertCommand.Parameters.AddWithValue("@id", questionId);
                    insertCommand.Parameters.AddWithValue("@answer", "");

                    foreach (var answer in answers)
                    {
                        if (!string.IsNullOrWhiteSpace(answer))
                        {
                            insertCommand.Parameters["@answer"].Value = answer.Trim();
                            insertCommand.ExecuteNonQuery();
                        }
                    }
                }

                // Добавляем новые правильные ответы
                string insertRightAnswerSql = @"INSERT INTO RightAnswer (ID_Quest, RAnsw) 
                                       VALUES (@id, @rightAnswer)";
                using (var insertRightCommand = new MySqlCommand(insertRightAnswerSql, connection))
                {
                    insertRightCommand.Parameters.AddWithValue("@id", questionId);
                    insertRightCommand.Parameters.AddWithValue("@rightAnswer", "");

                    foreach (var rightAnswer in rightAnswers)
                    {
                        if (!string.IsNullOrWhiteSpace(rightAnswer))
                        {
                            insertRightCommand.Parameters["@rightAnswer"].Value = rightAnswer.Trim();
                            insertRightCommand.ExecuteNonQuery();
                        }
                    }
                }

            }
        }

        private void btn_RedactQuest_Click(object sender, EventArgs e)
        {
            try
            {
                // Получаем тему
                string thema = cB_Cataloge.SelectedItem?.ToString() ?? string.Empty;
                if (string.IsNullOrWhiteSpace(thema))
                {
                    MessageBox.Show("Пожалуйста, выберите тему", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Получаем старый текст вопроса из CheckedListBox
                string questionText = GetSelectedQuestionText();
                if (string.IsNullOrWhiteSpace(questionText))
                {
                    MessageBox.Show("Пожалуйста, выберите вопрос для редактирования", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Получаем новый текст вопроса
                string newQuestionText = textBox_Ques.Text.Trim();
                if (string.IsNullOrWhiteSpace(newQuestionText))
                {
                    MessageBox.Show("Пожалуйста, введите новый текст вопроса", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Получаем варианты ответов
                string[] answers = new string[]
                {
                    tB_Answ1.Text.Trim(),
                    tB_Answ2.Text.Trim(),
                    tB_Answ3.Text.Trim()
                };

                // Получаем правильные ответы
                string[] rightAnswers = new string[]
                {
                    tB_RAnsw1.Text.Trim(),
                    tB_RAnsw2.Text.Trim()
                };

                UpdateQuestion(questionText, newQuestionText, thema, answers, rightAnswers);
                var msg = new MsgBox("Вопрос обновлен успешно", "Обновление вопроса");
                msg.ShowDialog();

                // Очищаем данные
                textBox_Ques.Text = string.Empty;
                tB_Answ1.Text = string.Empty;
                tB_Answ2.Text = string.Empty;
                tB_Answ3.Text = string.Empty;
                tB_RAnsw1.Text = string.Empty;
                tB_RAnsw2.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Метод для получения выбранного вопроса из CheckedListBox
        private string GetSelectedQuestionText()
        {
            if (checkedLB_Quest.SelectedItem != null)
            {
                return checkedLB_Quest.SelectedItem.ToString().Trim();
            }
            return string.Empty;
        }



    }
}
