using Arkashova.Minesweeper.Logic.GameModes;

namespace Arkashova.Minesweeper.Logic
{
    public interface IModel
    {
        public List<GameMode> GameModes { get; set; }

        public int CurrentGameModeIndex { get; set; }

        public void StartNewGame();

        public bool IsMine(int row, int column);

        public int GetValue(int row, int column);
    }
}