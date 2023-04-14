using Arkashova.TemperatureTask.Scales;
using Arkashova.TemperatureTask.Interfaces;

namespace Arkashova.TemperatureTask
{
    internal class TemperatureModel : ITemperatureConverter
    {
        public double ConvertTemperature(IScales sourceScale, double sourceTemperature, IScales resultScale)
        {
            var sourceScaleAbsoluteZero = sourceScale.GetAbsoluteZero();
            var sourceScaleUnit = sourceScale.GetUnit();

            if (sourceTemperature < sourceScaleAbsoluteZero)
            {
                throw new ArgumentOutOfRangeException(nameof(sourceTemperature), $"Температура не может быть меньше абсолютного нуля ({sourceScaleAbsoluteZero} °{sourceScaleUnit}). Передана температура {sourceTemperature} °{sourceScaleUnit}");
            }

            return resultScale.ConvertFromCelsius(sourceScale.ConvertToCelsius(sourceTemperature));
        }
    }
}
