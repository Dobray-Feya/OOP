using Arkashova.Minesweeper;
using Arkashova.Minesweeper.Logic;
using Arkashova.Minesweeper.Controller;
using System.Windows.Forms;

namespace MinesweeperTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test");

            //var mode = new CustomMode(11, 12, 13);
            var mode = new BeginnerMode();

            var model = new MinesweeperModel(mode);

            //var IView = new View();

            //var controller = new Controller(view, model);

            var controller = new Controller();

            Console.WriteLine(controller.GetTableWidth());
            Console.WriteLine(controller.GetTableHeight());
            Console.WriteLine(controller.GetMinesCount());

            for (int i = 0; i < controller.GetTableWidth(); i++)
            {
                for (int j = 0; j < controller.GetTableHeight(); j++)
                {
                    Console.Write(controller.GetValue(i, j) + " ");
                }

                Console.WriteLine();
            }
        }
    }
}