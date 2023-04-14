// Заметка для себя: этот файл редко нужно править. Только если хотим передать аргументы в конструктор формы
// В файле автоматически создается метод для работы с UI потоком

namespace Arkashova.TemperatureTask
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

            var temperatureModel = new TemperatureModel();

            var view = new View(temperatureModel);

            Application.Run(view);
        }
    }
}