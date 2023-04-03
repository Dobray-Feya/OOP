// ������� ��� ����: ���� ���� ����� ����� �������. ������ ���� ����� �������� ��������� � ����������� �����
// � ����� ������������� ��������� ����� ��� ������ � UI �������

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