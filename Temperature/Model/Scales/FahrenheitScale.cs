namespace Arkashova.TemperatureTask.Model.Scales
{
    internal class FahrenheitScale : IScale
    {
        public double GetAbsoluteZero => -459.67;

        public char GetUnit => 'F';

        public double ConvertFromCelsius(double temperature)
        {
            return 9 * temperature / 5 + 32;
        }

        public double ConvertToCelsius(double temperature)
        {
            return (temperature - 32) * 5 / 9;
        }

        public override string ToString()
        {
            return "°F";
        }
    }
}