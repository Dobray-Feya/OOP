namespace Arkashova.Minesweeper.View
{
    public interface IView
    {
        Controller Controller { get; set; }

        Image MineImage { get; }

        Image OpenedMineImage { get; }

        Image FlagImage { get; }

        Image WrongFlagImage { get; }

        void InitializeGameField(int rowCount, int columnCount, int minesCount);

        int GetSelectedGameModeIndex();

        int GetSelectedFieldWidth();

        int GetSelectedFieldHeight();

        int GetSelectedMinesCount();

        void OpenCell(int rowCount, int columnCount, string text);

        void OpenCell(int rowCount, int columnCount, Image image);

        bool IsCellClosed(int rowCount, int columnCount);

        bool HasFlag(int rowCount, int columnCount);

        void SetFlag(int rowCount, int columnCount);

        void RemoveFlag(int rowCount, int columnCount);

        void ShowError(string message);

        void SuccessfullyCompleteGame();

        void FailGame();

        int GetGameTime();

        void StopTimer();

        string? GetWinnerName();
    }
}