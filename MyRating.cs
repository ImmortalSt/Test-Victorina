using MySqlConnector;
using System;
using System.Data;
using System.Windows.Forms;

namespace Test_Victorina
{
    public partial class MyRating : Form
    {
        private string _user;

        public MyRating(string login)
        {
            InitializeComponent();
            _user = login;

        }

        private void btn_Exit_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void MyRating_Load(object sender, EventArgs e)
        {
            // получение количества записей в БД
            int count = ValidateCountTest(_user);
            label_CountAll.Text = count.ToString();

            //заполнение рейтинга в DataGridView
            LoadRatingIntoDataGridView(_user);
        }

        //получение количества записей в БД
        private static int ValidateCountTest(string user)
        {
            string connect = @"Server = 141.8.192.217; DataBase = a1153826_test; User ID = a1153826_test; Password = sev09rus";

            int count = 0;
            try
            {
                using (var connection = new MySqlConnection(connect))
                {
                    connection.Open();

                    string selectSql = @"SELECT COUNT(*) 
                                FROM Result r
                                INNER JOIN LoginPassword lg ON lg.ID = r.ID_User
                                WHERE lg.Name_User = @user";

                    using (var command = new MySqlCommand(selectSql, connection))
                    {
                        // Добавляем параметр ДО выполнения запроса
                        command.Parameters.AddWithValue("@user", user.Trim());

                        // Используем ExecuteScalar для получения одного значения
                        var result = command.ExecuteScalar();

                        if (result != null)
                        {
                            count = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при получении данных: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return count;
        }

        //добавление в данных о рейтинге
        private void LoadRatingIntoDataGridView(string user)
        {
            string connect = @"Server = 141.8.192.217; DataBase = a1153826_test; User ID = a1153826_test; Password = sev09rus";

            using (var connection = new MySqlConnection(connect))
            {
                connection.Open();
                string selectSql = @"SELECT
                                        lg.Name_User AS ""Участник"",
                                        c.Thema AS ""Тема теста"",
                                        r.RAnswerUser AS ""Верных ответов"",
                                        r.AnswerUser AS ""Неверных ответов"",
                                        r.Prosent AS ""Результат, %""
                                    FROM Result r
                                    INNER JOIN LoginPassword lg ON r.ID_User = lg.ID
                                    INNER JOIN Cataloge c ON r.ID_Cat = c.ID_Cat
                                    WHERE lg.Name_User = @user                                    
                                    ORDER BY r.Prosent DESC";

                using (var command = new MySqlCommand(selectSql, connection))
                {
                    command.Parameters.AddWithValue("@user", user);

                    using (var adapter = new MySqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        DataGridViewUsers.DataSource = dataTable;
                    }
                }
            }

        }
    }
}
