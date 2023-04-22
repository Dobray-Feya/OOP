namespace Arkashova.TemperatureTask.Model.Scales
{
    internal interface IScale
    {
        double ConvertFromCelsius(double temperatire);
        
        double ConvertToCelsius(double temperatire);

        double GetAbsoluteZero();

        char GetUnit();

        string ToString();
    }
}