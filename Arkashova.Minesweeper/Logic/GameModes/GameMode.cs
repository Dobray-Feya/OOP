using System.Runtime.Serialization.Formatters.Binary;

namespace Arkashova.Minesweeper.Logic.GameModes
{
    public abstract class GameMode
    {
        public virtual string Name => "Название режима";

        public virtual bool IsCustom => false;

        private int _fieldWidth;

        public virtual int FieldWidth
        {
            get => _fieldWidth;

            set
            {
                if (!IsCustom)
                {
                    throw new InvalidOperationException($"Нельзя изменить ширину поля в неизменяемом режиме {Name}.");
                }

                _fieldWidth = value;
            }
        }

        private int _fieldHeight;

        public virtual int FieldHeight
        {
            get => _fieldHeight;

            set
            {
                if (!IsCustom)
                {
                    throw new InvalidOperationException($"Нельзя изменить высоту поля в неизменяемом режиме {Name}.");
                }

                _fieldHeight = value;
            }
        }

        private int _minesCount;

        public virtual int MinesCount
        {
            get => _minesCount;

            set
            {
                if (!IsCustom)
                {
                    throw new InvalidOperationException($"Нельзя изменить число мин в неизменяемом режиме {Name}.");
                }

                _minesCount = value;
            }
        }

        public virtual string HighScoresFileName => "полный путь к текстовому файлу с результатами игры для данного режима";

        public SortedDictionary<string, int> GetHighScores()
        {
            try
            {
                var formatter = new BinaryFormatter();

                using (Stream stream = new FileStream(HighScoresFileName, FileMode.OpenOrCreate, FileAccess.Read))
                {
#pragma warning disable SYSLIB0011  // Сериализация BinaryFormatter устарела - компиллятор выдает предупреждение.
                    //TODO: попробовать другую сериализацию
                    return (SortedDictionary<string, int>)formatter.Deserialize(stream);
                }
            }
            catch (Exception)
            {
                return new SortedDictionary<string, int>();
            }
        }

        public void AddHighScore(string name, int score)
        {
            var highScores = GetHighScores();

            highScores.Add(name, score);

            var formatter = new BinaryFormatter();

            using (Stream stream = new FileStream(HighScoresFileName, FileMode.OpenOrCreate, FileAccess.Write))
            {
#pragma warning disable SYSLIB0011

                formatter.Serialize(stream, highScores);
            }
        }

        public GameMode()
        {
        }
    }
}
