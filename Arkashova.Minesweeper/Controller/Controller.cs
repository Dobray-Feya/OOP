using Arkashova.Minesweeper.Logic;
using System.Reflection;
using System.Windows.Forms;

namespace Arkashova.Minesweeper.Controller
{
    public class Controller // Get, Set по отношению к модели //change on internal after test
    {
        public IModel _model;

        /*private View _view;

        internal Controller(IModel model, View view)
        {
            _model = model;
            _view = view;

            model.GameMode = GetGameMode();
        }*/

        public Controller()
        {
            //var mode = GetGameMode();
            var mode = new BeginnerMode();
            //var mode = new CustomMode(11, 12, 13);

            _model = new MinesweeperModel(mode);
        }

        public int GetTableWidth()
        {
            return _model.GameMode.FieldWidth;
        }

        public void SetTableWidth(int value)
        {
            _model.GameMode.FieldWidth = value;
        }

        public int GetTableHeight()
        {
            return _model.GameMode.FieldHeight;
        }

        public void SetTableHeight(int value)
        {
            _model.GameMode.FieldHeight = value;
        }

        public int GetMinesCount()
        {
            return _model.GameMode.MinesCount;
        }

        public void SetMinesCount(int value)
        {
            _model.GameMode.MinesCount = value;
        }

        public int GetValue(int x, int y) // order? лишний?
        {
            return _model.Table[x, y]; // handler for wrong values
        }

        /*public GameMode GetGameMode()
        {
            if (true) //checked beginner mode
            {
                return new CustomMode();  //!!!!
            };
        }*/

        public void SetGameMode(GameMode mode)
        {
            _model.GameMode = mode;
        }
    }
}
