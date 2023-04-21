using Arkashova.Minesweeper.Controller;
using System.Security.Cryptography.X509Certificates;

namespace Arkashova.Minesweeper.Logic
{
    public class MinesweeperModel : IModel
    {
        public int[,] Table { get; set; }

        public GameMode GameMode { get; set; }

        private const int BOMB = 9;

        public MinesweeperModel(GameMode mode)
        {
            GameMode = mode;

            Table = new int[GameMode.FieldWidth, GameMode.FieldHeight];

            FillTable();
        }

        private void FillTable()
        {
            var randomNumbers = new List<int>();

            Random random = new Random();

            var maxNumber = GameMode.FieldWidth * GameMode.FieldHeight + 1;

            while (randomNumbers.Count < GameMode.MinesCount)
            {
                var number = random.Next(1, maxNumber);

                if (!randomNumbers.Contains(number))
                {
                    randomNumbers.Add(number);

                    var y = (int)Math.Ceiling((double)number / GameMode.FieldHeight) - 1;

                    var x = number - y * GameMode.FieldWidth - 1;

                    Table[x, y] = BOMB;
                }
            }

            for (int i = 0; i < GameMode.FieldWidth; i++)
            {
                for (int j = 0; j < GameMode.FieldHeight; j++)
                {
                    if (Table[i, j] != BOMB)
                    {
                        var sum = 0;

                        sum += GetValue(i - 1, j - 1);
                        sum += GetValue(i - 1, j);
                        sum += GetValue(i - 1, j + 1);
                        sum += GetValue(i, j - 1);
                        sum += GetValue(i, j + 1);
                        sum += GetValue(i + 1, j - 1);
                        sum += GetValue(i + 1, j);
                        sum += GetValue(i + 1, j + 1);

                        Table[i, j] = sum;
                    }
                }
            }
        }

        private int GetValue(int x, int y)
        {
            if (x== -1 || x == GameMode.FieldWidth || y == -1 || y == GameMode.FieldHeight || Table[x, y] != BOMB) //!! redo
            {
                return 0;
            }

            return 1;
        }
    }
}
