using Arkashova.Minesweeper.Logic.GameModes;

namespace Arkashova.Minesweeper.Logic
{
    public class MinesweeperModel : IModel
    {
        private const int MINE = 9;

        private int[,] _table;

        public List<GameMode> GameModes { get; set; }

        public int CurrentGameModeIndex { get; set; }

        public MinesweeperModel(List<GameMode> gameModes, int gameModeIndex)
        {
            GameModes = gameModes ?? throw new ArgumentNullException(nameof(gameModes));

            StartNewGame();
        }

        public void StartNewGame()
        {
            _table = new int[GameModes[CurrentGameModeIndex].FieldHeight, GameModes[CurrentGameModeIndex].FieldWidth];

            FillTable();
        }

        private void FillTable()
        {
            var randomNumbers = new List<int>();

            var random = new Random(DateTime.UtcNow.Millisecond);

            var fieldWidth = GameModes[CurrentGameModeIndex].FieldWidth;
            var fieldHeight = GameModes[CurrentGameModeIndex].FieldHeight;

            var maxNumber = fieldWidth * fieldHeight + 1;

            while (randomNumbers.Count < GameModes[CurrentGameModeIndex].MinesCount)
            {
                var number = random.Next(1, maxNumber);

                if (!randomNumbers.Contains(number))
                {
                    randomNumbers.Add(number);

                    var row = (int)Math.Ceiling((double)number / fieldWidth) - 1;

                    var column = number - row * fieldWidth - 1;

                    _table[row, column] = MINE;
                }
            }

            for (int i = 0; i < fieldHeight; i++)
            {
                for (int j = 0; j < fieldWidth; j++)
                {
                    if (_table[i, j] != MINE)
                    {
                        var sum = 0;

                        sum += GetOneIfIsMine(i - 1, j - 1);
                        sum += GetOneIfIsMine(i - 1, j);
                        sum += GetOneIfIsMine(i - 1, j + 1);
                        sum += GetOneIfIsMine(i, j - 1);
                        sum += GetOneIfIsMine(i, j + 1);
                        sum += GetOneIfIsMine(i + 1, j - 1);
                        sum += GetOneIfIsMine(i + 1, j);
                        sum += GetOneIfIsMine(i + 1, j + 1);

                        _table[i, j] = sum;
                    }
                }
            }
        }

        private int GetOneIfIsMine(int row, int column)
        {
            if (row == -1 || row == GameModes[CurrentGameModeIndex].FieldHeight
                || column == -1 || column == GameModes[CurrentGameModeIndex].FieldWidth
                || _table[row, column] != MINE)
            {
                return 0;
            }

            return 1;
        }

        public bool IsMine(int row, int column)
        {
            CheckRowIndex(row);
            CheckColumnIndex(column);

            return _table[row, column] == MINE;
        }

        public int GetValue(int row, int column)
        {
            CheckRowIndex(row);
            CheckColumnIndex(column);

            return _table[row, column];
        }

        private void CheckRowIndex(int value)
        {
            var maxValue = GameModes[CurrentGameModeIndex].FieldHeight;

            if (value < 0 || value >= maxValue)
            {
                throw new IndexOutOfRangeException($"Индекс строки должен быть от 0 до {maxValue - 1}. Передан индекс {value}");
            }
        }

        private void CheckColumnIndex(int value)
        {
            var maxValue = GameModes[CurrentGameModeIndex].FieldWidth;

            if (value < 0 || value >= maxValue)
            {
                throw new IndexOutOfRangeException($"Индекс столбца должен быть от 0 до {maxValue - 1}. Передан индекс {value}");
            }
        }
    }
}
