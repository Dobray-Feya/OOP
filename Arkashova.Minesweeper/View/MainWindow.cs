using Arkashova.Minesweeper.View;
using System.Data.Common;

namespace Arkashova.Minesweeper
{
    public partial class MainWindow : Form, IView
    {
        public Controller Controller { get; set; }

        public Image MineImage => Image.FromFile("..\\..\\..\\View\\Icons\\mine.png");

        public Image OpenedMineImage => Image.FromFile("..\\..\\..\\View\\Icons\\openedMine.png");

        public Image FlagImage => Image.FromFile("..\\..\\..\\View\\Icons\\flag.png");

        public Image WrongFlagImage => Image.FromFile("..\\..\\..\\View\\Icons\\wrongFlag.png");

        private Image _newGameImage = Image.FromFile("..\\..\\..\\View\\Icons\\newGame.png");

        private Image _winGameImage = Image.FromFile("..\\..\\..\\View\\Icons\\winGame.png");

        private Image _failGameImage = Image.FromFile("..\\..\\..\\View\\Icons\\failGame.png");

        private Image _closedCellImage = Image.FromFile("..\\..\\..\\View\\Icons\\closedCell.png");

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

            gameTable.Enabled = true;
            gameTable.Controls.Clear();

            gameTable.RowCount = rowCount;
            gameTable.ColumnCount = columnCount;

            var cellSize = 40;

            var tableWidth = cellSize * columnCount;
            var tableHeight = cellSize * rowCount;

            gameTable.Size = new Size(tableWidth, tableHeight);

            borderPanel.Width = tableWidth + 2;
            borderPanel.Height = tableHeight + 2;
            borderPanel.Visible = true;

            Width = tableWidth + 2 * 100;
            Height = tableHeight + 2 * 100 + 100;

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

            var button1 = FindButton(2, 2);
            button1.Image = _closedCellImage;
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
            button.Margin = new Padding(1, 1, 1, 1);
            button.Dock = DockStyle.Fill;
            button.TabStop = false;
            button.FlatAppearance.BorderSize = 1;
            button.FlatAppearance.BorderColor = Color.DarkGray;
            button.FlatStyle = FlatStyle.Flat;
            button.Image = _closedCellImage;
         }

        private void ApplyOpenedButtonStyle(Button button)
        {
            button.FlatStyle = FlatStyle.Standard;
            button.Image = null;
        }

        public bool IsCellClosed(int column, int row)
        {
            return FindButton(column, row).FlatStyle is FlatStyle.Flat; // считаю, что кнопка не была нажата, если у нее стиль остался Flat, как задано в ApplyClosedButtonStyle.
        }

        public void OpenCell(int column, int row, string text)
        {
            if (IsCellClosed(column, row))
            {
                var button = FindButton(column, row); 
                
                ApplyOpenedButtonStyle(button);

                button.Text = text;
            }
        }

        public void OpenCell(int column, int row, Image image)
        {
            if (IsCellClosed(column, row))
            {
                var button = FindButton(column, row); 
                
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

            for (int i = 0; i < gameTable.ColumnCount; i++)
            {
                for (int j = 0; j < gameTable.RowCount; j++)
                {
                    var button = FindButton(i, j);

                    button.Click -= new EventHandler(this.cell_Click!);
                }
            }
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

            var column = GetButtonColumn(button.Name);
            var raw = GetButtonRow(button.Name);

            if (IsCellClosed(column, raw))
            {
                Controller.OpenCell(column, raw);
            }
        }

        private void modesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitializeTextFields();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            var aboutWindow = new AboutWindow();

            aboutWindow.Show();
        }
    }
}