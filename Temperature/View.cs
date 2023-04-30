using Arkashova.TemperatureTask.Model.Scales;
using Arkashova.TemperatureTask.Model;

namespace Arkashova.TemperatureTask
{
    internal partial class View : Form
    {
        private readonly ITemperatureConverter _temperatureConverter;

        internal View(ITemperatureConverter temperatureConverter)
        {
            _temperatureConverter = temperatureConverter ?? throw new ArgumentNullException(nameof(temperatureConverter));

            InitializeComponent();

            SetDefaultValues();
        }

        private void SetDefaultValues()
        {
            temperatureFromField.Text = "0";

            var scalesList = _temperatureConverter.ScalesList;

            if (scalesList is null)
            {
                throw new ArgumentNullException(nameof(scalesList), "Температурная модель не содержит шкал.");
            }

            foreach (var scale in scalesList)
            {
                sourceScalesListBox.Items.Add(scale.GetUnit);
                resultScalesListBox.Items.Add(scale.GetUnit);
            }

            sourceScalesListBox.SetSelected(0, true);
            resultScalesListBox.SetSelected(0, true);
        }

        private void convertButton_Click(object sender, EventArgs e)
        {
            try
            {
                var resultTemperature = _temperatureConverter.ConvertTemperature(GetSourceScale(), GetSourceTemperature(), GetResultScale());

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

        private static void ShowError(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private IScale GetSourceScale()
        {
            var scaleIndex = sourceScalesListBox.SelectedIndex;

            if (scaleIndex == -1)
            {
                throw new InvalidOperationException("Не задана исходная шкала измерения температуры.");
            }

            return _temperatureConverter.ScalesList[scaleIndex];
        }

        private double GetSourceTemperature()
        {
            return Convert.ToDouble(temperatureFromField.Text);
        }

        private IScale GetResultScale()
        {
            var scaleIndex = resultScalesListBox.SelectedIndex;

            if (scaleIndex == -1)
            {
                throw new InvalidOperationException("Не задана целевая шкала измерения температуры.");
            }

            return _temperatureConverter.ScalesList[scaleIndex];
        }
    }
}