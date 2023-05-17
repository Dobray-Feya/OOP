using Arkashova.Minesweeper.Controller;
using Arkashova.Minesweeper.View;

namespace Arkashova.Minesweeper
{
    public partial class MainWindow : Form, IView 
    {
        public MinesweeperController Controller { get; set; }

        private const string IMAGES_FOLDER = "..\\..\\..\\View\\Icons\\";

        private Image _mineImage => Image.FromFile(IMAGES_FOLDER + "mine.png");

        private Image _explodedMineImage => Image.FromFile(IMAGES_FOLDER + "explodedMine.png");

        private Image _flagImage => Image.FromFile(IMAGES_FOLDER + "flag.png");

        private Image _wrongFlagImage => Image.FromFile(IMAGES_FOLDER + "wrongFlag.png");

        private Image _newGameImage = Image.FromFile(IMAGES_FOLDER + "newGame.png");

        private Image _winGameImage = Image.FromFile(IMAGES_FOLDER + "winGame.png");

        private Image _failGameImage = Image.FromFile(IMAGES_FOLDER + "failGame.png");

        private Image _closedCellImage = Image.FromFile(IMAGES_FOLDER + "closedCell.png");

        private bool _isFirstClickWaited;

        private VisibleCellState[,] _cellsStates;

        public MainWindow(MinesweeperController controller)
        {
            InitializeComponent();

            Controller = controller ?? throw new ArgumentNullException(nameof(controller));
        }

        public void InitializeGameField(int rowCount, int columnCount, int minesCount)
        {
            InitializeTextFields(rowCount, columnCount, minesCount);

            InitializeGameTable(rowCount, columnCount);

            InitializeTimer();

            _isFirstClickWaited = true;

            InitializeCellsStates(rowCount, columnCount);
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

        private void InitializeTextFields(int rowCount, int columnCount, int minesCount)
        {
            heightTextBox.Text = rowCount.ToString();
            widthTextBox.Text = columnCount.ToString();
            minesCountTextBox.Text = minesCount.ToString();

            if (Controller.IsCustomGameMode(Controller.GetCurrentGameModeIndex()))
            {
                heightTextBox.Enabled = true;
                widthTextBox.Enabled = true;
                minesCountTextBox.Enabled = true;
            }
            else
            {
                heightTextBox.Enabled = false;
                widthTextBox.Enabled = false;
                minesCountTextBox.Enabled = false;
            }
        }

        private void InitializeGameTable(int rowCount, int columnCount)
        {
            if (rowCount < 1 || columnCount < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(rowCount) + nameof(columnCount), "Число строк и столбцов в таблице должно быть больше 1." +
                                                      $"Переданы значения: число строк {rowCount} и число столбцов {columnCount}.");
            }

            gameTable.Enabled = true;
            gameTable.Controls.Clear();

            gameTable.RowCount = rowCount;
            gameTable.ColumnCount = columnCount;

            var cellSize = 40;

            var tableHeight = cellSize * rowCount;
            var tableWidth = cellSize * columnCount;

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

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    var button = new Button();

                    button.Name = GetButtonName(i, j);

                    button.Margin = new Padding(1, 1, 1, 1);
                    button.Dock = DockStyle.Fill;
                    button.TabStop = false;
                    button.FlatAppearance.BorderSize = 1;
                    button.FlatAppearance.BorderColor = Color.DarkGray;
                    button.FlatStyle = FlatStyle.Flat;
                    button.Image = _closedCellImage;

                    button.MouseDown += new MouseEventHandler(this.cell_Click!);

                    gameTable.Controls.Add(button, j, i);
                }
            }

            startGameButton.Image = _newGameImage;
        }

        private void InitializeTimer()
        {
            timeTextBox.Text = "0";

            timer.Interval = 1000;
            timer.Enabled = false;
        }

        private void InitializeCellsStates(int rowCount, int columnCount)
        {
            _cellsStates = new VisibleCellState[rowCount, columnCount];

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    _cellsStates[i, j] = VisibleCellState.Blank;
                }
            }
        }

        public void StopTimer()
        {
            timer.Stop();
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

        // Кодирую в имени кнопки ее координаты
        private string GetButtonName(int row, int column)
        {
            return $"{row}, {column}";
        }

        private static int GetButtonRow(string name)
        {
            return Convert.ToInt32(name.Substring(0, name.IndexOf(',')));
        }

        private static int GetButtonColumn(string name)
        {
            var commaIndex = name.IndexOf(',');

            return Convert.ToInt32(name.Substring(commaIndex + 1, name.Length - commaIndex - 1));
        }

        public bool IsCellBlank(int row, int column)
        {
             return Equals(_cellsStates[row, column], VisibleCellState.Blank);
        }

        public bool HasFlagOnClosedCell(int row, int column)
        {
            var button = FindButton(row, column);

            return Equals(_cellsStates[row, column], VisibleCellState.FlagOnClosedCell);
        }

        private Button FindButton(int row, int column)
        {
            var controlsArray = Controls.Find(GetButtonName(row, column), true);

            return (Button)controlsArray[0];
        }

        public void OpenCell(int row, int column, int value)
        {
            var button = FindButton(row, column);

            button.Image = GetImageForValue(value);

            _cellsStates[row, column] = VisibleCellState.Value;
        }

        private Image GetImageForValue(int value)
        {
            return Image.FromFile(IMAGES_FOLDER + value.ToString() + ".png");
        }

        public void OpenCell(int row, int column, VisibleCellState cellState)
        {
            var button = FindButton(row, column);

            Image? image = null;

            switch (cellState)
            {
                case VisibleCellState.Mine:
                    image = _mineImage;
                    break;
                case VisibleCellState.ExplodedMine:
                    image = _explodedMineImage;
                    break;
                case VisibleCellState.FlagOnClosedCell:
                    image = _flagImage;
                    break;
                case VisibleCellState.FlagOnOpenedCell:
                    image = _flagImage;
                    break;
                case VisibleCellState.WrongFlag:
                    image = _wrongFlagImage;
                    break;
                default:
                    break;
            }

            if (image != null)
            {
                button.Image = image;
            }

            _cellsStates[row, column] = cellState;
        }

        public void SetFlagOnClosedCell(int row, int column)
        {
            var button = FindButton(row, column);

            button.Image = _flagImage;

            _cellsStates[row, column] = VisibleCellState.FlagOnClosedCell;
        }

        public void RemoveFlagOnClosedCell(int row, int column)
        {
            var button = FindButton(row, column);

            button.Image = _closedCellImage;

            _cellsStates[row, column] = VisibleCellState.Blank;
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

            for (int i = 0; i < gameTable.RowCount; i++)
            {
                for (int j = 0; j < gameTable.ColumnCount; j++)
                {
                    var button = FindButton(i, j);

                    button.MouseDown -= new MouseEventHandler(this.cell_Click!);
                }
            }
        }

        public int GetGameTime()
        {
            return Convert.ToInt32(timeTextBox.Text);
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            var textBox = (TextBox)sender;

            if (!int.TryParse(textBox.Text, out var result))
            {
                ShowError("Нужно ввести число.");
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            InitializeGameModesListBox();

            Controller.StartNewGame();
        }

        private void startGameButton_Click(object sender, EventArgs e)
        {
            Controller.UpdateGameParameters();
        }

        private void cell_Click(object sender, MouseEventArgs e)
        {
            if (_isFirstClickWaited)
            {
                timer.Start();

                _isFirstClickWaited = false;
            }

            var button = (Button)sender;

            var row = GetButtonRow(button.Name);
            var column = GetButtonColumn(button.Name);

            if (e.Button == MouseButtons.Right)
            {
                Controller.ChangeFlagOnClosedCell(row, column);
            }
            else if (e.Button == MouseButtons.Left)
            {
                Controller.OpenCell(row, column);
            }
            else
            {
                BlinkNeighbouringCells(row, column);
            }
        }

        // Этот метод заставляет мигать ячейки, соседние с заданной.
        // Для этого кнопки сначала рисуются, как открытые , и через 0,1 секунды - снова как закрытые.
        // Т.к. Thread.Sleep тут не работает, подсмотрела на stackoverflow, что можно сделать метод асинхронным:
        // https://ru.stackoverflow.com/questions/1399773/%D0%9F%D0%BE%D1%87%D0%B5%D0%BC%D1%83-thread-sleep-%D1%80%D0%B0%D0%B1%D0%BE%D1%82%D0%B0%D0%B5%D1%82-%D0%B2-%D0%BD%D0%B0%D1%87%D0%B0%D0%BB%D0%B5-%D1%84%D1%83%D0%BD%D0%BA%D1%86%D0%B8%D0%B8
        private async void BlinkNeighbouringCells(int row, int column)
        {
            var neighbouringBlankCells = Controller.GetNeighbouringBlankCells(row, column);

            if (neighbouringBlankCells is null || neighbouringBlankCells.Count == 0)
            {
                return;
            }

            var neighbouringButtons = new List<Button>();

            foreach (var cell in neighbouringBlankCells)
            {
                var button = FindButton(cell.X, cell.Y);

                button.Image = GetImageForValue(0);

                neighbouringButtons.Add(button);
            }

            await Task.Delay(100);

            foreach (var button in neighbouringButtons)
            {
                button.Image = _closedCellImage;
            }
        }

        private void modesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Controller.StartNewGame();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            var location = new Point(Location.X + 50, Location.Y + 50);

            var window = new AboutWindow(location);

            window.ShowDialog();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            var seconds = Convert.ToInt32(timeTextBox.Text);

            seconds++;

            timeTextBox.Text = seconds.ToString();

            if (seconds >= 999)
            {
                timer.Stop();
            }
        }

        public string? GetWinnerName()
        {
            var location = new Point(Location.X + 50, Location.Y + 50);

            var window = new WinnerWindow(location);

            window.ShowDialog(this);

            return window.WinnerName;
        }

        private void highScoresButton_Click(object sender, EventArgs e)
        {
            var highScores = Controller.GetHighScores();

            var gameModeName = Controller.GetGameModesNames()[Controller.GetCurrentGameModeIndex()];

            var location = new Point(Location.X + 50, Location.Y + 50);

            var highScoresWindow = new HighScoresWindow(location, gameModeName, highScores);

            highScoresWindow.Show();
        }
    }
}