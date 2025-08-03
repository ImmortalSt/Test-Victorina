using System;
using System.Drawing;
using System.Windows.Forms;

namespace Test_Victorina
{
    public partial class MsgBox : Form
    {
        public MsgBox(string text, string caption)
        {
            InitializeComponent();

            label_MSG.Text = text;
            Text = caption;

            // Настройка шрифта
            label_MSG.Font = new Font("Segoe Script", 18, FontStyle.Bold);
        }



        private void button_OK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
