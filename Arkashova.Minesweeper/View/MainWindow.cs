using Arkashova.Minesweeper.View;

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

        private readonly Color _closedCellColor = Color.AliceBlue; // Этот и следующий цвет выбраны наугад. Главное, чтобы они отличались

        private readonly Color _openedCellColor = Color.AntiqueWhite;

        private bool _isFirstClickWaited;

        public MainWindow(Controller controller)
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

            for (int i = 0; i < rowCount; i++) // ???????????? i/j
            {
                for (int j = 0; j < columnCount; j++)
                {
                    var button = new Button();

                    button.Name = GetButtonName(i, j, false);

                    ApplyCommonButtonStyle(button);
                    ApplyClosedButtonStyle(button);

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
            timer.Enabled = false; // false? true on first click 
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

        // Кодирую в имени кнопки ее координаты и признак есть/нет флажок
        private string GetButtonName(int row, int column, bool hasFlag)
        {
            var flag = hasFlag ? "1" : "0";

            return $"{row}, {column}, {flag}";
        }

        private static int GetButtonRow(string name)
        {
            return Convert.ToInt32(name.Substring(0, name.IndexOf(',')));
        }

        private static int GetButtonColumn(string name)
        {
            var firstCommaIndex = name.IndexOf(',');
            var secondCommaIndex = name.IndexOf(',', firstCommaIndex + 1);

            return Convert.ToInt32(name.Substring(firstCommaIndex + 1, secondCommaIndex - firstCommaIndex - 1));
        }

        public bool IsCellClosed(int row, int column)
        {
            var button = FindButton(row, column);

            return Equals(button.BackColor, _closedCellColor); // ???? works???
        }

        public bool HasFlag(int row, int column)
        {
            var button = FindButton(row, column);

            var flag = button.Name[^1] == '1' ? true : false;

            return flag;
        }

        private Button FindButton(int row, int column)
        {
            var controlsArray = Controls.Find(GetButtonName(row, column, false), true);

            if (controlsArray.Length == 0)
            {
                controlsArray = Controls.Find(GetButtonName(row, column, true), true);
            }

            return (Button)controlsArray[0];
        }

        private void ApplyCommonButtonStyle(Button button)
        {
            button.Margin = new Padding(1, 1, 1, 1);
            button.Dock = DockStyle.Fill;
            button.TabStop = false;
            button.FlatAppearance.BorderSize = 1;
            button.FlatAppearance.BorderColor = Color.DarkGray;
            button.FlatStyle = FlatStyle.Flat;
        }

        private void ApplyClosedButtonStyle(Button button)
        {
            button.Image = _closedCellImage;
            button.BackColor = _closedCellColor; // Этот цвет кодирует то, что ячейка закрыта
        }

        private void ApplyOpenedButtonStyle(Button button)
        {
            button.Image = null;
            button.BackColor = _openedCellColor; // Этот цвет кодирует то, что ячейка открыта
        }

        public void OpenCell(int row, int column, string text)
        {
            if (IsCellClosed(row, column))
            {
                var button = FindButton(row, column);

                ApplyOpenedButtonStyle(button);

                button.Text = text;
            }
        }

        public void OpenCell(int row, int column, Image image)
        {
            if (IsCellClosed(row, column))
            {
                var button = FindButton(row, column);

                ApplyOpenedButtonStyle(button);

                button.Image = image;
            }
        }

        public void SetFlag(int row, int column)
        {
            var button = FindButton(row, column);

            var name = button.Name;

            button.Image = FlagImage;

            button.Name = name.Substring(0, name.Length - 1) + "1";
        }

        public void RemoveFlag(int row, int column)
        {
            var button = FindButton(row, column);

            var name = button.Name;

            button.Image = _closedCellImage;

            button.Name = name.Substring(0, name.Length - 1) + "0";
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

            for (int i = 0; i < gameTable.RowCount; i++)  // i/j????
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

            if (IsCellClosed(row, column))
            {
                if (e.Button == MouseButtons.Right)
                {
                    Controller.SetFlag(row, column);

                    //minesCountTextBox.Text = Controller.GetTableWidth(GetSelectedGameModeIndex()).ToString();
                }
                else
                {
                    Controller.OpenCell(row, column);
                }
            }
            else
            {
                BlinkNeighbouringCells(row, column);
            }
        }

        // Этот метод заставляет мигать ячейки, соседние с заданной.
        // Для этого кнопки сначала рисуются, как открытые, и через 0,1 секунды - снова как закрытые.
        // Т.к. Thread.Sleep тут не работает, подсмотрела на stackoverflow, что можно сделать метод асинхронным:
        // https://ru.stackoverflow.com/questions/1399773/%D0%9F%D0%BE%D1%87%D0%B5%D0%BC%D1%83-thread-sleep-%D1%80%D0%B0%D0%B1%D0%BE%D1%82%D0%B0%D0%B5%D1%82-%D0%B2-%D0%BD%D0%B0%D1%87%D0%B0%D0%BB%D0%B5-%D1%84%D1%83%D0%BD%D0%BA%D1%86%D0%B8%D0%B8
        private async void BlinkNeighbouringCells(int row, int column) 
        {
            var neighbouringClosedCells = Controller.GetNeighbouringClosedCells(row, column);

            if (neighbouringClosedCells is null || neighbouringClosedCells.Count == 0)
            {
                return;
            }

            var neighbouringButtons = new List<Button>();

            foreach (var cell in neighbouringClosedCells)
            {
                var button = FindButton(cell.Item1, cell.Item2);

                ApplyOpenedButtonStyle(button);

                neighbouringButtons.Add(button);
            }

            await Task.Delay(100);

            foreach (var button in neighbouringButtons)
            {
                ApplyClosedButtonStyle(button);
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