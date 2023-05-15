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

        private void CheckGameModeIndex(int value)
        {
            if (value < 0 || value >= GameModes.Count)
            {
                throw new IndexOutOfRangeException($"Индекс режима должен быть не меньше 0 и не больше {GameModes.Count - 1}. Передан индекс {value}");
            }
        }

        public void StartNewGame()
        {
            _table = new int[GameModes[CurrentGameModeIndex].FieldWidth, GameModes[CurrentGameModeIndex].FieldHeight];

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

                    var y = (int)Math.Ceiling((double)number / fieldWidth) - 1;

                    var x = number - y * fieldWidth - 1;

                    _table[x, y] = MINE;
                }
            }

            for (int i = 0; i < fieldWidth; i++)
            {
                for (int j = 0; j < fieldHeight; j++)
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

        private int GetOneIfIsMine(int column, int row)
        {
            if (column == -1 || column == GameModes[CurrentGameModeIndex].FieldWidth || row == -1 || row == GameModes[CurrentGameModeIndex].FieldHeight || _table[column, row] != MINE) //!! redo
            {
                return 0;
            }

            return 1;
        }

        public bool IsMine(int column, int row)
        {
            CheckColumnIndex(column);
            CheckRowIndex(row);

            return _table[column, row] == MINE;
        }

        public int GetValue(int column, int row)
        {
            CheckColumnIndex(column);
            CheckRowIndex(row);

            return _table[column, row];
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
