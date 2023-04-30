using Arkashova.TemperatureTask.Model.Scales;

namespace Arkashova.TemperatureTask.Model
{
    internal interface ITemperatureConverter
    {
        public List<IScale> ScalesList { get; }

        double ConvertTemperature(IScale sourceScale, double sourceTemperature, IScale resultScale);
    }
}