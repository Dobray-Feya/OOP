namespace Arkashova.Minesweeper.View
{
    public partial class WinnerWindow : Form
    {
        public WinnerWindow()
        {
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
