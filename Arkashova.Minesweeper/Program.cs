using Arkashova.Minesweeper.Logic;
using Arkashova.Minesweeper.Logic.GameModes;
using Arkashova.Minesweeper.Controller;

namespace Arkashova.Minesweeper
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var gameModesList = new List<GameMode>
            {
                new BeginnerMode(),
                new IntermediateMode(),
                new ExpertMode(),
                new SpecialMode()
            };

            var model = new MinesweeperModel(gameModesList, 0);

            var controller = new MinesweeperController(model);

            var view = new MainWindow(controller);

            controller.SetView(view);

            Application.Run(view);
        }
    }
}