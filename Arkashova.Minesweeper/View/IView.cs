namespace Arkashova.Minesweeper.View
{
    public interface IView
    {
        Controller Controller { get; set; }

        Image MineImage { get; }

        Image OpenedMineImage { get; }

        Image FlagImage { get; }

        Image WrongFlagImage { get; }

        void InitializeGameField(int columnCount, int rowCount, int minesCount);

        int GetSelectedGameModeIndex();

        int GetSelectedFieldWidth();

        int GetSelectedFieldHeight();

        int GetSelectedMinesCount();

        void OpenCell(int x, int y, string text);

        void OpenCell(int column, int row, Image image);

        bool IsCellClosed(int column, int row);

        bool HasFlag(int column, int row);

        void SetFlag(int column, int row);

        void RemoveFlag(int column, int row);

        void ShowError(string message);

        void SuccessfullyCompleteGame();

        void FailGame();

        int GetGameTime();

        void StopTimer();

        string? GetWinnerName();
    }
}