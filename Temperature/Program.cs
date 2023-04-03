// Заметка для себя: этот файл редко нужно править. Только если хотим передать аргументы в конструктор формы
// В файле автоматически создается метод для работы с UI потоком

namespace TemperatureTask
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

            TemperatureModel temperatuteModel = new TemperatureModel();

            Controller controller = new Controller(temperatuteModel);

            View view = new View(controller);

            controller.SetView(view);

            Application.Run(view);
        }
    }
}