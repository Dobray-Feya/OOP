namespace Arkashova.TemperatureTask.Model.Scales
{
    internal class CelsiusScale : IScale
    {
        public double GetAbsoluteZero => -273.15;

        public char GetUnit => 'C';

        public double ConvertFromCelsius(double temperature)
        {
            return temperature;
        }

        public double ConvertToCelsius(double temperature)
        {
            return temperature;
        }

        public override string ToString()
        {
            return "°C";
        }
    }
}
