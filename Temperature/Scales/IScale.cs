namespace Arkashova.TemperatureTask.Scales
{
    internal interface IScales
    {
        double ConvertFromCelsius(double temperatire);
        
        double ConvertToCelsius(double temperatire);

        double GetAbsoluteZero();

        char GetUnit();
    }
}
