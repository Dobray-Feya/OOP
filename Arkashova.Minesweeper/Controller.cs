﻿using Arkashova.Minesweeper.Logic;
using Arkashova.Minesweeper.View;

namespace Arkashova.Minesweeper
{
    public class Controller
    {
        public readonly IModel _model;

        private IView _view;

        private int _openedCellsCount;

        private int _сellsCountToOpen;

        public Controller(IModel model)
        {
            _model = model ?? throw new ArgumentNullException(nameof(model));
        }

        public void SetView(IView view)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        public int GetTableWidth(int index)
        {
            return _model.GameModes[index].FieldWidth;
        }

        public int GetTableHeight(int index)
        {
            return _model.GameModes[index].FieldHeight;
        }

        public int GetMinesCount(int index)
        {
            return _model.GameModes[index].MinesCount;
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
            return (List<string>)_model.GameModes.Select(x => x.Name).ToList();
        }

        public void StartNewGame()
        {
            if (_view.GetSelectedGameModeIndex() == -1)
            {
                _view.InitializeGameModeSelector();
            }

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

            _model.StartNewGame(selectedIndex);

            _view.InitializeGameTable(_model.GameModes[selectedIndex].FieldWidth, _model.GameModes[selectedIndex].FieldHeight);

            _сellsCountToOpen = _model.GameModes[selectedIndex].FieldWidth * _model.GameModes[selectedIndex].FieldHeight - _model.GameModes[selectedIndex].MinesCount;
            _openedCellsCount = 0;
        }

        public void OpenCell(int column, int row)
        {
            if (_model.IsMine(column, row))
            {
                _view.OpenCell(column, row, _view.OpenedMineImage);

                FailGame();
            }
            else
            {
                var cellValue = _model.GetValue(column, row);

                if (cellValue ==  0)
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
                if (!_view.IsCellClosed(column, row))
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

        public void FailGame()
        {
            OpenMines(_view.MineImage);

            _view.FailGame();
        }

        public void SuccessfullyCompleteGame()
        {
            OpenMines(_view.FlagImage);

            _view.SuccessfullyCompleteGame();
        }

        private void OpenMines(Image image)
        {
            var currentIndex = GetCurrentGameModeIndex();

            for (int i = 0; i < GetTableWidth(currentIndex); i++)
            {
                for (int j = 0; j < GetTableHeight(currentIndex); j++)
                {
                    if (_model.IsMine(i, j))
                    {
                        _view.OpenCell(i, j, image);
                    }
                }
            }
        }
    }
}