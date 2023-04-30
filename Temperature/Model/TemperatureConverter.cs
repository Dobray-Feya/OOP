using Arkashova.TemperatureTask.Model.Scales;

namespace Arkashova.TemperatureTask.Model
{
    internal class TemperatureConverter : ITemperatureConverter
    {
        public List<IScale> ScalesList { get; }

        public TemperatureConverter(List<IScale> scalesList)
        {
            ScalesList = scalesList ?? throw new ArgumentNullException(nameof(scalesList), "Передан список шкал, равный null.");
        }

        public double ConvertTemperature(IScale sourceScale, double sourceTemperature, IScale resultScale)
        {
            var sourceScaleAbsoluteZero = sourceScale.GetAbsoluteZero;

            if (sourceTemperature < sourceScaleAbsoluteZero)
            {
                throw new ArgumentOutOfRangeException(nameof(sourceTemperature), $"Температура не может быть меньше абсолютного нуля ({sourceScaleAbsoluteZero} {sourceScale.ToString()})." +
                                                      $" Передана температура {sourceTemperature} {sourceScale.ToString()}");
            }

            return resultScale.ConvertFromCelsius(sourceScale.ConvertToCelsius(sourceTemperature));
        }
    }
}
