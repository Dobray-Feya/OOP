namespace Arkashova.Minesweeper.View
{
    public partial class WinnerWindow : Form
    {
        public string? WinnerName { get; private set; } = "";

        public WinnerWindow(Point location)
        {
            Location = location;

            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(winnerNameTextBox.Text))
            {
                MessageBox.Show("Введите имя.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                winnerNameTextBox.Text = "";

                return;
            }

            WinnerName = winnerNameTextBox.Text;

            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            WinnerName = null;

            Close();
        }
    }
}
