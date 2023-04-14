using Arkashova.TemperatureTask.Scales;

namespace Arkashova.TemperatureTask.Interfaces
{
    internal interface ITemperatureConverter
    {
        double ConvertTemperature(IScales sourceScale, double sourceTemperature, IScales resultScale);
    }
}