using MySqlConnector;
using System;
using System.Data;
using System.Windows.Forms;

namespace Test_Victorina
{
    public partial class AllRating : Form
    {
        public AllRating()
        {
            InitializeComponent();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AllRating_Load(object sender, EventArgs e)
        {
            // получение количества записей в БД
            int count = ValidateCountUsers();
            label_CountAll.Text = count.ToString();

            //заполнение рейтинга в DataGridView(
            LoadRatingIntoDataGridView();


        }

        //получение количества записей в БД
        private static int ValidateCountUsers()
        {
            string connect = @"Server = 141.8.192.217; DataBase = a1153826_test; User ID = a1153826_test; Password = sev09rus";

            int count = 0;
            using (var connection = new MySqlConnection(connect))
            {
                connection.Open();
                string selectCataloge = "SELECT COUNT(*) FROM Result";
                using (var command = new MySqlCommand(selectCataloge, connection))
                {
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

        //добавление в данных о рейтинге
        private void LoadRatingIntoDataGridView()
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
                                    ORDER BY r.Prosent DESC";

                using (var command = new MySqlCommand(selectSql, connection))
                {
                    using (var adapter = new MySqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        DataGridViewUsers.DataSource = dataTable;
                    }
                }
            }

        }

        //обновление рейтинга
        private void UpdateDataGridView()
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
                                    ORDER BY r.Prosent DESC";
                using (var command = new MySqlCommand(selectSql, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        DataGridViewUsers.DataSource = dataTable;
                    }
                }
            }
        }

        private void btn_UpDate_Click(object sender, EventArgs e)
        {
            UpdateDataGridView();
            int count = ValidateCountUsers();
            label_CountAll.Text = count.ToString();
        }
    }
}
