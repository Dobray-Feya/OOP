namespace Arkashova.TemperatureTask.Model.Scales
{
    internal class KelvinScale : IScale
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

        public override string ToString()
        {
            return "K";  //Заметка для себя: в случае единиц Кельвина знак градуса не пишут
        }
    }
}