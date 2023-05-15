using Arkashova.Minesweeper.Logic;
using Arkashova.Minesweeper.View;
using System.Data.Common;

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

            var rowCount = _model.GameModes[selectedIndex].FieldHeight;
            var columnCount = _model.GameModes[selectedIndex].FieldWidth;
            var minesCount = _model.GameModes[selectedIndex].MinesCount;

            _view.InitializeGameField(rowCount, columnCount, minesCount);

            _сellsCountToOpen = rowCount * columnCount - minesCount;
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
            if (_view.HasFlag(row, column))
            {
                return;
            }

            if (_model.IsMine(row, column))
            {
                _view.OpenCell(row, column, _view.OpenedMineImage);

                FailGame();

                return;
            }

            var cellValue = _model.GetValue(row, column);

            if (cellValue == 0)
            {
                _view.OpenCell(row, column, "");
                _openedCellsCount++;

                OpenZeroNeigbours(row, column);
            }
            else
            {
                _view.OpenCell(row, column, cellValue.ToString());
                _openedCellsCount++;
            }

            if (_сellsCountToOpen == _openedCellsCount)
            {
                SuccessfullyCompleteGame();
            }
        }

        public void SetFlag(int row, int column)
        {
            if (_view.HasFlag(row, column))
            {
                _view.RemoveFlag(row, column);

                _userFlagsCount--;
            }
            else
            {
                _view.SetFlag(row, column);

                _userFlagsCount++;
            }
        }

        private void OpenZeroNeigbours(int row, int column)
        {
            OpenNeigbour(row - 1, column - 1);
            OpenNeigbour(row - 1, column);
            OpenNeigbour(row - 1, column + 1);
            OpenNeigbour(row, column - 1);
            OpenNeigbour(row, column + 1);
            OpenNeigbour(row + 1, column - 1);
            OpenNeigbour(row + 1, column);
            OpenNeigbour(row + 1, column + 1);
        }

        private void OpenNeigbour(int row, int column)
        {
            try
            {
                if (!_view.IsCellClosed(row, column) || _view.HasFlag(row, column))
                {
                    return;
                }

                var neigbourValue = _model.GetValue(row, column);

                if (neigbourValue == 0)
                {
                    _view.OpenCell(row, column, "");
                    _openedCellsCount++;

                    OpenZeroNeigbours(row, column);
                }
                else
                {
                    _view.OpenCell(row, column, neigbourValue.ToString());
                    _openedCellsCount++;
                }
            }
            catch (Exception)
            {
            }
        }

        public List<(int, int)> GetNeighbouringClosedCells(int row, int column)
        {
            var list = new List<(int, int)>();

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

        private void AddToList (List<(int, int)> list, int row, int column)
        {
            try
            {
                if (_view.IsCellClosed(row, column) && !_view.HasFlag(row, column))
                {
                    list.Add((row, column));
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

            for (int i = 0; i < _model.GameModes[currentIndex].FieldHeight; i++)
            {
                for (int j = 0; j < _model.GameModes[currentIndex].FieldWidth; j++)
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
            
            for (int i = 0; i < _model.GameModes[currentIndex].FieldHeight; i++)
            {
                for (int j = 0; j < _model.GameModes[currentIndex].FieldWidth; j++)
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