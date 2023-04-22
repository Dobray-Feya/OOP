// Заметка для себя: этот файл редко нужно править. Только если хотим передать аргументы в конструктор формы
// В файле автоматически создается метод для работы с UI потоком

using Arkashova.TemperatureTask.Model;
using Arkashova.TemperatureTask.Model.Scales;

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

            var scalesList = new List<IScale>()
            {
                new CelsiusScale(),
                new KelvinScale(),
                new FahrenheitScale()
            };

            var temperatureModel = new TemperatureModel(scalesList);

            var view = new View(temperatureModel);

            Application.Run(view);
        }
    }
}