namespace TemperatureTask
{
    public class TemperatureModel
    {
        private readonly double AbsoluteZeroInCelsius = -273.15;
        private readonly double AbsoluteZeroInFahrenheit = -459.67;
        private readonly double AbsoluteZeroInKelvin = 0;

        private char celsiusUnit = 'C';
        private char fahrenheitUnit = 'F';
        private char kelvinUnit = 'K';

        public double ConvertTemperature(double temperatureFrom, TemperatureScale scaleFrom, TemperatureScale scaleTo)
        {
            double absoluteZero;
            char unit;

            switch (scaleFrom)
            {
                case TemperatureScale.Fahrenheit:
                    absoluteZero = AbsoluteZeroInFahrenheit;
                    unit = fahrenheitUnit;
                    break;
                case TemperatureScale.Kelvin:
                    absoluteZero = AbsoluteZeroInKelvin;
                    unit = kelvinUnit;
                    break;
                default:
                    absoluteZero = AbsoluteZeroInCelsius;
                    unit = celsiusUnit;
                    break;
            }

            if (temperatureFrom < absoluteZero)
            {
                throw new ArgumentOutOfRangeException(nameof(temperatureFrom), $"Температура не может быть меньше абсолютного нуля ({absoluteZero} °{unit}). Передана температура {temperatureFrom} °{unit}");
            }

            if (scaleFrom == scaleTo)
            {
                return temperatureFrom;
            }

            if (scaleFrom == TemperatureScale.Celsius)
            {
                if (scaleTo == TemperatureScale.Kelvin)
                {
                    return ConvertCelsiusToKelvin(temperatureFrom);
                }
                else
                {
                    return ConvertCelsiusToFahrenheit(temperatureFrom);
                }
            }

            if (scaleFrom == TemperatureScale.Fahrenheit)
            {
                if (scaleTo == TemperatureScale.Kelvin)
                {
                    return ConvertFahrenheitToKelvin(temperatureFrom);
                }
                else
                {
                    return ConvertFahrenheitToCelsius(temperatureFrom);
                }
            }

            if (scaleTo == TemperatureScale.Fahrenheit)
            {
                return ConvertKelvinToFahrenheit(temperatureFrom);
            }

            return ConvertKelvinToCelsius(temperatureFrom);
        }

        private static double ConvertCelsiusToKelvin(double temperatureInCelsius)
        {
            return temperatureInCelsius + 273.15;
        }

        public static double ConvertCelsiusToFahrenheit(double temperatureInCelsius)
        {
            return 9 * temperatureInCelsius / 5 + 32;
        }

        private static double ConvertKelvinToCelsius(double temperatureInKelvin)
        {
            return temperatureInKelvin - 273.15;
        }

        public static double ConvertFahrenheitToCelsius(double temperatureInFahrenheit)
        {
            return (temperatureInFahrenheit - 32) * 5 / 9;
        }

        private static double ConvertKelvinToFahrenheit(double temperatureInKelvin)
        {
            return ConvertCelsiusToFahrenheit(ConvertKelvinToCelsius(temperatureInKelvin));
        }

        public static double ConvertFahrenheitToKelvin(double temperatureInFahrenheit)
        {
            return ConvertCelsiusToKelvin(ConvertFahrenheitToCelsius(temperatureInFahrenheit));
        }
    }
}
