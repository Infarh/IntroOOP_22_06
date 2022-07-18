namespace WinFormsTestApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void ClickMeButton_Click(object sender, EventArgs e)
        {
            var message = MessageTextBox.Text;

            MessageBox.Show(message, "Сообщение!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            MessageTextBox.Clear();
            //MessageTextBox.Text = "";
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}