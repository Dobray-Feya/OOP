using Arkashova.TemperatureTask.Scales;
using Arkashova.TemperatureTask.Interfaces;

namespace Arkashova.TemperatureTask
{
    internal partial class View : Form
    {
        private readonly ITemperatureConverter _temperatureModel;

        internal View(ITemperatureConverter temperatureModel)
        {
            _temperatureModel = temperatureModel;

            InitializeComponent();

            SetDefaultValues();
        }

        private void SetDefaultValues()
        {
            temperatureFromField.Text = "0";
            temperatureFromInCelsius.Checked = true;
            temperatureToInCelsius.Checked = true;
        }

        private void convertButton_Click(object sender, EventArgs e)
        {
            try
            {
                var resultTemperature = _temperatureModel.ConvertTemperature(GetSourceScale(), GetSourceTemperature(), GetResultScale());

                UpdateTemperature(resultTemperature);
            }
            catch (FormatException)
            {
                ShowError("В качестве температуры нужно ввести число.");
            }
            catch (Exception error)
            {
                ShowError(error.Message);
            }
        }

        internal void UpdateTemperature(double temperatureTo)
        {
            temperatuteToField.Text = Math.Round(temperatureTo, 3, MidpointRounding.AwayFromZero).ToString();
        }

        internal void ShowError(string message)
        {
            MessageBox.Show(message, "Ошибка");
        }

        private IScales GetSourceScale()
        {
            if (temperatureFromInCelsius.Checked)
            {
                return new CelsiusScale();
            }

            if (temperatureFromInFahrenheit.Checked)
            {
                return new FahrenheitScale();
            }

            if (temperatureFromInKelvin.Checked)
            {
                return new KelvinScale();
            }

            throw new InvalidOperationException("Не задана исходная шкала измерения температуры.");
        }

        private double GetSourceTemperature()
        {
            return Convert.ToDouble(temperatureFromField.Text);
        }

        private IScales GetResultScale()
        {
            if (temperatureToInCelsius.Checked)
            {
                return new CelsiusScale();
            }

            if (temperatureToInFahrenheit.Checked)
            {
                return new FahrenheitScale();
            }

            if (temperatureToInKelvin.Checked)
            {
                return new KelvinScale();
            }

            throw new InvalidOperationException("Не задана целевая шкала измерения температуры.");
        }
    }
}