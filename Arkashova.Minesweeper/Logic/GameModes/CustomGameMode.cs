namespace Arkashova.Minesweeper.Logic.GameModes
{
    public abstract class CustomGameMode : GameMode
    {
        public override string Name => "Название пользовательского режима";

        public override bool IsCustom => true;

        public abstract int GetMinWidth();
        public abstract int GetMaxWidth();

        public abstract int GetMinHeight();
        public abstract int GetMaxHeight();

        public abstract int GetMinMinesCount();

        private int _fieldWidth;

        public override int FieldWidth
        {
            get { return _fieldWidth; }

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
            get { return _fieldHeight; }

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
            get { return _minesCount; }

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

        public CustomGameMode(int height, int width, int minesCount)
        {
            FieldHeight = height; 
            FieldWidth = width;
            MinesCount = minesCount;
        }

        public CustomGameMode() // такие начальные значения сама придумала
        {
            FieldWidth = (GetMinWidth() + GetMaxWidth()) / 2;
            FieldHeight = (GetMinHeight() + GetMaxHeight()) / 2;
            MinesCount = FieldWidth * FieldHeight / 6;
        }
    }
}
