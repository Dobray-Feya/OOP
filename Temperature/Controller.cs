namespace TemperatureTask
{
    public class Controller
    {
        private readonly TemperatureModel temperatureModel;
        private View view;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Controller(TemperatureModel temperatureModel)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            this.temperatureModel = temperatureModel;
        }

        public void SetView(View view)
        {
            this.view = view;
        }

        public void ConvertTemperature(string temperatureFromText, TemperatureScale temperatureFromScale, TemperatureScale temperatureToScale)
        {
            try
            {
                var temperatureTo = temperatureModel.ConvertTemperature(Convert.ToDouble(temperatureFromText), temperatureFromScale, temperatureToScale);

                view.UpdateTemperature(temperatureTo);
            }
            catch (FormatException)
            {
                view.ShowError("В качестве температуры нужно ввести число.");
            }
            catch (Exception e)
            {
                view.ShowError(e.Message);
            }
        }
    }
}
