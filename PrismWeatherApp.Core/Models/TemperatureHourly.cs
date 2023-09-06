namespace PrismWeatherApp.Core.Models
{
    public class TemperatureHourly
    {
        public List<DateTime> time { get; set; }
        public List<double> temperature_2m { get; set; }
    }
}
