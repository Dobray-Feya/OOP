using Arkashova.Minesweeper.Logic;
using Arkashova.Minesweeper.View;

namespace Arkashova.Minesweeper
{
    public class Controller
    {
        public readonly IModel _model;

        private IView _view;

        private int _openedCellsCount;

        private int _сellsCountToOpen;

        private int _userFlagsCount; // пока не нужно

        public Controller(IModel model)
        {
            _model = model ?? throw new ArgumentNullException(nameof(model));
        }

        public void SetView(IView view)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        /*public int GetMinesCount(int index)
        {
            return _model.GameModes[index].MinesCount - _userFlagsCount;
        }*/

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
            return (List<string>)_model.GameModes.Select(x => x.Name).ToList();
        }

        public void StartNewGame()
        {
            var selectedIndex = _view.GetSelectedGameModeIndex();

            _model.CurrentGameModeIndex = selectedIndex;

            _model.StartNewGame();

            var columnCount = _model.GameModes[selectedIndex].FieldWidth;
            var rowCount = _model.GameModes[selectedIndex].FieldHeight;
            var minesCount = _model.GameModes[selectedIndex].MinesCount;

            _view.InitializeGameField(columnCount, rowCount, minesCount);

            _сellsCountToOpen = columnCount * rowCount - minesCount;
            _openedCellsCount = 0;
            _userFlagsCount = 0;
        }

        public void UpdateGameParameters()
        {
            var selectedIndex = _view.GetSelectedGameModeIndex();

            if (IsCustomGameMode(selectedIndex))
            {
                try
                {
                    _model.GameModes[selectedIndex].FieldWidth = _view.GetSelectedFieldWidth();
                    _model.GameModes[selectedIndex].FieldHeight = _view.GetSelectedFieldHeight();
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

        public void OpenCell(int column, int row)
        {
            if (_view.HasFlag(column, row))
            {
                return;
            }

            if (_model.IsMine(column, row))
            {
                _view.OpenCell(column, row, _view.OpenedMineImage);

                FailGame();

                return;
            }

            var cellValue = _model.GetValue(column, row);

            if (cellValue == 0)
            {
                _view.OpenCell(column, row, "");
                _openedCellsCount++;

                OpenZeroNeigbours(column, row);
            }
            else
            {
                _view.OpenCell(column, row, cellValue.ToString());
                _openedCellsCount++;
            }

            if (_сellsCountToOpen == _openedCellsCount)
            {
                SuccessfullyCompleteGame();
            }

        }

        public void SetFlag(int column, int row)
        {
            if (_view.HasFlag(column, row))
            {
                _view.RemoveFlag(column, row);

                _userFlagsCount--;
            }
            else
            {
                _view.SetFlag(column, row);

                _userFlagsCount++;
            }
        }

        private void OpenZeroNeigbours(int column, int row)
        {
            OpenNeigbour(column - 1, row - 1);
            OpenNeigbour(column - 1, row);
            OpenNeigbour(column - 1, row + 1);
            OpenNeigbour(column, row - 1);
            OpenNeigbour(column, row + 1);
            OpenNeigbour(column + 1, row - 1);
            OpenNeigbour(column + 1, row);
            OpenNeigbour(column + 1, row + 1);
        }

        private void OpenNeigbour(int column, int row)
        {
            try
            {
                if (!_view.IsCellClosed(column, row) || _view.HasFlag(column, row))
                {
                    return;
                }

                var neigbourValue = _model.GetValue(column, row);

                if (neigbourValue == 0)
                {
                    _view.OpenCell(column, row, "");
                    _openedCellsCount++;

                    OpenZeroNeigbours(column, row);
                }
                else
                {
                    _view.OpenCell(column, row, neigbourValue.ToString());
                    _openedCellsCount++;
                }
            }
            catch (Exception)
            {
            }
        }

        public List<(int, int)> GetNeighbouringClosedCells(int column, int row)
        {
            var list = new List<(int, int)>();

            AddToList(list, column - 1, row - 1);
            AddToList(list, column - 1, row);
            AddToList(list, column - 1, row + 1);
            AddToList(list, column, row - 1);
            AddToList(list, column, row + 1);
            AddToList(list, column + 1, row - 1);
            AddToList(list, column + 1, row);
            AddToList(list, column + 1, row + 1);

            return list;
        }

        private void AddToList (List<(int, int)> list, int column, int row)
        {
            try
            {
                if (_view.IsCellClosed(column, row) && !_view.HasFlag(column, row))
                {
                    list.Add((column, row));
                }
            }
            catch (Exception)
            {
            }
        }

        public void FailGame()
        {
            _view.StopTimer();
            
            OpenMines(_view.MineImage);

            if (_userFlagsCount != 0)
            {
                FindWrongFlags();
            }

            _view.FailGame();
        }

        public void SuccessfullyCompleteGame()
        {
            _view.StopTimer(); 
            
            OpenMines(_view.FlagImage);

            _view.SuccessfullyCompleteGame();

            UpdateHighScores();
        }

        // Метод открывает ячейки с минами:
        // если игра выиграна, в ячейки передается картинка-флажок
        // если игра проиграна, в ячеку передается картинка-мина.
        private void OpenMines(Image image)
        {
            var currentIndex = GetCurrentGameModeIndex();

            for (int i = 0; i < _model.GameModes[currentIndex].FieldWidth; i++)
            {
                for (int j = 0; j < _model.GameModes[currentIndex].FieldHeight; j++)
                {
                    if (_model.IsMine(i, j) && !_view.HasFlag(i, j)) //если мина помечена флажком, то оставляем для ячейки картинку-флажок
                    {
                        _view.OpenCell(i, j, image);
                    }
                }
            }
        }

        // Метод ищет ошибочно установленные флажки (флажок установлен, но мины под ним нет)
        private void FindWrongFlags()
        {
            var currentIndex = GetCurrentGameModeIndex(); 
            
            for (int i = 0; i < _model.GameModes[currentIndex].FieldWidth; i++)
            {
                for (int j = 0; j < _model.GameModes[currentIndex].FieldHeight; j++)
                {
                    if (_view.HasFlag(i, j) && !_model.IsMine(i, j))
                    {
                        _view.OpenCell(i, j, _view.WrongFlagImage);
                    }
                }
            }
        }

        private void UpdateHighScores()
        {
            var userName = _view.GetWinnerName();

            if (userName == null)
            {
                return;
            }

            var score = _view.GetGameTime();

            _model.GameModes[GetCurrentGameModeIndex()].AddHighScore(userName, score);
        }

        public SortedDictionary<string, int> GetHighScores()
        {
            return _model.GameModes[GetCurrentGameModeIndex()].GetHighScores();
        }
    }
}