namespace Arkashova.TemperatureTask.Scales
{
    internal class KelvinScale : IScales
    {
        public double ConvertFromCelsius(double temperature)
        {
            return temperature + 273.15;
        }

        public double ConvertToCelsius(double temperature)
        {
            return temperature - 273.15;
        }

        public double GetAbsoluteZero()
        {
            return 0;
        }

        public char GetUnit()
        {
            return 'K';
        }
    }
}
