namespace TemperatureTask
{
    public partial class View : Form
    {
        private readonly Controller controller;

        public View(Controller controller)
        {
            this.controller = controller;

            InitializeComponent();

            temperatureFromField.Text = "0";
            temperatureFromInCelsius.Checked = true;
            temperatureToInCelsius.Checked = true;
        }

        private void convertButton_Click(object sender, EventArgs e)
        {
            TemperatureScale temperatureFromScale;
            TemperatureScale temperatureToScale;

            if (temperatureFromInCelsius.Checked)
            {
                temperatureFromScale = TemperatureScale.Celsius;
            }
            else if (temperatureFromInFahrenheit.Checked)
            {
                temperatureFromScale = TemperatureScale.Fahrenheit;
            }
            else if (temperatureFromInKelvin.Checked)
            {
                temperatureFromScale = TemperatureScale.Kelvin;
            }
            else
            {
                ShowError("Не задана исходная шкала измерения температуры.");
                return;
            }

            if (temperatureToInCelsius.Checked)
            {
                temperatureToScale = TemperatureScale.Celsius;
            }
            else if (temperatureToInFahrenheit.Checked)
            {
                temperatureToScale = TemperatureScale.Fahrenheit;
            }
            else if (temperatureToInKelvin.Checked)
            {
                temperatureToScale = TemperatureScale.Kelvin;
            }
            else
            {
                ShowError("Не задана целевая шкала измерения температуры.");
                return;
            }

            try
            {
                controller.ConvertTemperature(temperatureFromField.Text, temperatureFromScale, temperatureToScale);
            }
            catch (ArgumentNullException er)
            {
                View view = (View)sender;
                view.ShowError(er.Message);
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
    }
}