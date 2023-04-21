using Arkashova.Minesweeper.Controller;

namespace Arkashova.Minesweeper.Logic
{
    public class CustomMode : GameMode
    {
        public override string Name => "Custom";

        public override bool IsCustom => true;

        private readonly int minWidth = 8;
        private readonly int maxWidth = 32;

        private readonly int minHeight = 8;
        private readonly int maxHeight = 24;

        private readonly int minMinesCount = 1;

        public CustomMode(int widtn, int height, int minesCount) : base(widtn, height, minesCount) // лишнее?
        {
        }

        public override void CheckWidthBeforeSetting(int value)
        {
            if (value < minWidth || value > maxWidth)
            {
                throw new ArgumentOutOfRangeException(nameof(value), $"Ширина поля должна быть от {minWidth} до {maxWidth}. Передано значение: {value}.");
            }
        }

        public override void CheckHeightBeforeSetting(int value)
        {
            if (value < minHeight || value > maxHeight)
            {
                throw new ArgumentOutOfRangeException(nameof(value), $"Ширина поля должна быть от {minHeight} до {maxHeight}. Передано значение: {value}.");
            }
        }

        public override void CheckMinesCountBeforeSetting(int value)
        {
            var maxMinesCount = FieldWidth * FieldHeight / 3;

            if (value < minMinesCount || value > maxMinesCount)
            {
                throw new ArgumentOutOfRangeException(nameof(value), $"Количество мин должно быть от {minMinesCount} до {maxMinesCount}. Передано значение: {value}.");
            }
        }
    }
}