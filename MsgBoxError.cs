using System.Drawing;
using System.Windows.Forms;

namespace Test_Victorina
{
    public partial class MsgBoxError : Form
    {
        public MsgBoxError(string text, string caption)
        {
            InitializeComponent();

            label_MSG.Text = text;
            Text = caption;

            // Настройка шрифта
            label_MSG.Font = new Font("Segoe Script", 14, FontStyle.Bold);
        }

        private void button_OK_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
