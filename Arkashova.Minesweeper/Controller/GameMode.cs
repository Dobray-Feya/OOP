namespace Arkashova.Minesweeper.Controller
{
    public abstract class GameMode
    {
        public virtual string? Name { get; }

        public virtual bool IsCustom { get; }

        public virtual int FieldWidth { get; set; }

        public virtual int FieldHeight { get; set; }

        public virtual int MinesCount { get; set; }

        public GameMode()
        {
        }

        public GameMode(int width, int height, int minesCount)
        {
            CheckWidthBeforeSetting(width);
            FieldWidth = width;

            CheckHeightBeforeSetting(height);
            FieldHeight = height;

            CheckMinesCountBeforeSetting(minesCount);
            MinesCount = minesCount;
        }

        public virtual void CheckWidthBeforeSetting(int value)
        {
            if (!IsCustom)
            {
                ThrowException();
            }
        }

        public virtual void CheckHeightBeforeSetting(int value)
        {
            if (!IsCustom)
            {
                ThrowException();
            }
        }

        public virtual void CheckMinesCountBeforeSetting(int value)
        {
            if (!IsCustom)
            {
                ThrowException();
            }
        }

        private void ThrowException()
        {
            throw new InvalidOperationException($"В режиме {Name} не предусмотрено изменение размеров поля и количества мин");
        }
    }
}