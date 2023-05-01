namespace Arkashova.Minesweeper.Logic.GameModes
{
    public abstract class GameMode
    {
        public virtual string Name => "Название режима";

        public virtual bool IsCustom => false;

        public virtual int FieldWidth
        {
            get => FieldWidth;

            set
            {
                if (IsCustom)
                {
                    FieldWidth = value;
                    return;
                }
                else
                {
                    throw new InvalidOperationException($"Нельзя изменить ширину поля в неизменяемом режиме {Name}.");
                }
            }
        }

        public virtual int FieldHeight
        {
            get => FieldHeight;

            set
            {
                if (IsCustom)
                {
                    FieldHeight = value;
                    return;
                }
                else
                {
                    throw new InvalidOperationException($"Нельзя изменить высоту поля в неизменяемом режиме {Name}.");
                }
            }
        }

        public virtual int MinesCount
        {
            get => MinesCount;

            set
            {
                if (IsCustom)
                {
                    MinesCount = value;
                    return;
                }
                else
                {
                    throw new InvalidOperationException($"Нельзя изменить число мин в неизменяемом режиме {Name}.");
                }
            }
        }

        public GameMode()
        {
        }
    }
}
