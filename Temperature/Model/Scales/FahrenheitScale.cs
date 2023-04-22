namespace Arkashova.TemperatureTask.Model.Scales
{
    internal class FahrenheitScale : IScale
    {
        public double ConvertFromCelsius(double temperature)
        {
            return 9 * temperature / 5 + 32;
        }

        public double ConvertToCelsius(double temperature)
        {
            return (temperature - 32) * 5 / 9;
        }

        public double GetAbsoluteZero()
        {
            return -459.67;
        }

        public char GetUnit()
        {
            return 'F';
        }

        public override string ToString()
        {
            return "°F";
        }
    }
}