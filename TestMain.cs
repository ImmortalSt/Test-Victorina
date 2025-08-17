using System;
using System.Windows.Forms;

namespace Test_Victorina
{
    public partial class TestMain : Form
    {
        private string _login;
        private bool _admin = false;

        // Конструктор для передачи ссылки на форму
        public TestMain(string login, bool admin)
        {
            InitializeComponent();
            _login = login;
            label_User.Text = login;
            _admin = admin;

            if (!_admin)
            {
                label4.Visible = false;
                button_Admin.Visible = false;
            }
            else
            {
                label4.Visible = true;
                button_Admin.Visible = true;
            }

        }



        private void button_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void button_Admin_Click(object sender, EventArgs e)
        {
            Hide();
            Password password = new Password(_login, _admin);
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
