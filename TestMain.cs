using System;
using System.Windows.Forms;

namespace Test_Victorina
{
    public partial class TestMain : Form
    {
        public TestMain()
        {
            InitializeComponent();
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Admin_Click(object sender, EventArgs e)
        {
            Password password = new Password();
            password.ShowDialog();
        }

        private void button_Test_Click(object sender, EventArgs e)
        {
            Test test = new Test();
            test.ShowDialog();
        }
    }
}
