using Arkashova.TemperatureTask.Model.Scales;
using Arkashova.TemperatureTask.Model;

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

            var scalesList = _temperatureModel.ScalesList;

            if (scalesList is null)
            {
                throw new ArgumentNullException(nameof(scalesList), "Температурная модель не содержит шкал.");
            }

            for (int i = 0; i < scalesList.Count; i++)
            {
                sourceScalesListBox.Items.Add(scalesList[i].GetUnit());
                resultScalesListBox.Items.Add(scalesList[i].GetUnit());
            }

            sourceScalesListBox.SetSelected(0, true);
            resultScalesListBox.SetSelected(0, true);
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

        private static void ShowError(string message)
        {
            MessageBox.Show(message, "Ошибка");
        }

        private IScale GetSourceScale()
        {
            var scaleIndex = sourceScalesListBox.SelectedIndex; 
            
            if (scaleIndex == -1)
            {
                throw new InvalidOperationException("Не задана исходная шкала измерения температуры.");
            }

            return _temperatureModel.ScalesList![scaleIndex];
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

            return _temperatureModel.ScalesList![scaleIndex];
        }
    }
}