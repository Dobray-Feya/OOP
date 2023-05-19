using Arkashova.Minesweeper.Logic.GameModes.HighScores;
using System.Runtime.Serialization.Formatters.Binary;

namespace Arkashova.Minesweeper.Logic.GameModes
{
    public abstract class GameMode
    {
        public virtual string Name => "Название режима";

        public string HighScoresFileName => $"..\\..\\..\\Logic\\GameModes\\HighScores\\{Name} {FieldHeight},{FieldWidth},{MinesCount}.txt";

        public virtual bool IsCustom => false;

        private int _fieldWidth;
        private int _fieldHeight;
        private int _minesCount;

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

        public List<(string, int)> GetHighScores()
        {
            try
            {
                var formatter = new BinaryFormatter();

                using (Stream stream = new FileStream(HighScoresFileName, FileMode.OpenOrCreate, FileAccess.Read))
                {
#pragma warning disable SYSLIB0011  // Сериализация BinaryFormatter устарела - компиллятор выдает предупреждение.
                    return (List<(string, int)>)formatter.Deserialize(stream);
                }
            }
            catch (Exception)
            {
                return new List<(string, int)>();
            }
        }

        public void AddHighScore(string? name, int score)
        {
            if (string.IsNullOrEmpty(name))
            {
                return;
            }

            var highScores = GetHighScores();

            highScores.Add((name, score));

            highScores.Sort(new HighScoresComparer());

            var formatter = new BinaryFormatter();

            using (Stream stream = new FileStream(HighScoresFileName, FileMode.OpenOrCreate, FileAccess.Write))
            {
#pragma warning disable SYSLIB0011
                formatter.Serialize(stream, highScores);
            }
        }
    }
}
