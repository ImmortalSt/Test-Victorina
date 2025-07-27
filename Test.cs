using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace Test_Victorina
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
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
            using (var connection = new SQLiteConnection(connect))
            {
                connection.Open();
                string selectCataloge = "SELECT Thema FROM Cataloge";
                using (var command = new SQLiteCommand(selectCataloge, connection))
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
            using (var connection = new SQLiteConnection(connect))
            {
                connection.Open();
                string selectCataloge = "SELECT COUNT() FROM Question INNER JOIN Cataloge ON Question.ID_Cat = Cataloge.ID_Cat WHERE Cataloge.Thema = @thema";
                using (var command = new SQLiteCommand(selectCataloge, connection))
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
            using (var connection = new SQLiteConnection(connect))
            {
                connection.Open();
                string selectQuestions = @"SELECT Question.Quest FROM Question INNER JOIN Cataloge ON Question.ID_Cat = Cataloge.ID_Cat
                                            WHERE Cataloge.Thema = @thema";
                using (var command = new SQLiteCommand(selectQuestions, connection))
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
            using (var connection = new SQLiteConnection(connect))
            {
                connection.Open();
                string selectQuestions = @"SELECT Answer.Answ_Option 
                                            FROM Question, Answer 
                                            INNER JOIN Cataloge ON Question.ID_Cat = Cataloge.ID_Cat
                                            WHERE Cataloge.Thema = @thema AND Answer.ID_Ques = Question.ID_Quest
                                            AND Question.Quest = @question";
                using (var command = new SQLiteCommand(selectQuestions, connection))
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
            using (var connection = new SQLiteConnection(connect))
            {
                connection.Open();
                string selectQuestions = @"SELECT RightAnswer.RAnsw
                                            FROM Question
                                            INNER JOIN Cataloge ON Question.ID_Cat = Cataloge.ID_Cat
                                            INNER JOIN Answer ON Answer.ID_Ques = Question.ID_Quest
                                            INNER JOIN RightAnswer ON RightAnswer.RAnsw = Answer.Answ_Option
                                            WHERE Cataloge.Thema = @thema AND Question.Quest = @question";
                using (var command = new SQLiteCommand(selectQuestions, connection))
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

        private int currentQuestionIndex = 0;
        private List<string> currentQuestions;
        private List<string> currentAnswers;
        private List<string> currentRightAnswers;

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
                    MessageBox.Show("Нет вопросов для выбранной темы.");
                }
            }
            else
            {
                MessageBox.Show("Выберите тему для теста");
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
            }
            else
            {
                MessageBox.Show("Тест завершен.");
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
                    MessageBox.Show("Правильный ответ!");
                }
                else
                {
                    MessageBox.Show("Неправильный ответ.");
                }

                currentQuestionIndex++;
                ShowNextQuestion();
            }
        }

       

    }
}
