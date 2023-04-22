namespace Arkashova.TemperatureTask.Model.Scales
{
    internal class CelsiusScale : IScale
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

        public override string ToString()
        {
            return "°C";
        }
    }
}
