using Arkashova.Minesweeper.Controller;

namespace Arkashova.Minesweeper.View
{
    public interface IView
    {
        MinesweeperController Controller { get; set; }

        bool IsFirstClickWaited { get; set; }

        void InitializeGameField(int rowCount, int columnCount, int minesCount);

        int GetSelectedGameModeIndex();

        int GetSelectedFieldWidth();

        int GetSelectedFieldHeight();

        int GetSelectedMinesCount();

        void OpenCell(int rowCount, int columnCount, int value);

        void OpenCell(int rowCount, int columnCount, VisibleCellState state);

        bool IsCellBlank(int rowCount, int columnCount);

        bool HasFlagOnClosedCell(int rowCount, int columnCount);

        void SetFlagOnClosedCell(int rowCount, int columnCount);

        void RemoveFlagOnClosedCell(int rowCount, int columnCount);

        void ShowError(string message);

        void SuccessfullyCompleteGame();

        void FailGame();

        int GetGameTime();

        void StartTimer();

        void StopTimer();

        string? GetWinnerName();

        void ShowHighScores();
    }
}