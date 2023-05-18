using Arkashova.Minesweeper.Logic;
using Arkashova.Minesweeper.View;
using System.Data.Common;

namespace Arkashova.Minesweeper.Controller
{
    public class MinesweeperController
    {
        public readonly IModel _model;

        private IView _view;

        private int _openedCellsCount;

        private int _cellsCountToOpen;

        public MinesweeperController(IModel model)
        {
            _model = model ?? throw new ArgumentNullException(nameof(model));
        }

        public void SetView(IView view)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        public bool IsCustomGameMode(int index)
        {
            return _model.GameModes[index].IsCustom;
        }

        public int GetCurrentGameModeIndex()
        {
            return _model.CurrentGameModeIndex;
        }

        public List<string> GetGameModesNames()
        {
            return _model.GameModes.Select(x => x.Name).ToList();
        }

        public void StartNewGame()
        {
            var selectedIndex = _view.GetSelectedGameModeIndex();

            _model.CurrentGameModeIndex = selectedIndex;

            _model.StartNewGame();

            var rowCount = _model.GameModes[selectedIndex].FieldHeight;
            var columnCount = _model.GameModes[selectedIndex].FieldWidth;
            var minesCount = _model.GameModes[selectedIndex].MinesCount;

            _view.InitializeGameField(rowCount, columnCount, minesCount);

            _cellsCountToOpen = rowCount * columnCount - minesCount;
            _openedCellsCount = 0;
        }

        public void UpdateGameParameters()
        {
            var selectedIndex = _view.GetSelectedGameModeIndex();

            if (IsCustomGameMode(selectedIndex))
            {
                try
                {
                    _model.GameModes[selectedIndex].FieldHeight = _view.GetSelectedFieldHeight();
                    _model.GameModes[selectedIndex].FieldWidth = _view.GetSelectedFieldWidth();
                    _model.GameModes[selectedIndex].MinesCount = _view.GetSelectedMinesCount();
                }
                catch (Exception e)
                {
                    _view.ShowError("Указаны неправильные параметры. " + e.Message);

                    return;
                }
            }

            StartNewGame();
        }

        public void OpenCell(int row, int column)
        {
            if (_model.IsMine(row, column))
            {
                _view.OpenCell(row, column, VisibleCellState.ExplodedMine);

                FailGame();

                return;
            }

            var cellValue = _model.GetValue(row, column);

            if (cellValue == 0)
            {
                _view.OpenCell(row, column, 0);
                _openedCellsCount++;

                OpenZeroNeighbours(row, column);
            }
            else
            {
                _view.OpenCell(row, column, cellValue);
                _openedCellsCount++;
            }

            if (_cellsCountToOpen == _openedCellsCount)
            {
                SuccessfullyCompleteGame();
            }
        }

        public void OpenFirstCell(int row, int column)
        {
            var i = 0;

            while (_model.IsMine(row, column))
            {
                _model.StartNewGame();
                i++;
            }

            OpenCell(row, column);
        }

        public void ChangeFlagOnClosedCell(int row, int column)
        {
            if (_view.IsCellBlank(row, column))
            {
                _view.SetFlagOnClosedCell(row, column);;
            }
            else  if (_view.HasFlagOnClosedCell(row, column))
            {
                _view.RemoveFlagOnClosedCell(row, column);
            }
        }

        private void OpenZeroNeighbours(int row, int column)
        {
            OpenNeighbour(row - 1, column - 1);
            OpenNeighbour(row - 1, column);
            OpenNeighbour(row - 1, column + 1);
            OpenNeighbour(row, column - 1);
            OpenNeighbour(row, column + 1);
            OpenNeighbour(row + 1, column - 1);
            OpenNeighbour(row + 1, column);
            OpenNeighbour(row + 1, column + 1);
        }

        private void OpenNeighbour(int row, int column)
        {
            try
            {
                if (!_view.IsCellBlank(row, column))
                {
                    return;
                }

                var neighbourValue = _model.GetValue(row, column);

                if (neighbourValue == 0)
                {
                    _view.OpenCell(row, column, 0);
                    _openedCellsCount++;

                    OpenZeroNeighbours(row, column);
                }
                else
                {
                    _view.OpenCell(row, column, neighbourValue);
                    _openedCellsCount++;
                }
            }
            catch (Exception)
            {
            }
        }

        public List<Point> GetNeighbouringBlankCells(int row, int column)
        {
            var list = new List<Point>();

            AddToList(list, row - 1, column - 1);
            AddToList(list, row - 1, column);
            AddToList(list, row - 1, column + 1);
            AddToList(list, row, column - 1);
            AddToList(list, row, column + 1);
            AddToList(list, row + 1, column - 1);
            AddToList(list, row + 1, column);
            AddToList(list, row + 1, column + 1);

            return list;
        }

        private void AddToList(List<Point> list, int row, int column)
        {
            try
            {
                if (_view.IsCellBlank(row, column))
                {
                    list.Add(new Point(row, column));
                }
            }
            catch (Exception)
            {
            }
        }

        public void FailGame()
        {
            _view.StopTimer();

            var currentIndex = GetCurrentGameModeIndex();

            for (int i = 0; i < _model.GameModes[currentIndex].FieldHeight; i++)
            {
                for (int j = 0; j < _model.GameModes[currentIndex].FieldWidth; j++)
                {
                    if (_model.IsMine(i, j))
                    {
                        if (_view.HasFlagOnClosedCell(i, j))
                        {
                            _view.OpenCell(i, j, VisibleCellState.FlagOnOpenedCell);
                        }
                        else
                        {
                            _view.OpenCell(i, j, VisibleCellState.Mine);
                        }

                        continue;
                    }

                    if (!_model.IsMine(i, j) && _view.HasFlagOnClosedCell(i, j))
                    {
                        _view.OpenCell(i, j, VisibleCellState.WrongFlag);
                    }
                }
            }

            _view.FailGame();
        }

        public void SuccessfullyCompleteGame()
        {
            _view.StopTimer();

            var currentIndex = GetCurrentGameModeIndex();

            for (int i = 0; i < _model.GameModes[currentIndex].FieldHeight; i++)
            {
                for (int j = 0; j < _model.GameModes[currentIndex].FieldWidth; j++)
                {
                    if (_model.IsMine(i, j))
                    {
                        _view.OpenCell(i, j, VisibleCellState.FlagOnOpenedCell);
                    }
                }
            }

            _view.SuccessfullyCompleteGame();

            UpdateHighScores();
        }

        private void UpdateHighScores()
        {
            var userName = _view.GetWinnerName();

            if (userName != null)
            {
                var score = _view.GetGameTime();

                _model.GameModes[GetCurrentGameModeIndex()].AddHighScore(userName, score);
            }
        }

        public SortedDictionary<string, int> GetHighScores()
        {
            return _model.GameModes[GetCurrentGameModeIndex()].GetHighScores();
        }
    }
}