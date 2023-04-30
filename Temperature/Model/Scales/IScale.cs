namespace Arkashova.TemperatureTask.Model.Scales
{
    internal interface IScale
    {
        double GetAbsoluteZero { get; }

        char GetUnit { get; }

        double ConvertFromCelsius(double temperature);

        double ConvertToCelsius(double temperature);

        string ToString();
    }
}