using System;
using System.Windows.Forms;

namespace Test_Victorina
{
    public partial class TestMain : Form
    {
        private string _login;

        // Конструктор для передачи ссылки на форму
        public TestMain(string login)
        {
            InitializeComponent();
            _login = login;
            label_User.Text = login;
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void button_Admin_Click(object sender, EventArgs e)
        {
            Hide();
            Password password = new Password(_login);
            password.ShowDialog();

        }

        private void button_Test_Click(object sender, EventArgs e)
        {
            Hide();
            Test test = new Test(_login);
            test.ShowDialog();
        }

        //показ рейтинга всех участников
        private void button_Reting_Click(object sender, EventArgs e)
        {
            AllRating allRating = new AllRating();
            allRating.ShowDialog();
        }

        //показать мой рейтинг
        private void button_MyReting_Click(object sender, EventArgs e)
        {
            MyRating myRating = new MyRating(_login);
            myRating.ShowDialog();
        }

        private void button_Resert_Click(object sender, EventArgs e)
        {
            Hide();
            Form1_Enter form1_Enter = new Form1_Enter();
            form1_Enter.ShowDialog();
        }
    }
}
