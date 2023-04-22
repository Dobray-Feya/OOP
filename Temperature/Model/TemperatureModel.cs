using Arkashova.TemperatureTask.Model.Scales;

namespace Arkashova.TemperatureTask.Model
{
    internal class TemperatureModel : ITemperatureConverter
    {
        public List<IScale>? ScalesList { get; }

        public TemperatureModel(List<IScale> scalesList)
        {
            ScalesList = scalesList;
        }

        public double ConvertTemperature(IScale sourceScale, double sourceTemperature, IScale resultScale)
        {
            var sourceScaleAbsoluteZero = sourceScale.GetAbsoluteZero();
            var sourceScaleUnit = sourceScale.GetUnit();

            if (sourceTemperature < sourceScaleAbsoluteZero)
            {
                throw new ArgumentOutOfRangeException(nameof(sourceTemperature), $"Температура не может быть меньше абсолютного нуля ({sourceScaleAbsoluteZero} {sourceScale.ToString()})." +
                                                      $" Передана температура {sourceTemperature} {sourceScale.ToString()}");
            }

            return resultScale.ConvertFromCelsius(sourceScale.ConvertToCelsius(sourceTemperature));
        }
    }
}
