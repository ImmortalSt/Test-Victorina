using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Test_Victorina
{
    public partial class Test : Form
    {
        // Сохраняем ссылку на существующую форму входа
        private string _login;

        // Конструктор для передачи ссылки на форму
        public Test(string login)
        {
            InitializeComponent();
            _login = login;
            label_User.Text = login;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Test_Load(object sender, EventArgs e)
        {
            cB_Cataloge.DropDownStyle = ComboBoxStyle.DropDownList; // нельзя написать в ячейке тема теста

            // получение всех тем из каталога
            List<string> catalogeItems = ValidateCataloge();
            cB_Cataloge.Items.AddRange(catalogeItems.ToArray());

            // обработчик события для изменения выбранной темы
            cB_Cataloge.SelectedIndexChanged += cB_Cataloge_SelectedIndexChanged;

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

        // обработчик события для изменения выбранной темы
        private void cB_Cataloge_SelectedIndexChanged(object sender, EventArgs e)
        {
            string thema = cB_Cataloge.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(thema))
            {
                int count = ValidateCountToThema(thema);
                label_Count.Text = count.ToString();

            }
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
                            int a = 0;
                        }
                    }
                }
            }

            return questions;
        }

        //получение списка ответов
        private static List<string> GetAnswerByThema(string thema, string question)
        {
            string connect = @"Server = 141.8.192.217; DataBase = a1153826_test; User ID = a1153826_test; Password = sev09rus";

            List<string> answer = new List<string>();
            using (var connection = new MySqlConnection(connect))
            {
                connection.Open();
                string selectQuestions = @"SELECT Answer.Answ_Option 
                                            FROM Question
                                            INNER JOIN Answer ON Answer.ID_Ques = Question.ID_Quest
                                            INNER JOIN Cataloge ON Question.ID_Cat = Cataloge.ID_Cat
                                            WHERE Cataloge.Thema = @thema 
                                            AND Question.Quest = @question";
                using (var command = new MySqlCommand(selectQuestions, connection))
                {
                    command.Parameters.AddWithValue("@thema", thema);
                    command.Parameters.AddWithValue("@question", question);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            answer.Add(reader.GetString(0));
                        }
                    }
                }
            }

            return answer;
        }

        //получить правильный ответ
        private static List<string> GetRightAnswerByThema(string thema, string question)
        {
            string connect = @"Server = 141.8.192.217; DataBase = a1153826_test; User ID = a1153826_test; Password = sev09rus";

            List<string> RAnswer = new List<string>();
            using (var connection = new MySqlConnection(connect))
            {
                connection.Open();
                string selectQuestions = @"SELECT RightAnswer.RAnsw
                                            FROM Question
                                            INNER JOIN Cataloge ON Question.ID_Cat = Cataloge.ID_Cat
                                            INNER JOIN Answer ON Answer.ID_Ques = Question.ID_Quest
                                            INNER JOIN RightAnswer ON RightAnswer.RAnsw = Answer.Answ_Option
                                            WHERE Cataloge.Thema = @thema AND Question.Quest = @question";
                using (var command = new MySqlCommand(selectQuestions, connection))
                {
                    command.Parameters.AddWithValue("@thema", thema);
                    command.Parameters.AddWithValue("@question", question);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            RAnswer.Add(reader.GetString(0));
                        }
                    }
                }
            }

            return RAnswer;
        }

        // Получить ID пользователя
        private int GetIDUser()
        {
            string user = _login;

            if (string.IsNullOrEmpty(user))
            {
                throw new InvalidOperationException("Логин не указан");
            }

            int idUser = 0;

            // код для получения ID пользователя
            string connect = @"Server = 141.8.192.217; DataBase = a1153826_test; User ID = a1153826_test; Password = sev09rus";

            using (var connection = new MySqlConnection(connect))
            {
                connection.Open();
                string selectID = @"SELECT ID FROM LoginPassword
                                    WHERE LoginPassword.Name_User = @login";

                var command = new MySqlCommand(selectID, connection);
                command.Parameters.AddWithValue("@login", user);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        idUser = reader.GetInt32(0);
                    }
                }
            }
            return idUser;
        }

        // Получить ID темы
        private int GetIDThema()
        {
            // Получаем логин из существующей формы
            string thema = cB_Cataloge.SelectedItem?.ToString();
            int idCat = 0;

            // код для получения ID темы
            string connect = @"Server = 141.8.192.217; DataBase = a1153826_test; User ID = a1153826_test; Password = sev09rus";

            using (var connection = new MySqlConnection(connect))
            {
                connection.Open();
                string selectID = @"SELECT ID_Cat FROM Cataloge
                                    WHERE Cataloge.Thema = @thema";

                var command = new MySqlCommand(selectID, connection);
                command.Parameters.AddWithValue("@Thema", thema);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        idCat = reader.GetInt32(0);
                    }

                }
            }
            return idCat;
        }

        //записать результат в БД
        private void SaveResult(int RAnswerUser, int AnswerUser, float result, int idCat, int idUser)
        {
            string connect = @"Server = 141.8.192.217; DataBase = a1153826_test; User ID = a1153826_test; Password = sev09rus";

            //string thema = cB_Cataloge.SelectedItem?.ToString();
            idCat = GetIDThema();

            using (var connection = new MySqlConnection(connect))
            {
                connection.Open();

                string insertResult = @"INSERT INTO Result (RAnswerUser, AnswerUser, Prosent, ID_User, ID_Cat)
                                            VALUES(@RAnswerUser, @AnswerUser, @Prosent, @ID_User, @ID_Cat)";

                using (var insertcmd = new MySqlCommand(insertResult, connection))
                {
                    insertcmd.Parameters.AddWithValue("@RAnswerUser", RAnswerUser);
                    insertcmd.Parameters.AddWithValue("@AnswerUser", AnswerUser);
                    insertcmd.Parameters.AddWithValue("@Prosent", result);
                    insertcmd.Parameters.AddWithValue("@ID_Cat", idCat);
                    insertcmd.Parameters.AddWithValue("@ID_User", idUser);

                    insertcmd.ExecuteNonQuery();
                }
            }

        }

        private int currentQuestionIndex = 0;
        private List<string> currentQuestions;          //список ответов
        private List<string> currentAnswers;            //список вопросов
        private List<string> currentRightAnswers;       //список правильных ответов
        private int AnswerUser = 0;                     //список ответов пользователя
        private int RAnswerUser = 0;                    //список правильных ответов пользователя

        //начать тест
        private void btn_Start_Click(object sender, EventArgs e)
        {
            string thema = cB_Cataloge.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(thema))
            {
                int count = ValidateCountToThema(thema);
                label_Count.Text = count.ToString();

                currentQuestions = GetQuestionsByThema(thema); //получение списка вопросов по теме

                if (currentQuestions.Count > 0)
                {
                    currentQuestionIndex = 0;
                    ShowNextQuestion();
                }
                else
                {
                    var msgError = new MsgBoxError("Нет вопросов для выбранной темы", "Выбор вопросов");
                    msgError.ShowDialog();
                    //MessageBox.Show("Нет вопросов для выбранной темы.");
                }
            }
            else
            {
                var msgError = new MsgBoxError("Выберите тему для теста", "Выбор темы");
                msgError.ShowDialog();
                //MessageBox.Show("Выберите тему для теста");
            }
        }

        //показ следующего вопроса
        private void ShowNextQuestion()
        {
            if (currentQuestionIndex < currentQuestions.Count)
            {
                string question = currentQuestions[currentQuestionIndex];
                currentAnswers = GetAnswerByThema(cB_Cataloge.SelectedItem.ToString(), question); //получение списка ответов на вопрос по теме
                currentRightAnswers = GetRightAnswerByThema(cB_Cataloge.SelectedItem.ToString(), question); //получение списка правильных ответов на вопрос по теме

                label_CountQues.Text = (currentQuestionIndex + 1).ToString();
                label_Question.Text = question;

                if (currentAnswers.Count > 0)
                {
                    checkBox1.Text = currentAnswers.Count > 0 ? currentAnswers[0] : string.Empty;
                    checkBox2.Text = currentAnswers.Count > 1 ? currentAnswers[1] : string.Empty;
                    checkBox3.Text = currentAnswers.Count > 2 ? currentAnswers[2] : string.Empty;
                }

                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                label_RAnsw1.Text = string.Empty;
                label_RAnsw2.Text = string.Empty;
            }
            else
            {
                string thema = cB_Cataloge.SelectedItem?.ToString();
                int count = ValidateCountToThema(thema);
                float result = 100 * RAnswerUser / (float)count;

                int idUser = GetIDUser();
                int idCat = GetIDThema();
                SaveResult(RAnswerUser, AnswerUser, result, idCat, idUser);

                var msg = new MsgBox($"Тест завершен.\nВаш результат: {result} %", "Результат");
                msg.ShowDialog();
                //MessageBox.Show($"Тест завершен.\nВаш результат: {result} %");
            }
        }

        private void btn_Answ_Click(object sender, EventArgs e)
        {
            if (currentQuestionIndex < currentQuestions.Count)
            {
                List<string> selectedAnswers = new List<string>();

                if (checkBox1.Checked)
                {
                    selectedAnswers.Add(checkBox1.Text);
                }
                if (checkBox2.Checked)
                {
                    selectedAnswers.Add(checkBox2.Text);
                }
                if (checkBox3.Checked)
                {
                    selectedAnswers.Add(checkBox3.Text);
                }

                bool allCorrect = true;
                foreach (var answer in selectedAnswers)
                {
                    if (!currentRightAnswers.Contains(answer))
                    {
                        allCorrect = false;
                        break;
                    }
                }

                if (allCorrect)
                {
                    // Отображение правильных ответов
                    if (currentRightAnswers.Count > 0)
                    {
                        label_RAnsw1.Text = currentRightAnswers[0];
                    }
                    if (currentRightAnswers.Count > 1)
                    {
                        label_RAnsw2.Text = currentRightAnswers[1];
                    }
                    RAnswerUser++;
                    var msg = new MsgBox("Правильный ответ", "Результат");
                    msg.ShowDialog();
                    //MessageBox.Show("Правильный ответ!");
                }
                else
                {
                    AnswerUser++;
                    var msgError = new MsgBoxError("Неправильный ответ", "Результат");
                    msgError.ShowDialog();
                    //MessageBox.Show("Неправильный ответ.");
                }

                currentQuestionIndex++;

                ShowNextQuestion();
            }
        }



    }
}
