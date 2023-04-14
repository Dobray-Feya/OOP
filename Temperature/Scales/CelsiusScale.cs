namespace Arkashova.TemperatureTask.Scales
{
    internal class CelsiusScale : IScales
    {
        public double ConvertFromCelsius(double temperature)
        {
            return temperature;
        }

        public double ConvertToCelsius(double temperature)
        {
            return temperature;
        }

        public double GetAbsoluteZero()
        {
            return -273.15;
        }

        public char GetUnit()
        {
            return 'C';
        }
    }
}
