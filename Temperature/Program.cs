// ������� ��� ����: ���� ���� ����� ����� �������. ������ ���� ����� �������� ��������� � ����������� �����
// � ����� ������������� ��������� ����� ��� ������ � UI �������

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