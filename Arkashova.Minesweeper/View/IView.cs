namespace Arkashova.Minesweeper.View
{
    public interface IView
    {
        Controller Controller { get; set; }

        Image MineImage { get; }

        Image OpenedMineImage { get; }

        Image FlagImage { get; }

        Image WrongFlagImage { get; }

        void InitializeGameModeSelector();

        void InitializeGameTable(int columnCount, int rowCount);

        int GetSelectedGameModeIndex();

        int GetSelectedFieldWidth();

        int GetSelectedFieldHeight();

        int GetSelectedMinesCount();

        void OpenCell(int x, int y, string text);

        void OpenCell(int x, int y, Image image);

        bool IsCellClosed(int column, int row);

        void ShowError(string message);

        void SuccessfullyCompleteGame();

        void FailGame();
    }
}