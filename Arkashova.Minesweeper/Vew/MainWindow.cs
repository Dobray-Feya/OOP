using Arkashova.Minesweeper.View;

namespace Arkashova.Minesweeper
{
    public partial class MainWindow : Form, IView
    {
        public Controller Controller { get; set; }

        public Image MineImage => Image.FromFile("..\\..\\..\\Vew\\Icons\\mine.png");

        public Image OpenedMineImage => Image.FromFile("..\\..\\..\\Vew\\Icons\\openedMine.png");

        public Image FlagImage => Image.FromFile("..\\..\\..\\Vew\\Icons\\flag.png");

        public Image WrongFlagImage => Image.FromFile("..\\..\\..\\Vew\\Icons\\wrongFlag.png");

        private Image _newGameImage = Image.FromFile("..\\..\\..\\Vew\\Icons\\newGame.png");

        private Image _winGameImage = Image.FromFile("..\\..\\..\\Vew\\Icons\\winGame.png");

        private Image _failGameImage = Image.FromFile("..\\..\\..\\Vew\\Icons\\failGame.png");

        public MainWindow(Controller controller)
        {
            InitializeComponent();

            Controller = controller ?? throw new ArgumentNullException(nameof(controller));
        }

        public void InitializeGameModeSelector()
        {
            InitializeGameModesListBox();

            InitializeTextFields();
        }

        private void InitializeGameModesListBox()
        {
            var gameModesNames = Controller.GetGameModesNames();

            if (gameModesNames is null)
            {
                throw new ArgumentNullException(nameof(gameModesNames), "Не задано ни одного режима игры.");
            }

            foreach (var name in gameModesNames)
            {
                gameModesListBox.Items.Add(name);
            }

            var currentIndex = Controller.GetCurrentGameModeIndex();

            gameModesListBox.SelectedIndex = currentIndex;
        }

        private void InitializeTextFields()
        {
            var selectedIndex = GetSelectedGameModeIndex();

            widthTextBox.Text = Controller.GetTableWidth(selectedIndex).ToString();
            heightTextBox.Text = Controller.GetTableHeight(selectedIndex).ToString();
            minesCountTextBox.Text = Controller.GetMinesCount(selectedIndex).ToString();

            if (Controller.IsCustomGameMode(selectedIndex))
            {
                widthTextBox.Enabled = true;
                heightTextBox.Enabled = true;
                minesCountTextBox.Enabled = true;
            }
            else
            {
                widthTextBox.Enabled = false;
                heightTextBox.Enabled = false;
                minesCountTextBox.Enabled = false;
            }
        }

        public int GetSelectedGameModeIndex()
        {
            return gameModesListBox.SelectedIndex;
        }

        public int GetSelectedFieldWidth()
        {
            return Convert.ToInt32(widthTextBox.Text);
        }

        public int GetSelectedFieldHeight()
        {
            return Convert.ToInt32(heightTextBox.Text);
        }

        public int GetSelectedMinesCount()
        {
            return Convert.ToInt32(minesCountTextBox.Text);
        }

        public void InitializeGameTable(int columnCount, int rowCount)
        {
            if (columnCount < 1 || rowCount < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(columnCount) + nameof(rowCount), "Число строк и столбцов в таблице должно быть больше 1." +
                                                      $"Переданы значения: число строк {rowCount} и число столбцов {columnCount}.");
            }

            gameTable.Controls.Clear();

            gameTable.RowCount = rowCount;
            gameTable.ColumnCount = columnCount;

            var cellSize = 40;

            gameTable.Size = new Size(cellSize * columnCount, cellSize * rowCount);

            borderPanel.Size = gameTable.Size;
            borderPanel.Visible = true;

            gameTable.RowStyles.Clear();

            for (int i = 0; i < rowCount; i++)
            {
                gameTable.RowStyles.Add(new RowStyle(SizeType.Absolute, cellSize));
            }

            gameTable.ColumnStyles.Clear();

            for (int i = 0; i < columnCount; i++)
            {
                gameTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, cellSize));
            }

            for (int i = 0; i < columnCount; i++)
            {
                for (int j = 0; j < rowCount; j++)
                {
                    var button = new Button();
                    button.Name = GetButtonName(i, j);
                    ApplyClosedButtonStyle(button);

                    button.Click += new EventHandler(this.cell_Click!);

                    gameTable.Controls.Add(button, i, j);
                }
            }

            startGameButton.Image = _newGameImage;
        }

        private string GetButtonName(int column, int row)
        {
            return column.ToString() + "," + row.ToString();
        }

        private int GetButtonColumn(string name)
        {
            return Convert.ToInt32(name.Substring(0, name.IndexOf(',')));
        }

        private int GetButtonRow(string name)
        {
            var commaIndex = name.IndexOf(',');
            return Convert.ToInt32(name.Substring(commaIndex + 1, name.Length - 1 - commaIndex));
        }

        private Button FindButton(int column, int row)
        {
            return (Button)Controls.Find(GetButtonName(column, row), true)[0];
        }

        private void ApplyClosedButtonStyle(Button button)
        {
            button.Margin = new Padding(0, 0, 0, 0);
            button.Dock = DockStyle.Fill;
            button.TabStop = false;
            button.FlatStyle = FlatStyle.Standard;
        }

        private void ApplyOpenedButtonStyle(Button button)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 1;
            button.FlatAppearance.BorderColor = Color.DarkGray;
        }

        private bool IsCellClosed(Button button)
        {
            return button.FlatStyle is FlatStyle.Standard; // считаю, что кнопка не была нажата, если у нее стиль остался Standard, как задано в InitializeGameTable.
        }

        public void OpenCell(int column, int row, string text)
        {
            var button = FindButton(column, row);

            if (IsCellClosed(button))
            {
                ApplyOpenedButtonStyle(button);

                button.Text = text;
            }
        }

        public void OpenCell(int column, int row, Image image)
        {
            var button = FindButton(column, row);

            if (IsCellClosed(button))
            {
                ApplyOpenedButtonStyle(button);

                button.Image = image;
            }
        }

        public void ShowError(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void SuccessfullyCompleteGame()
        {
            startGameButton.Image = _winGameImage;
        }

        public void FailGame()
        {
            startGameButton.Image = _failGameImage;
        }

        private void widthTextBox_TextChanged(object sender, EventArgs e)
        {
            var textBox = (TextBox)sender;

            if (!int.TryParse(textBox.Text, out var result))
            {
                ShowError("Нужно ввести число.");

                textBox.Text = Controller.GetTableWidth(GetSelectedGameModeIndex()).ToString();
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            Controller.StartNewGame();
        }

        private void startGameButton_Click(object sender, EventArgs e)
        {
            Controller.StartNewGame();
        }

        private void cell_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;

            if (IsCellClosed(button))
            {
                Controller.OpenCell(GetButtonColumn(button.Name), GetButtonRow(button.Name));
            }
        }

        private void modesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitializeTextFields();
        }
    }
}