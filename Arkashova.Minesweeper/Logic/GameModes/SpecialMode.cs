namespace Arkashova.Minesweeper.Logic.GameModes
{
    public class SpecialMode : GameMode
    {
        public override string Name => "Особый";

        public override bool IsCustom => true;

        public int GetMinWidth() => 8;
        public int GetMaxWidth() => 32;

        public int GetMinHeight() => 8;
        public int GetMaxHeight() => 24;

        public int GetMinMinesCount() => 1;

        public override string HighScoresFileName => "..\\..\\..\\Logic\\GameModes\\HighScores\\SpecialModeHighScores.txt";

        private int _fieldWidth;

        public override int FieldWidth
        {
            get => _fieldWidth;

            set
            {
                if (value < GetMinWidth() || value > GetMaxWidth())
                {
                    throw new ArgumentOutOfRangeException(nameof(value), $"Ширина поля должна быть от {GetMinWidth()} до {GetMaxWidth()}. Передано значение: {value}.");
                }

                _fieldWidth = value;
            }
        }

        private int _fieldHeight;

        public override int FieldHeight
        {
            get => _fieldHeight;

            set
            {
                if (value < GetMinHeight() || value > GetMaxHeight())
                {
                    throw new ArgumentOutOfRangeException(nameof(value), $"Высота поля должна быть от {GetMinHeight()} до {GetMaxHeight()}. Передано значение: {value}.");
                }

                _fieldHeight = value;
            }
        }

        private int _minesCount;

        public override int MinesCount
        {
            get => _minesCount;

            set
            {
                var maxMinesCount = FieldWidth * FieldHeight / 3;  // подсмотрела такое ограничение на сайте https://minesweeper.one/

                if (value < GetMinMinesCount() || value > maxMinesCount)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), $"Количество мин должно быть от {GetMinMinesCount()} до {maxMinesCount}. Передано значение: {value}.");
                }

                _minesCount = value;
            }
        }

        public SpecialMode(int height, int width, int minesCount)
        {
            FieldHeight = height;
            FieldWidth = width;
            MinesCount = minesCount;
        }

        public SpecialMode() // такие начальные значения сама придумала
        {
            FieldWidth = (GetMinWidth() + GetMaxWidth()) / 2;
            FieldHeight = (GetMinHeight() + GetMaxHeight()) / 2;
            MinesCount = FieldWidth * FieldHeight / 6;
        }
    }
}